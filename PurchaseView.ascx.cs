using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Jenzabar.Common;
using Jenzabar.Portal.Framework;
using Jenzabar.Common.Web.UI.Controls;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Common.ApplicationBlocks.Data;

namespace CUS.ICS.BulldogBucksFrARCredit
{
    public partial class PurchaseView : PortletViewBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblError.Visible = false;
            Int32 idnumInt = 0;
            String curtime = "";
            DateTime Now = DateTime.Now;
            curtime = Now.ToString();

            string purchamt = Session["purch"].ToString();
            Double postamt = Convert.ToDouble(purchamt);
            string id = Session["idnum"].ToString();
            idnumInt = Convert.ToInt32(id);
           
            
            String posttim = Session["posttime"].ToString();
            DateTime postTime = Convert.ToDateTime(posttim);
            TimeSpan diff = Now - postTime;
            String timediff = diff.Minutes.ToString();
            Int16 timeinterval = Convert.ToInt16(timediff);
           
            Double creditamt = 0.0;
            string sqlInsert = "";
            String curryrin = "";
            String currtrmin = "";
            String grpnum = "";
            String sqlTransInsertCr = "";
            String sqlTransInsertDb = "";
            int transhistline = 0;
            int result = 0;
            int transhistout = 0;
            MailMessage msg = new MailMessage();

            SqlConnection dbcon = null;

            this.purchamount.Text = postamt.ToString("C");

            dbcon = new SqlConnection(
                                System.Configuration.ConfigurationManager
                                .ConnectionStrings["JenzabarConnectionString"]
                                .ConnectionString);

            dbcon.Open();

            SqlCommand sqlcmdARCredit = new SqlCommand(
                            "select (sum(trans_amt) "
                          + "+ (select ar_hist_begin_bal from subsid_master where subsid_cde = 'SR' and id_num = '" + idnumInt + "')) as total"
                          + " from trans_hist"
                          + " where subsid_cde = 'SR' and id_num = '" + idnumInt + "'", dbcon);

            // Populate from from DB
            SqlDataReader ARreader = sqlcmdARCredit.ExecuteReader();
            if (ARreader.HasRows)
            {

                while (ARreader.Read())
                {
                    
                    string sum = ARreader["total"].ToString();
                    creditamt = Convert.ToDouble(sum);


                    if (creditamt < 0.0)
                    {
                        creditamt = creditamt * (-1.0);
                        //    this.cramount.Text = "< 0";

                    }
                    else
                    {
                        creditamt = 0.0;
                    }


             //       if (enrhours < 12.0)
             //       {
             //           creditamt = 0.0;
             //       }

                    string cramount = creditamt.ToString();
                }

            }
            ARreader.Close();

