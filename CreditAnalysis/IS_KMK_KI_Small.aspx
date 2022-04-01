<%@ Page language="c#" Codebehind="IS_KMK_KI_Small.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.IS_KMK_KI_Small" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IS_KMK_KI_Small</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../include/Neraca-IS-javascript.html" -->
		<script language="vbscript">
		function setLokal()
			SetLocale("in")		
		end function
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
											Laba Rugi</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Laba Rugi&nbsp;(Rp.000,-)</TD>
					</TR>
					<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
					<tr>
						<td class="tdHeader1" width="50%">History</td>
						<td class="tdHeader1" width="50%">Current</td>
					</tr>
					<TR>
						<td class="tdNoBorder" vAlign="top" width="50%"><ASP:DATAGRID id="DG_LRHistory" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
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
						<TD class="tdNoBorder" vAlign="top" width="50%"><asp:datagrid id="DB_LBRG1" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
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
									<asp:BoundColumn Visible="False" DataField="POSISI_TGL" HeaderText="TGL"></asp:BoundColumn>
									<asp:ButtonColumn Text="Retrieve" CommandName="retrieve"></asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" CommandName="delete"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
					<TR>
						<td align="center" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TBODY>
									<tr>
										<td class="tdSmallHeader" align="center" width="34%" rowSpan="2">Pos-pos Laba Rugi</td>
										<td class="tdSmallHeader" align="center" width="66%" colSpan="10">Laba 
											Rugi&nbsp;Per</td>
									</tr>
									<tr>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun ke n-1/bln</td>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun ke n/bln</td>
										<td class="tdSmallHeader" align="center" width="22%" colSpan="3">Tahun Proyeksi/bln</td>
									</tr>
									<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br0">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" align="right" width="34%">Posisi 
											Tanggal</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_B36" tabIndex="1" runat="server" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_B36" tabIndex="2" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_B36" tabIndex="3" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_C36" tabIndex="24" runat="server"
												MaxLength="2" Columns="4" CssClass="mandatory2"></asp:textbox><asp:dropdownlist id="DDL_BLN_C36" tabIndex="25" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_C36" tabIndex="26" runat="server"
												MaxLength="4" Columns="4" CssClass="mandatory2"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_D36" tabIndex="47" runat="server"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_D36" tabIndex="48" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_D36" tabIndex="49" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></td>
									</tr>
									<tr>
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" align="right" width="34%">Jumlah 
											Bulan</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B37" style="TEXT-ALIGN: center" tabIndex="4"
												runat="server" Width="50%" MaxLength="2"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C37" style="TEXT-ALIGN: center" tabIndex="27"
												runat="server" Width="50%" MaxLength="2" CssClass="mandatory2"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D37" style="TEXT-ALIGN: center" tabIndex="50"
												runat="server" Width="50%" MaxLength="2"></asp:textbox></td>
									</tr>
									<tr id="br1">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" align="right" width="34%">Jenis 
											Laporan</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="20%" colSpan="2"><asp:dropdownlist id="DDL_B38" tabIndex="5" runat="server">
												<asp:ListItem Value="-">- Pilih -</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="20%" colSpan="2"><asp:dropdownlist id="DDL_C38" tabIndex="28" runat="server" CssClass="mandatory2">
												<asp:ListItem Value="-">- Pilih -</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="20%" colSpan="2"><asp:dropdownlist id="DDL_D38" tabIndex="51" runat="server" Visible="False">
												<asp:ListItem Value="-">- Pilih -</asp:ListItem>
												<asp:ListItem Value="Audited">Audited</asp:ListItem>
												<asp:ListItem Value="Un-Audited">Un-Audited</asp:ListItem>
											</asp:dropdownlist></td>
									</tr>
									<!--  START baris 2 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br3">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Penjualan (KMK)/Penghasilan Usaha (KI)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B39" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C39" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="30" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D39" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="53" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br4">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">% Harga Pokok 
											Penjualan (HPP)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B40" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(1,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C40" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(1,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="31" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D40" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(1,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="54" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br5">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><STRONG>Nilai HPP</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="9" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="32" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D41" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="55" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br14">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Pendapatan lain-lain (Bersih)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B49" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(5,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="17" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C49" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(5,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="40" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D49" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(5,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="63" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br7">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><STRONG>Laba Kotor</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="11" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="34" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D43" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="57" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br6">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Biaya ATK, Administrasi &amp; 
											Konsumsi</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B42" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(2,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55')), FormatCurrency_noDec(document.getElementById('TXT_B41'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="10" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C42" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(2,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55')), FormatCurrency_noDec(document.getElementById('TXT_C41'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="33" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D42" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(2,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55')), FormatCurrency_noDec(document.getElementById('TXT_D41'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="56" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br9">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Biaya Transportasi, 
											Promosi &amp; Tenaga Kerja</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B45" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="13" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C45" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="36" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D45" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="59" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br10">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Biaya Telp/Listrik/Air 
											&amp; Pemeliharaan</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B46" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="14" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C46" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="37" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D46" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="60" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 11 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br11">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Biaya Umum 
											&amp; Gaji Pemilik</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B47" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="15" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C47" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="38" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D47" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(4,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="61" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 15 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br15">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Biaya lain-lain (Diisi Jika Ada)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B50" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(5,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="18" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C50" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(5,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="41" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D50" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(5,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="64" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 16 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br16">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><STRONG>Biaya Penyusutan</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B51" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="19" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C51" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="42" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D51" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="65" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br13">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><STRONG>Total 
												Biaya</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="16" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="39" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D48" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="62" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br8">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><STRONG>Laba Operasi</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="12" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="35" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D44" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="58" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 17 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br17">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">Biaya Bunga (Informasi dari SID/PAPI)</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B52" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(6,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C52" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(6,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="43" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D52" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(6,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="66" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 18 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br18">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><STRONG>Laba Sebelum 
												Pajak (EBT)</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B53" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="21" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C53" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="44" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D53" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="67" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  separator ----------------------------------------------------->
									<tr id="br21">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%">% Pajak</td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B54" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(7,'B'), FormatCurrency_noDec(document.getElementById('TXT_B41')), FormatCurrency_noDec(document.getElementById('TXT_B43')), FormatCurrency_noDec(document.getElementById('TXT_B44')), FormatCurrency_noDec(document.getElementById('TXT_B48')), FormatCurrency_noDec(document.getElementById('TXT_B51')), FormatCurrency_noDec(document.getElementById('TXT_B53')), FormatCurrency_noDec(document.getElementById('TXT_B55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="22" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C54" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(7,'C'), FormatCurrency_noDec(document.getElementById('TXT_C41')), FormatCurrency_noDec(document.getElementById('TXT_C43')), FormatCurrency_noDec(document.getElementById('TXT_C44')), FormatCurrency_noDec(document.getElementById('TXT_C48')), FormatCurrency_noDec(document.getElementById('TXT_C51')), FormatCurrency_noDec(document.getElementById('TXT_C53')), FormatCurrency_noDec(document.getElementById('TXT_C55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="45" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D54" onblur="FormatCurrency_noDec(this), HitungLabaRugiSmall(7,'D'), FormatCurrency_noDec(document.getElementById('TXT_D41')), FormatCurrency_noDec(document.getElementById('TXT_D43')), FormatCurrency_noDec(document.getElementById('TXT_D44')), FormatCurrency_noDec(document.getElementById('TXT_D48')), FormatCurrency_noDec(document.getElementById('TXT_D51')), FormatCurrency_noDec(document.getElementById('TXT_D53')), FormatCurrency_noDec(document.getElementById('TXT_D55'))"
												style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="68" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br22">
										<td class="tdBGColor1" style="PADDING-RIGHT: 15px" width="34%"><STRONG>Laba Bersih (Net 
												Income)</STRONG></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_B55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="23" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_C55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="46" runat="server" Width="100%"></asp:textbox></td>
										<td width="1%">&nbsp;</td>
										<td class="tdBGColorValue" align="center" width="21%" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_D55" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right"
												tabIndex="69" runat="server" Width="100%"></asp:textbox></td>
									</tr>
								</TBODY>
							</TABLE>
							<!-- END SEPARATOR UTK ISI NERACA  -----------------------------------------------------></td>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2">
							<table width="100%">
								<TBODY>
									<tr>
										<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp; 
											<!-- remark sementara -- <asp:button id="BTN_PROSES" runat="server" Width="150px" CssClass="Button1" Text="Proses / Calculate"></asp:button>&nbsp; --><asp:button id="BTN_CLEAR" runat="server" Width="100px" CssClass="Button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></td>
									</tr>
								</TBODY>
							</table>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<table>
				<tr>
					<td><asp:textbox id="TXT_B36" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C36" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D36" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_B38" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_C38" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox><asp:textbox id="TXT_D38" style="TEXT-ALIGN: center" runat="server" Width="100%" Visible="False"></asp:textbox></td>
				</tr>
			</table>
			<asp:label id="LBL_TAMPUNG" style="Z-INDEX: 101; LEFT: 240px; POSITION: absolute; TOP: 944px"
				runat="server" Visible="False">Label</asp:label></form>
	</body>
</HTML>
