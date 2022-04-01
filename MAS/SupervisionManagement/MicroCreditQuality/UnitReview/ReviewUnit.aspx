<%@ Page language="c#" Codebehind="ReviewUnit.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.MicroCreditQuality.UnitReview.ReviewUnit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReviewUnit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>REVIEW UNIT</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">District</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DISTRICT" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Cluster</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CLUSTER" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Unit / Cabang</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_UNIT_CABANG" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Tahun Pembukaan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_THN_PEMBUKAAN" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Jumlah Sales Outlet</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JUM_SO" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Tgl. Kunjungan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KUNJUNGAN1" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_KUNJUNGAN1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KUNJUNGAN1" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox>&nbsp;to&nbsp;
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_KUNJUNGAN2" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_KUNJUNGAN2" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_KUNJUNGAN2" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">DETAIL INFORMATION</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" width="18%">Nama Sales Outlet</TD>
									<TD width="1%">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO1" runat="server" MaxLength="100" Width="230px"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO2" runat="server" MaxLength="100" Width="230px"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO3" runat="server" MaxLength="100" Width="230px"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_SO4" runat="server" MaxLength="100" Width="230px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="5">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" vAlign="middle" width="18%">Lokasi SO (Jarak dari MBU)</TD>
									<TD width="1%">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO1" runat="server" Width="230px" AutoPostBack="True" RepeatDirection="Vertical">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO2" runat="server" Width="230px" AutoPostBack="True" RepeatDirection="Vertical">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO3" runat="server" Width="230px" AutoPostBack="True" RepeatDirection="Vertical">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 31px" align="left"><asp:radiobuttonlist id="RDO_LOKASI_SO4" runat="server" Width="230px" AutoPostBack="True" RepeatDirection="Vertical">
											<asp:ListItem Value="1">&lt;5 km</asp:ListItem>
											<asp:ListItem Value="2">5 s.d 10 km</asp:ListItem>
											<asp:ListItem Value="3">10 s.d 20 km</asp:ListItem>
											<asp:ListItem Value="5">&gt;20 km</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Daftar Pegawai Unit :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px" width="145">NIP</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NIP_PEGAWAI" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pegawai</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA_PEGAWAI" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jabatan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_JABATAN" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 262px; HEIGHT: 17px">Bergabung Sejak</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_BERGABUNG" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_BERGABUNG" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BERGABUNG" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Kepegawaian</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_STATUS_PEGAWAI" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Catatan</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CAT_PEGAWAI" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT_PEGAWAI_UNIT" runat="server" Width="75px" Text="INSERT" CssClass="Button1" onclick="BTN_INSERT_PEGAWAI_UNIT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_PEGAWAI_UNIT" runat="server" Width="75px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_PEGAWAI_UNIT_Click"></asp:button></td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_PEGAWAI" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="seq" DataField="seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="unit_seq" DataField="unit_seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="NIP" DataField="nip">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nama Pegawai" DataField="nama_pegawai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Jabatan" DataField="jabatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bergabung Sejak" DataField="bergabung_sejak">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Status Kepegawaian" DataField="status_kepegawaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Catatan" DataField="catatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="delete_data" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
											<asp:LinkButton id="retrieve_data" runat="server" CommandName="retrieve_data">Retrieve</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td><asp:label id="TXT_SEQ1" Visible="False" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Portfolio Kelolaan MKS :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px" width="145">NIP</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NIP_MKS" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pegawai</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA_PEGAWAI_MKS" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bergabung Sejak</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_BERGABUNG_MKS" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_BERGABUNG_MKS" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_BERGABUNG_MKS" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Kepegawaian</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_STATUS_KEPEGAWAIAN_MKS" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1">Bade Kelolaan (milyar)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BADE_KELOLAAN_MKS" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kol. Lancar (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KOL_LANCAR_MKS" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">DPD 30 + (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DPD_MKS" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPL (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NPL_MKS" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT_MKS" runat="server" Width="75px" Text="INSERT" CssClass="Button1" onclick="BTN_INSERT_MKS_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_MKS" runat="server" Width="75px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_MKS_Click"></asp:button></td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_MKS" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="seq" DataField="seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="unit_seq" DataField="unit_seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="NIP" DataField="nip">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Nama Pegawai" DataField="nama_pegawai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bergabung Sejak" DataField="bergabung_sejak">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Status Kepegawaian" DataField="status_kepegawaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Bade Kelolaan" DataField="bade_kelolaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Kol. Lancar" DataField="kol_lancar">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="DPD 30 +" DataField="dpd_30">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="NPL" DataField="npl">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td><asp:label id="TXT_SEQ2" Visible="False" Runat="server"></asp:label></td>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Portfolio Unit / Cabang per tanggal&nbsp;:</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1">Produk</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_PRODUK" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah Debitur</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_JUM_DEBITUR" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Baki Debet</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BAKI_DEBET" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kolektibilitas Lancar (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KOLEK_LANCAR" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">DPD 30+ (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DPD_PLUS" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1">NPL (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NPL_PERCENT" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">FR To X (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_FR_TO_X" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">FR To 30 (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_FR_TO_30" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">FR To 60 (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_FR_TO_60" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">FR To 90 (%)</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_FR_TO_90" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT_PORTFOLIO_UNIT" runat="server" Width="75px" Text="INSERT" CssClass="Button1" onclick="BTN_INSERT_PORTFOLIO_UNIT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_PORTFOLIO_UNIT" runat="server" Width="75px" Text="CLEAR" CssClass="Button1" onclick="BTN_CLEAR_PORTFOLIO_UNIT_Click"></asp:button></td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_POTFOLIO_UNIT" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="seq" DataField="seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="unit_seq" DataField="unit_seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Produk" DataField="produk">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Jumlah Debitur" DataField="jum_debitur">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Baki Debet" DataField="baki_debet">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Kolektibilitas Lancar (%)" DataField="kolek_lancar">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="DPD 30+ (%)" DataField="dpd_30_plus">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="NPL (%)" DataField="npl">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FR To X" DataField="fr_to_x">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FR To 30" DataField="fr_to_30">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FR To 60" DataField="fr_to_60">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="FR To 90" DataField="fr_to_90">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton3" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Linkbutton4" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td><asp:label id="TXT_SEQ3" Visible="False" Runat="server"></asp:label></td>
					</tr>
				</TABLE>
				<table>
					<tr>
						<TD class="td" vAlign="top" width="100%" colSpan="2">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Kualitas Supervisi / Monitoring MMM :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="3%">1.</TD>
									<TD width="82%">Buku Harian MKS dimiliki oleh seluruh MKS</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM1" runat="server" Width="100%" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">2.</TD>
									<TD width="82%">MMM melakukan monitoring harian penggunaan Buku Harian dengan 
										memberikan pada kolom paraf yang terdapat dalam Buku Harian MKS. (Pedoman 
										Penggunaan Buku Harian MKS dapat dilihat dalam Surat No. MRB.MBD/SSM.287/2011 
										tanggal 27 April 2011 Perihal Implementasi Buku Harian MKS dalam Rangka 4DP 
										Bisnis Mikro)
									</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM2" runat="server" Width="100%" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">3.</TD>
									<TD width="82%">Buku Kendali Agunan yang Diserahkan Debitur</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM3" runat="server" Width="100%" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">4.</TD>
									<TD width="82%">Buku Kendali Monitoring Pending Notaris</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM4" runat="server" Width="100%" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">5.</TD>
									<TD width="82%">Buku Kendali Monitoring Penerbitan Polis Asuransi</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM5" runat="server" Width="100%" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">6.</TD>
									<TD width="82%">Buku Kendali Pencairan Kredit</TD>
									<TD class="TDBGColorValue" align="left" width="15%"><asp:radiobuttonlist id="RDO_MMM6" runat="server" Width="100%" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
				</table>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%"><STRONG>Permasalahan yang Perlu Mendapatkan Perhatian :</STRONG></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="3%">1.</TD>
									<TD width="97%">Pemberian kredit yang terindikasi menyimpang dan melanggar 
										ketentuan code of conduct</TD>
								</TR>
								<TR>
									<TD align="center" width="3%"></TD>
									<TD width="97%"><asp:textbox id="TXT_PERMASALAHAN1" Width="100%" Runat="server" TextMode="MultiLine" Height="350px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">2.</TD>
									<TD width="97%">Informasi Lain Yang Perlu Mendapat Perhatian (DMTL)</TD>
								</TR>
								<TR>
									<TD align="center" width="3%"></TD>
									<TD width="97%"><asp:textbox id="TXT_PERMASALAHAN2" Width="100%" Runat="server" TextMode="MultiLine" Height="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD align="center" width="3%">3.</TD>
									<TD width="97%">Rekomendasi Perbaikan</TD>
								</TR>
								<TR>
									<TD align="center" width="3%"></TD>
									<TD width="97%"><asp:textbox id="TXT_PERMASALAHAN3" Width="100%" Runat="server" TextMode="MultiLine" Height="200px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="100%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD width="100%">Demikian Laporan Supervisi kami susun dengan sebenarnya 
										berdasarkan review on desk dan on site yang kami lakukan</TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<td></td>
					</tr>
				</table>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<TD class="td" vAlign="top" width="33%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%">Dibuat Oleh</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%">Diketahui Oleh</TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="34%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%">Diketahui Oleh</TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr>
						<TD class="td" vAlign="top" width="33%" colSpan="3">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIBUAT_OLEH" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="33%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIKETAHUI_OLEH1" runat="server" MaxLength="100"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="34%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD align="center" width="100%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DIKETAHUI_OLEH2" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="5"><asp:button id="BTN_SAVE" runat="server" Width="75px" Text="SAVE" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_PRINT" runat="server" Width="75px" Text="PRINT" CssClass="Button1" onclick="BTN_PRINT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_SEND" runat="server" Width="210px" Text="SEND TO CLUSTER/DISTRIK" CssClass="Button1" onclick="BTN_SEND_Click"></asp:button></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
