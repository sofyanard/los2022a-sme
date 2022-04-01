<%@ Page language="c#" Codebehind="EditNasabah.aspx.cs" AutoEventWireup="True" Inherits="SME.Assignment.Channeling.EditNasabah" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- aaa -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fSppkMonitor" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<TD class="tdNoBorder" style="WIDTH: 805px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Edit Info Nasabah</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<A href="UploadData.aspx?curef=<%=Request.QueryString["curef"]%>&mc=<%=Request.QueryString["mc"]%>&tc=<%=Request.QueryString["tc"]%>"><IMG src="../../Image/back.jpg"></IMG></a>
							<A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</tr>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table width="100%">
								<tr>
									<td>
										<TABLE class="td" id="Table1" height="35" cellSpacing="1" cellPadding="1" width="100%"
											border="1">
											<TR>
												<TD class="tdHeader1" colSpan="6">Data CIF</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Nama Pemohon</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox1" runat="server" Width="100%"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Jenis Alamat</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList1" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Alamat</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox3" runat="server" Width="100%"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Pendidikan Terakhir</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList2" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kota</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox5" runat="server" Width="100%"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Bidang Usaha</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList3" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kode Pos</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox7" runat="server" Width="88px"></asp:TextBox>
													<asp:Button id="Button9" runat="server" Text="Search"></asp:Button>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Berdiri Sejak</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox14" runat="server" Width="32px"></asp:TextBox>
													<asp:DropDownList id="DropDownList9" runat="server" Width="112px"></asp:DropDownList>
													<asp:TextBox id="TextBox16" runat="server" Width="72px"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kepemilikan Rumah</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:DropDownList id="DropDownList10" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">NPWP</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox2" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">No. Telepon</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox9" runat="server" Width="48px"></asp:TextBox>
													<asp:TextBox id="TextBox11" runat="server" Width="136px"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Jumlah Karyawan</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox4" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Tempat Lahir</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox13" runat="server" Width="100%"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Nama Ibu Kandung</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox6" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Tanggal Lahir</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox18" runat="server" Width="32px"></asp:TextBox>
													<asp:DropDownList id="DropDownList11" runat="server" Width="112px"></asp:DropDownList>
													<asp:TextBox id="TextBox15" runat="server" Width="72px"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Nama Pelaporan</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox8" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Status Perkawinan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:DropDownList id="DropDownList12" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Negara Domisili</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList4" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Jenis Kelamin</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:DropDownList id="DropDownList13" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Net Income</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox10" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">No. KTP</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox17" runat="server" Width="100%"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Lokasi Pabrik/Kebun/Proyek</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList5" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Tanggal Berakhir KTP</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox20" runat="server" Width="32px"></asp:TextBox>
													<asp:DropDownList id="DropDownList14" runat="server" Width="112px"></asp:DropDownList>
													<asp:TextBox id="TextBox19" runat="server" Width="72px"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Key Person</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox12" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR valign="top">
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 3px">Alamat KTP</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 3px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px; HEIGHT: 3px">
													<asp:TextBox id="TextBox21" runat="server" Width="100%" TextMode="MultiLine" Height="64px"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 3px">Lokasi DATI II</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 3px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 3px">
													<asp:DropDownList id="DropDownList6" runat="server" Width="100%" Height="27px"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 15px">Kota</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 15px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px; HEIGHT: 15px">
													<asp:TextBox id="TextBox22" runat="server" Width="100%"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 15px">Kewarganegaraan</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px">
													<asp:DropDownList id="DropDownList7" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kode Pos</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px">
													<asp:TextBox id="TextBox23" runat="server" Width="88px"></asp:TextBox>
													<asp:Button id="Button10" runat="server" Text="Search"></asp:Button>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Hubungan Nasabah BM</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList8" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7">
													<asp:button id="Button1" runat="server" CssClass="Button1" Width="100px" Text="SAVE"></asp:button>
													<asp:button id="Button2" runat="server" CssClass="Button1" Width="100px" Text="CLEAR"></asp:button>
												</TD>
											</TR>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td>
										<table width="100%">
											<tr>
												<TD class="tdHeader1" colSpan="7">Ketentuan Kedit/Struktur Kredit</TD>
											</tr>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Perihal/Jenis Permohonan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 305px">
													<asp:DropDownList id="DropDownList15" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Limit</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox24" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Jenis Pengajuan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 305px">
													<asp:DropDownList id="DropDownList16" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Exchange Rate to Rp</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox25" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Jenis Kredit</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 305px">
													<asp:DropDownList id="DropDownList17" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Jangka Waktu</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox26" runat="server" Width="32px"></asp:TextBox>
													<asp:Label id="Label1" runat="server">Bulan</asp:Label>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Tujuan Penggunaan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 305px">
													<asp:DropDownList id="DropDownList18" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%"></TD>
												<TD style="WIDTH: 1.31%"></TD>
												<TD class="TDBGColorValue">
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7">
													<asp:button id="Button3" runat="server" CssClass="Button1" Width="100px" Text="SAVE"></asp:button>
													<asp:button id="Button4" runat="server" CssClass="Button1" Width="100px" Text="CLEAR"></asp:button>
												</TD>
											</TR>
										</table>
									</td>
								</tr>
								<tr id="DATA_JAMINAN_TR" runat="server">
									<td>
										<table width="100%">
											<tr>
												<TD class="tdHeader1" colSpan="7">Data Agunan</TD>
											</tr>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Keterangan Jaminan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px">
													<asp:TextBox id="TextBox27" runat="server" Width="100%"></asp:TextBox>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Nilai Bank</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox28" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Bukti Kepemilikan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px">
													<asp:DropDownList id="DropDownList31" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Nilai Pasar</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox30" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Bentuk Pengikatan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px">
													<asp:DropDownList id="DropDownList30" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Tanggal Penilaian</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox32" runat="server" Width="32px"></asp:TextBox>
													<asp:DropDownList id="DropDownList32" runat="server" Width="112px"></asp:DropDownList>
													<asp:TextBox id="TextBox31" runat="server" Width="72px"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Currency</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px">
													<asp:DropDownList id="DropDownList29" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Penilaian Oleh</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:TextBox id="TextBox29" runat="server" Width="100%"></asp:TextBox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7">
													<asp:button id="Button5" runat="server" CssClass="Button1" Width="100px" Text="SAVE"></asp:button>
													<asp:button id="Button6" runat="server" CssClass="Button1" Width="100px" Text="CLEAR"></asp:button>
												</TD>
											</TR>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table width="100%">
											<tr>
												<TD class="tdHeader1" colSpan="7">Sandi BI</TD>
											</tr>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 17px">Jenis Penggunaan</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 17px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px; HEIGHT: 17px">
													<asp:DropDownList id="DropDownList24" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 17px">Sektor Ekonomi BI 1</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 17px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 21px">
													<asp:DropDownList id="DropDownList23" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Jenis Kredit</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px">
													<asp:DropDownList id="DropDownList25" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Sektor Ekonomi BI 2</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList22" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Orientasi Penggunaan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px">
													<asp:DropDownList id="DropDownList26" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Sektor Ekonomi BI 3</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList21" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Sifat Kredit</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px">
													<asp:DropDownList id="DropDownList27" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Sektor Ekonomi BI 4</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList20" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Fasilitas Penyediaan Dana</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px">
													<asp:DropDownList id="DropDownList28" runat="server" Width="100%"></asp:DropDownList>
												</TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Lokasi Proyek</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DropDownList19" runat="server" Width="100%"></asp:DropDownList>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7">
													<asp:button id="Button7" runat="server" CssClass="Button1" Width="100px" Text="SAVE"></asp:button>
													<asp:button id="Button8" runat="server" CssClass="Button1" Width="100px" Text="CLEAR"></asp:button>
												</TD>
											</TR>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
