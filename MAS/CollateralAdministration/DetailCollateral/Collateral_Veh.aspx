<%@ Page language="c#" Codebehind="Collateral_Veh.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.Collateral_Veh" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Collateral_Veh</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../../include/cek_all.html" -->
		<!-- #include  file="../../../include/cek_entries.html" -->
		<script language="javascript">
		function RefreshParent(link) {
		window.parent.location.href= link ;
		
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1">
							COLLATERAL</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">Keterangan&nbsp;Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" MaxLength="50"
											Columns="25" Width="400" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Posisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_posisi" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_posisi_SelectedIndexChanged"></asp:dropdownlist>
										<asp:dropdownlist id="ddl_notaris_asuransi" runat="server" Visible="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST ke CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_KE_CA" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST dari&nbsp;CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_DARI_CA" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SIBS_COLID" MaxLength="35" Columns="30"
											readonly Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Dealer</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_DEALER" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Mesin</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_MACHINENO" runat="server" MaxLength="20"
											Columns="20" Width="200" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Number of Unit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_NOOFUNITS" runat="server" MaxLength="8"
											Columns="8"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Manufactured Year</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_MANUFACTUREYY" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Chasis/ Seri</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_CHASISNO" runat="server" MaxLength="20"
											Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kendaraan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_JNSMOBIL" runat="server" MaxLength="20"
											Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 17px">Type / Jenis Unit</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CL_CARTYPE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Brand / Model</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_CARBRAND" runat="server" MaxLength="60"
											Columns="30" Width="250"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Owner / Nama BPKB</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_OWNER" runat="server" MaxLength="100"
											Columns="25" Width="400"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="200">Hubungan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_RELATIONSHIP" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. BPKB</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_BPKBNO" runat="server" MaxLength="20"
											Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Polisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_PLATEID" runat="server" MaxLength="20"
											Columns="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Dinilai Oleh</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_APPRBY" runat="server" MaxLength="100"
											Columns="25" Width="400"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl. Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_ISSUEDDATEDAY" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CL_ISSUEDDATEMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_ISSUEDDATEYEAR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUE" onblur="FormatCurrency(this)"
											runat="server" MaxLength="21" Columns="25" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUE2" onblur="FormatCurrency(this)"
											runat="server" MaxLength="21" Columns="25" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Asuransi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUEINS" onblur="FormatCurrency(this)"
											runat="server" MaxLength="21" Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUEIKAT" onblur="FormatCurrency(this)"
											runat="server" MaxLength="21" Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUEPPA" onblur="FormatCurrency(this)"
											runat="server" MaxLength="21" Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CL_VALUELIQ" onblur="FormatCurrency(this)"
											runat="server" MaxLength="21" Columns="25"></asp:textbox></TD>
								</TR>
								<!--<TR>
									<TD class="TDBGColor1">Jumlah Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_APPRVAL" runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_MARKETVAL" runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Agunan Untuk PPAP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_PPAPVAL" runat="server" MaxLength="21" Columns="25"
											onkeypress="return numbersonly()" CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:textbox></TD>
								</TR>-->
								<TR>
									<TD class="TDBGColor1">Lokasi Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLLOC" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penilaian Menurut</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_VALACCRDTO" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR runat="server" id="tr_tr" Visible="False">
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_JNSAGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR runat="server" id="tr_save">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:dropdownlist id="ddl_process" runat="server" AutoPostBack="True" onselectedindexchanged="ddl_process_SelectedIndexChanged"></asp:dropdownlist>
							<asp:dropdownlist id="DDL_CAO_NAME" runat="server" Visible="False"></asp:dropdownlist>
							<asp:dropdownlist id="DDL_CA_NAME" runat="server" Visible="False"></asp:dropdownlist>
							<asp:button id="btn_process" runat="server" CssClass="button1" Text="Proses" onclick="btn_process_Click"></asp:button>
							<asp:button id="btn_save" runat="server" CssClass="button1" Text="Save" Visible="False" onclick="btn_save_Click"></asp:button>
							<asp:button id="BTN_FINISH" runat="server" Width="106px" CssClass="Button1" Text="FINISH" Enabled="False"
								Visible="False" onclick="BTN_FINISH_Click"></asp:button>
							<asp:button id="BTN_TO_MKA" runat="server" Width="122px" CssClass="Button1" Text="RETURN TO MKA"
								Visible="False" onclick="BTN_TO_MKA_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_FIND" runat="server" Visible="False">
						<TD class="tdNoBorder" style="WIDTH: 483px" vAlign="top" width="483">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CAO Name :</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_CAO_NAME1" runat="server"></asp:dropdownlist><asp:button id="BTN_SEND" Runat="server" Text="Send" onclick="BTN_SEND_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_veh" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
