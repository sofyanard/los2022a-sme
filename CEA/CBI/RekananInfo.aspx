<%@ Page language="c#" Codebehind="RekananInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.CBI.RekananInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RekananInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_mandatory.html" -->
		<!-- #include file="../../include/cek_entries.html" -->
		<!-- #include file="../../include/popup.html" -->
		<!-- #include file="../../include/cek_all.html" -->
		<!-- #include file="../../include/onepost.html" -->
		<!-- #include file="../../include/ConfirmBox.html" -->
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
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
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="WIDTH: 648px"><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RDO_RFCUSTOMERTYPE_SelectedIndexChanged"></asp:radiobuttonlist></TD>
									<TD align="right">
										<table style="WIDTH: 363px; HEIGHT: 36px">
											<tr>
												<td class="TDBGColor1" width="130">Nomor Aplikasi</td>
												<td align="right"><asp:textbox id="TXT_NO_REG" ReadOnly="True" Width="222px" Runat="server" Height="28px"></asp:textbox></td>
											</tr>
										</table>
									</TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_REK_REF" runat="server" Visible="False"></asp:label><asp:label id="LBL_REK_REG" runat="server" Visible="False"></asp:label><asp:label id="SYARAT_TYPEIDE" runat="server" Visible="False"></asp:label><asp:label id="Label1" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Identitas Rekanan</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<!--JNS_REKANAN-->
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 10px" width="145">Jenis Rekanan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_REKANAN" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_JNS_REKANAN_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD><asp:label id="LBL_JNS_REKANAN" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<!--TITLE-->
									<TD class="TDBGColor1" style="WIDTH: 144px" width="145">Gelar</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TITLE" runat="server" Width="200px" MaxLength="15"></asp:textbox></TD>
									<TD><asp:label id="LBL_TITLE" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<!--NAMA-->
									<TD class="TDBGColor1" style="WIDTH: 144px">Nama
									</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA" runat="server" Width="300px" CssClass="mandatory"
											MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_NAMA" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<!--TGL_LAHIR-->
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px" width="145">Tanggal Lahir</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAHIR" runat="server" Width="24px"
											CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_LAHIR" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAHIR" runat="server" Width="36px"
											CssClass="mandatory" MaxLength="4" Columns="4"></asp:textbox></TD>
									<TD><asp:label id="LBL_TGL_LAHIR" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_LAHIR" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_LAHIR" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">Tempat Lahir
									</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TMP_LAHIR" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_TMP_LAHIR" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 21px">Alamat</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REK_ADD1" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="200"></asp:textbox></TD>
									<TD><asp:label id="LBL_REK_ADD1" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 17px">Wilayah</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_CITY_CAB" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_CITY_CAB_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD><asp:label id="LBL_CITY_CAB" runat="server" Visible="False"></asp:label></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">Kecamatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KAB_CAB" runat="server" AutoPostBack="True" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
									<TD><asp:label id="LBL_KAB_CAB" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">ZIP Code</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox onkeypress="return kutip_satu()" id="TXT_ZIP_CODE" runat="server" AutoPostBack="True"
												Width="300px" MaxLength="100" ontextchanged="TXT_ZIP_CODE_TextChanged"></asp:textbox></P>
									</TD>
									<TD><asp:label id="LBL_ZIP_CODE" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1">No. Telp. Kantor 1</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_AREA" runat="server" Width="48px" CssClass="mandatory"
											MaxLength="53"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_KNTR" runat="server" Width="120px" CssClass="mandatory"
											MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NO_AREA" runat="server" Visible="False"></asp:label><asp:label id="LBL_NO_KNTR" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telp. Kantor 2</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_AREA2" runat="server" Width="48px" MaxLength="53"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_KNTR2" runat="server" Width="120px"
											MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NO_AREA2" runat="server" Visible="False"></asp:label><asp:label id="LBL_NO_KNTR2" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax 1</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_AREA_FAX" runat="server" Width="48px"
											CssClass="mandatory" MaxLength="53"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_FAX" runat="server" Width="120px" CssClass="mandatory"
											MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NO_AREA_FAX" runat="server" Visible="False"></asp:label><asp:label id="LBL_NO_FAX" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Fax 2</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_AREA_FAX2" runat="server" Width="48px"
											MaxLength="53"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_FAX2" runat="server" Width="120px" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NO_AREA_FAX2" runat="server" Visible="False"></asp:label><asp:label id="LBL_NO_FAX2" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">eMAIL</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox onkeypress="return kutip_satu()" id="TXT_EMAIL" runat="server" Width="300px" MaxLength="100"></asp:textbox></P>
									</TD>
									<TD><asp:label id="LBL_EMAIL" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mobile Phone</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<P><asp:textbox onkeypress="return kutip_satu()" id="TXT_HP1" runat="server" Width="53px" MaxLength="100"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_HP2" runat="server" Width="120px" MaxLength="100"></asp:textbox></P>
									</TD>
									<TD><asp:label id="LBL_HP1" runat="server" Visible="False"></asp:label><asp:label id="LBL_HP2" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. NPWP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NPWP_PERSONAL" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
									<TD><asp:label id="LBL_NPWP_PERSONAL" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">KTP #</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NOKTP" runat="server" Width="300px" CssClass="mandatory"
											MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NOKTP" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tgl. Berakhir KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KTP" runat="server" Width="24px" CssClass="mandatory"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_KTP" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KTP" runat="server" Width="36px" CssClass="mandatory"
											MaxLength="4" Columns="4"></asp:textbox></TD>
									<TD><asp:label id="LBL_TGL_KTP" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_KTP" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_KTP" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px">Tgl. Pensiun</TD>
									<TD style="HEIGHT: 18px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENSIUN" runat="server" CssClass="mandatory"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_PENSIUN" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PENSIUN" runat="server" CssClass="mandatory"
											MaxLength="4" Columns="4"></asp:textbox></TD>
									<TD><asp:label id="LBL_TGL_PENSIUN" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_PENSIUN" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_PENSIUN" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY" runat="Server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table34" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px">Jenis Rekanan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_JENIS_REK_COMP" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_JENIS_REK_COMP_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD><asp:label id="LBL_JENIS_REK_COMP" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px">Jenis Badan Usaha</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_JENIS_BU" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									<TD><asp:label id="LBL_JENIS_BU" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 12px">Nama</TD>
									<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA_COMP" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_NAMA_COMP" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">Alamat Kantor Pusat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_ADD1" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="200"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_ADD1" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 14px">Wilayah</TD>
									<TD style="WIDTH: 15px; HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:dropdownlist id="DDL_CITY_CAB2" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_CITY_CAB2_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 14px"><asp:label id="LBL_CITY_CAB2" runat="server" Visible="False"></asp:label></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px" width="144">Kecamatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KAB_CAB2" runat="server" AutoPostBack="True" CssClass="mandatory" Enabled="False"></asp:dropdownlist></TD>
									<TD><asp:label id="LBL_KAB_CAB2" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">Zip Code</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_ZIPCODE" runat="server" AutoPostBack="True"
											Width="300px" CssClass="mandatory" MaxLength="100" ontextchanged="TXT_COMP_ZIPCODE_TextChanged"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_ZIPCODE" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">No. Telepon 1</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_AREA" runat="server" Width="56px"
											MaxLength="100"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_TLP" runat="server" Width="128px"
											MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_AREA" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_TLP" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px">No. Telepon 2</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_AREA2" runat="server" Width="56px"
											MaxLength="100"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_TLP2" runat="server" Width="128px"
											MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_AREA2" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_TLP2" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px">Tgl. Berdiri Perusahaan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox onkeypress="return numbersonly()" id="TXT_COMP_TGL" runat="server" CssClass="mandatory"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_COMP_BLN" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_COMP_THN" runat="server" CssClass="mandatory"
											MaxLength="4" Columns="4"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_TGL" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_BLN" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_THN" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px">Tempat Berdiri Perusahaan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 25px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_TMP" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_TMP" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nomor Faximile 1</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_FAX1" runat="server" Width="62px"
											MaxLength="100"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_FAX2" runat="server" Width="134px"
											MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_FAX1" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_FAX2" runat="server" Visible="False"></asp:label></TD>
								<TR>
									<TD class="TDBGColor1">Nomor Faximile 2</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_FAX3" runat="server" Width="62px"
											MaxLength="100"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_FAX4" runat="server" Width="134px"
											MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_FAX3" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_FAX4" runat="server" Visible="False"></asp:label></TD>
								<TR>
									<TD class="TDBGColor1">No. NPWP Perusahaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_NPWP" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_NPWP" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Contact Person:</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_CPNAME" runat="server" Width="300px"
											CssClass="mandatory" MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_CPNAME" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jabatan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_CPJBT" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_CPJBT" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nomor Telepon Contact Person</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_TLPCP1" runat="server" Width="62px"
											CssClass="mandatory" MaxLength="25"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_TLPCP2" runat="server" Width="134px"
											CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_TLPCP1" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_TLPCP2" runat="server" Visible="False"></asp:label></TD>
								<TR>
									<TD class="TDBGColor1">Nomor HP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_HPCP1" runat="server" Width="62px"
											MaxLength="100"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_COMP_CPHP2" runat="server" Width="134px"
											MaxLength="100"></asp:textbox></TD>
									<TD><asp:label id="LBL_COMP_HPCP1" runat="server" Visible="False"></asp:label><asp:label id="LBL_COMP_CPHP2" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_RANGKAP_KM" runat="server">
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table18" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD style="FONT-WEIGHT: bold; WIDTH: 228px">Merangkap Konsultan Manajemen</TD>
									<TD></TD>
									<TD><asp:radiobuttonlist id="RDO_MERANGKAP_KM" runat="server" RepeatDirection="Horizontal" Width="150px">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" id="TR_B" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE_REKANAN" runat="server" Width="75px" CssClass="button1" Text="Simpan" onclick="BTN_SAVE_REKANAN_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE_REKANAN" runat="server" Width="105px" CssClass="button1" Text="Update Status" onclick="BTN_UPDATE_REKANAN_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">List Dokumen</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridDoc" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
									<asp:BoundColumn DataField="DOC_DESC" HeaderText="Jenis Dokumen">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOC#" HeaderText="No. Dokumen">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOC_DATE" HeaderText="Tgl. Dokumen">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOC_END" HeaderText="Tgl. Berakhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOC_FROM" HeaderText="Dikeluarkan Oleh">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KAPA" HeaderText="KAPA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="EDIT_DOC" runat="server" CommandName="edit_doc">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="DELETE_DOC" runat="server" CommandName="delete_doc">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px">Jenis Dokumen</TD>
									<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_DOC" runat="server"></asp:dropdownlist></TD>
									<TD><asp:label id="LBL_JNS_DOC" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px">Nomor Dokumen</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_DOC" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NO_DOC" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px">Dikeluarkan Oleh</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIKELUARKAN_OLEH" runat="server" Width="300px"
											MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_DIKELUARKAN_OLEH" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 23px" width="262">Tgl. Dokumen</TD>
									<TD style="WIDTH: 20px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_DOC" runat="server" Width="24px" MaxLength="2"
											Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_DOC" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_DOC" runat="server" Width="36px" MaxLength="4"
											Columns="4"></asp:textbox></TD>
									<TD><asp:label id="LBL_TGL_DOC" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_DOC" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_DOC" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" align="center" width="50%">
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 23px" width="262">Tgl. Berakhir 
										Dokumen</TD>
									<TD style="WIDTH: 20px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLEXP_DOC" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLNEXP_DOC" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THNEXP_DOC" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
									<TD><asp:label id="LBL_TGLEXP_DOC" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLNEXP_DOC" runat="server" Visible="False"></asp:label><asp:label id="LBL_THNEXP_DOC" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px" width="262">Notaris</TD>
									<TD style="WIDTH: 20px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NOTARIS" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NOTARIS" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR id="TR_KAPA" runat="server">
									<TD class="TDBGColor1" style="WIDTH: 262px" width="262">KAPA</TD>
									<TD style="WIDTH: 20px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KAPA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_KAPA" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" CssClass="button1" Text="Tambah" onclick="BTN_INSERT_Click"></asp:button><asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Ubah" onclick="BTN_UPDATE_Click"></asp:button><asp:button id="BTN_CLEAR" runat="server" CssClass="button1" Text="Hapus" onclick="BTN_CLEAR_Click"></asp:button><asp:label id="TXT_SEQ" Runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR id="TR_NOTARIS" runat="server">
						<TD vAlign="top" width="100%" colSpan="2">
							<TABLE id="Table24" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">Data Notaris</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">SK Notaris</TD>
												<TD style="WIDTH: 15px; HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SK_NOTARIS" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_SK_NOTARIS" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tanggal SK Notaris</TD>
												<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_SK" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_SK" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_SK" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_SK" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_SK" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_SK" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sumpah Notaris</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SUMPAH_NOTARIS" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_SUMPAH_NOTARIS" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 13px">Tgl. Sumpah Notaris</TD>
												<TD style="WIDTH: 15px; HEIGHT: 13px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 13px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_SUMPAH" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_SUMPAH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_SUMPAH" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_SUMPAH" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_SUMPAH" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_SUMPAH" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kota Notaris</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KOTA_NOTARIS" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_KOTA_NOTARIS" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 31px">Anggota Koperasi</TD>
												<TD style="WIDTH: 15px; HEIGHT: 31px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_KOPERASI" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
														Width="150px" onselectedindexchanged="RDO_KOPERASI_SelectedIndexChanged">
														<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="N">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD><asp:label id="LBL_KOPERASI" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. SK Koperasi</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_KOP" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_NO_KOP" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgl. SK Koperasi</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KOP" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_KOP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KOP" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_KOP" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_KOP" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_KOP" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 29px">Terdaftar Sebagai 
													Rekanan&nbsp;Bapepam</TD>
												<TD style="WIDTH: 15px; HEIGHT: 29px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 29px" align="left"><asp:radiobuttonlist id="RDO_BAPEPAM" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
														Width="150px" onselectedindexchanged="RDO_BAPEPAM_SelectedIndexChanged">
														<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="N">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD><asp:label id="LBL_BAPEPAM" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. SK Bapepam</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_BAPEPAM" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_NO_BAPEPAM" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgl. SK Bapepam</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_BAPEPAM" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_BAPEPAM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BAPEPAM" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_BAPEPAM" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_BAPEPAM" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_BAPEPAM" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Limit Tertinggi</TD>
												<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_HIGH_LIMIT" runat="server" AutoPostBack="True"
														Width="300px" MaxLength="100" ontextchanged="TXT_HIGH_LIMIT_TextChanged"></asp:textbox></TD>
												<TD><asp:label id="LBL_HIGH_LIMIT" runat="server" Visible="False"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 17px">SK PPAT</TD>
												<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SK_PPAT" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_SK_PPAT" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgl. PPAT</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PPAT" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_PPAT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PPAT" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_PPAT" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_PPAT" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_PPAT" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sumpah PPAT</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SUMPAH_PPAT" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_SUMPAH_PPAT" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgl. Sumpah PPAT</TD>
												<TD style="WIDTH: 15px; HEIGHT: 13px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 13px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_SUMPAH_PPAT" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_SUMPAH_PPAT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_SUMPAH_PPAT" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_SUMPAH_PPAT" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_SUMPAH_PPAT" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_SUMPAH_PPAT" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Wilayah Kerja PPAT</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PPAT_LOKASI" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_PPAT_LOKASI" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Anggota IPPAT</TD>
												<TD style="WIDTH: 15px; HEIGHT: 39px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_IPPAT" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="150px" onselectedindexchanged="RDO_IPPAT_SelectedIndexChanged">
														<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="N">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD><asp:label id="LBL_IPPAT" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. SK IPPAT</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_IPPAT" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_NO_IPPAT" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgl. SK IPPAT</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_IPPAT" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_IPPAT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_IPPAT" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_IPPAT" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_IPPAT" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_IPPAT" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Anggota INI</TD>
												<TD style="WIDTH: 15px; HEIGHT: 39px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_INI" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" Width="150px">
														<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="N">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD><asp:label id="LBL_INI" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. SK INI</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NO_INI" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_NO_INI" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgl. SK INI</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_INI" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_INI" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_INI" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_INI" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_INI" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_INI" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR id="TR_PM" runat="server">
												<TD class="TDBGColor1">Rekanan Pasar Modal</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REK_BURSA" runat="server" Width="300px"
														MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_REK_BURSA" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR id="TR_TGL_PM" runat="server">
												<TD class="TDBGColor1">Tgl. Rekanan Pasar Modal</TD>
												<TD style="WIDTH: 15px; HEIGHT: 16px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_BURSA" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_BURSA" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BURSA" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
												<TD><asp:label id="LBL_TGL_BURSA" runat="server" Visible="False"></asp:label><asp:label id="LBL_BLN_BURSA" runat="server" Visible="False"></asp:label><asp:label id="LBL_THN_BURSA" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Remark</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REMARK" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
												<TD><asp:label id="LBL_REMARK" runat="server" Visible="False"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE_NOTARIS" runat="server" CssClass="button1" Text="Simpan" onclick="BTN_SAVE_NOTARIS_Click"></asp:button><asp:button id="BTN_CLEAR_NOTARIS" runat="server" CssClass="button1" Text="Hapus" onclick="BTN_CLEAR_NOTARIS_Click"></asp:button><asp:textbox id="TXT_TEMP" runat="server" Width="1px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<tr>
									<td></td>
								</tr>
								<tr>
								<TR width="100%">
									<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAN" runat="server" Width="100%" Visible="False" AutoGenerateColumns="False"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="QUANTITATIVEID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SUBQUANTITATIVEID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SUBSUBQUANTITATIVEID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="NILAI"></asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID><asp:label id="LBL_RFREKANANTYPE" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<tr>
									<td></td>
								</tr>
								<TR width="100%">
									<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAL" runat="server" Width="100%" Visible="False" AutoGenerateColumns="False"
											CellPadding="1" PageSize="12" DESIGNTIMEDRAGDROP="466">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SUBQUALITATIVEID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SCORE"></asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
								<tr>
									<td></td>
								</tr>
								<tr width="100%">
									<td colSpan="2"><ASP:DATAGRID id="DGR_CLA" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
											PageSize="12">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CRITEID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SUBCRITEID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="NILAI"></asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></td>
								</tr>
					</TR>
				</TABLE>
				</TD></TR></TABLE></center>
		</form>
	</body>
</HTML>
