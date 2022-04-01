<%@ Page language="c#" Codebehind="BackUpSnapShot.aspx.cs" AutoEventWireup="false" Inherits="SME.AccountPlanning.BackUpSnapShot.BackUpSnapShot" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ClientSnapShot</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table width="100%" border="0">
					<tr>
						<td align="left" width="50%">
							<table id="Table1">
								<tr>
									<td class="tdBGColor2" style="WIDTH: 400px" align="center"><b>Client Snapshot</b></td>
								</tr>
							</table>
						</td>
						<td class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">KEY FINANCIAL</td>
					</tr>
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
									<td class="tdHeader1" width="30%">Account Plan Data</td>
									<td class="tdHeader1" width="30%">Inisialisasi</td>
									<td class="tdHeader1" width="40%">IPS Data</td>
								</tr>
								<tr>
									<td class="td" vAlign="top" width="30%"><ASP:DATAGRID id="DG_NeracaHistory" runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
											Width="100%">
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
												<TD align="center" width="40%" colSpan="2"><asp:button id="BTN_CEK" runat="server" Width="100px" Text=" Save " CssClass="Button1"></asp:button></TD>
											</TR>
										</table>
									</td>
									<td class="td" vAlign="top" width="40%"><ASP:DATAGRID id="DG_Neraca1" runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
											Width="100%">
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
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_B1" tabIndex="1" runat="server" CssClass="mandatory2"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_B1" tabIndex="2" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_B1" tabIndex="3" runat="server" CssClass="mandatory2"
												MaxLength="4" Columns="4"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_C1" tabIndex="38" runat="server" CssClass="mandatory2"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_C1" tabIndex="39" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_C1" tabIndex="40" runat="server"
												CssClass="mandatory2" MaxLength="4" Columns="4"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_D1" tabIndex="75" runat="server" CssClass="mandatory2"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_D1" tabIndex="76" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_D1" tabIndex="77" runat="server"
												CssClass="mandatory2" MaxLength="4" Columns="4"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_E1" tabIndex="115" runat="server"
												CssClass="mandatory2" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_E1" tabIndex="116" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_E1" tabIndex="117" runat="server"
												CssClass="mandatory2" MaxLength="4" Columns="4"></asp:textbox></td>
									</tr>
									<tr id="br1">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Number 
											of Months</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B2" style="TEXT-ALIGN: center" tabIndex="4"
												runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C2" style="TEXT-ALIGN: center" tabIndex="41"
												runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D2" style="TEXT-ALIGN: center" tabIndex="81"
												runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E2" style="TEXT-ALIGN: center" tabIndex="118"
												runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></td>
									</tr>
									<!--  START baris 2 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR>
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Report 
											Type</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_B3" tabIndex="5" runat="server" CssClass="mandatory2">
												<asp:ListItem Value="-">-Pilih-</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:dropdownlist id="DDL_C3" tabIndex="42" runat="server" CssClass="mandatory2">
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
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="44" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E5" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="121" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br4">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Marketable 
											Securities</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="45" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="85" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E6" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="122" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br5">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
											Receivable</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="9" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="46" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="86" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E7" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(3,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="123" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br6">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
											Receivable fr Affiliated</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="10" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="47" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="87" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E8" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="124" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br7">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Inventory</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="11" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="48" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E9" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="125" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br8">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Other 
											Current Assets</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="49" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="89" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E10" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="126" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br9">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Prepaid 
											Expenses</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="13" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="50" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="90" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E11" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(1,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
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
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="15" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="52" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="92" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E13" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="129" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br12">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Investments</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="53" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="93" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E14" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="130" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br13">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Net 
											Other Non Current Assets</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'), FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="94" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E15" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="131" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br14">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Net 
											Intangibles</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="55" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="95" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E16" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(2,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
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
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="21" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="58" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="98" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E19" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="135" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br22">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
											Payable</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'), FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="22" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'), FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'), FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="99" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E20" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'), FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="136" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br23">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accounts 
											Payable to Affiliated</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="23" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="100" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E21" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="137" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br24">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Accruals</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="24" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="101" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E22" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="138" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 25 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br25">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Taxes 
											Payable</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="25" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="62" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="102" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E23" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="139" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 26 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br26">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Other 
											Current Liabilities</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="26" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="103" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E24" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="140" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 27 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br27">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Current 
											Portion L T Debt</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="27" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="64" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="104" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E25" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(4,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
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
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B27" onblur="FormatCurrency_noDec(this),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="29" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C27" onblur="FormatCurrency_noDec(this),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D27" onblur="FormatCurrency_noDec(this),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="106" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E27" onblur="FormatCurrency_noDec(this),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="143" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 30 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br30">
										<td class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Other 
											Liab, Long Term</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="30" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="67" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="107" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E28" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(5,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
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
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="70" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="110" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E31" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="147" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 34 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br34">
										<td class="TDBGColor1" style="PADDING-LEFT: 10px; HEIGHT: 9px" align="left" width="24%">Surplus 
											&amp; Reserves</td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="111" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E32" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="148" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<TR>
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="left" width="24%">Retained 
											Earnings</TD>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'B'),  FormatCurrency_noDec(document.Form1.TXT_B12),FormatCurrency_noDec(document.Form1.TXT_B17),FormatCurrency_noDec(document.Form1.TXT_B18),FormatCurrency_noDec(document.Form1.TXT_B26),FormatCurrency_noDec(document.Form1.TXT_B29),FormatCurrency_noDec(document.Form1.TXT_B30), FormatCurrency_noDec(document.Form1.TXT_B34),FormatCurrency_noDec(document.Form1.TXT_B35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="35" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'C'),  FormatCurrency_noDec(document.Form1.TXT_C12),FormatCurrency_noDec(document.Form1.TXT_C17),FormatCurrency_noDec(document.Form1.TXT_C18),FormatCurrency_noDec(document.Form1.TXT_C26),FormatCurrency_noDec(document.Form1.TXT_C29),FormatCurrency_noDec(document.Form1.TXT_C30), FormatCurrency_noDec(document.Form1.TXT_C34),FormatCurrency_noDec(document.Form1.TXT_C35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="72" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'D'),  FormatCurrency_noDec(document.Form1.TXT_D12),FormatCurrency_noDec(document.Form1.TXT_D17),FormatCurrency_noDec(document.Form1.TXT_D18),FormatCurrency_noDec(document.Form1.TXT_D26),FormatCurrency_noDec(document.Form1.TXT_D29),FormatCurrency_noDec(document.Form1.TXT_D30), FormatCurrency_noDec(document.Form1.TXT_D34),FormatCurrency_noDec(document.Form1.TXT_D35)"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="112" runat="server" Width="100%"></asp:textbox></td>
										<TD width="1%">&nbsp;</TD>
										<td class="TDBGColorValue" align="center" width="18%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_E33" onblur="FormatCurrency_noDec(this), HitungNeracaMiddle(7,'E'),  FormatCurrency_noDec(document.Form1.TXT_E12),FormatCurrency_noDec(document.Form1.TXT_E17),FormatCurrency_noDec(document.Form1.TXT_E18),FormatCurrency_noDec(document.Form1.TXT_E26),FormatCurrency_noDec(document.Form1.TXT_E29),FormatCurrency_noDec(document.Form1.TXT_E30), FormatCurrency_noDec(document.Form1.TXT_E34),FormatCurrency_noDec(document.Form1.TXT_E35)"
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
									<!-- separator utk textbox hidden ---->
									<TR style="DISPLAY: none">
										<td>
											<table>
												<tr>
													<td><asp:textbox id="TXT_B1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_E1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_B3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_E3" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
												</tr>
											</table>
										</td>
									</TR>
								</table>
								<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%% END SEPARATOR UTK ISI NERACA %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% -----------------------------------------------------></td>
						</TR>
						<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% SEPARATOR UNTUK KOMPONEN LABA RUGI %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% --------------------------------------------------------->
						<tr>
							<td vAlign="top" align="center" colSpan="2">
								<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
									<TBODY>
										<TR>
											<TD vAlign="top" colSpan="2">
												<table width="100%">
													<TR>
														<TD class="tdHeader1" vAlign="top" colSpan="3">Laba Rugi&nbsp;(Rp.000,-)</TD>
													</TR>
													<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
													<tr>
														<td class="tdHeader1" width="30%">Account Plan</td>
														<td class="tdHeader1" width="30%">Inisialisasi</td>
														<td class="tdHeader1" width="40%">IPS Data</td>
													</tr>
													<TR>
														<td class="td" vAlign="top" width="30%"><ASP:DATAGRID id="DG_LRHistory" runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
																Width="100%">
																<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																<Columns>
																	<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
																		<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="IS_DATE_PERIODE" HeaderText="Year">
																		<HeaderStyle HorizontalAlign="Center" Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="IS_NUM_MONTH" HeaderText="Periode Laporan">
																		<HeaderStyle HorizontalAlign="Center" Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="IS_REPORTTYPE" HeaderText="Jenis Laporan">
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
																	<td class="TDBGColorValue" width="20%"><asp:dropdownlist id="Dropdownlist1" runat="server"></asp:dropdownlist></td>
																</tr>
																<TR>
																	<TD class="TDBGColor1" width="20%">Denominator&nbsp; :</TD>
																	<TD class="TDBGColorValue" width="20%"><asp:dropdownlist id="Dropdownlist2" runat="server">
																			<asp:ListItem>- SELECT -</asp:ListItem>
																			<asp:ListItem Value="000">Ribuan (000)</asp:ListItem>
																			<asp:ListItem Value="000000">Jutaan (000000)</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD class="TDBGColor1" width="20%"></TD>
																	<TD class="TDBGColorValue" width="20%"><asp:label id="Label7" runat="server" Visible="False">Label</asp:label></TD>
																</TR>
																<TR>
																	<TD align="center" width="40%" colSpan="2"><asp:button id="Button1" runat="server" Width="100px" Text=" Save " CssClass="Button1"></asp:button></TD>
																</TR>
															</table>
														</td>
														<TD class="td" vAlign="top" align="center" width="40%"><asp:datagrid id="DB_LBRG1" runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
																Width="100%">
																<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																<Columns>
																	<asp:BoundColumn DataField="IS_DATE_PERIODE" HeaderText="Year">
																		<HeaderStyle HorizontalAlign="Center" Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="IS_NUM_MONTH" HeaderText="Periode Laporan">
																		<HeaderStyle HorizontalAlign="Center" Width="22%" CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="IS_REPORTTYPE" HeaderText="Jenis Laporan">
																		<HeaderStyle HorizontalAlign="Center" Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="tahun" HeaderText="tahun"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="IS_DATE_PERIODE" HeaderText="TGL"></asp:BoundColumn>
																	<asp:ButtonColumn Text="Retrieve" CommandName="retrieve"></asp:ButtonColumn>
																</Columns>
															</asp:datagrid></TD>
													</TR>
												</table>
											</TD>
										</TR>
										<!-- separator ------------------------------------------------------------------------------------------------------------------------------------------><asp:panel id="Panel1" runat="server" Visible="False">
											<TR>
												<TD class="td" align="center" colSpan="2">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="tdSmallHeader" align="center" width="24%" rowSpan="2">Pos-pos laba rugi</TD>
															<TD class="tdSmallHeader" align="center" width="76%" colSpan="13">Laba 
																Rugi&nbsp;Per</TD>
														</TR>
														<TR>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-2/bln</TD>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n-1/bln</TD>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun ke n/bln</TD>
															<TD class="tdSmallHeader" align="center" width="19%" colSpan="3">Tahun Proyeksi/bln</TD>
														</TR> <!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br1">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Date/Number 
																of Months</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_B37" tabIndex="1" runat="server" CssClass="mandatory2"
																	Columns="4" MaxLength="2"></asp:textbox>
																<asp:dropdownlist id="DDL_BLN_B37" tabIndex="2" runat="server" CssClass="mandatory2"></asp:dropdownlist>
																<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_B37" tabIndex="3" runat="server"
																	CssClass="mandatory2" Columns="4" MaxLength="4"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_C37" tabIndex="28" runat="server"
																	CssClass="mandatory2" Columns="4" MaxLength="2"></asp:textbox>
																<asp:dropdownlist id="DDL_BLN_C37" tabIndex="29" runat="server" CssClass="mandatory2"></asp:dropdownlist>
																<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_C37" tabIndex="30" runat="server"
																	CssClass="mandatory2" Columns="4" MaxLength="4"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_D37" tabIndex="55" runat="server"
																	CssClass="mandatory2" Columns="4" MaxLength="2"></asp:textbox>
																<asp:dropdownlist id="DDL_BLN_D37" tabIndex="56" runat="server" CssClass="mandatory2"></asp:dropdownlist>
																<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_D37" tabIndex="57" runat="server"
																	CssClass="mandatory2" Columns="4" MaxLength="4"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_E37" tabIndex="82" runat="server"
																	CssClass="mandatory2" Columns="4" MaxLength="2"></asp:textbox>
																<asp:dropdownlist id="DDL_BLN_E37" tabIndex="83" runat="server" CssClass="mandatory2"></asp:dropdownlist>
																<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_E37" tabIndex="84" runat="server"
																	CssClass="mandatory2" Columns="4" MaxLength="4"></asp:textbox></TD>
														</TR> <!--  START baris 2 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR>
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Number 
																Of Month</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B38" style="TEXT-ALIGN: center" tabIndex="4"
																	runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C38" style="TEXT-ALIGN: center" tabIndex="31"
																	runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D38" style="TEXT-ALIGN: center" tabIndex="58"
																	runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E38" style="TEXT-ALIGN: center" tabIndex="85"
																	runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px; HEIGHT: 3px" align="right" width="24%">Report 
																Type</TD>
															<TD style="HEIGHT: 3px" width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" style="HEIGHT: 3px" align="center" width="18%" colSpan="2">
																<asp:dropdownlist id="DDL_B39" tabIndex="5" runat="server" CssClass="mandatory2">
																	<asp:ListItem Value="-">- Pilih -</asp:ListItem>
																	<asp:ListItem Value="Audited">Audited</asp:ListItem>
																	<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD style="HEIGHT: 3px" width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" style="HEIGHT: 3px" align="center" width="18%" colSpan="2">
																<asp:dropdownlist id="DDL_C39" tabIndex="32" runat="server" CssClass="mandatory2">
																	<asp:ListItem Value="-">- Pilih -</asp:ListItem>
																	<asp:ListItem Value="Audited">Audited</asp:ListItem>
																	<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD style="HEIGHT: 3px" width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" style="HEIGHT: 3px" align="center" width="18%" colSpan="2">
																<asp:dropdownlist id="DDL_D39" tabIndex="59" runat="server" CssClass="mandatory2">
																	<asp:ListItem Value="-">- Pilih -</asp:ListItem>
																	<asp:ListItem Value="Audited">Audited</asp:ListItem>
																	<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
																</asp:dropdownlist></TD>
															<TD style="HEIGHT: 3px" width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" style="HEIGHT: 3px" align="center" width="18%" colSpan="2">
																<asp:dropdownlist id="DDL_E39" tabIndex="86" runat="server" Visible="False">
																	<asp:ListItem Value="-">- Pilih -</asp:ListItem>
																	<asp:ListItem Value="Audited">Audited</asp:ListItem>
																	<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
																</asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Sales 
																On Credit %</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B40" style="TEXT-ALIGN: center" tabIndex="6"
																	runat="server" Width="50%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C40" style="TEXT-ALIGN: center" tabIndex="33"
																	runat="server" Width="50%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D40" style="TEXT-ALIGN: center" tabIndex="60"
																	runat="server" Width="50%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E40" style="TEXT-ALIGN: center" tabIndex="87"
																	runat="server" Width="50%"></asp:textbox></TD>
														</TR> <!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br3"> <!-- Net Sales -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Net 
																Sales</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br4"> <!-- Cost Of Goods Sales -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Cost 
																Of Goods Sales</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 5 SEPARATOR UTK ISI laba rugi ----------------------------------------------------->
														<TR> <!-- % Sale  Row 16 -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
																Sales</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="9" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="36" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="63" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="90" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR id="br6"> <!-- Hitung -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Gross 
																Margin</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="10" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="37" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="64" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="91" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR> <!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR> <!-- '% of Sales	 Gross Margin	Row 18	  -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
																Sales</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="11" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="38" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="65" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="92" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR id="br8">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Selling, 
																Gen, Admin Exp</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR> <!-- '% of Sales, Row 20	 -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
																Sales</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="13" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="40" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="67" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="94" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR id="br10"> <!-- 'Operating Earnings				21					-->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Operating 
																Earnings</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="14" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="41" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="68" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="95" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR> <!-- '% of Sales Row 22 -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
																Sales</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="15" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="42" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="69" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="96" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR id="br12">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Depreciation 
																(Fixed Assets)</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br13">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Amortization 
																1 (Other Non C Ass)</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br14">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Amortization 
																2 (Intangibles)</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 15 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br15">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Other 
																Income (Charges) - Net</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  START baris 16 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br16">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Extraordinary 
																Items</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR> <!--  separator ----------------------------------------------------->
														<TR id="br21"> <!-- 'Earnings Before Interest & Taxes 27					55   =  48 - 50-51-52 +53 -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Earnings 
																Before Interest &amp; Taxes</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="21" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="48" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="75" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="102" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR> <!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
														<TR id="br22">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Interest 
																Expense</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR>
														<TR id="br23"> <!-- 'Earnings Before Taxes			  29					57   = 55 - 56  -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Earnings 
																Before Taxes</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="23" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="50" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="77" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="104" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR> <!--	'% of Sales		Row 31							58   =  57/41	 -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
																Sales</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="24" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="51" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="78" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="105" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR id="br25">
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Income 
																Taxes</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.Form1.TXT_B43), FormatCurrency_noDec(document.Form1.TXT_B44), FormatCurrency_noDec(document.Form1.TXT_B45), FormatCurrency_noDec(document.Form1.TXT_B47), FormatCurrency_noDec(document.Form1.TXT_B48), FormatCurrency_noDec(document.Form1.TXT_B49), FormatCurrency_noDec(document.Form1.TXT_B55), FormatCurrency_noDec(document.Form1.TXT_B57), FormatCurrency_noDec(document.Form1.TXT_B58), FormatCurrency_noDec(document.Form1.TXT_B60), FormatCurrency_noDec(document.Form1.TXT_B61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.Form1.TXT_C43), FormatCurrency_noDec(document.Form1.TXT_C44), FormatCurrency_noDec(document.Form1.TXT_C45), FormatCurrency_noDec(document.Form1.TXT_C47), FormatCurrency_noDec(document.Form1.TXT_C48), FormatCurrency_noDec(document.Form1.TXT_C49), FormatCurrency_noDec(document.Form1.TXT_C55), FormatCurrency_noDec(document.Form1.TXT_C57), FormatCurrency_noDec(document.Form1.TXT_C58), FormatCurrency_noDec(document.Form1.TXT_C60), FormatCurrency_noDec(document.Form1.TXT_C61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.Form1.TXT_D43), FormatCurrency_noDec(document.Form1.TXT_D44), FormatCurrency_noDec(document.Form1.TXT_D45), FormatCurrency_noDec(document.Form1.TXT_D47), FormatCurrency_noDec(document.Form1.TXT_D48), FormatCurrency_noDec(document.Form1.TXT_D49), FormatCurrency_noDec(document.Form1.TXT_D55), FormatCurrency_noDec(document.Form1.TXT_D57), FormatCurrency_noDec(document.Form1.TXT_D58), FormatCurrency_noDec(document.Form1.TXT_D60), FormatCurrency_noDec(document.Form1.TXT_D61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.Form1.TXT_E43), FormatCurrency_noDec(document.Form1.TXT_E44), FormatCurrency_noDec(document.Form1.TXT_E45), FormatCurrency_noDec(document.Form1.TXT_E47), FormatCurrency_noDec(document.Form1.TXT_E48), FormatCurrency_noDec(document.Form1.TXT_E49), FormatCurrency_noDec(document.Form1.TXT_E55), FormatCurrency_noDec(document.Form1.TXT_E57), FormatCurrency_noDec(document.Form1.TXT_E58), FormatCurrency_noDec(document.Form1.TXT_E60), FormatCurrency_noDec(document.Form1.TXT_E61)"
																	style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
														</TR>
														<TR id="br26"> <!-- 'Net Income												60  =  57 - 59 + 54  -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Net 
																Income</TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="26" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="53" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="80" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%">&nbsp;</TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="107" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
														<TR> <!-- '% of Sales												61   60/41   -->
															<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
																Sales</TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_B61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="27" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_C61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="54" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_D61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="81" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
															<TD width="1%"></TD>
															<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
																<asp:textbox onkeypress="return numbersonly()" id="TXT_E61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
																	tabIndex="108" runat="server" Width="100%" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="tdBGColor2" align="center" colSpan="2">
													<asp:button id="BTN_SIMPAN" runat="server" Width="120px" CssClass="BUTTON1" Text="Save"></asp:button>&nbsp;&nbsp; 
													<!-- <asp:button id="BTNPROSES" runat="server" Width="150px" CssClass="BUTTON1" Text="Proses / Calculate"></asp:button>&nbsp;&nbsp; -->
													<asp:button id="BTNCLEAR" runat="server" Width="120px" CssClass="BUTTON1" Text="Clear"></asp:button>
													<asp:Label id="Label8" runat="server"></asp:Label></TD>
											</TR>
										</asp:panel>
									</TBODY>
								</TABLE>
								<table style="DISPLAY: none">
									<tr>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_B37" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_C37" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_D37" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_E37" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
									</tr>
									<tr>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_B39" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_C39" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_D39" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
										<td align="center" width="10%" colSpan="2"><asp:textbox id="TXT_E39" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
									</tr>
								</table>
							</td>
						</tr>
						<!-- %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% END SEPARATOR UMTUK KOMPONEN LABA RUGI %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% --------------------------------------------------------->
						<!-- ************************* separator *************--------->
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td class="tdBGColor2" align="center"><asp:label id="LBL_H_TAHUN" runat="server"></asp:label><asp:label id="Label1" runat="server"></asp:label></td>
									</tr>
								</table>
							</TD>
						</TR>
						<tr>
							<td class="tdHeader1" colSpan="2">BUSINESS AND STRATEGY</td>
						</tr>
						<TR>
							<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="LBL_TXT_SCENARIO" runat="server">Description of business :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_DESCRIPTION_OF_BUSINESS" runat="server" Width="100%" CssClass="Mandatory"
												Height="98px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="Label2" runat="server">Client's strategy and priorities :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CLIENTS_STRATEGY_AND_PRIORITIES" runat="server" Width="100%" CssClass="Mandatory"
												Height="98px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="Label3" runat="server">Recent developments :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_RECENT_DEVELOPMENTS" runat="server" Width="100%" CssClass="Mandatory" Height="98px"
												TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="20%"><asp:label id="Label4" runat="server">Implications for Bank Pundi :</asp:label></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_IMPLICATIONS_FOR_MANDIRI" runat="server" Width="100%" CssClass="Mandatory"
												Height="98px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE_BUSINESS_AND_STRATEGY" runat="server" Width="100px" Text=" Save " CssClass="Button1"></asp:button></td>
									</tr>
								</table>
							</TD>
						</TR>
						<tr>
							<td class="tdHeader1" colSpan="2">COMPETITIVE SCAN
							</td>
						</tr>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_SCENARIO" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="CU_CIF" HeaderText="CU_CIF"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="ID_AP_VARIABLE" HeaderText="ID_AP_VARIABLE"></asp:BoundColumn>
										<asp:BoundColumn DataField="product" HeaderText="Product">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Primary bank" ItemStyle-Width="35%" ItemStyle-VerticalAlign="Top">
											<HeaderStyle CssClass="tdSmallHeader" VerticalAlign="Top"></HeaderStyle>
											<ItemTemplate>
												<asp:TextBox Width="100%" BackColor="#e0dfe3" Runat="server" ID="TXT_PRIMARY_BANK_GRID" TextMode="MultiLine"
													ReadOnly="True"></asp:TextBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Other banks" ItemStyle-Width="35%">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemTemplate>
												<asp:TextBox Width="100%" BackColor="#e0dfe3" Runat="server" ID="TXT_OTHER_BANKS_GRID" TextMode="MultiLine"
													ReadOnly="True"></asp:TextBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Function" ItemStyle-Width="7%">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="edit">View</asp:LinkButton>&nbsp;
												<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<td colSpan="2">
								<table width="100%">
									<TR>
										<TD class="TDBGColor1" width="15%"><asp:label id="LBL_TXT_CIF" runat="server">Product :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:dropdownlist id="DDL_PRODUCT" runat="server" Width="100%"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" vAlign="top" width="15%"><asp:label id="LBL_TXT_CUST_NAME" runat="server">Primary Bank :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_PRIMARY_BANK" runat="server" Width="100%" Height="70px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" vAlign="top" width="15%"><asp:label id="LBL_TXT_ADDRESS" runat="server">Other Banks :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_OTHER_BANK" runat="server" Width="100%" Height="70px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</table>
							</td>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE_COMPITIVE" runat="server" Width="100px" Text=" Save " CssClass="Button1"></asp:button></td>
									</tr>
								</table>
							</TD>
						</TR>
						<tr>
							<td class="tdHeader1" colSpan="2">STRATEGIES TO GROW ANCHORS
							</td>
						</tr>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="StrategiesToGrowAnchors" runat="server" AutoGenerateColumns="False" Width="100%"
									AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="CU_CIF" HeaderText="CU_CIF"></asp:BoundColumn>
										<asp:BoundColumn DataField="SEQ" HeaderText="#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Key Support Needed to Grow Anchors">
											<HeaderStyle CssClass="tdSmallHeader" VerticalAlign="Top"></HeaderStyle>
											<ItemStyle Width="90%" VerticalAlign="Top"></ItemStyle>
											<ItemTemplate>
												<asp:TextBox Width="100%" BackColor="#e0dfe3" Runat="server" ID="TXT_KEY_SUPPORT" TextMode="MultiLine"
													ReadOnly="True" Height="50px"></asp:TextBox>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="Linkbutton1" runat="server" CommandName="edit">View</asp:LinkButton>&nbsp;
												<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<td colSpan="2">
								<table width="100%">
									<TR id="TR_NO" runat="server">
										<TD class="TDBGColor1" width="15%"><asp:label id="Label5" runat="server">No :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_SEQ_GROW_ANCHORS" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" vAlign="top" width="15%"><asp:label id="Label6" runat="server">Key Support Needed :</asp:label></TD>
										<TD class="TDBGColorValue" width="100%"><asp:textbox id="TXT_KEY_SUPPORT_NEEDED" runat="server" Width="100%" Height="70px" TextMode="MultiLine"></asp:textbox></TD>
									</TR>
								</table>
							</td>
						</TR>
						<TR>
							<TD vAlign="top" align="center" colSpan="2">
								<table width="100%">
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE_STRATEGIES_TO_GROW_ANCHORS" runat="server" Width="100px" Text=" Save "
												CssClass="Button1"></asp:button></td>
									</tr>
								</table>
							</TD>
						</TR>
						<tr>
							<td colspan="2" class="tdHeader1" valign="middle" runat="server" ID="Td2">
								DOCUMENTS</td>
						</tr>
						<tr>
							<td>
								<table align="center" width="100%">
									<tr>
										<td vAlign="top" width="50%">
											<table cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" width="75">File</TD>
													<TD style="WIDTH: 15px">:</TD>
													<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
															runat="Server"></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Status</TD>
													<TD>:</TD>
													<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only xls, doc, txt, pdf, docx, xlsx or zip files are allowed!"
															ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.docx|.DOCX|.xlsx|.XLSX|)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"></TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload"></asp:button></TD>
												</TR>
												<TR>
													<TD align="center" colSpan="3"></TD>
												</TR>
											</table>
										</td>
									</tr>
								</table>
							</td>
							<td vAlign="top" width="50%">
								<asp:datagrid id="DATA_UPLOAD" runat="server" CellPadding="1" PageSize="5" AutoGenerateColumns="False"
									Width="100%" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_DATA_SNAPSHOT" HeaderText="ID_UPLOAD_DATA_SNAPSHOT">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn>
											<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
											<ItemTemplate>
												<asp:HyperLink id="FILE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="FILE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</asp:datagrid>
							</td>
						</tr>
					<!-- separator --------------></table>
				</TD></TR></asp:panel></TABLE></center>
		</form>
	</body>
</HTML>
