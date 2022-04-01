<%@ Page language="c#" Codebehind="Collateral_Lsagr.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.Collateral_Lsagr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Collateral_Lsagr</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../../include/cek_all.html" -->
		<!-- #include  file="../../../include/cek_entries.html" -->
		<script language="javascript">
		function update(regno, curef) {
			if(regno != curef + 'C')
			{
				parent.document.Form1.action = "../VerificationAssignment/AppraisalAssignment.aspx?regno=" + regno + "&curef=" + curef;
			}
			else if(regno == curef + 'C')
			{
				parent.document.Form1.action = "../VerificationAssignment/AppraisalAssignmentCBI.aspx?regno=" + regno + "&curef=" + curef + "&mc=030";
			}
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
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">
										Keterangan&nbsp;Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_DESC" onKeypress="return kutip_satu()" runat="server" MaxLength="50"
											Columns="25" Width="350" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Posisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_posisi" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST ke CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_KE_CA" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No BAST dari&nbsp;CA</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAST_DARI_CA" runat="server" Width="300px"
											MaxLength="100"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_SIBS_COLID" Runat="server" readonly MaxLength="35" Columns="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Perusahaan Leasing</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_COMPNAME" Width="350" onKeypress="return kutip_satu()" runat="server"
											MaxLength="100" Columns="25" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Building Ownership</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_BUILDOWN" Width="350" onKeypress="return kutip_satu()" runat="server"
											MaxLength="100" Columns="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Property</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_PROPTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
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
									<TD class="TDBGColor1">Tanggal Kadaluarsa</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_EXPDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_EXPDATEMONTH" runat="server"></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_EXPDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Penilaian</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_APPRDATEDAY" MaxLength="2" Columns="2" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
										<asp:dropdownlist id="DDL_CL_APPRDATEMONTH" runat="server"></asp:dropdownlist>
										<asp:TextBox id="TXT_CL_APPRDATEYEAR" MaxLength="4" Columns="4" runat="server" onKeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Penilai</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_APPRBY" onKeypress="return kutip_satu()" runat="server" MaxLength="100"
											Columns="25"></asp:textbox></TD>
								</TR>
								<!--<TR>
									<TD class="TDBGColor1">Hasil Penilaian</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_APPRVAL" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" CssClass="angka" onblur = "FormatCurrency(this)"></asp:textbox></TD>
								</TR>-->
								<TR>
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" CssClass="mandatory" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE2" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" CssClass="mandatory" onblur="FormatCurrency(this)"></asp:textbox></TD>
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
									<TD class="TDBGColor1">Nilai Garansi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_GUARANTEEVAL" onKeypress="return numbersonly()" runat="server" MaxLength="21"
											Columns="25" CssClass="angka" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Exchange Rate</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_EXCHGRATE" onKeypress="return numbersonly()" runat="server" MaxLength="6"
											Columns="6" CssClass="angka"></asp:textbox>%</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" valign="top">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CL_ADDR1" onKeypress="return kutip_satu()" runat="server" MaxLength="30"
											Columns="25"></asp:textbox><br>
										<asp:textbox id="TXT_CL_ADDR2" onKeypress="return kutip_satu()" runat="server" MaxLength="30"
											Columns="25"></asp:textbox><br>
										<asp:textbox id="TXT_CL_ADDR3" onKeypress="return kutip_satu()" runat="server" MaxLength="30"
											Columns="25"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Rumah</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_HMNUM" onKeypress="return kutip_satu()" runat="server" MaxLength="10"
											Columns="10"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:Button id="btn_save" runat="server" CssClass="button1" Text="Save" Visible="False" onclick="btn_save_Click"></asp:Button>
							<asp:button id="BTN_FINISH" runat="server" Width="106px" Text="FINISH" CssClass="Button1" Enabled="False" onclick="BTN_FINISH_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_FIND" runat="server">
						<TD class="tdNoBorder" style="WIDTH: 483px" vAlign="top" width="483">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129">CAO Name :</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px">
										<asp:dropdownlist id="DDL_CAO_NAME" runat="server"></asp:dropdownlist>
										<asp:button id="BTN_SEND" Runat="server" Text="Send" onclick="BTN_SEND_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="50%" colSpan="2">
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
