<%@ Page language="c#" Codebehind="Collateral_Bond.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.Collateral_Bond" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Collateral_Bond</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../../include/cek_all.html" -->
		<!-- #include  file="../../../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">Keterangan&nbsp;Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" CssClass="mandatory"
											Columns="25" Width="400" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 21px">Mata Uang</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Posisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_posisi" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST ke CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_KE_CA" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST dari&nbsp;CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_DARI_CA" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SIBS_COLID" Columns="30" MaxLength="35"
											Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Bond</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_BONDTYPE" runat="server"></asp:dropdownlist>&nbsp;
										<asp:checkbox id="CHB_CL_ISCASHEDVALUE" runat="server" Visible="False"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Regitrasi No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_REGNO" runat="server" Columns="20" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Security No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_SECURITYNO" runat="server" CssClass="mandatory"
											Columns="20" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUE" onblur="FormatCurrency(this)"
											runat="server" CssClass="mandatory" Columns="25" MaxLength="21"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUE2" onblur="FormatCurrency(this)"
											runat="server" CssClass="mandatory" Columns="25" MaxLength="21"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Asuransi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUEINS" onblur="FormatCurrency(this)"
											runat="server" Columns="25" MaxLength="21"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUEIKAT" onblur="FormatCurrency(this)"
											runat="server" Columns="25" MaxLength="21"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUEPPA" onblur="FormatCurrency(this)"
											runat="server" Columns="25" MaxLength="21"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUELIQ" onblur="FormatCurrency(this)"
											runat="server" Columns="25" MaxLength="21"></asp:textbox></TD>
								</TR>
								<!--<TR>
									<TD class="TDBGColor1">Nilai Pasar Saat Ini</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_MARKETVALUE" runat="server" MaxLength="21" Columns="25" onkeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>-->
								<TR>
									<TD class="TDBGColor1">Tanggal Pendaftaran</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_REGDATEDAY" runat="server" Columns="2"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CL_REGDATEMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_REGDATEYEAR" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Diterbitkan Oleh</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_ISSUEDBY" runat="server" Columns="20"
											Width="250" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_ISSUEDDATEDAY" runat="server" Columns="2"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CL_ISSUEDDATEMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_ISSUEDDATEYEAR" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Jatuh Tempo</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_DUEDATEDAY" runat="server" Columns="2"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_CL_DUEDATEMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_DUEDATEYEAR" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kondisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_CONDITION" runat="server" Columns="20"
											MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemilik</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_OWNER" runat="server" CssClass="mandatory"
											Columns="20" Width="400" MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 6px">Hubungan</TD>
									<TD style="HEIGHT: 6px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 6px"><asp:dropdownlist id="DDL_CL_RELATIONSHIP" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah / ukuran Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_COLLAMOUNT" onblur="FormatCurrency(this)"
											runat="server" CssClass="mandatory" Columns="25" MaxLength="21"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px">Jenis Pengikatan</TD>
									<TD style="HEIGHT: 18px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_CL_IKATTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penilaian Menurut</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_VALACCRDTO" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Peringkat Surat Berharga</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_PERINGKAT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_JNSAGUNAN" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:Button id="btn_save" runat="server" CssClass="button1" Text="Save" Visible="False" onclick="btn_save_Click"></asp:Button>
							<asp:button id="BTN_FINISH" runat="server" Width="106px" Text="FINISH" CssClass="Button1" Enabled="False" onclick="BTN_FINISH_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_FIND" runat="server">
						<TD class="tdNoBorder" style="WIDTH: 483px" vAlign="top" width="483">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CAO Name :</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:dropdownlist id="DDL_CAO_NAME" runat="server"></asp:dropdownlist>
										<asp:button id="BTN_SEND" Runat="server" Text="Send" onclick="BTN_SEND_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp;
							<asp:label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_bond" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