            if (postamt > 0.0 && postamt <= creditamt)
            {
               
                try
                {
                    

                    /*  get current year and term */
                    String getyrtrm = "";
                    getyrtrm = "SELECT CURR_YR,CURR_TRM from CUST_INTRFC_CNTRL where INTRFC_TYPE = 'CURR'";
                    SqlCommand sqlGetTrm = new SqlCommand(getyrtrm, dbcon);

                    SqlDataReader yrtrmReader = sqlGetTrm.ExecuteReader();

                    if (yrtrmReader.HasRows)
                    {
                        while (yrtrmReader.Read())
                        {
                            curryrin = yrtrmReader["curr_yr"].ToString();
                            currtrmin = yrtrmReader["curr_trm"].ToString();
                        }

                    }
                    yrtrmReader.Close();

                    try
                    {
                        /*  Is there a batch open for today?  If so, update. If not, get batch control num and open batch */
                        String grpdesc = "";
                        String grpdte = "";

                        String getbatchinfo = "";
                        getbatchinfo = "select group_num,trans_desc,trans_dte,trans_key_line_num from trans_hist where source_cde = 'MS' and trans_desc like 'BDBucksFrCredit%' and subsid_trans_sts = 'S' order by trans_dte,trans_key_line_num";
                        SqlCommand sqlGetBatchInfo = new SqlCommand(getbatchinfo, dbcon);

                        SqlDataReader batchinfoReader = sqlGetBatchInfo.ExecuteReader();
                        if (batchinfoReader.HasRows)
                        {
                            while (batchinfoReader.Read())
                            {
                                grpnum = batchinfoReader["group_num"].ToString();
                                grpdesc = batchinfoReader["trans_desc"].ToString();
                                grpdte = batchinfoReader["trans_dte"].ToString();
                                transhistline = Convert.ToInt32(batchinfoReader["trans_key_line_num"].ToString());

                            }



                            batchinfoReader.Close();
                            DateTime newgrpdate = Convert.ToDateTime(grpdte);
                            result = DateTime.Compare(Now.Date, newgrpdate.Date);
                        }
                        else
                        {
                            batchinfoReader.Close();
                            result = 1;
                        }

                    }
                    catch
                    {
                        this.lblError.Text = "Error in get batch info";
                        this.lblError.Visible = true;
                    }

                    try
                    {
                        if (result != 0)  /*  No batch is open today; so, open one  */
                        {



                            /*  get batch control number   */

                            String getgrpnumctl = "";
                            getgrpnumctl = "SELECT GRP_NUM_CTL FROM SOURCE_MASTER WHERE SOURCE_CDE = 'MS'";
                            SqlCommand sqlGetGrpNum = new SqlCommand(getgrpnumctl, dbcon);

                            SqlDataReader grpnumReader = sqlGetGrpNum.ExecuteReader();
                            if (grpnumReader.HasRows)
                            {
                                while (grpnumReader.Read())
                                {
                                    grpnum = grpnumReader["grp_num_ctl"].ToString();
                                }
                            }
                            grpnumReader.Close();

                            /*  Insert new batch control record  */
                            int newgrpnum = Convert.ToInt32(grpnum);
                            String sqlInsertNewBtch = "insert into trans_batch_ctl (source_cde,group_num,grp_desc,grp_dte,grp_sts,user_name,job_name,job_time)"
                                                    + " values ('MS','" + newgrpnum + "','BDBucksFrCredit','" + curtime + "','S','Jenzabar','BDBucksFrCredit','" + curtime + "')";
                            SqlCommand sqlNewBatch = new SqlCommand(sqlInsertNewBtch, dbcon);
                            sqlNewBatch.ExecuteNonQuery();

                            /*  increment batch control number */
                            
                                newgrpnum = newgrpnum + 1;
                                String updtgrpnumctl = "update source_master set grp_num_ctl = " + newgrpnum + " where source_cde = 'MS'";
                                SqlCommand sqlupdtgrpnumctl = new SqlCommand(updtgrpnumctl, dbcon);
                                sqlupdtgrpnumctl.ExecuteNonQuery();
                           



                        }  /* End of batch control update  */
                    }
                    catch
                    {
                        this.lblError.Text = "error in no batch";
                        this.lblError.Visible = true;
                    }

                    try
                    {
                        /*  Insert records into TRANS_HIST as 'S' suspended transactions.  Finance office will post to GL */

                        transhistout = transhistline + 1;
                        
                            sqlTransInsertCr = "insert into trans_hist(source_cde,group_num,trans_key_line_num,trans_dte,trans_amt,trans_desc"
                                             + ",acct_cde,id_num,subsid_cde,offset_flag,chg_fee_cde,subsid_trans_sts,encumb_gl_trans_st"
                                             + ",encumb_gl_flag,chg_yr_tran_hist,chg_trm_tran_hist,user_name,job_name,job_time,check_num_alpha)"
                                             + " values('MS','" + grpnum + "','" + transhistout + "','" + curtime + "','" + postamt + "'"
                                             + ", 'BDBucksFrCreditBal','1    5    9001 1210 900  90   ','" + id + "','SR','R','BBUCK','S','S','G'"
                                             + ",'" + curryrin + "','" + currtrmin + "','JENZABAR','BDBucksFrCredit','" + curtime + "','" + timediff + "')";
                            SqlCommand sqlTransCr = new SqlCommand(sqlTransInsertCr, dbcon);
                            sqlTransCr.ExecuteNonQuery();


                            transhistout = transhistline + 2;
                            postamt = postamt * (-1.0);

                            sqlTransInsertDb = "insert into trans_hist(source_cde,group_num,trans_key_line_num,trans_dte,trans_amt,trans_desc"
                                             + ",acct_cde,id_num,offset_flag,chg_fee_cde,subsid_trans_sts,encumb_gl_trans_st"
                                             + ",encumb_gl_flag,chg_yr_tran_hist,chg_trm_tran_hist,user_name,job_name,job_time)"
                                             + " values('MS','" + grpnum + "','" + transhistout + "','" + curtime + "','" + postamt + "'"
                                             + ", 'BDBucksFrCreditBal','1    5    9001 2215 900  90   ','" + id + "','O','BBUCK','S','S','G'"
                                             + ",'" + curryrin + "','" + currtrmin + "','JENZABAR','BDBucksFrCredit','" + curtime + "')";
                            SqlCommand sqlTransDb = new SqlCommand(sqlTransInsertDb, dbcon);
                            sqlTransDb.ExecuteNonQuery();
                        }
                   
                    catch
                    {
                        this.lblError.Text = sqlTransInsertDb;
                        this.lblError.Visible = true;
                    }

                    /*  Store transaction to transfer money to CBORD meal system  */
                    String tranhistkey = "MS-" + grpnum + "-" + transhistout.ToString();
                    sqlInsert = "INSERT INTO [dbo].[tlu_submission] "
                           + "(tlu_submission_dte,tlu_submitter_id,tlu_submission_sts,tlu_submission_amt,trans_hist_key,USERNAME,JOB_NAME,JOB_TIME) "
                           + "VALUES('" + curtime + "','" + id + "','H','" + purchamt + "','" + tranhistkey + "','Jenzabar','BDBucksFrARCredit','" + curtime + "')";
                    SqlCommand sqlStmt = new SqlCommand(sqlInsert, dbcon);
                    sqlStmt.ExecuteNonQuery();

                    dbcon.Close();

                    msg.To.Add("gmerkle@tlu.edu,erichardson@tlu.edu");
                    msg.From = new MailAddress("jenzabardb@tlu.edu");
                    msg.Subject = "BD Bucks from Credit Balance";
                    msg.Body = "BD Bucks purch from Credit:  ID: " + id + " amount: " + purchamt;
                    SmtpClient smtp = new SmtpClient("mail.tlu.edu");
                    smtp.Send(msg);


                }
                catch
                {
                    this.lblError.Text = "error occurred in dbcon insert attempt" + sqlInsert;
                    this.lblError.Visible = true;
                    dbcon.Close();
                }
            }
            else
            {
                dbcon.Close();
                this.ParentPortlet.State = PortletState.Maximized;
                this.ParentPortlet.NextScreen("NoPurchaseView");
                
            }
        }
    }
}