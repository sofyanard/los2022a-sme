<%@ Page language="c#" Codebehind="COLLATERAL_STOCK.aspx.cs" AutoEventWireup="True" Inherits="SME.CustomerInfo.COLLATERAL_STOCK" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>COLLATERAL_STOCK</title>
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
									<TD class="TDBGColor1" width="200">
										Keterangan&nbsp;Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox CssClass="mandatory" id="TXT_CL_DESC" onKeypress="return kutip_satu()" runat="server"
											MaxLength="50" Columns="25" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist CssClass="mandatory" id="DDL_CL_CURRENCY" runat="server"></asp:dropdownlist></TD>
								</TR>
								<!--<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist CssClass="mandatory" id="DDL_CL_COLCLASSIFY" runat="server"></asp:dropdownlist></TD>
								</TR>-->
								<TR>
									<TD class="TDBGColor1">Core Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox CssClass="mandatory" ID="TXT_SIBS_COLID" Runat="server" MaxLength="35" Columns="30"
											onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Share Counter</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_SHARECNTR" runat="server" MaxLength="20" Columns="20" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Share Counter No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_SHARECNTRNO" runat="server" MaxLength="20" Columns="20" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Number Of Share</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_NOOFSHARE" runat="server" MaxLength="9" Columns="25" onkeypress="return numbersonly()"
											Width="100px"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_BANK">
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											CssClass="mandatory" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PASAR">
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE2" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											CssClass="mandatory" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_ASURANSI">
									<TD class="TDBGColor1">Nilai Asuransi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEINS" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PENGIKATAN">
									<TD class="TDBGColor1">Nilai Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEIKAT" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PENGURANG_PPA">
									<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEPPA" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_LIKUIDASI">
									<TD class="TDBGColor1">Nilai Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUELIQ" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Unit Price</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_UNITPRICE" runat="server" CssClass="angkamandatory" MaxLength="21" Columns="25"
											onkeypress="return numbersonly()" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Penilaian</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_APPRDATEDAY" runat="server" MaxLength="2" Columns="2" onkeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList ID="DDL_CL_APPRDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_APPRDATEYEAR" runat="server" MaxLength="4" Columns="4" onkeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Peringkat Surat Berharga</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_PERINGKAT" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_JNSAGUNAN" runat="server"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp;
							<% if (Request.QueryString["appr"] == "1") { %>
							
							<INPUT type="button" value="Update" class="button1" onclick="return update('<%=Request.QueryString["regno"]%>','<%=Request.QueryString["curef"]%>');">&nbsp;
							
							<% } %>
							<% if (Request.QueryString["de"] == "1") { %>
							<input type="button" id="Button1" name="Button1" Value="Save" Class="Button1" onClick="return cek_mandatory(document.Form1);"
								style="WIDTH: 75px">&nbsp;
							<% } %>
							<asp:Label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_REGNO" runat="server" Visible="True"></asp:Label>
							<asp:Label id="LBL_CUREF" runat="server" Visible="True"></asp:Label>
							<asp:Label id="LBL_TC" runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
