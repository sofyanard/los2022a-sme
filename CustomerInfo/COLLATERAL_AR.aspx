<%@ Page language="c#" Codebehind="COLLATERAL_AR.aspx.cs" AutoEventWireup="True" Inherits="SME.CustomerInfo.COLLATERAL_AR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>COLLATERAL_AR</title>
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
									<TD class="TDBGColor1">Core Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox CssClass="mandatory" ID="TXT_SIBS_COLID" Runat="server" MaxLength="35" Columns="30"
											onKeypress="return kutip_satu()" Width="300px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist CssClass="mandatory" id="DDL_CL_CURRENCY" runat="server"></asp:dropdownlist>										
									</TD>
								</TR>
								<!--
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist Visible=False CssClass="mandatory" id="DDL_CL_COLCLASSIFY" runat="server"></asp:dropdownlist>
									</TD>
								</TR>
								-->
								<TR>
									<TD class="TDBGColor1">Nama Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_COLLNAME" MaxLength="30" Columns="25" runat="server" onKeypress="return kutip_satu()"
											Width="300px"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_BANK">
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											CssClass="mandatory" onblur="FormatCurrency(this)" Width="300px"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PASAR">
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE2" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											CssClass="mandatory" onblur="FormatCurrency(this)" Width="300px"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_ASURANSI">
									<TD class="TDBGColor1">Nilai Asuransi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEINS" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											onblur="FormatCurrency(this)" Width="300px"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PENGIKATAN">
									<TD class="TDBGColor1">Nilai Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEIKAT" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											onblur="FormatCurrency(this)" Width="300px"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PENGURANG_PPA">
									<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEPPA" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											onblur="FormatCurrency(this)" Width="300px"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_LIKUIDASI">
									<TD class="TDBGColor1">Nilai Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUELIQ" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											onblur="FormatCurrency(this)" Width="300px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_ISSUEDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_ISSUEDATEMONTH" runat="server"></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_ISSUEDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Review</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_REVIEWDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_REVIEWDATEMONTH" runat="server"></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_REVIEWDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Aging Amount</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_AGINGAMNT" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											CssClass="angka" onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Kadaluarsa</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_EXPDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_EXPDATEMONTH" runat="server"></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_EXPDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<% if (Request.QueryString["appr"] == "1") { %>
					
							<INPUT type="button" value="Update" class="button1" onclick="return update('<%=Request.QueryString["regno"]%>','<%=Request.QueryString["curef"]%>');">&nbsp;
						
							<% } %>
							<% if (Request.QueryString["de"] == "1") { %>
							<input type="button" id="Button1" name="Button1" Value="Save" Class="Button1" onClick="return cek_mandatory(document.Form1);"
								style="WIDTH: 75px">&nbsp;
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
	</body>
</HTML>
