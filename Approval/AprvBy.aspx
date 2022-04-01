<%@ Page language="c#" Codebehind="AprvBy.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.AprvBy" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AprvBy</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fAprvBy" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="WIDTH: 922px"></td>
						<td class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder>
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="HEIGHT: 7px"><asp:checkboxlist id="cbl_AprvBy" Runat="server"></asp:checkboxlist></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<tr>
						<td align="center"><asp:Button Runat="server" ID="btn_ok" Text="Ok" onclick="btn_ok_Click"></asp:Button>
							<asp:Label id="LBL_GROUPID" runat="server" Visible="False"></asp:Label></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
