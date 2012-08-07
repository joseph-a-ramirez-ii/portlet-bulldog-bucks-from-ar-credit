<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultView.ascx.cs" Inherits="CUS.ICS.BulldogBucksFrARCredit.DefaultView" %>
<%@ Register TagPrefix="common" Assembly="Jenzabar.Common" Namespace="Jenzabar.Common.Web.UI.Controls" %>
<script language="javascript" type="text/javascript">
// <!CDATA[

function obsessive_onclick() {

}

function ValidateMaxNumber() {
  //  if (val > cr) {
   //   var valout = val * 1;
    var valout = document.getElementById("pg1_V_cramtin").value;
        alert(valout);
  //  }
}
// ]]>
</script>




<style type="text/css">
    .style1
    {
        width: 139px;
        
    }
    .left
    {
    	text-align: left;
    }
    .right
    {
    	text-align: right;
    }
    
    #pg0_V_mentaldesc
    {
        height: 25px;
        width: 644px;
    }
    
    </style>

<div class="pSection">
	<div class="pContent">
	


		<table id="table1" style="border: black 0px solid; width:600px; background-color:#eeeeee"
		cellspacing="1" cellpadding="3"> 
			<tr>
				<th colspan="3">
					<p class="left">TLU ID&nbsp;&nbsp;
						<asp:TextBox id="tluid" runat="server"></asp:TextBox></p>
						
				</th>
				<td colspan="3">
				  <asp:ValidationSummary id="ValidationSummary1" runat="server"
                        HeaderText="<b>Errors were found and are identified in red<br /> on the form (scroll down to correct).</b>"
                        ShowSummary="True"
                        DisplayMode="List" /><br />
				<asp:label id="lblComplete" Runat="server" ForeColor="Red" BackColor="Yellow" />
				</td>
			</tr>
			<tr>
				<th class="style1">
					Last Name</th>
				<td>
					<ASP:TEXTBOX id="lname" ReadOnly="true" runat="server" Width="100"></ASP:TEXTBOX>
				
				</td>
				<th>
					First Name</th>
				<td>
					<ASP:TEXTBOX id="fname" ReadOnly="True" runat="server" Width="100"></ASP:TEXTBOX></td>
				<th>
					Middle Name</th>
				<td>
					<ASP:TEXTBOX id="mname" ReadOnly="True" runat="server" Width="104px"></ASP:TEXTBOX></td>
			</tr>
			
			<tr>
				<td colspan="6">
					<hr/>
				</td>
			</tr>
			<tr>
				<td colspan="6">
					<hr/>
				</td>
			</tr>
			<tr>
				<td colspan="5">
					This service is unavailable online if you are enrolled for fewer than 12 hours.  You are enrolled for hours:
					<br />(Please contact the Business Office, 830-372-8010, with any questions).
					
				</td>
				<td>
				    <ASP:TEXTBOX id="hrsenrolled" ReadOnly="True" runat="server" Width="104px" MaxLength="20" 
                        Height="22px"></ASP:TEXTBOX>
				
			    </td>
			</tr>
			<tr>
				<td colspan="5">
					You have the following amount available on your account that you can use to
		purchase Bulldog Bucks: 
				</td>
				<td>
				    <ASP:TEXTBOX id="cramount" ReadOnly="True" runat="server" Width="104px" MaxLength="20" 
                        Height="22px"></ASP:TEXTBOX>
				
			</td>
			</tr>
			<tr>
				<td colspan="5">
					How much do you want to use for Bulldog Bucks (cannot exceed amount shown 
    above)?
				</td>
				<td>
				    <ASP:TEXTBOX id="cramtin" runat="server" Width="104px" MaxLength="20" 
                        Height="22px" Text="0.0"></ASP:TEXTBOX>
                        
                        <br />

				
				</td>
			</tr>
			<tr>
				
			    <th style="BORDER-BOTTOM: gray 1px solid" align="center" colspan="6">
				<asp:label id="lblError" Runat="server" ForeColor="Red" BackColor="Yellow" />
					<br />
					<ASP:BUTTON OnClick="btnSubmit_Click" id="btnSubmit" runat="server" text="Submit" />
					
				<br />
					<asp:ValidationSummary id="valSummary" runat="server"
                        HeaderText="<b>The following errors were found:</b>"
                        ShowSummary="true"
                        DisplayMode="List" />
                        
					
				</th>
				
			</tr>
		</table>
		
	    <asp:CompareValidator id="Compare1" runat="server"
	        ForeColor="Red"
           ControlToValidate="cramtin" 
           ControlToCompare="cramount"
           EnableClientScript="False" 
           Type="Double" 
           Operator="LessThanEqual"
           ErrorMessage="Purchase amount must be equal to or less than available amt" />
        
         
         
         
      <br />

 

	    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
	    
	</div>

</div>
<p>
    &nbsp;</p>
