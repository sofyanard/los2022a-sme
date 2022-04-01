<%@ Page language="c#" Codebehind="AcqInfo2.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PortfolioWatchlistChecking.AcqInfo2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AcqInfo2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
					<TD class="TDBGColorValue"><asp:textbox id="TXT_MSG" runat="server" MaxLength="8000" Width="100%" BorderStyle="None" TextMode="MultiLine"
							Height="250px"></asp:textbox></TD>
				</TR>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">&nbsp;&nbsp;&nbsp;
						<asp:button id="BTN_SEND" runat="server" Width="75px" CssClass="Button1" Text="SEND" onclick="BTN_SEND_Click"></asp:button>&nbsp;&nbsp;
						<asp:button id="BTN_CLOSE" runat="server" Width="65px" CssClass="Button1" Text="CLOSE" onclick="BTN_CLOSE_Click"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
