<%@ Page language="c#" Codebehind="BarangBergerakVEH.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.BarangBergerakVEH" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BarangBergerakVEH</title>
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
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>BARANG BERGERAK 
											(VEH-KENDARAAN)</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="ListCustomer.aspx?si="></A><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_COL_TYPE" runat="server">Collateral Type</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COL_TYPE" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_COL_ID" runat="server">Collateral ID</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COL_ID" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_KET_JAMINAN" runat="server">Keterangan Jaminan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KET_JAMINAN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_SIFAT_AGUNAN" runat="server">Sifat Agunan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SIFAT_AGUNAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_JNS_VALUTA" runat="server">Jenis Valuta</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_VALUTA" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_JNS_AGUNAN" runat="server">Jenis Agunan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_AGUNAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_NM_PEMILIK" runat="server">Nama Pemilik Agunan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NM_PEMILIK" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_ALAT_BUKTI" runat="server">Alamat Penyimpanan Bukti Agunan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAT_BUKTI" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_DATI" runat="server">Lokasi Dati II</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_DATI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_STATUS" runat="server">Status/Bukti Kepemilikan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_STATUS" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">
										<asp:Label id="LBL_DDL_BLN_START" runat="server">Jangka Waktu Mulai</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_START" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_START" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_START" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">
										<asp:Label id="LBL_DDL_BLN_JT" runat="server">Jangka Waktu Jatuh Tempo</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_JT" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_JT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_JT" runat="server" Columns="4" MaxLength="4"
											Width="36px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_TXT_NILAI_PASAR" runat="server">Nilai Pasar / Bank</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_PASAR" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_TXT_NILAI_APPR" runat="server">Nilai Appraisal</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_APPR" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_TXT_NILAI_LIQUID" runat="server">Nilai Likuidasi</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_LIQUID" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_TXT_NILAI_IND" runat="server">Nama Penilai Independen</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_IND" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_BLN_PENILAIAN" runat="server">Tanggal Penilaian</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_PENILAIAN" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PENILAIAN" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_BLN_LAST" runat="server">Tanggal Penilaian Terakhir</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAST" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_LAST" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_LAST" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_TXT_NILAI_PENGIKATAN" runat="server">Nilai Pengikatan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_PENGIKATAN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_DDL_JNS_PENGIKATAN" runat="server">Jenis Pengikatan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_PENGIKATAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_DDL_BLN_PENGIKATAN" runat="server">Tanggal Pengikatan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENGIKATAN" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_PENGIKATAN" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_PENGIKATAN" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_TXT_NO_PENGIKATAN" runat="server">Nomor Pengikatan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_PENGIKATAN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_TXT_PARIPASU" runat="server">Paripasu(%)</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PARIPASU" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">
										<asp:Label id="LBL_RDO_ASURANSI" runat="server">Asuransi(Y/N)</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_ASURANSI" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="80px" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="80px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
