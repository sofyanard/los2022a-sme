<%@ Page language="c#" Codebehind="NotaAnalisaKreditUmum500.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.NotaAnalisaKreditUmum500" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Neraca_KMK_KI_500JT_2M</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/exportpost.html" -->
		
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
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
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
						<TD class="tdNoBorder" vAlign="top" align="center" colSpan="2"><ASP:DATAGRID id="DG_Neraca1" runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
								Width="90%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CA_YEAR" HeaderText="Year">
										<HeaderStyle HorizontalAlign="Center" Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CA_PERIODE_LAP" HeaderText="Periode Laporan">
										<HeaderStyle HorizontalAlign="Center" Width="22%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CA_JNS_LAP" HeaderText="Jenis Laporan">
										<HeaderStyle HorizontalAlign="Center" Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="-"></asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td colSpan="2">Upload File : <INPUT id="File1" type="file" name="File1" runat="server">&nbsp;
							<asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button><BR>
							<asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$"
								ControlToValidate="File1" ErrorMessage="Only xls file are allowed!"></asp:regularexpressionvalidator></td>
					</tr>
					<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
					<TR>
						<td align="center" colSpan="2">
							<table cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TBODY>
									<tr>
										<td class="tdSmallHeader" align="center" width="40%" rowSpan="2">Pos-pos neraca</td>
										<td class="tdSmallHeader" align="center" width="60%" colSpan="6">Neraca Per</td>
									</tr>
									<tr>
										<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n/bln</td>
										<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun ke-n+1/bln</td>
										<td class="tdSmallHeader" align="center" width="20%" colSpan="2">Tahun Proyeksi/bln</td>
									</tr>
									<!--  START baris 1 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br1" bgColor="#ffffff">
										<td style="PADDING-RIGHT: 15px" align="right" width="40%">Posisi Tanggal</td>
										<td align="center" width="15%"><asp:textbox id="TXT_B1" style="TEXT-ALIGN: center" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="5%"><asp:textbox id="TXT_B2" style="TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="15%"><asp:textbox id="TXT_C1" style="TEXT-ALIGN: center" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="5%"><asp:textbox id="TXT_C2" style="TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="15%"><asp:textbox id="TXT_D1" style="TEXT-ALIGN: center" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="5%"><asp:textbox id="TXT_D2" style="TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 2 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br2">
										<td style="PADDING-LEFT: 10px" align="left" width="40%" colSpan="7"><B>AKTIVA</B>
											<asp:textbox id="TXT_B3" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C3" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D3" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_B4" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_C4" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_D4" runat="server" Visible="False"></asp:textbox></td>
									</tr>
									<!--  START baris 3 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br3" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Kas dan Bank</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B5" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C5" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D5" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 4 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br4" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Piutang Dagang</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D6" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 5 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br5" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Persediaan</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D7" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 6 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br6" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Aktiva lancar lainnya</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D8" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 7 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br7" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total Aktiva Lancar</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D9" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 8 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br8" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Tanah dan Bangunan 
											(Net/Incl. Invest Baru)</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D10" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 9 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br9" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Mesin dan Peralatan 
											(Net/Incl. Invest Baru)</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D11" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 10 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br10" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Inventaris dan Kendaraan 
											(Net/Incl. Invest Baru)</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D12" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 11 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br11" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Aktiva Tetap Lainnya</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D13" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 12 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br12" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Akumulasi Penyusutan</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D14" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 13 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br13" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Net Aktiva Tetap</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D15" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 14 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br14" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Biaya yang ditangguhkan</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D16" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 15 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br15" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Akumulasi Amortisasi</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D17" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 16 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br16" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Aktiva Lainnya</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D18" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 17 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br17" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total Aktiva Lain</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D19" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 18 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br18" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total Aktiva</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D20" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  separator ----------------------------------------------------->
									<tr id="br19">
										<td style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="7">&nbsp;</td>
									</tr>
									<!--  START baris 20 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br20" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="100%" colSpan="7"><b>PASIVA</b></td>
									</tr>
									<!--  START baris 21 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br21" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Hutang Dagang</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D21" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 22 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br22" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Hutang Bank</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D22" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 23 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br23" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Bag. KI jth tempo dlm 12 
											bln</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D23" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 24 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br24" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Hutang lancar lainnya</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D24" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 25 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br25" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total Hutang Lancar</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D25" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 26 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br26" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Hutang jangka panjang (KI)</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D26" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 27 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br27" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Hutang pemegang saham</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D27" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 28 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br28" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Hutang jangka panjang 
											lainnya</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B28" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C28" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D28" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 29 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br29" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total hutang Jangka Panjang</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D29" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 30 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br30" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total Hutang</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D30" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 31 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br31" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Modal disetor</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D31" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 32 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br32" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%">Laba (rugi) ditahan</td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D32" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 33 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br33" bgColor="#eff3ff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total Modal</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D33" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
									<!--  START baris 34 SEPARATOR UTK ISI NERACA ----------------------------------------------------->
									<tr id="br34" bgColor="#ffffff">
										<td style="PADDING-LEFT: 10px" align="left" width="40%"><b>Total Pasiva (Hutang + Net 
												Worth)</b></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_B34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_C34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
										<td align="center" width="20%" colSpan="2"><asp:textbox id="TXT_D34" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" runat="server" Width="100%"></asp:textbox></td>
									</tr>
								</TBODY>
							</table>
							<!--  END SEPARATOR UTK ISI NERACA  -----------------------------------------------------></td>
					</TR>
				</TBODY>
			</TABLE>
			</TD></TR> 
			<!-- ************************* separator *************-------------------------------------------------------------------------------------------------------------------------------------------><TR>
				<TD colSpan="2" align="center" vAlign="top">
					<table width="100%">
						<TBODY>
							<tr>
								<td class="tdBGColor2" align="center"><asp:button id="BTN_SAVE" runat="server" Width="101" Text="Save" CssClass="Button1"></asp:button>&nbsp;
									<asp:button id="BTN_PRINT" runat="server" Width="101px" Text="Print" CssClass="Button1" onclick="BTN_PRINT_Click"></asp:button>&nbsp;<asp:button id="BTN_EXP2EXCEL" runat="server" Width="150px" Text="Export to Excel " CssClass="Button1" onclick="BTN_EXP2EXCEL_Click"></asp:button>&nbsp;&nbsp;</td>
							</tr>
						</TBODY>
					</table>
				</TD>
			</TR>
			</TBODY></TABLE>
			<CENTER></CENTER>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM></TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
