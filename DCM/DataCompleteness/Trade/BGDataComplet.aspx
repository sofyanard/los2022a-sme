<%@ Page language="c#" Codebehind="BGDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.Trade.BGDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>BGDataComplet</TITLE>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>BG Data Completeness</B></TD>
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
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNS" runat="server">Jenis :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNS" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NOBG" runat="server">No. BG :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NOBG" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_TUJUANPENERBITAN" runat="server">Tujuan Penerbitan BG :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TUJUANPENERBITAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENERIMAGARANSI" runat="server">Penerima Garansi :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENERIMAGARANSI" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENISVALUTA" runat="server">Jenis Valuta :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISVALUTA" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_MULAI" runat="server">Mulai :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_MULAI" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_MULAI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_MULAI" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_JATUHTEMPO" runat="server">Jatuh Tempo :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_JATUHTEMPO" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_JATUHTEMPO" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_JATUHTEMPO" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_GOLONGAN_PEMOHON" runat="server">Golongan Pemohon :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOLONGAN_PEMOHON" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_HUBUNGAN_DGN_BANK" runat="server">Hubungan Dengan Bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_HUBUNGAN_DGN_BANK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_TUJUAN_HUB_BANK" runat="server">Tujuan Berhubungan dgn Bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TUJUAN_HUB_BANK" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_STATUSPEMOHON" runat="server">Status Pemohon :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STATUSPEMOHON" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_NEGARAPIHAKPEMOHON" runat="server">Negara Pihak Pemohon :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_NEGARAPIHAKPEMOHON" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_LEMBAGAPEMERINGKAT" runat="server">Lembaga Pemeringkat :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_LEMBAGAPEMERINGKAT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_PERINGKATPERUSH" runat="server">Peringkat Perusahaan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PERINGKATPERUSH" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLPEMERINGKATAN" runat="server">Tanggal Pemeringkatan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPEMERINGKATAN" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLPEMERINGKATAN" runat="server" Width="45%" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPEMERINGKATAN" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_BG" runat="server">Nilai Nominal BG :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_BG" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PLAFOND" runat="server">Plafon :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFOND" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PLAFOND_INDUK" runat="server">Plafon Induk :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFOND_INDUK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS_AGUNAN" runat="server">Jenis Agunan/Jaminan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_AGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_SIFAT_AGUNAN" runat="server">Sifat Agunan/Jaminan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SIFAT_AGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNSVALUTA_AGUNAN" runat="server">Jenis Valuta Agunan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNSVALUTA_AGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_JKWKMUL" runat="server">Jangka Waktu Mulai :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_JKWKMUL" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_JKWKMUL" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_JKWKMUL" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_JKWKJATTEMP" runat="server">Jangka Waktu Jatuh Tempo :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_JKWKJATTEMP" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_JKWKJATTEMP" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_JKWKJATTEMP" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_AGUNAN" runat="server">Nilai Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_AGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BLN_PENILAIAN" runat="server">Tanggal Penilaian Terakhir :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_PENILAIAN" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_BLN_PENILAIAN" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_PENILAIAN" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENERBITAGUNAN" runat="server">Penerbit Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENERBITAGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PARIPASU" runat="server">Paripasu :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PARIPASU" runat="server" Width="50%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_AGUNANYGDIPERHTNGKN" runat="server">Agunan yang diperhitungkan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AGUNANYGDIPERHTNGKN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PPAPYGDIBENTUK" runat="server">PPAP Yang Dibentuk :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PPAPYGDIBENTUK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_SETORJAM" runat="server">Setoran Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SETORJAM" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NMR_AKAD_AWAL" runat="server">Nomor Akad Awal :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NMR_AKAD_AWAL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DLL_MM_AKAD_AWAL" runat="server">Tanggal Akad Awal :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_AKAD_AWAL" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DLL_MM_AKAD_AWAL" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_AKAD_AWAL" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NMR_AKAD_AKHIR" runat="server">Nomor Akad Akhir :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NMR_AKAD_AKHIR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLAKADAKHIR" runat="server">Tanggal Akad Akhir :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLAKADAKHIR" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLAKADAKHIR" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLAKADAKHIR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_KOLEKTIBILITAS" runat="server">Kolektibilitas :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:DropDownList id="DDL_KOLEKTIBILITAS" runat="server" Width="100%"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLMACET" runat="server">Tanggal Macet :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLMACET" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLMACET" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLMACET" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_SEBABMACET" runat="server">Sebab Macet :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SEBABMACET" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KET_MACET" runat="server">Keterangan Macet :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KET_MACET" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_WANPRESTASI" runat="server">Tgl. Wan Prestasi :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_WANPRESTASI" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_WANPRESTASI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_WANPRESTASI" runat="server" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KONDISI" runat="server">Kondisi :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KONDISI" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLKONDISI" runat="server">Tgl. Kondisi :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLKONDISI" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLKONDISI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLKONDISI" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
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
