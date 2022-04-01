<%@ Page language="c#" Codebehind="CIFDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.CAP.CIFDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CIFDataComplet</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>CIF&nbsp;Data 
											Completeness</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">GENERAL DATA</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_CIF" runat="server">CIF No :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_CIF" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_CUST_NAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_CUST_NAME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_RDO_CIF_DEBITUR_TYPE" runat="server">Jenis Nasabah :</asp:label></TD>
									<TD class="TDBGColorValue" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_CIF_DEBITUR_TYPE" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Badan Usaha</asp:ListItem>
											<asp:ListItem Value="0">Perorangan</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_BUC" runat="server">BUC :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_BUC" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_OWNER_UNIT" runat="server">PIC Data Owner :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_OWNER_UNIT" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_REPORT_NAME" runat="server">Nama Nasabah Pelaporan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_REPORT_NAME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_BOD_ESTABLISH_DATE_MM" runat="server">Tgl. Lahir/Tgl. Berdiri Perusahaan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_BOD_ESTABLISH_DATE_DD" runat="server"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_BOD_ESTABLISH_DATE_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_BOD_ESTABLISH_DATE_YY" runat="server"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_PLACE_BOD_STABLISH" runat="server">Tempat Lahir/Akta Dikeluarkan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_PLACE_BOD_STABLISH" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_MAIN_ID_TYPE" runat="server">Jenis ID Utama :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_MAIN_ID_TYPE" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_MAIN_ID" runat="server">No. ID Utama :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_MAIN_ID" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLKADALUARSAIDUTAMA" runat="server">Tgl. Kadaluarsa ID Utama :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLKADALUARSAIDUTAMA" runat="server"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLKADALUARSAIDUTAMA" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLKADALUARSAIDUTAMA" runat="server"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_GOL_CUSTOMER" runat="server">Golongan Nasabah :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_GOL_CUSTOMER" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_DEBITUR_TYPE" runat="server">Jenis Debitur :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_DEBITUR_TYPE" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_HUBUNGAN" runat="server">Hubungan dengan Bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_HUBUNGAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_ADDRESS_LINE1" runat="server">Alamat Nasabah :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_ADDRESS_LINE1" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_KECAMATAN" runat="server">Kecamatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_KECAMATAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_ZIP" runat="server">Kode Pos :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CIF_ZIP" runat="server" Width="100px" AutoPostBack="True"
											MaxLength="6" Columns="6"></asp:textbox><asp:button id="BTN_CIF_ZIP" runat="server" Text="Search"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_DATI2" runat="server">Lokasi Dati II :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_DATI2" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PH" runat="server">Nomor Telp Rumah/Kantor/HP :</asp:label></TD>
									<TD class="TDBGColorValue" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_PH" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">HP</asp:ListItem>
											<asp:ListItem Value="1">TR</asp:ListItem>
											<asp:ListItem Value="2">TK</asp:ListItem>
										</asp:radiobuttonlist><asp:textbox id="TXT_PH" runat="server"></asp:textbox>&nbsp;
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_VALUTA" runat="server">Valuta :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_VALUTA" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">Badan Usaha</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_APP" runat="server">No. APP :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_APP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_APP_DATE_MM" runat="server">Tanggal Akte APP :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APP_DATE_DD" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_APP_DATE_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APP_YY" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_APT" runat="server">No.APT :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_APT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_APT_DATE_MM" runat="server">Tanggal APT :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APT_DATE_DD" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_APT_DATE_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_APT_DATE_YY" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_PENDAPATAN_OPR" runat="server">Pendapatan Operasional :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_PENDAPATAN_OPR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_PEDAPATAN_NOPR" runat="server">Pendapatan Non Operasional :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_PEDAPATAN_NOPR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_RATING_COMP" runat="server">Lembaga Pemeringkat :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_RATING_COMP" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_RATING_RESULT" runat="server">Peringkat Perusahaan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_RATING_RESULT" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_RATING_DATE_MM" runat="server">Tanggal Pemeringkatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_RATING_DATE_DD" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CIF_RATING_DATE_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CIF_RATING_DATE_YY" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_BUSINESS_TYPE" runat="server">Bentuk Badan Usaha :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_BUSINESS_TYPE" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" colSpan="2">Perorangan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_SEX_TYPE" runat="server">Jenis Kelamin :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_SEX_TYPE" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_MOTHER_NM" runat="server">Nama Gadis Ibu Kandung :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_MOTHER_NM" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_PREFIK_NAME" runat="server">Nama Prefik :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_PREFIK_NAME" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_CUST_COMP_NAME" runat="server">Nama Perush. Nasabah Bekerja :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_CUST_COMP_NAME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_BIDANG_USAHA" runat="server">Bidang Usaha Nasabah :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_BIDANG_USAHA" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_JOB_TITLE" runat="server">Jabatan Nasabah :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_JOB_TITLE" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_CUST_OCCUPATION" runat="server">Pekerjaan Nasabah :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CIF_CUST_OCCUPATION" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_SALARY" runat="server">Gaji :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_SALARY" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_MAIN_INCOME" runat="server">Pendapatan Utama :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_MAIN_INCOME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF_OTHER_INCOME" runat="server">Pendapatan Lainnya :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF_OTHER_INCOME" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_CITIZEN" runat="server">Kewarganegaraan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CIF_CITIZEN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CIF_MARITAL" runat="server">Status Perkawinan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CIF_MARITAL" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE_GENERALDATA" runat="server" Width="76px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_GENERALDATA" runat="server" Width="76px" Text="CLEAR" CssClass="Button1"></asp:button>
							<!--<asp:button id="BTN_UPDATE_STATUS_GENERALDATA" runat="server" Width="146px" Text="UPDATE STATUS" CssClass="Button1"></asp:button>-->
						</TD>
					</TR>
				</TABLE>
				<BR>
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
					<TR>
						<TD class="td" vAlign="top" width="30%" colSpan="3">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="30%">
								<TR>
									<TD class="TDBGColor1" width="30%"><STRONG>TOTAL SAHAM :</STRONG></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TOT_SAHAM" runat="server" Width="100%" MaxLength="50" ReadOnly="True"></asp:textbox></TD>
									<TD>&nbsp;<STRONG>(%)</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF No :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NAMA" runat="server">Nama :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA" runat="server" Width="100%" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNS_NASABAH" runat="server">Jenis Nasabah :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNS_NASABAH" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_COMP" runat="server">BOD/Berdiri Sejak :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_COMP" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_COMP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_COMP" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNS_KELAMIN" runat="server">Jenis Kelamin :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNS_KELAMIN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SAHAM" runat="server">Share Saham (%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_SAHAM" runat="server" Width="50%" MaxLength="20"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNS_ID" runat="server">Jenis ID Utama :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNS_ID" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" align="center" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ID_UTAMA" runat="server">No. ID Utama :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ID_UTAMA" runat="server" Width="100%" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_EXP" runat="server">Expired Date ID Utama :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_EXP_DAY" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_EXP" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_EXP_YEAR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT" runat="server">Alamat :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT" runat="server" Width="100%" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CU_ZIPCODE" runat="server">Kode Pos :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" Width="100px"
											AutoPostBack="True" MaxLength="6" Columns="6"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BUC" runat="server">BUC :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUC" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_KODE_HUB" runat="server">Kode Hubungan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KODE_HUB" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_CHK_REMOVED" runat="server">Remove: Link</asp:label></TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_REMOVED" AutoPostBack="True" Text="(check for Yes)" Runat="server"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:button id="BTN_ADD_DATAPENGURUS" runat="server" Text="ADD" Width="76px" CssClass="button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_DATAPENGURUS" runat="server" Text="CLEAR" Width="76px" CssClass="button1"></asp:button>
							<!--<asp:button id="BTN_UPDATE_DATAPENGURUS" runat="server" Text="UPDATE" CssClass="button1"></asp:button>-->
						</TD>
					</TR>
				</TABLE>
				</TD></TR></TABLE> 
				<!-- ******************************************************************************************** -->
				<!-- === DATA KEUANGAN === --><BR>
				<TABLE width="100%" border="0">
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA KEUANGAN</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_LAP" runat="server">Posisi Laporan Keuangan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAP" runat="server" MaxLength="2"
											Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_LAP" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAP" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_RDO_PINJAMAN_LN" runat="server">Pinjaman Luar Negeri :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:radiobuttonlist id="RDO_PINJAMAN_LN" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_DENO" runat="server">Denominasi :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_DENO" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_AUDITED" runat="server">Audited/Unaudited :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_AUDITED" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CURR" runat="server">Currency :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CURR" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_JML_BLN" runat="server">Jumlah Bulan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JML_BLN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="3">AKTIVA</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ACTIVA" runat="server">Aktiva Lancar :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ACTIVA" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TOT_ACTIVA" runat="server">Total Aktiva :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TOT_ACTIVA" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" colSpan="3">PASIVA</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_WJB_BANK" runat="server">Kewajiban kepada Bank :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_WJB_BANK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_WJB_LANCAR" runat="server">Kewajiban Lancar :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_WJB_LANCAR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TOT_WJB" runat="server">Total Kewajiban :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TOT_WJB" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_MODAL" runat="server">Modal :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MODAL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="3">LABA/RUGI</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENJUALAN" runat="server">Penjualan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENJUALAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_POP" runat="server">Pendapatan Operasional :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_POP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_BOP" runat="server">Biaya Operasioanl :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BOP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NON_POP" runat="server">Pendapatan Non Operasional :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NON_POP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NON_BOP" runat="server">Biaya Non Operasional :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NON_BOP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_LR_AFTER" runat="server">Laba Rugi Thn Lalu (Stlh Pajak) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="LR_AFTER" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_LR_BEFORE" runat="server">Laba Rugi Thn Lalu (Sblm Pajak) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="LR_BEFORE" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<asp:button id="BTN_SAVE_DATAKEUANGAN" runat="server" Width="76px" Text="ADD" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_DATAKEUANGAN" runat="server" Width="76px" Text="CLEAR" CssClass="Button1"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
