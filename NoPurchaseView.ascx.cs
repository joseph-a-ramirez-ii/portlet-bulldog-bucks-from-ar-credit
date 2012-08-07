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
    public partial class NoPurchaseView : PortletViewBase
    {
     

        protected void Page_Load(object sender, System.EventArgs e)
        {
            
            string creditavailable = Session["credit"].ToString();
      
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