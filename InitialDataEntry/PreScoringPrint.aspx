<%@ Page language="c#" Codebehind="PreScoringPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PreScoringPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:o>
	<HEAD>
		<title>Pre-scoring</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function cetak()
		{
			TR_ATAS.style.display	= "none";
			window.print();
			TR_ATAS.style.display	= "";
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TBL_SCORINGPRINT" cellSpacing="0" cellPadding="3" width="650" align="left" border="0">
				<TR id="TR_ATAS">
					<TD class="TDBGColor2" width="60%" colSpan="3">&nbsp;
						<asp:button id="btn_BACK" runat="server" Text="Back" CssClass="Button1" onclick="btn_BACK_Click"></asp:button>&nbsp;<INPUT class="Button1" id="BTN_PRINT" onclick="cetak()" type="button" value="Print" name="BTN_PRINT">
					</TD>
				</TR>
				<TR>
					<td align="center" colSpan="2">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD borderColor="#000000" align="center"><STRONG><FONT size="2">P R E - S C O R I N G</FONT></STRONG></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD borderColor="black" align="center"><STRONG><FONT size="2">INITIAL INFORMATION</FONT></STRONG></TD>
							</TR>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="19%">Application No.</td>
								<td width="1%">:</td>
								<td width="30%"><asp:label id="lbl_HD_APREGNO" runat="server"></asp:label></td>
								<td width="19%">Nama</td>
								<td width="1%">:</td>
								<td width="30%"><asp:label id="lbl_HD_PEMOHON" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Reference No.</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_CUREF" runat="server"></asp:label></td>
								<td>Alamat</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_ALAMAT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Tanggal Aplikasi</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_TGLAPP" runat="server"></asp:label></td>
								<td>Kota</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_KOTA" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Sub-Segment/<BR>
									Program</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_PROGRAM" runat="server"></asp:label></td>
								<td>Jenis Perusahaan</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_BUSTYPE" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Business Unit</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_BUSUNIT" runat="server"></asp:label></td>
								<td>Jenis Permohonan</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_JNSMOHON" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Cabang/CBC/Group</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_CABANG" runat="server"></asp:label></td>
								<td>Jenis Kredit</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_JNSKREDIT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Source Code</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_SRCCODE" runat="server"></asp:label></td>
								<td>Credit Scheme</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_CREDITSCM" runat="server"></asp:label></td>
							</tr>
							<TR>
								<td>CA / SBA</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_NAMATL" runat="server"></asp:label></td>
								<td>Requested<BR>
									Amount (Rp. 000)</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_REQAMMT" runat="server"></asp:label></td>
							</TR>
							<tr>
								<td>RM / SBO</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_NAMARM" runat="server"></asp:label></td>
								<td>Total Exposure
									<BR>
									(Rp. 000)
								</td>
								<td>:</td>
								<td><asp:label id="lbl_HD_TOTEXPOSURE" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD colSpan="6"></TD>
							</TR>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
							<TR>
								<TD borderColor="black" align="center" width="19%"><STRONG><FONT size="2">SCORE RESULT</FONT></STRONG></TD>
							</TR>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="39%">Overall StrategyWare Decision</td>
								<td width="1%">:</td>
								<td width="60%"><asp:label id="lbl_SR_OVERALLSW" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Score Classification</td>
								<td>:</td>
								<td><asp:label id="lbl_SR_SCORECLASS" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Visit Indicator</td>
								<td>:</td>
								<td><asp:label id="lbl_SR_VISITINDICATOR" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Financial Analysis Format</td>
								<td>:</td>
								<td><asp:label id="lbl_SR_FINANCIAL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Manual Review Type</td>
								<td>:</td>
								<td><asp:label id="lbl_SR_MANUALREV" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pricing Class</td>
								<td>:</td>
								<td><asp:label id="lbl_SR_PRICINGCLASS" runat="server"></asp:label><asp:label id="lbl_SR_PRICINGCLASS_ID" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Increase Requested</td>
								<td>:</td>
								<td><asp:label id="lbl_SR_PERINCREASE" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Status Response</td>
								<td>:</td>
								<td><asp:label id="lbl_SR_STATRES" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
							</tr>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="1">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">RULE REASON</FONT></STRONG></td>
							</tr>
						</TABLE>
						<ASP:DATAGRID id="dtGrid" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
							CellPadding="0" BorderColor="Black" BorderWidth="1px">
							<Columns>
								<asp:BoundColumn DataField="R_CODE" HeaderText="Rule Reason Code">
									<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Description">
									<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="Black"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="80%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</ASP:DATAGRID><br>
						<!---##########################################################################################-->
						<TABLE id="TBL_DT_MICRO_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">LOW LINE / MICRO</FONT></STRONG></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_DT_MICRO" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<TD width="39%">Working Capital Limit</TD>
								<TD width="1%">:</TD>
								<TD width="60%"><asp:label id="lbl_LO_WCLIMIT" runat="server"></asp:label></TD>
							</tr>
							<TR>
								<TD>Working Capital KUMLTA Limit</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LO_WCKUMLTA" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Working Capital Micro Limit</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LO_WCMICRO" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Investment Loan Standard Limit</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LO_INVLOAN" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Investment Micro Limit</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LO_INVMICRO" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Investment Loan KUMLTA Limit</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LO_INVKUMLTA" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="3"></TD>
							</TR>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_DT_PUKK_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">PUKK</FONT></STRONG></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_DT_PUKK" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td width="39%">Working Capital PUKK Limit</td>
								<td width="1%">:</td>
								<td width="60%"><asp:label id="lbl_PU_WCPUKK" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Total Asset - Land &amp; Building</td>
								<td>:</td>
								<td><asp:label id="lbl_PU_TOTASSET" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD colSpan="3"></TD>
							</TR>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_DT_SMALL_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">SMALL BUSINESS</FONT></STRONG>
								</td>
							</tr>
						</TABLE>
						<TABLE id="TBL_DT_SMALL" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td width="39%">Investment Loan Standard Limit</td>
								<td width="1%">:</td>
								<td width="60%"><asp:label id="lbl_SM_INVLOAN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WC Contractor Routine Limit Plafond</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_WCCROUTINE" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WC Contractor Termyn</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_WCCTERMYN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WC Contractor Turnkey</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_WCCTRUNKEY" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WC SB 100 – 500 Million Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_WCSB100" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WC SB &gt; 500 Million Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_WCSB500" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% SB Bid Bond p.a.</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_PRCSBBID" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% SB Advance Bond p.a.</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_PRCSBADV" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% SB Performance Bond p.a.</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_PRCSBPERF" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% SB Retention Bond p.a.</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_PRCSBRET" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% SB Purchasing Bond p.a.</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_PRCSBPURCH" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>SB Total B/G Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_SBTOTBG" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>SB Plafond L/C Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_SM_SBPLAFOND" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
							</tr>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_DT_MIDDLE_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">MIDDLE COMMERCIAL</FONT></STRONG>
								</td>
							</tr>
						</TABLE>
						<TABLE id="TBL_DT_MIDDLE" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td width="39%">Investment Loan Limit</td>
								<td width="1%">:</td>
								<td width="60%"><asp:label id="lbl_MI_INVLOAN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Working Capital Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_WCLIMIT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Contractor Turnkey Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_CONTURKEY" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Contractor Progress Payment Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_CONPROGRESS" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Contractor Palfond Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_CONPLAFOND" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Bid Bond
								</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_PRCBID" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Advance Bond</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_PRCADV" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Performance Bond</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_PRCPERF" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Retention Bond
								</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_PRCRET" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Bond Other Than Contractor</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_PRCBOND" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Non Cash B/G Plafond</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_NONCASHBG" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>L/C Limit</td>
								<td>:</td>
								<td><asp:label id="lbl_MI_LCLIMIT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
							</tr>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_GI_MICRO_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">GENERAL INFORMATION</FONT></STRONG></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_GI_MICRO" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD align="center" colSpan="3"><STRONG>Informasi Usaha</STRONG></TD>
								<TD align="center" colSpan="3"><STRONG>Informasi Key Person</STRONG></TD>
							</TR>
							<tr>
								<td width="29%">Jenis Perusahaan</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_LOIU_JNSUSAHA" runat="server"></asp:label></td>
								<td width="29%">Nama Pemohon</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_LOIK_PEMOHON" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Jumlah Pegawai</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIU_JMLPEG" runat="server"></asp:label></td>
								<td>Tanggal Lahir</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIK_TGLLAHIR" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Mulai Usaha</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIU_MULAIUSAHA" runat="server"></asp:label></td>
								<td>Jenis Kelamin</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIK_JENKEL" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Lama Kepemilikan Usaha</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOIU_LAMAUSAHA" runat="server"></asp:label></TD>
								<TD>Pendidikan Terakhir</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOIK_PENDIDIKAN" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<td>Existing W/C Limit in Other Bank</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIU_WCOBANK" runat="server"></asp:label></td>
								<td>Status Perkawinan</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIK_KAWIN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
								<td>Jumlah Anak</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIK_ANAK" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><STRONG>Hubungan Dengan Bank</STRONG></td>
								<td>Mulai Menetap di Alamat Sekarang</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIK_TGLMENETAP" runat="server"></asp:label></td>
							</tr>
							<TR>
								<td>Saat Ini Menjadi Nasabah BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOHB_ISNASABAHBM" runat="server"></asp:label></td>
								<td>Miliki Rumah Tinggal Sendiri</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIK_ISRUMAH" runat="server"></asp:label></td>
							</TR>
							<tr>
								<td>Mulai Menjadi Nasabah BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOHB_MULAINASABAH" runat="server"></asp:label></td>
								<td>Umur</td>
								<td>:</td>
								<td><asp:label id="lbl_LOIK_UMUR" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Fasilitas Kredit Saat Ini</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOHB_FASKREDIT" runat="server"></asp:label></TD>
								<TD>Persentase Saham</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOIK_SAHAM" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<td>Limit Kredit Saat Ini</td>
								<td>:</td>
								<td><asp:label id="lbl_LOHB_LIMITKREDIT" runat="server"></asp:label></td>
								<TD colSpan="3"></TD>
							</TR>
							<tr>
								<td>Legal Lawsuit</td>
								<td>:</td>
								<td><asp:label id="lbl_LOHB_LEGAL" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Pemilik</STRONG></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
								<td>Kol. Saat ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOPM_KOLBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><STRONG>Applicant</STRONG></td>
								<td>Frek. Kol. &gt;= 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_LOPM_FREKKOL_2C" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Kol. Pers. Saat Ini di Bank Lain</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_KOLPERSBL" runat="server"></asp:label></td>
								<td>Tercatat Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOPM_DHITAMBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Kol. Pers. Saat Ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_KOLPERSBM" runat="server"></asp:label></td>
								<td>Tercatat Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_LOPM_DHITAMBI" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Kol. Terburuk 12 Bln Terakhir di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_KOLBURUK" runat="server"></asp:label></td>
								<td>Kol. Saat Ini di Bank Lain</td>
								<td>:</td>
								<td><asp:label id="lbl_LOPM_KOLBL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2A 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_KOLPERS_2A" runat="server"></asp:label></td>
								<td colSpan="3"></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2B 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_KOLPERS_2B" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Key Person</STRONG></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_KOLPERS_2C" runat="server"></asp:label></td>
								<td>Kolektibilitas saat ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOKP_KOLBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers &gt;= 3 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_KOLPERS_3" runat="server"></asp:label></td>
								<td>Frek. Kol. &gt;= 2C 12 Bulan Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_LOKP_FREKKOL_2C" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pers. Tercatat Dlm Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_DHITAMBM" runat="server"></asp:label></td>
								<td>Tercatat dalam Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_LOKP_DHITAMBI" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pers. Tercatat Dlm Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_DHITAMBI" runat="server"></asp:label></td>
								<td>Kolektibilitas saat ini di bank lain</td>
								<td>:</td>
								<td><asp:label id="lbl_LOKP_DHITAMBL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WatchList</td>
								<td>:</td>
								<td><asp:label id="lbl_LOAP_WACTHLIST" runat="server"></asp:label></td>
								<td>Tercatat dalam Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_LOKP_DHITAMBM" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD colSpan="6"></TD>
							</TR>
							<TR>
								<TD class="td" align="center" colSpan="6"><STRONG><FONT size="2">LOAN INFORMATION</FONT></STRONG></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><STRONG>Micro / Low Line</STRONG></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Purchasing Plan Amount</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOLO_PURHCPAMT" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>% Interest p.a. (x 100)</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOLO_PRCINTEREST" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Tenor (bulan)</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOLO_TENOR" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Average Net Profit</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOLO_AVGNETPROFIT" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Existing Facilities</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_LOLO_EXISTINGFAC" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<tr>
								<td colSpan="6"></td>
							</tr>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_GI_PUKK_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">GENERAL INFORMATION</FONT></STRONG></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_GI_PUKK" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD align="center" colSpan="3"><STRONG>Informasi Usaha</STRONG></TD>
								<TD align="center" colSpan="3"><STRONG>Informasi Key Person</STRONG></TD>
							</TR>
							<tr>
								<td width="29%">Jenis Perusahaan</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_PUIU_JNSUSAHA" runat="server"></asp:label></td>
								<td width="29%">Nama Pemohon</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_PUIK_PEMOHON" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Jumlah Pegawai</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIU_JMLPEG" runat="server"></asp:label></td>
								<td>Tanggal Lahir</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIK_TGLLAHIR" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Mulai Usaha</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIU_MULAIUSAHA" runat="server"></asp:label></td>
								<td>Jenis Kelamin</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIK_JENKEL" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Lama Kepemilikan Usaha</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_PUIU_LAMAUSAHA" runat="server"></asp:label></TD>
								<TD>Pendidikan Terakhir</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_PUIK_PENDIDIKAN" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<td>Existing W/C Limit in Other Bank</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIU_WCOBANK" runat="server"></asp:label></td>
								<td>Status Perkawinan</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIK_KAWIN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
								<td>Jumlah Anak</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIK_ANAK" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><STRONG>Hubungan Dengan Bank</STRONG></td>
								<td>Mulai Menetap di Alamat Sekarang</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIK_TGLMENETAP" runat="server"></asp:label></td>
							</tr>
							<TR>
								<td>Saat Ini Menjadi Nasabah BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUHB_ISNASABAHBM" runat="server"></asp:label></td>
								<td>Miliki Rumah Tinggal Sendiri</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIK_ISRUMAH" runat="server"></asp:label></td>
							</TR>
							<tr>
								<td>Mulai Menjadi Nasabah BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUHB_MULAINASABAH" runat="server"></asp:label></td>
								<td>Umur</td>
								<td>:</td>
								<td><asp:label id="lbl_PUIK_UMUR" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Fasilitas Kredit Saat Ini</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_PUHB_FASKREDIT" runat="server"></asp:label></TD>
								<TD>Persentase Saham</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_PUIK_SAHAM" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<td>Limit Kredit Saat Ini</td>
								<td>:</td>
								<td><asp:label id="lbl_PUHB_LIMITKREDIT" runat="server"></asp:label></td>
								<TD colSpan="3"></TD>
							</TR>
							<tr>
								<td>Legal Lawsuit</td>
								<td>:</td>
								<td><asp:label id="lbl_PUHB_LEGAL" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Pemilik</STRONG></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
								<td>Kol. Saat ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUPM_KOLBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><STRONG>Applicant</STRONG></td>
								<td>Frek. Kol. &gt;= 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_PUPM_FREKKOL_2C" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Kol. Pers. Saat Ini di Bank Lain</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_KOLPERSBL" runat="server"></asp:label></td>
								<td>Tercatat Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUPM_DHITAMBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Kol. Pers. Saat Ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_KOLPERSBM" runat="server"></asp:label></td>
								<td>Tercatat Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_PUPM_DHITAMBI" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Kol. Terburuk 12 Bln Terakhir di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_KOLBURUK" runat="server"></asp:label></td>
								<td>Kol. Saat Ini di Bank Lain</td>
								<td>:</td>
								<td><asp:label id="lbl_PUPM_KOLBL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2A 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_KOLPERS_2A" runat="server"></asp:label></td>
								<td colSpan="3"></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2B 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_KOLPERS_2B" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Key Person</STRONG></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_KOLPERS_2C" runat="server"></asp:label></td>
								<td>Kolektibilitas saat ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUKP_KOLBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers &gt;= 3 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_KOLPERS_3" runat="server"></asp:label></td>
								<td>Frek. Kol. &gt;= 2C 12 Bulan Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_PUKP_FREKKOL_2C" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pers. Tercatat Dlm Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_DHITAMBM" runat="server"></asp:label></td>
								<td>Tercatat dalam Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_PUKP_DHITAMBI" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pers. Tercatat Dlm Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_DHITAMBI" runat="server"></asp:label></td>
								<td>Kolektibilitas saat ini di bank lain</td>
								<td>:</td>
								<td><asp:label id="lbl_PUKP_DHITAMBL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WatchList</td>
								<td>:</td>
								<td><asp:label id="lbl_PUAP_WACTHLIST" runat="server"></asp:label></td>
								<td>Tercatat dalam Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_PUKP_DHITAMBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="6"></td>
							</tr>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_GI_SMALL_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">GENERAL INFORMATION</FONT></STRONG></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_GI_SMALL" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD align="center" colSpan="3"><STRONG>Informasi Usaha</STRONG></TD>
								<TD align="center" colSpan="3"><STRONG>Informasi Key Person</STRONG></TD>
							</TR>
							<tr>
								<td width="29%">Jenis Perusahaan</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_SMIU_JNSUSAHA" runat="server"></asp:label></td>
								<td width="29%">Nama Pemohon</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_SMIK_PEMOHON" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Jumlah Pegawai</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIU_JMLPEG" runat="server"></asp:label></td>
								<td>Tanggal Lahir</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIK_TGLLAHIR" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Mulai Usaha</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIU_MULAIUSAHA" runat="server"></asp:label></td>
								<td>Jenis Kelamin</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIK_JENKEL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Lama Kepemilikan Usaha</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIU_LAMAUSAHA" runat="server"></asp:label></td>
								<td>Pendidikan Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIK_PENDIDIKAN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Existing W/C Limit in Other Bank</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIU_WCOBANK" runat="server"></asp:label></td>
								<td>Status Perkawinan</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIK_KAWIN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
								<td>Jumlah Anak</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIK_ANAK" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><STRONG>Hubungan Dengan Bank</STRONG></td>
								<td>Mulai Menetap di Alamat Sekarang</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIK_TGLMENETAP" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Saat Ini Menjadi Nasabah BM</td>
								<td>:</td>
								<td><asp:label id="lbl_SMHB_ISNASABAHBM" runat="server"></asp:label></td>
								<td>Miliki Rumah Tinggal Sendiri</td>
								<td>:</td>
								<td><asp:label id="lbl_SMIK_ISRUMAH" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Mulai Menjadi Nasabah BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMHB_MULAINASABAH" runat="server"></asp:label></TD>
								<TD>Umur</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMIK_UMUR" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<td>Fasilitas Kredit Saat Ini</td>
								<td>:</td>
								<td><asp:label id="lbl_SMHB_FASKREDIT" runat="server"></asp:label></td>
								<TD>Persentase Saham</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMIK_SAHAM" runat="server"></asp:label></TD>
							</tr>
							<tr>
								<td>Limit Kredit Saat Ini</td>
								<td>:</td>
								<td><asp:label id="lbl_SMHB_LIMITKREDIT" runat="server"></asp:label></td>
								<TD colSpan="3"></TD>
							</tr>
							<TR>
								<td>Legal Lawsuit</td>
								<td>:</td>
								<td><asp:label id="lbl_SMHB_LEGAL" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Pemilik</STRONG></td>
							</TR>
							<tr>
								<td align="center" colSpan="3"><STRONG></STRONG></td>
								<td>Kol. Saat ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_SMPM_KOLBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<TD align="center" colSpan="3"><STRONG>Applicant</STRONG></TD>
								<td>Frek. Kol. &gt;= 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_SMPM_FREKKOL_2C" runat="server"></asp:label></td>
							</tr>
							<tr>
								<TD>Kol. Pers. Saat Ini di Bank Lain</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMAP_KOLPERSBL" runat="server"></asp:label></TD>
								<td>Tercatat Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_SMPM_DHITAMBM" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Kol. Pers. Saat Ini di BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMAP_KOLPERSBM" runat="server"></asp:label></TD>
								<TD>Tercatat Daftar Hitam di BI</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMPM_DHITAMBI" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<td>Kol. Terburuk 12 Bln Terakhir di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_KOLBURUK" runat="server"></asp:label></td>
								<td>Kol. Saat Ini di Bank Lain</td>
								<td>:</td>
								<td><asp:label id="lbl_SMPM_KOLBL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2A 12 Bln Terakhir
								</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_KOLPERS_2A" runat="server"></asp:label></td>
								<td colSpan="3"></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2B 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_KOLPERS_2B" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Key Person</STRONG></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_KOLPERS_2C" runat="server"></asp:label></td>
								<td>Kolektibilitas saat ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_SMKP_KOLBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers &gt;= 3 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_KOLPERS_3" runat="server"></asp:label></td>
								<td>Frek. Kol. &gt;= 2C 12 Bulan Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_SMKP_FREKKOL_2C" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pers. Tercatat Dlm Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_DHITAMBM" runat="server"></asp:label></td>
								<td>Tercatat dalam Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_SMKP_DHITAMBI" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pers. Tercatat Dlm Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_DHITAMBI" runat="server"></asp:label></td>
								<td>Kolektibilitas saat ini di bank lain</td>
								<td>:</td>
								<td><asp:label id="lbl_SMKP_DHITAMBL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>WatchList</td>
								<td>:</td>
								<td><asp:label id="lbl_SMAP_WACTHLIST" runat="server"></asp:label></td>
								<td>Tercatat dalam Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_SMKP_DHITAMBM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="6"></td>
							</tr>
							<TR>
								<TD class="td" align="center" colSpan="6"><STRONG><FONT size="2"><STRONG><FONT size="2">LOAN 
													INFORMATION</FONT></STRONG></FONT></STRONG></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><STRONG>Contractor Loan</STRONG></STRONG></TD>
								<TD align="center" colSpan="3"><STRONG>Non Cash Loan</STRONG></TD>
							</TR>
							<TR>
								<TD>Turn Key Proj.: Acceptable Proj. Cost</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_1APROJCOST" runat="server"></asp:label></TD>
								<TD>Bid Bond: Non cash Value of Project - General</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_1NCVALPROJ" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Turn Key Proj.: Down Payment Amount</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_1DPAMOUNT" runat="server"></asp:label></TD>
								<TD>Bid Bond: % Propability of Success</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_1PRCPROBSUC" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Termyn: Project Cost (1 project)</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_2PROJCOST" runat="server"></asp:label></TD>
								<TD>Advance Payment Bond: Non cash Value of Project – General</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_ADVPAYMENT" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Termyn: Number of Termyns</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_2NOTERMYN" runat="server"></asp:label></TD>
								<TD>Performance Bond: Non cash Value of Project – General</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_PERFBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Termyn: Down Payment Amounts</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_2DPAMOUNT" runat="server"></asp:label></TD>
								<TD>Retention Bond: Non cash Value of Project – General</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_RETBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Plafond: Total value of Project</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_3TOTVALPROJ" runat="server"></asp:label></TD>
								<TD>Purchasing Bond: Non cash Value of Project</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_PURCHBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Plafond: % Project Cost</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_3PRCPROJCOST" runat="server"></asp:label></TD>
								<TD>BG Plafond: Non cash Value of Project – General</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2NCGENERAL" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Plafond: Term of payment</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_3TERMPAYMENT" runat="server"></asp:label></TD>
								<TD>BG Plafond: Non cash Value of Project - Purchase Bond</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2NCPURCHBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Plafond: Down payment Amount</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_3DPAMOUNT" runat="server"></asp:label></TD>
								<TD>BG Plafond: % Prob of Success Bid Bond</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2PRCPROBSUC" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Plafond: Existing WC Plafond Limit in BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_3WCPLAFONDBM" runat="server"></asp:label></TD>
								<TD>BG Plafond: % Bid Bond</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2BIDBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Plafond: Existing WC Plafond Limit in Other Bank</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMCL_3WCPLAFONDBL" runat="server"></asp:label></TD>
								<TD>BG Plafond: % Advance Bond</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2ADVBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="3"></TD>
								<TD>BG Plafond: % Performance Bod</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2PERFBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><STRONG>Investment Loan</STRONG></TD>
								<TD>BG Plafond: % Retention Bond</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2RETBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Acceptable Project Cost</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMIV_ACCPCOST" runat="server"></asp:label></TD>
								<TD>BG Plafond: % Purchasing Bond</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_2PURCHBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>L/C Limit: Average Value L/c in a Year</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_3AVGVALLC" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>L/C Limit: Avrg Term of L/c in a Year</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_SMNC_3AVGTERMLC" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="6"></TD>
							</TR>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_GI_MIDDLE_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">GENERAL INFORMATION</FONT></STRONG></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_GI_MIDDLE" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD align="center" colSpan="3"><STRONG>Informasi Usaha</STRONG></TD>
								<TD align="center" colSpan="3"><STRONG>Informasi Key Person</STRONG></TD>
							</TR>
							<tr>
								<td width="29%">Jenis Perusahaan</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_MIIU_JNSUSAHA" runat="server"></asp:label></td>
								<td width="29%">Nama Pemohon</td>
								<td width="1%">:</td>
								<td width="20%"><asp:label id="lbl_MIIK_PEMOHON" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Jumlah Pegawai</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIU_JMLPEG" runat="server"></asp:label></td>
								<td>Tanggal Lahir</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_TGLLAHIR" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Mulai Usaha</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIU_MULAIUSAHA" runat="server"></asp:label></td>
								<td>Jenis Kelamin</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_JENKEL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Lama Kepemilikan Usaha</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIU_LAMAUSAHA" runat="server"></asp:label></td>
								<td>Pendidikan Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_PENDIDIKAN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Existing W/C Limit in Other Bank</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIU_WCOBANK" runat="server"></asp:label></td>
								<td>Status Perkawinan</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_KAWIN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"></td>
								<td>Jumlah Anak</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_ANAK" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"><STRONG>Hubungan Dengan Bank</STRONG></td>
								<td>Mulai Menetap di Alamat Sekarang</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_TGLMENETAP" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Saat Ini Menjadi Nasabah BM</td>
								<td>:</td>
								<td><asp:label id="lbl_MIHB_ISNASABAHBM" runat="server"></asp:label></td>
								<td>Miliki Rumah Tinggal Sendiri</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_ISRUMAH" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Mulai Menjadi Nasabah BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIHB_MULAINASABAH" runat="server"></asp:label></TD>
								<TD>Umur</TD>
								<TD></TD>
								<TD><asp:label id="lbl_MIIK_UMUR" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<td>Fasilitas Kredit Saat Ini</td>
								<td>:</td>
								<td><asp:label id="lbl_MIHB_FASKREDIT" runat="server"></asp:label></td>
								<td>Persentase Saham</td>
								<td>:</td>
								<td><asp:label id="lbl_MIIK_SAHAM" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Limit Kredit Saat Ini</td>
								<td>:</td>
								<td><asp:label id="lbl_MIHB_LIMITKREDIT" runat="server"></asp:label></td>
								<td colSpan="3"></td>
							</tr>
							<tr>
								<td>Legal Lawsuit</td>
								<td>:</td>
								<td><asp:label id="lbl_MIHB_LEGAL" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Pemilik</STRONG></td>
							</tr>
							<TR>
								<TD colSpan="3"></TD>
								<TD>Kol. Saat ini di BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIPM_KOLBM" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<td align="center" colSpan="3"><STRONG>Applicant</STRONG></td>
								<td>Frek. Kol. &gt;= 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_MIPM_FREKKOL_2C" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Kol. Pers. Saat Ini di Bank Lain</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIAP_KOLPERSBL" runat="server"></asp:label></TD>
								<td>Tercatat Daftar Hitam di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_MIPM_DHITAMBM" runat="server"></asp:label></td>
							</TR>
							<tr>
								<TD>Kol. Pers. Saat Ini di BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIAP_KOLPERSBM" runat="server"></asp:label></TD>
								<td>Tercatat Daftar Hitam di BI</td>
								<td>:</td>
								<td><asp:label id="lbl_MIPM_DHITAMBI" runat="server"></asp:label></td>
							</tr>
							<tr>
								<TD>Kol. Terburuk 12 Bln Terakhir di BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIAP_KOLBURUK" runat="server"></asp:label></TD>
								<td>Kol. Saat Ini di Bank Lain</td>
								<td>:</td>
								<td><asp:label id="lbl_MIPM_KOLBL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2A 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_MIAP_KOLPERS_2A" runat="server"></asp:label></td>
								<td colSpan="3"></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2B 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_MIAP_KOLPERS_2B" runat="server"></asp:label></td>
								<td align="center" colSpan="3"><STRONG>Key Person</STRONG></td>
							</tr>
							<tr>
								<td>Frek. Kol. Pers. 2C 12 Bln Terakhir</td>
								<td>:</td>
								<td><asp:label id="lbl_MIAP_KOLPERS_2C" runat="server"></asp:label></td>
								<td>Kolektibilitas saat ini di BM</td>
								<td>:</td>
								<td><asp:label id="lbl_MIKP_KOLBM" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Frek. Kol. Pers &gt;= 3 12 Bln Terakhir</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIAP_KOLPERS_3" runat="server"></asp:label></TD>
								<TD>Frek. Kol. &gt;= 2C 12 Bulan Terakhir</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIKP_FREKKOL_2C" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Pers. Tercatat Dlm Daftar Hitam di BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIAP_DHITAMBM" runat="server"></asp:label></TD>
								<TD>Tercatat dalam Daftar Hitam di BI</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIKP_DHITAMBI" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Pers. Tercatat Dlm Daftar Hitam di BI</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIAP_DHITAMBI" runat="server"></asp:label></TD>
								<TD>Kolektibilitas saat ini di bank lain</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIKP_DHITAMBL" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>WatchList</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIAP_WACTHLIST" runat="server"></asp:label></TD>
								<TD>Tercatat dalam Daftar Hitam di BM</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MIKP_DHITAMBM" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="6"></TD>
							</TR>
							<TR>
								<TD class="td" align="center" colSpan="6"><STRONG><FONT size="2">LOAN INFORMATION</FONT></STRONG></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><STRONG>Contractor Loan</STRONG></TD>
								<TD align="center" colSpan="3"><STRONG>Non Cash Loan</STRONG></TD>
							</TR>
							<TR>
								<TD>Turn Key Proj.: Acceptable Proj. Cost</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MICL_1APROJCOST" runat="server"></asp:label></TD>
								<TD>Bid Bond: Amount of Contract</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_AMOUNTCONT" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Turn Key Proj.: Down Payment Amount</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MICL_1DPAMOUNT" runat="server"></asp:label></TD>
								<TD>Adv. Payment Bond: Amount of Contract</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_ADVPAYMENT" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Progress Payment: Peak Deficit C. Flow</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MICL_2PEAKDEFICIT" runat="server"></asp:label></TD>
								<TD>Performance Bond: Amount of Contract</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_PERFBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Plafond: Peak Deficit Cash Flow</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MICL_3PDCASHFLOW" runat="server"></asp:label></TD>
								<TD>Retention Bond: Amount of Contract</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_RETBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>Bond Other Than Contractor: Amount of Contract</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_BONDOCONT" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>BG Bond: % Avrg. Total Bond Needed</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_AVGTOTBOND" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>Contractor Peak Deficit Cash Flow</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_CONTPEAK" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>L/C Limit: Avrg. Value Limit In a Year
								</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_3AVGVALLC" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD>L/C Limit: Avrg Term of L/C In a Year (Turn Over In Month)</TD>
								<TD>:</TD>
								<TD><asp:label id="lbl_MINC_3AVGTERMLC" runat="server"></asp:label></TD>
							</TR>
							<tr>
								<td colSpan="6"></td>
							</tr>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_NE_SMALL_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">NERACA</FONT></STRONG><br>
									<asp:label id="lbl_SMNE_PERTGL" runat="server"></asp:label></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_NE_SMALL" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD align="center" colSpan="3"><STRONG>AKTIVA</STRONG></TD>
								<TD></TD>
								<TD align="center" colSpan="3"><STRONG>PASIVA</STRONG></TD>
							</TR>
							<TR>
								<TD width="29%"><STRONG>Aktiva Lancar</STRONG></TD>
								<TD width="1%"></TD>
								<TD width="20%"></TD>
								<TD width="5">&nbsp;&nbsp;&nbsp;</TD>
								<TD width="29%"><STRONG>Hutang Lancar</STRONG></TD>
								<TD width="1%"></TD>
								<TD width="20%"></TD>
							</TR>
							<TR>
								<TD>Kas dan Bank</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_KASBANK" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Hutang Dagang</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_HUTDAG" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Piutang Dagang</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_PIUTANGD" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Hutang Bank</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_HUTBANK" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Persediaan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_PERSEDIAAN" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Bagian KI Jatuh Tempo 12 Bulan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_BAGIANKI" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Aktiva Lancar Lainnya</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_AKTLCRLAIN" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Hutang Lancar Lainnya</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_HUTLCRLAIN" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Total Aktiva Lancar</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTAKTLCR" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Total Hutang Lancar</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTHUTLCR" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD><STRONG>Aktiva Tetap</STRONG></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD><STRONG>Hutang Jangka Panjang</STRONG></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Tanah dan Bangunan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TANAHB" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Hutang Jangka Panjang</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_HUTJP" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Mesin dan Peralatan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_MESINP" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Hutang Pemegang Saham</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_HUTSAHAM" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Inventaris dan Kendaraan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_INVENTK" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Hutang Jangka Panjang Lainnya</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_HUTJPLAIN" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Aktiva Tetap Lainnya</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_AKTTTPLAIN" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Total Hutang Jangka Panjang</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTHUTJP" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Akumulasi Penyusutan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_AKUMSUSUT" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Total Hutang</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTHUT" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Total Aktiva Tetap</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTAKTTTP" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><STRONG>Aktiva Lain</STRONG></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Beban yang ditangguhkan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_BEBAN" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Modal Disetor</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_MODALD" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Akumulasi Amortisasi</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_AKUMAMORT" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Laba (rugi) Ditahan</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_LR" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Aktiva Lainnya</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_AKTLAIN" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Total Equity/Modal</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_MODAL" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD>Total Aktiva Lain</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTAKTLAIN" runat="server"></asp:label></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD>Total Aktiva</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTAKT" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Total Pasiva</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_SMNE_TOTPAS" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="7"></TD>
							</TR>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_IR_SMALL_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<TR>
								<TD borderColor="black" align="center" width="50%" colSpan="3"><STRONG><FONT size="2">LABA 
											RUGI</FONT></STRONG><br>
									<asp:label id="lbl_SMLR_PERTGL" runat="server"></asp:label></TD>
								<TD borderColor="black" align="center" width="50%" colSpan="3"><STRONG><FONT size="2">RASIO</FONT></STRONG><br>
									<asp:label id="lbl_SMRA_PERTGL" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="TBL_IR_SMALL" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td width="29%">Penjualan Pertahun</td>
								<td width="1%">:</td>
								<td align="right" width="20%"><asp:label id="lbl_SMLR_JUALTHN" runat="server"></asp:label></td>
								<TD width="5">&nbsp;&nbsp;&nbsp;</TD>
								<td width="29%">Sales&nbsp;to Working Capital Ratio</td>
								<td width="1%">:</td>
								<td align="right" width="20%"><asp:label id="lbl_SMRA_SALESWC" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Harga Pokok Penjualan</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_HPP" runat="server"></asp:label></td>
								<TD></TD>
								<td>Debt to Net Worth Ratio</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_DEBTNW" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Biaya Umum &amp; Administrasi</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_BUADM" runat="server"></asp:label></td>
								<TD></TD>
								<td>Current Ratio</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_CURRATIO" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Laba Operasi</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_LABAOPR" runat="server"></asp:label></td>
								<TD></TD>
								<td>Business Debt Service Ratio</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_BUSDEBT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Biaya Bunga</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_BBUNGA" runat="server"></asp:label></td>
								<TD></TD>
								<td>Trade Cycle Days (day)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_TRADECYC" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Biaya Penyusutan</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_BSUSUT" runat="server"></asp:label></td>
								<TD></TD>
								<td>Average Net Profit</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_AVGNETPROF" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Biaya Lain-lain</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_BLAIN" runat="server"></asp:label></td>
								<TD></TD>
								<td>Cash Velocity</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_CASHV" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pendapatan Lain-lain</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_PDPTLAIN" runat="server"></asp:label></td>
								<TD></TD>
								<td>Days Receivable (day)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_DAYRECEIVE" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Laba Sebelum Pajak</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_LABABPAJAK" runat="server"></asp:label></td>
								<TD></TD>
								<td>Days Inventory (day)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_DAYINVENT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Pajak</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_PAJAK" runat="server"></asp:label></td>
								<TD></TD>
								<td>Days Account Payable (day)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_DAYAP" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Laba Bersih</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMLR_LABA" runat="server"></asp:label></td>
								<TD></TD>
								<td>Net Working Capital</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_NETWC" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td align="right"></td>
								<TD></TD>
								<td>Total Asset Turn Over
								</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_SMRA_TOTASSTO" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="7"></td>
							</tr>
							<!---##########################################################################################--></TABLE>
						<TABLE id="TBL_NE_MIDDLE_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<tr>
								<td borderColor="black" align="center"><STRONG><FONT size="2">NERACA</FONT></STRONG><br>
									<asp:label id="lbl_MINE_PERTGL" runat="server"></asp:label></td>
							</tr>
						</TABLE>
						<TABLE id="TBL_NE_MIDDLE" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD align="center" colSpan="3"><STRONG>ASSETS</STRONG></TD>
								<TD></TD>
								<TD align="center" colSpan="3"><STRONG>LIABILITIES + EQUITY</STRONG></TD>
							</TR>
							<tr>
								<td width="29%">Cash &amp; Bank</td>
								<td width="1%">:</td>
								<td align="right" width="20%"><asp:label id="lbl_MINE_CASHBANK" runat="server"></asp:label></td>
								<TD width="5">&nbsp;&nbsp;&nbsp;</TD>
								<td width="29%">Due Banks, Short Term</td>
								<td width="1%">:</td>
								<td align="right" width="20%"><asp:label id="lbl_MINE_DUEBANK" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Marketable Securities</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_MARKETSEC" runat="server"></asp:label></td>
								<TD></TD>
								<td>Accounts Payable</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_AP" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Accounts Receivable</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_AR" runat="server"></asp:label></td>
								<TD></TD>
								<td>Accounts Payable to Affiliated</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_APAFF" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Acc. Receivable fr Affiliated</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_ARAFF" runat="server"></asp:label></td>
								<TD></TD>
								<td>Accruals</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_ACCRUAL" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Inventory</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_INVENTORY" runat="server"></asp:label></td>
								<TD></TD>
								<td>Taxes Payable</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_TAXPAYABLE" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Other Current Assets</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_OTHERCASS" runat="server"></asp:label></td>
								<TD></TD>
								<td>Other Current Liabilities</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_OTHERCLIAB" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Prepaid Expenses</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_PREPAIDEX" runat="server"></asp:label></td>
								<TD></TD>
								<td>Current Portion L T Debt</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_CURRPORTION" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td><STRONG>Current Assets</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_CURRASSET" runat="server"></asp:label></td>
								<TD></TD>
								<td><STRONG>Current Liabilities</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_CURRLIAB" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Net Fixed Assets</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_NETFIXASS" runat="server"></asp:label></td>
								<TD></TD>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td>Investments</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_INVESTMENT" runat="server"></asp:label></td>
								<TD></TD>
								<td>Long Term Debt</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_LTDEBT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Net Other Non Current Assets</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_NETOTHER" runat="server"></asp:label></td>
								<TD></TD>
								<td>Other Liab, Long Term</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_OTHERLIAB" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Net Intangibles</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_NETINT" runat="server"></asp:label></td>
								<TD></TD>
								<td><STRONG>Long Term Liabilities</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_LTLIAB" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td><STRONG>Total Non Current Assets</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_TOTNON" runat="server"></asp:label></td>
								<TD></TD>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td><STRONG>TOTAL ASSETS</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_TOTASSET" runat="server"></asp:label></td>
								<TD></TD>
								<td><STRONG>TOTAL LIABILITIES</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_TOTLIAB" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<TD></TD>
								<td></td>
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<TD></TD>
								<td>Common Stock</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_COMSTOCK" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<TD></TD>
								<td>Surplus &amp; Reserves</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_SURPLUSR" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<TD></TD>
								<td>Retained Earnings</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_RETEARN" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<TD></TD>
								<td><STRONG>Total Net Worth</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_TOTNETW" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td></td>
								<td></td>
								<td></td>
								<TD></TD>
								<td><STRONG>LIABILITIES + NET WORTH</STRONG></td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MINE_LIABNETW" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD colSpan="7"></TD>
							</TR>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_IR_MIDDLE_H" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
							<TR>
								<TD style="WIDTH: 317px" borderColor="black" align="center" width="50%" colSpan="3"><STRONG><FONT size="2">INCOME 
											STATEMENT</FONT></STRONG><br>
									<asp:label id="lbl_MIIS_PERTGL" runat="server"></asp:label></TD>
								<TD borderColor="black" align="center" width="50%" colSpan="3"><STRONG><FONT size="2">RATIO</FONT></STRONG><br>
									<asp:label id="lbl_MIRA_PERTGL" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="TBL_IR_MIDDLE" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td width="29%">Sales On Credit %</td>
								<td width="1%">:</td>
								<td align="right" width="20%"><asp:label id="lbl_MIIS_SALECRE" runat="server"></asp:label></td>
								<TD width="5">&nbsp;&nbsp;&nbsp;</TD>
								<td width="29%">Sales Growth Rate %</td>
								<td width="1%">:</td>
								<td align="right" width="20%"><asp:label id="lbl_MIRA_SALEGROW" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Net Sales</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_NETSALE" runat="server"></asp:label></td>
								<TD></TD>
								<td>Net Income / Net Worth % (ROE)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_ROE" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Cost Of Goods Sales</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_COSTGOOD" runat="server"></asp:label></td>
								<TD></TD>
								<td>Net Income / Asset % (ROA)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_ROA" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Of Sales</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_PRCSALE_1" runat="server"></asp:label></td>
								<TD></TD>
								<td>Interest / Average Bank Debt %</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_INTEREST" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Gross Margin</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_GROSSM" runat="server"></asp:label></td>
								<TD></TD>
								<td>Sales / Average Assets</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_SALES" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Of Sales</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_PRCSALE_2" runat="server"></asp:label></td>
								<TD></TD>
								<td>Current Ratio</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_CURRATIO" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Selling, Gen, Admin Exp</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_SELLING" runat="server"></asp:label></td>
								<TD></TD>
								<td>Quick Asset Ratio</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_QUICKASS" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Of Sales</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_PRCSALE_3" runat="server"></asp:label></td>
								<TD></TD>
								<td>Days Receivable</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_DRECEIVE" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Operating Earnings</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_OPREARN" runat="server"></asp:label></td>
								<TD></TD>
								<td>Days Inventory</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_DINVENT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>% Of Sales</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_PRCSALE_4" runat="server"></asp:label></td>
								<TD></TD>
								<td>Days Payable</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_DAYPAY" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Depreciation (Fixed Assets)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_DEPRECIATE" runat="server"></asp:label></td>
								<TD></TD>
								<td>Days TC</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_DAYTC" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Amortization 1 (Other Non C Ass)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_AMORT_1" runat="server"></asp:label></td>
								<TD></TD>
								<td>Debt Equity Ratio</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_DEBTEQ" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Amortization 2 (Intangibles)</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_AMORT_2" runat="server"></asp:label></td>
								<TD></TD>
								<td>Long Term Leverage</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_LTLEVER" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Other Income (Charges) - Net</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_OTHERINC" runat="server"></asp:label></td>
								<TD></TD>
								<td>Time Interest Earned</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_TIMEINT" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Extraordinary Items</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_EXORDITEM" runat="server"></asp:label></td>
								<TD></TD>
								<td>Debt Service Coverage</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_DEBTSERV" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td>Earnings Before Interest &amp; Taxes</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIIS_EARNBTAX" runat="server"></asp:label></td>
								<TD></TD>
								<td>Net Worth</td>
								<td>:</td>
								<td align="right"><asp:label id="lbl_MIRA_NETWORTH" runat="server"></asp:label></td>
							</tr>
							<TR>
								<TD>Interest Expense</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_MIIS_INTEREST" runat="server"></asp:label></TD>
								<TD></TD>
								<TD>Sales To Working Capital</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_MIRA_SALESWC" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD align="right"></TD>
								<TD></TD>
								<TD>Debt To NetWorth</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_MIRA_DEBTNW" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD align="right"></TD>
								<TD></TD>
								<TD>Business Debt Service Ratio</TD>
								<TD>:</TD>
								<TD align="right"><asp:label id="lbl_MIRA_BUSDEBT" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="7"></TD>
							</TR>
						</TABLE>
						<!---##########################################################################################-->
						<TABLE id="TBL_HIDDEN_DLL" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD align="center" colSpan="3"><STRONG><FONT size="2"><asp:dropdownlist id="DDL_FACKREDIT" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_APP_BI_COLL_CURR" runat="server" Visible="False" Enabled="False" Height="24px"></asp:dropdownlist><asp:dropdownlist id="DDL_APP_BM_COLL_CURR" runat="server" Visible="False" Enabled="False" Height="24px"></asp:dropdownlist><asp:dropdownlist id="DDL_BUSINESS_BM_COLL_W12" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_KEY_BI_COLL_LVL" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_MGM_BM_COLL_CURR" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_MGM_BI_COLL_LVL" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_JNSPERMOHONAN" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_JNSKREDIT" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_PRODUCTEXIST" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_SKEMAKREDIT" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_PENDAKHIR" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_STATUSKAWIN" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_JNSPERUSH" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_EXISTING_FAC" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_KEY_BM_COLL" runat="server" Visible="False" Enabled="False"></asp:dropdownlist></FONT></STRONG></TD>
							</TR>
						</TABLE>
						<!--<TABLE id="TBL_RASIO" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="3"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><STRONG><FONT size="2">RASIO</FONT></STRONG></TD>
							</TR>
							<TR>
								<TD width="49%">Sales to Working Capital</TD>
								<TD width="2%"></TD>
								<TD width="49%"><asp:textbox id="TXT_SALESWCRATIO" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Debt / Net Ratio</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_DEBTNETRATIO" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Current Ratio</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_CURRRATIO" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="7" runat="server"
										Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Business Debt Service Ratio</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_BUSSINESSDEBTRATIO" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="20"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Persentage Sales Increase</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_INCPROSENTASEPENJUALAN" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="8"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Persentage Net Income Increase</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_INCPROSENNETINCOME" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="9"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Trade Cycle Days</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_TRADECYCLEDAYS" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="16"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Purchasing Plan</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_PURCHASINGPLANT" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="10"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>WC plafond limit in BM</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_LIMITWCBM" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="11" runat="server"
										Width="150px" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>Average Net Profit</TD>
								<TD></TD>
								<TD><asp:textbox id="TXT_NETPROFITAVG" style="PADDING-RIGHT: 5px; TEXT-ALIGN: right" tabIndex="12"
										runat="server" Width="150px" ReadOnly="True"></asp:textbox></TD>
								<TD></TD>
							</TR>
						</TABLE>--></td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
