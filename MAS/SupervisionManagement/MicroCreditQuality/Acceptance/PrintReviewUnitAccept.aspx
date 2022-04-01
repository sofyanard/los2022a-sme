<%@ Page language="c#" Codebehind="PrintReviewUnitAccept.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.MicroCreditQuality.Acceptance.PrintReviewUnitAccept" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PrintReviewUnitAccept</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
		function print_frame() 
		{
			//window.parent.framelkkn.focus();
			tr_print.style.display = "none";
			window.print();
			tr_print.style.display = "";
		}		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="570">
					<tr id="tr_print" align="center">
						<td width="3%" colSpan="2"><INPUT class="button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
								name="BTN_PRINT"><INPUT class="button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
								value="Back" name="BTN_BACK">
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">District</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DISTRICT" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Cluster</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CLUSTER" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Unit / Cabang</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_UNIT_CABANG" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Tahun Pembukaan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_THN_PEMBUKAAN" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Jumlah Sales Outlet</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JUM_SO" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Tgl. Kunjungan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KUNJUNGAN1" runat="server" MaxLength="2"
											Width="24px" Columns="4" ReadOnly="True"></asp:textbox><asp:dropdownlist id="DDL_BLN_KUNJUNGAN1" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KUNJUNGAN1" runat="server" MaxLength="4"
											Width="36px" Columns="4" ReadOnly="True"></asp:textbox>&nbsp;to&nbsp;
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KUNJUNGAN2" runat="server" MaxLength="2"
											Width="24px" Columns="4" ReadOnly="True"></asp:textbox><asp:dropdownlist id="DDL_BLN_KUNJUNGAN2" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KUNJUNGAN2" runat="server" MaxLength="4"
											Width="36px" Columns="4" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">DETAIL INFORMATION</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" width="18%">Nama Sales Outlet</TD>
									<TD width="1%">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO1" runat="server" MaxLength="100" Width="140px"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO2" runat="server" MaxLength="100" Width="140px"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO3" runat="server" MaxLength="100" Width="140px"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO4" runat="server" MaxLength="100" Width="140px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="5">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" vAlign="middle" width="18%">Lokasi SO (Jarak dari MBU)</TD>
									<TD width="1%">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO1" runat="server" Width="140px" AutoPostBack="True" RepeatDirection="Vertical"
											Enabled="False">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO2" runat="server" Width="140px" AutoPostBack="True" RepeatDirection="Vertical"
											Enabled="False">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO3" runat="server" Width="140px" AutoPostBack="True" RepeatDirection="Vertical"
											Enabled="False">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO4" runat="server" Width="140px" AutoPostBack="True" RepeatDirection="Vertical"
											Enabled="False">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Daftar Pegawai Unit :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_PEGAWAI" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="unit_seq" HeaderText="unit_seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nip" HeaderText="NIP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nama_pegawai" HeaderText="Nama Pegawai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="jabatan" HeaderText="Jabatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="bergabung_sejak" HeaderText="Bergabung Sejak">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="status_kepegawaian" HeaderText="Status Kepegawaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="catatan" HeaderText="Catatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td><asp:label id="TXT_SEQ1" Visible="False" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Portfolio Kelolaan MKS :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_MKS" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="unit_seq" HeaderText="unit_seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nip" HeaderText="NIP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nama_pegawai" HeaderText="Nama Pegawai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="bergabung_sejak" HeaderText="Bergabung Sejak">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="status_kepegawaian" HeaderText="Status Kepegawaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="bade_kelolaan" HeaderText="Bade Kelolaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="kol_lancar" HeaderText="Kol. Lancar">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="dpd_30" HeaderText="DPD 30 +">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="npl" HeaderText="NPL">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td><asp:label id="TXT_SEQ2" Visible="False" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Portfolio Unit / Cabang per tanggal&nbsp;:</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_POTFOLIO_UNIT" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="unit_seq" HeaderText="unit_seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="produk" HeaderText="Produk">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="jum_debitur" HeaderText="Jumlah Debitur">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="baki_debet" HeaderText="Baki Debet">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="kolek_lancar" HeaderText="Kolektibilitas Lancar (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="dpd_30_plus" HeaderText="DPD 30+ (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="npl" HeaderText="NPL (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="fr_to_x" HeaderText="FR To X">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="fr_to_30" HeaderText="FR To 30">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="fr_to_60" HeaderText="FR To 60">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="fr_to_90" HeaderText="FR To 90">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td><asp:label id="TXT_SEQ3" Runat="server" Visible="False"></asp:label></td>
					</tr>
				</TABLE>
				<table>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="2">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Kualitas Supervisi / Monitoring MMM :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="3%">1.</TD>
									<TD width="82%">Buku Harian MKS dimiliki oleh seluruh MKS</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM1" runat="server" Width="100%" RepeatDirection="Horizontal" AutoPostBack="True"
											Enabled="False">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">2.</TD>
									<TD width="82%">MMM melakukan monitoring harian penggunaan Buku Harian dengan 
										memberikan pada kolom paraf yang terdapat dalam Buku Harian MKS. (Pedoman 
										Penggunaan Buku Harian MKS dapat dilihat dalam Surat No. MRB.MBD/SSM.287/2011 
										tanggal 27 April 2011 Perihal Implementasi Buku Harian MKS dalam Rangka 4DP 
										Bisnis Mikro)
									</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM2" runat="server" Width="100%" RepeatDirection="Horizontal" AutoPostBack="True"
											Enabled="False">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">3.</TD>
									<TD width="82%">Buku Kendali Agunan yang Diserahkan Debitur</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM3" runat="server" Width="100%" RepeatDirection="Horizontal" AutoPostBack="True"
											Enabled="False">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">4.</TD>
									<TD width="82%">Buku Kendali Monitoring Pending Notaris</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM4" runat="server" Width="100%" RepeatDirection="Horizontal" AutoPostBack="True"
											Enabled="False">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">5.</TD>
									<TD width="82%">Buku Kendali Monitoring Penerbitan Polis Asuransi</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM5" runat="server" Width="100%" RepeatDirection="Horizontal" AutoPostBack="True"
											Enabled="False">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">6.</TD>
									<TD width="82%">Buku Kendali Pencairan Kredit</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM6" runat="server" Width="100%" RepeatDirection="Horizontal" AutoPostBack="True"
											Enabled="False">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
				</table>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Permasalahan yang Perlu Mendapatkan Perhatian :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="3%">1.</TD>
									<TD width="97%">Pemberian kredit yang terindikasi menyimpang dan melanggar 
										ketentuan code of conduct</TD>
								</TR>
								<TR>
									<TD align="center" width="3%"></TD>
									<TD width="97%"><asp:textbox id="TXT_PERMASALAHAN1" Width="100%" TextMode="MultiLine" Runat="server" ReadOnly="True"
											></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">2.</TD>
									<TD width="97%">Informasi Lain Yang Perlu Mendapat Perhatian (DMTL)</TD>
								</TR>
								<TR>
									<TD align="center" width="3%"></TD>
									<TD width="97%"><asp:textbox id="TXT_PERMASALAHAN2" Width="100%" TextMode="MultiLine" Runat="server" ReadOnly="True"
											></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">3.</TD>
									<TD width="97%">Rekomendasi Perbaikan</TD>
								</TR>
								<TR>
									<TD align="center" width="3%"></TD>
									<TD width="97%"><asp:textbox id="TXT_PERMASALAHAN3" Width="100%" TextMode="MultiLine" Runat="server" ReadOnly="True"
											></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%">Demikian Laporan Supervisi kami susun dengan sebenarnya 
										berdasarkan review on desk dan on site yang kami lakukan</TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<td></td>
					</tr>
				</table>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<TD class="td" vAlign="top" width="33%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%">Dibuat Oleh</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%">Diketahui Oleh</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="34%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%">Diketahui Oleh</TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="33%" colSpan="3">
						<BR>
							<BR>
							<BR>
							<BR>
							<BR>
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIBUAT_OLEH" runat="server" Width="300px"
											MaxLength="100" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
						<BR>
							<BR>
							<BR>
							<BR>
							<BR>
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIKETAHUI_OLEH1" runat="server" Width="300px"
											MaxLength="100" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="34%">
						<BR>
							<BR>
							<BR>
							<BR>
							<BR>
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIKETAHUI_OLEH2" runat="server" Width="300px"
											MaxLength="100" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
