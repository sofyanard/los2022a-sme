<%@ Page language="c#" Codebehind="NotaPRRK.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.NotaPRRK" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Nota Analisa</title>
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
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" borderColor="white" border="0">
					<TR id="TRPRINT">
						<TD class="tdHeader1" align="center">
							<asp:Label id="LBL_REGNO" runat="server" Visible="False"></asp:Label>
							<INPUT type="button" name="TRPRINT" onclick="cetak()" Width="125px" Value="Print" CssClass="Button1">
							<asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label></TD>
					</TR>
					<TR>
						<TD align="center"><STRONG>NOTA PENILAIAN RESIKO DAN REKOMENDASI KEPUTUSAN</STRONG></TD>
					</TR>
					<TR>
						<TD align="center">No.&nbsp;
							<asp:label id="LBL_NO_NOTA" runat="server" Width="152px"></asp:label>&nbsp;&nbsp; 
							Tanggal.
							<asp:label id="LBL_TG_NOTA" runat="server" Width="120px"></asp:label></TD>
					</TR>
					<TR>
						<TD align="center"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" align="center">Informasi Permohonan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="1" borderColor="black">
								<TR>
									<TD rowSpan="3" vAlign="top">
										Informasi Dokumen
									</TD>
									<TD align="center">Nomor</TD>
									<TD align="center">Tanggal Surat</TD>
									<TD align="center">Tanggal Terima</TD>
								</TR>
								<TR>
									<TD>
										<asp:label id="LBL_NO_SURAT_NASABAH" runat="server" Width="194px"></asp:label></TD>
									<TD>
										<asp:label id="LBL_TGL_SURAT_NASABAH" runat="server" Width="143px"></asp:label></TD>
									<TD rowSpan="1">
										<asp:label id="LBL_TGL_SURAT_TERIMA" runat="server" Width="144px"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 19px" noWrap colSpan="3">
										Kelengakapan data&nbsp;&nbsp;terakhir berupa
										<asp:Label id="LBL_LENGKAP_" runat="server" Width="80px"></asp:Label>&nbsp;diterima 
										dari Nasabah&nbsp;&nbsp;pada tanggal
										<asp:Label id="LBL_TANGGAL_LENGKAP" runat="server" Width="80px"></asp:Label>.
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 264px; HEIGHT: 22px">
										Permohonan Nasabah
									</TD>
									<TD colSpan="3">
										<asp:label id="LBL_MOHON" runat="server" Width="80px"></asp:label>a.n.
										<asp:label id="LBL_AN_MOHON" runat="server" Width="80px"></asp:label>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 264px; HEIGHT: 22px" rowspan="4" vAlign="top">
										<P>Rekomendasi/Keputusan Bussiness Unit</P>
									</TD>
									<TD style="WIDTH: 374px; HEIGHT: 22px" align="center" colSpan="2">Nama</TD>
									<TD style="HEIGHT: 22px" align="center">Jabatan</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 374px; HEIGHT: 22px" colSpan="2">1.
										<asp:label id="LBL_BU_TL" runat="server" Width="345"></asp:label></TD>
									<TD style="HEIGHT: 22px">
										<asp:label id="LBL_JB_TL" runat="server" Width="200px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 374px; HEIGHT: 22px" colSpan="2">2.
										<asp:label id="LBL_BU_RM" runat="server" Width="345px"></asp:label></TD>
									<TD style="HEIGHT: 22px">
										<asp:label id="LBL_JB_RM" runat="server" Width="200px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 374px; HEIGHT: 22px" colSpan="2">3.
										<asp:label id="LBL_BU_CA" runat="server" Width="345px"></asp:label></TD>
									<TD style="HEIGHT: 22px">
										<asp:label id="LBL_JB_CA" runat="server" Width="200px"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" align="center">Informasi Umum</TD>
					</TR>
					<TR>
						<TD class="td">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							</TABLE>
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="1" borderColor="black">
								<TR>
									<TD style="WIDTH: 235px" colSpan="2">&nbsp;<STRONG>A. Debitur</STRONG></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Nama Debitur</TD>
									<TD>
										<asp:label id="Label8" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Alamat Kantor</TD>
									<TD>
										<asp:label id="Label9" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Alamat Proyek</TD>
									<TD>
										<asp:label id="Label10" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Bidang Usaha</TD>
									<TD>
										<asp:label id="Label11" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Bidang Usaha</TD>
									<TD>
										<asp:label id="Label12" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Kode Sektor Ekonomi BI</TD>
									<TD>
										<asp:label id="Label13" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Key Person</TD>
									<TD>
										<asp:label id="Label14" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Berusaha/beroperasi sejak</TD>
									<TD>
										<asp:label id="Label15" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Hubungan dengan Bank Mandiri</TD>
									<TD>
										<asp:label id="Label87" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Status Calon Debitur</TD>
									<TD>
										<asp:label id="Label88" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px" colSpan="2"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px; HEIGHT: 20px" colSpan="2"><STRONG>B. Group</STRONG></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Nama Group Usaha</TD>
									<TD>
										<asp:label id="Label89" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">
										<P>&nbsp; * Alamat Kantor</P>
									</TD>
									<TD>
										<asp:label id="Label90" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px; HEIGHT: 21px">&nbsp; * Alamat Proyek</TD>
									<TD style="HEIGHT: 21px">
										<asp:label id="Label91" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Bidang Usaha</TD>
									<TD>
										<asp:label id="Label92" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; *&nbsp;Kode Sektor Ekonomi BI</TD>
									<TD>
										<asp:label id="Label93" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Key Person</TD>
									<TD>
										<asp:label id="Label94" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Hubungan dengan Bank Mandiri</TD>
									<TD>
										<asp:label id="Label95" runat="server" Width="80px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 235px">&nbsp; * Tanggal Checking Internal</TD>
									<TD>
										<asp:label id="Label96" runat="server" Width="80px"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" align="center">Informasi Fasilitas</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 296px">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1" borderColor="black">
								<TR>
									<TD style="WIDTH: 174px; HEIGHT: 22px">a. Fasilitas Bank&nbsp;Mandiri</TD>
									<TD style="WIDTH: 197px" colSpan="2">Posisi Kredit Tanggal
										<asp:label id="Label97" runat="server" Width="160px"></asp:label></TD>
									<TD colSpan="6" align="right">
										Rp Juta</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px; HEIGHT: 20px" colSpan="9"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px" align="center" colSpan="1" rowSpan="1">Jenis Fasilitas</TD>
									<TD style="WIDTH: 102px" align="center">Limit</TD>
									<TD style="WIDTH: 91px" align="center">Baki Debet</TD>
									<TD style="WIDTH: 88px" align="center">Tgk. Pokok (Rp)</TD>
									<TD style="WIDTH: 82px" align="center">
										Lama Tgk (Bln)
									</TD>
									<TD style="WIDTH: 91px" align="center">Tgk. Bunga (Rp)</TD>
									<TD style="WIDTH: 85px" align="center">Lama Tgk (Bln)</TD>
									<TD style="WIDTH: 87px" align="center">Jatuh Tempo</TD>
									<TD align="center">Kol</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px" colSpan="9">Bank Mandiri</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="9">Nasabah</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px">&nbsp; * Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label98" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label107" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label116" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label125" runat="server" Width="81"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label134" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label143" runat="server" Width="82"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label152" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label161" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px">&nbsp; * Non Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label99" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label108" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label117" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label126" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label135" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label144" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label153" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label162" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px; HEIGHT: 15px">&nbsp; * Fasilitas Lain</TD>
									<TD style="WIDTH: 102px; HEIGHT: 15px">
										<asp:label id="Label100" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px; HEIGHT: 15px">
										<asp:label id="Label109" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px; HEIGHT: 15px">
										<asp:label id="Label118" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px; HEIGHT: 15px">
										<asp:label id="Label127" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px; HEIGHT: 15px">
										<asp:label id="Label136" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px; HEIGHT: 15px">
										<asp:label id="Label145" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px; HEIGHT: 15px">
										<asp:label id="Label154" runat="server" Width="96px"></asp:label></TD>
									<TD style="HEIGHT: 15px">
										<asp:label id="Label163" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px" align="center">Total</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label101" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label110" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label119" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label128" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label137" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label146" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label155" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label164" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="9">Group</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px">&nbsp; * Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label102" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label111" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label120" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label129" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label138" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label147" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label156" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label165" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px">&nbsp; * Non Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label103" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label112" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label121" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label130" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label139" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label148" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label157" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label166" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px">&nbsp; * Fasilitas Lain</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label104" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label113" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label122" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label131" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label140" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label149" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label158" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label167" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px" align="center">Total</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label105" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label114" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label123" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label132" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label141" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label150" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label159" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label168" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 174px" align="center">Total Nasabah + Group</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label106" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label115" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label124" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label133" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label142" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label151" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label160" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label169" runat="server" Width="82"></asp:label></TD>
								</TR>
							</TABLE>
							<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="1" borderColor="black">
								<TR>
									<TD colSpan="10"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px; HEIGHT: 22px">&nbsp; b. Fasilitas Bank Lain</TD>
									<TD style="WIDTH: 192px" colSpan="2">Posisi Kredit Tanggal
										<asp:label id="Label242" runat="server" Width="160px"></asp:label></TD>
									<TD colSpan="6" align="right">
										Rp Juta</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px; HEIGHT: 20px" colSpan="9"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px" align="center" colSpan="1" rowSpan="1">Jenis Fasilitas</TD>
									<TD style="WIDTH: 102px" align="center">Limit</TD>
									<TD style="WIDTH: 87px" align="center">Baki Debet</TD>
									<TD style="WIDTH: 88px" align="center">Tgk. Pokok (Rp)</TD>
									<TD style="WIDTH: 82px" align="center">Lama Tgk (Bln)</TD>
									<TD style="WIDTH: 91px" align="center">Tgk. Bunga (Rp)</TD>
									<TD style="WIDTH: 85px" align="center">Lama Tgk (Bln)</TD>
									<TD style="WIDTH: 87px" align="center">&nbsp;&nbsp;Jatuh Tempo</TD>
									<TD align="center">Kol
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px" colSpan="9">Bank Lain</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="9">Nasabah</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px">&nbsp; * Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label241" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label240" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label239" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label238" runat="server" Width="81"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label237" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label236" runat="server" Width="82"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label235" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label234" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px">&nbsp; * Non Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label233" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label232" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label231" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label230" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label229" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label228" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label227" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label226" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px; HEIGHT: 15px">&nbsp; * Fasilitas Lain</TD>
									<TD style="WIDTH: 102px; HEIGHT: 15px">
										<asp:label id="Label225" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px; HEIGHT: 15px">
										<asp:label id="Label224" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px; HEIGHT: 15px">
										<asp:label id="Label223" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px; HEIGHT: 15px">
										<asp:label id="Label222" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px; HEIGHT: 15px">
										<asp:label id="Label221" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px; HEIGHT: 15px">
										<asp:label id="Label220" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px; HEIGHT: 15px">
										<asp:label id="Label219" runat="server" Width="96px"></asp:label></TD>
									<TD style="HEIGHT: 15px">
										<asp:label id="Label218" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px" align="center">Total</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label217" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label216" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label215" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label214" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label213" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label212" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label211" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label210" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="9">Group</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px">&nbsp; * Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label209" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label208" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label207" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label206" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label205" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label204" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label203" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label202" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px">&nbsp; * Non Cash Loan</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label201" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label200" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label199" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label198" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label197" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label196" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label195" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label194" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px">&nbsp; * Fasilitas Lain</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label193" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label192" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label191" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label190" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label189" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label188" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label187" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label186" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px" align="center">Total</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label185" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label184" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label183" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label182" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label181" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label180" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label179" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label178" runat="server" Width="82"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 181px" align="center">Total Nasabah + Group</TD>
									<TD style="WIDTH: 102px">
										<asp:label id="Label177" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label176" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 88px">
										<asp:label id="Label175" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 82px">
										<asp:label id="Label174" runat="server" Width="80px"></asp:label></TD>
									<TD style="WIDTH: 91px">
										<asp:label id="Label173" runat="server" Width="96px"></asp:label></TD>
									<TD style="WIDTH: 85px">
										<asp:label id="Label172" runat="server" Width="82px"></asp:label></TD>
									<TD style="WIDTH: 87px">
										<asp:label id="Label171" runat="server" Width="96px"></asp:label></TD>
									<TD>
										<asp:label id="Label170" runat="server" Width="82"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" align="center">Evaluasi Resiko
						</TD>
					</TR>
					<TR>
						<TD class="td">
							<TABLE id="Table11" borderColor="black" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD style="WIDTH: 179px">Internal Risk Rating</TD>
									<TD>
										<asp:TextBox id="TextBox2" runat="server" Width="752px" Height="20px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 179px">Hasil Evaluasi</TD>
									<TD>
										<asp:TextBox id="TextBox4" runat="server" Width="752px" Height="20px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 179px" vAlign="top">Pembahasan</TD>
									<TD>
										<asp:TextBox id="TextBox1" runat="server" Width="752px" Height="76px"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" align="center"><b>Rekomendasi Pengusul</b></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 135px">
							<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="1" borderColor="black">
								<TR>
									<TD style="WIDTH: 179px">Nama, NIP, dan Jabatan</TD>
									<TD>
										<asp:label id="Label23" runat="server" Width="272px"></asp:label>,
										<asp:label id="Label24" runat="server" Width="134px"></asp:label>, dan
										<asp:label id="Label69" runat="server" Width="240px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 179px">Tanggal dan Paraf</TD>
									<TD>
										<asp:label id="Label70" runat="server" Width="134px"></asp:label></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 179px" vAlign="top">Pendapat</TD>
									<TD>
										<asp:TextBox id="TextBox3" runat="server" Width="752px" Height="76px"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1">
							<P align="center"><STRONG>Keputusan Pemegang Kewenangan</STRONG></P>
						</TD>
					</TR>
					<TR>
						<TD class="td">
							<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="1" borderColor="black">
								<TR>
									<TD style="WIDTH: 505px">Nama, NIP, dan Jabatan&nbsp;
										<asp:label id="Label268" runat="server" Width="352px"></asp:label></TD>
									<TD colSpan="2" align="center">
										Keputusan</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 505px">Tanggal&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:TextBox id="TextBox8" runat="server"></asp:TextBox></TD>
									<TD style="WIDTH: 248px" align="center">
										Disetujui</TD>
									<TD align="center">Ditolak</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 505px">
										<P>Catatan</P>
										<P>
											<asp:TextBox id="TextBox7" runat="server" Width="505" Height="76px"></asp:TextBox></P>
									</TD>
									<TD style="WIDTH: 248px">&nbsp;</TD>
									<TD>&nbsp;</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
