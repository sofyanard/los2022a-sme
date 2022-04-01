<%@ Page language="c#" Codebehind="bprLabaRugi.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.bprLabaRugi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>NPL BPR</title>
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
										Laba Rugi</B></TD>
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
					<TD class="tdHeader1" vAlign="top" colSpan="2">Laba Rugi&nbsp;(Rp. 000,-)</TD>
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
								<td vAlign="top" width="50%"><ASP:DATAGRID id="DG_LRHistory" runat="server" AllowPaging="True" Width="100%" CellPadding="1"
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
											<asp:BoundColumn Visible="False" DataField="POSISI_TGL" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
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
								<TD align="center" width="50%"><ASP:DATAGRID id="dg_LR" runat="server" AllowPaging="True" Width="100%" CellPadding="1" PageSize="5"
										AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="319">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
												<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="POSISI_TGL_YEAR" HeaderText="Year" DataFormatString="{0:yyyy-MM-dd}">
												<HeaderStyle HorizontalAlign="Center" Width="35%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="POSISI_TGL"></asp:BoundColumn>
											<asp:BoundColumn DataField="JML_BLN" HeaderText="Periode Laporan">
												<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" CommandName="retrieve">
												<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="Delete" CommandName="delete">
												<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
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
								<td class="tdSmallHeader" align="center" width="60%" colSpan="6">Laba Rugi</td>
							</tr>
							<tr>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n</td>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n+1</td>
								<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Pertumbuhan</td>
							</tr>
							<tr>
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px; HEIGHT: 31px" align="right" width="401"><STRONG>Posisi 
										Tanggal</STRONG></td>
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
										Bulan</STRONG></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_JML_BLN1" tabIndex="1" runat="server"
											Width="100px" CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"><nobr><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_JML_BLN2" tabIndex="1" runat="server"
											Width="100px" CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox></nobr></td>
								<td class="tdSmallHeader" style="HEIGHT: 31px" align="center" width="15%" colSpan="2"></td>
							</tr>
							<tr>
								<td class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>PENDAPATAN 
										OPERASIONAL</STRONG></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 24px" align="left" width="401">&nbsp;1. 
									Pendapatan Bunga Dari Bank</td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_BANK1"
										onblur="FormatCurrency(this);hit_neraca(1,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="6" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_BANK2"
										onblur="FormatCurrency(this);hit_neraca(1,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="32" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_BANK3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="57" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
									Pendapatan Bunga dari pihak-3 bukan bank</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK1"
										onblur="FormatCurrency(this);hit_neraca(1,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="7"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK2"
										onblur="FormatCurrency(this);hit_neraca(1,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="33"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PO_PENDAPATAN_BUNGA_DARI_PIHAK_KE3_BUKAN_BANK3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="58" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. 
									Provisi dan Komisi</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_PROVISI_DAN_KOMISI1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_PROVISI_DAN_KOMISI2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PO_PROVISI_DAN_KOMISI3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="59" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px; HEIGHT: 23px" align="right" width="401"><STRONG>TOTAL 
										PENDAPATAN_OPERASIONAL</STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_TOTAL1" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PO_TOTAL2" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" MaxLength="12" onchange="EnsureNumber(this)"
										BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PO_TOTAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--  separator ----------------------------------------------------->
							<!--  START baris 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>BIAYA 
										OPERASIONAL</STRONG></TD>
							</TR>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;1. 
									Biaya Bunga&nbsp;kepada Bank Indonesia</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BI1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BI2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BI3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="66" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;2. 
									Biaya Bunga&nbsp;kepada Bank Lain</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_BANK_LAIN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="66" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. 
									Biaya Bunga&nbsp;kepada pihak ke-3 bukan Bank</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="16"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="42"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BO_BIAYA_BUNGA_KEPADA_PIHAK_KE3_BUKAN_BANK3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="67" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>TOTAL <STRONG>
											BIAYA OPERASIONAL</STRONG></STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_TOTAL_BIAYA_OPERASIONAL1"
										onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%"
										MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BO_TOTAL_BIAYA_OPERASIONAL2"
										onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%"
										MaxLength="12" onchange="EnsureNumber(this)" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BO_TOTAL_BIAYA_OPERASIONAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>PENDAPATAN 
										OPERASIONAL (BERSIH)</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BO_PENDAPATAN_OPERASIONAL_BERSIH3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!-------------------------------------------------------------------->
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>PENDAPATAN 
										OPERASIONAL LAINNYA</STRONG></TD>
							</TR>
							<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;1. 
									Provisi dan Komisi diterima bukan dari kredit</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_POL_PROVISI_DAN_KOMISI_DITERIMA_BUKAN_DARI_KREDIT3"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42" runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. Lain 
									- Lain</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_POL_LAIN21" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="16" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_POL_LAIN22" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="42" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_POL_LAIN23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42"
										runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>TOTAL 
										PENDAPATAN OPERASIONAL LAINNYA</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_POL_TOTAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_POL_TOTAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_POL_TOTAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!-------------------------------------------------------------------->
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>BIAYA&nbsp;OPERASIONAL 
										LAINNYA</STRONG></TD>
							</TR>
							<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;1. 
									Biaya Umum dan Administrasi</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_BIAYA_UMUM_DAN_ADMINISTRASI3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="42" runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
									Biaya Tenaga Kerja</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_TENAGA_KERJA1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="16" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_TENAGA_KERJA2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="42" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_BIAYA_TENAGA_KERJA3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="42" runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;3. 
									Biaya Pemeliharaan dan Perbaikan</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_BIAYA_PEMELIHARAAN_DAN_PERBAIKAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="42" runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;4. 
									Biaya Penyusutan&nbsp;/ Penghapusan Aktiva Produktif</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="16"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="42"
										runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_BIAYA_PENYUSUTAN_PENGHAPUSAN_AKTIVA_PRODUKTIF3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="42" runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;5. 
									Depresiasi dan Amortisasi</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_DEPRESIASI_DAN_AMORTISASI1"
										onblur="FormatCurrency(this);hit_neraca(2,'B');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_DEPRESIASI_DAN_AMORTISASI2"
										onblur="FormatCurrency(this);hit_neraca(2,'C');" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server"
										Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_DEPRESIASI_DAN_AMORTISASI3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="42" runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;6. Lain 
									- Lain</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_LAIN21" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="16" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_BOL_LAIN22" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="42" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_LAIN23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="42"
										runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>TOTAL 
										BIAYA OPERASIONAL LAINNYA</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_TOTAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_TOTAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_BOL_TOTAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>PENDAPATAN 
										OPERASIONAL LAINNYA (BERSIH)</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_POL_TOTAL_NET1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_POL_TOTAL_NET2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_POL_TOTAL_NET3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>LABA 
										OPERASIONAL</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_LABA_OPERASIONAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_LABA_OPERASIONAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_LABA_OPERASIONAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!-------------------------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>PENDAPATAN 
										DAN BIAYA NON OPERASIONAL (BERSIH)</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET1"
										onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET2"
										onblur="FormatCurrency(this)" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%"
										CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PENDAPATAN_DAN_BIAYA_NON_OPERASIONAL_NET3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>PENDAPATAN 
										SEBELUM PAJAK (E B I T)</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="#E0E0E0" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PENDAPATAN_SEBELUM_PAJAK_EBIT3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>PAJAK 
										PENGHASILAN</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PAJAK_PENGHASILAN1" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_PAJAK_PENGHASILAN2" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PAJAK_PENGHASILAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>PENDAPATAN 
										BERSIH (EAT)</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PENDAPATAN_BERSIH_EAT1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PENDAPATAN_BERSIH_EAT2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_PENDAPATAN_BERSIH_EAT3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>SALDO KAS 
										AWAL</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_SALDO_KAS_AWAL1" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_SALDO_KAS_AWAL2" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_SALDO_KAS_AWAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 16px" align="left" width="401"><STRONG>DEVIDEN</STRONG></td>
								<td style="HEIGHT: 16px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_DIVIDEN1" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"
										Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 16px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_LRL_DIVIDEN2" onblur="FormatCurrency(this)"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" runat="server" Width="100%" CssClass="mandatory" MaxLength="12" onchange="EnsureNumber(this)"
										Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 16px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_DIVIDEN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-RIGHT: 15px; WIDTH: 401px" align="right" width="401"><STRONG>LABA 
										DITAHAN PADA AKHIR TAHUN</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_LRL_LABA_DITAHAN_PADA_AKHIR_TAHUN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE></TD></TR>
			<table style="WIDTH: 100%; HEIGHT: 36px">
				<tr>
					<td class="tdBGColor2" style="WIDTH: 100%" align="center">
						<asp:label id="LBL_H_TAHUN" runat="server" Visible="False"></asp:label>
						<asp:label id="LBL_H_SEQ" runat="server" Visible="False"></asp:label>
						<asp:button id="btn_Save" runat="server" Width="100px" DESIGNTIMEDRAGDROP="2557" CssClass="Button1"
							Text=" Save " onclick="btn_Save_Click"></asp:button>&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
			</table></TD></TR></TABLE></TD></TR></TABLE></TR></TABLE></TR></TABLE> 
			<!--############################################################################### --></form>
	</body>
</HTML>
