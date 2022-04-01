<%@ Page language="c#" Codebehind="RptPortfolioShare.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPortfolioShare" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPortfolioShare</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD style="HEIGHT: 204px" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1">PORTFOLIO SHARE TOP 25 DEBTOR
									</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" style="HEIGHT: 61px">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY> <!-- Additional Field : Right --></TBODY></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="BTN_SAVE" runat="server" Text="Find" Width="60px" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Parameters="False" Height="510px"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
