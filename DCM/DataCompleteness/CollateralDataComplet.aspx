<%@ Page language="c#" Codebehind="CollateralDataComplet.aspx.cs" AutoEventWireup="false" Inherits="SME.DCM.CollateralDataCompleteness.CollateralDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralDataComplet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<style type="text/css">.pl { MARGIN-RIGHT: 3px }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<asp:Label id="Label2" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server">Label</asp:Label>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<%if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) {%>
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" align="center" width="20%"><B>COLLATERAL DATA COMPLETENEWW</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<%}%>
					<tr>
						<td class="tdHeader1" align="center" width="100%" colSpan="2"><B>AGUNAN</B></td>
					</tr>
					<tr>
						<td colSpan="2">
							<table>
								<tr>
									<TD style="WIDTH: 145px" vAlign="top" width="145"><asp:table id="TBL_FASILITAS" Runat="server" Width="100%" CssClass="BackGroundList"></asp:table><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></TD>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_DDL_TYPE_AGUNAN" runat="server">Type Agunan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TYPE_AGUNAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_KET_AGUNAN" runat="server">Keterangan Agunan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 232px"><asp:textbox id="TXT_KET_AGUNAN" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_DDL_SIFAT_AGUNAN" runat="server">Sifat Agunan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SIFAT_AGUNAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_NMPEMILIK_COLL" runat="server">Nama Pemilik Agunan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NMPEMILIK_COLL" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_DDL_BUKTI_KEPEMILIKAN" runat="server">Bukti Kepemilikan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_DDL_STATUS_KEPEMILIKAN" runat="server">Status Kepemilikan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STATUS_KEPEMILIKAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">&nbsp;
													<asp:Label id="LBL_DDL_MM_TGLTERBITSERTF" runat="server">Tgl. Terbit Sertifikat</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLTERBITSERT" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLTERBITSERTF" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLTERBITSERTF" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">&nbsp;
													<asp:Label id="LBL_DDL_MM_EXPSERTF" runat="server">Tgl. Expired Sertifikat</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_EXPSERTF" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_EXPSERTF" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_EXPSERTF" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_ALAMAT_AGUNAN" runat="server">Alamat Agunan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_AGUNAN" runat="server" Width="100%" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px; HEIGHT: 27px">
													<asp:Label id="LBL_DDL_LKS_DATI2" runat="server">Lokasi Dati II</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 27px"><asp:dropdownlist id="DDL_LKS_DATI2" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_DDL_KODE_MATAUANG" runat="server">Kode Mata Uang</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KODE_MATAUANG" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_NILAIPASAR" runat="server">Nilai Pasar</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAIPASAR" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_NILAIAPPRAISAL" runat="server">Nilai Appraisal</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAIAPPRAISAL" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_NILAILIKUIDASI" runat="server">Nilai Likuidasi</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAILIKUIDASI" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_NILAINJOP" runat="server">Nilai NJOP</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAINJOP" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_PENERBITAGUNAN" runat="server">Penerbit Agunan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PENERBITAGUNAN" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_LEMBAGA_PRKT" runat="server">Lembaga Pemeringkat</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_LEMBAGA_PRKT" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_TXT_PRKT_PNRBT_COLL" runat="server">Peringkat Penerbit Agunan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PRKT_PNRBT_COLL" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 116px">
													<asp:Label id="LBL_DDL_TGL_PEMERINGKATAN" runat="server">Tgl. Pemeringkatan</asp:Label></TD>
												<TD style="WIDTH: 7px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TGL_PEMERINGKATAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_NILAI_IKAT" runat="server">Nilai Pengikatan</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" style="WIDTH: 299px"><asp:textbox id="TXT_NILAI_IKAT" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_NO_IKAT" runat="server">No. Pengikatan</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_IKAT" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;
													<asp:Label id="LBL_DDL_MM_PNLN_KE1" runat="server">Tanggal Penilaian ke-1</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_PNLN_KE1" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_PNLN_KE1" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_PNLN_KE1" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 38px">
													<asp:Label id="LBL_DDL_MM_PNLN_KE2" runat="server">Tanggal Penilaian Terakhir</asp:Label>&nbsp;</TD>
												<TD style="WIDTH: 1px; HEIGHT: 38px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 38px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_PNLN_KE2" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_PNLN_KE2" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_PNLN_KE2" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 17px">
													<asp:Label id="LBL_DDL_PENILAIANOLEH" runat="server">Penilaian Oleh</asp:Label></TD>
												<TD style="WIDTH: 1px; HEIGHT: 17px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 17px"><asp:dropdownlist id="DDL_PENILAIANOLEH" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_JENISIKAT" runat="server">Jenis Pengikatan</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISIKAT" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_MM_TGLIKAT" runat="server">Tanggal Pengikatan</asp:Label>&nbsp;</TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLIKAT" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLIKAT" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLIKAT" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 19px">
													<asp:Label id="LBL_DDL_JENISAGUNAN" runat="server">Jenis Agunan</asp:Label></TD>
												<TD style="WIDTH: 1px; HEIGHT: 19px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 19px"><asp:dropdownlist id="DDL_JENISAGUNAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_RDO_ASURANSI" runat="server">Asuransi</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_ASURANSI" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_PRKT_SRT_BERHARGA" runat="server">Peringkat Surat Berharga</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PRKT_SRT_BERHARGA" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_MM_TGLPRKT" runat="server">Tanggal Peringkat</asp:Label>&nbsp;</TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPRKT" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLPRKT" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPRKT" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_PNRBTN_SRT_BRHRG" runat="server">Penerbit Surat Berharga</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 299px; HEIGHT: 10px"><asp:dropdownlist id="DDL_PNRBTN_SRT_BRHRG" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_MM_TGLTERBIT" runat="server"> Tanggl Penerbitan</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLTERBIT" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLTERBIT" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_MM_TGLTERBIT" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_DDL_MM_JTHTEMPO" runat="server">Tanggal Jatuh Tempo</asp:Label>
													&nbsp;</TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_JTHTEMPO" runat="server" Width="18%"
														CssClass="pl" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MM_JTHTEMPO" runat="server" Width="48%" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_JTHTEMPO" runat="server" Width="30%"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;
													<asp:Label id="LBL_TXT_PLDAMTTOLIMIT" runat="server">Pledging Amt. To Limit</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox id="TXT_PLDAMTTOLIMIT" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_PLDAMTTOAVALIMIT" runat="server">Pledging Amt. To Available Limit</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class='A"TDBGColorValue"' style="WIDTH: 299px; HEIGHT: 10px">
													<asp:textbox id="TXT_PLDAMTTOAVALIMIT" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													<asp:Label id="LBL_TXT_PPA_CADUM" runat="server"> PPA Cadangan Umum</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox id="TXT_PPA_CADUM" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;
													<asp:Label id="LBL_TXT_PPA_CADKUS" runat="server">PPA Cadangan Khusus</asp:Label></TD>
												<TD style="WIDTH: 1px">:</TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox id="TXT_PPA_CADKUS" runat="server" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" Runat="server" CssClass="button1" Text="SAVE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_UPDATE" Runat="server" Width="132px" CssClass="button1" Text="UPDATE STATUS"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
