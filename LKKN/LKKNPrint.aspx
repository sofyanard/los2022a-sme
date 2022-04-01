<%@ Page language="c#" Codebehind="LKKNPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.LKKN1.LKKNPrint" buffer="True"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Laporan Kontak dan Kunjungan Nasabah</title>
		<script language="javascript">
function print_frame() {
	//window.parent.framelkkn.focus();
	tr_print.style.display = "none";
	window.print();
	tr_print.style.display = "";
}
		</script>
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY leftMargin="0" topMargin="0">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- #include file="../include/cek_all.html" -->
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="650" align="left" border="1">
					<TBODY>
						<TR id="tr_print">
							<TD width="3%" class="TDBGColor2" colSpan="2"><INPUT class="Button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
									name="BTN_PRINT"><INPUT class="Button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
									value="Back" name="BTN_BACK"></TD>
						</TR>
						<TR>
							<TD align="right" colSpan="2">CBC/Hub/Comm. Branch :
								<asp:label id="LBL_BRANCH" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD align="center" width="3%" colSpan="2"><STRONG>LAPORAN KONTAK DAN KUNJUNGAN NASABAH</STRONG></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								width="3%" colSpan="2">
								<TABLE id="Table9" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: solid"
									cellSpacing="0" cellPadding="0" width="100%" border="2">
									<TR>
										<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
											width="50%">
											<TABLE id="Table10" width="100%">
												<TR>
													<TD width="40%">Nama Nasabah</TD>
													<TD width="1%">:</TD>
													<TD width="59%"><asp:label id="LBL_CUST_NAME" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD width="40%">Alamat</TD>
													<TD width="1%">:</TD>
													<TD width="59%"><asp:label id="LBL_CU_ADDR1" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD width="40%">No. Telp</TD>
													<TD width="1%">:</TD>
													<TD width="59%"><asp:label id="LBL_CU_PHN" runat="server"></asp:label></TD>
												</TR>
											</TABLE>
										</TD>
										<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
											width="50%">
											<TABLE id="Table11" width="100%">
												<TR>
													<TD width="40%">Tgl. Kunjungan</TD>
													<TD width="1%">:</TD>
													<TD width="59%"><asp:label id="LBL_VISITDATE" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD width="40%">Business Officer</TD>
													<TD width="1%">:</TD>
													<TD width="59%"><asp:label id="LBL_BO" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD width="40%">Contact Person</TD>
													<TD width="1%">:</TD>
													<TD width="59%"><asp:label id="LBL_CONTACTPERSON" runat="server"></asp:label></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 19px" colSpan="2"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								width="3%"><STRONG><FONT size="2">1.</FONT></STRONG></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								width="85%"><STRONG style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"><FONT size="2">Observasi 
										Aspek Manajemen</FONT></STRONG></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								width="3%" height="23"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								width="85%" colSpan="1" height="23" rowSpan="1" Font-Bold="True"><b style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">a. 
									Susunan Pengurus :</b></TD>
						</TR>
						<TR>
							<TD align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="85%"><asp:datagrid id="DATAGRID1" BorderColor="Black" HorizontalAlign="Center" CellPadding="1" PageSize="1"
									AutoGenerateColumns="False" Runat="server" Width="100%">
									<SelectedItemStyle></SelectedItemStyle>
									<EditItemStyle></EditItemStyle>
									<AlternatingItemStyle></AlternatingItemStyle>
									<ItemStyle></ItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="NO">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LP_NAMA" HeaderText="Nama">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LP_JABATAN" HeaderText="Jabatan">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LP_JMLSAHAM" HeaderText="Jumlah saham (%)">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LP_PENDIDIKAN" HeaderText="Pendidikan terakhir">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LP_BLACKLIST" HeaderText="Daftar hitam (Y/T)">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD align="left" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%" Font-Bold="True"><b>b. Kualitas Manajemen :</b></TD>
						</TR>
						<TR>
							<TD align="center" width="3%"></TD>
							<TD align="center" width="85%">
								<TABLE class="td" id="Table1" style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
									width="100%" border="0">
									<TR>
										<TD width="40%" style="HEIGHT: 23px">Pengalaman Usaha</TD>
										<TD width="1%" style="HEIGHT: 23px">:</TD>
										<TD width="59%" style="HEIGHT: 23px"><asp:checkboxlist id="CBL_KM_PENGALAMAN" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">&gt; 5 tahun</asp:ListItem>
												<asp:ListItem Value="2">2-5 tahun</asp:ListItem>
												<asp:ListItem Value="3">&lt; 2 tahun</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD width="40%">Administrasi pencatatan transaksi keuangan</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:checkboxlist id="CBL_KM_ADMKEUANGAN" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">baik</asp:ListItem>
												<asp:ListItem Value="2">kurang baik</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD width="40%">Kualifikasi keahlian teknik</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:checkboxlist id="CBL_KM_KUALIFIKASI" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">memadai</asp:ListItem>
												<asp:ListItem Value="2">kurang memadai</asp:ListItem>
												<asp:ListItem Value="3">tidak memadai</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD width="40%">Lain-lain</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:label id="LBL_KM_LAIN" runat="server" Width="100%"></asp:label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"><STRONG><FONT size="2">2.</FONT></STRONG></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><STRONG><FONT size="2">Observasi Pribadi Pemohon/Pengurus</FONT></STRONG></TD>
						</TR>
						<TR>
							<TD align="center" width="3%" style="HEIGHT: 136px"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 136px; BORDER-BOTTOM-STYLE: none"
								align="center" width="85%">
								<TABLE class="td" id="Table2" style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
									width="100%">
									<TR>
										<TD width="40%">Sifat</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:checkboxlist id="CBL_OP_SIFAT" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Terbuka/jujur</asp:ListItem>
												<asp:ListItem Value="2">berbelit-belit</asp:ListItem>
												<asp:ListItem Value="3">tertutup</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD width="40%">Karakter</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:checkboxlist id="CBL_OP_KARAKTER" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Kooperatif</asp:ListItem>
												<asp:ListItem Value="2">Kurang kooperatif</asp:ListItem>
												<asp:ListItem Value="3">Tidak kooperatif</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD width="40%">Pengalaman</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:label id="LBL_OP_PENGALAMAN" runat="server"></asp:label>&nbsp;tahun</TD>
									</TR>
									<TR>
										<TD>Organisasi/pembagian tugas</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OP_ORGANISASI" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">ada</asp:ListItem>
												<asp:ListItem Value="2">tidak ada</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD width="40%">Lain-lain</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:label id="LBL_OP_LAIN" runat="server" Width="100%"></asp:label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"><FONT size="2"><STRONG>3.</STRONG></FONT></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><FONT size="2"><STRONG>Observasi Aspek Teknis</STRONG></FONT></TD>
						</TR>
						<TR>
							<TD align="center" width="3%"></TD>
							<TD align="center" width="85%">
								<TABLE class="td" id="Table3" style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
									width="100%">
									<TR>
										<TD width="40%">Daerah usaha</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:checkboxlist id="CBL_OAT_DAERAH" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">strategis</asp:ListItem>
												<asp:ListItem Value="2">kurang strategis</asp:ListItem>
												<asp:ListItem Value="3">tidak strategis</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD width="40%">Lokasi usaha</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:checkboxlist id="CBL_OAT_LOKASI" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Jalan raya</asp:ListItem>
												<asp:ListItem Value="2">Perumahan</asp:ListItem>
												<asp:ListItem Value="3">perkantoran</asp:ListItem>
												<asp:ListItem Value="4">Mall</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Luas tanah</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAT_LUASTANAH" runat="server"></asp:label>&nbsp;m<SUP>2</SUP>
										</TD>
									</TR>
									<TR>
										<TD>Luas Bangunan
										</TD>
										<TD></TD>
										<TD><asp:label id="LBL_OAT_LUASBGN" runat="server"></asp:label>&nbsp;m<SUP>2</SUP></TD>
									</TR>
									<TR>
										<TD>Kondisi bangunan usaha</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAT_KONDISI" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">layak</asp:ListItem>
												<asp:ListItem Value="2">Kurang layak</asp:ListItem>
												<asp:ListItem Value="3">Tidak layak</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Status bangunan tempat usaha</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAT_STATUS" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Milik sendiri</asp:ListItem>
												<asp:ListItem Value="2">Sewa</asp:ListItem>
												<asp:ListItem Value="3">lain-lain</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Utilisasi kapasitas usaha</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAT_UTILISASI" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">&lt; 50 % terpakai</asp:ListItem>
												<asp:ListItem Value="2">&gt; 50 % terpakai</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Peralatan usaha</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAT_PERALATAN" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">lengkap</asp:ListItem>
												<asp:ListItem Value="2">tidak lengkap</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Prasarana usaha</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAT_PRASARANA" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">mendukung</asp:ListItem>
												<asp:ListItem Value="2">kurang mendukung</asp:ListItem>
												<asp:ListItem Value="3">tidak mendukung</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Bahan baku</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAT_BAHANBAKU" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">tersedia</asp:ListItem>
												<asp:ListItem Value="2">cukup tersedia</asp:ListItem>
												<asp:ListItem Value="3">kurang tersedia</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Proses produksi</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAT_PROSESPROD" runat="server" Width="100%" Height="2px"></asp:label></TD>
									</TR>
									<TR>
										<TD>Suplier utama</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAT_SUPLIER" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Realisasi produksi/pembelian rata-rataper bulan</TD>
										<TD>:</TD>
										<TD>dalam kuantum
											<asp:label id="LBL_OAT_REALISASIKUAN" runat="server"></asp:label><br>
											Nilai Rp.
											<asp:label id="LBL_OAT_REALISASINILAI" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Target produksi/pembelianper bulan</TD>
										<TD>:</TD>
										<TD>dalam kuantum
											<asp:label id="LBL_OAT_TARGETKUAN" runat="server"></asp:label><br>
											Nilai Rp.
											<asp:label id="LBL_OAT_TARGETNILAI" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Biaya umum &amp; Adm (inc biaya hidup)rata-rata per bulan
										</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAT_BIAYA" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Jumlah karyawan</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAT_KARYAWAN" runat="server"></asp:label>&nbsp;orang</TD>
									</TR>
									<TR>
										<TD>Lain-lain</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAT_LAIN" runat="server"></asp:label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"><STRONG><FONT size="2">4.</FONT></STRONG></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><STRONG><FONT size="2">Observasi Aspek Pemasaran</FONT></STRONG></TD>
						</TR>
						<TR>
							<TD align="center" width="3%"></TD>
							<TD align="center" width="85%">
								<TABLE class="td" id="Table4" width="100%">
									<TR>
										<TD width="40%">Produk/jasa yang ditawarkan</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:label id="LBL_OAP_PRODUK" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Prospek penjualan</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAP_PROSPEK" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">baik</asp:ListItem>
												<asp:ListItem Value="2">cukup baik</asp:ListItem>
												<asp:ListItem Value="3">kurang baik</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Pelanggan utama/pasar yang dituju</TD>
										<TD>:</TD>
										<TD>
											<asp:label id="LBL_OAP_PELANGGAN" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Tingkat persaingan</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAP_PERSAINGAN" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">bersaing</asp:ListItem>
												<asp:ListItem Value="2">cukup bersaing</asp:ListItem>
												<asp:ListItem Value="3">kurang bersaing</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Pesaing utama</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAP_PESAING" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Lokasi pesaing utama</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAP_LOKASIPESAING" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Strategi penetapan harga</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAP_HARGA" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">diatas harga pasar</asp:ListItem>
												<asp:ListItem Value="2">rata-rata harga pasar</asp:ListItem>
												<asp:ListItem Value="3">dibwh harga pasar</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Saluran distribusi</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAP_DISTRIBUSI" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">penjualan langsung</asp:ListItem>
												<asp:ListItem Value="2">via distributor/agen</asp:ListItem>
												<asp:ListItem Value="3">konsinyasi</asp:ListItem>
												<asp:ListItem Value="4">lainnya</asp:ListItem>
											</asp:checkboxlist>:
											<asp:label id="LBL_OAP_DISTRIBUSILAIN" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Sistem penjualan</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAP_PENJUALAN" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">tunai</asp:ListItem>
												<asp:ListItem Value="2">kredit</asp:ListItem>
												<asp:ListItem Value="3">lainnya</asp:ListItem>
											</asp:checkboxlist>:
											<asp:label id="LBL_OAP_PENJUALANLAIN" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Strategi promosi</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OAP_PROMOSI" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">langsung</asp:ListItem>
												<asp:ListItem Value="2">brosur/pameran</asp:ListItem>
												<asp:ListItem Value="3">media</asp:ListItem>
												<asp:ListItem Value="4">lainnya</asp:ListItem>
											</asp:checkboxlist>:
											<asp:label id="LBL_OAP_PROMOSILAIN" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Realisasi penjualan rata-rata per bulan</TD>
										<TD>:</TD>
										<TD>
											dalam kuantum
											<asp:label id="LBL_OAP_REALISASIKUAN" runat="server"></asp:label><br>
											Nilai Rp.
											<asp:label id="LBL_OAP_REALISASINILAI" runat="server"></asp:label>
										</TD>
									</TR>
									<TR>
										<TD>Target penjualanper bulan</TD>
										<TD>:</TD>
										<TD>dalam kuantum
											<asp:label id="LBL_OAP_TARGETKUAN" runat="server"></asp:label><br>
											Nilai Rp.
											<asp:label id="LBL_OAP_TARGETNILAI" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Lain-lain
										</TD>
										<TD>:</TD>
										<TD><asp:label id="LBL_OAP_LAIN" runat="server"></asp:label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"><FONT size="2"><STRONG>5.</STRONG></FONT></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><FONT size="2"><STRONG style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">Observasi 
										Aspek Keuangan</STRONG></FONT></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: inset; BORDER-RIGHT-STYLE: inset; BORDER-LEFT-STYLE: inset; TEXT-ALIGN: left; BORDER-BOTTOM-STYLE: inset"
								align="left" width="3%" bgColor="#ffffff"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; TEXT-ALIGN: left; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%" bgColor="#ffffff"><b style="BORDER-TOP-STYLE: solid">a. 
									Untuk permohonan kredit dibawah Rp 100 juta</b></TD>
						</TR>
						<TR>
							<TD align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
								align="center" width="85%">
								<TABLE class="td" id="Table5" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
									cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD width="20%" colSpan="1"><b>Posisi</b></TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_POSISI" runat="server"></asp:label></TD>
										<TD width="20%"></TD>
										<TD width="1%"></TD>
										<TD width="29%"></TD>
									</TR>
									<TR>
										<TD width="20%">- Kas dan bank</TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_KAS" runat="server"></asp:label></TD>
										<TD width="20%">- Hutang dagang</TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_HTGDAGANG" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD width="20%">- Piutang dagang</TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_PIUTANG" runat="server"></asp:label></TD>
										<TD width="20%">- Hutang bank</TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_HTGBANK" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD width="20%">- Persediaan</TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_PERSEDIAAN" runat="server"></asp:label></TD>
										<TD width="20%">- Modal/equality</TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_MODAL" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD width="20%">- Aktiva tetap</TD>
										<TD width="1%">:</TD>
										<TD width="29%"><asp:label id="LBL_OAK_AKTIVATTP" runat="server"></asp:label></TD>
										<TD width="20%"></TD>
										<TD width="1%"></TD>
										<TD width="29%"></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><b>b. Untuk permohonan kredit dibawah Rp 100 juta</b></TD>
						</TR>
						<TR>
							<TD align="left" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%">* melampirkan data laporan keuangan</TD>
						</TR>
						<TR>
							<TD align="left" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><b style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none">c. 
									Kalkulasi biaya proyek (khusus untuk permohonan KI atau KMK Kontraktor)<b> </b></b>
							</TD>
						</TR>
						<TR>
							<TD vAlign="middle" align="left" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
								vAlign="middle" align="left" width="70%"><asp:label id="LBL_OAK_BIAYAPROYEK" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD style="HEIGHT: 36px" align="left" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"><STRONG><FONT size="2">6.</FONT></STRONG></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><STRONG><FONT size="2">Observasi Barang Agunan</FONT></STRONG></TD>
						</TR>
						<TR>
							<TD align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="85%"><asp:datagrid id="DATAGRID2" BorderColor="Black" CellPadding="1" PageSize="1" AutoGenerateColumns="False"
									Runat="server" Width="100%">
									<Columns>
										<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="No">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LA_JNSAGUNAN" HeaderText="Jenis Agunan">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LA_NILAI" HeaderText="Nilai" DataFormatString="{0:0,00.00}">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LA_KETAGUNAN" HeaderText="Lokasi/type/tahun">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LA_BUKTIPEMILIK" HeaderText="Bukti kepemilikan">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LA_ATASNAMA" HeaderText="Atas nama">
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%"><FONT size="2"><STRONG>7.</STRONG></FONT></TD>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="left" width="85%"><FONT size="2"><STRONG>Observasi Lain-lain</STRONG></FONT></TD>
						</TR>
						<TR>
							<TD align="center" width="3%"></TD>
							<TD style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
								align="center" width="85%">
								<TABLE id="Table6" style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
									width="100%">
									<TR>
										<TD width="40%">Jumlah kendaraan operasional</TD>
										<TD width="1%">:</TD>
										<TD width="59%"><asp:checkboxlist id="CBL_OLL_JUMLAH" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Mobil</asp:ListItem>
												<asp:ListItem Value="2">Motor</asp:ListItem>
												<asp:ListItem Value="3">Lain-lain :</asp:ListItem>
											</asp:checkboxlist><asp:label id="LBL_OLL_JUMLAHLAIN" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD>Keadaan kendaraan operasional</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OLL_KEADAAN" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Layak</asp:ListItem>
												<asp:ListItem Value="2">cukup layak</asp:ListItem>
												<asp:ListItem Value="3">kurang layak</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
									<TR>
										<TD>Dampak sosial ekonomi &amp; amdal</TD>
										<TD>:</TD>
										<TD><asp:checkboxlist id="CBL_OLL_DAMPAK" runat="server" Enabled="False" RepeatLayout="Flow" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Layak</asp:ListItem>
												<asp:ListItem Value="2">cukup layak</asp:ListItem>
												<asp:ListItem Value="3">kurang layak</asp:ListItem>
											</asp:checkboxlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD></TD>
							<TD></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 29px; BORDER-BOTTOM-STYLE: none"
								align="left" width="3%" colSpan="2"><FONT size="2"><STRONG>Keterangan lain-lain yang 
										perlu diinformasikan</STRONG></FONT></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; HEIGHT: 29px; BORDER-BOTTOM-STYLE: solid"
								align="left" width="85%" colSpan="2"><asp:label id="LBL_KETERANGAN" runat="server"></asp:label></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 29px; BORDER-BOTTOM-STYLE: none"
								align="left" width="3%" colSpan="2"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 29px; BORDER-BOTTOM-STYLE: none"
								align="left" width="3%" colSpan="2"><FONT size="2"><STRONG>Rencana tindak lanjut dan 
										tanggal target penyelesaian</STRONG></FONT></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								align="center" width="3%" colSpan="2">
								<TABLE id="Table7" style="BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-BOTTOM-STYLE: solid"
									borderColor="black" cellSpacing="1" cellPadding="1" width="100%" border="1">
									<TR>
										<TD width="50%"><STRONG>Rencana Tindak Lanjut :</STRONG></TD>
										<TD><STRONG>Tanggal target penyelesaian :</STRONG></TD>
									</TR>
									<TR>
										<TD width="50%"><asp:label id="LBL_TINDAKLANJUT" runat="server" Width="100%" Height="100px"></asp:label></TD>
										<TD vAlign="top" align="left"><asp:label id="LBL_TARGETSELESAI" runat="server" Width="100%" Height="100px"></asp:label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: ridge; BORDER-RIGHT-STYLE: ridge; BORDER-LEFT-STYLE: ridge; BORDER-BOTTOM-STYLE: ridge"
								align="center" width="3%" colSpan="2"></TD>
						</TR>
						<TR>
							<TD style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
								vAlign="top" align="center" width="3%" colSpan="2">
								<TABLE id="Table12" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD width="10%">Mengetahui,</TD>
										<TD width="1%"></TD>
										<TD width="24%"></TD>
										<TD width="30%"></TD>
										<TD width="10%">Tanggal</TD>
										<TD width="1%">:</TD>
										<TD width="24%"><asp:label id="LBL_ENTRYDATE" runat="server" Width="100%"></asp:label></TD>
									</TR>
									<TR>
										<TD width="10%"><nobr>Atasan langsung</nobr></TD>
										<TD width="1%">:</TD>
										<TD width="24%"><asp:label id="LBL_ATASAN" runat="server" Width="100%"></asp:label></TD>
										<TD width="30%"></TD>
										<TD width="10%"><nobr>Dibuat oleh</nobr></TD>
										<TD width="1%">:</TD>
										<TD width="24%"><asp:label id="LBL_PEMBUAT" runat="server" Width="100%"></asp:label></TD>
									</TR>
									<TR height="150">
										<TD width="10%" style="HEIGHT: 50px"></TD>
										<TD width="1%" style="HEIGHT: 50px"></TD>
										<TD width="24%" style="HEIGHT: 50px"></TD>
										<TD width="30%" style="HEIGHT: 50px"></TD>
										<TD width="10%" style="HEIGHT: 50px"><nobr></nobr></TD>
										<TD width="1%" style="HEIGHT: 50px"></TD>
										<TD width="24%" style="HEIGHT: 50px"></TD>
									</TR>
									<TR>
										<TD width="10%"></TD>
										<TD width="1%"></TD>
										<TD width="24%">Tanda Tangan</TD>
										<TD width="30%"></TD>
										<TD width="10%"></TD>
										<TD width="1%"></TD>
										<TD width="24%"><NOBR>Tanda Tangan</NOBR></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
		</form>
		</CENTER>
	</BODY>
</HTML>
