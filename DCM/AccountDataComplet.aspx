<%@ Page language="c#" Codebehind="AccountDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.AccountDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AccountDataComplet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Account&nbsp;Data 
											Completeness</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Account&nbsp;Data</TD>
					</TR>
					<TR>
					</TR>
					<tr>
						<td colSpan="2">
							<table>
								<tr>
									<TD class="td" vAlign="top" width="33%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Nomor Rekening</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AREA" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Loan Type</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sifat Kredit</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SIFAT_KREDIT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Penggunaan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JENIS_PENGGUNAAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Orientasi Penggunaan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_ORIENTASI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Golongan Kredit</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_GOL_KREDIT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Kredit</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JENIS_KREDIT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Fas. Penyediaan Dana</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_FAS_DANA" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Bank Utama Sindikasi
												</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_BANK_SINDIKASI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Lokasi Proyek</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox7" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Alamat Proyek</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox8" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Golongan Penjamin</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_GOL_PENJAMIN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="40%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Bagian yang Dijamin</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox1" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KSEBI 1</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSEBI1" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KSEBI 2</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSEBI2" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KSEBI 3</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSEBI3" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KSEBI 4</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSEBI4" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal PK Pertama</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox31" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BULAN_PK1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox32" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No PK Pertama</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox35" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal PK Terakhir</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox33" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BULAN_PKAKHIR" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox34" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No PK Terakhir</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox2" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Awal Kredit</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox3" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist6" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox4" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Mulai</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox5" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist7" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox6" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Jatuh Tempo</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox9" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist8" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox10" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kolektibilitas</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist9" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="40%">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Restrukturisasi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_KEY_PERSON_COMP" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tgl Restru Awal</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox41" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist37" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox42" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tgl Restru Akhir</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox43" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist38" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox44" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tgl Review Restru</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox11" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist10" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox12" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Restrukturisasi ke-</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox13" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Ket. Restrukturisasi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist39" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sandi/Kode Posisi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist40" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tgl Posisi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox45" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist41" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox46" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sebab Macet</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist42" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Macet</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox48" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist43" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox49" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Currency</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist11" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" Text="SAVE" CssClass="button1" Runat="server"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button1" Width="68px" Text="CLEAR" CssClass="button1" Runat="server"></asp:button></TD>
					</TR>
				</table>
				</TD></TR><tr>
					<td></td>
				</tr>
				</TABLE></CENTER>
		</form>
	</body>
</HTML>
