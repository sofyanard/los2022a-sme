<%@ Page language="c#" Codebehind="ScoringRatio.aspx.cs" AutoEventWireup="True" Inherits="TestSME.CreditAnalysis.Scoring_Ratio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>RATIO_KMK_KI_SMALL</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TBODY>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Ratio&nbsp;(Rp.000,-)</TD>
					</TR>
					<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
					<TR>
						<td align="center" colSpan="2" class="td">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TBODY>
									<tr>
										<td class="tdSmallHeader" align="center" width="34%" rowSpan="2">
											Ratio</td>
										<td class="tdSmallHeader" align="center" width="66%" colSpan="10">-</td>
									</tr>
									<tr>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun ke n-1/bln</td>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun ke n/bln</td>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun Proyeksi/bln</td>
									</tr>
									<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br1">
										<td style="PADDING-RIGHT: 15px" align="right" width="34%" class="tdBGColor1">Posisi 
											Tanggal</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue">
											<asp:textbox id="TXT_TGL_B1" runat="server" Columns="4" MaxLength="2" TabIndex="1"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_B1" runat="server" TabIndex="2"></asp:dropdownlist>
											<asp:textbox id="TXT_YEAR_B1" runat="server" Columns="4" MaxLength="4" TabIndex="3"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue">
											<asp:textbox id="TXT_TGL_C1" runat="server" Columns="4" MaxLength="2" TabIndex="17"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_C1" runat="server" TabIndex="18"></asp:dropdownlist>
											<asp:textbox id="TXT_YEAR_C1" runat="server" Columns="4" MaxLength="4" TabIndex="19"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue">
											<asp:textbox id="TXT_TGL_D1" runat="server" Columns="4" MaxLength="2" TabIndex="33"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_D1" runat="server" TabIndex="34"></asp:dropdownlist>
											<asp:textbox id="TXT_YEAR_D1" runat="server" Columns="4" MaxLength="4" TabIndex="35"></asp:textbox></td>
									</tr>
									<TR>
										<td style="PADDING-RIGHT: 15px" align="right" width="34%" class="tdBGColor1">Jumlah 
											Bulan</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B2" style="TEXT-ALIGN: right" runat="server" Width="100%" TabIndex="4"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C2" style="TEXT-ALIGN: right" runat="server" Width="100%" TabIndex="20"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D2" style="TEXT-ALIGN: right" runat="server" Width="100%" TabIndex="36"></asp:textbox></td>
									</TR>
									<!--  START baris 2 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br3">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Current 
											Ratio (%)</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="7"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="21"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="37"></asp:textbox></td>
									</tr>
									<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br4">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Debt 
											Equity Ratio (%)</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B4" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="8"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C4" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="22"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D4" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="38"></asp:textbox></td>
									</tr>
									<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br5">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Return 
											on Equity (%)</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B5" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="9"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C5" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="23"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D5" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="39"></asp:textbox></td>
									</tr>
									<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br6">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Net 
											Profit Margin (%)</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="10"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="24"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="40"></asp:textbox></td>
									</tr>
									<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br7">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Net 
											Worth</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="11"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="25"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="41"></asp:textbox></td>
									</tr>
									<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br9">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Cash 
											Velocity</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="12"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="26"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="42"></asp:textbox></td>
									</tr>
									<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br10">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Days 
											Receivable</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="13"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="27"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="43"></asp:textbox></td>
									</tr>
									<!--  START baris 11 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br11">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Days 
											Inventory</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="14"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="28"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="44"></asp:textbox></td>
									</tr>
									<!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br13">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Days 
											Account Payable</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="15"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="29"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="45"></asp:textbox></td>
									</tr>
									<!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br14">
										<td style="PADDING-RIGHT: 15px" align="left" width="34%" class="tdBGColor1">Trade 
											Cycle</td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_B12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="16"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_C12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="30"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td align="center" width="21%" colSpan="2" class="tdBGColorValue"><asp:textbox id="TXT_D12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
												TabIndex="46"></asp:textbox></td>
									</tr>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Net 
											Working Capital</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_B13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_C13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_D13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Return 
											On Investment</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_B14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_C14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_D14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px; HEIGHT: 22px" align="left" width="34%">Net 
											Profit Growth</TD>
										<TD width="1%" style="HEIGHT: 22px"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2" style="HEIGHT: 22px">
											<asp:textbox id="TXT_B15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="19" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%" style="HEIGHT: 22px"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2" style="HEIGHT: 22px">
											<asp:textbox id="TXT_C15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%" style="HEIGHT: 22px"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2" style="HEIGHT: 22px">
											<asp:textbox id="TXT_D15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Total 
											Asset Turn Over</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_B16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_C16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_D16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Sales 
											To Working Capital</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_B17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_C17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_D17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Debt To 
											Networth</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_B18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_C18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_D18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Business 
											Debt Service Ratio</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_B19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_C19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="TXT_D19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<!--
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Debt 
											Service ratio</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="Textbox6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="Textbox12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="Textbox18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" align="left" width="34%">Colateral 
											Coverage</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="Textbox7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="Textbox13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox id="Textbox19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server"
												Width="100%"></asp:textbox></TD>
									</TR>
									-->
								</TBODY>
							</TABLE>
							<!-- END SEPARATOR UTK ISI NERACA  ----------------------------------------------------->
						</td>
					</TR>
					<!-- start remark tgl 4/11/04, 
					<TR>
						<TD align="center" colSpan="2"><asp:Button id="BTN_SIMPAN" runat="server" Width="120px" CssClass="BUTTON1" Text="Save"></asp:Button></TD>
					</TR>
					-->
					<!-- end remark tgl 4/11/04, 
					<TR>
						<td colspan="2">
							<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td align="center" style="HEIGHT: 245px">
										<iframe id="if2" width="100%" height="510" name="if2" src="CFUploadFile.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&ca=<%=Request.QueryString["ca"]%>"></iframe> 
										<iframe id="if2" width="100%" height="250" name="if2" src="CFUploadFile.aspx?regno=<%=Request.QueryString["regno"]%>" style="WIDTH: 100%; HEIGHT: 240px"></IFRAME>
									</td>
								</tr>
							</table>
						</td>
					</TR>
					-->
				</TBODY>
			</TABLE>
			<TABLE>
				<TR>
					<TD><asp:textbox id="TXT_B1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox>
						<asp:textbox id="TXT_C1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox>
						<asp:textbox id="TXT_D1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
