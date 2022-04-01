<%@ Page language="c#" Codebehind="COLLATERAL_RE.aspx.cs" AutoEventWireup="True" Inherits="SME.RejectMaintenanceDE.Jaminan_RealEstate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Jaminan_RealEstate</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
									<TD class="TDBGColor1">Bukti Pemilikan Hak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CERTTYPE1" runat="server"></asp:dropdownlist><asp:dropdownlist id="DDL_CL_CERTTYPE2" runat="server" Visible="False"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Property Type</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_PROPTYPE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No sertifikat</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_CERTNO" runat="server" MaxLength="50" Columns="25" onKeypress="return kutip_satu()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Terbit Sertifikat</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CL_CERTISSUEDAY" runat="server" MaxLength="2" Columns="2" onkeypress="return numbersonly()"></asp:textbox><asp:dropdownlist id="DDL_CL_CERTISSUEMONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CL_CERTISSUEYEAR" runat="server" onkeypress="return numbersonly()" MaxLength="4"
											Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tgl Kadaluarsa Sertifikat</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_CERTEXPIREDAY" runat="server" MaxLength="2" Columns="2" onkeypress="return numbersonly()"></asp:textbox><asp:dropdownlist id="DDL_CL_CERTEXPIREMONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CL_CERTEXPIREYEAR" runat="server" onkeypress="return numbersonly()" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Luas Tanah</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_LANDAREA" runat="server" MaxLength="10" Columns="10" onkeypress="return numbersonly()"></asp:textbox>m2 
										(persegi)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Luas Bangunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_BUILDAREA" runat="server" MaxLength="10" Columns="10" onkeypress="return numbersonly()"></asp:textbox>m2 
										(persegi)</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemilik</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_OWNER" runat="server" MaxLength="100" Columns="25" onKeypress="return kutip_satu()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Hubungan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_RELATIONSHIP" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="200">Nilai Bank</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="200">Nilai Pasar</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE2" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="200">Nilai Asuransi</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEINS" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="200">Nilai Pengikatan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEIKAT" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="200">Nilai Pengurang PPA</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEPPA" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_DEVELOPER" runat="server" Visible="False"></asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="200">Nilai Likuidasi</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUELIQ" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<!--<TR>
									<TD class="TDBGColor1">Hasil Penilaian</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_RESULTVAL" runat="server" MaxLength="21" Columns="25" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_MARKETVAL" runat="server" MaxLength="21" Columns="25" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Agunan Untuk PPAP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_PPAPVAL" runat="server" MaxLength="21" Columns="25" onkeypress="return numbersonly()"
											onblur="FormatCurrency(this)"></asp:textbox>
										
									</TD>
								</TR>-->
								<TR>
									<TD align="right"><b>Location of Lot:</b></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Perum/Jalan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_LOCJLN" runat="server" MaxLength="50" Columns="25" onKeypress="return kutip_satu()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">RT/RW</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_LOCRT" runat="server" MaxLength="3" Columns="3" onKeypress="return kutip_satu()"></asp:textbox>/
										<asp:textbox id="TXT_CL_LOCRW" runat="server" MaxLength="3" Columns="3" onKeypress="return kutip_satu()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Kapling/rumah</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_LOCKAVNO" runat="server" Columns="20" MaxLength="20" onKeypress="return kutip_satu()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 17px">Lokasi Agunan</TD>
									<TD style="HEIGHT: 17px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CL_COLLOC" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penilaian Menurut</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_VALACCRDTO" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_JNSAGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<input type="button" id="Button1" name="Button1" Value="Save" Class="Button1" runat="server" onserverclick="Button1_ServerClick">&nbsp;
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
