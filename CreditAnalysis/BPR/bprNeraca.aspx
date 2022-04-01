<%@ Page language="c#" Codebehind="bprNeraca.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.bprNeraca" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Neraca BPR</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_mandatory.html" -->
		<!-- #include file="../../include/cek_entries.html" -->
		<!-- #include file="../../include/popup.html" -->
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 805px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table6">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
										Neraca</B>
								</TD>
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
					<TD class="tdHeader1" vAlign="top" colSpan="2">NERACA (Rp.000,-)
					</TD>
				</TR>
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
				<TR>
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
											<asp:BoundColumn DataField="POSISI_TGL_YEAR" HeaderText="Year" DataFormatString="{0:yyyy-MM-dd}">
												<HeaderStyle HorizontalAlign="Center" Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="POSISI_TGL"></asp:BoundColumn>
											<asp:BoundColumn DataField="JML_BLN" HeaderText="Periode Laporan">
												<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" CommandName="retrieve_history">
												<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="" PrevPageText="" Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<TD align="center" width="50%"><ASP:DATAGRID id="dg_Neraca" runat="server" AllowPaging="True" Width="100%" CellPadding="1" PageSize="5"
										AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="319">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
												<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="POSISI_TGL_YEAR" HeaderText="Year" DataFormatString="{0:yyyy-MM-dd}">
												<HeaderStyle HorizontalAlign="Center" Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="POSISI_TGL"></asp:BoundColumn>
											<asp:BoundColumn DataField="JML_BLN" HeaderText="Periode Laporan">
												<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" CommandName="retrieve">
												<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="Delete" CommandName="delete">
												<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<td align="center" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="1">
							<tr>
								<td class="tdSmallHeader" style="WIDTH: 401px" align="center" width="401" rowSpan="2">URAIAN</td>
								<td class="tdSmallHeader" align="center" width="60%" colSpan="6">NERACA</td>
							</tr>
							<tr>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n</td>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n+1</td>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Pertumbuhan</td>
							</tr>
							<tr>
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px; HEIGHT: 31px" align="right" width="401"><STRONG>Posisi 
										Tanggal</STRONG>
								</td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return signeddigitsonly()" id="txt_DD_B1" tabIndex="1" runat="server"
											Width="22px" CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="ddl_MM_B1" tabIndex="2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return signeddigitsonly()" id="txt_YY_B1" tabIndex="3" runat="server"
											CssClass="mandatory" MaxLength="4" Columns="4"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return signeddigitsonly()" id="txt_DD_B2" tabIndex="27" runat="server"
											Width="22px" CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="ddl_MM_B2" tabIndex="28" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return signeddigitsonly()" id="txt_YY_B2" tabIndex="29" runat="server"
											CssClass="mandatory" MaxLength="4" Columns="4"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2">%</td>
							</tr>
							<tr>
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px; HEIGHT: 31px" align="right" width="401"><STRONG>Jumlah 
										Bulan</STRONG>
								</td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_JML_BLN1" tabIndex="1" runat="server"
											Width="100px" CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_JML_BLN2" tabIndex="1" runat="server"
											Width="100px" CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"></td>
							</tr>
							<tr>
								<td class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>AKTIVA</STRONG>
								</td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 24px" align="left" width="401">&nbsp;1. 
									Kas</td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_KAS1" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="6" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_KAS2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="32" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_KAS3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="57" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2.Sertifikat 
									Bank Indonesia</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_SBI1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="7" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_SBI2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="33" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_SBI3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="58" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3.Antar 
									Bank Aktiva</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 50px; WIDTH: 401px" align="left" width="401">&nbsp;3.1.Giro</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_GIRO1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_GIRO2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_GIRO3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 50px; WIDTH: 401px" align="left" width="401">&nbsp;3.2.Tabungan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_TABUNGAN1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_TABUNGAN2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_TABUNGAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 50px; WIDTH: 401px" align="left" width="401">&nbsp;3.3.Lainnya</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_LAINNYA1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_LAINNYA2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_BANK_AKTIVA_LAINNYA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;4.Kredit 
									yang Diberikan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_KREDIT_YANG_DIBERIKAN1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="9" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_KREDIT_YANG_DIBERIKAN2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="35" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_KREDIT_YANG_DIBERIKAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="60" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;5.Penyisihan 
									Penghapusan Aktiva Produktif</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_PPAP1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="10" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_PPAP2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="36" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_PPAP3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="61" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;6.Aktiva 
									Tetap dan Inventaris</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_AKTIVA_TETAP_DAN_INVENTARIS1"
										onblur="FormatCurrency(this);hit_neraca(1,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="12"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_AKTIVA_TETAP_DAN_INVENTARIS2"
										onblur="FormatCurrency(this);hit_neraca(1,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="38"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_AKTIVA_TETAP_DAN_INVENTARIS3"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;7.Antar 
									Kantor Aktiva</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_KANTOR_AKTIVA1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="13" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_ANTAR_KANTOR_AKTIVA2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="39" runat="server" Width="100%" MaxLength="12" CssClass="mandatory"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_AKTV_ANTAR_KANTOR_AKTIVA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="64" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;8.Rupa-rupa 
									Aktiva</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_RUPA2_AKTVIVA1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="13" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_RUPA2_AKTVIVA2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_RUPA2_AKTVIVA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="69" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401"><STRONG>TOTAL 
										AKTIVA</STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_TOTAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_TOTAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTV_TOTAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--  separator ----------------------------------------------------->
							<!--  START baris 20 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<!--  START baris 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>LIABILITIES</STRONG></TD>
							</TR>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;1. 
									Kewajiban2 yang Segera Dibayar</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_KEWAJIBAN_YANG_SEGERA_DAPAT_DIBAYAR1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="14"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_KEWAJIBAN_YANG_SEGERA_DAPAT_DIBAYAR2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="40"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_KEWAJIBAN_YANG_SEGERA_DAPAT_DIBAYAR3"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="65" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;2. 
									Tabungan</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_TABUNGAN1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_TABUNGAN2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_TABUNGAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="66" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3.Deposito 
									Berjangka</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_DEPOSITO_BERJANGKA1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="16" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_DEPOSITO_BERJANGKA2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="42" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_DEPOSITO_BERJANGKA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="67" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;4.Bank 
									Indonesia (KMK)</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_BI_KMK1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="17" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_BI_KMK2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="43" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_BI_KMK3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="68" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 25 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;5.Antar 
									Bank Pasiva</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 50px; WIDTH: 401px" align="left" width="401">&nbsp;5.1.Pinjaman</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_PINJAMAN1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_PINJAMAN2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_PINJAMAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 50px; WIDTH: 401px" align="left" width="401">&nbsp;5.2.Deposito 
									&gt; 3 Bulan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_LEBIH_3BULAN1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_LEBIH_3BULAN2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_LEBIH_3BULAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 50px; WIDTH: 401px" align="left" width="401">&nbsp;5.3.Deposito 
									s.d 3 Bulan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_SD_3BULAN1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_SD_3BULAN2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_DEPOSITO_SD_3BULAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 50px; WIDTH: 401px" align="left" width="401">&nbsp;5.4.Tabungan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_TABUNGAN1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_TABUNGAN2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_BANK_PASSIVA_TABUNGAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 26 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;6.Pinjaman 
									Subordinasi</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_PINJAMAN_SUBORDINASI1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="19" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_PINJAMAN_SUBORDINASI2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="45" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_PINJAMAN_SUBORDINASI3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="70" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 27 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;7.Pinjaman 
									Lainnya (&gt;3 Bulan)</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_PINJAMAN_LAINNYA_LB3BULAN1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="20" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_PINJAMAN_LAINNYA_LB3BULAN2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="46" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_PINJAMAN_LAINNYA_LB3BULAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="71" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 22px" align="left" width="401">&nbsp;8. 
									Antar Kantor Pasiva</td>
								<td style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_KANTOR_PASSIVA1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="21" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_KANTOR_PASSIVA2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="47" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 22px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_ANTAR_KANTOR_PASSIVA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="72" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;9. 
									Rupa-Rupa Pasiva</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_RUPA2_PASIVA1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="22" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_RUPA2_PASIVA2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="48" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_PSV_RUPA2_PASIVA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="73"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">10. Modal 
									Disetor (Modal Dasar Belum Disetor)</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_MODAL_DISETOR1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="23" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_MODAL_DISETOR2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="49" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_PSV_MODAL_DISETOR3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="74"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">11. Modal 
									Pinjaman/Sumbangan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_MODAL_PINJAMAN_SUMBANGAN1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="24" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_MODAL_PINJAMAN_SUMBANGAN2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="50" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_MODAL_PINJAMAN_SUMBANGAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="75" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr class="TblAlternating">
								<td class="TblAlternating" style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 20px" align="left"
									width="401">12. Cadangan</td>
								<td style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_CADANGAN1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="25" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_CADANGAN2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="51" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 20px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_CADANGAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="76" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">13. Laba 
									Ditahan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_LABA_DITAHAN1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="26" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_LABA_DITAHAN2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="52" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_LABA_DITAHAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="77" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">14. Laba 
									Tahun Berjalan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_LABA_THN_BERJALAN1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="26" runat="server" Width="100%" MaxLength="12"
										CssClass="mandatory" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_LABA_THN_BERJALAN2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="52" runat="server" Width="100%" MaxLength="12"
										CssClass="mandatory" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_LABA_THN_BERJALAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="77" runat="server" Width="100%" MaxLength="12" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>TOTAL 
										PASSIVA</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_TOTAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_TOTAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_PSV_TOTAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" ReadOnly="True" BackColor="Gainsboro" Font-Bold="True"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE></TD></TR>
			<table style="WIDTH: 100%; HEIGHT: 36px">
				<tr>
					<td class="tdBGColor2" style="WIDTH: 100%" align="center"><asp:label id="LBL_H_TAHUN" runat="server" Visible="False"></asp:label><asp:label id="LBL_H_SEQ" runat="server" Visible="False"></asp:label><asp:button id="btn_Save" runat="server" Width="100px" DESIGNTIMEDRAGDROP="2557" CssClass="Button1"
							Text=" Save " onclick="btn_Save_Click"></asp:button>&nbsp;&nbsp;&nbsp;
						<asp:button id="btnCalculateRatio" runat="server" Width="128px" DESIGNTIMEDRAGDROP="2557" CssClass="Button1"
							Text="Calculate Ratio" onclick="btnCalculateRatio_Click"></asp:button></td>
				</tr>
			</table></TD></TR></TABLE></TD></TR></TABLE></TR></TABLE></TR></TABLE></form>
	</body>
</HTML>
