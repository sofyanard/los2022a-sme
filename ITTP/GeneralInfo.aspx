<%@ Page language="c#" Codebehind="GeneralInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.GeneralInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GeneralInfo</title>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer Info</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD colspan="3"><TABLE bordercolor="white">
								<TR>
									<TD class="td" vAlign="top" width="40%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" bordercolor="white">
											<TR>
												<TD class="TDBGColor1">CIF Number</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="Textbox25" runat="server" Width="280px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="40%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" bordercolor="white">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 11px">Customer Name</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="Textbox40" runat="server" Width="272px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="20%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" bordercolor="white">
											<TR>
												<TD style="HEIGHT: 11px" align="center">
													<asp:Button id="Button1" runat="server" Text="Search"></asp:Button>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colspan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">INFORMASI NASABAH</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 542px" vAlign="top" width="542"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">CIF No</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Customer Name</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CUST_NAME" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 24px">Jenis Nasabah</TD>
									<TD style="WIDTH: 5px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 24px" vAlign="middle" align="left"><asp:textbox id="TXT_JENIS_NASABAH" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penduduk</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 10px"><asp:textbox id="TXT_PENDUDUK" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px">Tgl. Pembukaan</TD>
									<TD style="WIDTH: 5px; HEIGHT: 23px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 23px"><asp:textbox id="Textbox3" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl. Lahir/Tgl. Berdiri Perusahaan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_REPORT_NAME" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Tempat Lahir/Berdiri Perusahaan</TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 20px" align="left"><asp:textbox id="Textbox1" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px">Jenis ID Utama</TD>
									<TD style="WIDTH: 5px; HEIGHT: 23px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 23px"><asp:textbox id="Textbox2" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. ID Utama</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_MAIN_ID" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl. Kadaluarsa ID Utama</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_TGL_KADALUARSA_ID" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Tempat Dikeluarkan ID Utama</TD>
									<TD style="WIDTH: 5px; HEIGHT: 14px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 14px"><asp:textbox id="Textbox5" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px">Kewarganegaraaan</TD>
									<TD style="WIDTH: 5px; HEIGHT: 25px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 25px"><asp:textbox id="Textbox4" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Kode Negara</TD>
									<TD style="WIDTH: 5px; HEIGHT: 14px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 14px"><asp:textbox id="Textbox6" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Agama</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_ADDRESS_LINE1" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Pekerjaan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_KECAMATAN" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Business Unit Code</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_APP" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Nama Gadis Ibu Kandung</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 23px" align="left"><asp:textbox id="Textbox7" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Marital Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_APT" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Jenis Kelamin</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 23px" align="left"><asp:textbox id="Textbox8" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Kode Industri</TD>
									<TD style="WIDTH: 6px; HEIGHT: 11px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 20px"><asp:textbox id="Textbox9" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Cabang Pengawas</TD>
									<TD style="WIDTH: 6px; HEIGHT: 11px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 1px"><asp:textbox id="Textbox11" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Level Pendidikan</TD>
									<TD style="WIDTH: 6px; HEIGHT: 11px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 26px"><asp:textbox id="Textbox10" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Jumlah Tanggungan</TD>
									<TD style="WIDTH: 6px; HEIGHT: 11px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 24px"><asp:textbox id="Textbox12" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Status Nasabah</TD>
									<TD style="WIDTH: 6px; HEIGHT: 11px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 18px" align="left"><asp:textbox id="Textbox14" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">Pengiriman Surat</TD>
									<TD style="WIDTH: 6px; HEIGHT: 11px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 11px"><asp:textbox id="Textbox13" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>
										<table>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 54%; HEIGHT: 11px">
													Retensi</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 45%; HEIGHT: 11px"><asp:textbox id="Textbox15" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 54%; HEIGHT: 11px">ATM Card</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 45%; HEIGHT: 11px"><asp:textbox id="Textbox16" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 54%; HEIGHT: 11px">Credit Card</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 45%; HEIGHT: 11px"><asp:textbox id="Textbox17" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 54%; HEIGHT: 11px">Treasury</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 45%; HEIGHT: 11px"><asp:textbox id="Textbox18" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 54%; HEIGHT: 11px">Cross Sell info</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 45%; HEIGHT: 11px"><asp:textbox id="Textbox19" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
										</table>
									</TD>
									<TD>
									</TD>
									<TD>
										<table>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 53.71%; HEIGHT: 11px">
													Trade Service/Finance</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 55%; HEIGHT: 11px"><asp:textbox id="Textbox20" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 53.71%; HEIGHT: 11px">Debit Card</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 55%; HEIGHT: 11px"><asp:textbox id="Textbox21" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 53.71%; HEIGHT: 11px">CLS Customer</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 55%; HEIGHT: 11px"><asp:textbox id="Textbox22" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 53.71%; HEIGHT: 11px">Nasabah CAP</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 55%; HEIGHT: 11px"><asp:textbox id="Textbox23" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 53.71%; HEIGHT: 11px">
													Mutual Fund</TD>
												<TD style="WIDTH: 1%; HEIGHT: 11px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 55%; HEIGHT: 11px"><asp:textbox id="Textbox24" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
										</table>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</table>
				</TD></TR></TABLE><br>
				<tr>
					<td></td>
				</tr>
				</TABLE></CENTER>
		</form>
	</body>
</HTML>
