<%@ Page language="c#" Codebehind="bprAnalisisRasio.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.bprAnalisisRasio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>bprAnalisisRasio</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../include/cek_all.html" -->
		<!-- #include  file="../../include/bpr_validasi.html" -->
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
			<!--######################################################################################-->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TBODY>
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
											Analisis Rasio</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">
							<P>ANALISIS RASIO (Rp. 000,-)</P>
						</TD>
					</TR>
					<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				</TBODY>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="100%" border="1">
				<TBODY>
					<tr>
						<td class="tdSmallHeader" align="center" width="40%" rowSpan="2" style="HEIGHT: 53px">URAIAN</td>
						<td class="tdSmallHeader" align="center" width="60%" colSpan="6">
							<P>ANALISIS RASIO</P>
						</td>
					</tr>
					<tr>
						<td class="tdSmallHeader" style="WIDTH: 211px; HEIGHT: 27px" align="center" width="211"
							colSpan="2">Tahun ke-n/bln</td>
						<td class="tdSmallHeader" align="center" width="20%" colSpan="2" style="HEIGHT: 27px">Tahun 
							ke-n+1/bln</td>
						<td class="tdSmallHeader" align="center" width="20%" colSpan="2" style="HEIGHT: 27px">Tahun 
							Proyeksi/bln</td>
					</tr>
					<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
					<tr>
						<td style="PADDING-RIGHT: 15px; HEIGHT: 32px" align="right" width="40%"><STRONG>Posisi 
								Tanggal</STRONG></td>
						<td class="tdSmallHeader" style="HEIGHT: 32px" align="center" width="15%" colSpan="2"><nobr>
								<asp:textbox id="txt_DD_B12" runat="server" Width="22px" Columns="4" MaxLength="2" tabIndex="1"
									onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_MM_B12" runat="server" tabIndex="2" BackColor="Gainsboro" Enabled="False"
									CssClass="mandatory"></asp:dropdownlist><asp:textbox id="txt_YY_B12" runat="server" Columns="4" MaxLength="4" onkeypress="return numbersonly()"
									tabIndex="3" BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox></nobr></td>
						<td class="tdSmallHeader" style="HEIGHT: 32px" align="center" width="15%" colSpan="2"><nobr>
								<asp:textbox id="txt_DD_C12" runat="server" Width="22px" Columns="4" MaxLength="2" tabIndex="37"
									onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_MM_C12" runat="server" tabIndex="38" BackColor="Gainsboro" Enabled="False"
									CssClass="mandatory"></asp:dropdownlist><asp:textbox id="txt_YY_C12" runat="server" Columns="4" MaxLength="4" tabIndex="39" onkeypress="return numbersonly()"
									BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox></nobr></td>
						<td class="tdSmallHeader" style="HEIGHT: 32px" align="center" width="15%" colSpan="2"><nobr>
								<asp:textbox id="txt_DD_D12" runat="server" Width="22px" Columns="4" MaxLength="2" tabIndex="73"
									onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_MM_D12" runat="server" tabIndex="74" BackColor="Gainsboro" Enabled="False"
									CssClass="mandatory"></asp:dropdownlist><asp:textbox id="txt_YY_D12" runat="server" Columns="4" MaxLength="4" tabIndex="75" onkeypress="return numbersonly()"
									BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox></nobr></td>
					</tr>
					<TR>
						<TD style="PADDING-RIGHT: 15px; HEIGHT: 25px" align="right" width="40%"><STRONG>Bulan</STRONG></TD>
						<TD class="tdSmallHeader" style="HEIGHT: 25px" align="center" width="15%" colSpan="2"><asp:textbox id="txt_B13" style="TEXT-ALIGN: right" runat="server" Width="50px" Columns="4" MaxLength="2"
								onkeypress="return numbersonly()" tabIndex="4" BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox></TD>
						<TD class="tdSmallHeader" style="HEIGHT: 25px" align="center" width="15%" colSpan="2"><asp:textbox id="txt_C13" style="TEXT-ALIGN: right" runat="server" Width="50px" Columns="4" MaxLength="2"
								tabIndex="40" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox></TD>
						<TD class="tdSmallHeader" style="HEIGHT: 25px" align="center" width="15%" colSpan="2"><asp:textbox id="txt_D13" style="TEXT-ALIGN: right" runat="server" Width="50px" Columns="4" MaxLength="2"
								tabIndex="76" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True" CssClass="mandatory"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-RIGHT: 15px; HEIGHT: 25px" align="right" width="40%"></TD>
						<TD class="tdSmallHeader" style="HEIGHT: 25px" align="center" width="15%" colSpan="2">
							<asp:dropdownlist id="ddl_B14" tabIndex="5" runat="server" BackColor="Gainsboro" Enabled="False" CssClass="mandatory">
								<asp:ListItem Value="-">-Pilih-</asp:ListItem>
								<asp:ListItem Value="Audited">Audited</asp:ListItem>
								<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD class="tdSmallHeader" style="HEIGHT: 25px" align="center" width="15%" colSpan="2">
							<asp:dropdownlist id="ddl_C14" tabIndex="5" runat="server" BackColor="Gainsboro" Enabled="False" CssClass="mandatory">
								<asp:ListItem Value="-">-Pilih-</asp:ListItem>
								<asp:ListItem Value="Audited">Audited</asp:ListItem>
								<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
							</asp:dropdownlist></TD>
						<TD class="tdSmallHeader" style="HEIGHT: 25px" align="center" width="15%" colSpan="2">
							<asp:dropdownlist id="ddl_D14" tabIndex="5" runat="server" BackColor="Gainsboro" Enabled="False" Visible="False"
								CssClass="mandatory">
								<asp:ListItem Value="-">-Pilih-</asp:ListItem>
								<asp:ListItem Value="Audited">Audited</asp:ListItem>
								<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
							</asp:dropdownlist></TD>
					</TR>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><B>A. Size</B></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px; HEIGHT: 24px" align="left" width="40%">&nbsp;&nbsp; 
							1. Total Assets</td>
						</TD>
						<td style="WIDTH: 211px; HEIGHT: 24px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12" tabIndex="5" BackColor="Gainsboro"
								ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2" style="HEIGHT: 24px"><asp:textbox id="txt_C15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="41" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2" style="HEIGHT: 24px"><asp:textbox id="txt_D15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="77" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp; &nbsp;2. Risk 
							Weighted Assets</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="6" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="42" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="78" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px; HEIGHT: 20px" align="left" width="40%">&nbsp; 
							&nbsp;3. Jumlah Aktiva Produktif</td>
						</TD>
						<td style="WIDTH: 211px; HEIGHT: 20px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="7" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12" BackColor="Gainsboro"
								ReadOnly="True"></asp:textbox></td>
						<td style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_C17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="43" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_D17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="79" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px; HEIGHT: 23px" align="left" width="40%">&nbsp; 
							&nbsp;4. Jumlah Modal</td>
						</TD>
						<td style="WIDTH: 211px; HEIGHT: 23px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="8" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12" BackColor="Gainsboro"
								ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2" style="HEIGHT: 23px"><asp:textbox id="txt_C18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="44" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2" style="HEIGHT: 23px"><asp:textbox id="txt_D18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="80" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp; &nbsp;5. Dana Pihak 
							Ketiga</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="9" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="45" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="81" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="40%">
							&nbsp;&nbsp;&nbsp;6. Kredit Yang Diberikan</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="13" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="49" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="85" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 7. Penyisihan 
							penghapusan aktiva produktif</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="14" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)" MaxLength="12"
								BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="50" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="86" onkeypress="return numbersonly()" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
								MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>B.&nbsp; 
								Liquidity</STRONG></td>
						</STRONG></TD></tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px; HEIGHT: 22px" align="left" width="40%">&nbsp;&nbsp; 
							1. Loan To Deposit (LDR) (%)</td>
						</TD>
						<td style="WIDTH: 211px; HEIGHT: 22px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="20" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_C30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="56" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_D30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="72" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 2. Alat Liquid 
							/ Hutang Lancar (Cash Periode) (%)</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="22" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="58" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="74" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>C. 
								Profitability</STRONG></td>
						</STRONG></TD></tr>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 1. ROA<SPAN style="mso-spacerun: yes">&nbsp;
							</SPAN>(Laba Sebelum Pajak) (%)</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="23" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="59" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="75" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px; HEIGHT: 23px" align="left" width="40%">&nbsp;&nbsp; 
							2. Return On Equity (ROE) (%)</td>
						</TD>
						<td style="WIDTH: 211px; HEIGHT: 23px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="24" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_C34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="60" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_D34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="76" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr>
						<td style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 3. Laba 
							Operasional/Tot. Assets (%)</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="25" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="61" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="77" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<tr class="TblAlternating">
						<td style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 4. Beban/ 
							Pendapatan Operasional (%)</td>
						</TD>
						<td style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B36" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="26" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_C36" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="62" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
						<td align="center" width="20%" colSpan="2"><asp:textbox id="txt_D36" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="78" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
					</tr>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 21px" align="left" width="40%">&nbsp;&nbsp; 
							5. Fee Based Income To Total Income (%)</TD>
						</TD>
						<TD style="WIDTH: 211px; HEIGHT: 21px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B37" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="27" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD style="HEIGHT: 21px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_C37" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="63" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD style="HEIGHT: 21px" align="center" width="20%" colSpan="2"><asp:textbox id="txt_D37" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="79" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>D. 
								Efisiensi</STRONG></TD>
						</STRONG></TD></TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 1. Overhead 
							Cost/Total Assets (%)</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B38" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="28" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C38" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="64" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D38" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="80" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 2. Operating 
							expenses/net revenue (%)</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B39" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="29" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C39" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="65" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D39" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="81" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp; 3. Biaya dana 
							(Funding Cost) (%)</TD>
						</TD></TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B40" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="30" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C40" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="66" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D40" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="82" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px; HEIGHT: 23px" align="left" width="40%" colSpan="7">
							<P><STRONG>E. Capital Adequacy</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp;1. Modal/Risk 
							Asset Ratio (CAR) (%)</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="31" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="67" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="83" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp;2. Net 
							worth/total assets (%)</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B42" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="32" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C42" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="68" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D42" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="84" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px; HEIGHT: 22px" align="left" width="40%" colSpan="7"><STRONG>F. 
								Asset Quality</STRONG></TD>
						</STRONG></TD></TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp;1. Net Interest 
							Margin (Nim) (%)</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="33" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="69" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="85" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp;2. Net interest 
							income/quick &amp; risk assets (%)</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="34" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="70" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="86" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR class="TblAlternating">
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp;3. Provision 
							Charge To Total Loans (%)</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"><asp:textbox id="txt_B45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="35" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_C45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="71" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2"><asp:textbox id="txt_D45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
								tabIndex="87" onkeypress="return numbersonly()" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp;4. 
							Non-Performing Loan To Tot. Loan (%)</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2">
							<asp:textbox onkeypress="return numbersonly()" id="txt_B46" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
								tabIndex="36" runat="server" Width="100%" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)"
								onchange="EnsureNumber(this)"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2">
							<asp:textbox onkeypress="return numbersonly()" id="txt_C46" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
								tabIndex="72" runat="server" Width="100%" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)"
								onchange="EnsureNumber(this)"></asp:textbox></TD>
						<TD align="center" width="20%" colSpan="2">
							<asp:textbox onkeypress="return numbersonly()" id="txt_D46" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
								tabIndex="88" runat="server" Width="100%" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)"
								onchange="EnsureNumber(this)"></asp:textbox></TD>
					</TR>
					<!--
					<TR>
						<TD style="PADDING-LEFT: 10px" align="left" width="40%">&nbsp;&nbsp;17. 
							Non-Performing Loan To Tot. Loan</TD>
						</TD>
						<TD style="WIDTH: 211px" align="center" width="211" colSpan="2"></TD>
						<TD align="center" width="20%" colSpan="2"></TD>
						<TD align="center" width="20%" colSpan="2"></TD>
					</TR>
					-->
				</TBODY>
			</table>
			</TD></TR></TBODY></TABLE></TD></TR>
			<table width="100%">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<table width="100%">
								<TBODY>
									<tr>
										<td class="tdBGColor2" align="center">
											<asp:button id="btn_Save" runat="server" Width="100px" Text=" Save " DESIGNTIMEDRAGDROP="56"
												CssClass="Button1" onclick="btn_Save_Click"></asp:button>&nbsp;
										</td>
									</tr>
								</TBODY>
							</table>
							<table width="100%">
								<tr>
									<td width="33%">
										<asp:textbox onkeypress="return numbersonly()" id="txt_B20" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="10" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B21" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="11" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B22" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="12" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B25" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="15" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B26" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="17" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B27" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="18" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B28" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="19" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B29" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="16" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return numbersonly()" id="txt_B31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											tabIndex="21" runat="server" Width="100%" Visible="False"></asp:textbox><BR>
									</td>
									<td width="33%">
										<asp:textbox onkeypress="return numbersonly()" id="txt_C20" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="46" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C21" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="47" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C22" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="48" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C25" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="51" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C26" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="52" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C27" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="53" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C28" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="54" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C29" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="55" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return numbersonly()" id="txt_C31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											tabIndex="57" runat="server" Width="100%" Visible="False"></asp:textbox><BR>
									</td>
									<td width="33%">
										<asp:textbox onkeypress="return numbersonly()" id="txt_D20" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="82" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D21" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="83" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D22" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="84" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D25" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="87" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D26" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="88" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D27" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="89" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D28" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="70" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D29" onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											onfocus="RestoreCurrency(this)" tabIndex="71" runat="server" Width="100%" MaxLength="12"
											onchange="EnsureNumber(this)" Visible="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return numbersonly()" id="txt_D31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
											tabIndex="73" runat="server" Width="100%" Visible="False"></asp:textbox><BR>
									</td>
								</tr>
							</table>
						</TD>
					</TR>
				</TBODY>
			</table>
			<!--######################################################################################--></form>
	</body>
</HTML>
