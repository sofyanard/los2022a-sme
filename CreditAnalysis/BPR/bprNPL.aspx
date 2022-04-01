<%@ Page language="c#" Codebehind="bprNPL.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.bprNPL" %>
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
										NPL</B></TD>
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
					<TD class="tdHeader1" vAlign="top" colSpan="2">NPL&nbsp;(Rp. 000,-)</TD>
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
								<td vAlign="top" width="50%"><ASP:DATAGRID id="DG_NPLHistory" runat="server" AllowPaging="True" Width="100%" CellPadding="1"
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
											<asp:ButtonColumn Text="Retrieve" CommandName="retrieve_history">
												<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle NextPageText="" PrevPageText="" Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<TD align="center" width="50%"><ASP:DATAGRID id="dg_NPL" runat="server" AllowPaging="True" Width="100%" CellPadding="1" PageSize="5"
										AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="319">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
												<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="POSISI_TGL_YEAR" HeaderText="Year" DataFormatString="{0:yyyy-MM-dd}">
												<HeaderStyle HorizontalAlign="Center" Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="POSISI_TGL" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" CommandName="retrieve">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:ButtonColumn>
											<asp:ButtonColumn Text="Delete" CommandName="delete">
												<HeaderStyle Width="1%"></HeaderStyle>
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
								<td class="tdSmallHeader" align="center" width="60%" colSpan="6">NPL</td>
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
								<td class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>AKTIVA 
										PRODUKTIF YANG DIHASILKAN</STRONG></td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 24px" align="left" width="401">&nbsp;1. 
									Lancar</td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_LANCAR1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="6" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_LANCAR2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="32" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 24px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_APYD_LANCAR3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="57"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;2. 
									Kurang Lancar</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_KURANG_LANCAR1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="7" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_KURANG_LANCAR2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="33" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_APYD_KURANG_LANCAR3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="58"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. 
									Diragukan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_DIRAGUKAN1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="8" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_DIRAGUKAN2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="34" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_APYD_DIRAGUKAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;4. 
									Macet</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_MACET1" onblur="FormatCurrency(this);hit_neraca(1,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="9" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_MACET2" onblur="FormatCurrency(this);hit_neraca(1,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="35" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_APYD_MACET3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401"><STRONG>TOTAL 
										AKTIVA PRODUKTIF</STRONG></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_TOTAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_TOTAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_APYD_TOTAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!--  separator ----------------------------------------------------->
							<!--  START baris 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<TR>
								<TD class="TblAlternating" style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><STRONG>PENYISIHAN 
										PENGHAPUSAN <STRONG>AKTIVA PRODUKTIF</STRONG></STRONG></TD>
							</TR>
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;1. 
									Lancar</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_LANCAR1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_LANCAR2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_PPAP_LANCAR3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px; HEIGHT: 23px" align="left" width="401">&nbsp;2. 
									Kurang Lancar</td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_KURANG_LANCAR1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="15" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_KURANG_LANCAR2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="41" runat="server" Width="100%" CssClass="mandatory" MaxLength="12"
										onchange="EnsureNumber(this)"></asp:textbox></td>
								<td style="HEIGHT: 23px" align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_PPAP_KURANG_LANCAR3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr>
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;3. 
									Diragukan</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_DIRAGUKAN1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="16" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_DIRAGUKAN2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="42" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_PPAP_DIRAGUKAN3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="67"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
							<tr class="TblAlternating">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401">&nbsp;4. 
									Macet</td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_MACET1" onblur="FormatCurrency(this);hit_neraca(2,'B');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="17" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_MACET2" onblur="FormatCurrency(this);hit_neraca(2,'C');"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" onfocus="RestoreCurrency(this)" tabIndex="43" runat="server" Width="100%" CssClass="mandatory"
										MaxLength="12" onchange="EnsureNumber(this)"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_MACET3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										tabIndex="68" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>TOTAL 
										PPAP</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_PPAP_TOTAL1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_PPAP_TOTAL2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_NPL_PPAP_TOTAL3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server"
										Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<!-------------------------------------------------------------------->
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>PPAP YANG 
										SEHARUSNYA DIBENTUK</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_PPAP_YG_SEHARUSNYA_DIBENTUK3"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>KELEBIHAN 
										(KEKURANGAN) PEMBENTUKAN PPAP</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NPL_KELEBIHAN_KEKURANGAN_PEMBENTUKAN_PPAP3"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>AKTIVA 
										PRODUKTIF YANG DIKLASIFIKASIKAN</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN1"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN2"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_AKTIVA_PRODUKTIF_YANG_DIKLASIFIKASIKAN3"
										style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
							<tr class="TDBGColor">
								<td style="PADDING-LEFT: 10px; WIDTH: 401px" align="left" width="401"><STRONG>PENYISIHAN 
										PENGHAPUSAN AKTIVA PRODUKTIF</STRONG></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF1" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF2" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
								<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_PENYISIHAN_PENGHAPUSAN_AKTIVA_PRODUKTIF3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
										runat="server" Width="100%" MaxLength="12" BackColor="Gainsboro" ReadOnly="True" Font-Bold="True"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE>
			</TD></TR>
			<table style="WIDTH: 100%">
				<tr>
					<td class="tdBGColor2" style="WIDTH: 100%" align="center"><asp:label id="LBL_H_TAHUN" runat="server" Visible="False"></asp:label><asp:label id="LBL_H_SEQ" runat="server" Visible="False"></asp:label><asp:button id="btn_Save" runat="server" Width="100px" DESIGNTIMEDRAGDROP="2557" CssClass="Button1"
							Text=" Save " onclick="btn_Save_Click"></asp:button>&nbsp;&nbsp;&nbsp;
					</td>
				</tr>
			</table>
			</TD></TR></TABLE></TD></TR></TABLE></TR></TABLE></TR></TABLE> 
			<!--############################################################################### --></form>
	</body>
</HTML>
