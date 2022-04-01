<%@ Page language="c#" Codebehind="LCDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.Trade.LCDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>LCDataComplet</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
		<STYLE type="text/css">.pl { MARGIN-RIGHT: 3px }
		</STYLE>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<asp:label id="Label33" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
					Visible="False">Label</asp:label>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LC Data Completeness</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF # :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUSTNAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUSTNAME" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNS_NASABAH" runat="server">Jenis Nasabah :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNS_NASABAH" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_LC" runat="server">No. LC :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_LC" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS_LC" runat="server">Jenis LC :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:DropDownList id="DDL_JENIS_LC" runat="server" Width="100%"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNS_VALUTA" runat="server">Jenis Valuta :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNS_VALUTA" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_MULAI" runat="server">Mulai :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_MULAI" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_MULAI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_MULAI" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_JATUH_TEMPO" runat="server">Jatuh Tempo :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_JATUH_TEMPO" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_JATUH_TEMPO" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_JATUH_TEMPO" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_GOL_PEMOHON" runat="server">Golongan Pemohon :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOL_PEMOHON" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_HUB_BANK" runat="server">Hubungan Dengan Bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_HUB_BANK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_STATUS_PEMOHON" runat="server">Status Pemohon :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STATUS_PEMOHON" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_NEGARA_PEMOHON" runat="server">Negara Pihak Pemohon :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_NEGARA_PEMOHON" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_LEMBAGA_PEMERINGKAT" runat="server">Lembaga Pemeringkat :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_LEMBAGA_PEMERINGKAT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_PERINGKAT_PERUSAHAAN" runat="server">Peringkat Perusahaan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PERINGKAT_PERUSAHAAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_PEMERINGKAT" runat="server">Tanggal Pemeringkatan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PEMERINGKAT" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_PEMERINGKAT" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PEMERINGKAT" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BANK_BENEFICIARY" runat="server">Bank Beneficiary :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_BANK_BENEFICIARY" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_CARAPEMBAYARAN_LC" runat="server">Cara Pembayaran LC :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_CARAPEMBAYARAN_LC" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NOMINAL_LC" runat="server">Nominal LC :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOMINAL_LC" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PLAFON" runat="server">Plafon :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFON" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PLAFON_INDUK" runat="server">Plafon Induk :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFON_INDUK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS_AGUNAN" runat="server">Jenis Agunan/Jaminan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_AGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_SIFAT_AGUNAN" runat="server">Sifat Agunan/Jaminan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SIFAT_AGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS_VALUTA_AGUNAN" runat="server">Jenis Valuta Agunan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_VALUTA_AGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_MULAI2" runat="server">Jangka Waktu Mulai :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_MULAI2" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_MULAI2" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_MULAI2" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_JANGKA_WAKTU2" runat="server">Jangka Waktu Jatuh Tempo :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_JANGKA_WAKTU2" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_JANGKA_WAKTU2" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_JANGKA_WAKTU2" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_AGUNAN" runat="server">Nilai Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_AGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_PENILAIAN_TERAKHIR" runat="server">Tanggal Penilaian Terakhir :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN_TERAKHIR" runat="server"
											Columns="2" MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_PENILAIAN_TERAKHIR" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PENILAIAN_TERAKHIR" runat="server"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_PENERBIT_AGUNAN" runat="server">Penerbit Agunan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PENERBIT_AGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PARIPASU" runat="server">Paripasu :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PARIPASU" runat="server" Width="50%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PPAP_YG_DIBENTUK" runat="server">PPAP Yang Dibentuk :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PPAP_YG_DIBENTUK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SETORAN_JAMINAN" runat="server">Setoran Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SETORAN_JAMINAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NOMOR_AKAD_AWAL" runat="server">Nomor Akad Awal :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOMOR_AKAD_AWAL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_AKAD_AWAL" runat="server">Tanggal Akad Awal :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_AKAD_AWAL" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_AKAD_AWAL" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_AKAD_AWAL" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NOMOR_AKAD_AKHIR" runat="server">Nomor Akad Akhir :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOMOR_AKAD_AKHIR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"  width="50%"><asp:label id="LBL_DDL_MM_TANGGALAKADAKHIR" runat="server">Tanggal Akad Akhir :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TANGGALAKADAKHIR" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TANGGALAKADAKHIR" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TANGGALAKADAKHIR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_KOLEKTIBILITAS" runat="server">Kolektibilitas :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:DropDownList id="DDL_KOLEKTIBILITAS" runat="server" Width="100%"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLMACET" runat="server">Tanggal Macet :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLMACET" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLMACET" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLMACET" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_SEBABMACET" runat="server">Sebab Macet :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SEBABMACET" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KETERANGANMACET" runat="server">Keterangan Macet :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KETERANGANMACET" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLWANPRESTASI" runat="server">Tgl. Wan Prestasi :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLWANPRESTASI" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLWANPRESTASI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLWANPRESTASI" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KONDISI" runat="server">Kondisi :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KONDISI" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLKONDISI" runat="server">Tgl. Kondisi :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLKONDISI" runat="server" Columns="2"
											MaxLength="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLKONDISI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLKONDISI" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
							<asp:button id="BTN_SAVE" runat="server" Width="76px" Text="SAVE" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="76px" Text="CLEAR" CssClass="Button1"></asp:button>
							<!--<asp:button id="BTN_UPDATE" runat="server" Width="121px" Text="UPDATE STATUS" CssClass="Button1"></asp:button>-->
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
