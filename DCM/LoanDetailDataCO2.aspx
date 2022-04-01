<%@ Page language="c#" Codebehind="LoanDetailDataCO2.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.LoanDetailDataCO2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoanDetailDataCO2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
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
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">&nbsp;Tanggal PK Pertama</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PK_AWAL" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_PK_AWAL" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PK_AWAL" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No PK Pertama</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPK_AWAL" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">&nbsp;Tanggal PK Terakhir</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PK_AKHIR" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_PK_AKHIR" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PK_AKHIR" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No PK Terakhir</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOPK_AKHIR" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Perhitungan PPA</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_PPA" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Otomatis Kolektibilitas</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_KOLE" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">One Entity Flag</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_FLAG" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Restrukturisasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_RESTRU" runat="server" Width="100px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">&nbsp;Tanggal Restrukturisasi Awal</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_REST_AW" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_REST_AW" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_REST_AW" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">&nbsp;Tanggal Restrukturisasi Akhir</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_REST_AKH" runat="server" Columns="4"
											MaxLength="2" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_REST_AKH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_REST_AKH" runat="server" Columns="4"
											MaxLength="4" Width="36px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_r" runat="server" Visible="False"></asp:label><asp:label id="LBL_REKANANTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">Jenis Restrukturisasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_REST" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">Kolektibilitas BI (tiga pilar)</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KOLE" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Review Restrukturisasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_RVW" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_RVW" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_REST" runat="server" Columns="4" MaxLength="4"
											Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px" width="149">Restrukturisasi ke-</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REST_KE" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">Keterangan Restrukturisasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KET_REST" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">Sandi/Kode Posisi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SANDI" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px">Tgl Posisi</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_POS" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_POS" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_POS" runat="server" Columns="4" MaxLength="4"
											Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 200px">Sebab Macet</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_MACET" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Macet</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_MCT" runat="server" Columns="4" MaxLength="2"
											Width="24px"></asp:textbox><asp:dropdownlist id="DDL_BLN_MCT" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_MCT" runat="server" Columns="4" MaxLength="4"
											Width="36px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;<asp:button id="BTN_UPDATE" runat="server" Width="116px" CssClass="Button1" Text="UPDATE STATUS" onclick="BTN_UPDATE_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="TXT_TEMP" runat="server" Width="1px" ReadOnly="True" BorderStyle="None"></asp:textbox>&nbsp;&nbsp;
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
