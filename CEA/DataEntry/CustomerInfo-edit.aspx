<%@ Page language="c#" Codebehind="CustomerInfo.aspx.cs" AutoEventWireup="True" Inherits="dbrbm.Data_Entry.CustomerInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustomerInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Fmain" name="Fmain" action="SearchCustomer.aspx?mc=030" method="post" target="main">
		</form>
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Info Rekanan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" Visible="False" NavigateUrl="CustomerInfo.aspx">Informasi Rekanan</asp:hyperlink><asp:hyperlink id="Hyperlink1" runat="server" Visible="False" NavigateUrl="DTBO\ListDTBO.aspx">Perijinan</asp:hyperlink><asp:hyperlink id="Hyperlink2" runat="server" Visible="False" NavigateUrl="InfoPerusahaan.aspx">Data Perusahaan</asp:hyperlink><asp:hyperlink id="HL_COLLATERAL" runat="server" Visible="False" NavigateUrl="KantorCabang.aspx">Struktur Organisasi</asp:hyperlink><asp:hyperlink id="HL_HISTORY" runat="server" Visible="False" NavigateUrl="CustHistory.aspx"> Notaris</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"></asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Identitas Rekanan</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px" width="129">Jenis Rekanan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="Drop_jenis_privat" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Title</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_title_privat" runat="server" Width="200px"
											MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama
									</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="nama_privat" runat="server" Width="300px" CssClass="mandatory"
											MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px" width="129">Tanggal Lahir</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="tgl_lahir_privat" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tempat Lahir
									</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_tmpatLahir_privat" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="cu_alamat1_privat" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="100"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="cu_alamat2_privat" runat="server" Width="300px"
											MaxLength="100"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="cu_alamat3_privat" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="cu_kota_privat" runat="server" ReadOnly="True"
											CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1">No. Telp. Kantor</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox onkeypress="return kutip_satu()" id="telp_privat" runat="server" Width="300px" MaxLength="100"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">eMAIL</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox onkeypress="return kutip_satu()" id="email_privat" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mobile Phone</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox onkeypress="return kutip_satu()" id="hp_privat" runat="server" Width="300px" MaxLength="100"></asp:textbox></P>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">KTP #</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_noktp_privat" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tgl. Berakhir KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="cu_tglakhirKTP_privat" runat="server" Width="24px"
											CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="cu_tglakhirmonth_privat" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="cu_tglakhiryear_privat" runat="server" Width="36px"
											CssClass="mandatory" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 27px">Tgl. Pensiun</TD>
									<TD style="HEIGHT: 27px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 27px"><asp:textbox onkeypress="return numbersonly()" id="cu_tglpensiunday_privat" runat="server" CssClass="mandatory"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="cu_tglpensiunmonth_privat" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="cu_tglpensiunyear_privat" runat="server" CssClass="mandatory"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">ZIP Code</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Kode_privat" runat="server" Width="300px" CssClass="mandatory"
											MaxLength="50"></asp:textbox></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY" runat="Server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 23px">Jenis Rekanan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="cu_comjenisrekaan_BU" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 23px">Jenis Badan Usaha</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="jenisBU" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 12px">Nama</TD>
									<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return kutip_satu()" id="nama_BU" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_comkota_BU" runat="server" ReadOnly="True"
											CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Zip Code</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="kode_BU" runat="server" Width="300px" CssClass="mandatory"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_comnotelp_BU" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 21px">Tgl. Berdiri Perusahaan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox onkeypress="return numbersonly()" id="cu_comberdiriday_BU" runat="server" CssClass="mandatory"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="cu_comberdirimonth_BU" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="cu_comberdiriyear_BU" runat="server" CssClass="mandatory"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_comalamat1_BU" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="100"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="cu_comalamat2_BU" runat="server" Width="300px"
											MaxLength="100"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="cu_comalamat3_BU" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px">Tempat Berdiri Perusahaan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 25px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="tmptBerdiri_BU" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nomor Ficimile</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="fax_BU" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. NPWP Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_comnpwp_BU" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person:</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="cu_CP_BU" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="namaCP_BU" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jabatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox6" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nomor Telpon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TelpCP_BU" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nomor HP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="HP_CP_BU" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" id="TR_A" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_save_rekanan" runat="server" Width="75px" CssClass="button1" Text="Save"></asp:button>&nbsp;
							<asp:button id="update_rekanan" runat="server" Width="105px" CssClass="button1" Text="Update Status"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
