    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jenzabar.Common;
using Jenzabar.Portal.Framework;
using Jenzabar.Portal.Framework.Web;
using Jenzabar.Portal.Framework.Web.UI;
using Jenzabar.Portal.Framework.Security.Authorization;

#region "Settings - Optional"
	/// <summary>
	/// 
	
	/// </summary>
	/// 	


#endregion

namespace CUS.ICS.BulldogBucksFrARCredit
{
    [PortletOperation(
        "CANACCESS",
        "Can Access Portlet",
        "Whether a user can access this portlet or not",
        PortletOperationScope.Global)]

    [PortletOperation(
        "CanAdminPortlet",
        "Can Admin Portlet",
        "Whether a user can admin this portlet or not",
        PortletOperationScope.Global)]

  public partial class BulldogBucksFrARCredit : SecuredPortletBase
    {

        protected override PortletViewBase GetCurrentScreen()
        {
            switch (this.CurrentPortletScreenName)
            {
                case "MainView":

                    State = PortletState.Maximized;
                    
                    return this.LoadPortletView("ICS/BulldogBucksFrARCredit/MainView.ascx");
                case "DefaultView":
                    return this.LoadPortletView("ICS/BulldogBucksFrARCredit/DefaultView.ascx");
                case "PurchaseView":
                    return this.LoadPortletView("ICS/BulldogBucksFrARCredit/PurchaseView.ascx");
                case "ThankYouView":
                    return this.LoadPortletView("ICS/BulldogBucksFrARCredit/ThankYouView.ascx");
                default:
                    return this.LoadPortletView("ICS/BulldogBucksFrARCredit/DefaultView.ascx");
            }
        }
    }
}
