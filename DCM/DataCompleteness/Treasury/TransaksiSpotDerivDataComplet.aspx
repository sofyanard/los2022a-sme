<%@ Page language="c#" Codebehind="TransaksiSpotDerivDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.Treasury.TransaksiSpotDerivDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>TransaksiSpotDerivDataComplet</TITLE>
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
						<TD align="left">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Data Transaksi Spot &amp; 
											Derivatif</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Data</TD>
					</TR>
					<tr>
						<TD class="td" vAlign="top" width="50%">
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
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_TRANSAKSI" runat="server">No. Transaksi / Rekening :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_TRANSAKSI" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS" runat="server">Jenis :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLDIKELUARKAN" runat="server">Status :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STATUS" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLMULAI" runat="server">Tgl. Mulai :</asp:label></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLMULAI" runat="server" CssClass="pl"
											Columns="2" MaxLength="2"></asp:textbox>
										<asp:dropdownlist id="DDL_MM_TGLMULAI" runat="server" CssClass="pl"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLMULAI" runat="server" Columns="4"
											MaxLength="4"></asp:textbox></TD>
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
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_VALUTADASAR" runat="server">Valuta Dasar :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_VALUTADASAR" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_VALUTALAWAN" runat="server">Valuta Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_VALUTALAWAN" runat="server" width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NIKONCURRASAL" runat="server">Nilai Kontrak Curr. Asal :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NIKONCURRASAL" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KURS" runat="server">Kurs :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KURS" runat="server" width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_KONTRAK" runat="server">Nilai Kontrak (Rp) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_KONTRAK" runat="server" width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_EKSPOSURLIMIT" runat="server">Eksposure Limit :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_EKSPOSURLIMIT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_MARGINDEPOSIT" runat="server">Margin Deposit :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_MARGINDEPOSIT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_POSTERBUKADEBITUR" runat="server">Posisi Terbuka Debitur :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_POSTERBUKADEBITUR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_TUJUAN" runat="server">Tujuan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TUJUAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENIS_HEDGING" runat="server">Jenis Hedging :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENIS_HEDGING" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_UNDERLYINGVAR" runat="server">Underlying Variable :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_UNDERLYINGVAR" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_GOLPHKLAWAN" runat="server">Golongan Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_GOLPHKLAWAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_STTSPHKLAWAN" runat="server">Status Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STTSPHKLAWAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_NGRPHKLAWAN" runat="server">Negara Pihak Lawan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_NGRPHKLAWAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_RDO_TGHNSPOTDERIVATIF" runat="server">Tagihan Spot dan Derivatif :</asp:label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_TGHNSPOTDERIVATIF" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="1">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_RDO_KWJBNPOTDERIVATIF" runat="server">Kewajiban Spot dan Derivatif :</asp:label></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:radiobuttonlist id="RDO_KWJBNPOTDERIVATIF" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="1">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">
							<asp:button id="BTN_SAVE" CssClass="button1" Text="SAVE" Runat="server" Width="76px"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLR" CssClass="button1" Text="CLEAR" Runat="server" Width="76px"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
