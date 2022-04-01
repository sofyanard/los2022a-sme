<%@ Page language="c#" Codebehind="PortfolioGuidelineInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.PortfolioGuidelineInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PortfolioGuidelineInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fAppInfo" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="2">Portfolio Guideline</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 17px">Outstanding Limit</TD>
									<TD style="WIDTH: 12px; HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_OUTSTANDING" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox><asp:textbox id="TXT_RATIO_LIMIT" runat="server" Width="40px" BorderStyle="None" Height="24px"></asp:textbox><asp:label id="txt_CU_REF" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 26px">Pending Limit</TD>
									<TD style="WIDTH: 12px; HEIGHT: 26px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:textbox id="TXT_PENDING" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 23px">Available Limit</TD>
									<TD style="WIDTH: 12px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox id="TXT_AVAILABLE" runat="server" Width="200px" BorderStyle="None" Height="17px"></asp:textbox><asp:textbox id="TXT_RATIO_AVAIL" runat="server" Width="40px" BorderStyle="None" Height="24px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 24px">Industry Class</TD>
									<TD style="WIDTH: 12px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox id="TXT_INDUSTRYCLASS" runat="server" Width="200px" BorderStyle="None" Height="22px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 24px">Portfolio Status</TD>
									<TD style="WIDTH: 12px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox id="TXT_STATUS" runat="server" Width="200px" BorderStyle="None" Height="22px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label><asp:label id="lbl_industry" runat="server" Visible="False"></asp:label><asp:label id="lbl_ksebi4" runat="server" Visible="False"></asp:label><asp:label id="LBL_STA" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
