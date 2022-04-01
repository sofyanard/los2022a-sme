<%@ Page language="c#" Codebehind="KolektibilitasAccount.aspx.cs" AutoEventWireup="True" Inherits="SME.CustomerInfo.KolektibilitasAccount" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KolektibilitasAccount</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
		}
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../include/onepost.html" -->
		<!-- #include  file="../include/exportpost.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD style="WIDTH: 361px" width="361" height="35">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer Info - 
											Kolektibilitas</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2" height="160">
							<asp:PlaceHolder id="Menu" runat="server"></asp:PlaceHolder></TD>
					</TR>
					<TR>
						<TD class="tdheader1" align="center" colSpan="2">Kolektibilitas</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 89px" align="left" colSpan="2">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 5px">Nasabah</TD>
									<TD style="WIDTH: 529px; HEIGHT: 5px"><asp:dropdownlist id="DDL_NASABAH" runat="server" Width="200px">
											<asp:ListItem Value="0">Nasabah</asp:ListItem>
											<asp:ListItem Value="1">Key Person</asp:ListItem>
											<asp:ListItem Value="2">Pemilik</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kolektibilitas berubah menjadi
									</TD>
									<TD style="WIDTH: 529px"><asp:dropdownlist id="DDL_COLL_FILTER" runat="server" Width="136px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 22px">Durasi</TD>
									<TD style="WIDTH: 529px; HEIGHT: 22px"><asp:dropdownlist id="DDL_DURASI_FILTER" runat="server" Width="136px">
											<asp:ListItem Value="12">12 Bulan Terakhir</asp:ListItem>
											<asp:ListItem Value="24">24 Bulan Terakhir</asp:ListItem>
										</asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" colSpan="2">
										<asp:button id="BTN_CARI" runat="server" CssClass="Button1" Text="Search" onclick="BTN_CARI_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_COLL" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False"
								CellPadding="1" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ACC_TYPE"></asp:BoundColumn>
									<asp:BoundColumn DataField="COLL_CODE" HeaderText="Kode Kolektibilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACC_NO" HeaderText="Nomor Rekening">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TGL_PERUBAHAN_COLL" HeaderText="Tanggal Perubahan" DataFormatString="{0:dd MMMM yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="USER_ID" HeaderText="Diubah Oleh">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<P></P>
							<P>
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD class="tdheader1" align="center" colSpan="2">APPLICANT</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Kolektibilitas Terburuk 12 Bulan 
											Terakhir</TD>
										<TD>
											<asp:dropdownlist id="DDL_WORSTIN12MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_COLL_W_12" runat="server" Visible="False">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Kolektibilitas Perusahaan Saat Ini</TD>
										<TD>
											<asp:dropdownlist id="DDL_COLL_CURR_CUST" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Frekuensi Kolektibilitas Perusahaan 2A 
											pada 12 bulan terakhir</TD>
										<TD><asp:textbox id="TXT_NUM_COLL_2A" runat="server" MaxLength="1" Columns="2" onkeypress="return numbersonly()">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Frekuensi Kolektibilitas Perusahaan 2B 
											pada 12 bulan terakhir</TD>
										<TD><asp:textbox id="TXT_NUM_COLL_2B" runat="server" MaxLength="1" Columns="2" onkeypress="return numbersonly()">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Frekuensi Kolektibilitas Perusahaan 2C 
											pada 12 bulan terakhir</TD>
										<TD><asp:textbox id="TXT_NUM_COLL_2C" runat="server" MaxLength="1" Columns="2" onkeypress="return numbersonly()">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Frekuensi Kolektibilitas Perusahaan 
											&gt;= 3 pada 12 bulan terakhir</TD>
										<TD><asp:textbox id="TXT_NUM_COLL_3PLUS" runat="server" MaxLength="1" Columns="2" onkeypress="return numbersonly()">0</asp:textbox>&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">
											Perusahaan tercatat dalam Daftar Hitam di BM</TD>
										<TD>
											<asp:radiobuttonlist id="RDO_BM_BL_PERUSAHAAN" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Ya</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="tdheader1" align="center" colSpan="2">PEMILIK
											<asp:Label id="Label1" runat="server" Visible="False">[ INI DULUNYA KEY PERSON(S) ]</asp:Label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Frekuensi Kolektibilitas Pemilik &gt;= 
											2C pada 12 bulan terakhir</TD>
										<TD><asp:textbox id="TXT_COLL_2C_12_KP" runat="server" MaxLength="1" Columns="2" onkeypress="return numbersonly()">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Kolektibilitas Pemilik Saat ini di BM</TD>
										<TD><asp:dropdownlist id="DDL_COLL_KP_CURR" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">
											Pemilik&nbsp;tercatat dalam Daftar Hitam di BM</TD>
										<TD>
											<asp:radiobuttonlist id="RDO_BM_BL_PEMILIK" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Ya</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="tdheader1" align="center" colSpan="2">KEY PERSON
											<asp:Label id="LBL_JUDUL" runat="server" Visible="False">[ INI DULUNYA MANAGEMENT ]</asp:Label></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Frekuensi Kolektibilitas Key Person 
											&gt;= 2C pada 12 bulan terakhir</TD>
										<TD><asp:textbox id="TXT_COLL_2C_12_MGM" runat="server" MaxLength="1" Columns="2" onkeypress="return numbersonly()">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Kolektibilitas Key Person Saat ini di 
											BM</TD>
										<TD><asp:dropdownlist id="DDL_COLL_MGM_CURR" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Key Person&nbsp;tercatat dalam Daftar 
											Hitam di BM</TD>
										<TD>
											<asp:radiobuttonlist id="RDO_BM_BL_MGMT" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Ya</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 100px" colSpan="2">
							<P><asp:label id="Label3" runat="server" Font-Size="Medium">Rating</asp:label></P>
							<P>
								Lancar untuk&nbsp;24 Bulan Terakhir&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:dropdownlist id="DDL_LANCAR12" runat="server" Width="104px" Height="8px">
									<asp:ListItem Value="1">Y</asp:ListItem>
									<asp:ListItem Value="0">N</asp:ListItem>
								</asp:dropdownlist><BR>
								Full Recovery&nbsp;On Previous Default&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:dropdownlist id="DDL_FULLRECOVERY" runat="server" Width="104px">
									<asp:ListItem Value="1">Y</asp:ListItem>
									<asp:ListItem Value="0">N</asp:ListItem>
								</asp:dropdownlist>
								<asp:Label id="LBL_SQL" runat="server" Visible="False"></asp:Label></P>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save Kolektibilitas" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
					<tr>
						<td colspan="2"></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">BI Checking - BlackList Info</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="50%" border="0">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 336px">Perusahaan Tercatat dalam Daftar Hitam 
										di BI</TD>
									<TD><asp:radiobuttonlist id="RDO_AP_BLBIUSAHA" runat="server" RepeatDirection="Horizontal" Width="150px">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 336px">Key Person Tercatat dalam Daftar Hitam 
										di BI</TD>
									<TD><asp:radiobuttonlist id="RDO_AP_BLBIMGMT" runat="server" RepeatDirection="Horizontal" Width="150px">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 336px">Pemilik Tercatat dalam Daftar Hitam di 
										BI</TD>
									<TD><asp:radiobuttonlist id="RDO_AP_BLBIPEMILIK" runat="server" RepeatDirection="Horizontal" Width="150px">
											<asp:ListItem Value="1">Ya</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 336px; HEIGHT: 13px">Kolektibilitas perusahaan 
										saat ini di bank lain (IDI BI)
									</TD>
									<TD style="HEIGHT: 13px"><asp:dropdownlist id="DDL_ACCBK" runat="server" Width="136px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 336px">Kolektibilitas pemilik saat ini di bank 
										lain (IDI BI)</TD>
									<TD><asp:dropdownlist id="DDL_OCBK" runat="server" Width="136px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 336px">Kolektibilitas Key Person saat ini di 
										bank lain (IDI BI)</TD>
									<TD><asp:dropdownlist id="DDL_MCBKS" runat="server" Width="136px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:radiobuttonlist id="RDO_AP_BLBIPERNAH" runat="server" RepeatDirection="Horizontal" Width="150px"
								Visible="False">
								<asp:ListItem Value="1">Ya</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
							</asp:radiobuttonlist>
							<asp:Label id="Label2" runat="server" Visible="False">[dulu Y/N ini untuk Nasabah BL di BI]</asp:Label></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" colSpan="2"><asp:button id="BTN_UPDATE_BI" runat="server" Text="Update BI" CssClass="Button1" onclick="BTN_UPDATE_BI_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
