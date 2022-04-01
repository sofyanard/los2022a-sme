<%@ Page language="c#" Codebehind="Notaris.aspx.cs" AutoEventWireup="false" Inherits="dbrbm.Data_Entry.Notaris" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Notaris</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center><asp:button id="BTN_save_org" style="Z-INDEX: 100; LEFT: 440px; POSITION: absolute; TOP: 208px"
					runat="server" Width="75px" CssClass="button1" Text="Save"></asp:button><asp:button id="BTN_clear2_org" style="Z-INDEX: 104; LEFT: 520px; POSITION: absolute; TOP: 576px"
					runat="server" Width="75px" CssClass="button1" Text="Clear"></asp:button><asp:button id="BTN_insert_org" style="Z-INDEX: 103; LEFT: 440px; POSITION: absolute; TOP: 576px"
					runat="server" Width="75px" CssClass="button1" Text="Insert"></asp:button>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder">
								<TABLE id="Table8">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Struktur Organisasi</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" NavigateUrl="CustomerInfo.aspx" Visible="False">Info Rekanan</asp:hyperlink><asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="DTBO\ListDTBO.aspx" Visible="False"> Perijinan</asp:hyperlink><asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="InfoPerusahaan.aspx" Visible="False">Data Perusahaan</asp:hyperlink><asp:hyperlink id="Hyperlink4" runat="server" NavigateUrl="TenagaAhli.aspx" Visible="False">Struktur Organisasi</asp:hyperlink><asp:hyperlink id="HL_HISTORY" runat="server" NavigateUrl="CustHistory.aspx" Visible="False"> Notaris</asp:hyperlink></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Data Struktur Organisasi</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 23px">Status Kantor</TD>
										<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_status_org" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 22px">Jumlah Cabang</TD>
										<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_cabang_org" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 12px">Total Pegawai Tetap</TD>
										<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_tetap_org" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
									<!-- Additional Field : Right --></TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">Total Pegawai Tidak Tetap</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_tdktetap_org" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jumlah Agen</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_agen_org" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<tr>
						</tr>
						<TR>
						<tr>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">Tenaga Ahli</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DatGridPengurus" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
									CellPadding="1" DESIGNTIMEDRAGDROP="33">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="no_registrasi" HeaderText="noreg"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NAME" HeaderText="No">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NAME" HeaderText="Nama">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CS_IDCARDNUM" HeaderText="Gelar">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="CS_NPWP" HeaderText="Pengalaman">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
												<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</ASP:DATAGRID><BR>
								<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TBODY>
									</TBODY>
								</TABLE>
								<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TBODY>
										<TR>
											<TD style="HEIGHT: 43px" vAlign="top" width="50%" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="td" vAlign="top" width="50%">
												<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD class="TDBGColor1" id="TXT_nama_TA" style="WIDTH: 276px">Nama</TD>
														<TD></TD>
														<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_nama_TA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="TDBGColor1" style="WIDTH: 276px">Jabatan</TD>
														<TD></TD>
														<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_jabatan_TA" runat="server" Width="300px"
																MaxLength="50"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="td" vAlign="top" align="center">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD class="TDBGColor1" style="WIDTH: 262px" width="262">Gelar</TD>
														<TD style="WIDTH: 20px"></TD>
														<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_Gelar_TA" runat="server" Width="300px"
																MaxLength="50"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="TDBGColor1" style="WIDTH: 262px" width="262">Pengalaman</TD>
														<TD style="WIDTH: 20px"></TD>
														<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_pengalaman_TA" runat="server" Width="300px"
																MaxLength="50"></asp:textbox></TD>
													</TR>
												</TABLE>
												<CENTER></CENTER>
												<asp:button id="BTN_CLEAR_org" style="Z-INDEX: 101; LEFT: 520px; POSITION: absolute; TOP: 208px"
													runat="server" Width="75px" CssClass="button1" Text="Clear"></asp:button>
		</form>
		</TD></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</TD></TR></TBODY></TABLE></CENTER>
	</body>
</HTML>
