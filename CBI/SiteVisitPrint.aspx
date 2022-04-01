<%@ Page language="c#" Codebehind="SiteVisitPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.CBI.SiteVisitPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Laporan Kontak dan Kunjungan Nasabah</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<!-- Rubah di sini -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="650" border="1">
				<TBODY>
					<!--
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						-->
					<TR id="TRPRINT">
						<TD class="TDBGColor2" colSpan="2"><INPUT class="Button1" onclick="cetak()" type="button" value="Print" name="TRPRINT" CssClass="Button1">
							<INPUT class="Button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
								value="Back" name="BTN_BACK">
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><STRONG>GENERAL INFORMATION</STRONG></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="20%">Name</TD>
									<TD></TD>
									<TD><asp:label id="LBL_CU_NAME" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD>Address</TD>
									<TD vAlign="top"></TD>
									<TD><asp:label id="LBL_CU_ADDR" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD>Contact Person</TD>
									<TD vAlign="top"></TD>
									<TD><asp:label id="LBL_CU_CONTACTPERSON" runat="server" Width="100%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="150">Relationship Manager</TD>
									<TD></TD>
									<TD><asp:label id="LBL_AP_RELMNGR" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD>Credit Analyst</TD>
									<TD></TD>
									<TD><asp:label id="LBL_CREDIT_ANALIS_" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD>Unit</TD>
									<TD></TD>
									<TD><asp:label id="LBL_BRANCH_CODE" runat="server" Width="100%"></asp:label></TD>
								</TR>
								<TR>
									<TD>Group</TD>
									<TD></TD>
									<TD><asp:label id="LBL_GROUP_" runat="server" Width="100%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><STRONG><STRONG>LAPORAN KONTAK DAN KUNJUNGAN NASABAH</STRONG></STRONG></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="2">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
								<TR>
									<TD width="24%">Tanggal Kunjungan</TD>
									<TD width="1%"></TD>
									<TD width="75%">
										<asp:label id="LBL_SV_DATE" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Nama Yang Ditemui</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_NAME" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Tujuan kunjungan dan hal-hal yang dibicarakan</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_TUJUAN" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD colSpan="3"><b>Hasil Kunjungan Yang Lalu Yang Belum Ditindaklanjuti</b></TD>
								</TR>
								<TR>
									<TD width="24%">Nasabah</TD>
									<TD width="1%"></TD>
									<TD width="75%">
										<asp:label id="LBL_SV_NASABAH" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Bank</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_BANK" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD colSpan="3"><b>Hasil-hasil Kunjungan / Pembicaraan</b></TD>
								</TR>
								<TR>
									<TD colSpan="3"><b>1. Lokasi Usaha</b></TD>
								</TR>
								<TR>
									<TD width="24%">Kantor</TD>
									<TD width="1%"></TD>
									<TD width="75%">
										<asp:label id="LBL_SV_OFFICE" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Pabrik</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_FACTORY" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD colSpan="3"><b>2. Kondisi Usaha</b></TD>
								</TR>
								<TR>
									<TD width="24%">Manajemen</TD>
									<TD width="1%"></TD>
									<TD width="75%">
										<asp:label id="LBL_SV_MANAGEMENT" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Produksi</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_PRODUKSI" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Pemasaran</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_PEMASARAN" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Keuangan</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_KEUANGAN" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD>Agunan</TD>
									<TD></TD>
									<TD>
										<asp:label id="LBL_SV_AGUNAN" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD colSpan="3"><b>Persoalan Yang Harus Diselesaikan</b></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<asp:label id="LBL_SV_PERSOALAN" runat="server"></asp:label></TD>
								</TR>
								<TR>
									<TD colSpan="3"><b>Tanggal Target</b></TD>
								</TR>
								<TR>
									<TD colSpan="3"><asp:label id="LBL_SV_TARGETDATE" runat="server" Width="100%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
