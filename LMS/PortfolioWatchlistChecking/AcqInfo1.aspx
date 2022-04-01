<%@ Page language="c#" Codebehind="AcqInfo1.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PortfolioWatchlistChecking.AcqInfo1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AcqInfo1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdHeader1" colSpan="2">ACQUIRE INFO</TD>
				</TR>
				<tr>
				<tr>
					<td class="tdNoBorder" align="center" colSpan="2"><asp:label id="lbl_regnum" runat="server" Visible="False"></asp:label><asp:label id="TRACK" runat="server" Visible="False"></asp:label><asp:label id="lbl_prod" runat="server" Visible="False"></asp:label><asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label><asp:label id="lbl_track" runat="server" Visible="False"></asp:label><asp:label id="lbl_userid" runat="server" Visible="False"></asp:label><asp:label id="LBL_APRV" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<TD class="TDBGColorValue"><asp:textbox id="TXT_MSG" runat="server" Height="250px" TextMode="MultiLine" BorderStyle="None"
							Width="100%" MaxLength="8000"></asp:textbox></TD>
				</TR>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">&nbsp;&nbsp;&nbsp;
						<asp:button id="BTN_SEND" runat="server" Width="75px" Text="SEND" CssClass="Button1" onclick="BTN_SEND_Click"></asp:button>&nbsp;&nbsp;
						<asp:button id="BTN_CLOSE" runat="server" Width="65px" Text="CLOSE" CssClass="Button1" onclick="BTN_CLOSE_Click"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
