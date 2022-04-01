<%@ Page language="c#" Codebehind="PrintWawancara.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.PrintWawancara" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintWawancara</title>
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
			<table id="Table21" cellSpacing="0" cellPadding="1" width="100%">
				<tr>
					<td class="td">
						<table>
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
								<td class="td"><STRONG>LAPORAN HASIL WAWANCARA</STRONG></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table id="Table1" cellSpacing="0" cellPadding="1" width="100%">
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
											<td width="30%">Tanggal Wawancara</td>
											<td width="4%">:</td>
											<td style="WIDTH: 208px" width="208"><asp:label id="TGL_WAWANCARA" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td width="30%">Peserta</td>
											<td width="4%">:</td>
											<td style="WIDTH: 208px" width="208"><asp:label id="PESERTA1" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td width="30%"></td>
											<td width="4%"></td>
											<td style="WIDTH: 208px" width="208"><asp:label id="PESERTA2" Runat="server"></asp:label></td>
										</tr>
										<tr>
											<td width="30%"></td>
											<td width="4%"></td>
											<td style="WIDTH: 208px" width="208"><asp:label id="PESERTA3" Runat="server"></asp:label></td>
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
							<tr align="left">
								<td class="td"><STRONG>1. Non Substansi Presentasi</STRONG></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr class="tdHeader">
								<td class="td" width="5%">No</td>
								<td class="td" align="center" width="45%"><STRONG>Materi</STRONG></td>
								<td class="td" align="center" width="10%"><STRONG>Bobot (%)</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>1</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>2</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>3</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>4</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>5</STRONG></td>
								<td class="td" align="center" width="10%"><STRONG>Total</STRONG></td>
							</tr>
							<tr>
								<td align="center" width="5%">1.</td>
								<td width="45%">Ketepatan waktu (kehadiran) dan alokasi waktu yang disediakan</td>
								<td align="center" width="10%">20</td>
								<td width="6%"><asp:label id="A1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="A2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="A3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="A4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="A5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="NONS_TIME" Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="center" width="5%">2.</td>
								<td width="45%">Persiapan presentasi, (Sarana &amp;prasarana)</td>
								<td align="center" width="10%">20</td>
								<td width="6%"><asp:label id="B1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="B2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="B3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="B4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="B5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="NONS_PREPARE" Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="center" width="5%">3.</td>
								<td width="45%">Kemampuan dalam penyampaian materi presentasi dan menjawab 
									pertanyaan</td>
								<td align="center" width="10%">60</td>
								<td width="6%"><asp:label id="C1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="C2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="C3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="C4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="C5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="NONS_DELIVARY" Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td width="5%"></td>
								<td align="left" width="45%"></td>
								<td align="center" width="10%"></td>
								<td width="6%"></td>
								<td width="6%"></td>
								<td width="6%"></td>
								<td width="6%"></td>
								<td width="6%"></td>
								<td width="10%"></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td class="td" width="70%">Sub-Total I (Score x 30%)</td>
								<td class="td" width="30%"><asp:label id="NONS_TOT" Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr align="left">
								<td class="td"><STRONG>2. Substansi Presentasi</STRONG></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr class="tdHeader">
								<td class="td" width="5%">No</td>
								<td class="td" align="center" width="45%"><STRONG>Materi</STRONG></td>
								<td class="td" align="center" width="10%"><STRONG>Bobot (%)</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>1</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>2</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>3</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>4</STRONG></td>
								<td class="td" align="center" width="6%"><STRONG>5</STRONG></td>
								<td class="td" align="center" width="10%"><STRONG>Total</STRONG></td>
							</tr>
							<tr>
								<td align="center" width="5%">1.</td>
								<td width="45%">Pengalaman kerja/ keahlian khusus calon rekanan</td>
								<td align="center" width="10%">30</td>
								<td width="6%"><asp:label id="D1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="D2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="D3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="D4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="D5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="S_EXPERIAN" Runat="server"></asp:label></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="5%"></td>
								<td width="45%">Komentar :</td>
								<td width="50%">
									<P><asp:label id="COMENT1" Runat="server"></asp:label></P>
									<P>&nbsp;</P>
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td align="center" width="5%">2.</td>
								<td width="45%">Kondisi tenaga ahli/ tenaga kerja Calon Rekanan</td>
								<td align="center" width="10%">30</td>
								<td width="6%"><asp:label id="E1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="E2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="E3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="E4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="E5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="S_EXPERT" Runat="server"></asp:label></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="5%"></td>
								<td width="45%">Komentar :</td>
								<td width="50%">
									<P><asp:label id="COMENT2" Runat="server"></asp:label></P>
									<P>&nbsp;</P>
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td align="center" width="5%">3.</td>
								<td width="45%">Pengendalian mutu yang dimiliki oleh calon rekanan</td>
								<td align="center" width="10%">20</td>
								<td width="6%"><asp:label id="F1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="F2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="F3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="F4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="F5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="S_MUTU" Runat="server"></asp:label></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="5%"></td>
								<td width="45%">Komentar :</td>
								<td width="50%">
									<P><asp:label id="COMENT3" Runat="server"></asp:label></P>
									<P>&nbsp;</P>
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td align="center" width="5%">4.</td>
								<td width="45%">Daya saing biaya yang dikenakan dalam mengerjakan suatu proyek/ 
									pekerjaan dibandingkan dengan perusahaan lain</td>
								<td align="center" width="10%">10</td>
								<td width="6%"><asp:label id="G1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="G2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="G3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="G4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="G5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="S_COST" Runat="server"></asp:label></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="5%"></td>
								<td width="45%">Komentar :</td>
								<td width="50%">
									<P><asp:label id="COMENT4" Runat="server"></asp:label></P>
									<P>&nbsp;</P>
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td align="center" width="5%">5.</td>
								<td width="45%">Lain-lain (kerjasama dengan istansi lain, organisasi asing, 
									jaringan kerja)</td>
								<td align="center" width="10%">10</td>
								<td width="6%"><asp:label id="H1" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="H2" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="H3" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="H4" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="6%"><asp:label id="H5" Runat="server" Visible="False">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;X</asp:label></td>
								<td width="10%"><asp:label id="S_OTHERS" Runat="server"></asp:label></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="5%"></td>
								<td width="45%">Komentar :</td>
								<td width="50%">
									<P><asp:label id="COMENT5" Runat="server"></asp:label></P>
									<P>&nbsp;</P>
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="5%"></td>
								<td width="45%"></td>
								<td width="50%"><asp:label id="Label1" Runat="server"></asp:label></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="5%"></td>
								<td vAlign="top" width="45%">Catatan Khusus :</td>
								<td width="50%" height="400">
									<P><asp:label id="CAT" Runat="server"></asp:label></P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>									
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td class="td" width="70%">Sub-Total Score II (Score x 70%)</td>
								<td class="td" width="30%"><asp:label id="S_TOT" Runat="server"></asp:label></td>
							</tr>
							<tr>
								<td class="td" width="70%">Total Score (Total I + Total II)</td>
								<td class="td" width="30%"><asp:label id="SC_TOTAL" Runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr>
								<td class="td" width="100%">
									<P>- Penilaian: 1=Kurang Sekali 2=Kurang 3=Cukup 4=Baik 5=Baik Sekali</P>
									<P>- Hasil wawancara score &gt; 3 dilanjutkan ke tahap berikutnya</P>
									<P>- Hasil wawancara score &lt; 3 tidak dapat ditindaklanjuti ke tahap berikutnya</P>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr>
								<td class="td" width="50%">
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
			</TD></TR></TABLE></form>
	</body>
</HTML>
