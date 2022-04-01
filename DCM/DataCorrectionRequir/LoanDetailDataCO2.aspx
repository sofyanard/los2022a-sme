<%@ Page language="c#" Codebehind="LoanDetailDataCO2.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.LoanDetailDataCO2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoanDetailDataCO2</title>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LOAN DETAIL DATA</B></TD>
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
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_BLN_PK_AWAL" runat="server">Tanggal PK Pertama</asp:label>&nbsp;</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PK_AWAL" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_PK_AWAL" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PK_AWAL" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_NOPK_AWAL" runat="server">No PK Pertama</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPK_AWAL" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_BLN_PK_AKHIR" runat="server">Tanggal PK Terakhir</asp:label>&nbsp;</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PK_AKHIR" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_PK_AKHIR" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PK_AKHIR" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_NOPK_AKHIR" runat="server">No PK Terakhir</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPK_AKHIR" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_RDO_PPA" runat="server">Perhitungan PPA</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_PPA" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_RDO_KOLE" runat="server">Otomatis Kolektibilitas</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_KOLE" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_RDO_FLAG" runat="server">One Entity Flag</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_FLAG" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_RDO_RESTRU" runat="server">Restrukturisasi</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_RESTRU" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_BLN_REST_AW" runat="server">Tanggal Restrukturisasi Awal</asp:label>&nbsp;</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_REST_AW" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_REST_AW" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_REST_AW" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_BLN_REST_AKH" runat="server">Tanggal Restrukturisasi Akhir</asp:label>&nbsp;</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_REST_AKH" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_REST_AKH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_REST_AKH" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_JNS_REST" runat="server">Jenis Restrukturisasi</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_REST" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_KOLE" runat="server">Kolektibilitas BI (tiga pilar)</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KOLE" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_BLN_RVW" runat="server">Tgl Review Restrukturisasi</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_RVW" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_RVW" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_RVW" runat="server" Columns="4" MaxLength="4"
											Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149"><asp:label id="LBL_TXT_REST_KE" runat="server">Restrukturisasi ke-</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REST_KE" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_KET_REST" runat="server">Keterangan Restrukturisasi</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KET_REST" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_SANDI" runat="server">Sandi/Kode Posisi</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SANDI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px"><asp:label id="LBL_DDL_BLN_POS" runat="server">Tgl Posisi</asp:label></TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_POS" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_POS" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_POS" runat="server" Columns="4" MaxLength="4"
											Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_DDL_MACET" runat="server">Sebab Macet</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_MACET" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_BLN_MCT" runat="server">Tanggal Macet</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_MCT" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_MCT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_MCT" runat="server" Columns="4" MaxLength="4"
											Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_RDO_MELANGGAR" runat="server">Melanggar BMPK</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_MELANGGAR" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px"><asp:label id="LBL_RDO_MELAMPAUI" runat="server">Melampaui BMPK</asp:label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_MELAMPAUI" runat="server" Width="100px" RepeatDirection="Horizontal">
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
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="80px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
