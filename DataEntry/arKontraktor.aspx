<%@ Page language="c#" Codebehind="arKontraktor.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.arKontraktor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Kontractor</title>
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
			'	edit.value = formatnumber(value,2)
			'else	edit.value = ""
			'end if
			edit.style.textAlign = "right"
		end function
		function RestoreCurrency(edit)
			'value = edit.value
			'value = replace(value, ".", "")
			'value = replace(value, ",", ".")
			'if isnumeric(value) then
			'	edit.value = eval(value)
			'	edit.select
			'else	edit.value = ""
			'end if
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
			<table width="100%" border="1">
				<TR>
					<TD class="tdHeader1" width="100%" colSpan="3">PROYEK</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3"><nobr>Ketentuan Kredit:
							<asp:dropdownlist id="ddl_KTR_KETKREDIT" runat="server" Enabled="False">
								<asp:ListItem Value="0">--Pilih--</asp:ListItem>
							</asp:dropdownlist></nobr></TD>
				</TR>
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="3">Plafon Rutin (RP. 000,-)</td>
				</tr>
				<tr>
					<td class="tdSmallHeader" width="47%"></td>
					<td class="tdSmallHeader" style="WIDTH: 130px" width="130"><nobr>Past Performance</nobr></td>
					<td class="tdSmallHeader" width="27%">Rencana</td>
				</tr>
				<tr>
					<td width="47%"><nobr>Nilai Proyek Rata-Rata per Bulan</nobr></td>
					<td style="WIDTH: 130px" width="130"><asp:textbox id="txt_KTR_BP_NILAIPROYEK" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
					<td width="27%"><asp:textbox id="txt_KTR_RC_NILAIPROYEK" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<tr class="TblAlternating">
					<td width="47%"><nobr>Persentase Proyek Cost Rata-Rata (%)</nobr></td>
					<td style="WIDTH: 130px" width="130"><asp:textbox id="txt_KTR_BP_PRSNPROYEK" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
					<td width="27%"><asp:textbox id="txt_KTR_RC_PRSNPROYEK" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<tr>
					<td width="47%"><nobr>Lama Pembayaran Rata-Rata (Bulan)</nobr></td>
					<td style="WIDTH: 130px" width="130"><asp:textbox id="txt_KTR_BP_LAMABAYAR" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
					<td width="27%"><asp:textbox id="txt_KTR_RC_LAMABAYAR" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<tr class="TblAlternating">
					<td width="47%"><nobr>Uang Muka Rata-Rata</nobr></td>
					<td style="WIDTH: 131px" width="131"><asp:textbox id="txt_KRT_BP_UANGMUKA" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
					<td width="27%"><asp:textbox id="txt_KTR_RC_UANGMUKA" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
			</table>
			<br>
			<table width="100%" border="1">
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="2">Termin</td>
				</tr>
				<tr>
					<td width="58%"><nobr>Proyek Cost yang Diaksep</nobr></td>
					<td width="42%"><asp:textbox id="txt_KTR_TM_COSTPROYEK" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<tr class="TblAlternating">
					<td style="HEIGHT: 24px" width="58%"><nobr>Jumlah Termin</nobr></td>
					<td style="HEIGHT: 24px" width="42%"><asp:textbox id="txt_KTR_TM_JUMLAHTRM" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<tr>
					<td width="58%"><nobr>Uang Muka</nobr></td>
					<td width="42%"><asp:textbox id="txt_KTR_TM_UANGMUKA" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
			</table>
			<br>
			<table width="100%" border="1">
				<tr>
					<td class="tdSmallHeader" width="100%" colSpan="2">Turn Key</td>
				</tr>
				<tr>
					<td width="57%"><nobr>Proyek Cost yang Diaksep</nobr></td>
					<td width="43%"><asp:textbox id="txt_KTR_TK_COSTPROYEK" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<tr class="TblAlternating">
					<td width="57%"><nobr>Uang Muka</nobr></td>
					<td width="43%"><asp:textbox id="txt_KTR_TK_UANGMUKA" onkeypress="return digitsonly()" runat="server" onblur="FormatCurrency(this), FormatCurrency_ahmad(this)"
							onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" style="TEXT-ALIGN: right"></asp:textbox></td>
				</tr>
				<TR>
					<TD class="TDBGColor2" width="57%" colSpan="2"><asp:button id="btn_Save" 
                            runat="server" Text="Simpan" CssClass="Button1" onclick="btn_Save_Click"></asp:button>&nbsp;
						<asp:button id="btn_Delete" runat="server" CssClass="Button1" Text="Hapus" 
                            onclick="btn_Delete_Click"></asp:button></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
