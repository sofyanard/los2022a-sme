<%@ Page language="c#" Codebehind="Collateral_Dep.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.Collateral_Dep" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Collateral_Dep</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../../include/cek_all.html" -->
		<!-- #include  file="../../../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 482px">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PROFIL RESIKO</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" CausesValidation="False"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">General Info</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Nasabah</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_NASABAH" runat="server" BorderStyle="None" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama AO</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_AO" runat="server" BorderStyle="None" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kanwil</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KANWIL" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kanca</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KANCA" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Uker</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_UKER" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Status Permohonan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_STATUS_PERMOHONAN" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sumber Aplikasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_INTERNAL" runat="server" Text="Internal"></asp:checkbox><asp:checkbox id="CHK_EXTERNAL" runat="server" Text="Eksternal"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_STATUS1" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_STATUS2" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_STATUS3" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="btn_save" runat="server" Text="Insert" CssClass="button1"></asp:button><asp:button id="BTN_FINISH" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Penghasilan Nasabah</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Sumber</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SUMBER" runat="server" BorderStyle="None" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Pekerjaan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JENISPEKERJAAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Pekerjaan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BIDANGPEKERJAAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub Bidang</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SUBBIDANGPEKERJAAN" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Nama Tempat kerja</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMATEMPATKERJA" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan Lain</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KETERANGANLAIN" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Lama Bekerja</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_LAMABEKERJA" runat="server" Width="56px"></asp:textbox><asp:dropdownlist id="DDL_LAMABEKERJA" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox7" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button1" runat="server" Text="Insert" CssClass="button1"></asp:button><asp:button id="Button2" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Struktur Kredit</TD>
					</TR>
					<tr>
						<td colSpan="2"><ASP:DATAGRID id="DG_STRUKTUR" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="NOREK" HeaderText="No. Rekening">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTCODE" HeaderText="Kode Produk">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OUTSTANDING" HeaderText="Outstanding">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JANGKAWAKTU" HeaderText="Jangka Waktu">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KOLEKTIBILITAS" HeaderText="Kolektabilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SKIM" Visible="False" HeaderText="05"></asp:BoundColumn>
									<asp:BoundColumn DataField="TUJUAN" Visible="False" HeaderText="06"></asp:BoundColumn>
									<asp:BoundColumn DataField="PKS" Visible="False" HeaderText="07"></asp:BoundColumn>
									<asp:BoundColumn DataField="NAMAPROYEK" Visible="False" HeaderText="08"></asp:BoundColumn>
									<asp:BoundColumn DataField="DEVELOPER" Visible="False" HeaderText="09"></asp:BoundColumn>
									<asp:BoundColumn DataField="BUYBACKGRNTY" Visible="False" HeaderText="10"></asp:BoundColumn>
									<asp:BoundColumn DataField="PLAFOND" Visible="False" HeaderText="11"></asp:BoundColumn>
									<asp:BoundColumn DataField="DRAWDOWN" Visible="False" HeaderText="12"></asp:BoundColumn>
									<asp:BoundColumn DataField="DRAWDOWNDATE" Visible="False" HeaderText="13"></asp:BoundColumn>
									<asp:BoundColumn DataField="JANGKAWAKTU_CODE" Visible="False" HeaderText="14"></asp:BoundColumn>
									<asp:BoundColumn DataField="PEMRAKARSA" Visible="False" HeaderText="15"></asp:BoundColumn>
									<asp:BoundColumn DataField="PEMUTUS" Visible="False" HeaderText="16"></asp:BoundColumn>
									<asp:BoundColumn DataField="ADK" Visible="False" HeaderText="17"></asp:BoundColumn>
									<asp:BoundColumn DataField="ASJW" Visible="False" HeaderText="18"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></td>
					</tr>
					<TR>
						<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Skim</TD>
									<TD style="WIDTH: 15px; HEIGHT: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_SKIM" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TUJUAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Type</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_PKS" runat="server" Text="PKS"></asp:checkbox><asp:checkbox id="CHK_NONPKS" runat="server" Text="Non PKS"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Proyek</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMAPROYEK" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Developer</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DEVELOPER" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Buy back Guarantee</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUYBACKGRNTY" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Plafond</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PLAFOND" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">O/S</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OUTSTANDING" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Drawdown</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_DRAWDOWN" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Drawdown Date</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DRAWDOWNDATE_DAY" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_DRAWDOWNDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DRAWDOWNDATE_YEAR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JANGKAWAKTU" runat="server" Width="56px"></asp:textbox><asp:dropdownlist id="DDL_JANGKAWAKTU_CODE" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kolektibilitas</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KOLEKTIBILITAS" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pemakarsa</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PEMRAKARSA" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pemutus</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PEMUTUS" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">ADK</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADK" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Asuransi Jiwa</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_ASJWYA" runat="server" Text="Ya"></asp:checkbox><asp:checkbox id="CHK_ASJWTDK" runat="server" Text="Tidak"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button3" runat="server" Text="Save" CssClass="button1"></asp:button><asp:button id="Button4" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Agunan
						</TD>
					</TR>
					<tr>
						<td colSpan="2"><ASP:DATAGRID id="DG_AGUNAN" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AGUNANID" HeaderText="No. Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JENISAGUNAN" HeaderText="Jenis Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUSAGUNAN" HeaderText="Status Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ATASNAMA" HeaderText="Atas Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUSDOC" HeaderText="Status Document">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></td>
					</tr>
					<TR>
						<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">No. Agunan</TD>
									<TD style="WIDTH: 15px; HEIGHT: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox id="TXT_NOAGUNAN" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Lokasi Agunan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_LOKASIAGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat Agunan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMATAGUNAN1" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMATAGUNAN2" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Marketibility Agunan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_MARKETABLAGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Agunan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_STATUSAGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Doc. Kepemilikan</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_DOCAGUNAN" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Atas Nama</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox20" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Hubungan dgn Debitur</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox28" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Jabatan Penilai Awal</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox21" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Penilai Awal&nbsp;</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox22" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP Awal</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox23" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NL Awal</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox24" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jabatan Penilai Ulang</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox25" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai&nbsp;Penilai Ulang</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox26" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP Ulang</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox27" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NL Ulang</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox29" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Asuransi kerugian</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:checkbox id="Checkbox9" runat="server" Text="Internal"></asp:checkbox><asp:checkbox id="Checkbox10" runat="server" Text="Eksternal"></asp:checkbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button5" runat="server" Text="Save" CssClass="button1"></asp:button><asp:button id="Button6" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Data Macet</TD>
					</TR>
					<tr>
						<td colSpan="2"><ASP:DATAGRID id="DG_MACET" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="NOREK" HeaderText="No. Rekening">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TGLNPL" HeaderText="Tgl. NPL">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SEBABMACET" HeaderText="Penyebab Macet">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TARGETDATE" HeaderText="Target Penyelesaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REALSELESAI" HeaderText="Realisasi Penyelesaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton3" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Linkbutton4" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></td>
					</tr>
					<TR>
						<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Tanggal NPL</TD>
									<TD style="WIDTH: 15px; HEIGHT: 15px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox onkeypress="return numbersonly()" id="Textbox42" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="Dropdownlist16" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox41" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penyebab Macet</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:checkbox id="Checkbox7" runat="server" Text="Internal"></asp:checkbox><asp:checkbox id="Checkbox8" runat="server" Text="Eksternal"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Upaya Penyelesaian</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox43" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Rencana Tindak Lanjut</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox14" runat="server" Width="300px" R></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Target penyelesaian</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="Textbox44" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="Dropdownlist17" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox34" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status Kolektibilitas</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="Dropdownlist19" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Realisasi&nbsp;penyelesaian</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="Textbox46" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="Dropdownlist22" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="Textbox45" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan penyelesaian</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="Textbox38" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="Button7" runat="server" Text="Save" CssClass="button1"></asp:button><asp:button id="Button8" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Info Lain</TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:textbox id="Textbox31" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"></TD>
					</tr>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
