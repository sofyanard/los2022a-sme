<%@ Page language="c#" Codebehind="Neraca_KMK_KI_SMALL.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.Neraca_KMK_KI_500JT_2M" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Neraca_KMK_KI_500JT_2M</title>
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
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Neraca (Rp.000,-)</TD>
					</TR>
					<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------->
					<TR>
						<TD class="tdNoBorder" vAlign="top" align="center" colSpan="2"><table width="100%">
								<tr>
									<td class="tdHeader1" vAlign="top" width="50%">History</td>
									<td class="tdHeader1" vAlign="top" width="50%">Current</td>
								</tr>
								<tr>
									<td vAlign="top" width="50%">
										<ASP:DATAGRID id="DG_NeracaHistory" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
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
												<asp:BoundColumn DataField="JNS_LAP" HeaderText="Jenis Laporan">
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
									<td vAlign="top" width="50%"><ASP:DATAGRID id="DG_Neraca1" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="POSISI_TGL" HeaderText="Year">
													<HeaderStyle HorizontalAlign="Center" Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="JML_BLN" HeaderText="Periode Laporan">
													<HeaderStyle HorizontalAlign="Center" Width="22%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="JNS_LAP" HeaderText="Jenis Laporan">
													<HeaderStyle HorizontalAlign="Center" Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="tahun"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="POSISI_TGL" HeaderText="tgl"></asp:BoundColumn>
												<asp:ButtonColumn Text="Retrieve" CommandName="retrieve"></asp:ButtonColumn>
												<asp:ButtonColumn Text="Delete" CommandName="delete"></asp:ButtonColumn>
											</Columns>
										</ASP:DATAGRID></td>
								</tr>
							</table>
						</TD>
					</TR>
					<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
					<TR>
						<td class="td" align="center" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TBODY>
									<tr>
										<td class="tdSmallHeader" align="center" width="34%" rowSpan="2">Pos-pos neraca</td>
										<td class="tdSmallHeader" align="center" width="66%" colSpan="10">Neraca Per</td>
									</tr>
									<tr>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun ke n-1/bln</td>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun ke n/bln</td>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun Proyeksi/bln</td>
									</tr>
									<!--  START baris 0 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br01">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" align="right" width="34%"><STRONG>Posisi 
												Tanggal</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_B1" tabIndex="1" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_B1" tabIndex="2" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_B1" tabIndex="3" runat="server" MaxLength="4"
												Columns="4"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_C1" tabIndex="37" runat="server" MaxLength="2"
												Columns="4" CssClass="mandatory2"></asp:textbox><asp:dropdownlist id="DDL_BLN_C1" tabIndex="38" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_C1" tabIndex="39" runat="server"
												MaxLength="4" Columns="4" CssClass="mandatory2"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_D1" tabIndex="73" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_D1" tabIndex="74" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_D1" tabIndex="75" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></td>
									</tr>
									<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR id="br0">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" align="right" width="34%"><STRONG>Jumlah 
												Bulan</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B2" style="TEXT-ALIGN: center" tabIndex="4"
												runat="server" MaxLength="2" width="50%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C2" style="TEXT-ALIGN: center" tabIndex="40"
												runat="server" MaxLength="2" CssClass="mandatory2" width="50%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D2" style="TEXT-ALIGN: center" tabIndex="76"
												runat="server" MaxLength="2" width="50%"></asp:textbox></td>
									</TR>
									<tr id="br1">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" align="right" width="34%"><STRONG>Jenis 
												Laporan</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:dropdownlist id="DDL_B3" tabIndex="5" runat="server">
												<asp:ListItem Value="-">-Pilih-</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:dropdownlist id="DDL_C3" tabIndex="41" runat="server" CssClass="mandatory2">
												<asp:ListItem Value="-">-Pilih-</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2">&nbsp;<asp:dropdownlist id="DDL_D3" tabIndex="77" runat="server" Visible="False">
												<asp:ListItem Value="-">-Pilih-</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></td>
									</tr>
									<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br2">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" align="right" width="34%"><STRONG>Sales 
												On Credit %</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B4" style="TEXT-ALIGN: center" tabIndex="6"
												runat="server" MaxLength="4" width="50%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C4" style="TEXT-ALIGN: center" tabIndex="42"
												runat="server" MaxLength="4" width="50%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D4" style="TEXT-ALIGN: center" tabIndex="78"
												runat="server" MaxLength="4" width="50%"></asp:textbox></td>
									</tr>
									<!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br20">
										<td class="TDBGColor" style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="10"><STRONG>AKTIVA</STRONG></td>
									</tr>
									<tr id="br3">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Kas dan Bank</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B5" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B35')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C5" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C35')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="43" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D5" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D35')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="79" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br4">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Piutang Dagang</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B6" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B35')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C6" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C35')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="44" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D6" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D35')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="80" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br5">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Persediaan</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B7" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B35')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="9" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C7" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C35')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="45" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D7" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D35')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="81" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br6">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Pekerjaan dalam 
											proses</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B8" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B35')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="10" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C8" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C35')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="46" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D8" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D35')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="82" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br7">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Total Aktiva Lancar</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="11" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="47" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="83" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br8">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Bangunan 
											(Sebelum Penyusutan)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B10" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C10" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="48" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D10" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="84" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br9">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Mesin 
											(Sebelum Penyusutan)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B11" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="13" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C11" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="49" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D11" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="85" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br10">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Peralatan 
											(Sebelum Penyusutan)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B12" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="14" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C12" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="50" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D12" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="86" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 11 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br11">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Kendaraan (Sebelum Penyusutan)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B13" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="15" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C13" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="51" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D13" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="87" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br14">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Tanah 
											</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B16" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C16" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D16" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="90" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 17 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br17">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Total Penyusutan (Bangunan, Mesin, Peralatan, Kendaraan)</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="21" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="57" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="93" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br12">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Penyusutan Total</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B14" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C14" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="52" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D14" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="88" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br13">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Net Aktiva Tetap</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="17" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="53" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="89" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 15 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br15">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Amortisasi (Jika Ada)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B17" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="19" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C17" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="55" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D17" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="91" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 16 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br16">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Aktiva Lainnya (Jika Ada)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B18" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C18" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="56" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D18" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="92" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 18 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br18">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Total Aktiva</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="22" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="58" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="94" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 20 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br20">
										<td class="TDBGColor" style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="10"><STRONG>PASIVA</STRONG></td>
									</tr>
									<!--  START baris 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br21">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Hutang Dagang</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B21" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="23" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C21" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D21" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="95" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br22">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Hutang Bank</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B22" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="24" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C22" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D22" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="96" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br23">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Hutang Pajak</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B23" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="25" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C23" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D23" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="97" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br24">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Hutang lancar 
											lainnya (Jika Ada)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B24" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="26" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C24" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="62" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D24" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="98" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 25 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br25">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Total Hutang Lancar</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="27" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="63" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="99" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 26 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br26">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Hutang jangka 
											panjang</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B26" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="28" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C26" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="64" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D26" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="100" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 27 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br27">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Hutang pemegang 
											saham (Jika Ada)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B27" onblur="FormatCurrency_noDec(this),HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="29" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C27" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="65" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D27" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="101" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 28 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br28">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Hutang jangka 
											panjang lainnya (Jika Ada)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B28" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="30" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C28" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D28" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="102" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 29 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br29">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Total hutang Jangka 
												Panjang</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="31" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="67" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="103" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 30 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br30">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Total Hutang</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="32" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="68" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="104" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 31 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br31">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Modal (Diisi Terakhir untuk Balance)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B31" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C31" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="69" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D31" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="105" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 32 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!-- <tr id="br32">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Laba Tahun ditahan (Jika Ada)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B32" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="34" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C32" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="70" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D32" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="106" runat="server" Width="100%"></asp:textbox></td>
									</tr> -->
									<!--  START baris 33 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<TR>
										<TD class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Laba Tahun berjalan</TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B33" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'B'), FormatCurrency_noDec(document.getElementById('TXT_B9')),FormatCurrency_noDec(document.getElementById('TXT_B15')), FormatCurrency_noDec(document.getElementById('TXT_B19')), FormatCurrency_noDec(document.getElementById('TXT_B20')),FormatCurrency_noDec(document.getElementById('TXT_B25')), FormatCurrency_noDec(document.getElementById('TXT_B29')),FormatCurrency_noDec(document.getElementById('TXT_B30')), FormatCurrency_noDec(document.getElementById('TXT_B34')),FormatCurrency_noDec(document.getElementById('TXT_B35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="35" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C33" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'C'), FormatCurrency_noDec(document.getElementById('TXT_C9')),FormatCurrency_noDec(document.getElementById('TXT_C15')), FormatCurrency_noDec(document.getElementById('TXT_C19')), FormatCurrency_noDec(document.getElementById('TXT_C20')),FormatCurrency_noDec(document.getElementById('TXT_C25')), FormatCurrency_noDec(document.getElementById('TXT_C29')),FormatCurrency_noDec(document.getElementById('TXT_C30')), FormatCurrency_noDec(document.getElementById('TXT_C34')),FormatCurrency_noDec(document.getElementById('TXT_C35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="71" runat="server" Width="100%"></asp:textbox></TD>
										<TD width="1%"></TD>
										<TD class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D33" onblur="FormatCurrency_noDec(this), HitungNeracaSmall(8,'D'), FormatCurrency_noDec(document.getElementById('TXT_D9')),FormatCurrency_noDec(document.getElementById('TXT_D15')), FormatCurrency_noDec(document.getElementById('TXT_D19')), FormatCurrency_noDec(document.getElementById('TXT_D20')),FormatCurrency_noDec(document.getElementById('TXT_D25')), FormatCurrency_noDec(document.getElementById('TXT_D29')),FormatCurrency_noDec(document.getElementById('TXT_D30')), FormatCurrency_noDec(document.getElementById('TXT_D34')),FormatCurrency_noDec(document.getElementById('TXT_D35')) "
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="107" runat="server" Width="100%"></asp:textbox></TD>
									</TR>
									<tr id="br33">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Modal (Pembalance)</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="36" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="72" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="108" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 34 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br34">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><b>Total Pasiva (Hutang 
												+ Net Worth)</b></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_B35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="36" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_C35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="36" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2">
											<asp:textbox onkeypress="return numbersonly()" id="TXT_D35" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="36" runat="server" Width="100%"></asp:textbox></td>
									</tr>
								</TBODY>
							</table>
							<!--  END SEPARATOR UTK ISI NERACA  -----------------------------------------------------></td>
					</TR>
					<TR>
						<TD width="100%" colSpan="2">
							<table class="tdBGColor2" width="100%">
								<TR>
									<TD class="tdBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SIMPANSAJA" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SIMPANSAJA_Click"></asp:button>&nbsp;&nbsp;
										<asp:button id="BTN_CLEAR" runat="server" Width="100px" CssClass="Button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
								</TR>
							</table>
						</TD>
					<TR>
						<TD class="tdHeader1" width="100%" colSpan="2">Documents</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<!-- <tr>
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
								</tr> -->
							</table>
						</TD>
						<TD vAlign="top" width="50%" rowSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<!-- <TR>
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
								</TR> -->
							</table>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<!-- <TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="TXT_FILE_UPLOAD" runat="Server"></TD>
								</TR> -->
								<!-- <TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
											ControlToValidate="TXT_FILE_UPLOAD" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$"></asp:regularexpressionvalidator></TD>
								</TR> -->
								<!-- <TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR> -->
								<!-- <TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA" runat="server" Visible="False"></asp:label></TD> -->
								</TR>
								<!-- <TR>
									<TD align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR> -->
								<!-- <TR>
									<TD align="center" colSpan="3"></TD>
								</TR> -->
								<!-- <TR>
									<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk tidak 
											meng-klik tulisan download, tp di klik kanan saja dari tulisan download 
											tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
								</TR> -->
							</table>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR> 
			<!-- ************************* separator *************-------------------------------------------------------------------------------------------------------------------------------------------><TR>
				<TD></TD>
			</TR>
			</TBODY></TABLE> 
			<!-- tbl dibawah jangan dihapus ------>
			<table style="DISPLAY: none" width="100%">
				<tr>
					<td>&nbsp;</td>
					<td><asp:textbox id="TXT_B1" style="TEXT-ALIGN: center" runat="server" Width="160px" Visible="False"></asp:textbox><asp:textbox id="TXT_C1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D1" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_B3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
							Visible="False"></asp:textbox><asp:textbox id="TXT_C3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
							Visible="False"></asp:textbox><asp:textbox id="TXT_D3" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"
							Visible="False"></asp:textbox></asp:textbox>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td></asp:textbox><asp:textbox id="TXT_B37" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B38" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B39" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B40" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B41" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B42" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B43" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B44" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B45" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B46" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B47" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B48" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B49" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B50" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B51" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B52" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B53" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B54" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B55" runat="server" Visible="False"></asp:textbox></td>
					<td></asp:textbox><asp:textbox id="TXT_C37" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C38" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C39" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C40" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C41" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C42" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C43" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C44" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C45" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C46" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C47" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C48" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C49" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C50" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C51" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C52" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C53" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C54" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C55" runat="server" Visible="False"></asp:textbox></td>
					<td><asp:textbox id="TXT_D36" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D37" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D38" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D39" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D40" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D41" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D42" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D43" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D44" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D45" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D46" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D47" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D48" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D49" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D50" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D51" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D52" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D53" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D54" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D55" runat="server" Visible="False"></asp:textbox></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
