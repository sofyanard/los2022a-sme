<%@ Page language="c#" Codebehind="DataOrganisasi.aspx.cs" AutoEventWireup="false" Inherits="SME.CEA.CBI.DataOrganisasi" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataOrganisasi</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Data&nbsp;Organisasi</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="MenuStrukturOrganisasi" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Data Organisasi</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table16" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Status Kantor</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_STATUS_KANTOR" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Jumlah Cabang</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JML_CAB" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Total Pegawai Tetap</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PEG_TETAP" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table15" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Total Pegawai Tidak Tetap</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PEG_TDK_TETAP" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Jumlah Agen</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JML_AGEN" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR id="TR_MODAL" runat="server">
								<TD class="TDBGColor1" style="WIDTH: 276px">Jumlah Modal</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_MODAL" runat="server" MaxLength="50" Width="300px"
										AutoPostBack="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE_SO" runat="server" Text="Simpan" CssClass="button1"></asp:button><asp:button id="BTN_CLEAR_SO" runat="server" Text="Hapus" CssClass="button1"></asp:button></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px" vAlign="top" width="100%" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Daftar Cabang/Perwakilan Rekanan</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGrdCab" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
								<asp:BoundColumn DataField="NAMA_CABANG" HeaderText="Nama Cabang/Perwakilan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="JENIS" HeaderText="JENIS CABANG">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ALAMAT" HeaderText="Alamat Cabang/Perwakilan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NO_TELP" HeaderText="No. Telp">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="edit_cab" runat="server" CommandName="edit_cab">Edit</asp:LinkButton>&nbsp;
										<asp:LinkButton id="delete_cab" runat="server" CommandName="delete_cab">Hapus</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 200px">Jenis</TD>
								<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JNS_CAB" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 200px">Nama Cabang/Perwakilan</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA_CAB" runat="server" MaxLength="50"
										Width="100%"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 200px">Alamat Cabang/Perwakilan</TD>
								<TD></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ADD_CAB" runat="server" Width="100%" Height="50px"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" align="center" width="50%">
						<TABLE id="Table33" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1">No. Telp.</TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_AREA" runat="server" MaxLength="4" Width="48px"></asp:textbox><asp:textbox id="TXT_NO_KNTR" runat="server" MaxLength="10" Width="120px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 100px">Wilayah</TD>
								<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_CITY_CAB" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 100px">Kecamatan</TD>
								<TD style="WIDTH: 15px; HEIGHT: 20px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_KAB_CAB" runat="server" AutoPostBack="True" Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Zipcode</TD>
								<TD>:</TD>
								<TD><asp:textbox id="TXT_ZIPCD_CAB" runat="server" Columns="5" AutoPostBack="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT_CAB" runat="server" Text="Tambah" CssClass="button1"></asp:button><asp:button id="BTN_UPDATE_CAB" runat="server" Text="Ubah" CssClass="button1"></asp:button><asp:button id="BTN_CLEAR_CAB" runat="server" Text="Hapus" CssClass="button1"></asp:button><asp:label id="TXT_SEQ_CAB" Runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px" vAlign="top" width="100%" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Tenaga Ahli</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2"><ASP:DATAGRID id="DatGridTenagaAhli" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
							PageSize="5" AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="SEQ"></asp:BoundColumn>
								<asp:BoundColumn DataField="NAMA" HeaderText="Nama">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="POSITION_TA" HeaderText="Jabatan">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TITLE" HeaderText="Gelar">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="EXPERIENCE" HeaderText="Pengalaman">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SERTIFIKASI" HeaderText="Sertifikasi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ASOSIASI_Profesi" HeaderText="Asosiasi Profesi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="edit_tenaga_ahli" runat="server" CommandName="edit_tenaga_ahli">Edit</asp:LinkButton>&nbsp;
										<asp:LinkButton id="delete_tenaga_ahli" runat="server" CommandName="delete_tenaga_ahli">Hapus</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				<TR>
					<TD style="HEIGHT: 20px" vAlign="top" width="100%" colSpan="2"><asp:label id="TXT_SEQ" Runat="server" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Nama</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA_TA" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Jabatan</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JABATAN_TA" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Sertifikasi</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SERTIFIKASI" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table14" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Gelar</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_GELAR_TA" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Asosiasi Profesi</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ASOSIASI_PROFESI" runat="server" MaxLength="50"
										Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 276px">Pengalaman</TD>
								<TD style="WIDTH: 10px; HEIGHT: 23px"></TD>
								<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PENGALAMAN_TA" runat="server" MaxLength="50"
										Width="300px" TextMode="MultiLine" Height="50px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT_TA" runat="server" Text="Tambah" CssClass="button1"></asp:button><asp:button id="BTN_Clear_TA" runat="server" Text="Hapus" CssClass="button1"></asp:button></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
