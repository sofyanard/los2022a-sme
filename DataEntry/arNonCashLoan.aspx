<%@ Page language="c#" Codebehind="arNonCashLoan.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.arNonCashLoan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Non Cash Loan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<script language="vbscript">
		function FormatCurrency_ahmad(edit)
			SetLocale("in")
			'value = edit.value
			'value = replace(value, ".", "")
			'value = replace(value, ",", ".")
			'if isnumeric(value) then
			'edit.value = formatnumber(value,2)
			'else	edit.value = ""
			'end if
			edit.style.textAlign = "right"
		end function		
	
		function RestoreCurrency(edit)
			SetLocale("in")			
			'value = edit.value
			'value = replace(value, ".", "")
			'value = replace(value, ",", ".")
			'if isnumeric(value) then
				'edit.value = eval(value)
				'edit.select
			'else	edit.value = ""
			'end if
			edit.style.textAlign = "left"
		end function
		function EnsureNumber(edit)
			SetLocale("in")
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
			<table width="100%" border="1">
				<TR>
					<TD class="tdHeader1" width="100%" colSpan="8">NON CASH LOAN</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="8">Ketentuan Kredit:
						<asp:dropdownlist id="ddl_NCL_KETKREDIT" runat="server" Enabled="False">
							<asp:ListItem Value="0">--Pilih--</asp:ListItem>
						</asp:dropdownlist>
						<asp:Label id="lbl_PAR" runat="server" Visible="False"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" width="100%" colSpan="8">Rencana Kebutuhan Bank Garansi, L/C, 
						SKBDN (Permohonan NCL)</TD>
				</TR>
				<tr>
					<td class="tdSmallHeader" align="center" width="2%">No.</td>
					<td class="tdSmallHeader" align="center" width="18%">Jenis BG atau L/C</td>
					<td class="tdSmallHeader" align="center" width="14%"><nobr>Nilai Kontrak</nobr></td>
					<td class="tdSmallHeader" align="center" width="12%">%</td>
					<td class="tdSmallHeader" align="center" width="14%">Normal</td>
					<td class="tdSmallHeader" align="center" width="12%">% Set</td>
					<td class="tdSmallHeader" align="center" width="14%">Set Jaminan</td>
					<td class="tdSmallHeader" align="center" width="14%">JW</td>
				</tr>
				<tr>
					<td align="center" width="2%">1.</td>
					<td width="18%">Tender</td>
					<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_TD_KONT" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_TD_PRSN" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox class="TDBGColor" id="txt_TD_Norm" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_TD_PSET" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox id="txt_TD_SJam" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
							ReadOnly="True"></asp:textbox></td>
					<td width="14%"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_TD_JW_dd" Width="25px" MaxLength="2"
								Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_TD_JW_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_TD_JW_yy" Width="40px" MaxLength="4"
								Runat="server" Columns="4"></asp:textbox></nobr></td>
				</tr>
				<TR class="TblAlternating">
					<TD align="center" width="2%">2.</TD>
					<TD width="18%">Uang Muka</TD>
					<TD width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_UM_KONT" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></TD>
					<TD width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_UM_PRSN" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></TD>
					<TD width="14%"><asp:textbox class="TDBGColor" id="txt_UM_Norm" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					<TD width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_UM_PSET" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></TD>
					<td width="14%"><asp:textbox id="txt_UM_SJam" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
							ReadOnly="True"></asp:textbox></td>
					<td width="14%"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_UM_JW_dd" Width="25px" MaxLength="2"
								Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_UM_JW_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_UM_JW_yy" Width="40px" MaxLength="4"
								Runat="server" Columns="4"></asp:textbox></nobr></td>
				</TR>
				<tr>
					<td style="HEIGHT: 25px" align="center" width="2%">3.</td>
					<td style="HEIGHT: 25px" width="18%">Pelaksanaan</td>
					<td style="HEIGHT: 25px" width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PK_KONT" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
					<td style="HEIGHT: 25px" width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PK_PRSN" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
					<td style="HEIGHT: 25px" width="14%"><asp:textbox class="TDBGColor" id="txt_PK_Norm" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					<td style="HEIGHT: 25px" width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PK_PSET" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
					<td style="HEIGHT: 25px" width="14%"><asp:textbox id="txt_PK_SJam" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
							ReadOnly="True"></asp:textbox></td>
					<td style="HEIGHT: 25px" width="14%"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_PK_JW_dd" Width="25px" MaxLength="2"
								Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_PK_JW_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_PK_JW_yy" Width="40px" MaxLength="4"
								Runat="server" Columns="4"></asp:textbox></nobr></td>
				</tr>
				<tr class="TblAlternating">
					<td align="center" width="2%">4.</td>
					<td width="18%">Pemeliharaan</td>
					<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PM_KONT" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PM_PRSN" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox class="TDBGColor" id="txt_PM_Norm" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PM_PSET" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox id="txt_PM_SJam" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
							ReadOnly="True"></asp:textbox></td>
					<td width="14%"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_PM_JW_dd" Width="25px" MaxLength="2"
								Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_PM_JW_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_PM_JW_yy" Width="40px" MaxLength="4"
								Runat="server" Columns="4"></asp:textbox></nobr></td>
				</tr>
				<tr>
					<td align="center" width="2%">5.</td>
					<td width="18%">Pembelian</td>
					<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PB_KONT" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PB_PRSN" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox class="TDBGColor" id="txt_PB_Norm" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_PB_PSET" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox id="txt_PB_SJam" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
							ReadOnly="True"></asp:textbox></td>
					<td width="14%"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_PB_JW_dd" Width="25px" MaxLength="2"
								Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_PB_JW_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_PB_JW_yy" Width="40px" MaxLength="4"
								Runat="server" Columns="4"></asp:textbox></nobr></td>
				</tr>
				<tr class="TblAlternating">
					<td align="center" width="2%">6.</td>
					<td width="18%">L/C</td>
					<td width="14%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_LC_KONT" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_LC_PRSN" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox class="TDBGColor" id="txt_LC_Norm" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					<td width="12%"><asp:textbox onkeypress="return digitsonly()" id="txt_NCL_LC_PSET" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							style="TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12"
							onchange="EnsureNumber(this)"></asp:textbox></td>
					<td width="14%"><asp:textbox id="txt_LC_SJam" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
							ReadOnly="True"></asp:textbox></td>
					<td width="14%"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_LC_JW_dd" Width="25px" MaxLength="2"
								Runat="server" Columns="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_LC_JW_mm" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_NCL_LC_JW_yy" Width="40px" MaxLength="4"
								Runat="server" Columns="4"></asp:textbox></nobr></td>
				</tr>
				<tr class="TDBGColor">
					<td width="2%"></td>
					<td width="18%">TOTAL</td>
					<td width="14%"><asp:textbox id="txt_TotKont" style="TEXT-ALIGN: right" runat="server" Width="100%" BackColor="Gainsboro"
							ReadOnly="True"></asp:textbox></td>
					<td width="12%"></td>
					<td width="14%"><asp:textbox class="TDBGColor" id="txt_TotNorm" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					<td width="12%"></td>
					<td width="14%"><asp:textbox class="TDBGColor" id="txt_TotSJam" style="TEXT-ALIGN: right" runat="server" Width="100%"
							BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					<td width="14%"></td>
				</tr>
				<!-- di remark<denny>, krn asp:button kemungkinan tidak bisa diakses oleh javascript:getElemenbyId, jadi diganti dgn input button html 
				<tr>
					<td class="TDBGColor2" align="center" width="100%" colSpan="8"><asp:button id="btn_Hitung" runat="server" Text="Hitung" CssClass="Button1"></asp:button></td>
				</tr>
				-->
				<tr><td class="TDBGColor2" align="center" width="100%" colSpan="8"><input type="submit" name="btn_Hitung" value="Hitung" id="btn_Hitung" class="Button1" onclick="btn_Hitung_Click" /></td></tr>
			</table>
			<!-- menurut cheng di hilangin aja
			<table width="100%" border="1">
				<TR>
					<TD width="30%" colSpan="4" style="HEIGHT: 20px"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" style="HEIGHT: 26px" width="30%" colSpan="4">Data Pendukung 
						Lain</TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" width="30%">Tujuan Penggunaan</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_TJNPGUNAN" runat="server" Width="100%"></asp:textbox></TD>
					<TD class="TDBGColor0" width="20%">Jangka Waktu</TD>
					<TD width="30%"><nobr><asp:textbox  id="txt_NCL_JW_dd" Width="25px" Columns="2" Runat="server"
								MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_JW_mm" Runat="server"></asp:dropdownlist><asp:textbox  id="txt_NCL_JW_yy" Width="40px" Columns="4" Runat="server"
								MaxLength="4"></asp:textbox></nobr></TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" width="30%">Dasar Permohonan Penerbitan</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_DSRTERBIT" runat="server" Width="100%"></asp:textbox></TD>
					<TD class="TDBGColor0" width="20%">Tanggal Penerbitan</TD>
					<TD width="30%"><nobr><asp:textbox  id="txt_NCL_TP_dd" Width="25px" Columns="2" Runat="server"
								MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_TP_mm" Runat="server"></asp:dropdownlist><asp:textbox  id="txt_NCL_TP_yy" Width="40px" Columns="4" Runat="server"
								MaxLength="4"></asp:textbox></nobr></TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" style="HEIGHT: 26px" width="30%">Diajukan Kepada/Beneficiary</TD>
					<TD style="HEIGHT: 26px" width="30%"><asp:textbox id="txt_NCL_KPD" runat="server" Width="100%"></asp:textbox></TD>
					<TD class="TDBGColor0" style="HEIGHT: 26px" width="20%">Jatuh Tempo</TD>
					<TD style="HEIGHT: 26px" width="30%"><nobr><asp:textbox  id="txt_NCL_JT_dd" Width="25px" Columns="2" Runat="server"
								MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_NCL_JT_mm" Runat="server"></asp:dropdownlist><asp:textbox  id="txt_NCL_JT_yy" Width="40px" Columns="4" Runat="server"
								MaxLength="4"></asp:textbox></nobr></TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" width="30%">Alamat</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_KPDALMT" runat="server" Width="100%"></asp:textbox></TD>
					<TD width="20%" colSpan="2"></TD>
				</TR>
				<TR>
					<TD width="30%" colSpan="4"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" width="30%" colSpan="4">
						<P>Untuk Permohonan L/C dan SKBDN</P>
					</TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" width="30%">Barang Komoditi</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_BRGKOMODITI" runat="server" Width="100%"></asp:textbox></TD>
					<TD class="TDBGColor0" width="20%">Jumlah/Kualitas</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_KUALITAS" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" width="30%">Nilai FOB / CIF / CNF</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_NILFOB" runat="server" Width="100%"></asp:textbox></TD>
					<TD class="TDBGColor0" width="20%">Keterangan Lain</TD>
					<TD width="30%"></TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" width="30%">Bank Koresponden</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_BANK" runat="server" Width="100%"></asp:textbox></TD>
					<TD width="50%" colSpan="2" rowSpan="2"><asp:textbox id="txt_NCL_KET" runat="server" Width="100%" TextMode="MultiLine" Height="50px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor0" width="30%">Alamat</TD>
					<TD width="30%"><asp:textbox id="txt_NCL_BANKALMT" runat="server" Width="100%"></asp:textbox></TD>
				</TR>
			</table>
			<br>
			--><br>
			<table width="100%" border="1">
				<TR>
					<TD class="TDBGColor2" align="center" width="7%" colSpan="5">
                        <asp:button id="btn_Save" runat="server" Text="Simpan" CssClass="Button1" 
                            onclick="btn_Save_Click"></asp:button>&nbsp;<asp:button id="btn_Delete" 
                            runat="server" Text="Hapus" CssClass="Button1" onclick="btn_Delete_Click"></asp:button></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
