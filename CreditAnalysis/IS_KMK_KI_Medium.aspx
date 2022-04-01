<%@ Page language="c#" Codebehind="IS_KMK_KI_Medium.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.IS_KMK_KI_Medium" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IS_KMK_KI_Medium</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../include/Neraca-IS-javascript.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TBODY>
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Analysis&nbsp;: 
											Laba Rugi</B></TD>
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
					<TR>
						<TD vAlign="top" colSpan="2">
							<table width="100%">
								<TR>
									<TD class="tdHeader1" vAlign="top" colSpan="3">Laba Rugi&nbsp;(Rp.000,-)</TD>
								</TR>
								<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
								<tr>
									<td class="tdHeader1" width="30%">History</td>
									<td class="tdHeader1" width="30%">Inisialisasi</td>
									<td class="tdHeader1" width="40%">Current</td>
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
												<TD align="center" width="40%" colSpan="2"><asp:button id="BTN_CEK" runat="server" Width="100px" Text=" Save " CssClass="Button1" onclick="BTN_CEK_Click"></asp:button></TD>
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
												<asp:ButtonColumn Text="Delete" CommandName="delete"></asp:ButtonColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
							</table>
						</TD>
					</TR>
					<!-- separator ------------------------------------------------------------------------------------------------------------------------------------------><asp:panel id="PnlNeraca" runat="server" Visible="False">
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
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_B37" tabIndex="1" runat="server" MaxLength="2"
												Columns="4"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_B37" tabIndex="2" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_B37" tabIndex="3" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_C37" tabIndex="28" runat="server"
												MaxLength="2" Columns="4"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_C37" tabIndex="29" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_C37" tabIndex="30" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_D37" tabIndex="55" runat="server"
												CssClass="mandatory2" MaxLength="2" Columns="4"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_D37" tabIndex="56" runat="server" CssClass="mandatory2"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_D37" tabIndex="57" runat="server"
												CssClass="mandatory2" MaxLength="4" Columns="4"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_E37" tabIndex="82" runat="server"
												MaxLength="2" Columns="4"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_E37" tabIndex="83" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_E37" tabIndex="84" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR> <!--  START baris 2 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR>
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Number 
											Of Month</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B38" style="TEXT-ALIGN: center" tabIndex="4"
												runat="server" Width="50%" MaxLength="2"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C38" style="TEXT-ALIGN: center" tabIndex="31"
												runat="server" Width="50%" MaxLength="2"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D38" style="TEXT-ALIGN: center" tabIndex="58"
												runat="server" Width="50%" CssClass="mandatory2" MaxLength="2"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E38" style="TEXT-ALIGN: center" tabIndex="85"
												runat="server" Width="50%" MaxLength="2"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px; HEIGHT: 3px" align="right" width="24%">Report 
											Type</TD>
										<TD style="HEIGHT: 3px" width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 3px" align="center" width="18%" colSpan="2">
											<asp:dropdownlist id="DDL_B39" tabIndex="5" runat="server">
												<asp:ListItem Value="-">- Pilih -</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></TD>
										<TD style="HEIGHT: 3px" width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 3px" align="center" width="18%" colSpan="2">
											<asp:dropdownlist id="DDL_C39" tabIndex="32" runat="server">
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
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E41" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR id="br4"> <!-- Cost Of Goods Sales -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Cost 
											Of Goods Sales</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E42" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 5 SEPARATOR UTK ISI laba rugi ----------------------------------------------------->
									<TR> <!-- % Sale  Row 16 -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
											Sales</TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="9" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="36" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="63" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="90" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR id="br6"> <!-- Hitung -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Gross 
											Margin</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="10" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="37" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="64" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="91" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR> <!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR> <!-- '% of Sales	 Gross Margin	Row 18	  -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
											Sales</TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="11" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="38" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="65" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E45" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="92" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR id="br8">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Selling, 
											Gen, Admin Exp</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E46" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR> <!-- '% of Sales, Row 20	 -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
											Sales</TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="13" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="40" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="67" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E47" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="94" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR id="br10"> <!-- 'Operating Earnings				21					-->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Operating 
											Earnings</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox ReadOnly="true" BackColor="Gainsboro" onkeypress="return numbersonly()" id="TXT_B48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="14" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox ReadOnly="true" BackColor="Gainsboro" onkeypress="return numbersonly()" id="TXT_C48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="41" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox ReadOnly="true" BackColor="Gainsboro" onkeypress="return numbersonly()" id="TXT_D48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="68" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox ReadOnly="true" BackColor="Gainsboro" onkeypress="return numbersonly()" id="TXT_E48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="95" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR> <!-- '% of Sales Row 22 -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
											Sales</TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="15" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="42" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="69" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E49" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="96" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR id="br12">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Depreciation 
											(Fixed Assets)</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E50" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR id="br13">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Amortization 
											1 (Other Non C Ass)</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E51" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR id="br14">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Amortization 
											2 (Intangibles)</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E52" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 15 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR id="br15">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Other 
											Income (Charges) - Net</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E53" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  START baris 16 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR id="br16">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Extraordinary 
											Items</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E54" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR> <!--  separator ----------------------------------------------------->
									<TR id="br21"> <!-- 'Earnings Before Interest & Taxes 27					55   =  48 - 50-51-52 +53 -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Earnings 
											Before Interest &amp; Taxes</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="21" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="48" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="75" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="102" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR> <!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR id="br22">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Interest 
											Expense</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E56" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR>
									<TR id="br23"> <!-- 'Earnings Before Taxes			  29					57   = 55 - 56  -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Earnings 
											Before Taxes</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="23" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="50" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="77" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E57" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="104" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR> <!--	'% of Sales		Row 31							58   =  57/41	 -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
											Sales</TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="24" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="51" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="78" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E58" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="105" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR id="br25">
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Income 
											Taxes</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'B'), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B45')), FormatCurrency_noDec(document.getElementById('TXT_B47')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B49')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B57')), FormatCurrency_noDec(document.getElementById('TXT_B58')), FormatCurrency_noDec(document.getElementById('TXT_B60')), FormatCurrency_noDec(document.getElementById('TXT_B61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'C'), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C45')), FormatCurrency_noDec(document.getElementById('TXT_C47')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C49')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C57')), FormatCurrency_noDec(document.getElementById('TXT_C58')), FormatCurrency_noDec(document.getElementById('TXT_C60')), FormatCurrency_noDec(document.getElementById('TXT_C61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'D'),  FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D45')), FormatCurrency_noDec(document.getElementById('TXT_D47')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D49')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D57')), FormatCurrency_noDec(document.getElementById('TXT_D58')), FormatCurrency_noDec(document.getElementById('TXT_D60')), FormatCurrency_noDec(document.getElementById('TXT_D61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E59" onblur="FormatCurrency_noDec(this), HitungLabaRugiMiddle(0,'E'),  FormatCurrency_noDec(document.getElementById('TXT_E43')), FormatCurrency_noDec(document.getElementById('TXT_E44')), FormatCurrency_noDec(document.getElementById('TXT_E45')), FormatCurrency_noDec(document.getElementById('TXT_E47')), FormatCurrency_noDec(document.getElementById('TXT_E48')), FormatCurrency_noDec(document.getElementById('TXT_E49')), FormatCurrency_noDec(document.getElementById('TXT_E55')), FormatCurrency_noDec(document.getElementById('TXT_E57')), FormatCurrency_noDec(document.getElementById('TXT_E58')), FormatCurrency_noDec(document.getElementById('TXT_E60')), FormatCurrency_noDec(document.getElementById('TXT_E61'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></TD>
									</TR>
									<TR id="br26"> <!-- 'Net Income												60  =  57 - 59 + 54  -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">Net 
											Income</TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="26" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="53" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="80" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%">&nbsp;</TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E60" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="107" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
									<TR> <!-- '% of Sales												61   60/41   -->
										<TD class="TDBGColor1" style="PADDING-RIGHT: 15px" align="right" width="24%">% Of 
											Sales</TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="27" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="54" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="81" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="TDBGColorValue" align="center" width="18%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_E61" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="108" runat="server" Width="100%" BackColor="Gainsboro"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdBGColor2" align="center" colSpan="2">
								<asp:button id="BTN_SIMPAN" runat="server" Width="120px" CssClass="BUTTON1" Text="Save" onclick="BTN_SIMPAN_Click"></asp:button>&nbsp;&nbsp; 
								<!-- <asp:button id="BTNPROSES" runat="server" Width="150px" CssClass="BUTTON1" Text="Proses / Calculate"></asp:button>&nbsp;&nbsp; -->
								<asp:button id="BTNCLEAR" runat="server" Width="120px" CssClass="BUTTON1" Text="Clear" onclick="BTNCLEAR_Click"></asp:button>
								<asp:Label id="LBL_H_TAHUN" runat="server"></asp:Label></TD>
						</TR>
					</asp:panel></TBODY></TABLE>
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
		</form>
	</body>
</HTML>
