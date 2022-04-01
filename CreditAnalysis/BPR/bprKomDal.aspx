<%@ Page language="c#" Codebehind="bprKomDal.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.bprKomDal" %>
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
										Komposisi Modal</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
						<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
					</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2" style="HEIGHT: 41px"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2" style="HEIGHT: 41px"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" colSpan="2">Komposisi Modal (Rp. 000,-)</TD>
				</TR>
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<TR>
					<td align="center" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="1">
							<tr>
								<td class="tdSmallHeader" style="WIDTH: 401px" align="center" width="401" rowSpan="2">URAIAN</td>
								<td class="tdSmallHeader" align="center" width="60%" colSpan="6">Komposisi Modal</td>
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
											Columns="4" MaxLength="2" CssClass="mandatory" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox><asp:dropdownlist id="ddl_MM_B2" tabIndex="28" runat="server" CssClass="mandatory" BackColor="#E0E0E0"
											Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_YY_B2" tabIndex="29" runat="server" Columns="4"
											MaxLength="4" BackColor="#E0E0E0"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2">%</td>
							</tr>
							<tr>
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px; HEIGHT: 31px" align="right" width="401"><STRONG>Jumlah 
										Bulan</STRONG></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_BULAN1" tabIndex="1" runat="server"
											Width="100px" Columns="4" MaxLength="2" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="TXT_JUMLAH_BULAN2" tabIndex="1" runat="server"
											Width="100px" Columns="4" MaxLength="2" CssClass="mandatory" BackColor="#E0E0E0"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"></td>
							</tr>
							<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401"><STRONG>TOTAL 
										EQUITY</STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_TOTAL_EQUITY1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_TOTAL_EQUITY2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_TOTAL_EQUITY3"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401"><STRONG>MODAL 
										INTI (Tier 1 Capital)</STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_MODAL_INTI1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_MODAL_INTI2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_MODAL_INTI3"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--  START baris 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>MODAL 
										PELENGKAP (Tier 2 Capital)</STRONG></TD>
							</TR>
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;1. 
									Pinjaman Subordinasi</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_SUBORDINASI1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    tabIndex="15" runat="server" Width="100%" MaxLength="12" CssClass="mandatory"
										onchange="EnsureNumber(this)" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_SUBORDINASI2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    tabIndex="41" runat="server" Width="100%" MaxLength="12" CssClass="mandatory"
										onchange="EnsureNumber(this)" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_SUBORDINASI3" 
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;2. 
									0.125% Risk Assets</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_RISK_ASSETS1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    tabIndex="15" runat="server" Width="100%" MaxLength="12" CssClass="mandatory"
										onchange="EnsureNumber(this)" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_RISK_ASSETS2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    tabIndex="41" runat="server" Width="100%" MaxLength="12" CssClass="mandatory"
										onchange="EnsureNumber(this)" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_RISK_ASSETS3"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    tabIndex="66" runat="server" Width="100%" MaxLength="12"
										ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>JUMLAH 
										MODAL PELENGKAP</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_JUMLAH_MODAL_PELENGKAP1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_JUMLAH_MODAL_PELENGKAP2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_JUMLAH_MODAL_PELENGKAP3"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>TOTAL 
										MODAL UNTUK PERHITUNGAN CAR</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_TOTAL_MODAL_4_CAR1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_TOTAL_MODAL_4_CAR2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_TOTAL_MODAL_4_CAR3"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!-------------------------------------------------------------------->
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>FIXED 
										ASSET MILIK DEBITUR YANG DIKUASAI BPR</STRONG></TD>
							</TR>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>PINJAMAN 
										DARI BANK LAIN</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_DARI_BANK_LAIN1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_DARI_BANK_LAIN2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_DARI_BANK_LAIN3"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>PINJAMAN 
										DARI BANK INDONESIA</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_DARI_BI1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_DARI_BI2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_KOMDAL_PINJAMAN_DARI_BI3"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"    runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE>
			</TD></TR>
			<table style="WIDTH: 100%">
				<tr>
					<td class="tdBGColor2" style="WIDTH: 100%" align="center"><asp:label id="LBL_H_TAHUN" runat="server" Visible="False"></asp:label>
						<asp:button id="BtnCalculate" runat="server" Width="229px" CssClass="Button1" Text="Calculate Komposisi Modal" onclick="BtnCalculate_Click"></asp:button><asp:label id="LBL_H_SEQ" runat="server" Visible="False"></asp:label>&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
			</table>
			</TD></TR></TABLE></TD></TR></TABLE></TR></TABLE></TR></TABLE> 
			<!--############################################################################### --></form>
	</body>
</HTML>
