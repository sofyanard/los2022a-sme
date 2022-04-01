<%@ Page language="c#" Codebehind="COLLATERAL_DEP.aspx.cs" AutoEventWireup="True" Inherits="SME.CustomerInfo.COLLATERAL_DEP" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>COLLATERAL_DEP</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include  file="../include/cek_entries.html" -->
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
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">Keterangan Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox CssClass="mandatory" id="TXT_CL_DESC" onKeypress="return kutip_satu()" runat="server"
											MaxLength="50" Columns="25" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist CssClass="mandatory" id="DDL_CL_CURRENCY" runat="server"></asp:dropdownlist>
										<!--<asp:TextBox ID="TXT_CL_FOREIGNVAL" Runat="server" onKeypress="return digitsonly()" onkeyup="HitungLimit()"
											onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE)" MaxLength="15"></asp:TextBox>
										<asp:TextBox id="TXT_CL_EXCHANGERATE" runat="server" CssClass="angkamandatory" onKeypress="return digitsonly()" Visible=False
											onkeyup="HitungLimit()" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE)" MaxLength="15"></asp:TextBox>
										-->
									</TD>
								</TR>
								<!--
								<TR>
									<TD class="TDBGColor1">Exchange Rate to Rp</TD>
									<TD></TD>
									<TD class="TDBGColorValue">									
									</TD>
								</TR>								
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist CssClass="mandatory" id="DDL_CL_COLCLASSIFY" runat="server"></asp:dropdownlist></TD>
								</TR>
								-->
								<TR>
									<TD class="TDBGColor1">Core Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox CssClass="mandatory" ID="TXT_SIBS_COLID" Runat="server" MaxLength="35" Columns="30"
											onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penilaian Menurut</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_VALACCRDTO" runat="server"></asp:DropDownList>
										&nbsp;<asp:CheckBox ID="CHB_CL_ISCASHEDVALUE" Runat="server"></asp:CheckBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_JNSAGUNAN" runat="server" CssClass="mandatory"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_IKATTYPE" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bank/ simpanan tabungan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_BANK" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. FDR/ No. Rek. Tabungan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_REKNUM" runat="server" Columns="25" MaxLength="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Rekening</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_REKTYPE" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_REKCURRENCY" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_BANK">
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox CssClass="mandatory" id="TXT_CL_VALUE" runat="server" Columns="25" MaxLength="21"
											onKeypress="return numbersonly()" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PASAR">
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox CssClass="mandatory" id="TXT_CL_VALUE2" runat="server" Columns="25" MaxLength="21"
											onKeypress="return numbersonly()" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR  runat="server" id="TR_NILAI_ASURANSI">
									<TD class="TDBGColor1">Nilai Asuransi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEINS" runat="server" Columns="25" MaxLength="21"
											onKeypress="return numbersonly()" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR  runat="server" id="TR_NILAI_PENGIKATAN">
									<TD class="TDBGColor1">Nilai Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEIKAT" runat="server" Columns="25" MaxLength="21"
											onKeypress="return numbersonly()" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR  runat="server" id="TR_NILAI_PENGURANG_PPA">
									<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEPPA" runat="server" Columns="25" MaxLength="21"
											onKeypress="return numbersonly()" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR  runat="server" id="TR_NILAI_LIKUIDASI">
									<TD class="TDBGColor1">Nilai Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUELIQ" runat="server" Columns="25" MaxLength="21"
											onKeypress="return numbersonly()" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Suku bunga FDR</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_FDRRATE" runat="server" Columns="6" MaxLength="6" onKeypress="return digitsonly()"></asp:TextBox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penerbit FDR</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_FDRISSUEDBY" runat="server" Columns="20" MaxLength="20" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl. Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_FDRISSUEDDATEDAY" runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList id="DDL_CL_FDRISSUEDDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_FDRISSUEDDATEYEAR" runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl. Kadaluarsa FDR</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_FDREXPIREDDATEDAY" runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList id="DDL_CL_FDREXPIREDDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_FDREXPIREDDATEYEAR" runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tenor term</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_TENORTERM" runat="server" Columns="4" MaxLength="3" onKeypress="return numbersonly()"></asp:TextBox>Bulan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Spread Rate</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_SPRDRATE" runat="server" Columns="6" MaxLength="6" onKeypress="return digitsonly()"></asp:TextBox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Buku Tabungan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_REKBOOKNUM" runat="server" Columns="30" MaxLength="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Hubungan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_RELATIONSHIP" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Deposit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_OWNERNMFIRST" runat="server" Columns="30" MaxLength="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_OWNERNMMID" runat="server" Columns="30" MaxLength="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_OWNERNMLAST" runat="server" Columns="30" MaxLength="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Review</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_REVIEWDATEDAY" runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList id="DDL_CL_REVIEWDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_REVIEWDATEYEAR" runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Garansi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_GUARANTEEVAL" runat="server" Columns="25" MaxLength="21" onKeypress="return numbersonly()"
											CssClass="angka" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl. Jatuh Tempo Garansi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_GUARANTEEDUEDATEDAY" runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList id="DDL_CL_GUARANTEEDUEDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_GUARANTEEDUEDATEYEAR" runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Instruksi untuk Tgl Due</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_INSTDUE" runat="server" Columns="25" MaxLength="100" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" bgColor="red" colSpan="2"><STRONG style="COLOR: #ffffff">Deposito 
								sebagai agunan tidak langsung link kepada fasilitas. Diminta konfirmasi di BDS 
								setelah rekening terbentuk</STRONG></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp; 
							
							<% if (Request.QueryString["appr"] == "1") { %>
							
							<INPUT type="button" value="Update" class="button1" onclick="return update('<%=Request.QueryString["regno"]%>','<%=Request.QueryString["curef"]%>');">&nbsp;
							
							<% } %>
							<% if (Request.QueryString["de"] == "1") { %>
													<input type="button" id="Button1" name="Button1" Value="Save" Class="Button1" onClick="return cek_mandatory(document.Form1);">&nbsp; 
							
							<% } %>
							
							<asp:Label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_REGNO" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_CUREF" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_TC" runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
		<script language="vbscript">
		function HitungLimit()
			SetLocale("in")
			set obj = document.Form1
			EXLIMIT = obj.TXT_CL_EXCHANGERATE.value
			EXRPLIMIT = obj.TXT_CL_FOREIGNVAL.value
			if isnumeric(EXLIMIT) then
				EXLIMIT = cdbl(EXLIMIT)
			else
				EXLIMIT = 0
			end if
			
			if isnumeric(EXRPLIMIT) then
				EXRPLIMIT = cdbl(EXRPLIMIT)
			else
				EXRPLIMIT = 0
			end if
			obj.TXT_CL_VALUE.value = EXLIMIT * EXRPLIMIT	
		end function
		</script>
	</body>
</HTML>
