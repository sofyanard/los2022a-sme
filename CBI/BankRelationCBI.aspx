<%@ Page language="c#" Codebehind="BankRelationCBI.aspx.cs" AutoEventWireup="True" Inherits="SME.CBI.BankRelationCBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Relation With Bank</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_mandatoryColl.html" -->
		<!-- #include file="../include/popup.html" -->
		<script language="javascript">
			function cek_mandatory(frm, alamat)
			{
				max_elm = (frm.elements.length) - 2;
				lanjut = true;
				for (var i=1; i<=max_elm; i++)
				{
					elm = frm.elements[i];
					nm_kolom = "kotak";
					if (elm.className == "mandatory" && elm.value == "" && (elm.type == "text" || elm.type == "select-one"))
					{
						r = elm.parentElement.parentElement;
						d = r.cells(0).innerText;
						alert(d + " tidak boleh kosong...");
						lanjut = false;
						elm.focus();
						return false;
					}
				}
				return true;
			}
			
			function digitsonly2()
			{
				if ( (event.keyCode>47&&event.keyCode<58 ) || (event.keyCode == 44 ) || (event.keyCode == 45 ) )
				{
					return true;
				} else
				{
					return false;
				}
			}

			
		</script>
		<script language="vbscript">
		''---- Menghitung UnCommitted '''''''
		function HitungCashLoan1()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CG_CASHLOAN.value) then
				CASHLOAN = cdbl(obj.TXT_CG_CASHLOAN.value)
			else
				CASHLOAN = 0
			end if
			
			if isnumeric(obj.TXT_CG_COMMITTED.value) then
				COMMITTED = cdbl(obj.TXT_CG_COMMITTED.value)
			else
				COMMITTED = 0
			end if	
			
			obj.TXT_CG_UNCOMMITTED.value = CASHLOAN - COMMITTED
			obj.TXT_CG_UNCOMMITTED.value = replace(obj.TXT_CG_UNCOMMITTED.value, ".", ",")
		end function			

		''---- Menghitung Committed
		function HitungCashLoan2()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CG_CASHLOAN.value) then
				CASHLOAN = cdbl(obj.TXT_CG_CASHLOAN.value)
			else
				CASHLOAN = 0
			end if
			
			if isnumeric(obj.TXT_CG_UNCOMMITTED.value) then
				UNCOMMITTED = cdbl(obj.TXT_CG_UNCOMMITTED.value)
			else
				UNCOMMITTED = 0
			end if	
			
			obj.TXT_CG_COMMITTED.value = CASHLOAN - UNCOMMITTED
			obj.TXT_CG_COMMITTED.value = replace(obj.TXT_CG_COMMITTED.value, ".", ",")
		end function			


		function HitungLimit()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CG_CASHLOAN.value) then
				CASHLOAN = cdbl(obj.TXT_CG_CASHLOAN.value)
			else
				CASHLOAN = 0
			end if
			
			if isnumeric(obj.TXT_CG_NONCASHLOAN.value) then
				NONCASHLOAN = cdbl(obj.TXT_CG_NONCASHLOAN.value)
			else
				NONCASHLOAN = 0
			end if
			
			if isnumeric(obj.TXT_CG_OTHERS.value) then
				OTHERS = cdbl(obj.TXT_CG_OTHERS.value)
			else
				OTHERS = 0
			end if
			
			obj.TXT_CG_TOTAL.value = CASHLOAN + NONCASHLOAN + OTHERS	
			obj.TXT_CG_TOTAL.value = replace(obj.TXT_CG_TOTAL.value, ".", ",")
		end function			
		function FormatCurrency2(edit)
			SetLocale("in")
			value = edit.value
			v_a = "1.000,00"    '-- in Rupiah Currency
			if isnumeric(v_a) and v_a = 1000 then	
				value = replace(value, ".", "")
				value = replace(value, ",", ".")
				if isnumeric(value) then
					edit.value =(formatnumber(eval(value),2))
				else	edit.value = ""
				end if
				edit.style.textAlign = "right"
			end if
		end function
		function RestoreCurrency(edit)
			value = edit.value
			value = replace(value, ".", "")
			value = replace(value, ",", ".")
			if isnumeric(value) then
				edit.value = eval(value)
				edit.select
			else	edit.value = ""
			end if
			edit.style.textAlign = "left"
		end function
		function EnsureNumber(edit)
			value = edit.value
			value = replace(value, ".", "")
			value = replace(value, ",", ".")
			if not isnumeric(value) then
				edit.value = ""
			end if
		end function
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 325px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table5" width="400">
								<TR>
									<TD class="tdBGColor2" align="center"><B>Detail Data Entry : Hubungan dengan Bank</B></TD>
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
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMSAVING_DAY" runat="server" Columns="4"
											Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CI_BMSAVING_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMSAVING_YEAR" runat="server" Columns="4"
											Width="36px" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px; HEIGHT: 22px">Debitur Sejak</TD>
									<TD style="HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMDEBITUR_DAY" runat="server" Columns="4"
											Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CI_BMDEBITUR_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMDEBITUR_YEAR" runat="server" Columns="4"
											Width="36px" MaxLength="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 22px" width="164">Giro Sejak</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMGIRO_DAY" runat="server" Columns="4"
											Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CI_BMGIRO_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMGIRO_YEAR" runat="server" Columns="4"
											Width="36px" MaxLength="4"></asp:textbox></TD>
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
										<asp:hyperlink id="HPL_SALDORATA" runat="server" Font-Bold="True">Saldo Rata-Rata</asp:hyperlink>
										<!--&nbsp;&nbsp;&nbsp;
										<asp:hyperlink id="HPL_ATASNAMA2" runat="server" Font-Bold="True">Atas Nama Nasabah Dan Group</asp:hyperlink>--></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="3"><asp:label id="LBL_ATASNAMA" runat="server" Width="330px" Font-Bold="True"></asp:label><asp:label id="LBL_CM_ATASNAMA" runat="server" Visible="False"></asp:label></TD>
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
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CG_CASHLOAN" onblur="HitungLimit(), HitungCashLoan1(), FormatCurrency2(this), FormatCurrency2(document.Form1.TXT_CG_TOTAL), FormatCurrency2(document.Form1.TXT_CG_UNCOMMITTED), FormatCurrency2(document.Form1.TXT_CG_COMMITTED)"
																	style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="200px" MaxLength="15" CssClass="mandatory"
																	onchange="EnsureNumber(this)"></asp:textbox></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CG_COMMITTED" onblur="HitungCashLoan1(), FormatCurrency2(this), FormatCurrency2(document.Form1.TXT_CG_UNCOMMITTED), FormatCurrency2(document.Form1.TXT_CG_COMMITTED)"
																	style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="200px" MaxLength="15" onchange="EnsureNumber(this)"></asp:textbox></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CG_UNCOMMITTED" onblur="HitungCashLoan2(),FormatCurrency2(this), FormatCurrency2(document.Form1.TXT_CG_UNCOMMITTED), FormatCurrency2(document.Form1.TXT_CG_COMMITTED)"
																	style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="200px" MaxLength="15" onchange="EnsureNumber(this)"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Non Cash Loan</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CG_NONCASHLOAN" onblur="HitungLimit(), FormatCurrency2(this), FormatCurrency2(document.Form1.TXT_CG_TOTAL)"
																	style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="200px" MaxLength="15" CssClass="mandatory"
																	onchange="EnsureNumber(this)"></asp:textbox></TD>
															<TD class="TDBGColorValue"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Others</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CG_OTHERS" onblur="HitungLimit(),FormatCurrency2(this), FormatCurrency2(document.Form1.TXT_CG_TOTAL)"
																	style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="200px" MaxLength="15" CssClass="mandatory"
																	onchange="EnsureNumber(this)"></asp:textbox></TD>
															<TD class="TDBGColorValue"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Total</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CG_TOTAL" style="TEXT-ALIGN: right" runat="server" Width="200px" MaxLength="20"
																	ReadOnly="True"></asp:textbox></TD>
															<TD class="TDBGColorValue"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVEGRP" runat="server" Width="75px" CssClass="button1" Text="Save"></asp:button></TD>
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
												<td style="HEIGHT: 15px" width="23%"><nobr><asp:dropdownlist id="ddl_MR_M1_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MR_M1_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 15px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M1_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M1_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M1_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M1_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 15px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M1_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px; HEIGHT: 26px" align="center" width="48">2.</td>
												<td style="HEIGHT: 26px" width="23%"><nobr><asp:dropdownlist id="ddl_MR_M2_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MR_M2_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 26px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M2_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M2_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M2_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M2_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M2_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px" align="center" width="48">3.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MR_M3_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MR_M3_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M3_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M3_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M3_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M3_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M3_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">4.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MR_M4_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MR_M4_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M4_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M4_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M4_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M4_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M4_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px; HEIGHT: 17px" align="center" width="48">5.</td>
												<td style="HEIGHT: 17px" width="23%"><nobr><asp:dropdownlist id="ddl_MR_M5_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MR_M5_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 17px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M5_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M5_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M5_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M5_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M5_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">6.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MR_M6_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MR_M6_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M6_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M6_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M6_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M6_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_M6_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
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
												<td style="WIDTH: 156px" width="156"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_LIMITKREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="28%" colSpan="2"><STRONG>%SALDO TERHADAP LIMIT</STRONG></td>
												<td width="15%" colSpan="2"><asp:textbox onkeypress="return digitsonly()" id="txt_MR_PRSNSALDO" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<TR>
												<TD align="center" width="100%" colSpan="7"><STRONG>SALDO SAAT INI:</STRONG>
													<asp:textbox onkeypress="return digitsonly2()" id="txt_MR_M1_SALDO" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="150px" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></TD>
											</TR>
											<tr>
												<td align="center" width="100%" colSpan="7"><asp:textbox onkeypress="return numbersonly()" id="txt_TempDD" Columns="2" Width="32px" MaxLength="2"
														Visible="False" ReadOnly="True" Runat="server" Enabled="False">1</asp:textbox><asp:button class="TDBGColor1" id="btn_Calc" runat="server" Width="100px" CssClass="Button1"
														Text="Hitung Lama" Visible="False" Enabled="False" onclick="btn_Calc_Click"></asp:button>
													<asp:button class="TDBGColor1" id="btn_Hitung" runat="server" Width="100px" CssClass="Button1"
														Text="Hitung" onclick="btn_Hitung_Click"></asp:button></td>
											</tr>
											<tr>
												<td style="HEIGHT: 25px" width="100%" colSpan="7"><STRONG>Catatan:</STRONG></td>
											</tr>
											<tr>
												<td style="HEIGHT: 45px" width="100%" colSpan="7"><asp:textbox onkeypress="return kutip_satu()" id="txt_MR_CATATAN" runat="server" Width="656px"
														TextMode="MultiLine" Height="50px"></asp:textbox></td>
											</tr>
											<TR>
												<TD align="center" width="100%" colSpan="7"><asp:button class="TDBGColor1" id="btn_SaveSaldo" runat="server" Width="220px" CssClass="Button1"
														Text="Save Saldo untuk Bank Mandiri" Height="32px"></asp:button></TD>
											</TR>
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
												<td style="HEIGHT: 22px" width="23%"><nobr><asp:dropdownlist id="ddl_MO_M1_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MO_M1_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 22px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M1_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M1_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M1_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M1_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 22px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M1_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px; HEIGHT: 26px" align="center" width="48">2.</td>
												<td style="HEIGHT: 26px" width="23%"><nobr><asp:dropdownlist id="ddl_MO_M2_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MO_M2_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 26px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M2_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M2_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M2_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M2_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 26px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M2_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px" align="center" width="48">3.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MO_M3_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MO_M3_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M3_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M3_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M3_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M3_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M3_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">4.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MO_M4_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MO_M4_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M4_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M4_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M4_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M4_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M4_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr>
												<td style="WIDTH: 48px; HEIGHT: 17px" align="center" width="48">5.</td>
												<td style="HEIGHT: 17px" width="23%"><nobr><asp:dropdownlist id="ddl_MO_M5_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MO_M5_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px; HEIGHT: 17px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M5_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M5_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M5_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M5_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td style="HEIGHT: 17px" width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M5_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
											</tr>
											<tr class="TblAlternating">
												<td style="WIDTH: 48px" align="center" width="48">6.</td>
												<td width="23%"><nobr><asp:dropdownlist id="ddl_MO_M6_BLN_mm" Width="96px" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_MO_M6_BLN_yy" Columns="4" Width="72px"
															MaxLength="4" Runat="server"></asp:textbox></nobr></td>
												<td style="WIDTH: 160px" width="160"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M6_SLDRATA" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M6_DEBET" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M6_DEBETF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M6_KREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="15%"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_M6_KREDITF" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12"></asp:textbox></td>
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
												<td style="WIDTH: 156px" width="156"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_LIMITKREDIT" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
												<td width="28%" colSpan="2"><STRONG>%SALDO TERHADAP LIMIT</STRONG></td>
												<td width="15%" colSpan="2"><asp:textbox onkeypress="return digitsonly()" id="txt_MO_PRSNSALDO" style="TEXT-ALIGN: right"
														runat="server" Width="100%" MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
											</tr>
											<TR>
												<TD align="center" width="100%" colSpan="7"><STRONG>SALDO SAAT INI:</STRONG>
													<asp:textbox onkeypress="return digitsonly2()" id="txt_MO_M1_SALDO" onblur="FormatCurrency2(this)"
														style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="150px" MaxLength="12"
														onchange="EnsureNumber(this)"></asp:textbox></TD>
											</TR>
											<tr>
												<td style="HEIGHT: 11px" align="center" width="100%" colSpan="7"><asp:button class="TDBGColor1" id="btn_CalcOB" runat="server" Width="100px" CssClass="Button1"
														Text="Hitung"></asp:button></td>
											</tr>
											<tr>
												<td style="HEIGHT: 25px" width="100%" colSpan="7"><STRONG>Catatan:</STRONG></td>
											</tr>
											<tr>
												<td width="100%" colSpan="7"><asp:textbox onkeypress="return kutip_satu()" id="txt_MO_CATATAN" runat="server" Width="656px"
														TextMode="MultiLine" Height="50px"></asp:textbox></td>
											</tr>
											<TR>
												<TD align="center" width="100%" colSpan="7"><asp:button class="TDBGColor1" id="btn_SaveSaldoOB" runat="server" Width="220px" CssClass="Button1"
														Text="Save Saldo untuk Bank Lain" Height="32px"></asp:button></TD>
											</TR>
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
									<TD align="center" colSpan="3"><ASP:DATAGRID id="DatGridMandiriLoan" runat="server" Width="100%" AutoGenerateColumns="False"
											PageSize="1" CellPadding="1">
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
												<asp:BoundColumn DataField="CM_LIMIT" HeaderText="Limit Kredit (Rp.)">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_OUTSTANDING" HeaderText="Baki Debet (Rp.)">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_TGKPOKOK" HeaderText="Tunggakan Pokok (Rp.)">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CM_TGKBUNGA" HeaderText="Tunggakan Bunga (Rp.)">
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
												<asp:TemplateColumn>
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
									<TD><asp:label id="LBL_SUBTOTAL" runat="server" Font-Bold="True">Total Limit Nasabah (Rp.)</asp:label>&nbsp;</TD>
									<td></td>
									<td><asp:textbox id="TXT_SUBTOTAL" runat="server" MaxLength="20" CssClass="angka" ReadOnly="True"
											width="200px"></asp:textbox></td>
								</TR>
								<TR id="br02" runat="server">
									<TD><b>Total Limit Kredit Atas Nama Nasabah dan Group&nbsp; (Rp.) (incl. app. exposure)</b></TD>
									<td></td>
									<td><asp:textbox id="TXT_TOTAL" runat="server" Width="201" MaxLength="20" CssClass="angka" ReadOnly="True"></asp:textbox></td>
								</TR>
								<TR id="br03" runat="server">
									<TD style="HEIGHT: 21px"></TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD style="HEIGHT: 21px"><INPUT class="button1" id="BTN_SCORE" style="WIDTH: 201px; HEIGHT: 20px" onclick="javascript:PopupPage('ScoreRatingData.aspx?curef=<%=Request.QueryString["curef"]%>&amp;de=<%=Request.QueryString["de"]%>','800','227');"
											type="button" value="Rating Data" name="BTN_SCORE">
									</TD>
								</TR>
								<TR id="br04" runat="server">
									<TD style="HEIGHT: 8px" align="center" colSpan="3"></TD>
								</TR>
								<TR id="br05" runat="server">
									<TD align="center" colSpan="3">
										<%if (Request.QueryString["de"]=="1") {%>
										<TABLE id="Table7" cellSpacing="2" cellPadding="2" width="90%">
											<TR>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Jenis Kredit</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CM_CREDITTYPE" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
														</TR>
														<TR id="namaPerusahaan" runat="server">
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Nama 
																Perusahaan</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CM_COMPNAME" runat="server"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Limit Kredit</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_LIMIT" onblur="FormatCurrency2(this)"
																	runat="server" Width="180" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Baki Debet</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_OUTSTANDING" onblur="FormatCurrency2(this)"
																	runat="server" Width="180" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Tunggakan 
																Pokok</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_TGKPOKOK" onblur="FormatCurrency2(this)"
																	runat="server" Width="180" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Posisi 
																Tanggal</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_TGLPOSISI_D" runat="server" Columns="4"
																	Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CM_TGLPOSISI_M" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_TGLPOSISI_Y" runat="server" Columns="4"
																	Width="36px" MaxLength="4"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tunggakan 
																Bunga</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CM_TGKBUNGA" onblur="FormatCurrency2(this)"
																	runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Lama 
																Tunggakan (bln)</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_LAMATGK" runat="server" Width="40px"
																	MaxLength="5" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Masa Berlaku 
																s/d</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_DUEDATE_DAY" runat="server" Columns="4"
																	Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CM_DUEDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_DUEDATE_YEAR" runat="server" Columns="4"
																	Width="36px" MaxLength="4"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Kolektibilitas</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CM_COLLECTABILITY" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">No Rekening</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CM_ACCNO" runat="server" MaxLength="20"
																	CssClass="mandatoryColl" width="180"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2"><asp:button id="BTN_INSERT" runat="server" Width="75px" CssClass="button1" Text="Insert"></asp:button></TD>
											</TR>
										</TABLE>
										<%}%>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<!--<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Saldo Rata-rata dan Mutasi Rekening 
							Selama 6 Bulan Terakhir</TD>
					</TR>-->
					<TR id="br06" runat="server">
						<TD class="tdHeader1" vAlign="top" colSpan="2">Aktivitas Rekening Nasabah 6 Bulan 
							Terakhir</TD>
					</TR>
					<TR id="br07" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<!--<TR>
									<TD width="100%"><ASP:DATAGRID id="DatGridSaldo" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CA_SEQ" HeaderText="CA_SEQ">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CA_DATESALDO" HeaderText="Bulan / Tahun">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CURRENCYDESC" HeaderText="Mata Uang">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CA_AVGSALDO" HeaderText="Saldo Rata-rata">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CA_DEBET" HeaderText="Mutasi Debet">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CA_FREKDEB" HeaderText="Frekuensi Debet">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CA_CREDIT" HeaderText="Mutasi Kredit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CA_FREKCRED" HeaderText="Frekuensi Kredit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 2px" align="center" width="100%"></TD>
								</TR>
								<TR>
									<TD align="center" width="100%">
										<TABLE cellSpacing="0" cellPadding="0" width="90%">
											<TR>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Bulan / Tahun</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CA_DATESALDO_MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CA_DATESALDO_YEAR" runat="server" Width="40px" MaxLength="20"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Mata Uang</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CA_CURRENCY" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Saldo 
																Rata-rata</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CA_AVGSALDO" runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Mutasi Debet</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CA_DEBET" runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Frekuensi 
																Debet</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CA_FREKDEB" runat="server" Width="40px" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Mutasi Kredit</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CA_CREDIT" runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Frekuensi 
																Kredit</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox id="TXT_CA_FREKCRED" runat="server" Width="40px" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142"></TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="2"><asp:button id="BTN_INSERTAVG" runat="server" Text="Insert"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>-->
								<TR>
									<TD class="TDBGColor1" width="142">Status</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobutton id="RDO_CA_ACCOUNTSTATUS0" runat="server" Text="Tidak Aktif" GroupName="RDG_CA_ACCOUNTSTATUS"></asp:radiobutton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:radiobutton id="RDO_CA_ACCOUNTSTATUS1" runat="server" Text="Aktif" GroupName="RDG_CA_ACCOUNTSTATUS"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" vAlign="top" width="142">Catatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CA_NOTE" runat="server" Width="800" MaxLength="20"
											TextMode="MultiLine" Height="100px"></asp:textbox></TD>
								</TR>
								<!--<TR>
									<TD width="100%"><STRONG>Kewajiban lain yang tidak diperhitungkan ke dalam total limit 
											kredit</STRONG></TD>
								</TR>
								<TR>
									<TD width="100%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 166px" align="right" width="166">
																Overdraft</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CA_OVERDRAFT" runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 166px" align="right" width="166">
																Personal Guarante</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CA_PGUARANTEE" runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 166px" align="right" width="166">
																Lain-lain</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CA_KETOTHER" runat="server" MaxLength="20" Width="200px"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 166px" align="right" width="166"></TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:textbox id="TXT_CA_OTHER" runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
												<TD class="td" vAlign="top" width="50%">
													<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 191px" align="right" width="191">Menunggu Hut. 
																Pokok dan Hutang Bunga dalam 3 bln terakhir</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:RadioButton id="RDO_CA_KETHUTANG1" runat="server" Text="Pernah" GroupName="RDG_CA_KETHUTANG"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:RadioButton id="RDO_CA_KETHUTANG0" runat="server" Text="Tidak Pernah" GroupName="RDG_CA_KETHUTANG"></asp:RadioButton></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 191px" align="right" width="191">Overdraft 
																dalam 3 bulan terakhir&nbsp;&nbsp;</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue">
																<asp:RadioButton id="RDO_CA_KETOVERDRAFT1" runat="server" Text="Pernah" GroupName="RDG_CA_KETOVERDRAFT"></asp:RadioButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<asp:RadioButton id="RDO_CA_KETOVERDRAFT0" runat="server" Text="Tidak Pernah" GroupName="RDG_CA_KETOVERDRAFT"></asp:RadioButton></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 191px" align="right" width="191"></TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>--></TABLE>
						</TD>
					</TR>
					<TR id="br08" runat="server">
						<TD class="tdHeader1" vAlign="top" colSpan="2">Fasilitas Nasabah Di Bank Lain</TD>
					</TR>
					<TR id="br09" runat="server">
						<TD vAlign="top" colSpan="2"><ASP:DATAGRID id="DatGridOtherLoan" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
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
									<asp:BoundColumn DataField="CO_DUEDATE" HeaderText="Tgl. Jatuh Tempo"  DataFormatString="{0:dd/MM/yyyy}">
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
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="br10" runat="server">
						<TD style="HEIGHT: 1px" vAlign="top" colSpan="2"></TD>
					</TR>
					<TR id="br11" runat="server">
						<TD vAlign="top" align="center" colSpan="2">
							<%if (Request.QueryString["de"]=="1") {%>
							<TABLE id="Table11" cellSpacing="2" cellPadding="2" width="90%">
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Jenis Kredit</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CO_CREDTYPE" runat="server" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Nama Bank</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CO_BANKNAME" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Limit</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_LIMIT" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Baki Debet</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_BAKIDEBET" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">&nbsp;Posisi 
													Tanggal</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLPOSISI_D" runat="server" Columns="4"
														Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CO_TGLPOSISI_M" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLPOSISI_Y" runat="server" Columns="4"
														Width="36px" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">&nbsp;Debitur 
													Sejak</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLDEBITUR_D" runat="server" Columns="4"
														Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CO_TGLDEBITUR_M" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGLDEBITUR_Y" runat="server" Columns="4"
														Width="36px" MaxLength="4"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tunggakan 
													Pokok</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_TGKPOKOK" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tunggakan 
													Bunga</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CO_TGKBUNGA" onblur="FormatCurrency2(this)"
														runat="server" MaxLength="20" CssClass="angka" width="180"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Tgl. Jatuh 
													Tempo</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATE_DAY" runat="server" Columns="4"
														Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CO_DUEDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATE_YEAR" runat="server" Columns="4"
														Width="36px" MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Kolektibilitas</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CO_COLLECTABILITY" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 142px" align="right" width="142"></TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px" align="right" width="142">Jenis Produk</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_RFJENISPRODUCT" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 142px" align="left" width="142" colSpan="3"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2"><asp:label id="LBL_PAR" runat="server" Visible="False"></asp:label><asp:button id="BtnInsert1" runat="server" Width="75px" CssClass="button1" Text="Insert"></asp:button></TD>
								</TR>
							</TABLE>
							<%}%>
						</TD>
					</TR>
					<!--<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Internal Checking</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><ASP:DATAGRID id="DatGridIC" runat="server" Width="95%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Category">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Confirm Information Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 3px" vAlign="top" align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 3px" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="90%">
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Category</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="Dropdownlist6" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Confirm 
													Information Bank</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="Textbox13" runat="server" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Date</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="Textbox8" runat="server" Columns="4" Width="24px" MaxLength="2"></asp:textbox>
													<asp:dropdownlist id="Dropdownlist5" runat="server"></asp:dropdownlist>
													<asp:textbox id="Textbox7" runat="server" Columns="4" Width="36px" MaxLength="4"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 147px" align="right" width="147">Remark</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="Textbox9" runat="server" Width="192px" MaxLength="20" TextMode="MultiLine" Height="70px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:button id="Button2" runat="server" Text="Insert"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>-->
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<!--##########################################################################################################-->
							<!--AHMAD-->
							<!--##########################################################################################################--></TD>
					</TR>
					<TR id="brtombol" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<%if (Request.QueryString["de"] == "1") {%>
							<asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save"></asp:button>
							<%}%>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
