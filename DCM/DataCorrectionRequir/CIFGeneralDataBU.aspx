<%@ Page language="c#" Codebehind="CIFGeneralDataBU.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.CIFGeneralDataBU" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFGeneralDataBU</title>
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
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 475px">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CIF BADAN USAHA</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="left" colSpan="2"><asp:placeholder id="MenuCIF" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">General&nbsp;Data</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 24px" width="173">
										<asp:Label id="LBL_TXT_CIFNO" runat="server">Cif No</asp:Label></TD>
									<TD style="WIDTH: 15px; HEIGHT: 24px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox id="TXT_CIFNO" runat="server" ReadOnly="True" MaxLength="15" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px" width="173">
										<asp:Label id="LBL_TXT_CUST_NAME" runat="server">Customer Name</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUST_NAME" runat="server" ReadOnly="True" MaxLength="15" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px">
										<asp:Label id="LBL_TXT_NAMA_PELAPOR" runat="server">Nama Pelaporan</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_PELAPOR" runat="server" MaxLength="100" Width="300px"></asp:textbox></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_NAMA_PREFIK" runat="server">Nama Prefik</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_NAMA_PREFIK" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_JNS_NASABAH" runat="server">Jenis Nasabah</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_NASABAH" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 23px" width="173"><FONT color="#000000"><asp:label id="LBL_DDL_BLN_BOD" runat="server">Tgl Berdiri Perusahaan</asp:label></FONT></TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_BOD" runat="server" MaxLength="2" Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_BOD" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BOD" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px">
										<asp:Label id="LBL_TXT_TMP_AKTA" runat="server">Tempat Akta Dikeluarkan</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TMP_AKTA" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 21px">
										<asp:Label id="LBL_DDL_JNS_IDI" runat="server">Jenis ID Utama</asp:Label></TD>
									<TD style="HEIGHT: 21px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_IDI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 23px">
										<asp:Label id="LBL_TXT_NO_IDI" runat="server">No ID Utama</asp:Label></TD>
									<TD style="HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_IDI" runat="server" MaxLength="100" Width="300px"></asp:textbox></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 23px" width="173"><FONT color="#000000"><asp:label id="LBL_DDL_BLN_KAD" runat="server">Tgl Kadaluarsa ID Utama</asp:label></FONT></TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_KAD" runat="server" MaxLength="2" Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_KAD" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KAD" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px">
										<asp:Label id="LBL_TXT_TEMPAT_IDI" runat="server">Tempat Dikeluarkan ID Utama</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TEMPAT_IDI" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_JNS_DEB" runat="server">Jenis Debitur</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_DEB" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_GOL_NASABAH" runat="server">Golongan Nasabah</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_GOL_NASABAH" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_KWRG" runat="server">Kewarganegaraan</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KWRG" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 17px"><FONT color="#000000"><asp:label id="LBL_DDL_KODE_INDUSTRI" runat="server">Kode Industri</asp:label></FONT></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KODE_INDUSTRI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px">
										<asp:Label id="LBL_TXT_NO_APP" runat="server">No. APP</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_APP" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 23px" width="173"><FONT color="#000000">
											<asp:Label id="LBL_DDL_BLN_APP" runat="server">Tanggal APP</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_APP" runat="server" MaxLength="2" Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_APP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_APP" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px">
										<asp:Label id="LBL_TXT_NO_APT" runat="server">No. APT</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_APT" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px; HEIGHT: 23px" width="173"><FONT color="#000000">
											<asp:Label id="LBL_DDL_BLN_APT" runat="server">Tanggal APT</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_APT" runat="server" MaxLength="2" Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_APT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_APT" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 173px">No. Telepon Kantor</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TLP_KANTOR" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_KODE_NEGARA" runat="server">Kode Negara</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KODE_NEGARA" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_ALAMAT1" runat="server">Alamat</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT1" runat="server" MaxLength="1000" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT2" runat="server" MaxLength="1000" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_KECAMATAN" runat="server">Kecamatan</asp:label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KECAMATAN" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_CU_COMPZIPCODE" runat="server">ZipCode</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CU_COMPZIPCODE" runat="server" MaxLength="6" AutoPostBack="True" Columns="6"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_KOTA" runat="server">Kota</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KOTA" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_JNS_ALAMAT" runat="server">Jenis Alamat</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_ALAMAT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_LOKASI_DATI" runat="server">Lokasi Dati II</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_LOKASI_DATI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><FONT color="#000000"><asp:label id="LBL_DDL_LBG_PEM" runat="server">Lembaga Pemeringkat</asp:label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_LBG_PEM" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><FONT color="#000000"><asp:label id="LBL_DDL_PEM_COMP" runat="server">Pemeringkat Perusahaan</asp:label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_PEM_COMP" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><FONT color="#000000"><asp:label id="LBL_DDL_BLN_PEM" runat="server">Tanggal Pemeringkatan</asp:label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_PEMRINGKAT" runat="server" MaxLength="2" Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_PEM" runat="server"></asp:dropdownlist><asp:textbox id="TXT_THN_PEMRINGKAT" runat="server" MaxLength="4" Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_HUB_KEL" runat="server">Hubungan dengan Keluarga</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_HUB_KEL" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_HUB_BANK" runat="server">Hubungan dengan Bank</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_HUB_BANK" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><FONT color="#000000"><asp:label id="LBL_DDL_PIC" runat="server">PIC Data Owner</asp:label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_PIC" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_RDO_ASURANSI" runat="server">Go Publik</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_GOPUBLIC" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">
										<asp:Label id="LBL_TXT_TELP_RMH" runat="server">No. Telpon Rumah</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TELP_RMH" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">
										<asp:Label id="LBL_TXT_MOBILE" runat="server">No. Telpon Mobile</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MOBILE" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">
										<asp:Label id="LBL_TXT_OPR" runat="server">Pendapatan Operasional</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OPR" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">
										<asp:Label id="LBL_TXT_NON_OPR" runat="server">Pendapatan Non Operasional</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NON_OPR" runat="server" MaxLength="50" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_VALUTA" runat="server">Valuta</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_VALUTA" runat="server"></asp:dropdownlist></TD>
								</TR>
								<!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="76px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
