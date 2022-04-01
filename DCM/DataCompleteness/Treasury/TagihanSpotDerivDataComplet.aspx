<%@ Page language="c#" Codebehind="TagihanSpotDerivDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.Treasury.TagihanSpotDerivDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>TagihanSpotDerivDataComplet</TITLE>
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
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" colspan="2">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Data Tagihan Spot &amp; 
											Derivatif</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="3">General Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CIF" runat="server">CIF# :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CIF" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_CUSTNAME" runat="server">Customer Name :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CUSTNAME" runat="server" width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_TRANSAKSI" runat="server">No. Transaksi / Rekg :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_TRANSAKSI" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS" runat="server">Jenis :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLDIKELUARKAN" runat="server">Tgl. Dikeluarkan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLDIKELUARKAN" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLDIKELUARKAN" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLDIKELUARKAN" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLJTHTEMPO" runat="server">Tgl. Jatuh Tempo :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLJTHTEMPO" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLJTHTEMPO" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLJTHTEMPO" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_TUJUAN" runat="server">Tujuan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TUJUAN" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENISVALUTA" runat="server">Jenis Valuta :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISVALUTA" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NIKRON_KURSASAL" runat="server">Nilai Kontrak Curr. Asal :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NIKRON_KURSASAL" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KURS" runat="server">Kurs :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_KURS" runat="server" Width="100%"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NIKRON_RP" runat="server">Nilai Kontrak (Rp) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NIKRON_RP" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_TAGIHAN" runat="server">Nilai Tagihan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_TAGIHAN" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_COUNTERPART" runat="server">Penerbit / Counterparty :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_COUNTERPART" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_VARDASAR" runat="server">Variabel yg mendasari :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_VARDASAR" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_GOL_PHK_LAWAN" runat="server">Golongan Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOL_PHK_LAWAN" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_HUBBANK" runat="server">Hubungan dgn bank :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_HUBBANK" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_STSPHKLAWAN" runat="server">Status Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STSPHKLAWAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_LBG_PMRKT" runat="server">Lembaga Pemeringkat :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_LBG_PMRKT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_PRKTPHKLWN" runat="server">Peringkat Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PRKTPHKLWN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLPMRKT" runat="server">Tgl. Pemeringkatan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPMRKT" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLPMRKT" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPMRKT" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_NRGPHKLWN" runat="server">Negara Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_NRGPHKLWN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KUALITAS" runat="server">Kualitas :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KUALITAS" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_RDO_SCR_INDIVIDUAL" runat="server">Secara Individual :</asp:label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_SCR_INDIVIDUAL" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="1">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_RDO_SCR_KOLEKTIF" runat="server">Secara Kolektif :</asp:label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_SCR_KOLEKTIF" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="1">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_SIFATAGUNAN" runat="server">Sifat Agunan/Jaminan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SIFATAGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNSAGUNAN" runat="server">Jenis Agunan/Jaminan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNSAGUNAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JNSVALUTA" runat="server">Jenis Valuta Agunan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JNSVALUTA" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_JWMULAI" runat="server">JW Mulai :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_JWMULAI" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_JWMULAI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_JWMULAI" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_JWJTHTEMPO" runat="server">JW.Jatuh Tempo :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_JWJTHTEMPO" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_JWJTHTEMPO" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_JWJTHTEMPO" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAIAGUNAN" runat="server">Nilai Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAIAGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLPNLNTRKHR" runat="server">Tgl. Penilaian Terakhir :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPNLNTRKHR" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLPNLNTRKHR" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPNLNTRKHR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PNRBTAGUNAN" runat="server">Penerbit Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PNRBTAGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LBGPMRKT" runat="server">Lembaga Pemeringkat :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_LBGPMRKT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PRKTAGUNAN" runat="server">Peringkat Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRKTAGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_PMRKTAGN" runat="server">Tgl. Pemeringkatan Agunan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_PMRKTAGN" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_PMRKTAGN" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_PMRKTAGN" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NLAGNYGDPTDPRHTNGKN" runat="server">Nilai Agunan yg Dapat Diperhitungkan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NLAGNYGDPTDPRHTNGKN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KOLEKTIBILITAS" runat="server">Kolektibilitas :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KOLEKTIBILITAS" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLMACET" runat="server"> Tanggal Macet :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLMACET" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLMACET" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLMACET" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TUNGGAKANPOKOK" runat="server">Tunggakan Pokok :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TUNGGAKANPOKOK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLTUNGGAKAN" runat="server">Tanggal Tunggakan :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLTUNGGAKAN" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLTUNGGAKAN" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLTUNGGAKAN" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_SEBABMACET" runat="server">Sebab Macet :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SEBABMACET" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_KONDISI" runat="server">Kondisi :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KONDISI" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLKONDISI" runat="server">Tanggal Kondisi :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLKONDISI" runat="server" MaxLength="2"
											Columns="2" CssClass="pl"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLKONDISI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLKONDISI" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PPAPYGDBNTK" runat="server">PPAP yg Dibentuk :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PPAPYGDBNTK" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="3">
							<asp:button id="BTN_SAVE" CssClass="button1" Runat="server" Text="SAVE" Width="76px"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLR" CssClass="button1" Runat="server" Text="CLEAR" Width="76px"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
