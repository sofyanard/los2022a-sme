<%@ Page language="c#" Codebehind="DetailSandiBIData.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.Booking.DetailSandiBIData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailSandiBIData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="td" vAlign="top" width="100%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">Jenis Penggunaan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JenisPenggunaan" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<tr>
									<td class="TDBGColor1">Jenis Kredit</td>
									<td width="15"></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="DDL_JenisKredit" runat="server" CssClass="mandatory"></asp:dropdownlist></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Sektor Ekonomi BI 1</TD>
									<TD style="HEIGHT: 14px" width="15"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:dropdownlist id="DDL_SektorEkonomi" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_SektorEkonomi_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub Sektor Ekonomi BI 2</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SUBSEKTORBM" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_SUBSEKTORBM_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<tr>
									<td class="TDBGColor1">&nbsp;Sub Sub Sektor Ekonomi BI 3</td>
									<td></td>
									<td class="TDBGColorValue"><asp:dropdownlist id="DDL_SUBSUBSEKTORBM" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_SUBSUBSEKTORBM_SelectedIndexChanged"></asp:dropdownlist></td>
								</tr>
								<TR>
									<TD class="TDBGColor1">Sektor Ekonomi BI 4</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEKTOREKONOMIBI" runat="server" CssClass="mandatory" Enabled="False" onselectedindexchanged="DDL_SEKTOREKONOMIBI_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Orientasi Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_OrientasiPenggunaan" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sifat&nbsp;Kredit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SifatKredit" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Lokasi Proyek</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_LokasiProyek" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Fasilitas Penyediaan Dana</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_FasilitasDana" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label><asp:label id="LBL_CUREF" Visible="False" Runat="server"></asp:label><asp:label id="LBL_REGNO" Visible="False" Runat="server"></asp:label><asp:label id="LBL_PRODUCTID" Visible="False" Runat="server"></asp:label><asp:label id="LBL_PROD_SEQ" Visible="False" Runat="server"></asp:label></td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" 
                                CssClass="button1" Runat="server" Text="SIMPAN" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:dropdownlist id="DDL_BUSSTYPE" runat="server" Visible="False" onselectedindexchanged="DDL_BUSSTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
