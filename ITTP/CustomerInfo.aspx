<%@ Page language="c#" Codebehind="CustomerInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.CustomerInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustomerInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
		<script language="javascript">
			function Testtt()
			{
				alert('Test!');
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<tr id="TR_VIEW" runat="server">
							<td colSpan="2">
								<table width="100%">
									<TR>
										<TD class="tdNoBorder">
											<TABLE id="Table4">
												<TR>
													<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
															General Info</B></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
									</TR>
									<TR>
										<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
									</TR>
								</table>
							</td>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">Customer Info</TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RDO_RFCUSTOMERTYPE_SelectedIndexChanged"></asp:radiobuttonlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR id="TR_PERSONAL" runat="server">
							<TD class="td" style="WIDTH: 686px" vAlign="top" width="686"><TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="129">CIF No.</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_P" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox><asp:label id="LBL_AP_RELMNGR" runat="server" Visible="False">LBL_AP_RELMNGR</asp:label><asp:label id="TXT_CU_REF" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Title Before Name</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TITLEBEFORENAME" runat="server" Width="200px"
												MaxLength="15"></asp:textbox><asp:label id="TXT_AP_REGNO" runat="server" Visible="False"></asp:label><asp:label id="TXT_AP_RELMNGR" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nama Pemohon</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<P><asp:textbox id="TXT_CU_FIRSTNAME" runat="server" Width="300px" MaxLength="50" CssClass="mandatory2"></asp:textbox><asp:label id="TXT_PROG_CODE" runat="server" Visible="False"></asp:label><BR>
												<asp:textbox id="TXT_CU_MIDDLENAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></P>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Title After Name</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_LASTNAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Alamat</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_ADDR1" runat="server" Width="300px" MaxLength="100" CssClass="mandatory2"></asp:textbox><BR>
											<asp:textbox id="TXT_CU_ADDR2" runat="server" Width="300px" MaxLength="100"></asp:textbox><BR>
											<asp:textbox id="TXT_CU_ADDR3" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kota</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_CITY" runat="server" Width="175px" ReadOnly="True" CssClass="mandatory2"></asp:textbox><asp:label id="LBL_CU_CITY" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kode Pos</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" AutoPostBack="True"
												MaxLength="6" CssClass="mandatory2" Columns="6" ontextchanged="TXT_CU_ZIPCODE_TextChanged"></asp:textbox><asp:button id="BTN_SEARCHPERSONAL" runat="server" Text="Search" onclick="BTN_SEARCHPERSONAL_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kepemilikan Rumah</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_HOMESTA" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">&nbsp;Mulai Menetap</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_MULAIMENETAPMM" runat="server" MaxLength="2" Columns="2"></asp:textbox>(MM)
											<asp:textbox id="TXT_CU_MULAIMENETAPYY" runat="server" MaxLength="4" Columns="4"></asp:textbox>&nbsp;(YYYY)</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Telepon</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_PHNAREA" runat="server" MaxLength="5" CssClass="mandatory2" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_PHNNUM" runat="server" Width="100px" MaxLength="15" CssClass="mandatory2"
												Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox id="TXT_CU_PHNEXT" runat="server" MaxLength="5" Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Fax</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_FAXAREA" runat="server" MaxLength="5" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_FAXNUM" runat="server" Width="100px" MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox id="TXT_CU_FAXEXT" runat="server" MaxLength="5" Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tempat Lahir</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_POB" runat="server" Width="300px" MaxLength="50" CssClass="mandatory2"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal Lahir</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_DAY" runat="server" Width="24px"
												MaxLength="2" CssClass="mandatory2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_YEAR" runat="server" Width="36px"
												MaxLength="4" CssClass="mandatory2" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Status Perkawinan</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_MARITAL" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD colSpan="3">
											<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 127px">Spouse Name</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_FNAME" runat="server" MaxLength="50"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_MNAME" runat="server" MaxLength="50"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_LNAME" runat="server" MaxLength="50"
															Columns="40"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 127px">No KTP</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox id="TXT_CU_SPOUSE_IDCARDNUM" runat="server" MaxLength="50" Columns="40"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 127px">KTP Address</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR1" runat="server" MaxLength="100"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR2" runat="server" MaxLength="100"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR3" runat="server" MaxLength="100"
															Columns="40"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 127px">KTP Issuance Date</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_DAY" runat="server"
															Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_SPOUSE_KTPISSUEDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_YEAR" runat="server"
															Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 127px">Tanggal Berakhir KTP</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_DAY" runat="server"
															Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_SPOUSE_KTPEXPDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_YEAR" runat="server"
															Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 127px">No Kartu Keluarga</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_NOKARTUKELUARGA" runat="server" MaxLength="50"
															Columns="40"></asp:textbox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jumlah Anak</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CHILDREN" runat="server" MaxLength="2"
												Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jenis Kelamin</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_SEX" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kewarganegaraan</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_CITIZENSHIP" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
									<TR>
										<TD class="TDBGColor1">No. KTP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_IDCARDNUM" runat="server" Width="300px" MaxLength="50" CssClass="mandatory2"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal Berakhir KTP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_DAY" runat="server" Width="24px"
												MaxLength="2" CssClass="mandatory2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_IDCARDEXP_MONTH" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_YEAR" runat="server" Width="36px"
												MaxLength="4" CssClass="mandatory2" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">KTP Address</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPADDR1" runat="server" Width="300px" MaxLength="100" CssClass="mandatory2"></asp:textbox><BR>
											<asp:textbox id="TXT_CU_KTPADDR2" runat="server" Width="300px" MaxLength="100"></asp:textbox><BR>
											<asp:textbox id="TXT_CU_KTPADDR3" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kota</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPCITY" runat="server" Width="175px" ReadOnly="True" CssClass="mandatory2"></asp:textbox><asp:label id="LBL_CU_KTPCITY" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kode Pos</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_KTPZIPCODE" runat="server" AutoPostBack="True"
												MaxLength="6" CssClass="mandatory2" Columns="6" ontextchanged="TXT_CU_KTPZIPCODE_TextChanged"></asp:textbox><asp:button id="BTN_SEARCHKTPZIP" runat="server" Text="Search" onclick="BTN_SEARCHKTPZIP_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jenis Alamat</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_P" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:dropdownlist id="DDL_CU_JNSNASABAH_P" runat="server" Visible="False" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Pendidikan Terakhir</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_EDUCATION" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jabatan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JOBTITLE" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Bidang Usaha</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_BUSSTYPE" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Berdiri Sejak</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ESTABLISHDD" runat="server" MaxLength="2" CssClass="mandatory2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CU_ESTABLISHMM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_CU_ESTABLISHYY" runat="server" MaxLength="4" CssClass="mandatory2" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">NPWP</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NPWP" runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Pendapatan Bersih/Bulan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CU_NETINCOMEMM" runat="server" Width="300px"
												MaxLength="15">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jumlah Karyawan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_EMPLOYEE" runat="server" MaxLength="4"
												CssClass="mandatory2" Columns="5"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nama Ibu Kandung</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_MOTHER" runat="server" Width="300px" MaxLength="25" CssClass="Mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nama Pelaporan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NAMAPELAPORAN" runat="server" Width="300px" MaxLength="100" CssClass="mandatory"></asp:textbox><asp:checkbox id="CHB_CU_NAMAPELAPORAN" AutoPostBack="True" Text="Same with Name" Runat="server" oncheckedchanged="CHB_CU_NAMAPELAPORAN_CheckedChanged"></asp:checkbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Negara Domisili</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_NEGARADOMISILI" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR id="TR_COMPANY" runat="Server">
							<TD class="td" style="WIDTH: 686px" vAlign="top" width="686"><TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">CIF No.</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_C" runat="server" Width="200px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Nama Perusahaan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNAME" runat="server" Width="200px"
												MaxLength="50" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Badan Usaha</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JNSNASABAH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Berdiri Sejak</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHDD" runat="server" MaxLength="2"
												CssClass="mandatory" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPESTABLISHMM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHYY" runat="server" MaxLength="4"
												CssClass="mandatory" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Tempat Berdiri Perusahaan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPOB" runat="server" Width="200px"
												MaxLength="50" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Alamat Perusahaan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR1" runat="server" Width="300px"
												MaxLength="100" CssClass="mandatory"></asp:textbox><BR>
											<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR2" runat="server" Width="300px"
												MaxLength="100"></asp:textbox><BR>
											<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR3" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPCITY" runat="server" Width="175px" ReadOnly="True" CssClass="mandatory"></asp:textbox><asp:label id="LBL_CU_COMPCITY" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kode Pos</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPZIPCODE" runat="server" AutoPostBack="True"
												MaxLength="6" CssClass="mandatory" Columns="6" ontextchanged="TXT_CU_COMPZIPCODE_TextChanged"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jenis Alamat</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_C" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1"></TD>
										<TD></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">External Rating Company</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPEXTRATING_BY" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Rating Class</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPEXTRATING_CLASS" runat="server" MaxLength="5" Columns="5"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Rating Date</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEXTRATING_DATE_DAY" runat="server"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPEXTRATING_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEXTRATING_DATE_YEAR" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kode Listing Bursa</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPLISTINGCODE" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal Listing Bursa</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPLISTINGDATE_DAY" runat="server"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPLISTINGDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPLISTINGDATE_YEAR" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="129">Bidang Usaha</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPBUSSTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Akta Pendirian</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPAKTAPENDIRIAN" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Issuance Date</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_DAY" runat="server"
												Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGASURANSI_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_YEAR" runat="server"
												Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Akta Perubahan Terakhir</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPAKTATERAKHIR_NO" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Tanggal Perubahan Terakhir</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPAKTATERAKHIR_DATE_DAY" runat="server"
												Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPAKTATERAKHIR_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPAKTATERAKHIR_DATE_YEAR" runat="server"
												Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Nama Notaris</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPNOTARYNAME" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jumlah Karyawan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEMPLOYEE" runat="server" MaxLength="4"
												Columns="5">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Telepon</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPPHNAREA" runat="server" MaxLength="5"
												CssClass="mandatory" Columns="4"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPHNNUM" runat="server" Width="100px"
												MaxLength="15" CssClass="mandatory" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPPHNEXT" runat="server" MaxLength="5"
												Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Fax</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPFAXAREA" runat="server" MaxLength="5"
												Columns="4"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPFAXNUM" runat="server" Width="100px"
												MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPFAXEXT" runat="server" MaxLength="5"
												Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">NPWP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNPWP" runat="server" Width="200px"
												MaxLength="25" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">TDP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TDP" runat="server" MaxLength="17" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tgl Penerbitan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_DAY" runat="server" Width="24px"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLTERBIT_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_YEAR" runat="server" Width="36px"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tgl Jatuh Tempo</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_DAY" runat="server" Width="24px"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLJATUHTEMPO_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_YEAR" runat="server"
												Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Contact Person</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPERSON" runat="server" Width="300px"
												MaxLength="100" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR id="TR_telepon" runat="server">
										<TD class="TDBGColor1" width="129">No. Telepon</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CONTACTPHNAREA" runat="server" MaxLength="5"
												Columns="4"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPHNNUM" runat="server" Width="100px"
												MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CONTACTPHNEXT" runat="server" MaxLength="5"
												Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="129"></TD>
										<TD></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR id="TR_koperasi" runat="server">
										<TD align="center" colSpan="3">Untuk Koperasi/Kelompok dan sebagainya</TD>
										<TD></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR id="TR_anggota" runat="server">
										<TD class="TDBGColor1" width="129">Jumlah Anggota</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPANGGOTA" runat="server" MaxLength="4"
												Columns="5">0</asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- pipeline -->
						<TR id="TR_sektor" runat="Server">
							<TD class="td" style="WIDTH: 686px" vAlign="top" width="686"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Group Nasabah</TD>
										<TD class="TDBGColorValue"><asp:textbox id="DDL_groupnasabah" runat="server" AutoPostBack="False" Width="300px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 1</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_bmsektor" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_bmsektor_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 2</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_bmsubsektor" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_bmsubsektor_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 3</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_bmsubsubsektor" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_bmsubsubsektor_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 4</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEKTOREKONOMIBI" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist><INPUT id="BTN_PG" onclick="window.open('PG2010.html')" type="button" value="Portfolio Guideline"
												name="BTN_PG">
										</TD>
									</TR>
								</TABLE>
								<asp:label id="temp_userid" runat="server" Visible="False">temp_userid</asp:label><asp:label id="temp_branchcode" runat="server" Visible="False">temp_branchcode</asp:label><asp:label id="temp_areaid" runat="server" Visible="False">temp_areaid</asp:label></TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Net Income</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_netincome" onblur="FormatCurrency(this)"
												runat="server" Width="200px" MaxLength="25" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Pendapatan Operasional</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_pendapatanoperasional" onblur="FormatCurrency(this)"
												runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Pendapatan Non Operasional</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_pendapatannon" onblur="FormatCurrency(this)"
												runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Lokasi Pabrik/Kebun/Proyek</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_lokasiproyek" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Key Person</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox_keyperson" runat="server" Width="200px"
												MaxLength="25" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Lokasi Dati II</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_LOKASIDATI2" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Hubungan Nasabah dengan Pejabat 
											Executive BM</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_HUBEXECBM" runat="server"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button><asp:button id="BTN_SAVECON" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
