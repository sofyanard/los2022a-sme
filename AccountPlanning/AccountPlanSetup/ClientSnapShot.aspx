<%@ Page language="c#" Codebehind="ClientSnapShot.aspx.cs" AutoEventWireup="false" Inherits="SME.AccountPlanning.ActionPlanSetup.ClientSnapShot" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ClientSnapShot</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table width="100%" border="0">
					<tr>
						<td align="left" width="50%">
							<table id="Table1">
								<tr>
									<td class="tdBGColor2" style="WIDTH: 400px" align="center"><b>Account Plan Setup</b></td>
								</tr>
							</table>
						</td>
						<td class="tdNoBorder" align="right">
							<a href="ListCustomer.aspx?si="></A>
							<asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg"></asp:imagebutton>
							<a href="../../Body.aspx"><img height="25" src="../../Image/MainMenu.jpg" width="106"></a>
							<a href="../../Logout.aspx" target="_top"><img src="../../Image/Logout.jpg"></a>
						</td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">CLIENT SNAPSHOT</td>
					</tr>
					<tr>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
