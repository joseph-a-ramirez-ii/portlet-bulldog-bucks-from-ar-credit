<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MainView.ascx.cs" Inherits="CUS.ICS.BulldogBucksFrARCredit.MainView" %>


		<table id="table1" style="border: black 0px solid; width:600px; background-color:#eeeeee"
		cellspacing="1" cellpadding="3"> 
			
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
					You have the following amount available on your account that you can use to
		purchase Bulldog Bucks:
				</td>
				<td>
				    <ASP:TEXTBOX id="cramt" ReadOnly="True" runat="server" Width="104px" MaxLength="20" 
                        Height="22px"></ASP:TEXTBOX></td>
				
				</td>
			</tr>
			<tr>
				<td colspan="5">
					Please confirm you want to use the following amount for Bulldog Bucks: (press button to
					purchase)
				</td>
				<td>
				    <ASP:TEXTBOX id="cramtpost" ReadOnly="True" runat="server" Width="104px" MaxLength="20" 
                        Height="22px"></ASP:TEXTBOX>
                        
                        <br />

				
				</td>
			</tr>
			<tr>
				
			    <th style="BORDER-BOTTOM: gray 1px solid" align="center" colspan="6">
				
					<br />
					<ASP:BUTTON OnClick="btnPurchase_Click" id="btnPurchase" runat="server" text="Purchase BD Bucks">
					
					</ASP:BUTTON><br />
					<asp:Button ID="btnPurchaseDisabled" Enabled="false" runat="server" Text="Save Entry" Style="visibility: hidden;" />
					</asp:Button><br />
                       
					
				</th>
				
			</tr>
		</table>
