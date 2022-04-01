<%@ Page language="c#" Codebehind="backupprRatio.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.backupprRatio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>NPL BPR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../include/cek_all.html" -->
		<!-- #include  file="../../include/bpr_validasi.html" -->
		<!-- #include  file="../../include/onepost.html" -->
		<script language="javascript">
		function uploadInProgress() {
			if (processing) {
				alert("Upload is in progress. Please wait ...");
				return false;
			}
			else
				return true;
		}
		</script>
		<script language="vbscript">
		function FormatCurrency(edit)
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 805px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table6">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
										Ratio</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
						<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
					</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" colSpan="2">Ratio&nbsp;(Rp. 000,-)</TD>
				</TR>
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<TR>
					<td align="center" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TBODY>
								<tr>
									<td class="tdSmallHeader" style="WIDTH: 401px" align="center" width="401" rowSpan="2">URAIAN</td>
									<td class="tdSmallHeader" align="center" width="60%" colSpan="6">Ratio</td>
								</tr>
								<tr>
									<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n</td>
									<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n+1</td>
									<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Pertumbuhan</td>
								</tr>
								<tr>
									<td style="PADDING-RIGHT: 15px; WIDTH: 401px; HEIGHT: 31px" align="right" width="401"><STRONG>Posisi 
											Tanggal</STRONG></td>
									<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_DD_B1" tabIndex="1" runat="server" Width="22px"
												Columns="4" MaxLength="2" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox><asp:dropdownlist id="ddl_MM_B1" tabIndex="2" runat="server" BackColor="#E0E0E0" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_YY_B1" tabIndex="3" runat="server" Columns="4"
												MaxLength="4" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></nobr></td>
									<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_DD_B2" tabIndex="27" runat="server" Width="22px"
												Columns="4" MaxLength="2" BackColor="#E0E0E0" ReadOnly="True" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_MM_B2" tabIndex="28" runat="server" BackColor="#E0E0E0" Enabled="False"
												CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_YY_B2" tabIndex="29" runat="server" Columns="4"
												MaxLength="4" BackColor="#E0E0E0"></asp:textbox></nobr></td>
									<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2">%</td>
								</tr>
								<tr>
									<td style="PADDING-RIGHT: 15px; WIDTH: 401px; HEIGHT: 31px" align="right" width="401"><STRONG>Jumlah 
											Bulan</STRONG></td>
									<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_BULAN1" tabIndex="1" runat="server"
												Width="100px" Columns="4" MaxLength="2" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></nobr></td>
									<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_BULAN2" tabIndex="1" runat="server"
												Width="100px" Columns="4" MaxLength="2" BackColor="#E0E0E0" CssClass="mandatory"></asp:textbox></nobr></td>
									<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"></td>
								</tr>
								<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
								<TR>
									<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>SIZE</STRONG></TD>
								</TR>
								<tr>
									<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. 
										Total Assets (Total Aktiva)</td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TOTAL_ASSETS1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TOTAL_ASSETS2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TOTAL_ASSETS3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								</tr>
								<tr>
									<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. Aktiva Tertimbang Menurut 
										Risiko (ATMR)</td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_RISK_WEIGHTED_ASSETS1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_RISK_WEIGHTED_ASSETS2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_RISK_WEIGHTED_ASSETS3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								</tr>
								<tr>
									<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. 
										Jumlah Aktiva Produktif</td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_AKTIVA_PRODUKTIF1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_AKTIVA_PRODUKTIF2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_AKTIVA_PRODUKTIF3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								</tr>
								<tr>
									<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;4. 
										Jumlah Modal</td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_MODAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_MODAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_MODAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								</tr>
								<tr>
									<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;5. Dana 
										Pihak Ketiga</td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_DANA_PIHAK_KETIGA1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_DANA_PIHAK_KETIGA2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_DANA_PIHAK_KETIGA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								</tr>
								<tr>
									<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;6. 
										Kredit Yang Diberikan</td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KREDIT_YANG_DIBERIKAN1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KREDIT_YANG_DIBERIKAN2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
									<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KREDIT_YANG_DIBERIKAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								</tr>
								<tr>
									<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;7. 
										Penyisihan Penghapusan Aktiva Produktif<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>
										(PPAP)</td>
					</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_PPAP1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_PPAP2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_PPAP3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</TR>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;8. Laba<SPAN style="mso-spacerun: yes">&nbsp;
						</SPAN>
					</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LABA1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LABA2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LABA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>LIQUIDITY</STRONG></TD>
				</TR>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. Loan 
						To Deposit (LDR)</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LDR1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LDR2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LDR3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. Alat 
						Likuid / Hutang Lancar (Cash Ratio)</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_CASH_RATIO1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_CASH_RATIO2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_CASH_RATIO3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>PROFITABILITY</STRONG></TD>
				</TR>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. ROA<SPAN style="mso-spacerun: yes">&nbsp;
						</SPAN>(Laba Sebelum Pajak)</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ROA1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ROA2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ROA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
						Return On Equity (ROE)</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ROE1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ROE2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ROE3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. Laba 
						Operasional / Total Assets</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LABA_OP_TOT_ASSETS1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LABA_OP_TOT_ASSETS2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_LABA_OP_TOT_ASSETS3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr id="HIDE6" runat="server">
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;5. Fee 
						Based Income To Total Income (hide)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_FEE_BASED_INCOME_TO_TOTAL_INCOME1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_FEE_BASED_INCOME_TO_TOTAL_INCOME2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_FEE_BASED_INCOME_TO_TOTAL_INCOME3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>EFFICIENCY</STRONG></TD>
				</TR>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. 
						Biaya Operasional / Pendapatan Operasional<SPAN style="mso-spacerun: yes">&nbsp;</SPAN></td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_BIAYA_OP_PDPTN_OPERASIONAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_BIAYA_OP_PDPTN_OPERASIONAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_BIAYA_OP_PDPTN_OPERASIONAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr id="HIDE1" runat="server">
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. 
						Overhead Cost / Total Assets (hide)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_OVERHEAD_COST_TOT_ASSETS1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_OVERHEAD_COST_TOT_ASSETS2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_OVERHEAD_COST_TOT_ASSETS3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr id="HIDE2" runat="server">
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
						Operating Expenses / Net Revenue (hide)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_OPERATING_EXPENSE_NET_REVENUE1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_OPERATING_EXPENSE_NET_REVENUE2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_OPERATING_EXPENSE_NET_REVENUE3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr id="HIDE3" runat="server">
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. 
						Biaya Dana (Funding Cost) (hide)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_BIAYA_DANA_FUNDING_COST1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_BIAYA_DANA_FUNDING_COST2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_BIAYA_DANA_FUNDING_COST3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>CAPITAL 
							ADEQUACY</STRONG></TD>
				</TR>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. CAR 
						(Modal / Risk Asset Ratio)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_CAR1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_CAR2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_CAR3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
						Total Modal / Total Asset</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_WORTH_TOT_ASSETS1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_WORTH_TOT_ASSETS2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_WORTH_TOT_ASSETS3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>ASSETS 
							QUALITY</STRONG></TD>
				</TR>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. Net 
						Interest Margin (NIM)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_INTEREST_MARGIN1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_INTEREST_MARGIN2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_INTEREST_MARGIN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr id="HIDE4" runat="server">
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
						Provision Charge To Total Loans (hide)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_PROVISION_CHARGE_TO_TOTAL_LOANS1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_PROVISION_CHARGE_TO_TOTAL_LOANS2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_PROVISION_CHARGE_TO_TOTAL_LOANS3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr id="HIDE5" runat="server">
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. Net 
						Interest Income / Quick &amp; Risk Assets (hide)</td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_INTEREST_INCOME_QUICK_RISK_ASSETS1"
							style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)"
							Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_INTEREST_INCOME_QUICK_RISK_ASSETS2"
							style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)"
							Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NET_INTEREST_INCOME_QUICK_RISK_ASSETS3"
							style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)"
							Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">
						&nbsp;2. NPL Bruto</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NPL_TO_TOT_LOAN1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NPL_TO_TOT_LOAN2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_NPL_TO_TOT_LOAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">
						&nbsp;3. Kualitas Aktiva Produktif</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="Textbox1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="Textbox2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="Textbox3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr>
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">
						&nbsp;4. Ratio PPAP</td></TD>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="Textbox4" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="Textbox5" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
					<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="Textbox6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
							runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
				</tr>
				<tr class="TDBGColor">
					<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"></td>
					<td align="center" width="20%" colSpan="2"></td>
					<td align="center" width="20%" colSpan="2"></td>
					<td align="center" width="20%" colSpan="2"></td>
				</tr>
				<!--------------------------------------------------------------------></TABLE></TD></TR></TBODY></TABLE></TD></TR>
			<table style="WIDTH: 100%">
				<tr>
					<td class="tdBGColor2" style="WIDTH: 100%" align="center"><asp:label id="LBL_H_TAHUN" runat="server" Visible="False"></asp:label><asp:button id="BtnCalculate" runat="server" CssClass="Button1" Text="Calculate Ratio" onclick="BtnCalculate_Click"></asp:button><asp:label id="LBL_H_SEQ" runat="server" Visible="False"></asp:label>&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
			</table></TD></TR></TABLE></TD></TR></TABLE></TR></TABLE></TR></TABLE> 
			<!--############################################################################### --></form>
	</body>
</HTML>
