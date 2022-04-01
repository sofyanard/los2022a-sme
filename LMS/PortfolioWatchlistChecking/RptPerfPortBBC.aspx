<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="RptPerfPortBBC.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PortfolioWatchlistChecking.RptPerfPortBBC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPerfPortBBC</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PERFORMANCE PORTFOLIO BBC</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD vAlign="middle" align="center" colSpan="2">
						<TABLE class="td" id="Table1" height="130" cellSpacing="1" cellPadding="1" width="550"
							border="1">
							<TR>
								<TD class="tdHeader1">
									SEARCH CRITERIA</TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1">Periode :</TD>
											<TD></TD>
											<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLFROM_DD" runat="server" MaxLength="2"
													Columns="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_TGLFROM_MM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLFROM_YY" runat="server" MaxLength="4"
													Columns="4" CssClass="mandatory"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" width="170">Region&nbsp;:</TD>
											<TD width="5"></TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEGMENT" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 21px">BBC&nbsp;:</TD>
											<TD style="HEIGHT: 21px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:dropdownlist id="DDL_AREA" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_CANCEL" runat="server" Text="CANCEL" Width="80px" CssClass="button1"></asp:button>&nbsp;<asp:button id="Button3" runat="server" Text="PRINT" Width="80px" CssClass="button1" Visible="False"></asp:button>&nbsp;<asp:button id="BTN_FIND" runat="server" Text="FIND" Width="80px" CssClass="button1"></asp:button></TD>
				</TR>
				<TR align="center">
					<TD vAlign="top" colSpan="2"><cc1:reportviewer id="ReportViewer2" runat="server" Width="100%" Height="510px" Parameters="False"
							Toolbar="Default"></cc1:reportviewer></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
