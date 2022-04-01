<%@ Page language="c#" Codebehind="CollateralListDataApp.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.CollateralListDataApp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralListDataApp</title>
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
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LAINNYA (PNCHQ, AR)</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
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
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COL_TYPE" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_COL_ID" runat="server">Collateral ID</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COL_ID" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										<asp:Label id="LBL_TXT_KET_JAMINAN" runat="server">Keterangan Jaminan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KET_JAMINAN" runat="server" Width="300px" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_SIFAT_AGUNAN" runat="server">Sifat Agunan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SIFAT_AGUNAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_JNS_VALUTA" runat="server">Jenis Valuta</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_VALUTA" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_JNS_AGUNAN" runat="server">Jenis Agunan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_AGUNAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_NM_PEMILIK" runat="server">Nama Pemilik Agunan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NM_PEMILIK" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_ADD_BANK" runat="server">Alamat Bank Penyimpan Agunan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADD_BANK" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_DATI" runat="server">Lokasi Dati II</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_DATI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_STATUS" runat="server">Status/Bukti Kepemilikan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_STATUS" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_NILAI_AGUNAN" runat="server">Nilai Agunan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_AGUNAN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_r" runat="server" Visible="False"></asp:label><asp:label id="LBL_REKANANTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149"><asp:label id="LBL_TXT_NILAI_LIQUID" runat="server">Nilai Likuidasi</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_LIQUID" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149"><asp:label id="LBL_TXT_NILAI_APPR" runat="server">Nilai Appraisal</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_APPR" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149"><asp:label id="LBL_TXT_NAMA_PENILAI" runat="server">Nama Penilai Independen</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_PENILAI" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_BLN_PENILAIAN" runat="server">Tanggal Penilaian</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_PENILAIAN" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PENILAIAN" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_BLN_LAST" runat="server">Tanggal Penilaian Terakhir</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAST" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_LAST" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAST" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149"><asp:label id="LBL_TXT_NILAI_PENGIKATAN" runat="server">Nilai Pengikatan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_PENGIKATAN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_BLN_PENGIKAT" runat="server">Tanggal Pengikatan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENGIKAT" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_PENGIKAT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PENGIKAT" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149"><asp:label id="LBL_DDL_JNS_PENGIKAT" runat="server">Jenis Pengikatan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_PENGIKAT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149"><asp:label id="LBL_TXT_NO_PENGIKAT" runat="server">Nomor Pengikatan</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_PENGIKAT" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
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
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" CssClass="Button1" Text="SAVE"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BTN_CLEAR" runat="server" Width="80px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None" ReadOnly="True"></asp:textbox>&nbsp;&nbsp;
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
