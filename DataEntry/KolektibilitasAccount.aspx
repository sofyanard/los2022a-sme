<%@ Page language="c#" Codebehind="KolektibilitasAccount.aspx.cs" AutoEventWireup="True" Inherits="Websysca.KolektibilitasAccount" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>List Customer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" width="100%"
					border="0">
					<TR>
						<TD style="WIDTH: 481px" align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Kolektibilitas&nbsp;Rekening 
											History</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD style="HEIGHT: 52px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 89px" align="left" colSpan="2">
							<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 5px">Nasabah</TD>
									<TD style="WIDTH: 529px; HEIGHT: 5px"><asp:dropdownlist id="DDL_NASABAH" runat="server" Width="200px" onselectedindexchanged="DDL_NASABAH_SelectedIndexChanged">
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
										<asp:button id="BTN_CARI" runat="server" CssClass="Button1" Text="Cari" 
                                            onclick="BTN_CARI_Click"></asp:button></TD>
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
										<TD class="tdheader1" align="center" colSpan="2">PEMOHON</TD>
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
											Perusahaan tercatat dalam Daftar Hitam di Bank</TD>
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
										<TD class="TDBGColor1" style="WIDTH: 406px">Kolektibilitas Pemilik Saat ini di Bank</TD>
										<TD><asp:dropdownlist id="DDL_COLL_KP_CURR" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">
											Pemilik&nbsp;tercatat dalam Daftar Hitam di Bank</TD>
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
											Bank</TD>
										<TD><asp:dropdownlist id="DDL_COLL_MGM_CURR" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 406px">Key Person&nbsp;tercatat dalam Daftar 
											Hitam di Bank</TD>
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
								<asp:dropdownlist id="DDL_LANCAR12" runat="server" Width="104px">
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
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" 
                                runat="server" Width="70px" Text="Simpan" CssClass="Button1" 
                                onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
