<%@ Page language="c#" Codebehind="bprRugiLaba.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.bprRugiLaba" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Rugi-Laba BPR</title>
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
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table6">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center">
									<P><B>Credit Analysis&nbsp;: LABA RUGI</B></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
						<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
					</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" colSpan="2">LABA RUGI (Rp. 000,-)</TD>
				</TR>
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<tr>
					<TD class="tdNoBorder" vAlign="top" align="center" colSpan="2"><table width="100%">
							<tr>
								<td class="tdHeader1" vAlign="top" width="50%">History</td>
								<td class="tdHeader1" vAlign="top" width="50%">Current</td>
							</tr>
							<TR>
								<td vAlign="top" width="50%"><ASP:DATAGRID id="DG_NeracaHistory" runat="server" AllowPaging="True" Width="100%" CellPadding="1"
										PageSize="5" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
												<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="POSISI_TGL" HeaderText="Year">
												<HeaderStyle HorizontalAlign="Center" Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="JML_BLN" HeaderText="Periode Laporan">
												<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="tahun"></asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" CommandName="retrieve_history">
												<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="" PrevPageText="" Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<TD class="tdNoBorder" vAlign="top" align="center" width="50%">
									<TABLE id="Table2" width="100%" border="1">
										<TR>
											<TD vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="dg_Neraca" runat="server" Width="100%" CellPadding="1" PageSize="5" AutoGenerateColumns="False"
													AllowPaging="True">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn DataField="POSISI_TGL" HeaderText="Year">
															<HeaderStyle HorizontalAlign="Center" Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="JML_BLN" HeaderText="Periode Laporan">
															<HeaderStyle HorizontalAlign="Center" Width="48%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:ButtonColumn Text="Retrieve" CommandName="retrieve">
															<HeaderStyle Width="1%"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Text="Delete" CommandName="delete">
															<HeaderStyle Width="1%"></HeaderStyle>
														</asp:ButtonColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</ASP:DATAGRID>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</TD>
				</tr>
				<TR>
					<td align="center" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="1">
							<tr>
								<td class="tdSmallHeader" style="WIDTH: 380px" align="center" width="380" rowSpan="2">URAIAN</td>
								<td class="tdSmallHeader" align="center" width="60%" colSpan="6">RUGI LABA</td>
							</tr>
							<tr>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n/bln</td>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n+1/bln</td>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun Proyeksi/bln</td>
							</tr>
							<tr>
								<td style="PADDING-RIGHT: 15px; WIDTH: 380px; HEIGHT: 23px" align="right" width="380"><STRONG>Posisi 
										Tanggal</STRONG></td>
								<td class="tdSmallHeader" style="HEIGHT: 23px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_DD_B29" tabIndex="1" runat="server" Width="22px"
											Columns="4" MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_MM_B29" tabIndex="2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_YY_B29" tabIndex="3" runat="server" Columns="4"
											MaxLength="4" CssClass="mandatory"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 23px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_DD_C29" tabIndex="25" runat="server" Width="22px"
											Columns="4" MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_MM_C29" tabIndex="26" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_YY_C29" runat="server" Columns="4" MaxLength="4"
											Rows="27" CssClass="mandatory"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 23px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return numbersonly()" id="txt_DD_D29" tabIndex="49" runat="server" Width="22px"
											Columns="4" MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_MM_D29" tabIndex="50" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_YY_D29" tabIndex="51" runat="server" Columns="4"
											MaxLength="4" CssClass="mandatory"></asp:textbox></nobr></td>
							</tr>
							<TR>
								<TD style="PADDING-RIGHT: 15px; WIDTH: 380px; HEIGHT: 29px" align="right" width="380"><STRONG>Bulan</STRONG></TD>
								<TD class="tdSmallHeader" style="HEIGHT: 29px" align="center" width="15%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B30" style="TEXT-ALIGN: right" tabIndex="4"
										runat="server" Width="50px" Columns="4" MaxLength="2" CssClass="mandatory"></asp:textbox></TD>
								<TD class="tdSmallHeader" style="HEIGHT: 29px" align="center" width="15%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C30" style="TEXT-ALIGN: right" tabIndex="28"
										runat="server" Width="50px" Columns="4" MaxLength="2" CssClass="mandatory"></asp:textbox></TD>
								<TD class="tdSmallHeader" style="HEIGHT: 29px" align="center" width="15%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D30" style="TEXT-ALIGN: right" tabIndex="52"
										runat="server" Width="50px" Columns="4" MaxLength="2" CssClass="mandatory"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="PADDING-RIGHT: 15px; WIDTH: 380px; HEIGHT: 29px" align="right" width="380"></TD>
								<TD class="tdSmallHeader" style="HEIGHT: 29px" align="center" width="15%" colSpan="2">
									<asp:dropdownlist id="ddl_B31" tabIndex="5" runat="server" CssClass="mandatory">
										<asp:ListItem Value="-">-Pilih-</asp:ListItem>
										<asp:ListItem Value="Audited">Audited</asp:ListItem>
										<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD class="tdSmallHeader" style="HEIGHT: 29px" align="center" width="15%" colSpan="2">
									<asp:dropdownlist id="ddl_C31" tabIndex="29" runat="server" CssClass="mandatory">
										<asp:ListItem Value="-">-Pilih-</asp:ListItem>
										<asp:ListItem Value="Audited">Audited</asp:ListItem>
										<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD class="tdSmallHeader" style="HEIGHT: 29px" align="center" width="15%" colSpan="2">
									<asp:dropdownlist id="ddl_D31" runat="server" Visible="False">
										<asp:ListItem Value="-">-Pilih-</asp:ListItem>
										<asp:ListItem Value="Audited">Audited</asp:ListItem>
										<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<tr>
								<td class="TblAlternating" style="PADDING-LEFT: 10px; HEIGHT: 26px" align="left" width="40%"
									colSpan="7"><STRONG><STRONG>&nbsp;1. Pendapatan Operasional</STRONG></STRONG></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 24px" align="left" width="380">&nbsp;1.1. 
									Pendapatan bunga dari bank</td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B32" onblur="FormatCurrency(this);hit_labarugi(1,'B');hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="6" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C32" onblur="FormatCurrency(this);hit_labarugi(1,'C');hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="30" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D32" onblur="FormatCurrency(this);hit_labarugi(1,'D');hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="53" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380"><NOBR>&nbsp;1.2. 
										Pendapatan bunga dari pihak III bukan bank</NOBR></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B33" onblur="FormatCurrency(this);hit_labarugi(1,'B');hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C33" onblur="FormatCurrency(this);hit_labarugi(1,'C');hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="31" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D33" onblur="FormatCurrency(this);hit_labarugi(1,'D');hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 23px" align="left" width="380">
									<P>&nbsp;1.3. Provisi dan komisi</P>
								</td>
								<td align="center" width="20%" colSpan="2" style="HEIGHT: 23px"><asp:textbox onkeypress="return numbersonly()" id="txt_B34" onblur="FormatCurrency(this);hit_labarugi(1,'B');hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2" style="HEIGHT: 23px"><asp:textbox onkeypress="return numbersonly()" id="txt_C34" onblur="FormatCurrency(this);hit_labarugi(1,'C');hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="32" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2" style="HEIGHT: 23px"><asp:textbox onkeypress="return numbersonly()" id="txt_D34" onblur="FormatCurrency(this);hit_labarugi(1,'D');hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="55" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="right" width="380"><STRONG><EM>Total 
											Pendapatan operasional</EM></STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B35" onblur="FormatCurrency(this);hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C35" onblur="FormatCurrency(this);hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D35" onblur="FormatCurrency(this);hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<TR>
								<TD style="PADDING-LEFT: 10px; HEIGHT: 27px" align="left" width="40%" colSpan="7"><STRONG>&nbsp;2. 
										Beban Operasional</STRONG></TD>
							</TR>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;2.1. 
									Biaya Bunga Kepada bank Indonesia</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B36" onblur="FormatCurrency(this);hit_labarugi(2,'B');hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="9" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C36" onblur="FormatCurrency(this);hit_labarugi(2,'C');hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D36" onblur="FormatCurrency(this);hit_labarugi(2,'D');hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="56" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;2.2. 
									Biaya bunga kepada bank lain</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B37" onblur="FormatCurrency(this);hit_labarugi(2,'B');hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="10" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C37" onblur="FormatCurrency(this);hit_labarugi(2,'C');hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D37" onblur="FormatCurrency(this);hit_labarugi(2,'D');hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="57" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;2.3. 
									Biaya bunga kepada pihak III bukan bank</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B38" onblur="FormatCurrency(this);hit_labarugi(2,'B');hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="11" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C38" onblur="FormatCurrency(this);hit_labarugi(2,'C');hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="35" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D38" onblur="FormatCurrency(this);hit_labarugi(2,'D');hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="58" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 23px" align="right" width="380"><STRONG><EM>Total 
											Beban Operasional</EM></STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B39" onblur="FormatCurrency(this);hit_labarugi(3,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C39" onblur="FormatCurrency(this);hit_labarugi(3,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D39" onblur="FormatCurrency(this);hit_labarugi(3,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="right" width="380"><STRONG><EM>Pendapatan 
											Operasional Bersih</EM></STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B40" onblur="FormatCurrency(this);hit_labarugi(7,'B');hit_labarugi(8,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C40" onblur="FormatCurrency(this);hit_labarugi(7,'C');hit_labarugi(8,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D40" onblur="FormatCurrency(this);hit_labarugi(7,'D');hit_labarugi(8,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px; HEIGHT: 27px" align="left" width="40%"
									colSpan="7"><STRONG>&nbsp;3. Pendapatan Operasional Lainnya</STRONG></TD>
							</TR>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380"><NOBR>&nbsp;3.1. 
										Provisi dan komisi diterima bukan dari kredit</NOBR></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B41" onblur="FormatCurrency(this);hit_labarugi(4,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C41" onblur="FormatCurrency(this);hit_labarugi(4,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="36" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D41" onblur="FormatCurrency(this);hit_labarugi(4,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;3.2. 
									Pendapatan karena transaksi valas</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B42" onblur="FormatCurrency(this);hit_labarugi(4,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="13" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C42" onblur="FormatCurrency(this);hit_labarugi(4,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="37" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D42" onblur="FormatCurrency(this);hit_labarugi(4,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;3.3. 
									Lain-lain</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B43" onblur="FormatCurrency(this);hit_labarugi(4,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="14" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C43" onblur="FormatCurrency(this);hit_labarugi(4,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D43" onblur="FormatCurrency(this);hit_labarugi(4,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="right" width="380"><EM><STRONG>Total 
											Pendapatan Operasional Lainnya</STRONG></EM></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B44" onblur="FormatCurrency(this);hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C44" onblur="FormatCurrency(this);hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D44" onblur="FormatCurrency(this);hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<TR>
								<TD style="PADDING-LEFT: 10px; WIDTH: 656px; HEIGHT: 21px" align="left" width="656"
									colSpan="7"><STRONG>&nbsp;4. Biaya Operasional Lainnya</STRONG></TD>
							</TR>
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;4.1. 
									Biaya Umum dan Administrasi</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B45" onblur="FormatCurrency(this);hit_labarugi(5,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="15" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C45" onblur="FormatCurrency(this);hit_labarugi(5,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="39" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D45" onblur="FormatCurrency(this);hit_labarugi(5,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="62" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 25 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;4.2. 
									Biaya Tenaga kerja</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B46" onblur="FormatCurrency(this);hit_labarugi(5,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C46" onblur="FormatCurrency(this);hit_labarugi(5,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="40" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D46" onblur="FormatCurrency(this);hit_labarugi(5,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 26 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;4.3. 
									Biaya Pemeliharaan dan perbaikan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B47" onblur="FormatCurrency(this);hit_labarugi(5,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C47" onblur="FormatCurrency(this);hit_labarugi(5,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="41" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D47" onblur="FormatCurrency(this);hit_labarugi(5,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="64" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<!--  START baris 27 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;4.4. 
									Biaya Penyusutan/Penghapusan Aktiva Produksi</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B48" onblur="FormatCurrency(this);hit_labarugi(5,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C48" onblur="FormatCurrency(this);hit_labarugi(5,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D48" onblur="FormatCurrency(this);hit_labarugi(5,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="65" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;4.5. 
									Depresiasi dan amortisasi</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B49" onblur="FormatCurrency(this);hit_labarugi(5,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="19" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C49" onblur="FormatCurrency(this);hit_labarugi(5,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="43" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D49" onblur="FormatCurrency(this);hit_labarugi(5,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;4.6. 
									Lain-lain</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B50" onblur="FormatCurrency(this);hit_labarugi(5,'B');hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C50" onblur="FormatCurrency(this);hit_labarugi(5,'C');hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="44" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D50" onblur="FormatCurrency(this);hit_labarugi(5,'D');hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="67" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 23px" align="right" width="380"><STRONG><EM>Total 
											Biaya Operasional Lainnya</EM></STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B51" onblur="FormatCurrency(this);hit_labarugi(6,'B');hit_labarugi(7,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C51" onblur="FormatCurrency(this);hit_labarugi(6,'C');hit_labarugi(7,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D51" onblur="FormatCurrency(this);hit_labarugi(6,'D');hit_labarugi(7,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 23px" align="right" width="380"><STRONG><EM><STRONG>Pendapatan 
												Operasional Lainnya Bersih</STRONG></EM></STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B52" onblur="FormatCurrency(this);hit_labarugi(7,'B');hit_labarugi(8,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C52" onblur="FormatCurrency(this);hit_labarugi(7,'C');hit_labarugi(8,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D52" onblur="FormatCurrency(this);hit_labarugi(7,'D');hit_labarugi(8,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td class="TDBGColor" style="PADDING-LEFT: 10px; WIDTH: 380px" align="right" width="380"><STRONG><EM>Laba 
											Operasional</EM></STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B53" onblur="FormatCurrency(this);hit_labarugi(8,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C53" onblur="FormatCurrency(this);hit_labarugi(8,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D53" onblur="FormatCurrency(this);hit_labarugi(8,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<TR>
								<TD style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;5. 
									Non-operating Revenue and Expenses - Net</TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B54" onblur="FormatCurrency(this);hit_labarugi(8,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C54" onblur="FormatCurrency(this);hit_labarugi(8,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="45" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D54" onblur="FormatCurrency(this);hit_labarugi(8,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="68" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR class="TblAlternating">
								<TD style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 20px" align="left" width="380"><STRONG>&nbsp;6. 
										Income before Income Tax</STRONG></TD>
								<TD style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B55" onblur="FormatCurrency(this);hit_labarugi(9,'B');hit_labarugi(10,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								<TD style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C55" onblur="FormatCurrency(this);hit_labarugi(9,'C');hit_labarugi(10,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								<TD style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D55" onblur="FormatCurrency(this);hit_labarugi(9,'D');hit_labarugi(10,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 22px" align="left" width="380">&nbsp;7. 
									Income Tax</TD>
								<TD style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B56" onblur="FormatCurrency(this);hit_labarugi(9,'B');hit_labarugi(10,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="22" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C56" onblur="FormatCurrency(this);hit_labarugi(9,'C');hit_labarugi(10,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="46" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D56" onblur="FormatCurrency(this);hit_labarugi(9,'D');hit_labarugi(10,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="69" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR class="TblAlternating">
								<TD style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;<STRONG>8. 
										Net Income</STRONG></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B57" onblur="FormatCurrency(this);hit_labarugi(10,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C57" onblur="FormatCurrency(this);hit_labarugi(10,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D57" onblur="FormatCurrency(this);hit_labarugi(10,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" Font-Bold="True" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="PADDING-LEFT: 10px; WIDTH: 380px" align="left" width="380">&nbsp;9. 
									Balance at beginning</TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B58" onblur="FormatCurrency(this);hit_labarugi(10,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="23" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C58" onblur="FormatCurrency(this);hit_labarugi(10,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="47" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D58" onblur="FormatCurrency(this);hit_labarugi(10,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="70" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR class="TblAlternating">
								<TD style="PADDING-LEFT: 10px; WIDTH: 380px; HEIGHT: 18px" align="left" width="380">10. 
									Deviden</TD>
								<TD style="HEIGHT: 18px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B59" onblur="FormatCurrency(this);hit_labarugi(10,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="24" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD style="HEIGHT: 18px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C59" onblur="FormatCurrency(this);hit_labarugi(10,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="48" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
								<TD style="HEIGHT: 18px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D59" onblur="FormatCurrency(this);hit_labarugi(10,'D');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server" Width="100%" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12"></asp:textbox></TD>
							</TR>
							<TR class="TDBGColor">
								<TD style="PADDING-LEFT: 10px; WIDTH: 380px" align="right" width="380"><STRONG>TOTAL 
										RETAINED EARNING AT THE END OF YEAR</STRONG></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_B60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" Font-Bold="True" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_C60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" Font-Bold="True" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
								<TD align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="txt_D60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" Font-Bold="True" onblur="FormatCurrency(this)" onfocus="RestoreCurrency(this)" onchange="EnsureNumber(this)"
										MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
							</TR>
						</table>
					</td>
				</TR>
			</TABLE></TD></TR>
			<table width="100%">
				<tr>
					<td class="tdBGColor2" align="center">
						<asp:Label id="LBL_H_TAHUN" runat="server" Visible="False"></asp:Label><asp:button id="btn_Save" runat="server" Width="100px" Text=" Save " CssClass="Button1" onclick="btn_Save_Click"></asp:button>&nbsp;</td>
				</tr>
			</table></TD></TR></TABLE></TR></TABLE></TR></TABLE></form>
	</body>
</HTML>
