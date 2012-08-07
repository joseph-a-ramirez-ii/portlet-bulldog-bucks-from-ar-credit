<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PurchaseView.ascx.cs" Inherits="CUS.ICS.BulldogBucksFrARCredit.PurchaseView" %>


<table id="table1" style="border: black 0px solid; width:600px; background-color:#eeeeee"
		cellspacing="1" cellpadding="3"> 
			
			<tr>
				<td colspan="6">
					<hr/>
				</td>
			</tr>
			<tr>
				<td colspan="5">
					You have purchased Bulldog Bucks for the following amount.  The Bulldog Bucks will be available for
					your use after the next hour.  Thank you.
				    <br />
                    (Please wait a couple of minutes before you purchase additional BDBucks using 
                    your credit balance)</td>
				<td>
				    <ASP:TEXTBOX id="purchamount" ReadOnly="True" runat="server" Width="104px" MaxLength="20" 
                        Height="22px"></ASP:TEXTBOX>
                        
                        <br />

				
				</td>
			</tr>
			</table>
<asp:TextBox ID="lblError" runat="server" Width="844px"></asp:TextBox>
