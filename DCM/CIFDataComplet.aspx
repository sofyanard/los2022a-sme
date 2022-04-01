<%@ Page language="c#" Codebehind="CIFDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.CIFDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFDataComplet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CIF&nbsp;Data 
											Completeness</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General&nbsp;Data</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 542px" vAlign="top" width="542"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">CIF No</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_CIF" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Customer&nbsp;Name</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_CUST_NAME" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Nasabah</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 39px" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_CIF_DEBITUR_TYPE" runat="server" Width="200px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Badan Usaha</asp:ListItem>
											<asp:ListItem Value="0">Perorangan</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">BUC</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CIF_BUC" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px">PIC Data Owner</TD>
									<TD style="WIDTH: 5px; HEIGHT: 23px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 23px"><asp:dropdownlist id="DDL_CIF_OWNER_UNIT" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Nasabah Pelaporan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_REPORT_NAME" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Tgl. Lahir/Tgl. Berdiri Perusahaan</TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 20px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_BOD_ESTABLISH_DATE_DD" runat="server"
											Width="24px" Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_BOD_ESTABLISH_DATE_MM" runat="server" Width="112px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_BOD_ESTABLISH_DATE_YY" runat="server"
											Width="72px" Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tempat Lahir/Akta Dikeluarkan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_PLACE_BOD_STABLISH" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px">Jenis ID Utama</TD>
									<TD style="WIDTH: 5px; HEIGHT: 23px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 23px"><asp:dropdownlist id="DDL_CIF_MAIN_ID_TYPE" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. ID Utama</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_MAIN_ID" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 16px">Golongan Nasabah</TD>
									<TD style="WIDTH: 5px; HEIGHT: 16px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 16px"><asp:dropdownlist id="DDL_CIF_GOL_CUSTOMER" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Jenis Debitur</TD>
									<TD style="WIDTH: 5px; HEIGHT: 14px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 14px"><asp:dropdownlist id="DDL_CIF_DEBITUR_TYPE" runat="server" Width="280px" AutoPostBack="True" onselectedindexchanged="Dropdownlist26_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Group Nasabah</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_CUST_GROUP" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Hubungan dengan Bank</TD>
									<TD style="WIDTH: 5px; HEIGHT: 14px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 14px"><asp:dropdownlist id="DDL_CIF_HUBUNGAN" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat Nasabah</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_ADDRESS_LINE1" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kecamatan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_KECAMATAN" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CIF_ZIP" runat="server" Width="112px" AutoPostBack="True"
											Columns="6" MaxLength="6"></asp:textbox><asp:button id="BTN_CIF_ZIP" runat="server" Text="Search"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px">Lokasi Dati II</TD>
									<TD style="WIDTH: 5px; HEIGHT: 25px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 25px"><asp:dropdownlist id="DDL_CIF_DATI2" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nomor Telp Rumah/Kantor/HP</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 39px" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_PH" runat="server" Width="56px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">HP</asp:ListItem>
											<asp:ListItem Value="1">TR</asp:ListItem>
											<asp:ListItem Value="2">TK</asp:ListItem>
										</asp:radiobuttonlist><asp:textbox id="TXT_PH" runat="server" Width="120px"></asp:textbox>&nbsp;</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Valuta</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist16" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" style="WIDTH: 422px" colSpan="3">Badan Usaha</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. APP</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_APP" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Akte APP</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APP_DATE_DD" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_APP_DATE_MM" runat="server" Width="104px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APP_YY" runat="server" Width="56px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No.APT</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_APT" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal APT</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APT_DATE_DD" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_APT_DATE_MM" runat="server" Width="104px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APT_DATE_YY" runat="server" Width="56px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Pendapatan Operasional</TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 20px"><asp:textbox id="TXT_CIF_PENDAPATAN_OPR" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 1px">Pendapatan Non Operasional</TD>
									<TD style="WIDTH: 5px; HEIGHT: 1px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 1px"><asp:textbox id="TXT_CIF_PEDAPATAN_NOPR" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 26px">Lembaga Pemeringkat</TD>
									<TD style="WIDTH: 5px; HEIGHT: 26px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 26px"><asp:dropdownlist id="DDL_CIF_RATING_COMP" runat="server" Width="272px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 24px">Peringkat Perusahaan</TD>
									<TD style="WIDTH: 5px; HEIGHT: 24px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 24px"><asp:dropdownlist id="DDL_CIF_RATING_RESULT" runat="server" Width="272px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Pemeringkatan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_RATING_DATE_DD" runat="server" Width="24px"
											Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_RATING_DATE_MM" runat="server" Width="104px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_RATING_DATE_YY" runat="server" Width="56px"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bentuk Badan Usaha</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CIF_BUSINESS_TYPE" runat="server" Width="272px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" style="WIDTH: 422px" colSpan="3">Perorangan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 17px">Jenis Kelamin</TD>
									<TD style="WIDTH: 5px; HEIGHT: 17px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 17px"><asp:dropdownlist id="DDL_CIF_SEX_TYPE" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Gadis Ibu Kandung</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_MOTHER_NM" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Nama Prefik</TD>
									<TD style="WIDTH: 5px; HEIGHT: 14px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 14px"><asp:dropdownlist id="DDL_CIF_PREFIK_NAME" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Perush. Nasabah Bekerja</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_CUST_COMP_NAME" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha Nasabah</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CIF_BIDANG_USAHA" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Jabatan Nasabah</TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 20px"><asp:dropdownlist id="DDL_CIF_JOB_TITLE" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pekerjaan&nbsp;Nasabah</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CIF_CUST_OCCUPATION" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Gaji</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_SALARY" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pendapatan Utama</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_MAIN_INCOME" runat="server" Width="264px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pendapatan Lainnya</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_OTHER_INCOME" runat="server" Width="264px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kewarganegaraan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:dropdownlist id="DDL_CIF_CITIZEN" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Perkawinan</TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:dropdownlist id="DDL_CIF_MARITAL" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" Text="SAVE" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" Width="76px" Text="CLEAR" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button2" runat="server" Width="143px" Text="UPDATE STATUS" CssClass="Button1"></asp:button>&nbsp;&nbsp;
						</td>
					</tr>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
