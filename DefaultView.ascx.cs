using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

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
    public partial class DefaultView : PortletViewBase
    {
        String usernm = "";
        String idnum = "";
        String curtime = "";
        Int32 idnumInt = 0;
   
        Double creditamt = 0.0;
        String ptft = "";
        Double pthrs = 0.0;
        String sum = "";

        SqlConnection sqlcon = null;
        
        

        protected void Page_Load(object sender, System.EventArgs e)
        {
            //  if (Jenzabar.Portal.Framework.PortalUser.Current.IsMemberOf(PortalGroup.Students))
            //  {
            Session["credit"] = cramount.Text.ToString();
            Session["purch"] = cramtin.Text.ToString();
            Session["idnum"] = Jenzabar.Portal.Framework.PortalUser.Current.HostID;
            Session["hours"] = ptft;
            DateTime Now = DateTime.Now;
            Session["posttime"] = Now.ToString();
           
            this.ParentPortlet.State = PortletState.Default;

            if (!ParentPortlet.AccessCheck("CanAccessPortlet"))
            {
              //  this.ParentPortlet.ShowFeedbackGlobalized(FeedbackType.Message, "CUS_HEALTHFORM_ACCESS_DENIED_MESSAGE");


            }
            if (ParentPortlet.AccessCheck("CanAdminPortlet"))
            {

            }


            if (IsFirstLoad)
            {
                
                idnum = this.tluid.Text;
                //  }
                //  else
                //  {
                // Get and populate known user information
                this.ParentPortlet.State = PortletState.Maximized;


                try
                {
                    sqlcon = new SqlConnection(
                        System.Configuration.ConfigurationManager
                        .ConnectionStrings["JenzabarConnectionString"]
                        .ConnectionString);

                    sqlcon.Open();

                    //****************************************
                    // Try to populate 
                    //****************************************
                    try
                    {

                        usernm = Jenzabar.Portal.Framework.PortalUser.Current.Username;
                        //    usernmDB = this.usernm.Text;
                       SqlCommand sqlcmdBDBucksPerson = new SqlCommand(
                        "SELECT a.ID_NUM, a.LAST_NAME, a.FIRST_NAME, a.MIDDLE_NAME, b.hrs_enrolled "
                      + "FROM NAME_MASTER a LEFT JOIN STUD_TERM_SUM_DIV b "
                      + "ON a.ID_NUM = b.ID_NUM "
                      + "WHERE a.ID_NUM = '" + Jenzabar.Portal.Framework.PortalUser.Current.HostID + "'"
                      + " and b.yr_cde = (select CURR_YR from CUST_INTRFC_CNTRL where INTRFC_TYPE = 'BUCKSFRARCREDIT_PORTLET') "
                      + " and b.trm_cde = (select CURR_TRM from CUST_INTRFC_CNTRL where INTRFC_TYPE = 'BUCKSFRARCREDIT_PORTLET')", sqlcon);

                        SqlDataReader reader = sqlcmdBDBucksPerson.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                this.tluid.Text = reader["ID_NUM"].ToString();
                                this.lname.Text = reader["LAST_NAME"].ToString();
                                this.fname.Text = reader["FIRST_NAME"].ToString();
                                this.mname.Text = reader["MIDDLE_NAME"].ToString();
                                //         this.usernm.Text = Jenzabar.Portal.Framework.PortalUser.Current.NameDetails.DisplayName.ToString();

                                
                                idnum = reader["ID_NUM"].ToString();
                                idnumInt = Convert.ToInt32(idnum);

                                ptft = reader["hrs_enrolled"].ToString();
                                pthrs = Convert.ToDouble(ptft);
                                this.hrsenrolled.Text = reader["hrs_enrolled"].ToString();

                            }

                        }
                        reader.Close();
                        
                        SqlCommand sqlcmdARCredit = new SqlCommand(
                            "select (sum(trans_amt) "
                          + "+ (select ar_hist_begin_bal from subsid_master where subsid_cde = 'SR' and id_num = '" + idnumInt + "')) as total"
                          + " from trans_hist"
                          + " where subsid_cde = 'SR' and id_num = '" + idnumInt + "'", sqlcon);
                           
                        // Populate from from DB
                        SqlDataReader ARreader = sqlcmdARCredit.ExecuteReader();
                        if (ARreader.HasRows)
                        {

                            while (ARreader.Read())
                            {
                           
                                sum = ARreader["total"].ToString();
                                this.creditamt =  Convert.ToDouble(sum);
                         
                         
                                if (creditamt < 0.0)
                                {
                                    creditamt = creditamt * (-1.0);
                                //    this.cramount.Text = "< 0";

                                }
                                else
                                {
                                    creditamt = 0.0;
                                }

                                                         
                             if (pthrs < 12.0)
                                {
                                    creditamt = 0.0;
                                }
                                
                             this.cramount.Text = this.creditamt.ToString();
                            }

                        }
                       ARreader.Close();
                      
                     
                    } //Try close

                    catch 
                    {
                        lname.Enabled = false;
                        lname.Enabled = false;

                    }

                }
                catch 
                {

                    sqlcon.Close();
                }
            }  //FirstLoad close
        } //Protected class close

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
         
            
         //   if (Page.IsPostBack)
         //   {
                
                if (Page.IsValid)
                {
                    SqlConnection sqlconUp = new SqlConnection(
                    System.Configuration.ConfigurationManager
                           .ConnectionStrings["JenzabarConnectionString"]
                           .ConnectionString);
                    sqlconUp.Open();

                    String pageItem;
              //      String cmtText;
             //       String sqlInsert;
                    DateTime Now = DateTime.Now;
                    pageItem = Now.ToString();
                    curtime = Now.ToString();
                    idnum = this.tluid.Text;
                    lblComplete.Text = "";
                    this.ParentPortlet.State = PortletState.Maximized;
                    this.ParentPortlet.NextScreen("MainView");
                  //  Server.Transfer("MainView.ascx");
                }
                else
                {
                    this.ParentPortlet.State = PortletState.Maximized;
                    lblComplete.Text = "Please correct any errors and resubmit form";
                //    this.ParentPortlet.NextScreen("DefaultView");
                }
           // }
        }

        public string entamount
        {
            get
            {
                return cramtin.Text;
            }
        }
   
     


    }  //Public class close
}
