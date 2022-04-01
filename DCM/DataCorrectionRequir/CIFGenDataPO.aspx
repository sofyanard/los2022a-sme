<%@ Page language="c#" Codebehind="CIFGenDataPO.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.CIFGenDataPO" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFGenDataPO</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CIF PERORANGAN</B></TD>
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
									<TD class="TDBGColor1" style="WIDTH: 177px" width="177">
										<asp:Label id="LBL_TXT_CIF_NO" runat="server">CIF No</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_NO" runat="server" Width="200px" MaxLength="15" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px" width="177">
										<asp:Label id="LBL_TXT_CUST_NAME" runat="server">Customer Name</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUST_NAME" runat="server" Width="200px" MaxLength="15" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px">
										<asp:Label id="LBL_TXT_NAMA_PELAPORAN" runat="server">Nama Pelaporan</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_PELAPORAN" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_NAMA_PREFIK" runat="server">Nama Prefik</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_NAMA_PREFIK" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_JNS_NASABAH" runat="server">Jenis Nasabah</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_NASABAH" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 23px" width="177"><FONT color="#000000">
											<asp:Label id="LBL_DDL_BLN_LAHIR" runat="server">Tgl Lahir</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_TGL_LAHIR" runat="server" Width="24px" MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_LAHIR" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAHIR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px">
										<asp:Label id="LBL_TXT_TMP_LAHIR" runat="server">Tempat Lahir</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TMP_LAHIR" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_JNS_IDI" runat="server">Jenis IDI Utama</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_IDI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 17px">
										<asp:Label id="LBL_TXT_IDI_UTAMA" runat="server">No IDI Utama</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_IDI_UTAMA" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 23px" width="177"><FONT color="#000000">
											<asp:Label id="LBL_DDL_BLN_KADAL" runat="server">Tgl Kadaluarsa IDI Utama</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_TGL_KADAL" runat="server" Width="24px" MaxLength="2" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_KADAL" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KADAL" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px">
										<asp:Label id="LBL_TXT_TEMPAT_IDI" runat="server">Tempat Dikeluarkan IDI Utama</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TEMPAT_IDI" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_JNS_DEBITUR" runat="server">Jenis Debitur</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_DEBITUR" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_GOL_NASABAH" runat="server">Golongan Nasabah</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_GOL_NASABAH" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<tr>
									<TD class="TDBGColor1" style="WIDTH: 177px; HEIGHT: 17px">
										<asp:Label id="LBL_DDL_KEWARGANEGARAAN" runat="server">Kewarganegaraan</asp:Label></TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KEWARGANEGARAAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px">
										<asp:Label id="LBL_TXT_TELP_M" runat="server">No Telepon Mobile</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TELP_M" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 177px">
										<asp:Label id="LBL_TXT_TELP_R" runat="server">No Telepon Rumah</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TELP_R" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
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
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT1" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT2" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_KECAMATAN" runat="server">Kecamatan</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KECAMATAN" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_CU_COMPZIPCODE" runat="server">ZipCode</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CU_COMPZIPCODE" runat="server" AutoPostBack="True" MaxLength="6" Columns="6"
											Enabled="False"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_CITY" runat="server">Kota</asp:Label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CITY" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_JNS_ALAMAT" runat="server">Jenis Alamat</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_ALAMAT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_DATI" runat="server">Lokasi Dati II</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_DATI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><FONT color="#000000">
											<asp:Label id="LBL_TXT_MOTHER_NAME" runat="server">Nama Gadis Ibu Kandung</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MOTHER_NAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_HUB_BANK" runat="server">Hubungan dengan Bank</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_HUB_BANK" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_HUB_FAM" runat="server">Hubungan dengan Keluarga</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_HUB_FAM" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_JNS_KELAMIN" runat="server">Jenis Kelamin</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_KELAMIN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_KODE_INDUSTRY" runat="server">Kode Industri</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KODE_INDUSTRY" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><FONT color="#000000">
											<asp:Label id="LBL_DDL_PIC_DATA_OWNER" runat="server">PIC Data Owner</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_PIC_DATA_OWNER" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><FONT color="#000000">
											<asp:Label id="LBL_TXT_NPWP" runat="server">No. NPWP</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NPWP" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
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
