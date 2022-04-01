<%@ Page language="c#" Codebehind="Neraca_KMK_KI_Medium.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.Neraca_KMK_KI_Medium_new" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Neraca_KMK_KI_Medium</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../include/Neraca-IS-javascript.html" -->
		<!-- #include file = "../include/onepost.html" -->
		<script language="javascript">
	function uploadInProgress() {
		if (document.getElementById('TXT_FILE_UPLOAD').value == "") 
		{
			alert("File Upload tidak boleh kosong!");
			return false;
		}
		
		if (processing) {
			alert("Upload is in progress. Please wait ...");
			return false;
		}
		else
			return true;
	}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table6">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
												Neraca</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="MainCreditAnalysis.aspx?"></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
						</TR>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR>
							<TD class="tdNoBorder" vAlign="top" align="center" colSpan="2"><table width="100%">
									<TR>
										<TD class="tdHeader1" vAlign="top" colSpan="3">Neraca
										</TD>
									</TR>
									<tr>
										<td class="tdHeader1" width="30%">History</td>
										<td class="tdHeader1" width="30%">Inisialisasi</td>
										<td class="tdHeader1" width="40%">Current</td>
									</tr>
									<tr>
										<td class="td" vAlign="top" width="30%"><ASP:DATAGRID id="DG_NeracaHistory" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
														<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BS_DATE_PERIODE" HeaderText="Year">
														<HeaderStyle HorizontalAlign="Center" Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BS_NUM_MONTH" HeaderText="Periode Laporan">
														<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BS_REPORTTYPE" HeaderText="Jenis Laporan">
														<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="tahun"></asp:BoundColumn>
													<asp:ButtonColumn Text="Retrieve" CommandName="retrieve_history">
														<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:ButtonColumn>
												</Columns>
											</ASP:DATAGRID></td>
										<td class="td" vAlign="top" width="30%">
											<table width="100%">
												<tr>
													<td class="tdSmallHeader" width="40%" colSpan="2">Inisialisasi</td>
												</tr>
												<tr>
													<td class="TDBGColor1" width="20%">Currency&nbsp;:</td>
													<td class="TDBGColorValue" width="20%"><asp:dropdownlist id="DDL_CURRENCY" runat="server"></asp:dropdownlist></td>
												</tr>
												<TR>
													<TD class="TDBGColor1" width="20%">Denominator&nbsp; :</TD>
													<TD class="TDBGColorValue" width="20%"><asp:dropdownlist id="DDL_DENOMINATOR" runat="server">
															<asp:ListItem>- SELECT -</asp:ListItem>
															<asp:ListItem Value="000">Ribuan (000)</asp:ListItem>
															<asp:ListItem Value="000000">Jutaan (000000)</asp:ListItem>
														</asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="20%"></TD>
													<TD class="TDBGColorValue" width="20%"><asp:label id="LbL_FLAG_INISIALISASI" runat="server" Visible="False">Label</asp:label></TD>
												</TR>
												<TR>
													<TD align="center" width="40%" colSpan="2"><asp:button id="BTN_CEK" runat="server" Width="100px" CssClass="Button1" Text=" Save " onclick="BTN_CEK_Click"></asp:button></TD>
												</TR>
											</table>
										</td>
										<td class="td" vAlign="top" width="40%"><ASP:DATAGRID id="DG_Neraca1" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn DataField="BS_DATE_PERIODE" HeaderText="Year">
														<HeaderStyle HorizontalAlign="Center" Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BS_NUM_MONTH" HeaderText="Periode Laporan">
														<HeaderStyle HorizontalAlign="Center" Width="22%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BS_REPORTTYPE" HeaderText="Jenis Laporan">
														<HeaderStyle HorizontalAlign="Center" Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="tahun"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="bs_date_periode" HeaderText="tgl"></asp:BoundColumn>
													<asp:BoundColumn DataField="BS_CURRENCY" HeaderText="Currency">
														<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BS_DENOMINATOR" HeaderText="Denominator">
														<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:ButtonColumn Text="Retrieve" CommandName="retrieve"></asp:ButtonColumn>
													<asp:ButtonColumn Text="Delete" CommandName="delete"></asp:ButtonColumn>
												</Columns>
											</ASP:DATAGRID></td>
									</tr>
								</table>
							</TD>
						</TR>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- 
						<TR>
							<TD align="center" colSpan="2">
								<table width="100%">
									<TBODY>
										<tr>
											<td class="tdBGColor2" align="center"><asp:button id="BTN_DEL" runat="server" Width="100px" CssClass="Button1" Text="Delete"></asp:button>&nbsp;
												<asp:button id="BTN_RTRV" runat="server" Width="100px" CssClass="Button1" Text="Retrieve"></asp:button>&nbsp;
											</td>
										</tr>
									</TBODY>
								</table>
							</TD>
						</TR>
						-->
						<!-- diremark dulu tgl 21 sept 2004 ------
						<TR>
							<td class="tdNoBorder" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td width="60%">Nasabah menyerahkan laporan keuangan dua periode</td>
										<td width="20%"><asp:radiobutton id="RBTN_LAPKEU1" runat="server"></asp:radiobutton></td>
										<td width="20%"><asp:radiobutton id="RadioButton2" runat="server"></asp:radiobutton></td>
									</tr>
								</table>
							</td>
						</TR>
						------------------------------------------------------------------------------------------------------------------------------------------->
						<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------><asp:panel id="PnlNeraca" runat="server" Visible="False">
							<TR>
								<td class="td" align="center" colSpan="2">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="tdSmallHeader" align="center" width="24%" rowSpan="2">Pos-pos neraca</td>
											<td class="tdSmallHeader" align="center" width="76%" colSpan="12">Neraca Per</td>
										</tr>
										<tr>
											<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-2/bln</td>
											<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-1/bln</td>
											<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n/bln</td>
											<td class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun Proyeksi/bln</td>
										</tr>
										<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br0">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Date 
												Periode</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_B1" tabIndex="1" runat="server" Columns="4"
													MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_B1" tabIndex="2" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_B1" tabIndex="3" runat="server" Columns="4"
													MaxLength="4"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_C1" tabIndex="38" runat="server" Columns="4"
													MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_C1" tabIndex="39" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_C1" tabIndex="40" runat="server"
													Columns="4" MaxLength="4"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_D1" tabIndex="75" runat="server" Columns="4"
													MaxLength="2" CssClass="mandatory2"></asp:textbox><asp:dropdownlist id="DDL_BLN_D1" tabIndex="76" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_D1" tabIndex="77" runat="server"
													Columns="4" MaxLength="4" CssClass="mandatory2"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_E1" tabIndex="115" runat="server"
													Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_E1" tabIndex="116" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_E1" tabIndex="117" runat="server"
													Columns="4" MaxLength="4"></asp:textbox></td>
										</tr>
										<tr id="br1">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Number 
												of Months</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B2" style="TEXT-ALIGN: center" tabIndex="4"
													runat="server" Width="50%" MaxLength="2"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C2" style="TEXT-ALIGN: center" tabIndex="41"
													runat="server" Width="50%" MaxLength="2"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D2" style="TEXT-ALIGN: center" tabIndex="81"
													runat="server" Width="50%" MaxLength="2" CssClass="mandatory2"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E2" style="TEXT-ALIGN: center" tabIndex="118"
													runat="server" Width="50%" MaxLength="2"></asp:textbox></td>
										</tr>
										<!--  START baris 2 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<TR>
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Report 
												Type</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_B3" tabIndex="5" runat="server">
													<asp:ListItem Value="-">-Pilih-</asp:ListItem>
													<asp:ListItem Value="Audited">Audited</asp:ListItem>
													<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
												</asp:dropdownlist></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_C3" tabIndex="42" runat="server">
													<asp:ListItem Value="-">-Pilih-</asp:ListItem>
													<asp:ListItem Value="Audited">Audited</asp:ListItem>
													<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
												</asp:dropdownlist></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_D3" tabIndex="82" runat="server" CssClass="mandatory2">
													<asp:ListItem Value="-">-Pilih-</asp:ListItem>
													<asp:ListItem Value="Audited">Audited</asp:ListItem>
													<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
												</asp:dropdownlist></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_E3" tabIndex="119" runat="server" Visible="False">
													<asp:ListItem Value="-">-Pilih-</asp:ListItem>
													<asp:ListItem Value="Audited">Audited</asp:ListItem>
													<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
												</asp:dropdownlist></td>
										</TR>
										<TR>
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Sales 
												On Credit %</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B4" style="TEXT-ALIGN: center" tabIndex="6"
													runat="server" Width="50%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C4" style="TEXT-ALIGN: center" tabIndex="43"
													runat="server" Width="50%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D4" style="TEXT-ALIGN: center" tabIndex="83"
													runat="server" Width="50%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E4" style="TEXT-ALIGN: center" tabIndex="120"
													runat="server" Width="50%"></asp:textbox></td>
										</TR>
										<tr id="br2">
											<td class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="24%" colSpan="13"><STRONG>&nbsp;&nbsp;&nbsp;ASSETS</STRONG></td>
										</tr>
										<!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br3">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Cash 
												&amp; Bank</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="44" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="121" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br4">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Marketable 
												Securities</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="45" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="85" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="122" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br5">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
												Receivable</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="9" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="46" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="86" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="123" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br6">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
												Receivable fr Affiliated</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="10" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="47" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="87" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="124" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br7">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Inventory</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="11" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="48" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="125" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br8">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Other 
												Current Assets</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="49" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="89" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="126" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br9">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Prepaid 
												Expenses</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="13" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="50" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="90" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="127" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br10">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>Current 
													Assets</STRONG></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="14" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="51" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="91" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="128" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 11 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br11">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Net 
												Fixed Assets</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="15" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="52" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="92" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="129" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br12">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Investments</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="53" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="93" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="130" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br13">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Net 
												Other Non Current Assets</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="94" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="131" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br14">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Net 
												Intangibles</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="55" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="95" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="132" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 15 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br15">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>Total 
													Non Current Assets</STRONG></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="19" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="56" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="96" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="133" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 16 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br16">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>TOTAL 
													ASSETS</STRONG></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="20" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="57" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="97" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="134" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 20 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<!--  START baris 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<TR>
											<TD class="TDBGColor" style="PADDING-RIGHT: 40px" align="left" width="100%" colSpan="13"><STRONG>&nbsp;&nbsp;&nbsp;LIABILITIES 
													+ EQUITY</STRONG></TD>
										</TR>
										<tr id="br21">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Due 
												Banks, Short Term</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="58" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="98" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="135" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br22">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
												Payable</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'), FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="22" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'), FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'), FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="99" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'), FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="136" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br23">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
												Payable to Affiliated</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="23" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="100" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="137" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br24">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accruals</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="24" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="101" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="138" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 25 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br25">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Taxes 
												Payable</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="25" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="62" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="102" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="139" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 26 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br26">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Other 
												Current Liabilities</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="26" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="103" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="140" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 27 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br27">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Current 
												Portion L T Debt</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="27" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="64" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="104" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="141" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 28 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br28">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>Current 
													Liabilities</STRONG></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="28" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="65" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="105" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="142" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 29 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br29">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Long 
												Term Debt</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B27" onblur="FormatCurrency_noDec(this),  HitungNeracaMiddle(5,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="29" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C27" onblur="FormatCurrency_noDec(this),  HitungNeracaMiddle(5,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D27" onblur="FormatCurrency_noDec(this),  HitungNeracaMiddle(5,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="106" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E27" onblur="FormatCurrency_noDec(this),  HitungNeracaMiddle(5,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="143" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 30 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br30">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Other 
												Liab, Long Term</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="30" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="67" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="107" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="144" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 31 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br31">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>Long 
													Term Liabilities</STRONG></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="31" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="68" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="108" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="145" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 32 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br32">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>Total 
													Liabilities</STRONG></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="32" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="69" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="109" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="146" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 33 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br33">
											<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Common 
												Stock</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="70" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="110" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="147" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<!--  START baris 34 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
										<tr id="br34">
											<td class="TDBGColor1" style="PADDING-LEFT: 10px; HEIGHT: 9px" align="left" width="24%">Surplus 
												&amp; Reserves</td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="111" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="148" runat="server" Width="100%"></asp:textbox></td>
										</tr>
										<TR>
											<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Retained 
												Earnings</TD>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'B'),  FormatCurrency_noDec(document.getElementById('TXT_B12')),FormatCurrency_noDec(document.getElementById('TXT_B17')),FormatCurrency_noDec(document.getElementById('TXT_B18')),FormatCurrency_noDec(document.getElementById('TXT_B26')),FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="35" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'C'),  FormatCurrency_noDec(document.getElementById('TXT_C12')),FormatCurrency_noDec(document.getElementById('TXT_C17')),FormatCurrency_noDec(document.getElementById('TXT_C18')),FormatCurrency_noDec(document.getElementById('TXT_C26')),FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="72" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D12')),FormatCurrency_noDec(document.getElementById('TXT_D17')),FormatCurrency_noDec(document.getElementById('TXT_D18')),FormatCurrency_noDec(document.getElementById('TXT_D26')),FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="112" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E12')),FormatCurrency_noDec(document.getElementById('TXT_E17')),FormatCurrency_noDec(document.getElementById('TXT_E18')),FormatCurrency_noDec(document.getElementById('TXT_E26')),FormatCurrency_noDec(document.getElementById('TXT_E29')),FormatCurrency_noDec(document.getElementById('TXT_E30')), FormatCurrency_noDec(document.getElementById('TXT_E34')),FormatCurrency_noDec(document.getElementById('TXT_E35'))"
													style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="149" runat="server" Width="100%"></asp:textbox></td>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>Total 
													Net Worth</STRONG></TD>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="36" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="73" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="113" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="150" runat="server" Width="100%"></asp:textbox></td>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%"><STRONG>&nbsp;&nbsp;&nbsp;LIABILITIES 
													+ NET WORTH</STRONG></TD>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="37" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="74" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="114" runat="server" Width="100%"></asp:textbox></td>
											<TD width="1%">&nbsp;</TD>
											<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
													tabIndex="151" runat="server" Width="100%"></asp:textbox></td>
										</TR>
									</table>
									<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%% END SEPARATOR UTK ISI NERACA %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% -----------------------------------------------------></td>
							</TR>
							<!-- ************************* separator *************--------->
							<TR>
								<TD vAlign="top" align="center" colSpan="2">
									<table width="100%">
										<tr>
											<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp; 
												<!-- <asp:button id="BTN_PROSES" runat="server" Width="150px" CssClass="Button1" Text="Proses / Calculate"></asp:button>&nbsp; -->
												<asp:button id="BTN_CLEAR" runat="server" Width="100px" CssClass="Button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button>
												<asp:Label id="LBL_H_TAHUN" runat="server"></asp:Label></td>
										</tr>
									</table>
								</TD>
							</TR>
							<!-- ************************* separator *************--------->
							<TR>
								<TD class="tdHeader1" width="100%" colSpan="2">Documents</TD>
							</TR>
							<TR>
								<TD vAlign="top" width="50%">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td><asp:datagrid id="DG_XLS" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn DataField="cnt" HeaderText="No">
															<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="XLS_VIEW" HeaderText="Source File">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Location" HeaderText="Location"></asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="HP_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></td>
										</tr>
									</table>
								</TD>
								<TD vAlign="top" width="50%" rowSpan="2">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD><ASP:DATAGRID id="DatGrid" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="No.">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FU_FILENAME" HeaderText="Destination File">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
															<ItemTemplate>
																<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="FU_USERID"></asp:BoundColumn>
													</Columns>
												</ASP:DATAGRID></TD>
										</TR>
									</table>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" width="50%">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" width="75">File</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" runat="Server"></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Status</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
													ControlToValidate="TXT_FILE_UPLOAD" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$"></asp:regularexpressionvalidator></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1"></TD>
											<TD></TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 21px" align="center" colSpan="3">
												<asp:Label id="LBL_SUMBERDATA" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3"></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
													proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
													download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
										</TR>
									</table>
								</TD>
							</TR>
						<!-- separator --------------></TBODY></TABLE>
				</TD></TR></asp:panel> 
				<!-- separator utk teksbox keperluan simpan ke tabel labarugi ----------------------><TR style="DISPLAY: none">
					<TD class="tdNoBorder" colSpan="2" align="center" vAlign="top">
						<table width="100%">
							<TBODY>
								<tr>
									<td class="tdNoBorder" align="left"><asp:textbox id="TXT_LBRG_B37" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B38" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B39" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B40" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B41" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B42" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B43" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B44" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B45" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B46" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B47" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B48" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B49" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B50" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B51" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B52" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B53" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B54" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B55" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B56" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B57" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B58" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B59" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B60" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_B61" runat="server" Visible="False"></asp:textbox></td>
									<!-- SEPARATOR ---->
									<td class="tdNoBorder" align="left"><asp:textbox id="TXT_LBRG_C37" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C38" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C39" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C40" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C41" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C42" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C43" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C44" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C45" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C46" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C47" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C48" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C49" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C50" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C51" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C52" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C53" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C54" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C55" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C56" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C57" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C58" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C59" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C60" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_C61" runat="server" Visible="False"></asp:textbox></td>
									<!-- SEPARATOR ---->
									<td class="tdNoBorder" align="left"><asp:textbox id="TXT_LBRG_D37" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D38" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D39" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D40" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D41" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D42" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D43" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D44" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D45" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D46" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D47" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D48" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D49" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D50" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D51" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D52" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D53" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D54" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D55" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D56" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D57" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D58" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D59" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D60" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_D61" runat="server" Visible="False"></asp:textbox></td>
									<!-- SEPARATOR ---->
									<td class="tdNoBorder" align="left"><asp:textbox id="TXT_LBRG_E37" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E38" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E39" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E40" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E41" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E42" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E43" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E44" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E45" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E46" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E47" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E48" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E49" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E50" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E51" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E52" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E53" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E54" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E55" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E56" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E57" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E58" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E59" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E60" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_LBRG_E61" runat="server" Visible="False"></asp:textbox></td>
								</tr>
							</TBODY>
						</table>
					</TD>
				</TR>
				<!-- separator utk teksbox hidden ----><TR style="DISPLAY: none">
					<td>
						<table>
							<tr>
								<td><asp:textbox id="TXT_B1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_E1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_B3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_E3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</TR>
				</TBODY></TABLE></center>
		</form>
	</body>
</HTML>
