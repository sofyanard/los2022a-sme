<%@ Page language="c#" Codebehind="AccountCustomer.aspx.cs" AutoEventWireup="True" Inherits="SME.CustomerInfo.AccountCustomer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AccountCustomer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
		function checkChannFac() {
			// If user decide this facility as :
			
			// 1. a Channeling-Facility, 
			// then follow this policy :
			// - Nomor rekening must be empty and disable
			// - Maturity Date is mandatory
			
			// 2. NOT-a Channeling Facility
			// - Persentase dari Bank disable
			// - Remaining eMAS limit disable
			// - Pending Accept Limit disable
			
			if (Form1.CHK_ISCHANNFACILITY.checked) 
			{
				Form1.TXT_AI_NOREK.disabled = true;
				Form1.TXT_BANK_PERCENTAGE.disabled = false;
				Form1.TXT_REMAINING_EMAS_LIMIT.disabled = false;
				
				Form1.TXT_MATURITY_DAY.className = "mandatory3";
				Form1.DDL_MATURITY_MONTH.className = "mandatory3";
				Form1.TXT_MATURITY_YEAR.className = "mandatory3";	
			}
			else 
			{				
				Form1.TXT_BANK_PERCENTAGE.value = "";
				Form1.TXT_REMAINING_EMAS_LIMIT.value = "";
			
				Form1.TXT_AI_NOREK.disabled = false;	
				Form1.TXT_BANK_PERCENTAGE.disabled = true;
				Form1.TXT_REMAINING_EMAS_LIMIT.disabled = true;				
				
				Form1.TXT_MATURITY_DAY.className = "";
				Form1.DDL_MATURITY_MONTH.className = "";
				Form1.TXT_MATURITY_YEAR.className = "";				
			}
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder><asp:hyperlink id="HL_ACCOUNT" runat="server" NavigateUrl="InfoCustomer.aspx" Visible="False">Account Customer</asp:hyperlink><asp:hyperlink id="HL_COLLATERAL" runat="server" NavigateUrl="CollateralCustomer.aspx" Visible="False">Collateral Customer</asp:hyperlink><asp:hyperlink id="HL_HISTORY" runat="server" NavigateUrl="CustHistory.aspx" Visible="False">History Data</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Info Nasabah
							<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label><asp:label id="LBL_STA" runat="server"></asp:label><asp:label id="LBL_CU_CITY" runat="server" Visible="False"></asp:label><asp:label id="LBL_CU_COMPCITY" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CIF No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CU_CIF_P" runat="server" MaxLength="20"
											Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Gelar Sebelum Nama</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TITLEBEFORENAME" runat="server" MaxLength="15"
											Width="200px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemohon</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_FIRSTNAME" runat="server" MaxLength="50"
											Width="300px" CssClass="mandatory" Enabled="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_MIDDLENAME" runat="server" MaxLength="50"
											Width="300px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Gelar Sesudah Nama</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_LASTNAME" runat="server" MaxLength="50"
											Width="300px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ADDR1" runat="server" MaxLength="100"
											Width="300px" CssClass="mandatory" Enabled="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ADDR2" runat="server" MaxLength="100"
											Width="300px" Enabled="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ADDR3" runat="server" MaxLength="100"
											Width="300px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CITY" runat="server" CssClass="mandatory"
											ReadOnly="True" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" AutoPostBack="True"
											MaxLength="6" CssClass="mandatory" Columns="6" Enabled="False"></asp:textbox><asp:button id="BTN_SEARCHPERSONAL" runat="server" Text="Search" Enabled="False"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kepemilikan Rumah</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_HOMESTA" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;Mulai Menetap</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_MULAIMENETAPMM" runat="server" MaxLength="2" Columns="2" Enabled="False"></asp:textbox>(MM)
										<asp:textbox id="TXT_CU_MULAIMENETAPYY" runat="server" MaxLength="4" Columns="4" Enabled="False"></asp:textbox>&nbsp;(YYYY)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_PHNAREA" runat="server" MaxLength="5"
											CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_PHNNUM" runat="server" MaxLength="15"
											CssClass="mandatory" Columns="10" Enabled="False"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_PHNEXT" runat="server" MaxLength="5"
											Columns="3" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_FAXAREA" runat="server" MaxLength="5"
											Columns="4" Enabled="False"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_FAXNUM" runat="server" MaxLength="15"
											Columns="10" Enabled="False"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_FAXEXT" runat="server" MaxLength="5"
											Columns="3" Enabled="False"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1" width="129">Tempat Lahir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_POB" runat="server" MaxLength="50" Width="300px"
											CssClass="mandatory" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tanggal Lahir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_DAY" runat="server" MaxLength="2"
											Width="24px" CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_YEAR" runat="server" MaxLength="4"
											Width="36px" CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Status Perkawinan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_MARITAL" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Nama Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_FNAME" runat="server" MaxLength="50"
														Columns="40" Enabled="False"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_MNAME" runat="server" MaxLength="50"
														Columns="40" Enabled="False"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_LNAME" runat="server" MaxLength="50"
														Columns="40" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">No KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox id="TXT_CU_SPOUSE_IDCARDNUM" runat="server" MaxLength="50" Columns="40" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Alamat KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR1" runat="server" MaxLength="100"
														Columns="40" Enabled="False"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR2" runat="server" MaxLength="100"
														Columns="40" Enabled="False"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR3" runat="server" MaxLength="100"
														Columns="40" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Tanggal Terbit KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_DAY" runat="server"
														MaxLength="2" Width="24px" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_SPOUSE_KTPISSUEDATE_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_YEAR" runat="server"
														MaxLength="4" Width="36px" Columns="4" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Tanggal Berakhir KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_DAY" runat="server"
														MaxLength="2" Width="24px" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_SPOUSE_KTPEXPDATE_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_YEAR" runat="server"
														MaxLength="4" Width="36px" Columns="4" Enabled="False"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">No Kartu Keluarga</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_NOKARTUKELUARGA" runat="server" MaxLength="50"
														Columns="40" Enabled="False"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Jenis Kelamin</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_SEX" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">No. KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_IDCARDNUM" runat="server" MaxLength="50"
											Width="300px" CssClass="mandatory" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tanggal Berakhir KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_DAY" runat="server" MaxLength="2"
											Width="24px" CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_IDCARDEXP_MONTH" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_YEAR" runat="server" MaxLength="4"
											Width="36px" CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 21px" width="129">Kewarganegaraan&nbsp;</TD>
									<TD style="WIDTH: 15px; HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:dropdownlist id="DDL_CU_CITIZENSHIP" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Jabatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JOBTITLE" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_BUSSTYPE" runat="server" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Berdiri Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_ESTABLISHDD" runat="server" MaxLength="2"
											CssClass="mandatory" Columns="2" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_ESTABLISHMM" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_ESTABLISHYY" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_NPWP" runat="server" MaxLength="25"
											Width="300px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Karyawan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_EMPLOYEE" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="5" Enabled="False"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY" runat="Server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">CIF No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CU_CIF_C" runat="server" MaxLength="20"
											Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Pemohon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPTYPE" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNAME" runat="server" MaxLength="50"
											Width="200px" CssClass="mandatory" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Badan Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JNSNASABAH" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Berdiri Sejak</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHDD" runat="server" MaxLength="2"
											CssClass="mandatory" Columns="2" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPESTABLISHMM" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHYY" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Tempat Berdiri Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPOB" runat="server" MaxLength="50"
											Width="300px" CssClass="mandatory" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR1" runat="server" MaxLength="100"
											Width="300px" CssClass="mandatory" Enabled="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR2" runat="server" MaxLength="100"
											Width="300px" Enabled="False"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR3" runat="server" MaxLength="100"
											Width="300px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPCITY" runat="server" CssClass="mandatory"
											ReadOnly="True" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPZIPCODE" runat="server" AutoPostBack="True"
											MaxLength="6" CssClass="mandatory" Columns="6" Enabled="False"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" Enabled="False"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_C" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">Bidang Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPBUSSTYPE" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Karyawan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEMPLOYEE" runat="server" MaxLength="5"
											Width="50px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPHNAREA" runat="server" MaxLength="5"
											CssClass="mandatory" Columns="4" Enabled="False"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPHNNUM" runat="server" MaxLength="15"
											CssClass="mandatory" Columns="10" Enabled="False"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPHNEXT" runat="server" MaxLength="5"
											Columns="3" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px">No. Fax</TD>
									<TD style="WIDTH: 15px; HEIGHT: 25px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPFAXAREA" runat="server" MaxLength="5"
											Columns="4" Enabled="False"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPFAXNUM" runat="server" MaxLength="15"
											Columns="10" Enabled="False"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPFAXEXT" runat="server" MaxLength="5"
											Columns="3" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNPWP" runat="server" MaxLength="25"
											Width="300px" CssClass="mandatory" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">TDP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TDP" runat="server" MaxLength="17" Columns="20"
											Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Penerbitan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_DAY" runat="server" MaxLength="2"
											Width="24px" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLTERBIT_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_YEAR" runat="server" MaxLength="4"
											Width="36px" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Jatuh Tempo</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_DAY" runat="server" MaxLength="2"
											Width="24px" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLJATUHTEMPO_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_YEAR" runat="server"
											MaxLength="4" Width="36px" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPERSON" runat="server" MaxLength="100"
											Width="300px" CssClass="mandatory" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">No. Telepon</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPHNAREA" runat="server" MaxLength="5"
											Columns="4" Enabled="False"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPHNNUM" runat="server" MaxLength="15"
											Columns="10" Enabled="False"></asp:textbox>&nbsp;Ext.
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPHNEXT" runat="server" MaxLength="5"
											Columns="3" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Channeling Company</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CB_CU_CHANNEL" runat="server" Enabled="False"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Akta&nbsp;Pendirian</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPAKTAPENDIRIAN" runat="server" MaxLength="25"
											Width="300px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Issuance Date</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_ISSUANCEDATE_DAY" runat="server" MaxLength="2"
											Width="24px" Columns="4" Enabled="False"></asp:textbox><asp:dropdownlist id="DDL_CU_ISSUANCEDATE_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_ISSUANCEDATE_YEAR" runat="server" MaxLength="4"
											Width="36px" Columns="4" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nama Notaris</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNOTARYNAME" runat="server" MaxLength="25"
											Width="300px" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="129"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3">Untuk Koperasi/Kelompok dan sebagainya</TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Jumlah Anggota</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPANGGOTA" runat="server" MaxLength="4"
											Columns="5" Enabled="False">0</asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_WASPADA" runat="server">
						<TD colSpan="2"><asp:checkbox id="CB_WASPADA" runat="server" Text="Nasabah Waspada SAM"></asp:checkbox></TD>
					</TR>
					<TR id="TR_TOMBOL" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_SAVE" runat="server" Width="80px" CssClass="Button1" 
                                Text="Simpan"></asp:button>&nbsp;<INPUT class="Button1" onclick="keluar()" type="button" size="20" value=" Keluar "></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Info Fasilitas Nasabah</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">&nbsp;</TD>
									<TD style="HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:radiobuttonlist id="RB_ACCOUNT" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
											Width="327px" onselectedindexchanged="Radiobuttonlist1_SelectedIndexChanged">
											<asp:ListItem Value="0" Selected="True">Existing AA# entry in LOS</asp:ListItem>
											<asp:ListItem Value="1">New AA# entry in LOS</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 8px">AA No.</TD>
									<TD style="HEIGHT: 8px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 8px"><asp:dropdownlist id="DDL_AI_AA_NO" runat="server" CssClass="mandatory3" onselectedindexchanged="DDL_AI_AA_NO_SelectedIndexChanged"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_AI_AA_NO" runat="server" Visible="False"
											MaxLength="20" Width="136px" CssClass="mandatory3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No.&nbsp;Fasilitas</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AI_FACILITY" runat="server" AutoPostBack="True" CssClass="mandatory3" onselectedindexchanged="DDL_AI_FACILITY_SelectedIndexChanged"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AI_SEQ" runat="server" MaxLength="15"
											Width="100px" CssClass="mandatory3"></asp:textbox><asp:checkbox id="CHK_ISCHANNFACILITY" runat="server" AutoPostBack="True" Text="Channeling Facility" oncheckedchanged="CHK_ISCHANNFACILITY_CheckedChanged"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Total Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_LOANAMOUNT" onblur="FormatCurrency(this)"
											runat="server" MaxLength="20" Width="200px" CssClass="mandatory3">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TENOR" runat="server" MaxLength="3" Width="48px"
											CssClass="mandatory3">0</asp:textbox><asp:dropdownlist id="DDL_TENORCODE" runat="server" CssClass="mandatory3"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:textbox onkeypress="return kutip_satu()" id="TXT_STATUS" runat="server" Visible="False"
								Width="96px">insert</asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_AI_NOREK_OLD" runat="server" Visible="False"
								MaxLength="13" Columns="25"></asp:textbox></TD>
						<TD class="td" vAlign="top">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 21px" width="150">Baki Debet</TD>
									<TD style="WIDTH: 15px; HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox onkeypress="return digitsonly()" id="TXT_BAKIDEBET" onblur="FormatCurrency(this)"
											runat="server" MaxLength="19" Width="216px" Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Maturity Date</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_DAY" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MATURITY_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_MATURITY_YEAR" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="150">Product</TD>
									<TD style="WIDTH: 15px; HEIGHT: 3px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px"><asp:dropdownlist id="DDL_PRODUCT" runat="server" CssClass="mandatory3"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">No. Rekening</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AI_NOREK" runat="server" MaxLength="13"
											Width="300px" Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Persentase Dari Bank</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BANK_PERCENTAGE" runat="server" ReadOnly="True" Columns="5"></asp:textbox>% 
										(untuk Share Financing)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Remaining eMas Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_REMAINING_EMAS_LIMIT" onblur="FormatCurrency(this)"
											runat="server" MaxLength="13" Width="214px" ReadOnly="True" Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Pending Accept Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_PENDING_ACCEPT_LIMIT" onblur="FormatCurrency(this)"
											runat="server" MaxLength="13" Width="214px" ReadOnly="True" Columns="25" BackColor="#E0E0E0"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Tujuan Penggunaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<!--<TR>
									<TD class="TDBGColor1" width="150">Limit&nbsp; Account</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AI_LIMIT" runat="server" AutoPostBack="True"
											CssClass="angka">0</asp:textbox></TD>
								</TR>--></TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" id="TR_A" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_NEW" runat="server" Width="75px" CssClass="button1" 
                                Text="Simpan" onclick="BTN_NEW_Click"></asp:button>&nbsp;
							<asp:button id="Button1" runat="server" Width="75px" CssClass="button1" 
                                Text="Batal" onclick="Button1_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True" PageSize="5" HorizontalAlign="Center">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="aa_no" HeaderText="AA No.">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="productid" HeaderText="No. Fasilitas">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="limit" HeaderText="Total Limit" DataFormatString="{0:0,00.00}">
										<HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Tenor" HeaderText="Jangka Waktu">
										<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="acc_no" HeaderText="No. Rekening">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="acc_seq" HeaderText="Sequence">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="limit" HeaderText="Limit Account">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Ubah" CommandName="Edit">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="Hapus" CommandName="Delete">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="bc_tenor" HeaderText="tenor"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="bc_tenorcode" HeaderText="tenorcode"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ISCHANNFACILITY" HeaderText="ISCHANNFACILITY"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
