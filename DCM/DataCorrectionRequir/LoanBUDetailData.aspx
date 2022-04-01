<%@ Page language="c#" Codebehind="LoanBUDetailData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.LoanBUDetailData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoanBUDetailData</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 475px">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LOAN BU DETAIL DATA</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="left" colSpan="2"><asp:placeholder id="MenuCIF" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">General&nbsp;Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px">
										<asp:Label id="LBL_DDL_SIFATKREDIT" runat="server">Sifat Kredit</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_SIFATKREDIT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px" width="160">
										<asp:Label id="LBL_DDL_JNSPENGGUNAAN" runat="server">Jenis Penggunaan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNSPENGGUNAAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px" width="160">
										<asp:Label id="LBL_DDL_ORIENTASI_PENGGUNAAN" runat="server">Orientasi Penggunaan</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_ORIENTASI_PENGGUNAAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px"><FONT color="#000000">
											<asp:Label id="LBL_DDL_GOLKREDIT" runat="server">Golongan Kredit</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_GOLKREDIT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px" width="160">
										<asp:Label id="LBL_DDL_JNSKREDIT" runat="server">Jenis Kredit</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_JNSKREDIT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px; HEIGHT: 8px" width="160">
										<asp:Label id="LBL_DDL_FACDANA" runat="server">Fasilitas Penyediaan Dana</asp:Label></TD>
									<TD style="WIDTH: 15px; HEIGHT: 8px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_FACDANA" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px">
										<asp:Label id="LBL_DDL_BANK_UTAMA" runat="server">Bank Utama Sindikasi</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_BANK_UTAMA" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px" width="160">
										<asp:Label id="LBL_DDL_LOKASI_PROYEK" runat="server">Lokasi Proyek</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_LOKASI_PROYEK" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 160px" width="160"><FONT color="#000000">
											<asp:Label id="LBL_TXT_NILAI_PROYEK" runat="server">Nilai Proyek</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_NILAI_PROYEK" Runat="server" Width="296px" MaxLength="100" AutoPostBack="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 167px; HEIGHT: 18px" width="167"><FONT color="#000000">
											<asp:Label id="LBL_TXT_ADD_PROYEK" runat="server">Alamat Proyek</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px; HEIGHT: 18px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:textbox id="TXT_ADD_PROYEK" Runat="server" Width="296px" MaxLength="200"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 167px"><FONT color="#000000">
											<asp:Label id="LBL_DDL_GOL_PENJAMIN" runat="server">Golongan Penjamin</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_GOL_PENJAMIN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 167px" width="167"><FONT color="#000000">
											<asp:Label id="LBL_TXT_JAMINAN" runat="server">Bagian yang Dijamin</asp:Label></FONT></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:textbox id="TXT_JAMINAN" Runat="server" Width="296px" MaxLength="50" AutoPostBack="True"></asp:textbox></TD>
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
									<TD class="TDBGColor1" style="WIDTH: 167px" width="167">
										<asp:Label id="LBL_DDL_KSBI1" runat="server">KSEBI 1</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI1" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 167px">
										<asp:Label id="LBL_DDL_KSBI2" runat="server">KSEBI 2</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI2" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 167px" width="167">
										<asp:Label id="LBL_DDL_KSBI3" runat="server">KSEBI 3</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI3" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 167px" width="167">
										<asp:Label id="LBL_DDL_KSBI4" runat="server">KSEBI 4</asp:Label></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_KSBI4" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="76px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="76px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_Click"></asp:button></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
