<%@ Page language="c#" Codebehind="PrintSiteVisit.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.PrintSiteVisit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintSiteVisit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
function print_frame() {
	//window.parent.framelkkn.focus();
	tr_print.style.display = "none";
	window.print();
	tr_print.style.display = "";
}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
				<TBODY>
					<tr>
						<td class="td">
							<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
								<tr id="tr_print" align="center">
									<td width="3%" colSpan="2"><INPUT class="button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
											name="BTN_PRINT"><INPUT class="button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
											value="Back" name="BTN_BACK">
									</td>
								</tr>
								<tr align="center">
									<td></td>
								</tr>
								<tr align="center">
									<td class="td" colSpan="2"><STRONG>LAPORAN HASIL REKANAN</STRONG></td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table width="100%">
								<tr>
									<td class="td">
										<table width="100%">
											<tr>
												<td width="30%">Nama Rekanan</td>
												<td width="4%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_NAMA" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%">Alamat</td>
												<td width="4%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_ALAMAT" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="4%"></td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_CITY" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%">No.Telepon Kantor</td>
												<td width="4%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="LBL_TELP" Runat="server"></asp:label></td>
											</tr>
										</table>
									</td>
									<td class="td">
										<table width="100%">
											<tr>
												<td width="30%">Tanggal Kunjungan</td>
												<td width="4%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="TGL_KUNJUNGAN" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%">Diterima oleh</td>
												<td width="4%">:</td>
												<td style="WIDTH: 208px" width="208"><asp:label id="DITERIMA1" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="4%"></td>
												<td style="WIDTH: 208px" width="208"><asp:label id="DITERIMA2" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="30%"></td>
												<td width="4%"></td>
												<td style="WIDTH: 208px" width="208"><asp:label id="DITERIMA3" Runat="server"></asp:label></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table width="100%">
								<tr>
									<td class="td">
										<table width="100%">
											<tr height="40">
												<td width="1%">1.</td>
												<td width="20%">Luas Bangunan Tempat Usaha</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="280"><asp:label id="LBL_AREA" Runat="server"></asp:label><asp:label id="Label7" Runat="server">M2</asp:label></td>
											</tr>
											<tr height="40">
												<td width="1%">2.</td>
												<td width="20%">Status Kepemilikan</td>
												<td width="2%">:</td>
												<td><asp:radiobuttonlist id="RDO_STATUS" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
														Width="200 px" Enabled="False">
														<asp:ListItem Value="0">Milik Sendiri</asp:ListItem>
														<asp:ListItem Value="1">Sewa</asp:ListItem>
													</asp:radiobuttonlist></td>
											</tr>
											<tr height="40">
												<td width="1%">3.</td>
												<td width="20%">Lama Menempati Gedung</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="280"><asp:label id="OWN_AGE" Runat="server"></asp:label><asp:label id="Label9" Runat="server">tahun. Sejak tahun</asp:label>&nbsp;<asp:label id="SINCE" Runat="server"></asp:label></td>
											</tr>
											<tr height="40">
												<td width="1%">4.</td>
												<td width="20%">Alamat Cabang</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="280"><asp:label id="ALAMAT_CABANG1" Runat="server"></asp:label></td>
											</tr>
											<tr height="40">
												<td style="HEIGHT: 40px" width="1%"></td>
												<td style="HEIGHT: 40px" width="20%"></td>
												<td style="HEIGHT: 40px" width="2%"></td>
												<td style="WIDTH: 208px; HEIGHT: 40px" width="280"><asp:label id="ALAMAT_CABANG2" Runat="server"></asp:label></td>
											</tr>
											<tr height="40">
												<td width="1%">5.</td>
												<td width="20%">Kontak Person Cabang</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="280"><asp:label id="CP1" Runat="server"></asp:label>&nbsp;&nbsp;<asp:label id="CP2" Runat="server"></asp:label>&nbsp;&nbsp;<asp:label id="CP3" Runat="server"></asp:label></td>
											</tr>
											<tr height="40">
												<td width="1%">6.</td>
												<td width="20%">Jumlah Tenaga Kerja</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="280"><asp:label id="EMPLOYEE" Runat="server"></asp:label>&nbsp;<asp:label id="Label17" Runat="server">Orang</asp:label></td>
											</tr>
											<tr height="20">
												<td width="1%"></td>
												<td width="20%"></td>
												<td width="2%"></td>
												<td style="WIDTH: 500px" width="500"><asp:label id="EXPERT" Runat="server"></asp:label>&nbsp;<asp:label id="Label19" Runat="server">Tenaga Ahli</asp:label>&nbsp;&nbsp;&nbsp;<asp:label id="ADMIN" Runat="server"></asp:label>&nbsp;<asp:label id="Label21" Runat="server">Admin</asp:label>&nbsp;&nbsp;&nbsp;<asp:label id="OUTSOURCE" Runat="server"></asp:label>&nbsp;<asp:label id="Label23" Runat="server">Tidak Tetap</asp:label>
												</td>
											</tr>
											<tr height="40">
												<td width="1%">7.</td>
												<td width="20%">Peralatan Kantor</td>
												<td width="2%">:</td>
												<td><asp:radiobuttonlist id="RDO_EQUITMENT" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
														Width="280 px" Enabled="False">
														<asp:ListItem Value="0">Memadai</asp:ListItem>
														<asp:ListItem Value="1">Tidak Memadai</asp:ListItem>
													</asp:radiobuttonlist></td>
											</tr>
											<tr height="40">
												<td width="1%">8.</td>
												<td width="20%">Sistem Database yang Dimiliki</td>
												<td width="2%">:</td>
												<td><asp:radiobuttonlist id="RDO_DB" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="280 px"
														Enabled="False">
														<asp:ListItem Value="0">Mempunyai</asp:ListItem>
														<asp:ListItem Value="1">Tidak Mempunyai</asp:ListItem>
													</asp:radiobuttonlist></td>
											</tr>
											<tr height="40">
												<td width="1%">9.</td>
												<td width="20%">Kondisi Gedung</td>
												<td width="2%">:</td>
												<td><asp:radiobuttonlist id="RDO_BUILDING" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
														Width="280 px" Enabled="False">
														<asp:ListItem Value="0">Rumah</asp:ListItem>
														<asp:ListItem Value="1">Ruko</asp:ListItem>
														<asp:ListItem Value="2">Gedung</asp:ListItem>
													</asp:radiobuttonlist></td>
											</tr>
											<tr height="40">
												<td width="1%">10.</td>
												<td width="20%">Kondisi Barang Arsip</td>
												<td width="2%">:</td>
												<td><asp:radiobuttonlist id="ARSIP_ROOM" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
														Width="280 px" Enabled="False">
														<asp:ListItem Value="0">Mempunyai</asp:ListItem>
														<asp:ListItem Value="1">Tidak Mempunyai</asp:ListItem>
													</asp:radiobuttonlist></td>
											</tr>
											<tr height="40">
												<td width="1%">11.</td>
												<td width="20%">Kegiatan yang sedang dilakukan</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="280"><asp:label id="ACTIVITY1" Runat="server"></asp:label></td>
											</tr>
											<tr height="40">
												<td width="1%"></td>
												<td width="20%"></td>
												<td width="2%"></td>
												<td style="WIDTH: 208px" width="280"><asp:label id="ACTIVITY2" Runat="server"></asp:label></td>
											</tr>
											<tr height="40">
												<td width="1%">12.</td>
												<td width="20%">Kesimpulan/pendapat</td>
												<td width="2%">:</td>
												<td style="WIDTH: 208px" width="280"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table width="100%">
								<tr>
									<td class="td">
										<table width="100%">
											<tr class="tdHeader">
												<td class="td" style="HEIGHT: 21px" align="center" width="50%"><STRONG>Materi</STRONG></td>
												<td class="td" style="HEIGHT: 21px" align="center" width="10%"><STRONG>Bobot (%)</STRONG></td>
												<td class="td" style="HEIGHT: 21px" align="center" width="6%"><STRONG>1</STRONG></td>
												<td class="td" style="HEIGHT: 21px" align="center" width="6%"><STRONG>2</STRONG></td>
												<td class="td" style="HEIGHT: 21px" align="center" width="6%"><STRONG>3</STRONG></td>
												<td class="td" style="HEIGHT: 21px" align="center" width="6%"><STRONG>4</STRONG></td>
												<td class="td" style="HEIGHT: 21px" align="center" width="6%"><STRONG>5</STRONG></td>
												<td class="td" style="HEIGHT: 21px" align="center" width="10%"><STRONG>Total</STRONG></td>
											</tr>
											<tr>
												<td width="50%">a. Kesesuaian Alamat</td>
												<td align="center" width="10%">10</td>
												<td width="6%"><asp:label id="A1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="A2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="A3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="A4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="A5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="10%"><asp:label id="SC_ADD" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="50%">b. Kelayakan Sarana &amp;prasarana</td>
												<td align="center" width="10%">20</td>
												<td width="6%"><asp:label id="B1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="B2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="B3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="B4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="B5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="10%"><asp:label id="SC_SARANA" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="50%">c. Kelayakan Database</td>
												<td align="center" width="10%">15</td>
												<td width="6%"><asp:label id="C1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="C2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="C3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="C4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="C5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="10%"><asp:label id="SC_DATABASE" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="50%">d. Kelayakan Ruang Arsip, Sistem Penataan Arsip</td>
												<td align="center" width="10%">15</td>
												<td width="6%"><asp:label id="D1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="D2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="D3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="D4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="D5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="10%"><asp:label id="SC_EQUITMENT" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="50%">e. Kelayakan Kondisi Gedung</td>
												<td align="center" width="10%">15</td>
												<td width="6%"><asp:label id="E1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="E2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="E3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="E4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="E5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="10%"><asp:label id="SC_BUILDING" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td width="50%">f. Kelayakan Jumlah Tenaga Kerja</td>
												<td align="center" width="10%">25</td>
												<td width="6%"><asp:label id="F1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="F2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="F3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="F4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="6%"><asp:label id="F5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
												<td width="10%"><asp:label id="SC_RESOURCE" Runat="server"></asp:label></td>
											</tr>
											<tr>
												<td align="center" width="50%"></td>
												<td align="center" width="10%"><asp:label id="A" Runat="server" Visible="False"></asp:label></td>
												<td width="6%"></td>
												<td width="6%"></td>
												<td width="6%"></td>
												<td width="6%"></td>
												<td width="6%"></td>
												<td width="10%"></td>
											</tr>
											<tr>
												<td class="td" align="center" width="50%">Total</td>
												<td class="td" align="center" width="10%"></td>
												<td class="td" width="6%"></td>
												<td class="td" width="6%"></td>
												<td class="td" width="6%"></td>
												<td class="td" width="6%"></td>
												<td class="td" width="6%"></td>
												<td class="td" width="10%"><asp:label id="SC_TOT" Runat="server"></asp:label></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td>
							<table width="100%">
								<tr>
									<td class="td">
										<table width="100%">
											<tr>
												<td width="50%" class="td">
													<P>Mengetahui,</P>
													<P>Pelaksana</P>
													<P>&nbsp;</P>
													<P>&nbsp;</P>
													<P>&nbsp;</P>
													<P>(.................................)</P>
												</td>
												<td width="50%" class="td">
													<P>Dibuat oleh:</P>
													<P>&nbsp;</P>
													<P>&nbsp;</P>
													<P>&nbsp;</P>
													<P>&nbsp;</P>
													<P>(.................................)</P>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
