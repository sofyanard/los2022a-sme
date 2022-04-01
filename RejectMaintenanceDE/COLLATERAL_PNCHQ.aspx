<%@ Page language="c#" Codebehind="COLLATERAL_PNCHQ.aspx.cs" AutoEventWireup="True" Inherits="SME.RejectMaintenanceDE.COLLATERAL_PNCHQ" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>COLLATERAL_PNCHQ</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_all.html" -->
		<!-- #include  file="../include/cek_entries.html" -->
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
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_DESC" onKeypress="return kutip_satu()" runat="server" MaxLength="50"
											Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Core Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_SIBS_COLID" Runat="server" MaxLength="35" Columns="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Cheques</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_CHECKNO" onKeypress="return kutip_satu()" runat="server" MaxLength="20"
											Columns="20"></asp:textbox>
										<asp:CheckBox ID="CHB_CL_ISCASHEDVALUE" Runat="server"></asp:CheckBox>Nilai 
										tunai untuk penjualan paksa
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Cheques</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_CHECKDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_CHECKDATEMONTH" runat="server"></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_CHECKDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE2" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Asuransi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEINS" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEIKAT" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEPPA" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUELIQ" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_AMOUNT" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Penarik</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_CASHEDBY" onKeypress="return kutip_satu()" runat="server" MaxLength="100"
											Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Endorsers</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_ENDORSERS" onKeypress="return kutip_satu()" runat="server" MaxLength="100"
											Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Holder / Payee</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CL_PAYEE" onKeypress="return kutip_satu()" runat="server" MaxLength="100"
											Columns="25"></asp:textbox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp; <input type="button" id="Button1" name="Button1" Value="Save" Class="Button1" runat="server" onserverclick="Button1_ServerClick">&nbsp;
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
