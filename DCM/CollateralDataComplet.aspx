<%@ Page language="c#" Codebehind="CollateralDataComplet.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.CollateralDataComplet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralDataComplet</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<%if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) {%>
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" align="center" width="30%"><B>COLLATERAL DATA COMPLETENEWW</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
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
									<TD vAlign="top" width="20%"><asp:table id="TBL_FASILITAS" CssClass="BackGroundList" Width="100%" Runat="server"></asp:table><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></TD>
									<td><iframe id="frm_sandibi" name="frm_sandibi" frameBorder="0" width="100%" scrolling="auto"
											height="400"></iframe>
									</td>
									<TD class="td" vAlign="top" width="40%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Type Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist3" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Keterangan Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox8" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Sifat Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist4" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Pemilik Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox10" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Bukti Kepemilikan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist5" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status Kepemilikan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist22" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tgl. Terbit Sertifikat</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox11" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist6" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox12" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tgl. Expired Sertifikat</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox7" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist23" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox9" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Alamat Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox13" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Lokasi Dati II</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist7" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kode Mata Uang</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist8" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai Pasar</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox14" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai Appraisal</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox15" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai Likuidasi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox16" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nilai NJOP</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox20" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="40%">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Nilai Pengikatan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox1" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Pengikatan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="Textbox23" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggl Penilaian ke-1</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox4" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox5" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggl Penilaian Terakhir</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox2" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist9" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox17" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Penilaian Oleh</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist2" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Pengikatan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist10" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Pengikatan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox6" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist11" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox18" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Agunan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist13" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Asuransi</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:radiobuttonlist id="RDO_KEY_PERSON_COMP" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Y" Selected="True">Yes</asp:ListItem>
														<asp:ListItem Value="N">No</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Peringkat Surat Berharga</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist12" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Peringkat</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox19" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist15" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox21" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Penerbit Surat Berharga</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="Dropdownlist16" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggl Penerbitan</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox25" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist14" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox26" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">&nbsp;Tanggal Jatuh Tempo</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return numbersonly()" id="Textbox27" runat="server" Width="24px" Columns="4"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="Dropdownlist20" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox28" runat="server" Width="36px" Columns="4"
														MaxLength="4"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" CssClass="button1" Runat="server" Text="SAVE"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button1" CssClass="button1" Width="132px" Runat="server" Text="UPDATE STATUS"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
