using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Jenzabar.Common;
using Jenzabar.Common.Web.UI.Controls;
using Jenzabar.Common.Globalization;
using Jenzabar.Portal.Framework.Web.UI;

namespace CUS.ICS.BulldogBucksFrARCredit
{
    public partial class MainView : PortletViewBase
    {
     

        protected void Page_Load(object sender, System.EventArgs e)
        {

            btnPurchase.OnClientClick = string.Format("javascript:{0}.style.visibility = 'hidden';{0}.style.display  = 'none';{1}.style.visibility = 'visible'", btnPurchase.ClientID, btnPurchaseDisabled.ClientID);
            
            string creditavailable = Session["credit"].ToString();
       //     Double creditout = Convert.ToDouble(creditavailable);
            this.cramt.Text = creditavailable.ToString();
            string purchrequest = Session["purch"].ToString();
           
            Double purchase = Convert.ToDouble(purchrequest);
            this.cramtpost.Text = purchase.ToString("C");

            
        //    if (!IsPostBack)
        //    {
        //        sourcepage = (DefaultView)Context.Handler;
         //       cramtinput.Text = sourcepage.entamount;
         //   }
        }

        protected void btnPurchase_Click(object sender, System.EventArgs e)
        {
            
            
            
            this.ParentPortlet.State = PortletState.Maximized;
            this.ParentPortlet.NextScreen("PurchaseView");

        }

        protected void glnkAdmin_Click(object sender, EventArgs e)
        {
            this.ParentPortlet.NextScreen("Admin");
        }
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion
        }


   }
