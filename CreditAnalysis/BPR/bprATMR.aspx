<%@ Page language="c#" Codebehind="bprATMR.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.bprATMR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>NPL BPR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #includefile="../../include/cek_all.html" -->
		<!-- #includefile="../../include/bpr_validasi.html" -->
		<!-- #includefile="../../include/onepost.html" -->
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
			v_a = "1.000,00"'-- in Rupiah Currency
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
										ATMR</B></TD>
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
					<TD class="tdHeader1" vAlign="top" colSpan="3">ATMR (Rp. 000,-)</TD>
				</TR>
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<TR>
					<td align="center" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="1">
							<tr>
								<td class="tdSmallHeader" style="WIDTH: 401px" align="center" width="401" rowSpan="2">URAIAN</td>
								<td class="tdSmallHeader" align="center" width="30%" colSpan="4">REALISASI
									<asp:label id="LBL_ATMR1" runat="server">Label</asp:label></td>
								<td class="tdSmallHeader" align="center" width="30%" colSpan="4">REALISASI&nbsp;
									<asp:label id="LBL_ATMR2" runat="server">Label</asp:label></td>
							</tr>
							<tr>
								<td class="tdSmallHeader" align="center" width="15%" colSpan="2">Rupiah</td>
								<td class="tdSmallHeader" align="center" width="15%" colSpan="2">ATMR</td>
								<td class="tdSmallHeader" style="WIDTH: 179px" align="center" width="179" colSpan="2">Rupiah</td>
								<td class="tdSmallHeader" align="center" width="15%" colSpan="2">ATMR</td>
							</tr>
							<tr>
								<td class="TblAlternating" style="PADDING-LEFT: 10px; WIDTH: 920px" align="left" width="920"
									colSpan="9"><STRONG>AKTIVA&nbsp;</STRONG></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 24px" align="left" width="401">&nbsp;1. 
									Kas</td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_KAS1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_KAS1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_KAS2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_KAS2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
									Sertifikat Bank Indonesia</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_SBI1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_SBI1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_SBI2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_SBI2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. 
									Antar Bank Aktiva</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_ANTAR_BANK_AKTIVA1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_ANTAR_BANK_AKTIVA2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;4. 
									Kredit Yang Diberikan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_KREDIT_YANG_DIBERIKAN1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_KREDIT_YANG_DIBERIKAN1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_KREDIT_YANG_DIBERIKAN2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_KREDIT_YANG_DIBERIKAN2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;5. 
									Aktiva Tetap Dan Inventaris</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_AKTIVA_TETAP_DAN_INVENTARIS1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_AKTIVA_TETAP_DAN_INVENTARIS1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 23px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_AKTIVA_TETAP_DAN_INVENTARIS2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_AKTIVA_TETAP_DAN_INVENTARIS2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;6. 
									Antar Kantor Aktiva</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_ANTAR_KANTOR_AKTIVA1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_ANTAR_KANTOR_AKTIVA1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 23px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_ANTAR_KANTOR_AKTIVA2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_ANTAR_KANTOR_AKTIVA2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;7. Rupa 
									Rupa Aktiva</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_RUPA2_AKTVIVA1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12"
										onchange="EnsureNumber(this)" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_RUPA2_AKTIVA1"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" MaxLength="12"
										onchange="EnsureNumber(this)" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="WIDTH: 179px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_RUPA2_AKTVIVA2"  
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="67" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_RUPA2_AKTIVA2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>TOTAL 
										ASSETS</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_TOTAL1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_TOTAL1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_AKTV_TOTAL2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="WIDTH: 179px; HEIGHT: 24px" align="center" width="179" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_ATMR_TOTAL2" 
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro"
										ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE></TD></TR>
			<table style="WIDTH: 100%; HEIGHT: 36px">
				<tr>
					<td class="tdBGColor2" style="WIDTH: 100%" align="center"><asp:label id="LBL_H_TAHUN" runat="server" Visible="False"></asp:label>
						<asp:button id="btn_Save" runat="server" Width="327px" Text="Calculate Aktiva Tertimbang Menurut Resiko"
							CssClass="Button1" DESIGNTIMEDRAGDROP="2557" onclick="btn_Save_Click"></asp:button><asp:label id="LBL_H_SEQ" runat="server" Visible="False"></asp:label>&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
			</table></TD></TR></TABLE></TD></TR></TABLE></TR></TABLE></TR></TABLE> 
			<!--############################################################################### --></form>
	</body>
</HTML>
