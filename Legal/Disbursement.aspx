<%@ Page language="c#" Codebehind="Disbursement.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.Disbursement" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="../CommonForm/DocumentExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Disbursement</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../SourceSMEReport/style.css" type="text/css" rel="stylesheet">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/onepost.html" -->
		<!-- #include  file="../include/ConfirmBox.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Legal Signing : 
											Disbursement</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2"><asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label><asp:label id="LBL_REGNO" Visible="False" Runat="server"></asp:label>Informasi 
							Pemohon</td>
					</tr>
					<tr>
						<td colSpan="2">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nomor Aplikasi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:label id="LBL_AP_REGNO" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Nomor Referensi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_CU_REF" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Aplikasi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_TGL" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_BRANCH_NAME" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Supervisi</td>
												<td style="HEIGHT: 22px"></td>
												<td class="TDBGColorValue" style="HEIGHT: 22px"><asp:label id="LBL_AP_TMLDRNM" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Analis</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_ANALIS" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Petugas</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_AP_RMNM" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Segmen</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_BISNIS_UNIT" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Pemohon</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:label id="LBL_CU_NAME" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1" style="HEIGHT: 40px">Alamat</td>
												<td style="HEIGHT: 40px"></td>
												<td class="TDBGColorValue" style="HEIGHT: 40px"><asp:label id="LBL_CU_ADDR1" runat="server"></asp:label><br>
													<asp:label id="LBL_CU_ADDR2" runat="server"></asp:label>&nbsp;<br>
													<asp:label id="LBL_CU_ADDR3" runat="server"></asp:label></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_CU_CITYNM" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Telp</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_CU_PHN" runat="server"></asp:label>&nbsp;</td>
											</tr>
											<tr>
												<td class="TDBGColor1">Bidang Usaha</td>
												<td></td>
												<td class="TDBGColorValue"><asp:label id="LBL_BUSSTYPEDESC" runat="server"></asp:label>&nbsp;</td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdheader1" colSpan="2">Fasilitas</TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:table id="oTable1" runat="server" Width="100%" CellPadding="0" CellSpacing="0">
								<asp:TableRow>
									<asp:TableCell Font-Bold="True" Text="Jenis Kredit" CssClass="HeaderReportList"></asp:TableCell>
									<asp:TableCell Font-Bold="True" Text="Jenis Pengajuan" CssClass="HeaderReportList"></asp:TableCell>
									<asp:TableCell Width="110px" Font-Bold="True" Text="Status" CssClass="HeaderReportList"></asp:TableCell>
								</asp:TableRow>
							</asp:table></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">
							<P align="center">Review Syarat Pencairan Kredit</P>
						</TD>
					</TR>
					<tr>
						<td style="HEIGHT: 63px" vAlign="top" colSpan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Syarat</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROSES" Runat="server" Width="750px" ReadOnly CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:RadioButtonList id="RDO_SY_ISLENGKAP" runat="server" Width="200px" RepeatDirection="Horizontal"
											AutoPostBack="True" onselectedindexchanged="RDO_SY_ISLENGKAP_SelectedIndexChanged">
											<asp:ListItem Value="1" Selected="True">Lengkap</asp:ListItem>
											<asp:ListItem Value="0">Tidak Lengkap</asp:ListItem>
										</asp:RadioButtonList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Dipenuhi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL" Runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN" Runat="server" ReadOnly></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN" Runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KET" Runat="server" Width="512px" Columns="35"
											TextMode="MultiLine" Height="54px"></asp:textbox>&nbsp;</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="tdBGCOlor2" colSpan="2"><asp:button id="BTN_DF_INPUT" Runat="server" 
                                Width="80px" CssClass="button1" Text="Simpan" onclick="BTN_DF_INPUT_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE" Runat="server" CssClass="button1" 
                                Text="Update Status" Enabled="False"></asp:button>&nbsp;
							<asp:button id="BTN_PRINT" Runat="server" Width="80px" CssClass="button1" 
                                Text="Cetak" onclick="BTN_PRINT_Click"></asp:button></TD>
					</TR>
                    <TR bgcolor="red" align="center">
						<TD colSpan="2">
							<STRONG style="COLOR: #ffffff">Sebelum melakukan update status, pastikan Anda telah mencetak Worksheet 
								untuk kelengkapan input data di Core Sistem </STRONG>
						</TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2"><asp:datagrid id="DGR_LIST" Runat="server" Width="100%" PageSize="1" AutoGenerateColumns="False"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="des" HeaderText="Syarat">
										<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_accdate" HeaderText="Tanggal Dipenuhi">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_ket" HeaderText="Keterangan">
										<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_islengkap" HeaderText="Status">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="60px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">hapus</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
                    <TR>
						<TD align="center" colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
