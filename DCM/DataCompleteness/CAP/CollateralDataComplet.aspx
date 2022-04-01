<%@ Page language="c#" Codebehind="CollateralDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.CAP.CollateralDataCompleteness.CollateralDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CollateralDataComplet</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<STYLE type="text/css">.pl { MARGIN-RIGHT: 3px }
		</STYLE>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER><asp:label id="Label2" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
					Visible="False">Label</asp:label>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<%if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) {%>
					<TR>
						<TD align="left" colSpan="2"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>COLLATERAL DATA 
											COMPLETENESS</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="3"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<%}%>
					<TR>
						<TD class="tdHeader1" colSpan="3"><B>AGUNAN</B></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="20%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="tdHeader1">Data Agunan</TD>
								</TR>
								<TR>
									<TD vAlign="top" width="100%"><asp:label id="Label1" Runat="server" Visible="False"></asp:label><asp:label id="Label3" Runat="server" Visible="False"></asp:label><asp:label id="Label4" Runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="40%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_TYPE_AGUNAN" runat="server">Type Agunan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_TYPE_AGUNAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KET_AGUNAN" runat="server">Keterangan Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KET_AGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_SIFAT_AGUNAN" runat="server">Sifat Agunan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_SIFAT_AGUNAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NMPEMILIK_COLL" runat="server">Nama Pemilik Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NMPEMILIK_COLL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_BUKTI_KEPEMILIKAN" runat="server">Bukti Kepemilikan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_STATUS_KEPEMILIKAN" runat="server">Status Kepemilikan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_STATUS_KEPEMILIKAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLTERBITSERTF" runat="server">Tgl. Terbit Sertifikat :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLTERBITSERT" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLTERBITSERTF" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLTERBITSERTF" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_EXPSERTF" runat="server">Tgl. Expired Sertifikat :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_EXPSERTF" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_EXPSERTF" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_EXPSERTF" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_AGUNAN" runat="server">Alamat Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_AGUNAN" runat="server" Width="100%" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_LKS_DATI2" runat="server">Lokasi Dati II :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_LKS_DATI2" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_KODE_MATAUANG" runat="server">Kode Mata Uang :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_KODE_MATAUANG" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAIPASAR" runat="server">Nilai Pasar :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAIPASAR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAIAPPRAISAL" runat="server">Nilai Appraisal :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAIAPPRAISAL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAILIKUIDASI" runat="server">Nilai Likuidasi :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAILIKUIDASI" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAINJOP" runat="server">Nilai NJOP :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAINJOP" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENERBITAGUNAN" runat="server">Penerbit Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENERBITAGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LEMBAGA_PRKT" runat="server">Lembaga Pemeringkat :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_LEMBAGA_PRKT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PRKT_PNRBT_COLL" runat="server">Peringkat Penerbit Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRKT_PNRBT_COLL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLPEMERINGKATAN" runat="server">Tgl. Pemeringkatan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPEMERINGKATAN" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLPEMERINGKATAN" runat="server" CssClass="pl" AutoPostBack="True"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPEMERINGKATAN" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="40%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_IKAT" runat="server">Nilai Pengikatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NILAI_IKAT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_IKAT" runat="server">No. Pengikatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_IKAT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_PNLN_KE1" runat="server">Tanggal Penilaian ke-1 :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_PNLN_KE1" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_PNLN_KE1" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_PNLN_KE1" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_PNLN_KE2" runat="server">Tanggal Penilaian Terakhir :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_PNLN_KE2" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_PNLN_KE2" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_PNLN_KE2" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_PENILAIANOLEH" runat="server">Penilaian Oleh :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PENILAIANOLEH" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENISIKAT" runat="server">Jenis Pengikatan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISIKAT" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLIKAT" runat="server">Tanggal Pengikatan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLIKAT" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLIKAT" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLIKAT" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_JENISAGUNAN" runat="server">Jenis Agunan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_JENISAGUNAN" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_RDO_ASURANSI" runat="server">Asuransi :</asp:label></TD>
									<TD class="TDBGColorValue" vAlign="middle" align="left"><asp:radiobuttonlist id="RDO_ASURANSI" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
											<asp:ListItem Value="N">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_PRKT_SRT_BERHARGA" runat="server">Peringkat Surat Berharga :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PRKT_SRT_BERHARGA" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLPRKT" runat="server">Tanggal Peringkat :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLPRKT" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLPRKT" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLPRKT" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_PNRBTN_SRT_BRHRG" runat="server">Penerbit Surat Berharga :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:dropdownlist id="DDL_PNRBTN_SRT_BRHRG" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_TGLTERBIT" runat="server"> Tanggal Penerbitan :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_TGLTERBIT" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_TGLTERBIT" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_TGLTERBIT" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_DDL_MM_JTHTEMPO" runat="server">Tanggal Jatuh Tempo :</asp:label></TD>
									<TD class='A"TDBGColorValue"'><asp:textbox onkeypress="return numbersonly()" id="TXT_DD_JTHTEMPO" runat="server" CssClass="pl"
											MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_MM_JTHTEMPO" runat="server" CssClass="pl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YY_JTHTEMPO" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PLDAMTTOLIMIT" runat="server">Pledging Amt. To Limit :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLDAMTTOLIMIT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PLDAMTTOAVALIMIT" runat="server">Pledging Amt. To Available Limit :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLDAMTTOAVALIMIT" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PPA_CADUM" runat="server">PPA Cadangan Umum :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PPA_CADUM" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PPA_CADKUS" runat="server">PPA Cadangan Khusus :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PPA_CADKUS" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD width="20%"></TD>
						<TD class="TDBGColor2" align="center" width="80%" colSpan="2"><asp:button id="BTN_SAVE" Runat="server" Width="76px" CssClass="button1" Text="SAVE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" Runat="server" Width="76px" CssClass="button1" Text="CLEAR"></asp:button>
							<!--<asp:button id="BTN_UPDATE" CssClass="button1" Width="132px" Runat="server" Text="UPDATE STATUS"></asp:button></TD>--></TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
