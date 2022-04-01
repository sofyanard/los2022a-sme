<%@ Page language="c#" Codebehind="CompanyLegal.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.CompanyLegal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Company Legal</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 371px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Detail Data Entry : 
											Legalitas Perusahaan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Legalitas Perusahaan</TD>
					</TR>
					<TR runat="server">
						<TD class="td" vAlign="top" width="45%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px" align="right" width="165">Aspek 
										Legalitas</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:radiobutton id="RDO_CI_ISCOMPLETE1" runat="server" GroupName="RDG_CI_ISCOMPLETE" Text="Lengkap"></asp:radiobutton>&nbsp;
										<asp:radiobutton id="RDO_CI_ISCOMPLETE0" runat="server" GroupName="RDG_CI_ISCOMPLETE" Text="Tidak"></asp:radiobutton></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px">Akte Pendirian No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_CERTNO" runat="server" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px">Tanggal Akte</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_CERTDATE_DAY" runat="server" MaxLength="2" Columns="4" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_CI_CERTDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CI_CERTDATE_YEAR" runat="server" MaxLength="4" Columns="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px">Nama Notaris</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_NOTARY" runat="server" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px">Pengesahan Dr MenKeh No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CI_MKAPPRV" runat="server" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 165px">Tanggal Pengesahan</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CI_MKAPPRVDATE_DAY" runat="server" MaxLength="2" Columns="4" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_CI_MKAPPRVDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CI_MKAPPRVDATE_YEAR" runat="server" MaxLength="4" Columns="4" Width="36px"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
						<TD class="td" vAlign="top" width="55%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 228px" width="228">No. Pendaftaran di 
										Pengadilan Negeri / Pengumuman di Lembaran Berita Negara (dalam hal PT.)</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_PNREGNO" runat="server" MaxLength="20"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 228px; HEIGHT: 22px" width="228">Tanggal 
										Pendaftaran</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox id="TXT_CI_PNREGDATE_DAY" runat="server" MaxLength="2" Columns="4" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_CI_PNREGDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CI_PNREGDATE_YEAR" runat="server" MaxLength="4" Columns="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 228px; HEIGHT: 16px" width="228">Akte 
										Perubahan terakhir</TD>
									<TD style="WIDTH: 15px; HEIGHT: 16px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:textbox id="TXT_CI_CERTMOD" runat="server" MaxLength="50"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 228px" width="228">Tanggal Perubahan&nbsp;Akte</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_CERTMODDATE_DAY" runat="server" MaxLength="2" Columns="4" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_CI_CERTMODDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CI_CERTMODDATE_YEAR" runat="server" MaxLength="4" Columns="4" Width="36px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 228px" width="228">Nama Notaris</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_MODNOTARY" runat="server" MaxLength="100"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" align="center" colSpan="2">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td align="center"><STRONG>Legallitas Usaha</STRONG>
									</td>
								</tr>
								<TR>
									<TD align="center"><ASP:DATAGRID id="DatGridLegal" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_CERTTYPE" HeaderText="CL_CERTTYPE">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CERTTYPEDESC" HeaderText="Jenis Surat">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_CERTNO" HeaderText="No.">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_CERTDATE" HeaderText="Tanggal">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_ATASNAMA" HeaderText="Atas Nama">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
								<TR>
									<TD align="center"></TD>
								</TR>
							</TABLE>
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="80%">
								<tr>
									<td width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="111" style="WIDTH: 111px">Jenis Surat</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:dropdownlist id="DDL_CL_CERTTYPE" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 111px">No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CL_CERTNO" runat="server" MaxLength="50"></asp:textbox></TD>
											</TR>
										</table>
									</td>
									<td width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="111" style="WIDTH: 111px">Tanggal</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CL_CERTDATE_DAY" runat="server" MaxLength="2" Columns="4" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_CL_CERTDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CL_CERTDATE_YEAR" runat="server" MaxLength="4" Columns="4" Width="36px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 111px">Atas Nama</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CL_ATASNAMA" runat="server" MaxLength="100"></asp:textbox></TD>
											</TR>
										</table>
									</td>
								</tr>
								<TR>
									<TD align="center" colspan="2"><asp:button id="BTN_INSERT" runat="server" Text="Insert" Width="75px" CssClass="button1" onclick="BTN_INSERT_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" align="center" colSpan="2">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td><STRONG>Batasan kekuasaan Direksi (dalam hal PT./CV.) telah memiliki surat 
											persetujuan / ijin meminjam uang dari komisaris / persero komanditer</STRONG>
									</td>
								</tr>
								<TR>
									<TD>
										<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="1">
											<TR>
												<TD class="TDBGColor1" width="75">No.</TD>
												<TD width="15"></TD>
												<TD><asp:textbox id="TXT_CI_AGREEMNTNO" runat="server" MaxLength="50"></asp:textbox></TD>
												<TD class="TDBGColor1" width="75">Tanggal</TD>
												<TD width="15"></TD>
												<TD><asp:textbox id="TXT_CI_AGREEMNTDATE_DAY" runat="server" MaxLength="2" Columns="4" Width="24px"></asp:textbox><asp:dropdownlist id="DDL_CI_AGREEMNTDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CI_AGREEMNTDATE_YEAR" runat="server" MaxLength="4" Columns="4" Width="36px"></asp:textbox></TD>
												<TD class="TDBGColor1" width="75">Status</TD>
												<TD width="15"></TD>
												<TD><asp:radiobutton id="RDO_CI_AGREEMNTSTA0" runat="server" GroupName="CI_AGREEMNTSTA" Text="Valid"></asp:radiobutton><asp:radiobutton id="RDO_CI_AGREEMNTSTA1" runat="server" GroupName="CI_AGREEMNTSTA" Text="Expired "></asp:radiobutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Save" Width="100px" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
