<%@ Page language="c#" Codebehind="LoanDetailDataBU.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.LoanDetailDataBU" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoanDetailDataBU</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="left">
						<TABLE id="Table31">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LOAN&nbsp;DETAIL DATA</B></TD>
							</TR>
						</TABLE>
					</td>
					<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">Error Message</TD>
				</TR>
				<TR>
					<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_ERROR_MSG" TextMode="MultiLine" Height="80px" Runat="server" Width="100%"
							MaxLength="8000" Enabled="False"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">General&nbsp;Data</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px">Sifat Kredit</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SIFATKREDIT" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px" width="160">Jenis Penggunaan</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNSPENGGUNAAN" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px" width="160">Orientasi Penggunaan</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_ORIENTASI_PENGGUNAAN" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px">Golongan Kredit</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_GOLKREDIT" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px" width="160">Jenis Kredit</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNSKREDIT" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px; HEIGHT: 8px" width="160">Fasilitas 
									Penyediaan Dana</TD>
								<TD style="WIDTH: 15px; HEIGHT: 8px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_FACDANA" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px">Bank Utama Sindikasi</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_BANK_UTAMA" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px" width="160">Lokasi Proyek</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_LOKASI_PROYEK" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 160px" width="160">Nilai Proyek</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_NILAI_PROYEK" Runat="server" Width="296px" MaxLength="100" AutoPostBack="True" ontextchanged="TXT_NILAI_PROYEK_TextChanged"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px" width="167">Alamat Proyek</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_ADD_PROYEK" Runat="server" Width="296px" MaxLength="200"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px">Golongan Penjamin</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_GOL_PENJAMIN" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px" width="167">Bagian yang Dijamin</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_JAMINAN" Runat="server" Width="296px" MaxLength="50" AutoPostBack="True" ontextchanged="TXT_JAMINAN_TextChanged"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px" width="167">Kolektibilitas BI (Tiga 
									Pilar)</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KOL_BI" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px" width="167">Kolektibilitas BM</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KOL_BM" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px" width="167">KSBI 1</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI1" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_KSBI1_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px">KSBI 2</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI2" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_KSBI2_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px" width="167">KSBI 3</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI3" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_KSBI3_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 167px" width="167">KSBI 4</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI4" runat="server"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
