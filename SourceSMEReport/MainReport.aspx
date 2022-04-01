<%@ Page language="c#" Codebehind="MainReport.aspx.cs" AutoEventWireup="True" Inherits="SourceSMEReport.MainReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="96%" border="0">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="TDBGColor1" align="right">Reports&nbsp;</TD>
						<td class="TDBGColorValue"><asp:dropdownlist id="DDL_REPORT" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REPORT_SelectedIndexChanged">
								<asp:ListItem Value="-- PILIH --" Selected="True">-- PILIH --</asp:ListItem>
								<asp:ListItem Value="OR">Operational Reporting</asp:ListItem>
								<asp:ListItem Value="SLA">SLA Reporting</asp:ListItem>
								<asp:ListItem Value="PR">Performance Reporting</asp:ListItem>
								<asp:ListItem Value="CR">Characteristic Reports</asp:ListItem>
							</asp:dropdownlist></td>
					<TR>
						<TD class="TDBGColor1">&nbsp;</TD>
						<td class="TDBGColorValue"><asp:radiobuttonlist id="RB_OR" runat="server" Width="648px" Visible="False">
								<asp:ListItem Value="RptBussinesUnit.aspx" Selected="True">Business Unit BI Request Report</asp:ListItem>
								<asp:ListItem Value="RptCOBIRequest.aspx">CO BI Request Report</asp:ListItem>
								<asp:ListItem Value="RptBUApprReq.aspx">Business Unit Appraisal Request Report</asp:ListItem>
								<asp:ListItem Value="RptCoApprReq.aspx">CO Appraisal Request Report</asp:ListItem>
								<asp:ListItem Value="RptCustResponse.aspx">SPPK Response Report</asp:ListItem>
								<asp:ListItem Value="RptBooking.aspx">Booking Report</asp:ListItem>
								<asp:ListItem Value="RptAccPerfomance.aspx">Analyst / Public Accountant Performance Report</asp:ListItem>
							</asp:radiobuttonlist><asp:radiobuttonlist id="RB_SLA" runat="server" Width="456px" Visible="False">
								<asp:ListItem Value="RptSLABussinessUNit.aspx" Selected="True">SLA - Business Unit</asp:ListItem>
								<asp:ListItem Value="none">SLA - CRM Report</asp:ListItem>
								<asp:ListItem Value="none">SLA - CO Booking Process</asp:ListItem>
								<asp:ListItem Value="RPTSLABICKBUCO.aspx">SLA BI Checking From BU to CO</asp:ListItem>
								<asp:ListItem Value="RPTSLABICKCOBU.aspx">SLA Bi Checking From CO to BU</asp:ListItem>
								<asp:ListItem Value="RptCollAppraisal.aspx">SLA Collaterals Appraisal From BU to CO</asp:ListItem>
								<asp:ListItem Value="RptCollApprAgency.aspx">SLA Collateral Appraisal from CO to Agency</asp:ListItem>
							</asp:radiobuttonlist><asp:radiobuttonlist id="RB_PR" runat="server" Width="424px" Visible="False">
								<asp:ListItem Value="RptProdPerform.aspx" Selected="True">Product Performance Report</asp:ListItem>
								<asp:ListItem Value="none">RM Performance Report</asp:ListItem>
							</asp:radiobuttonlist><asp:radiobuttonlist id="RB_CR" runat="server" Width="360px" Visible="False">
								<asp:ListItem Value="none" Selected="True">Data Analysis Report</asp:ListItem>
							</asp:radiobuttonlist></td>
					</TR>
					<TR>
						<TD class="TDBGColor2" colSpan="2" height="90%"><asp:button id="BTN_VIEW" runat="server" Visible="False" Text="VIEW" onclick="BTN_VIEW_Click"></asp:button>&nbsp;</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
