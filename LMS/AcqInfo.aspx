<%@ Page language="c#" Codebehind="AcqInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.AcqInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AcqInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="FAcqInfo" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<!--
					<tr>
						<td style="WIDTH: 922px">
						</td>
						<td class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</td>
					</tr>
					-->
					<TR>
						<TD class="tdheader1" align="center" colSpan="2">Acquire Information</TD>
					</TR>
					<tr>
						<td class="tdNoBorder" align="center" colSpan="2">
						</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="HEIGHT: 7px"><asp:TextBox Runat="server" TextMode="MultiLine" Width="100%" Height="150" ID="txt_acqinfo"></asp:TextBox></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<tr>
						<td align="center" class="TDBGColor2"><asp:Button Runat="server" ID="btn_send" Text="Send" Width="100px" CssClass="button1" onclick="btn_send_Click"></asp:Button>
							<INPUT class="button1" style="WIDTH: 100px" type="button" value="Close" onclick="javascript:window.close()"></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
