<%@ Page language="c#" Codebehind="EditNasabahBackup.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.Channeling.EditNasabahBackup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- aaa -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
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
							<!-- <A href="UploadData.aspx?curef=<%=Request.QueryString["curef"]%>&mc=<%=Request.QueryString["mc"]%>&tc=<%=Request.QueryString["tc"]%>&regno=<%=Request.QueryString["regno"]%>&productid=<%=Request.QueryString["productid"]%>&aano=<%=Request.QueryString["aano"]%>&prodseq=<%=Request.QueryString["prodseq"]%>&parentregno=<%=Request.QueryString["parentregno"]%>"><IMG src="../../Image/back.jpg"></IMG></a><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A> -->
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</tr>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table width="100%">
								<tr>
									<td>
										<TABLE class="td" id="Table30" height="35" cellSpacing="1" cellPadding="1" width="100%"
											border="1">
											<TR>
												<TD class="tdHeader1" colSpan="6">Data CIF</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Nama Pemohon</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CU_FIRSTNAME_1" runat="server" Width="100%"></asp:textbox><asp:textbox id="TXT_CU_MIDDLENAME_1" runat="server" Width="100%"></asp:textbox><asp:textbox id="TXT_CU_LASTENAME_1" runat="server" Width="100%"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Jenis Alamat</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JNSALAMAT_1" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 16px">Alamat</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 16px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px; HEIGHT: 16px"><asp:textbox id="TXT_CU_ADDR_1" runat="server" Width="100%"></asp:textbox><asp:textbox id="TXT_CU_ADDR_2" runat="server" Width="100%"></asp:textbox><asp:textbox id="TXT_CU_ADDR_3" runat="server" Width="100%"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 16px">Pendidikan Terakhir</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 16px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_CU_EDUCATION_1" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kota</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CITYNAME_1" runat="server" Width="100%"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Bidang Usaha</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_BUSSTYPE_1" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kode Pos</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CU_ZIPCODE_1" runat="server" Width="88px" ontextchanged="TXT_CU_ZIPCODE_1_TextChanged"></asp:textbox><asp:button id="BTN_SEARCH_ZIPCODE_1" runat="server" Text="Search" onclick="BTN_SEARCH_ZIPCODE_1_Click"></asp:button>
													<asp:Label id="LabelIDCity1" runat="server" Visible="False">Label</asp:Label></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Berdiri Sejak</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_DOB_DAY_3" runat="server" Width="32px"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH_3" runat="server" Width="112px"></asp:dropdownlist><asp:textbox id="TXT_CU_DOB_YEAR_3" runat="server" Width="72px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kepemilikan Rumah</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:dropdownlist id="DDL_CU_HOMESTA_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">NPWP</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NPWP_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">No. Telepon</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CU_PHNAREA_1" runat="server" Width="48px"></asp:textbox><asp:textbox id="TXT_CU_PHNNUM_1" runat="server" Width="136px"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Jumlah Karyawan</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_EMPLOYEE_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Tempat Lahir</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CU_POB_1" runat="server" Width="100%"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Nama Ibu Kandung</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_MOTHER_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 23px">Tanggal Lahir</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 23px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px; HEIGHT: 23px"><asp:textbox id="TXT_CU_DOB_DAY_1" runat="server" Width="32px"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH_1" runat="server" Width="112px"></asp:dropdownlist><asp:textbox id="TXT_CU_DOB_YEAR_1" runat="server" Width="72px"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 23px">Nama Pelaporan</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 23px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox id="TXT_CU_NAMAPELAPORAN_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Status Perkawinan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:dropdownlist id="DDL_CU_MARITAL_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Negara Domisili</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_NEGARADOMISILI_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<!-- customer -->
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 21px">Jenis Kelamin</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 21px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px; HEIGHT: 21px"><asp:dropdownlist id="DDL_CU_SEX_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 21px">Net Income</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 21px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox id="TXT_CU_NETINCOME_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<!-- cust_personal -->
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">No. KTP</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CU_IDCARDNUM_1" runat="server" Width="100%"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Lokasi Pabrik/Kebun/Proyek</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_LOKASIPROYEK_1" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Tanggal Berakhir KTP</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CU_IDCARDEXP_DAY_1" runat="server" Width="32px"></asp:textbox><asp:dropdownlist id="TXT_CU_IDCARDEXP_MONTH_1" runat="server" Width="112px"></asp:dropdownlist><asp:textbox id="TXT_CU_IDCARDEXP_YEAR_1" runat="server" Width="72px"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Key Person</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KEYPERSON_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR vAlign="top">
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 3px">Alamat KTP</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 3px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px; HEIGHT: 3px"><asp:textbox id="TXT_CU_KTPADDR_1" runat="server" Width="100%" TextMode="MultiLine" Height="64px"></asp:textbox><asp:textbox id="TXT_CU_KTPADDR_2" runat="server" Width="100%" TextMode="MultiLine" Height="64px"></asp:textbox><asp:textbox id="TXT_CU_KTPADDR_3" runat="server" Width="100%" TextMode="MultiLine" Height="64px"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 3px">Lokasi DATI II</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 3px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 3px"><asp:dropdownlist id="DDL_CU_LOKASIDATI_2" runat="server" Width="100%" Height="27px"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 15px">Kota</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 15px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px; HEIGHT: 15px"><asp:textbox id="TXT_CU_KTPCITY_1" runat="server" Width="100%"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 15px">Kewarganegaraan</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_CU_CITIZENSHIP_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Kode Pos</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 306px"><asp:textbox id="TXT_CU_KTPZIPCODE_1" runat="server" Width="88px" ontextchanged="TXT_CU_KTPZIPCODE_1_TextChanged"></asp:textbox><asp:button id="BTN_SEARCH_ZIPCODE_2" runat="server" Text="Search" onclick="BTN_SEARCH_ZIPCODE_2_Click"></asp:button>
													<asp:Label id="LabelIDCity2" runat="server" Visible="False">Label</asp:Label></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Hubungan Nasabah BM</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_HUBEXECBM_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7"><asp:button id="btn_Save_CIF_Data" runat="server" Width="100px" Text="SAVE" CssClass="Button1" onclick="btn_Save_CIF_Data_Click"></asp:button><asp:button id="btn_Clear_CIF_Data" runat="server" Width="100px" Text="CLEAR" CssClass="Button1" onclick="btn_Clear_CIF_Data_Click"></asp:button></TD>
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
												<TD class="TDBGColorValue" style="WIDTH: 305px"><asp:dropdownlist id="DDL_CP_KETERANGAN_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Limit</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_LIMIT_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Jenis Pengajuan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 305px"><asp:dropdownlist id="DDL_APPTYPE_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Exchange Rate to Rp</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_EXCHANGERATE_1" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 15px">Jenis Kredit</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 15px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 305px; HEIGHT: 15px"><asp:dropdownlist id="DDL_BI_JENISKREDIT_2" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 15px">Jangka Waktu</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox id="TXT_CP_JANGKAWKT_1" runat="server" Width="32px"></asp:textbox><asp:label id="Label_Satuan_Waktu" runat="server">&nbsp Bulan</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Tujuan Penggunaan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 305px"><asp:dropdownlist id="DDL_CP_LOANPURPOSE_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%"></TD>
												<TD style="WIDTH: 1.31%"></TD>
												<TD class="TDBGColorValue"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7"><asp:button id="btn_Save_Ketentuan_Kredit" runat="server" Width="100px" Text="SAVE" CssClass="Button1" onclick="btn_Save_Ketentuan_Kredit_Click"></asp:button><asp:button id="btn_Clear_Ketentuan_Kredit" runat="server" Width="100px" Text="CLEAR" CssClass="Button1" onclick="btn_Clear_Ketentuan_Kredit_Click"></asp:button></TD>
											</TR>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table width="100%">
											<tr>
												<TD class="tdHeader1" colSpan="7">Data Agunan</TD>
											</tr>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Keterangan Jaminan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px"><asp:textbox id="TXT_CL_DESC_1" runat="server" Width="100%"></asp:textbox></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Nilai Bank</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE_1" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 10px">Bukti Kepemilikan</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 10px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CL_CERTTYPE_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 10px">Nilai Pasar</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 10px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_CL_VALUE2_1" runat="server" Width="100%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Bentuk Pengikatan</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px"><asp:dropdownlist id="DDL_CL_IKATID_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Tanggal Penilaian</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_PENILAIANDATE_DAY_1" runat="server" Width="32px"></asp:textbox><asp:dropdownlist id="TXT_CL_PENILAIANDATE_MONTH_1" runat="server" Width="112px"></asp:dropdownlist><asp:textbox id="TXT_CL_PENILAIANDATE_YEAR_1" runat="server" Width="72px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Currency</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 304px"><asp:dropdownlist id="DDL_CL_CURRENCY_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Penilaian Oleh</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_PENILAIANBY_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7"><asp:button id="btn_Save_Data_Agunan" runat="server" Width="100px" Text="SAVE" CssClass="Button1" onclick="btn_Save_Data_Agunan_Click"></asp:button><asp:button id="btn_Clear_data_agunan" runat="server" Width="100px" Text="CLEAR" CssClass="Button1" onclick="btn_Clear_data_agunan_Click"></asp:button></TD>
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
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 1px">Jenis Penggunaan</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 1px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px; HEIGHT: 1px"><asp:dropdownlist id="DDL_BI_JENISPENGGUNAAN_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 1px">Sektor Ekonomi BI 1</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 1px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 1px"><asp:dropdownlist id="DDL_BM_SEKTOREKONOMI_1" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_BM_SEKTOREKONOMI_1_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Jenis Kredit</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px"><asp:dropdownlist id="DDL_BI_JENISKREDIT_1" runat="server" Width="100%"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Sektor Ekonomi BI 2</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BM_SUBSEKTOREKON_1" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_BM_SUBSEKTOREKON_1_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%; HEIGHT: 18px">Orientasi Penggunaan</TD>
												<TD style="WIDTH: 0.87%; HEIGHT: 18px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px; HEIGHT: 18px"><asp:dropdownlist id="DDL_BI_ORIENTASI_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%; HEIGHT: 18px">Sektor Ekonomi BI 3</TD>
												<TD style="WIDTH: 1.31%; HEIGHT: 18px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_BM_SUBSUBSEKTOREKON_1" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="DDL_BM_SUBSUBSEKTOREKON_1_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Sifat Kredit</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px"><asp:dropdownlist id="DDL_BI_SIFATKREDIT_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Sektor Ekonomi BI 4</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BI_SEKTOREKONOMI_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 17.71%">Fasilitas Penyediaan Dana</TD>
												<TD style="WIDTH: 0.87%">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 307px"><asp:dropdownlist id="DDL_BI_FASILITAS_1" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
												<!-------------------------------------------------------------------------------------------------------->
												<TD class="TDBGColor1" style="WIDTH: 18.7%">Lokasi Proyek</TD>
												<TD style="WIDTH: 1.31%">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_LOKASIPROYEK_2" runat="server" Width="100%"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="7"><asp:button id="btn_Save_Sandi_BI" runat="server" Width="100px" Text="SAVE" CssClass="Button1" onclick="btn_Save_Sandi_BI_Click"></asp:button><asp:button id="btn_Clear_Sandi_BI" runat="server" Width="100px" Text="CLEAR" CssClass="Button1" onclick="btn_Clear_Sandi_BI_Click"></asp:button></TD>
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
