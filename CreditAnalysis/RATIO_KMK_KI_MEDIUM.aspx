<%@ Page language="c#" Codebehind="RATIO_KMK_KI_MEDIUM.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.RATIO_KMK_KI_MEDIUM" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RATIO_KMK_KI_MEDIUM</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../include/ca_validasi.html" -->
		<!-- #include file = "../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TBODY>
					<%if (Request.QueryString["sta"] != "view") {%>
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
											Ratio</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="MainCreditAnalysis.aspx?"></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
					</TR>
					<% } %>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Ratio</TD>
					</TR>
					<!-- separator ------------------------------------------------------------------------------------------------------------------------------------------>
					<TR>
						<td class="td" align="center" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="tdSmallHeader" style="WIDTH: 278px" align="center" width="24%" rowSpan="2">Ratio</td>
									<td class="tdSmallHeader" align="center" width="76%" colSpan="12">Tahun Laporan 
										Keuangan</td>
								</tr>
								<tr>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-2/bln</td>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun 
										ke&nbsp;n-1/bln</td>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n/bln</td>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun Proyeksi/bln</td>
								</tr>
								<!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<TR>
									<TD class="tdBGColor1" style="PADDING-LEFT: 10px" align="left" width="24%">Date 
										Periode</TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" vAlign="top" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_TGL_B2" tabIndex="1" runat="server" Columns="4" MaxLength="2" Width="25px"></asp:textbox><asp:dropdownlist id="DDL_BLN_B2" tabIndex="2" runat="server"></asp:dropdownlist><asp:textbox id="TXT_YEAR_B2" tabIndex="3" runat="server" Columns="4" MaxLength="4"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" vAlign="top" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_TGL_C2" tabIndex="22" runat="server" Columns="4" MaxLength="2" Width="25px"></asp:textbox><asp:dropdownlist id="DDL_BLN_C2" tabIndex="23" runat="server"></asp:dropdownlist><asp:textbox id="TXT_YEAR_C2" tabIndex="24" runat="server" Columns="4" MaxLength="4"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" vAlign="top" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_TGL_D2" tabIndex="43" runat="server" Columns="4" MaxLength="2" Width="25px"></asp:textbox><asp:dropdownlist id="DDL_BLN_D2" tabIndex="44" runat="server"></asp:dropdownlist><asp:textbox id="TXT_YEAR_D2" tabIndex="45" runat="server" Columns="4" MaxLength="4"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" vAlign="top" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_TGL_E2" tabIndex="64" runat="server" Columns="4" MaxLength="2" Width="25px"></asp:textbox><asp:dropdownlist id="DDL_BLN_E2" tabIndex="65" runat="server"></asp:dropdownlist><asp:textbox id="TXT_YEAR_E2" tabIndex="66" runat="server" Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="tdBGColor1" align="left" width="24%">Number Of Number</TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B3" style="TEXT-ALIGN: center" tabIndex="4" runat="server" Width="50%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C3" style="TEXT-ALIGN: center" tabIndex="25" runat="server" Width="50%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D3" style="TEXT-ALIGN: center" tabIndex="46" runat="server" Width="50%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E3" style="TEXT-ALIGN: center" tabIndex="67" runat="server" Width="50%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="tdBGColor1" width="24%">Report Type</TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" style="HEIGHT: 11px" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_B4" tabIndex="5" runat="server">
											<asp:ListItem Value="-">-Pilih-</asp:ListItem>
											<asp:ListItem Value="Audited">Audited</asp:ListItem>
											<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											<asp:ListItem Value="Proyeksi">Proyeksi</asp:ListItem>
										</asp:dropdownlist></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" style="HEIGHT: 11px" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_C4" tabIndex="26" runat="server">
											<asp:ListItem Value="-">-Pilih-</asp:ListItem>
											<asp:ListItem Value="Audited">Audited</asp:ListItem>
											<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											<asp:ListItem Value="Proyeksi">Proyeksi</asp:ListItem>
										</asp:dropdownlist></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" style="HEIGHT: 11px" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_D4" tabIndex="47" runat="server">
											<asp:ListItem Value="-">-Pilih-</asp:ListItem>
											<asp:ListItem Value="Audited">Audited</asp:ListItem>
											<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											<asp:ListItem Value="Proyeksi">Proyeksi</asp:ListItem>
										</asp:dropdownlist></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" style="HEIGHT: 11px" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_E4" tabIndex="68" runat="server">
											<asp:ListItem Value="-">-Pilih-</asp:ListItem>
											<asp:ListItem Value="Audited">Audited</asp:ListItem>
											<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											<asp:ListItem Value="Proyeksi">Proyeksi</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="tdBGColor1" style="PADDING-LEFT: 10px" align="left" width="24%">Sales On 
										Credit %</TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B5" style="TEXT-ALIGN: center" tabIndex="6" runat="server" Width="50%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C5" style="TEXT-ALIGN: center" tabIndex="27" runat="server" Width="50%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D5" style="TEXT-ALIGN: center" tabIndex="48" runat="server" Width="50%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E5" style="TEXT-ALIGN: center" tabIndex="69" runat="server" Width="50%"></asp:textbox></TD>
								</TR>
								<tr>
									<td class="tdBGColor1" width="24%">LIQUIDITY</td>
									<td colSpan="8"></td>
								</tr>
								<!--  START BARIS 01 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR1">
									<td class="tdBGColor1" width="24%">Current Ratio</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="75" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 02 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR2">
									<td class="tdBGColor1" width="24%">Quick Asset Ratio</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="13" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="55" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="76" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 03 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR3">
									<td class="tdBGColor1" width="24%">Net Working Capital</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="75" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr>
									<td class="tdBGColor1" width="24%">PROFITABILITY</td>
									<td colSpan="8"></td>
								</tr>
								<!--  START BARIS 04 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR4">
									<td class="tdBGColor1" width="24%">Gross Profit Margin</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="75" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 05 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR5">
									<td class="tdBGColor1" width="24%">EBITDA</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="75" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 06 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR6">
									<td class="tdBGColor1" width="24%">Operating Profit Margin</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="75" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 07 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR7">
									<td class="tdBGColor1" width="24%">Net Profit Margin</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="75" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 08 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR8">
									<td class="tdBGColor1" width="24%">ROE</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="29" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="50" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 09 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR9">
									<td class="tdBGColor1" width="24%">Return on Average Equity</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="29" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="50" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR10">
									<td class="tdBGColor1" width="24%">ROA</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="9" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="30" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="51" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="72" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 11 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR11">
									<td class="tdBGColor1" width="24%">Return on Average Assets</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="29" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="50" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr>
									<td class="tdBGColor1" width="24%">SOLVENCY</td>
									<td colSpan="8"></td>
								</tr>
								<!--  START BARIS 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR12">
									<td class="tdBGColor1" width="24%">Total Equity</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="29" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="50" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR13">
									<td class="tdBGColor1" width="24%">Debt to Equity Ratio</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR14">
									<td class="tdBGColor1" width="24%">Leverage</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 15 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR15">
									<td class="tdBGColor1" width="24%">Long Term Debt to Equity (LTD)</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 16 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR16">
									<td class="tdBGColor1" width="24%">Debt to Assets</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 17 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR17">
									<td class="tdBGColor1" width="24%">Interest Coverage Ratio</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 18 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR18">
									<td class="tdBGColor1" width="24%">Interest to Sales Ratio</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 19 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR19">
									<td class="tdBGColor1" width="24%">EBITDA to Interest Expense</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 20 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR20">
									<td class="tdBGColor1" width="24%">EBITDA to Debt</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR21">
									<td class="tdBGColor1" width="24%">EBITDA to Liabilities</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR22">
									<td class="tdBGColor1" width="24%">Debt to EBITDA</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR23">
									<td class="tdBGColor1" width="24%">DSC (based on EBITDA)</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B28" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C28" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D28" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E28" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr>
									<td class="tdBGColor1" width="24%">ACTIVITY</td>
									<td colSpan="8"></td>
								</tr>
								<!--  START BARIS 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR24">
									<td class="tdBGColor1" width="24%">Assets Turn Over</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 25 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR25">
									<td class="tdBGColor1" width="24%">Fixed Assets Turn Over</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 26 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR26">
									<td class="tdBGColor1" width="24%">Inventory Turn Over</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 27 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR27">
									<td class="tdBGColor1" width="24%">Receivable Turn Over</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 28 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR28">
									<td class="tdBGColor1" width="24%">Account Payable Turn Over</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 29 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR29">
									<td class="tdBGColor1" width="24%">Days Inventory</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="15" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="36" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="57" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="78" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 30 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR30">
									<td class="tdBGColor1" width="24%">Days Receivable</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="14" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="35" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="56" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="77" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 31 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR31">
									<td class="tdBGColor1" width="24%">Days Payable</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B36" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C36" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="37" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D36" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="58" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E36" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="79" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 32 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR32">
									<td class="tdBGColor1" width="24%">Days TC</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B37" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C37" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D37" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E37" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="80" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr>
									<td class="tdBGColor1" width="24%">GROWTH</td>
									<td colSpan="8"></td>
								</tr>
								<!--  START BARIS 33 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR33">
									<td class="tdBGColor1" width="24%">EBITDA Growth</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B38" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C38" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D38" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E38" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="80" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 34 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR34">
									<td class="tdBGColor1" width="24%">Net Income Growth</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B39" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C39" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D39" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E39" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="80" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 35 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR35">
									<td class="tdBGColor1" width="24%">Sales Growth</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B40" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C40" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D40" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E40" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="80" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr>
									<td class="tdBGColor1" width="24%">OTHERS</td>
									<td colSpan="8"></td>
								</tr>
								<!--  START BARIS 36 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR36">
									<td class="tdBGColor1" width="24%">Debt to Capital</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="80" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 37 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR37">
									<td class="tdBGColor1" width="24%">Operating Margin</td>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B42" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C42" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D42" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%">&nbsp;</TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E42" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="80" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 38 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR38">
									<TD class="tdBGColor1" width="24%">Sales To Working Capital
									</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 39 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR39">
									<TD class="tdBGColor1" width="24%">Business Debt Service Ratio</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 40 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR40">
									<TD class="tdBGColor1" width="24%">Gearing Ratio</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR41">
									<TD class="tdBGColor1" width="24%">Net Revenue/Month</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B46" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C46" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D46" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E46" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR42">
									<TD class="tdBGColor1" width="24%">Account Receivables to Asset</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR43">
									<TD class="tdBGColor1" width="24%">Account Receivables to Liabilities</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR44">
									<TD class="tdBGColor1" width="24%">Equity To Asset</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR45">
									<TD class="tdBGColor1" width="24%">Asset Growth</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B50" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C50" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D50" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E50" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR46">
									<TD class="tdBGColor1" width="24%">Receivables Growth</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B51" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C51" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D51" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E51" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR47">
									<TD class="tdBGColor1" width="24%">Equity Growth</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B52" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C52" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D52" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E52" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR48">
									<TD class="tdBGColor1" width="24%">Eficieny Ratio</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B53" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C53" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D53" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E53" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<!--  START BARIS 41 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<tr id="BR49">
									<TD class="tdBGColor1" width="24%">Total Asset</TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_B54" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_C54" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_D54" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server"
											Width="100%"></asp:textbox></TD>
									<TD width="1%"></TD>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_E54" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
							</table>
						</td>
					</TR>
					<!--
					<TR>
						<td class="tdBGColor2" align="center" colspan="2"><asp:button id="BTN_SIMPANSAJA" runat="server" Width="100px" Text="Save" CssClass="Button1"></asp:button></td>
					</TR>
					-->
					<%if (Request.QueryString["sta"] != "view") { %>
					<tr>
						<td class="td" width="56%">
							<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="tdHeader1" align="center" width="56%" colSpan="3"><B>Investasi</B></td>
								</tr>
								<tr>
									<td class="tdBGColor1" width="34%">NPV</td>
									<td width="1%">&nbsp;:</td>
									<td class="tdBGColorValue" width="21%"><asp:textbox onkeypress="return numbersonly()" id="TXT_NPV" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onblur="FormatCurrency(this)" tabIndex="85" runat="server" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="tdBGColor1" width="34%">IRR</td>
									<td width="1%">&nbsp;:</td>
									<td class="tdBGColorValue" width="21%"><asp:textbox onkeypress="return numbersonly()" id="TXT_IRR" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onblur="FormatCurrency(this)" tabIndex="86" runat="server" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="tdBGColor1" width="34%">PAYBACK</td>
									<td width="1%">&nbsp;:</td>
									<td class="tdBGColorValue" width="21%"><asp:textbox onkeypress="return numbersonly()" id="TXT_PAYBACK" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onblur="FormatCurrency(this)" tabIndex="87" runat="server" Width="100%"></asp:textbox></td>
								</tr>
								<tr>
									<td class="tdNoBorder" width="56%" colSpan="3"></td>
								</tr>
								<tr>
									<td align="center" width="56%" colSpan="3"><asp:button id="BTN_UPDATE" runat="server" Width="128px" CssClass="BUTTON1" Text="Update" onclick="BTN_UPDATE_Click"></asp:button></td>
								</tr>
							</table>
						</td>
						<td width="44%"></td>
					</tr>
					<% } %>
					<tr>
						<td colSpan="2">&nbsp;</td>
					</tr>
					<!-- start rekonsiliasi ----------------------------------->
					<!--
					<TR>
						<TD class="td" align="center" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td class="tdSmallHeader" style="WIDTH: 387px" align="center" width="24%" rowSpan="2">Reconciliations</td>
									<td class="tdSmallHeader" align="center" width="76%" colSpan="12">Tahun Laporan 
										Keuangan</td>
								</tr>
								<tr>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke-n/bln</td>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke-n+1/bln</td>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke-n+2/bln</td>
									<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun Proyeksi/bln</td>
								</tr>
								
								<tr class="TDBGColor" id="br1">
									<td style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="13"><STRONG>Net Worth</STRONG></td>
								</tr>
								
								<tr id="br2">
									<td class="tdBGColor1" width="24%">beginning NW</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br3">
									<td class="tdBGColor1" width="24%">Plus: net income</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br4">
									<td class="tdBGColor1" width="24%">Plus: fresh capital</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br5">
									<td class="tdBGColor1" width="24%">Total increase</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br6">
									<td class="tdBGColor1" width="24%">Less: dividends, other</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br7">
									<td class="tdBGColor1" width="24%">increase/decrease in NW</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br8">
									<td class="tdBGColor1" width="24%">Ending NW</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr class="TDBGColor" id="br9">
									<td style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="13"><STRONG>Fixed 
											Asset</STRONG></td>
								</tr>
								
								<tr id="br10">
									<td class="tdBGColor1" width="24%">Beginning fixed assets</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br11">
									<td class="tdBGColor1" width="24%">Less: depreciation</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br12">
									<td class="tdBGColor1" width="24%">subtotal</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br13">
									<td class="tdBGColor1" width="24%">ending fixed assets</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								
								<tr id="br14">
									<td class="tdBGColor1" width="24%">capital expenditures</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>

								<tr class="TDBGColor" id="br15">
									<td style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="13"><STRONG>Other Non 
											Current Assets</STRONG></td>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">beginning other non curr assets</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">less: amortization 1</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">subtotal</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">ending other non curr assets</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">other non curr ass expenditures</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>

								<tr class="TDBGColor" id="br15">
									<td class="TDBGColor" style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="13"><STRONG>Intangibles</STRONG></td>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">beginning intangibles</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">less: amortization 2</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">subtotal</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">ending intangibles</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
								<tr id="br15">
									<td class="tdBGColor1" width="24%">intangibles expenditures</td>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_B27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_C27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_D27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
									<td width="1%">&nbsp;</td>
									<TD class="tdBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox id="TXT_REKON_E27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
											Width="100%"></asp:textbox></TD>
								</tr>
							</table>
						</TD>
					</TR>
					
					<!-- input type hidden utk textbox ratio middle ----------------------------->
					<TR>
						<TD align="center" colSpan="2">
							<table width="100%">
								<tr>
									<td><asp:textbox id="TXT_B2" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C2" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D2" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_E2" runat="server" Width="100%" Visible="False"></asp:textbox>
										<!-- ************* --><asp:textbox id="TXT_B4" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C4" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D4" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_E4" runat="server" Width="100%" Visible="False"></asp:textbox></td>
								</tr>
							</table>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
