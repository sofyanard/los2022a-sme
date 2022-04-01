<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocUpload.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocExport.ascx" %>
<%@ Page language="c#" Codebehind="SiteVisit.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.CBI.SiteVisit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SiteVisit</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../include/cek_all.html" -->
		<script language="javascript">
		  function fillText(sTXT)
		  {
		    objTXT = eval('document.Form1.TXT_' + sTXT)
		    objDDL = eval('document.Form1.DDL_' + sTXT)
		    objTXT.value = objDDL.options[objDDL.selectedIndex].text;
		  }
		</script>
		</SCRIPT>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" width="50%">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Site Visit</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" width="100%" colSpan="2">Laporan Hasil Kunjungan</td>
					</tr>
					<tr>
						<td class="td" style="WIDTH: 675px" vAlign="top" width="675"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Tanggal Kunjungan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DAY" runat="server" Columns="2" MaxLength="2"
											CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_BLN_VISIT" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR" runat="server" Columns="4" MaxLength="4"
											CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Dilaksanakan Oleh</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DILAKSANAKAN1" runat="server" CssClass="mandatory" Width="146px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px" width="150">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DILAKSANAKAN2" runat="server" Width="146px" BorderStyle="None"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></td>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Diterima Oleh</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DITERIMA1" runat="server" CssClass="mandatory" Width="146px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DITERIMA2" runat="server" Width="146px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DITERIMA3" runat="server" Width="146px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<td class="td" vAlign="top" width="100%" colSpan="2">
							<table width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px">Luas Bangunan Tempat 
										Usaha</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_AREA" runat="server" MaxLength="25" Width="48px"></asp:textbox>M2</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px">&nbsp;&nbsp;&nbsp; Status 
										Kepemilikan Tempat Usaha</TD>
									<TD>:</TD>
									<td class="TDBGColorValue"><asp:radiobuttonlist id="RDO_STATUS" runat="server" Width="200 px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Milik Sendiri</asp:ListItem>
											<asp:ListItem Value="1">Sewa</asp:ListItem>
										</asp:radiobuttonlist></td>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px" width="251">Lama 
										Menempati Gedung</TD>
									<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_OWN_AGE" runat="server" MaxLength="25"
											Width="48px"></asp:textbox>&nbsp;Tahun. Sejak Tahun&nbsp;
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_SINCE" runat="server" MaxLength="25" Width="48px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px" width="251">Alamat Cabang</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_Address1" runat="server" MaxLength="80"
											Width="150px"></asp:textbox>&nbsp;No.&nbsp;
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_NO1" MaxLength="25" Width="48px" Runat="server"></asp:textbox>&nbsp;Kota&nbsp;
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CITY1" MaxLength="80" Width="150px" Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px" width="251"></TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_ADDRESS2" runat="server" MaxLength="80"
											Width="150px"></asp:textbox>&nbsp;No.&nbsp;
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_NO2" MaxLength="25" Width="48px" Runat="server"></asp:textbox>&nbsp;Kota&nbsp;
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CITY2" MaxLength="80" Width="150px" Runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px">Kontak Person Cabang</TD>
									<TD style="HEIGHT: 20px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PIC1" runat="server" MaxLength="100" Width="150px"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_PIC2" runat="server" MaxLength="100" Width="150px"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_PIC3" runat="server" MaxLength="100" Width="150px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px">Jumlah Tenaga Kerja</TD>
									<TD style="HEIGHT: 22px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_EMPLOYEE" runat="server" MaxLength="25"
											Width="48px"></asp:textbox>&nbsp;Orang&nbsp;&nbsp;&nbsp;
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px"></TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_EXPERT" runat="server" MaxLength="25" Width="48px"></asp:textbox>&nbsp;Tenaga 
										Ahli&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_ADMIN" runat="server" MaxLength="25" Width="48px"></asp:textbox>&nbsp;Tenaga 
										Administrasi&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_OUTSOURCE" runat="server" MaxLength="25"
											Width="48px"></asp:textbox>Tidak Tetap</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px">Peralatan Kantor</TD>
									<TD>:</TD>
									<td class="TDBGColorValue"><asp:radiobuttonlist id="RDO_EQUITMENT" runat="server" Width="280 px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Memadai</asp:ListItem>
											<asp:ListItem Value="1">Tidak Memadai</asp:ListItem>
										</asp:radiobuttonlist></td>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px">Sistem Database yang Dimiliki</TD>
									<TD>:</TD>
									<td class="TDBGColorValue"><asp:radiobuttonlist id="RDO_DATABASE" runat="server" Width="280 px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Mempunyai</asp:ListItem>
											<asp:ListItem Value="1">Tidak Mempunyai</asp:ListItem>
										</asp:radiobuttonlist></td>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px; HEIGHT: 19px">Kondisi Gedung</TD>
									<TD style="HEIGHT: 21px">:</TD>
									<td class="TDBGColorValue"><asp:radiobuttonlist id="RDO_BUILDING" runat="server" Width="280 px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Rumah</asp:ListItem>
											<asp:ListItem Value="1">Ruko</asp:ListItem>
											<asp:ListItem Value="2">Gedung</asp:ListItem>
										</asp:radiobuttonlist></td>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px">Kondisi Ruang Arsip</TD>
									<TD>:</TD>
									<td class="TDBGColorValue"><asp:radiobuttonlist id="RDO_ARSIP_ROOM" runat="server" Width="280 px" RepeatDirection="Horizontal">
											<asp:ListItem Value="0" Selected="True">Mempunyai</asp:ListItem>
											<asp:ListItem Value="1">Tidak Mempunyai</asp:ListItem>
										</asp:radiobuttonlist></td>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px">Kegiatan yang Sedang dilakukan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ACTIVITY1" runat="server" MaxLength="100"
											Width="592px" Height="50px" TextMode="MultiLine"></asp:textbox><br>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 251px"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ACTIVITY2" runat="server" MaxLength="100"
											Width="592px" Visible="False"></asp:textbox></TD>
								</TR>
							</table>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" width="100%" colSpan="2">Kesimpulan/Pendapat</td>
					</tr>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_VISIT" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="false" DataField="ID_MATERI"></asp:BoundColumn>
									<asp:BoundColumn Visible="false" DataField="REGNUM"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESC_MATERI" HeaderText="Materi">
										<HeaderStyle CssClass="tdSmallHeader" Width="50%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERSEN_BOBOT" HeaderText="Bobot (%)">
										<HeaderStyle CssClass="tdSmallHeader" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="false" DataField="NILAI_BOBOT"></asp:BoundColumn>
									<asp:BoundColumn Visible="false" DataField="ISCOMPLY"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Skala">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_VISIT" runat="server" RepeatDirection="Horizontal" DataValueField="iscomply">
												<asp:ListItem Value="1">1</asp:ListItem>
												<asp:ListItem Value="2">2</asp:ListItem>
												<asp:ListItem Value="3">3</asp:ListItem>
												<asp:ListItem Value="4">4</asp:ListItem>
												<asp:ListItem Value="5">5</asp:ListItem>
											</asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="SCORE" HeaderText="Total">
										<HeaderStyle CssClass="tdSmallHeader" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_SUM" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SUM"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1" colSpan="2">TOTAL&nbsp;:<asp:textbox id="TXT_SUM" runat="server" Width="220px" ReadOnly="True"></asp:textbox></TD>
					</TR>
					<tr>
						<td colSpan="2">Pembobotan : 1 = Kurang Sekali&nbsp;&nbsp; 2 = Kurang&nbsp;&nbsp; 3 
							= Sedang&nbsp;&nbsp; 4 = Baik&nbsp;&nbsp; 5 = Baik Sekali
						</td>
					</tr>
					<tr>
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" CssClass="Button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_PRINT" runat="server" CssClass="Button1" Text="Print" onclick="BTN_PRINT_Click"></asp:button></td>
					</tr>
					<TR>
						<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
					</TR>
					<TR>
						<TD colSpan="2"><uc1:docupload id="DocUpload1" runat="server"></uc1:docupload></TD>
					</TR>
				</TABLE>
		</form>
		</CENTER>
	</body>
</HTML>
