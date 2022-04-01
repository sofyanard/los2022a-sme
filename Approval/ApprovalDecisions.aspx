<%@ Page language="c#" Codebehind="ApprovalDecisions.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprovalDecisions" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalDecisions</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fAllDec" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td style="WIDTH: 922px"></td>
					<td class="tdNoBorder" align="right"><asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</tr>
				<tr>
					<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
				</tr>
				<tr>
					<td class="tdHeader1" width="50%" colSpan="2">Credit Info</td>
				</tr>
			</table>
			<asp:Table id="tbl_decision" Width="100%" runat="server"></asp:Table>
			<Table id="table1" cellSpacing="2" cellPadding="2" width="100%" Runat="server">
				<tr>
					<td>
						<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
						<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
					</td>
				</tr>
			</Table>
		</form>
	</body>
</HTML>
