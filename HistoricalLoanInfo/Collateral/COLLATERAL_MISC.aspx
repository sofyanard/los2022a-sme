<%@ Page language="c#" Codebehind="COLLATERAL_MISC.aspx.cs" AutoEventWireup="True" Inherits="SME.HistoricalLoanInfo.Collateral.COLLATERAL_MISC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>COLLATERAL_MISC</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../include/cek_all.html" -->
		<!-- #include  file="../../include/cek_entries.html" -->
			<script language="javascript">
		function update(regno, curef) {
			parent.document.Form1.action = "../../VerificationAssignment/AppraisalAssignment.aspx?regno=" + regno + "&curef=" + curef;
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
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_DESC" onKeypress="return kutip_satu()" runat="server" MaxLength="50" Width=400
											Columns="25" CssClass="mandatory" Enabled=False ></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatory" Enabled=False ></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatory" Enabled=False ></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">SIBS Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_SIBS_COLID" Runat="server" readonly MaxLength="35" Columns="30" onKeypress="return kutip_satu()" Enabled=False ></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE" MaxLength="21" Columns="25" runat="server" onKeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)" Enabled=False ></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Penilaian</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_VALUEDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()" Enabled=False ></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_VALUEDATEMONTH" runat="server" Enabled=False ></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_VALUEDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()" Enabled=False ></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Hasil Penilaian</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_APPRVALUE" CssClass="angka" MaxLength="21" Columns="25" runat="server"
											onKeypress="return numbersonly()" onblur = "FormatCurrency(this)" Enabled=False ></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Taksiran</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_APPRDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()" Enabled=False ></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_APPRDATEMONTH" runat="server" Enabled=False ></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_APPRDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()" Enabled=False ></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Penilai</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_APPRBY" MaxLength="100" Columns="25" runat="server" Width=400 Enabled=False ></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_JNSAGUNAN" runat="server" CssClass="mandatory" Enabled=False ></asp:DropDownList></TD>
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
	</body>
</HTML>
