<%@ Page language="c#" Codebehind="GeneralInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.RejectMaintenance.GeneralInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GeneralInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_mandatory.html" -->
		<!-- #include file="../../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="2">General Information</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">Kantor Pusat/Kanwil</TD>
									<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AREAID" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_AREAID" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Cabang/CBC/Group</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_CODE" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_BRANCH_CODE" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:label id="LBL_PROG_CODE" runat="server" Visible="False"></asp:label>
										<asp:textbox id="TXT_PROG_CODE" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">RM / SBO</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_RELMNGR" runat="server" Enabled="False" Width="200px"></asp:textbox><asp:label id="LBL_AP_RELMNGR" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Channels</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CHANNEL_CODE" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_CHANNEL_CODE" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Source Code</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SRCCODE" runat="server" AutoPostBack="True" Columns="6" ontextchanged="TXT_AP_SRCCODE_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Gross Annual Sales</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_GROSSSALES" onblur="FormatCurrency(this)"
											runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Booking Branch</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_BOOKINGBRANCH" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">CCO Branch</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_CCOBRANCH" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Aplikasi</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Aplikasi Diterima</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_AP_RECVDATE_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox>
										<asp:dropdownlist id="DDL_AP_RECVDATE_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_AP_RECVDATE_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Business Unit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:label id="LBL_AP_BUSINESSUNIT" runat="server" Visible="False"></asp:label>
										<asp:textbox id="TXT_AP_BUSINESSUNIT" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Application No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="150"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" Enabled="False" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Sales Agency</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_SALESAGENCY" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_AP_SALESAGENCY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Sales Supervisor</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
										<asp:textbox id="TXT_AP_SALESSUPERV" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_AP_SALESSUPERV" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Sales Executive</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_AP_SALESEXEC" runat="server" Enabled="False" Width="200px" ReadOnly="True"></asp:textbox>
										<asp:label id="LBL_AP_SALESEXEC" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<tr>
									<td colspan="3"></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Lokasi Dati II</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_LOKASIDATI2" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Hubungan Nasabah dengan Pejabat 
										Executive BM</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_HUBEXECBM" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" align="right" width="180">Hubungan Keluarga</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_HUBKELBM" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Customer Info</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="80%" border="0">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 228px">Pernah jadi nasabah Bank Mandiri</TD>
									<TD></TD>
									<TD>
										<asp:radiobuttonlist id="RDO_CU_PERNAHJDNASABAHBM" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" Enabled="False" AutoPostBack="True" RepeatDirection="Horizontal"></asp:radiobuttonlist></TD>
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
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_P" runat="server" Width="200px" onkeypress="return digitsonly()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Title Before Name</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TITLEBEFORENAME" runat="server" Width="200px"
											MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemohon</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_FIRSTNAME" runat="server"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_MIDDLENAME" runat="server"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_LASTNAME" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_ADDR1" runat="server" Width="200px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR2" runat="server" Width="200px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_ADDR3" runat="server" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_CITY" runat="server" Width="175px" ReadOnly="True"></asp:textbox><asp:label id="LBL_CU_CITY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_ZIPCODE" runat="server" AutoPostBack="True" Columns="6" MaxLength="6" ontextchanged="TXT_CU_ZIPCODE_TextChanged"></asp:textbox><asp:button id="BTN_SEARCHPERSONAL" runat="server" Text="Search" onclick="BTN_SEARCHPERSONAL_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_PHNAREA" runat="server" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_PHNNUM" runat="server" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_PHNEXT" runat="server" Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_FAXAREA" runat="server" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_FAXNUM" runat="server" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_FAXEXT" runat="server" Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tempat Lahir</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_POB" runat="server" Width="175px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Lahir</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Perkawinan</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_MARITAL" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Anak</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CHILDREN" runat="server" Columns="3">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kelamin</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_SEX" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kewarganegaraan</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_CITIZENSHIP" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1">No. KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_IDCARDNUM" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Berakhir KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CU_IDCARDEXP_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">KTP Address</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPADDR1" runat="server" Width="200px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_KTPADDR2" runat="server" Width="200px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_KTPADDR3" runat="server" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPCITY" runat="server" Width="175px" ReadOnly="True"></asp:textbox><asp:label id="LBL_CU_KTPCITY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPZIPCODE" runat="server" AutoPostBack="True" Columns="6" MaxLength="6" ontextchanged="TXT_CU_KTPZIPCODE_TextChanged"></asp:textbox><asp:button id="BTN_SEARCHKTPZIP" runat="server" Text="Search" onclick="BTN_SEARCHKTPZIP_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_P" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Nasabah</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JNSNASABAH_P" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pendidikan Terakhir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_EDUCATION" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jabatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JOBTITLE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_BUSSTYPE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Berdiri Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ESTABLISHMM" runat="server" Columns="2" MaxLength="2"></asp:textbox>(MM)
										<asp:textbox id="TXT_CU_ESTABLISHYY" runat="server" Columns="4" MaxLength="4"></asp:textbox>&nbsp;(YYYY)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NPWP" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pendapatan Bersih/Bulan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CU_NETINCOMEMM" onblur="FormatCurrency(this)"
											runat="server">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Ibu Kandung</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CU_MOTHER" runat="server" Width="300px" MaxLength="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pelaporan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NAMAPELAPORAN" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Negara Domisili</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_NEGARADOMISILI" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY" runat="Server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">CIF No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_C" runat="server" Width="200px" onkeypress="return digitsonly()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPTYPE" runat="server"></asp:dropdownlist>000000<asp:textbox id="TXT_CU_COMPNAME" runat="server" MaxLength="35"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Badan Usaha</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JNSNASABAH" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Berdiri Sejak</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHMM" runat="server" Columns="2"
											MaxLength="2"></asp:textbox>&nbsp;(MM)&nbsp;
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISH" runat="server" Columns="4"
											MaxLength="4"></asp:textbox>&nbsp;(YYYY)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Tempat Berdiri Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPPOB" runat="server" Width="200px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alamat Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPADDR1" runat="server" Width="200px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_COMPADDR2" runat="server" Width="200px"></asp:textbox><BR>
										<asp:textbox id="TXT_CU_COMPADDR3" runat="server" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPCITY" runat="server" Width="175px" ReadOnly="True"></asp:textbox><asp:label id="LBL_CU_COMPCITY" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPZIPCODE" runat="server" AutoPostBack="True" Columns="6" MaxLength="6" ontextchanged="TXT_CU_COMPZIPCODE_TextChanged"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_C" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">External Rating Company</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPEXTRATING_BY" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CU_COMPEXTRATING_BY_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Rating Class</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPEXTRATING_CLASS" runat="server"></asp:dropdownlist></TD>
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
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPBUSSTYPE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Akta Pendirian</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CU_COMPAKTAPENDIRIAN" runat="server" Width="296px" MaxLength="20"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Notaris</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CU_COMPNOTARYNAME" runat="server" Width="296px" MaxLength="20"></asp:TextBox></TD>
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
									<TD class="TDBGColor1">Jumlah Karyawan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEMPLOYEE" runat="server" Columns="5">0</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPPHNAREA" runat="server" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_COMPPHNNUM" runat="server" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_COMPPHNEXT" runat="server" Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPFAXAREA" runat="server" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_COMPFAXNUM" runat="server" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_COMPFAXEXT" runat="server" Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPNPWP" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">TDP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_TDP" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Penerbitan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_TGLTERBIT_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_YEAR" runat="server" Width="36px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Jatuh Tempo</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_DAY" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox>
										<asp:dropdownlist id="DDL_CU_TGLJATUHTEMPO_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_YEAR" runat="server"
											Width="36px" Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CONTACTPERSON" runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">No. Telepon</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CONTACTPHNAREA" runat="server" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_CONTACTPHNNUM" runat="server" Columns="10"></asp:textbox>&nbsp;Ext.
										<asp:textbox id="TXT_CU_CONTACTPHNEXT" runat="server" Columns="3"></asp:textbox></TD>
								</TR>
								<TR>
									<TD width="129"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD align="center" width="129" colSpan="3">Untuk Koperasi/Kelompok dan sebagainya</TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Jumlah Anggota</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPANGGOTA" runat="server" Columns="5"
											MaxLength="4">0</asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD style="WIDTH: 129px">Request BI Checking
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" width="200"><asp:radiobuttonlist id="RDO_BI_CHECKING" runat="server" Enabled="False" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
											<asp:ListItem Value="0">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue">Tanggal Terakhir Checking:
										<asp:textbox id="TXT_BS_RECVDATE" runat="server" Enabled="False" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save " CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
