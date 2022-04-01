<%@ Page language="c#" Codebehind="collateralnew.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.collateralnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>collateralnew</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_mandatory.html" -->
		<script language="javascript">
		function update(regno, curef) {
			parent.document.Form1.action = "../VerificationAssignment/AppraisalAssignment.aspx?regno=" + regno + "&curef=" + curef;
			parent.document.Form1.submit();
			return false;
		}
		</script>
</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR id="TR_COLL" runat="server">
						<TD class="td" colSpan="2">
							<P>
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD class="td" vAlign="top" align="center" colSpan="2">
											<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" width="129">Keterangan Agunan</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" Width="300px" MaxLength="150"
															CssClass="mandatory"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Core ID AGunan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_SIBS_COLID" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Bukti Kepemilikan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Bentuk Pengikatan</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 1px"><asp:dropdownlist id="DDL_BENTUK_PENGIKATAN" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 11px">Klasifikasi Jaminan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Valuta</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatory" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR runat="server" id="TR_NILAI_BANK">
													<TD class="TDBGColor1">Nilai Bank</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE" runat="server" Width="200px" CssClass="mandatory" onblur="FormatCurrency(this)"></asp:textbox></TD>
												</TR>
												<TR runat="server" id="TR_NILAI_PASAR">
													<TD class="TDBGColor1">Nilai Pasar</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE2" runat="server" Width="200px" onblur="FormatCurrency(this)" CssClass="mandatory"></asp:textbox></TD>
												</TR>
												<TR runat="server" id="TR_NILAI_ASURANSI">
													<TD class="TDBGColor1">Nilai Asuransi</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEINS" runat="server" Width="200px" onblur="FormatCurrency(this)"></asp:textbox></TD>
												</TR>
												<TR runat="server" id="TR_NILAI_PENGIKATAN">
													<TD class="TDBGColor1">Nilai Pengikatan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEIKAT" runat="server" Width="200px" onblur="FormatCurrency(this)"></asp:textbox></TD>
												</TR>
												<TR runat="server" id="TR_NILAI_PENGURANG_PPA">
													<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEPPA" runat="server" Width="200px" onblur="FormatCurrency(this)"></asp:textbox></TD>
												</TR>
												<TR runat="server" id="TR_NILAI_LIKUIDASI">
													<TD class="TDBGColor1">Nilai Likuidasi</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUELIQ" runat="server" Width="200px" onblur="FormatCurrency(this)"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tanggal Penilaian</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_TGLPENILAIAN_DAY" runat="server" MaxLength="2" Columns="4" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_TGLPENILAIAN_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_TGLPENILAIAN_YEAR" runat="server" MaxLength="4" Columns="4" CssClass="mandatory"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Penilaian Oleh</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PENILAI_OLEH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" width="50%" colSpan="2">
							<asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Perbaharui" 
                                Visible="False" onclick="BTN_UPDATE_Click"></asp:button>
							<asp:button id="BTN_SAVE" runat="server" CssClass="button1" Text="Simpan" 
                                Visible="False" onclick="BTN_SAVE_Click"></asp:button>
							<asp:label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label>
							<asp:Button id="UPDATETOAPPRISAL" runat="server" CssClass="button1" Text="Update To Appraisal" onclick="UPDATETOAPPRISAL_Click"></asp:Button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
