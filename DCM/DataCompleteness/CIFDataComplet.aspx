<%@ Page language="c#" Codebehind="CIFDataComplet.aspx.cs" AutoEventWireup="false" Inherits="SME.DCM.DataCompleteness.CIFDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFDataComplet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
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
						<TD class="tdNoBorder" align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">GENERAL DATA</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 542px" vAlign="top" width="542"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_CIF" runat="server">CIF No</asp:label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_CIF" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_CUST_NAME" runat="server">Customer Name</asp:label></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_CUST_NAME" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_RDO_CIF_DEBITUR_TYPE" runat="server">Jenis Nasabah</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 39px" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_CIF_DEBITUR_TYPE" runat="server" Width="200px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Badan Usaha</asp:ListItem>
											<asp:ListItem Value="0">Perorangan</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_CIF_BUC" runat="server">BUC</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CIF_BUC" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px"><asp:label id="LBL_DDL_CIF_OWNER_UNIT" runat="server">PIC Data Owner</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 23px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 23px"><asp:dropdownlist id="DDL_CIF_OWNER_UNIT" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_REPORT_NAME" runat="server">Nama Nasabah Pelaporan</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_REPORT_NAME" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px"><asp:label id="LBL_DDL_CIF_BOD_ESTABLISH_DATE_MM" runat="server">Tgl. Lahir/Tgl. Berdiri Perusahaan</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 20px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_BOD_ESTABLISH_DATE_DD" runat="server"
											Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CIF_BOD_ESTABLISH_DATE_MM" runat="server" Width="112px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_BOD_ESTABLISH_DATE_YY" runat="server"
											Width="72px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_PLACE_BOD_STABLISH" runat="server">Tempat Lahir/Akta Dikeluarkan</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_PLACE_BOD_STABLISH" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px"><asp:label id="LBL_DDL_CIF_MAIN_ID_TYPE" runat="server">Jenis ID Utama</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 23px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 23px"><asp:dropdownlist id="DDL_CIF_MAIN_ID_TYPE" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_MAIN_ID" runat="server">No. ID Utama</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_MAIN_ID" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_TGL_KADALUARSA_ID" runat="server">Tgl. Kadaluarsa ID Utama</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_TGL_KADALUARSA_ID" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px"><asp:label id="LBL_DDL_CIF_GOL_CUSTOMER" runat="server">Golongan Nasabah</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 14px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 14px"><asp:dropdownlist id="DDL_CIF_GOL_CUSTOMER" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px"><asp:label id="LBL_DDL_CIF_DEBITUR_TYPE" runat="server">Jenis Debitur</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 25px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 25px"><asp:dropdownlist id="DDL_CIF_DEBITUR_TYPE" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px"><asp:label id="LBL_DDL_CIF_HUBUNGAN" runat="server">Hubungan dengan Bank</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 14px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 14px"><asp:dropdownlist id="DDL_CIF_HUBUNGAN" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_ADDRESS_LINE1" runat="server">Alamat Nasabah</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_ADDRESS_LINE1" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_KECAMATAN" runat="server">Kecamatan</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox id="TXT_CIF_KECAMATAN" runat="server" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_ZIP" runat="server">Kode Pos</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CIF_ZIP" runat="server" Width="112px" AutoPostBack="True"
											MaxLength="6" Columns="6"></asp:textbox><asp:button id="BTN_CIF_ZIP" runat="server" Text="Search"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px"><asp:label id="LBL_DDL_CIF_DATI2" runat="server">Lokasi Dati II</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 25px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 25px"><asp:dropdownlist id="DDL_CIF_DATI2" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_PH" runat="server">Nomor Telp Rumah/Kantor/HP</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 287px; HEIGHT: 39px" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_PH" runat="server" Width="56px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">HP</asp:ListItem>
											<asp:ListItem Value="1">TR</asp:ListItem>
											<asp:ListItem Value="2">TK</asp:ListItem>
										</asp:radiobuttonlist><asp:textbox id="TXT_PH" runat="server" Width="120px"></asp:textbox>&nbsp;</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_VALUTA" runat="server">Valuta</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 287px; HEIGHT: 10px"><asp:dropdownlist id="DDL_VALUTA" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" style="WIDTH: 422px" colSpan="3">Badan Usaha</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_APP" runat="server">No. APP</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_APP" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_CIF_APP_DATE_MM" runat="server">Tanggal Akte APP</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APP_DATE_DD" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CIF_APP_DATE_MM" runat="server" Width="104px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APP_YY" runat="server" Width="56px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_APT" runat="server">No.APT</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_APT" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_CIF_APT_DATE_MM" runat="server">Tanggal APT</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APT_DATE_DD" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CIF_APT_DATE_MM" runat="server" Width="104px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APT_DATE_YY" runat="server" Width="56px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px"><asp:label id="LBL_TXT_CIF_PENDAPATAN_OPR" runat="server">Pendapatan Operasional</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 20px"><asp:textbox id="TXT_CIF_PENDAPATAN_OPR" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 1px"><asp:label id="LBL_TXT_CIF_PEDAPATAN_NOPR" runat="server">Pendapatan Non Operasional</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 1px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 1px"><asp:textbox id="TXT_CIF_PEDAPATAN_NOPR" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 26px"><asp:label id="LBL_DDL_CIF_RATING_COMP" runat="server">Lembaga Pemeringkat</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 26px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 26px"><asp:dropdownlist id="DDL_CIF_RATING_COMP" runat="server" Width="272px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 24px"><asp:label id="LBL_DDL_CIF_RATING_RESULT" runat="server">Peringkat Perusahaan</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 24px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 24px"><asp:dropdownlist id="DDL_CIF_RATING_RESULT" runat="server" Width="272px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px"><asp:label id="LBL_DDL_CIF_RATING_DATE_MM" runat="server">Tanggal Pemeringkatan</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 18px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px; HEIGHT: 18px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_RATING_DATE_DD" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CIF_RATING_DATE_MM" runat="server" Width="104px"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_RATING_DATE_YY" runat="server" Width="56px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px"><asp:label id="LBL_DDL_CIF_BUSINESS_TYPE" runat="server">Bentuk Badan Usaha</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 11px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 11px"><asp:dropdownlist id="DDL_CIF_BUSINESS_TYPE" runat="server" Width="272px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" style="WIDTH: 422px" colSpan="3">Perorangan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 22px"><asp:label id="LBL_DDL_CIF_SEX_TYPE" runat="server">Jenis Kelamin</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 22px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 22px"><asp:dropdownlist id="DDL_CIF_SEX_TYPE" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_MOTHER_NM" runat="server">Nama Gadis Ibu Kandung</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_MOTHER_NM" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 19px"><asp:label id="LBL_DDL_CIF_PREFIK_NAME" runat="server">Nama Prefik</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 19px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 19px"><asp:dropdownlist id="DDL_CIF_PREFIK_NAME" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_CUST_COMP_NAME" runat="server">Nama Perush. Nasabah Bekerja</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_CUST_COMP_NAME" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_CIF_BIDANG_USAHA" runat="server">Bidang Usaha Nasabah</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CIF_BIDANG_USAHA" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 16px"><asp:label id="LBL_DDL_CIF_JOB_TITLE" runat="server">Jabatan Nasabah</asp:label></TD>
									<TD style="WIDTH: 5px; HEIGHT: 16px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 16px"><asp:dropdownlist id="DDL_CIF_JOB_TITLE" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_CIF_CUST_OCCUPATION" runat="server">Pekerjaan Nasabah</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class='A"TDBGColorValue"' style="WIDTH: 260px; HEIGHT: 10px"><asp:dropdownlist id="DDL_CIF_CUST_OCCUPATION" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_SALARY" runat="server">Gaji</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_SALARY" runat="server" Width="272px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_MAIN_INCOME" runat="server">Pendapatan Utama</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_MAIN_INCOME" runat="server" Width="264px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_TXT_CIF_OTHER_INCOME" runat="server">Pendapatan Lainnya</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:textbox id="TXT_CIF_OTHER_INCOME" runat="server" Width="264px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_CIF_CITIZEN" runat="server">Kewarganegaraan</asp:label></TD>
									<TD style="WIDTH: 5px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 260px"><asp:dropdownlist id="DDL_CIF_CITIZEN" runat="server" Width="176px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><asp:label id="LBL_DDL_CIF_MARITAL" runat="server">Status Perkawinan</asp:label></TD>
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
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE_GENERALDATA" runat="server" Width="76px" Text="SAVE" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_GENERALDATA" runat="server" Width="76px" Text="CLEAR" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_UPDATE_STATUS_GENERALDATA" runat="server" Width="143px" Text="UPDATE STATUS"
								CssClass="Button1"></asp:button>&nbsp;&nbsp;
						</td>
					</tr>
				</table>
				<br>
				<!-- ================== PENGURUS ============================================================== -->
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA PENGURUS</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridDataPerusahaan" runat="server" Width="100%" AutoGenerateColumns="False"
								PageSize="5" CellPadding="1" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CIFNO_PENGURUS" HeaderText="CIF#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAMA" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BOD" HeaderText="BOD/Tgl. Berdiri">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="GENDER" HeaderText="Sex">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NO_ID" HeaderText="ID#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ALAMAT" HeaderText="Alamat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SHARE_SAHAM" HeaderText="Share Saham(%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KODE_POS" HeaderText="Kode Pos">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LB_DELETE" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td class="td" vAlign="top" width="50%">
							<table id="Table30" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><STRONG>TOTAL SAHAM (%) :</STRONG></TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_TOT_SAHAM" runat="server" Width="300px" MaxLength="50" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_TXT_CIF" runat="server">CIF No </asp:label>:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CIF" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_TXT_NAMA" runat="server">Nama </asp:label>:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_NAMA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_DDL_JNS_NASABAH" runat="server">Jenis Nasabah </asp:label>:
									</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:dropdownlist id="DDL_JNS_NASABAH" runat="server" Width="96px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_DDL_BLN_COMP" runat="server">BOD/Berdiri Sejak </asp:label>:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_COMP" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_COMP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_COMP" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_DDL_JNS_KELAMIN" runat="server">Jenis Kelamin </asp:label>:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 10px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNS_KELAMIN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_TXT_SAHAM" runat="server">Share Saham (%) </asp:label>:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_SAHAM" runat="server" Width="48px" MaxLength="20"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_DDL_JNS_ID" runat="server">Jenis ID Utama </asp:label>:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:dropdownlist id="DDL_JNS_ID" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" align="center" width="50%">
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_TXT_ID_UTAMA" runat="server">No. ID Utama </asp:label>:</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_ID_UTAMA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_DDL_BLN_EXP" runat="server">Expired Date ID Utama </asp:label>:</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_EXP_DAY" runat="server" Width="24px" MaxLength="2"
											Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_EXP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_EXP_YEAR" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_TXT_ALAMAT" runat="server">Alamat </asp:label>:</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_ALAMAT" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_TXT_CU_ZIPCODE" runat="server">Kode Pos </asp:label>:</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" AutoPostBack="True"
											MaxLength="6" Columns="6"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px; HEIGHT: 16px">&nbsp;
										<asp:label id="LBL_DDL_BUC" runat="server">BUC </asp:label>:</TD>
									<TD style="HEIGHT: 16px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px" align="left"><asp:dropdownlist id="DDL_BUC" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_DDL_KODE_HUB" runat="server">Kode Hubungan </asp:label>:</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_KODE_HUB" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 276px"><asp:label id="LBL_CHK_REMOVED" runat="server">Remove: Link</asp:label></TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left"><asp:checkbox id="CHK_REMOVED" AutoPostBack="True" Runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_ADD_DATAPENGURUS" runat="server" Text="ADD" CssClass="button1"></asp:button><asp:button id="BTN_UPDATE_DATAPENGURUS" runat="server" Text="UPDATE" CssClass="button1"></asp:button><asp:button id="BTN_CLEAR_DATAPENGURUS" runat="server" Text="CLEAR" CssClass="button1"></asp:button></TD>
					</TR>
				</TABLE>
				</TD></TR></TABLE> 
				<!-- ******************************************************************************************** -->
				<!-- === DATA KEUANGAN === --><br>
				<table width="100%" border="0">
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA KEUANGAN</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 151px"><asp:label id="LBL_DDL_BLN_LAP" runat="server">Posisi Laporan Keuangan</asp:label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAP" runat="server" Width="24px" MaxLength="2"
											Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_LAP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAP" runat="server" Width="36px" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 151px"><asp:label id="LBL_RDO_PINJAMAN_LN" runat="server">Pinjaman Luar Negeri</asp:label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 39px" align="left"><asp:radiobuttonlist id="RDO_PINJAMAN_LN" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 151px"><asp:label id="LBL_DDL_DENO" runat="server">Denominasi</asp:label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_DENO" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px; HEIGHT: 23px"><asp:label id="LBL_DDL_AUDITED" runat="server">Audited/Unaudited</asp:label></TD>
									<TD style="WIDTH: 1px; HEIGHT: 23px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 23px"><asp:dropdownlist id="DDL_AUDITED" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px"><asp:label id="LBL_DDL_CURR" runat="server">Currency</asp:label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_CURR" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 162px" width="162"><asp:label id="LBL_TXT_JML_BLN" runat="server">Jumlah Bulan</asp:label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_JML_BLN" runat="server" Width="312px"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="3">AKTIVA</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 23px">
										<asp:Label id="LBL_TXT_ACTIVA" runat="server">Aktiva Lancar</asp:Label></TD>
									<TD style="WIDTH: 3px; HEIGHT: 23px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
										<asp:TextBox id="TXT_ACTIVA" runat="server" Width="312px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px">
										<asp:Label id="LBL_TXT_TOT_ACTIVA" runat="server">Total Aktiva</asp:Label></TD>
									<TD style="WIDTH: 3px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_TOT_ACTIVA" runat="server" Width="312px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" colSpan="3">PASIVA</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 22px">
										<asp:Label id="LBL_TXT_WJB_BANK" runat="server">Kewajiban kepada Bank</asp:Label></TD>
									<TD style="WIDTH: 3px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
										<asp:TextBox id="TXT_WJB_BANK" runat="server" Width="312px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px">
										<asp:Label id="LBL_TXT_WJB_LANCAR" runat="server">Kewajiban Lancar</asp:Label></TD>
									<TD style="WIDTH: 3px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_WJB_LANCAR" runat="server" Width="312px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px">
										<asp:Label id="LBL_TXT_TOT_WJB" runat="server">Total Kewajiban</asp:Label></TD>
									<TD style="WIDTH: 3px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_TOT_WJB" runat="server" Width="312px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 154px">
										<asp:Label id="LBL_TXT_MODAL" runat="server">Modal</asp:Label></TD>
									<TD style="WIDTH: 3px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_MODAL" runat="server" Width="312px"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="3">LABA/RUGI</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 183px">
										<asp:Label id="LBL_TXT_PENJUALAN" runat="server">Penjualan </asp:Label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_PENJUALAN" runat="server" Width="296px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 183px">
										<asp:Label id="LBL_TXT_POP" runat="server">Pendapatan Operasional</asp:Label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_POP" runat="server" Width="296px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 183px">
										<asp:Label id="LBL_TXT_BOP" runat="server">Biaya Operasioanl</asp:Label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_BOP" runat="server" Width="296px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 183px; HEIGHT: 22px">
										<asp:Label id="LBL_TXT_NON_POP" runat="server">Pendapatan Non Operasional</asp:Label></TD>
									<TD style="WIDTH: 1px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
										<asp:TextBox id="TXT_NON_POP" runat="server" Width="296px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 183px">
										<asp:Label id="LBL_TXT_NON_BOP" runat="server">Biaya Non Operasional</asp:Label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_NON_BOP" runat="server" Width="296px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 183px">
										<asp:Label id="LBL_LR_AFTER" runat="server">Laba Rugi Thn Lalu (Stlh Pajak)</asp:Label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="LR_AFTER" runat="server" Width="296px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 183px">
										<asp:Label id="LBL_LR_BEFORE" runat="server">Laba Rugi Thn Lalu (Sblm Pajak)</asp:Label></TD>
									<TD style="WIDTH: 1px">:</TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="LR_BEFORE" runat="server" Width="296px"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE_DATAKEUANGAN" runat="server" Width="76px" Text="SAVE" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR__DATAKEUANGAN" runat="server" Width="76px" CssClass="Button1" Text="CLEAR"></asp:button></td>
					</tr>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
