<%@ Page language="c#" Codebehind="NasabahGroupInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.NasabahGroupInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Nasabah / Group Info</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		//TODO : How to use this function using include file ?
		// Fungsi ini sebenarnya sudah ada di /include/cek_entries.html,
		// tapi kalau pake #include file, screen-protection tidak berfungsi.
		function kutip_satu()
		{
			if ((event.keyCode == 35) || (event.keyCode == 39))
			{
				return false;
			} else
			{
				return true;
			}	
		}		
		
		function numbersonly()
		{
			if (event.keyCode<48||event.keyCode>57)
			{
				return false;
			} else
			{
				return true;
			}	
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Detail Data Entry : 
											Nasabah Group Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR id="TR_CUSTINFO" runat="Server">
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Info Nasabah</TD>
					</TR>
					<asp:label id="lbl_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="117" style="WIDTH: 117px">CIF No.</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_P" runat="server" MaxLength="20" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="117" style="WIDTH: 117px">Gelar Sebelum Nama</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TITLEBEFORENAME" runat="server" Width="200px"
											MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px; HEIGHT: 20px">Nama Pemohon</TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:textbox id="TXT_CU_FIRSTNAME" runat="server" CssClass="mandatory" MaxLength="50" Width="300px"></asp:textbox>
										<asp:textbox id="TXT_CU_MIDDLENAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px; HEIGHT: 20px">Gelar Setelah Nama</TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:textbox id="TXT_CU_LASTNAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px">Alamat</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_ADDR1" runat="server" CssClass="mandatory" MaxLength="100" Width="300px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR2" runat="server" MaxLength="100" Width="300px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR3" runat="server" MaxLength="100" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px">Kota</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_CITY" runat="server" CssClass="mandatory" MaxLength="10" ReadOnly="True"
											Width="175px"></asp:textbox>
										<asp:label id="LBL_CU_CITY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px">Kode Pos</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_ZIPCODE" runat="server" Columns="6" CssClass="mandatory" MaxLength="6"
											onkeypress="return kutip_satu()" AutoPostBack="True" ontextchanged="TXT_CU_ZIPCODE_TextChanged"></asp:textbox>
										<asp:button id="BTN_SEARCHPERSONAL" runat="server" Text="Search" onclick="BTN_SEARCHPERSONAL_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px">No. Telepon / HP</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_PHNAREA" runat="server" Columns="4" CssClass="mandatory" MaxLength="5"></asp:textbox><asp:textbox id="TXT_CU_PHNNUM" runat="server" Columns="10" CssClass="mandatory" MaxLength="15"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_PHNEXT" runat="server" Columns="3" MaxLength="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px">No. Fax / Telepon</TD>
									<TD style="WIDTH: 5px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_FAXAREA" runat="server" Columns="4" MaxLength="5"></asp:textbox><asp:textbox id="TXT_CU_FAXNUM" runat="server" Columns="10" MaxLength="15"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_FAXEXT" runat="server" Columns="3" MaxLength="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px">Kepemilikan Rumah</TD>
									<TD style="WIDTH: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:dropdownlist id="DDL_CU_HOMESTA" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 117px">Mulai Menetap</TD>
									<TD style="WIDTH: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_CU_MULAIMENETAPMM" runat="server" MaxLength="2" Columns="2"></asp:textbox>(MM)
										<asp:textbox id="TXT_CU_MULAIMENETAPYY" runat="server" MaxLength="4" Columns="4"></asp:textbox>(YYYY)</TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1" width="129">
										Tempat Lahir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_POB" runat="server" CssClass="mandatory" MaxLength="50" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">
										Tanggal Lahir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_DOB_DAY" runat="server" Columns="4" Width="24px" MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_CU_DOB_YEAR" runat="server" Columns="4" Width="36px" MaxLength="4" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129" style="HEIGHT: 16px">Status Perkawinan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 16px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_CU_MARITAL" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 16px" colspan="3">
										<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Nama Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_FNAME" runat="server" MaxLength="50"
														Columns="40"></asp:TextBox><BR>
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_MNAME" runat="server" MaxLength="50"
														Columns="40"></asp:TextBox><BR>
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_LNAME" runat="server" MaxLength="50"
														Columns="40"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">No KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:TextBox id="TXT_CU_SPOUSE_IDCARDNUM" runat="server" MaxLength="50" Columns="40"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Alamat KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR1" runat="server" MaxLength="100"
														Columns="40"></asp:TextBox><BR>
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR2" runat="server" MaxLength="100"
														Columns="40"></asp:TextBox><BR>
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR3" runat="server" MaxLength="100"
														Columns="40"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Tanggal Terbit KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_DAY" runat="server"
														Width="24px" MaxLength="2" Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_CU_SPOUSE_KTPISSUEDATE_MONTH" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_YEAR" runat="server"
														Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Tanggal Berakhir KTP Pasangan</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_DAY" runat="server"
														Width="24px" MaxLength="2" Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_CU_SPOUSE_KTPEXPDATE_MONTH" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_YEAR" runat="server"
														Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">No Kartu Keluarga</TD>
												<TD style="WIDTH: 11px"></TD>
												<TD>
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_CU_NOKARTUKELUARGA" runat="server" MaxLength="50"
														Columns="40"></asp:TextBox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 22px" width="129">Jumlah Anak</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CHILDREN" runat="server" MaxLength="2"
											Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129" style="HEIGHT: 22px">Jenis Kelamin</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_SEX" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Kewarganegaraan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_CU_CITIZENSHIP" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">No. KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_IDCARDNUM" runat="server" CssClass="mandatory" MaxLength="50" Width="250px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tanggal Berakhir KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_IDCARDEXP_DAY" runat="server" Columns="4" Width="24px" MaxLength="2"
											CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_CU_IDCARDEXP_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_CU_IDCARDEXP_YEAR" runat="server" Columns="4" Width="36px" MaxLength="4"
											CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129" style="HEIGHT: 23px">
										Jabatan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:dropdownlist id="DDL_CU_JOBTITLE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_BUSSTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Berdiri Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_ESTABLISHDD" runat="server" Columns="2" MaxLength="2" CssClass="mandatory"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_ESTABLISHMM" runat="server" CssClass="mandatory"></asp:dropdownlist>
										<asp:textbox id="TXT_CU_ESTABLISHYY" runat="server" Columns="4" MaxLength="4" CssClass="mandatory"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NPWP" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Karyawan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_EMPLOYEE" runat="server" MaxLength="4"
											CssClass="mandatory2" Columns="5">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Ibu Kandung</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_MOTHER" runat="server" Width="300px" MaxLength="25" CssClass="Mandatory"></asp:textbox></TD>
								</TR>
                                <TR>
									<TD class="TDBGColor1">Nama Instansi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_TEMPATKERJA" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
                                <TR>
									<TD class="TDBGColor1" width="129" style="HEIGHT: 23px">
										Kode Instansi</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:dropdownlist id="DDL_CU_KODEINSTANSI" runat="server"></asp:dropdownlist></TD>
								</TR>
                                <TR>
									<TD class="TDBGColor1">No Pegawai</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_NOPEGAWAI" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
                                <!-- Additional Field : Right -->
                            </TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY" runat="Server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">CIF No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_C" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CU_COMPTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_CU_COMPNAME" runat="server" MaxLength="50" CssClass="mandatory" Width="250px"
											onkeypress="return kutip_satu()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Badan Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CU_JNSNASABAH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Berdiri Sejak</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_COMPESTABLISHDD" runat="server" Columns="2" MaxLength="2" CssClass="mandatory"
											onkeypress="return numbersonly()"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_COMPESTABLISHMM" runat="server" CssClass="mandatory"></asp:dropdownlist>
										<asp:textbox id="TXT_CU_COMPESTABLISHYY" runat="server" Columns="4" MaxLength="4" CssClass="mandatory"
											onkeypress="return numbersonly()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alamat Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_COMPADDR1" onkeypress="return kutip_satu()" runat="server" CssClass="mandatory"
											MaxLength="100" Width="350px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_COMPADDR2" onkeypress="return kutip_satu()" runat="server" MaxLength="100"
											Width="350px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_COMPADDR3" onkeypress="return kutip_satu()" runat="server" MaxLength="100"
											Width="350px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPCITY" runat="server" CssClass="mandatory" MaxLength="10" ReadOnly="True"
											Width="175px"></asp:textbox>
										<asp:label id="LBL_CU_COMPCITY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_COMPZIPCODE" runat="server" Columns="6" CssClass="mandatory" MaxLength="6"
											onkeypress="return kutip_satu()" AutoPostBack="True" ontextchanged="TXT_CU_COMPZIPCODE_TextChanged"></asp:textbox>
										<asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_JNSALAMAT_C" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Bidang Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPBUSSTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 20px">Jumlah Karyawan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPEMPLOYEE" runat="server" MaxLength="4"
											CssClass="mandatory" Columns="10" Width="72px">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Telepon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_COMPPHNAREA" runat="server" Columns="4" CssClass="mandatory" MaxLength="5"
											onkeypress="return numbersonly()"></asp:textbox>
										<asp:textbox id="TXT_CU_COMPPHNNUM" runat="server" Columns="10" CssClass="mandatory" MaxLength="15"
											onkeypress="return kutip_satu()"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_COMPPHNEXT" runat="server" Columns="3" MaxLength="5" onkeypress="return numbersonly()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Fax</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_COMPFAXAREA" onkeypress="return numbersonly()" runat="server" Columns="4"
											MaxLength="5"></asp:textbox>
										<asp:textbox id="TXT_CU_COMPFAXNUM" onkeypress="return kutip_satu()" runat="server" Columns="10"
											MaxLength="15"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_COMPFAXEXT" onkeypress="return numbersonly()" runat="server" Columns="3"
											MaxLength="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">NPWP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPNPWP" onkeypress="return kutip_satu()" runat="server" CssClass="mandatory"
											MaxLength="25" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CONTACTPERSON" onkeypress="return kutip_satu()" runat="server" CssClass="mandatory"
											MaxLength="100" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_CONTACTPHNAREA" runat="server" onkeypress="return numbersonly()" Columns="4"
											MaxLength="5"></asp:textbox>
										<asp:textbox id="TXT_CU_CONTACTPHNNUM" runat="server" onkeypress="return kutip_satu()" Columns="10"
											MaxLength="15"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_CONTACTPHNEXT" runat="server" onkeypress="return numbersonly()" Columns="3"
											MaxLength="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Akta Pendirian</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_AKTAPENDIRIAN" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Issuance Date</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_DAY" runat="server"
											Width="24px" MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_TGASURANSI_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_YEAR" runat="server"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Notaris</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNOTARYNAME" runat="server" Width="300px"
											MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">TDP</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TDP" runat="server" Width="300px" MaxLength="17"
											CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_TGLTERBIT_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Jatuh Tempo</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_DAY" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_TGLJATUHTEMPO_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_YEAR" runat="server"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3">Untuk Koperasi/Kelompok dan sebagainya</TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Anggota</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPANGGOTA" runat="server" MaxLength="4"
											Columns="5">0</asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
                    <TR id="TR_APAMANDIRI" runat="Server">
						<TD class="TDBGColor1" style="HEIGHT: 19px" vAlign="top" width="50%">Apakah nasabah 
							ber-suku bangsa Papua?</TD>
						<TD class="td" style="HEIGHT: 19px" vAlign="top" width="50%">
							<asp:RadioButtonList id="RDO_CU_PERNAHJDNASABAHBM" runat="server" Width="125px" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">Ya</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR id="TR_APARATING" runat="Server">
						<TD class="TDBGColor1" vAlign="top" width="50%">Apakah nasabah merupakan nasabah 
							rating?</TD>
						<TD class="td" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD width="100">
										<asp:RadioButtonList id="RBL_CU_COMPRATING" runat="server" RepeatDirection="Horizontal" Width="125px">
											<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:RadioButtonList></TD>
									<TD>
										<asp:DropDownList id="DDL_CU_COMPRATINGREASON" runat="server"></asp:DropDownList>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_APACRSS" runat="Server">
						<TD class="TDBGColor1" vAlign="top" width="50%">Apakah nasabah merupakan nasabah 
							CRSS?</TD>
						<TD class="td" vAlign="top" width="50%">
							<asp:RadioButtonList id="RBL_CU_RESTRUCTURE" runat="server" Width="125px" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">Ya</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR id="TR_APAHUKUM" runat="Server">
						<TD class="TDBGColor1" style="HEIGHT: 19px" vAlign="top" width="50%">Apakah saat 
							ini perusahaan&nbsp;dalam masalah hukum?</TD>
						<TD class="td" style="HEIGHT: 19px" vAlign="top" width="50%">
							<asp:RadioButtonList id="RDO_CU_COMPPROBLEM" runat="server" Width="128px" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">Ya</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR id="TR_APAWASPADA" runat="Server">
						<TD class="TDBGColor1" style="HEIGHT: 19px" vAlign="top" width="50%">Apakah saat 
							ini perusahaan dalam Daftar Waspada (Watchlist)</TD>
						<TD class="td" style="HEIGHT: 19px" vAlign="top" width="50%">
							<asp:RadioButtonList id="RDO_CU_INWATCHLIST" runat="server" Width="128px" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">Ya</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
							</asp:RadioButtonList></TD>
					</TR>
					<TR id="TR_SPACE1" runat="server">
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="80%" border="0">
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Informasi Grup</TD>
					</TR>
					<TR runat="Server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Group</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_GROUPCUST" onkeypress="return kutip_satu()" MaxLength="50" runat="server"
											Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_GRPADDR1" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="300px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_GRPADDR2" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="300px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_GRPADDR3" onkeypress="return kutip_satu()" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Bidang Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_GRPBUSSTYPE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Telepon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_GRPPHNAREA" runat="server" MaxLength="5" Columns="4" onkeypress="return numbersonly()"></asp:textbox>
										<asp:textbox id="TXT_CU_GRPPHNNUM" runat="server" Width="150" MaxLength="15" onkeypress="return kutip_satu()"
											Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_GRPPHNEXT" runat="server" MaxLength="5" onkeypress="return numbersonly()"
											Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Catatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_GRPREMARK" runat="server" Width="100%"
											MaxLength="500" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Data Kepemilikan 
							Perusahaan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DatGridPengurus" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_DOB" HeaderText="Tgl Lahir/Pendirian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_IDCARDNUM" HeaderText="No. KTP/AKTA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_NPWP" HeaderText="NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JOBTITLEDESC" HeaderText="Jabatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_STOCKPERC" HeaderText="Saham (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EDUCATIONDESC" HeaderText="Pendidikan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AGE" HeaderText="Umur">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EXPDESC" HeaderText="Pengalaman">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_KEYPERSON1" HeaderText="Key Person">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS_DESC" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn Visible="False" HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Edit" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID>
							<!--
							<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="125">Nama</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_FIRSTNAME" runat="server" Width="300px"
														MaxLength="50" CssClass="mandatoryColl"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_MIDDLENAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_LASTNAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nomor KTP</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_IDCARDNUM" runat="server" Width="300px"
														MaxLength="50" CssClass="mandatoryColl"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Alamat KTP</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR1" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR2" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR3" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kota</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox id="TXT_CS_CITY" runat="server" ReadOnly="True" Width="175px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kode Pos</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CS_ZIPCODE" runat="server" MaxLength="6"
														AutoPostBack="True" Columns="6"></asp:textbox>
													<asp:button id="BTN_SEARCHCOMP1" runat="server" Text="Search"></asp:button></TD>
											</TR>
										</TABLE>
										<asp:Label id="SEQ" runat="server"></asp:Label>
									</TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="125">Date of Birth</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_DAY" runat="server" Width="24px"
														MaxLength="2" Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_CS_DOB_MONTH" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_YEAR" runat="server" Width="36px"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="125">Pendidikan Terakhir</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:dropdownlist id="DDL_CS_EDUCATION" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="125">NPWP</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_NPWP" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 21px">Job Title</TD>
												<TD style="HEIGHT: 21px"></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:dropdownlist id="DDL_CS_JOBTITLE" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Pengalaman</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:dropdownlist id="DDL_CS_EXPERIENCE" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Stock
												</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return digitsonly()" id="TXT_CS_STOCKPERC" runat="server" Width="48px"
														MaxLength="5" CssClass="mandatoryColl"></asp:textbox>&nbsp;%
													<asp:label id="LBL_TOTPERC" runat="server" Visible="False">100</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:radiobutton id="RDO_CS_NATSTAT0" runat="server" Text="WNI" Checked="True" GroupName="RDG_CS_NATSTAT"></asp:radiobutton>&nbsp;&nbsp;
													<asp:radiobutton id="RDO_CS_NATSTAT1" runat="server" Text="WNA" GroupName="RDG_CS_NATSTAT"></asp:radiobutton></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Akta Pendirian</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_AKTA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Key Person</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:RadioButtonList id="RDO_KEY_PERSON" runat="server" Width="125px" RepeatDirection="Horizontal">
														<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="0">Tidak</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" colspan="2">
										<asp:button id="BTN_STOCKHOLDER" runat="server" CssClass="button1" Text="Add Stockholder" Visible="False"></asp:button>
										<asp:button id="BTN_UPDATE" runat="server" Visible="False" CssClass="button1" Text="Update"></asp:button>
										<asp:button id="BTN_CANCEL" runat="server" Visible="False" CssClass="button1" Text="Cancel"></asp:button></TD>
								</TR>
							</TABLE>
							-->
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_SAVE" runat="server" Text="Simpan" CssClass="Button1" 
                                Width="100px" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
