<%@ Page language="c#" Codebehind="Disbursement.aspx.cs" AutoEventWireup="True" Inherits="SourceSMEReport.Disbursement" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Disbursement</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function cetak()
		{
			ID_TOP.style.display	= "none";
			ID_BOTTOM.style.display	= "none";
			window.print();
			ID_TOP.style.display	= "";
			ID_BOTTOM.style.display	= "";
		}
		function keluar(tc, mc)
		{
			a = confirm("Are you sure want to finish ?")
			if (a)
				window.location = "DisbursementSheet.aspx?tc=" + tc + "&mc=" + mc;
		}
		function buka(str1,str2)
		{
			if ((str1=="01") && (str2=="0"))
			{
				ID011.style.display	= "none";
				ID012.style.display	= "none";
			}
		}
		</script>
		<!-- #include  file="../../include/cek_all.html" -->
	
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout"   onload="buka('<%=Request.QueryString["ket_code"]%>','<%=Request.QueryString["cash"]%>')">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR id="ID_TOP">
							<TD class="tdNoBorder" align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg" border="0"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg" border="0"></A></TD>
						</TR>
						<tr>
							<td vAlign="top" align="center">
								<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="670">
									<TBODY>
										<TR>
											<TD class="HeaderReport"><asp:label id="LBL_APREGNO" runat="server" Visible="False"></asp:label>
												<!-- <asp:label id="LBL_APPTYPE1" runat="server" Visible="False"></asp:label>WORKSHEET --><asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label>WORKSHEET
												<asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label><asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD>&nbsp;&nbsp;
												<asp:label id="Label1" runat="server">Print Date                  :</asp:label>&nbsp;
												<asp:label id="LBL_PRINT" runat="server"></asp:label><asp:label id="LBL_CASH" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
													<TBODY>
														<TR>
															<TD class="NoReport" width="30">&nbsp; 1</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue" colSpan="2"><strong>Customer Information</strong></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD width="15"></TD>
															<TD class="TDBGColorValue" width="280">Name</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_NAME" runat="server"></asp:label>&nbsp;</TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD>&nbsp;</TD>
															<TD class="TDBGColorValue"><asp:label id="LBL_ID" runat="server"></asp:label></TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_IDCARD" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:label id="LBL_DOBTEXT" runat="server"></asp:label></TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_DOB" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue">Contact Person</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_CPERSON" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue">Telephone</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_PHONE" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue">CIF #</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_CIF" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue">NPWP</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_NPWP" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue">BU Approved By and Date</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_BUAPPR" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue">CRM Approved By and Date</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_CRMAPPR" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp; 2</TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><b>Services Applied</b></TD>
														</TR>
														<asp:panel id="Panel04" runat="server" Visible="False">
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">Ketentuan Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_KET_DESC" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Pengajuan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_APPDESC" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_FACILITY" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Sifat Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_SIFATKREDIT" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tujuan Penggunaan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_TUJUANPENGGUNAAN" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Limit
																	<asp:label id="LBL_CURRENCY" runat="server"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_LIMIT" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tenor</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_TENORVALUE" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">No. Rekening</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_ACCOUNT" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Request Tenor</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_OLDTENOR" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel05" runat="server" Visible="False">
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">Ketentuan Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_KET_DESC05" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Pengajuan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_APPDESC05" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_FACILITY05" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Sifat Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_SIFATKREDIT05" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">No. Rekening</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_ACCOUNT05" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Limit
																	<asp:label id="LBL_CURRENCY05" runat="server"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_LIMIT05" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tenor</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_TENORVALUE05" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel01" runat="server" Visible="False">
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">Ketentuan Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_KET_DESC01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Pengajuan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_APPDESC01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_FACILITY01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Pembentukan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_SIFATKREDIT01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tujuan Penggunaan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_TUJUANPENGGUNAAN01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Limit dlm Currency&nbsp;yang diminta</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_EXLIMITVAL01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">
																	<P>Exchange Rate Rp. to 1 Unit<BR>
																		Foreign Currency (Limit)</P>
																</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_EXRPLIMIT01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Limit (Rp.)<SPAN id="Span1"> </SPAN>
																</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_LIMIT01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">
																	<asp:label id="LBL_INSTALLTEXT01" runat="server" Visible="False"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_INSTALLMENT01" runat="server" Visible="False"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Loan Term</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_LOANTERM01" runat="server"></asp:label></TD>
															</TR>
															<TR id="ID011">
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Grace Period</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_GRACE01" runat="server"></asp:label></TD>
															</TR>
															<TR id="ID012">
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Repayment Frequency</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_REPAYMENT01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">
																	<asp:label id="LBL_INTERESTTYPE01" runat="server"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_INTEREST01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Total Limit Exposure</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_TOTALEXPLOSURE01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Total Application Value</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_SUMLIMIT01" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel07" runat="server" Visible="False">
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tanggal Penerbitan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07TGLTERBIT" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tanggal Jatuh Tempo</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07TGLTEMPO" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Dasar Permohonan Penerbitan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07DASARMOHON" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Ditujukan Kepada</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07DITUJUKAN" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Alamat</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07ALAMATTUJU" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Nama Barang / Komoditi</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07NMBARANG" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jumlah</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07JML" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport" style="HEIGHT: 20px"></TD>
																<TD style="HEIGHT: 20px"></TD>
																<TD class="TDBGColorValue" style="HEIGHT: 20px">Nilai FOB/CIF/CNF</TD>
																<TD class="TDBGColorValue" style="HEIGHT: 20px">:
																	<asp:label id="LBL_07NILAIFOB" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Bank Koresponden</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07BANKKORES" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Alamat</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_07ALAMATBANK" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel03" runat="server" Visible="False">
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">Ketentuan Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_KET_DESC03" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Pengajuan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_APPDESC03" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_FACILITY03" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Limit Lama -
																	<asp:label id="LBL_CURROLD03" runat="server"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_OLDLIMIT03" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Perubahan Limit -
																	<asp:label id="LBL_CURRNEW03" runat="server"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_LIMIT03" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Exchange Rate Rp.</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_EXRPLIMIT03" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Perubahan&nbsp;Limit&nbsp;in Rp.</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_CPLIMIT03" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel06" runat="server" Visible="False">
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Ketentuan Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_KET_DESC06" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Pengajuan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_APPDESC06" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Withdrawl Type</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_WITHDRAWLID06" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_FACILITY06" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Limit -
																	<asp:label id="LBL_CURRENCY06" runat="server"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_CP_EXLIMITVAL06" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Exchange Rate Rp.</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_CP_EXRPLIMIT06" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Request Limit&nbsp;in Rp.
																</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBLCP_LIMIT06" runat="server" Visible="False"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tenor</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_TENOR06" runat="server" Visible="False"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">
																	<asp:label id="LBL_CURR06" runat="server" Visible="False"></asp:label>Installment</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_CPINSTALLMENT06" runat="server" Visible="False"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">
																	<asp:Label id="LBL_INTERESTTYPE06" runat="server"></asp:Label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_INTEREST06" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel02" runat="server" Visible="False">
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Ketentuan Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_KET_DESC02" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Pengajuan</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_APPDESC02" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Jenis Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_FACILITY02" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Sifat Kredit</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_SIFATKREDIT02" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Limit
																	<asp:label id="LBL_CURRENCY02" runat="server"></asp:label></TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_LIMIT02" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Tenor</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_TENOR02" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="PanelACC" Visible="False" Runat="server">
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">No. Fasilitas</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_ACCNOFASILITAS" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport" style="HEIGHT: 19px"></TD>
																<TD style="HEIGHT: 19px"></TD>
																<TD class="TDBGColorValue" style="HEIGHT: 19px">AA No.</TD>
																<TD class="TDBGColorValue" style="HEIGHT: 19px">:
																	<asp:label id="LBL_ACCAANO" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Sequence</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_ACCSEQ" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel041" runat="server" Visible="False">
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue"><B><I>IDC Information</I></B></TD>
																<TD class="TDBGColorValue">&nbsp;</TD>
															</TR>
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">Main a/c-IDC Ratio</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDCRATIO" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">IDC Loan Term</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDCJWAKTU" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport">&nbsp;
																</TD>
																<TD></TD>
																<TD class="TDBGColorValue">IDC a/c % Kapitalise</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDC_CAPRATIO" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">IDC variance code and percentage</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDC_PRIMEVARCODE" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport">&nbsp;</TD>
																<TD></TD>
																<TD class="TDBGColorValue">IDC a/c - Plafond</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDC_CAPAMNT" runat="server"></asp:label></TD>
															</TR>
														</asp:panel><asp:panel id="Panel011" runat="server" Visible="False">
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue" colSpan="2"><B><I>IDC Information</I></B></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">IDC a/c - Plafond</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDC_PLAFOND01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">IDC Loan Term</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDC_LOANTERM01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">Main a/c&nbsp;- IDC Ratio</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDC_RATIO01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue">IDC a/c - % Kapitalis</TD>
																<TD class="TDBGColorValue">:
																	<asp:label id="LBL_IDC_KAPITALIS01" runat="server"></asp:label></TD>
															</TR>
															<TR>
																<TD class="NoReport" style="HEIGHT: 20px"></TD>
																<TD style="HEIGHT: 20px"></TD>
																<TD class="TDBGColorValue" style="HEIGHT: 20px">IDC Interest</TD>
																<TD class="TDBGColorValue" style="HEIGHT: 20px">:
																	<asp:label id="LBL_IDC_INTEREST01" runat="server"></asp:label></TD>
															</TR>
														</asp:panel>
														<tr>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><b><i>Biaya - biaya</i></b></TD>
															<TD class="TDBGColorValue">&nbsp;</TD>
														</tr>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue">Biaya Administrasi</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_BIAYA_ADM" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue">Biaya Provisi</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_BIAYA_PROVISI" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue">Biaya Notaris</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_BIAYA_NOTARIS" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue">Biaya Pengikatan</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_BIAYA_IKAT" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue">Biaya Materai</TD>
															<TD class="TDBGColorValue">:
																<asp:label id="LBL_BIAYA_MATERAI" runat="server"></asp:label></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><asp:table id="oTable" runat="server" Width="100%" CellPadding="0" CellSpacing="0">
																	<asp:TableRow>
																		<asp:TableCell Text="Collateral ID" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Text="Collateral Name" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Text="Amount" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Text="Klasifikasi Jaminan" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Text="Currency" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Text="Percentage" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Visible="False" ForeColor="Red" Text="Action" CssClass="HeaderReportList"></asp:TableCell>
																	</asp:TableRow>
																</asp:table></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp; 3</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><b>Documents Collected</b></TD>
															<TD class="TDBGColorValue">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><asp:table id="oTable1" runat="server" Width="100%" CellPadding="0" CellSpacing="0">
																	<asp:TableRow>
																		<asp:TableCell Text="Documents ID" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Text="Name" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Width="110px" Text="Received Date" CssClass="HeaderReportList"></asp:TableCell>
																		<asp:TableCell Width="110px" Text="Expiry Date" CssClass="HeaderReportList"></asp:TableCell>
																	</asp:TableRow>
																</asp:table></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp; 4</TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><b>Remarks / Special Instructions</b></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_CPKET" runat="server" Width="500px" TextMode="MultiLine" Wrap="True" BorderStyle="None"
																	Rows="5"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="NoReport">&nbsp; 5</TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><b>Collateral Detail</b></TD>
														</TR>
														<TR>
															<TD class="NoReport"></TD>
															<TD></TD>
															<TD class="TDBGColorValue" colSpan="2"><asp:table id="oTableAR" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table>&nbsp;
																<asp:table id="oTableBOND" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableDEP" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableINV" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableLC" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableLSAGR" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableMISC" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTablePG" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTablePNCHQ" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableRE" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableSPK" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableSTOCK" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableTRCON" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table><asp:table id="oTableVEH" runat="server" Visible="False" Width="100%" CellPadding="0" CellSpacing="0"></asp:table>&nbsp;
															</TD>
														</TR>
														<asp:panel id="PanelAltenateRate" runat="server" Visible="False">
															<TR>
																<TD class="NoReport" vAlign="top">&nbsp;
																	<asp:Label id="LBL_NO_ALTERNATERATE" runat="server" Visible=False></asp:Label></TD>
																<TD></TD>
																<TD class="TDBGColorValue" colSpan="2"><B>Alternate Rate</B></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue" colSpan="2">
																	<asp:table id="TblAltenateRate" runat="server" CellSpacing="0" CellPadding="0" Width="100%">
																		<asp:TableRow>
																			<asp:TableCell Text="Sequence" width="10%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Tenor" width="15%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Fixed Rate" width="15%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Floating Rate" width="15%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Varcode" width="15%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Variance" width="15%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Installment" width="15%" CssClass="HeaderReportList"></asp:TableCell>
																		</asp:TableRow>
																	</asp:table></TD>
															</TR>
														</asp:panel><asp:panel id="PanelPaymentSchedule" runat="server" Visible="False">
															<TR>
																<TD class="NoReport" vAlign="top">&nbsp;
																	<asp:Label id="LBL_NO_PAYMENTSCHEDULE" runat="server" Visible=False></asp:Label></TD>
																<TD></TD>
																<TD class="TDBGColorValue" colSpan="2"><B>Payment Schedule</B></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue" colSpan="2">
																	<asp:table id="TblPaymentSchedule" runat="server" CellSpacing="0" CellPadding="0" Width="100%">
																		<asp:TableRow>
																			<asp:TableCell Text="Seq Month" width="20%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Percentage" width="35%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="AltenateRate Amount" width="45%" CssClass="HeaderReportList"></asp:TableCell>
																		</asp:TableRow>
																	</asp:table></TD>
															</TR>
														</asp:panel><asp:panel id="PanelDrawdownSchedule" runat="server" Visible="False">
															<TR>
																<TD class="NoReport" vAlign="top">&nbsp;
																	<asp:Label id="LBL_NO_DRAWDOWNSCHEDULE" runat="server" Visible=False></asp:Label></TD>
																<TD></TD>
																<TD class="TDBGColorValue" colSpan="2"><B>Drawdown Schedule</B></TD>
															</TR>
															<TR>
																<TD class="NoReport"></TD>
																<TD></TD>
																<TD class="TDBGColorValue" colSpan="2">
																	<asp:table id="TblDrawdownSchedule" runat="server" CellSpacing="0" CellPadding="0" Width="100%">
																		<asp:TableRow>
																			<asp:TableCell Text="Seq Month" width="20%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Percentage" width="35%" CssClass="HeaderReportList"></asp:TableCell>
																			<asp:TableCell Text="Drawdown Amount" width="45%" CssClass="HeaderReportList"></asp:TableCell>
																		</asp:TableRow>
																	</asp:table></TD>
															</TR>
														</asp:panel>
													</TBODY>
												</TABLE>
											</TD>
										</TR>
										<TR id="ID_BOTTOM">
											<!--
											<TD class="TDBGColor2" vAlign="top">&nbsp;</TD>
											-->
											<TD class="TDBGColor2" vAlign="top"><INPUT class="button1" onclick="cetak()" type="button" value="PRINT">&nbsp;<INPUT class="button1" onclick="keluar('<%=Request.QueryString["tc"]%>','<%=Request.QueryString["mc"]%>')" type="button" value="FINISH"></TD>
										</TR>
									</TBODY>
								</TABLE>
								&nbsp;</td>
						</tr>
					</TBODY>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
