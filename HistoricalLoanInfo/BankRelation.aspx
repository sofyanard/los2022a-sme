<%@ Page language="c#" Codebehind="BankRelation.aspx.cs" AutoEventWireup="True" Inherits="SME.HistoricalLoanInfo.BankRelation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BankRelation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 325px">
							<TABLE id="Table5" width="400">
								<TR>
									<TD class="tdBGColor2" align="center"><B> Hubungan dengan Bank</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Hubungan Dengan Bank 
							Mandiri</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px" align="right" width="165">Tabungan 
										Sejak</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_BMSAVING_DAY" runat="server" MaxLength="2" Width="24px" Columns="4" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_CI_BMSAVING_MONTH" runat="server" BackColor="Gainsboro" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_CI_BMSAVING_YEAR" runat="server" MaxLength="4" Width="36px" Columns="4"
											ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px; HEIGHT: 22px">Debitur Sejak</TD>
									<TD style="HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox id="TXT_CI_BMDEBITUR_DAY" runat="server" MaxLength="2" Width="24px" Columns="4"
											ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_CI_BMDEBITUR_MONTH" runat="server" BackColor="Gainsboro" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_CI_BMDEBITUR_YEAR" runat="server" MaxLength="4" Width="36px" Columns="4"
											ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 22px" width="164">Giro Sejak</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox id="TXT_CI_BMGIRO_DAY" runat="server" MaxLength="2" Width="24px" Columns="4" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_CI_BMGIRO_MONTH" runat="server" BackColor="Gainsboro" Enabled="False"></asp:dropdownlist><asp:textbox id="TXT_CI_BMGIRO_YEAR" runat="server" MaxLength="4" Width="36px" Columns="4" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Fasilitas Di Bank Mandiri</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="HEIGHT: 7px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"><asp:hyperlink id="HPL_ATASNAMA0" runat="server" Font-Bold="True">Atas Nama Nasabah</asp:hyperlink>&nbsp;&nbsp;
										<asp:hyperlink id="HPL_ATASNAMA1" runat="server" Font-Bold="True">Atas Nama Group</asp:hyperlink>&nbsp;&nbsp;
										<asp:hyperlink id="HPL_SALDORATA" runat="server" Font-Bold="True">Saldo Rata-Rata</asp:hyperlink></TD>
								<TR>
									<TD style="HEIGHT: 1px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3"><asp:label id="LBL_ATASNAMA" runat="server" Width="330px" Font-Bold="True"></asp:label><asp:label id="LBL_CM_ATASNAMA" runat="server" Visible="False"></asp:label>
										<asp:placeholder id="PH_SUBMENU" runat="server" Visible="False"></asp:placeholder></TD>
								</TR>
								<TR id="TRGroup" runat="server">
									<TD align="left" colSpan="3">
										<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="1">
											<TR>
												<TD vAlign="top" align="center" width="50%" colSpan="2">
													<TABLE id="TableGroup" cellSpacing="0" cellPadding="0" runat="server">
														<TR>
															<TD style="WIDTH: 128px" align="right" width="128"></TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"></TD>
															<TD>Committed</TD>
															<TD>Uncommitted</TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Cash Loan</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CG_CASHLOAN" style="TEXT-ALIGN: right" runat="server" MaxLength="15" Width="200px"
																	CssClass="mandatory" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CG_COMMITTED" style="TEXT-ALIGN: right" runat="server" MaxLength="15" Width="200px"
																	ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CG_UNCOMMITTED" style="TEXT-ALIGN: right" runat="server" MaxLength="15"
																	Width="200px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Non Cash Loan</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CG_NONCASHLOAN" style="TEXT-ALIGN: right" runat="server" MaxLength="15"
																	Width="200px" CssClass="mandatory" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD class="TDBGColorValue"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Others</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CG_OTHERS" style="TEXT-ALIGN: right" runat="server" MaxLength="15" Width="200px"
																	CssClass="mandatory" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD class="TDBGColorValue"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Total</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CG_TOTAL" runat="server" MaxLength="20" Width="200px" ReadOnly="True" style="TEXT-ALIGN: right"
																	BackColor="Gainsboro"></asp:textbox></TD>
															<TD class="TDBGColorValue"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 26px" align="center" colSpan="3">
										<!--###############################################################################3######################-->
										<table id="TBL_SALDO_RATA" cellSpacing="0" cellPadding="2" width="100%" border="1" runat="server">
											<tr>
												<td class="tdHeader1" width="100%" colSpan="7">SALDO RATA-RATA DAN MUTASI REKENING 
													AKTIVITAS USAHA 6 BULAN TERAKHIR (Rp. 000) UNTUK BANK MANDIRI</td>
											</tr>
											<tr>
												<td class="tdSmallHeader" style="WIDTH: 48px" width="48" rowSpan="2">No.</td>
												<td class="tdSmallHeader" width="23%" rowSpan="2">Bulan</td>
												<td class="tdSmallHeader" style="WIDTH: 156px" width="156" rowSpan="2">Saldo 
													Rata-Rata</td>
												<td class="tdSmallHeader" width="58%" colSpan="4">Mutasi</td>
											</tr>
											<tr>
												<td class="tdSmallHeader" width="14%">Debet</td>
												<td class="tdSmallHeader" width="14%">Frek</td>
												<td class="tdSmallHeader" width="15%">Kredit</td>
												<td class="tdSmallHeader" width="15%">Frek</td>
											</tr>
											<tr>
												<td style="WIDTH: 48px; HEIGHT: 15px" align="center" width="48">1.</td>
												<td style="HEIGHT: 15px" width="23%"><nobr><asp:dropdownlist id="ddl_MR_M1_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MR_M1_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 15px" width="160"><asp:textbox id="txt_MR_M1_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="14%"><asp:textbox id="txt_MR_M1_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="14%"><asp:textbox id="txt_MR_M1_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="15%"><asp:textbox id="txt_MR_M1_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="15%"><asp:textbox id="txt_MR_M1_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px; HEIGHT: 26px" align="center" width="48">2.</td>
												<td style="HEIGHT: 26px" width="23%"><nobr><asp:dropdownlist id="ddl_MR_M2_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MR_M2_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 26px" width="160"><asp:textbox id="txt_MR_M2_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox id="txt_MR_M2_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox id="txt_MR_M2_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox id="txt_MR_M2_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox id="txt_MR_M2_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px" align="center" width="48">3.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MR_M3_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MR_M3_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_MR_M3_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MR_M3_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MR_M3_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MR_M3_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MR_M3_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">4.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MR_M4_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MR_M4_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_MR_M4_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MR_M4_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MR_M4_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MR_M4_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MR_M4_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px; HEIGHT: 17px" align="center" width="48">5.</td>
												<td style="HEIGHT: 17px" width="23%"><nobr><asp:dropdownlist id="ddl_MR_M5_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MR_M5_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 17px" width="160"><asp:textbox id="txt_MR_M5_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox id="txt_MR_M5_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox id="txt_MR_M5_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox id="txt_MR_M5_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox id="txt_MR_M5_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">6.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MR_M6_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MR_M6_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_MR_M6_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MR_M6_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MR_M6_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MR_M6_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MR_M6_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TDBGColor">
												<td width="28%" colSpan="2"><STRONG>JUMLAH</STRONG></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_TotSaldo" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_TotDebet" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_TotDebetF" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_TotKredit" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_TotKreditF" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<tr class="TDBGColor">
												<td width="28%" colSpan="2"><STRONG>RATA-RATA</STRONG></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_RataSaldo" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_RataDebet" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_RataDebetF" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_RataKredit" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_RataKreditF" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<tr>
												<td width="28%" colSpan="2"><STRONG>LIMIT KREDIT</STRONG></td>
												<td style="WIDTH: 156px" width="156"><asp:textbox id="txt_MR_LIMITKREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12"
														Width="100%" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="28%" colSpan="2"><STRONG>%SALDO TERHADAP LIMIT</STRONG></td>
												<td width="15%" colSpan="2"><asp:textbox id="txt_MR_PRSNSALDO" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<TR>
												<TD align="center" width="100%" colSpan="7"><STRONG>SALDO SAAT INI:</STRONG>
													<asp:textbox id="txt_MR_M1_SALDO" style="TEXT-ALIGN: right" runat="server" Width="150px" MaxLength="12"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox>
													<asp:textbox id="txt_TempDD" Columns="2" Width="32px" MaxLength="2" Visible="False" ReadOnly="True"
														Runat="server" Enabled="False" BackColor="Gainsboro">1</asp:textbox></TD>
											</TR>
											<tr>
												<td style="HEIGHT: 25px" width="100%" colSpan="7"><STRONG>Catatan:</STRONG></td>
											</tr>
											<tr>
												<td style="HEIGHT: 45px" width="100%" colSpan="7"><asp:textbox id="txt_MR_CATATAN" runat="server" Width="656px" Height="50px" TextMode="MultiLine"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<TR>
												<TD width="100%" colSpan="7"></TD>
											</TR>
										</table>
										<!--###############################################################################3######################--></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 26px" align="center" colSpan="3">
										<!--###############################################################################3######################-->
										<table id="TBL_SALDO_RATA_OB" cellSpacing="0" cellPadding="2" width="100%" border="1" runat="server">
											<tr>
												<td class="tdHeader1" width="100%" colSpan="7">SALDO RATA-RATA DAN MUTASI REKENING 
													AKTIVITAS 6 BULAN TERAKHIR (Rp. 000) UNTUK BANK LAIN</td>
											</tr>
											<tr>
												<td class="tdSmallHeader" style="WIDTH: 48px" width="48" rowSpan="2">No.</td>
												<td class="tdSmallHeader" width="23%" rowSpan="2">Bulan</td>
												<td class="tdSmallHeader" style="WIDTH: 156px" width="156" rowSpan="2">Saldo 
													Rata-Rata</td>
												<td class="tdSmallHeader" width="58%" colSpan="4">Mutasi</td>
											</tr>
											<tr>
												<td class="tdSmallHeader" width="14%">Debet</td>
												<td class="tdSmallHeader" width="14%">Frek</td>
												<td class="tdSmallHeader" width="15%">Kredit</td>
												<td class="tdSmallHeader" width="15%">Frek</td>
											</tr>
											<tr>
												<td style="WIDTH: 48px; HEIGHT: 22px" align="center" width="48">1.</td>
												<td style="HEIGHT: 22px" width="23%"><nobr><asp:dropdownlist id="ddl_MO_M1_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MO_M1_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 22px" width="160"><asp:textbox id="txt_MO_M1_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="14%"><asp:textbox id="txt_MO_M1_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="14%"><asp:textbox id="txt_MO_M1_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="15%"><asp:textbox id="txt_MO_M1_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="15%"><asp:textbox id="txt_MO_M1_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px; HEIGHT: 26px" align="center" width="48">2.</td>
												<td style="HEIGHT: 26px" width="23%"><nobr><asp:dropdownlist id="ddl_MO_M2_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MO_M2_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 26px" width="160"><asp:textbox id="txt_MO_M2_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox id="txt_MO_M2_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox id="txt_MO_M2_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox id="txt_MO_M2_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox id="txt_MO_M2_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px" align="center" width="48">3.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MO_M3_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MO_M3_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_MO_M3_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MO_M3_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MO_M3_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MO_M3_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MO_M3_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">4.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MO_M4_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MO_M4_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_MO_M4_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MO_M4_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MO_M4_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MO_M4_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MO_M4_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px; HEIGHT: 17px" align="center" width="48">5.</td>
												<td style="HEIGHT: 17px" width="23%"><nobr><asp:dropdownlist id="ddl_MO_M5_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MO_M5_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 17px" width="160"><asp:textbox id="txt_MO_M5_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox id="txt_MO_M5_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox id="txt_MO_M5_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox id="txt_MO_M5_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox id="txt_MO_M5_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">6.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MO_M6_BLN_mm" Width="96px" Runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_MO_M6_BLN_yy" MaxLength="4" Width="72px" Columns="4" Runat="server" BackColor="Gainsboro"
															ReadOnly="True"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_MO_M6_SLDRATA" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MO_M6_DEBET" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_MO_M6_DEBETF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MO_M6_KREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_MO_M6_KREDITF" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<tr class="TDBGColor">
												<td width="28%" colSpan="2"><STRONG>JUMLAH</STRONG></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_TotSaldoOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_TotDebetOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_TotDebetFOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_TotKreditOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_TotKreditFOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<tr class="TDBGColor">
												<td width="28%" colSpan="2"><STRONG>RATA-RATA</STRONG></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox id="txt_RataSaldoOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_RataDebetOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="14%"><asp:textbox id="txt_RataDebetFOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_RataKreditOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
												<td width="15%"><asp:textbox id="txt_RataKreditFOB" style="TEXT-ALIGN: right" runat="server" Width="100%" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<tr>
												<td width="28%" colSpan="2"><STRONG>LIMIT KREDIT</STRONG></td>
												<td style="WIDTH: 156px" width="156"><asp:textbox id="txt_MO_LIMITKREDIT" style="TEXT-ALIGN: right" runat="server" MaxLength="12"
														Width="100%" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
												<td width="28%" colSpan="2"><STRONG>%SALDO TERHADAP LIMIT</STRONG></td>
												<td width="15%" colSpan="2"><asp:textbox id="txt_MO_PRSNSALDO" style="TEXT-ALIGN: right" runat="server" MaxLength="12" Width="100%"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<TR>
												<TD align="center" width="100%" colSpan="7"><STRONG>SALDO SAAT INI:</STRONG>
													<asp:textbox id="txt_MO_M1_SALDO" style="TEXT-ALIGN: right" runat="server" Width="150px" MaxLength="12"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<tr>
												<td style="HEIGHT: 25px" width="100%" colSpan="7"><STRONG>Catatan:</STRONG></td>
											</tr>
											<tr>
												<td width="100%" colSpan="7"><asp:textbox id="txt_MO_CATATAN" runat="server" Width="656px" Height="50px" TextMode="MultiLine"
														BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
											</tr>
											<TR>
												<TD width="100%" colSpan="7"></TD>
											</TR>
										</table>
										<!--#####################################################################################################ganti--></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 2px" align="center" colSpan="3"></TD>
								</TR>
								<TR id="br00" runat="server">
									<TD align="center" colSpan="3"><ASP:DATAGRID id="DatGridMandiriLoan" runat="server" Width="100%" CellPadding="1" PageSize="1"
											AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
												<asp:BoundColumn DataField="CM_COMPNAME" HeaderText="Nama Perusahaan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CM_CREDITTYPE" HeaderText="CM_CREDITTYPE">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_LIMIT" HeaderText="Limit Kredit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_OUTSTANDING" HeaderText="Baki Debet">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_TGKPOKOK" HeaderText="Tunggakan Pokok">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_TGKBUNGA" HeaderText="Tunggakan Bunga">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_LAMATGK" HeaderText="Lama Tunggakan (Bln)">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_DUEDATE" HeaderText="Masa Berlaku s/d" DataFormatString="{0:dd-MMM-yyyy}">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COLLECTDESC" HeaderText="Kolektibilitas">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_TGLPOSISI" HeaderText="Posisi Pada" DataFormatString="{0:dd-MMM-yyyy}">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_ACCNO" HeaderText="No Rekening">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn Visible="False">
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
								<TR id="br01" runat="server">
									<TD><asp:label id="LBL_SUBTOTAL" runat="server" Font-Bold="True">Total Limit Nasabah</asp:label></TD>
									<td></td>
									<td><asp:textbox id="TXT_SUBTOTAL" runat="server" MaxLength="20" CssClass="angka" ReadOnly="True"
											width="200px" BackColor="Gainsboro"></asp:textbox></td>
								</TR>
								<TR id="br02" runat="server">
									<TD><b>Total Limit Kredit Atas Nama Nasabah dan Group</b></TD>
									<td></td>
									<td><asp:textbox id="TXT_TOTAL" runat="server" MaxLength="20" Width="201" CssClass="angka" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox></td>
								</TR>
								<TR id="br03" runat="server">
									<TD style="HEIGHT: 21px"></TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD style="HEIGHT: 21px">
										<!--
										<INPUT class="button1" id="BTN_SCORE" style="WIDTH: 201px; HEIGHT: 20px" type="button" onclick="javascript:PopupPage('ScoreRatingData.aspx?curef=<%=Request.QueryString["curef"]%>&amp;de=<%=Request.QueryString["de"]%>','800','227');" value="Rating Data" name="BTN_SCORE">
										-->
									</TD>
								</TR>
								<TR id="br04" runat="server">
									<TD style="HEIGHT: 8px" align="center" colSpan="3"></TD>
								</TR>
								<TR id="br05" runat="server">
									<TD align="center" colSpan="3">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="br06" runat="server">
						<TD class="tdHeader1" vAlign="top" colSpan="2">Aktivitas Rekening Nasabah 6 Bulan 
							Terakhir</TD>
					</TR>
					<TR id="br07" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="142">Status</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobutton id="RDO_CA_ACCOUNTSTATUS0" runat="server" Text="Tidak Aktif" GroupName="RDG_CA_ACCOUNTSTATUS"
											Enabled="False"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="RDO_CA_ACCOUNTSTATUS1" runat="server" Text="Aktif" GroupName="RDG_CA_ACCOUNTSTATUS"
											Enabled="False"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" vAlign="top" width="142">Catatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CA_NOTE" runat="server" MaxLength="20" Width="800" Height="100px" TextMode="MultiLine"
											BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="br08" runat="server">
						<TD class="tdHeader1" vAlign="top" colSpan="2">Fasilitas Nasabah Di Bank Lain</TD>
					</TR>
					<TR id="br09" runat="server">
						<TD vAlign="top" colSpan="2"><ASP:DATAGRID id="DatGridOtherLoan" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CO_SEQ" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_CREDTYPE" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BANKNAME" HeaderText="Nama Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_LIMIT" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_BAKIDEBET" HeaderText="Baki Debet">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_TGKPOKOK" HeaderText="Tunggakan Pokok">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_TGKBUNGA" HeaderText="Tunggakan Bunga">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_DUEDATE" HeaderText="Tgl. Jatuh Tempo">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COLLECTDESC" HeaderText="Kolektibilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_TGLPOSISI" HeaderText="Posisi Pada">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CO_JENISDESC" HeaderText="Jenis Product">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn Visible="False">
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
			<asp:Label id="LBL_PAR" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 2048px" runat="server"></asp:Label>
		</form>
	</body>
</HTML>
