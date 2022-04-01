<%@ Page language="c#" Codebehind="CustInteraction.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.CustInteraction" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CustInteraction</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" width="421"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer Interaction</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="500" border="1">
								<TR>
									<TD class="tdHeader1" colSpan="2">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="2">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="197">Nomor Aplikasi</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_APPNO" runat="server" MaxLength="20" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197" height="20">Nama</TD>
												<TD width="9" height="20"></TD>
												<TD class="TDBGColorValue" width="342" height="20"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAME" runat="server" MaxLength="50" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" height="20">Tipe Pelanggan</TD>
												<TD width="9" height="20"></TD>
												<TD class="TDBGColorValue" height="20"><asp:radiobuttonlist id="RB_PELANGGAN" runat="server" AutoPostBack="True" RepeatLayout="Flow" RepeatDirection="Horizontal">
														<asp:ListItem Value="0" Selected="True">Personal</asp:ListItem>
														<asp:ListItem Value="1">Company</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197">CIF</TD>
												<TD width="9"></TD>
												<TD class="TDBGColorValue" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CIF" runat="server" MaxLength="20" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="197">Nomor ID</TD>
												<TD width="9"></TD>
												<TD class="TDBGColorValue" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_IDNUMBER" runat="server" MaxLength="30"
														Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 24px" width="197">NPWP</TD>
												<TD style="HEIGHT: 24px" width="9"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 24px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NPWP" runat="server" MaxLength="25" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_FIND" runat="server" Text="Find" Width="75px" CssClass="button1" onclick="BTN_FIND_Click"></asp:button>&nbsp;
													<asp:button id="BTN_CLEAR" runat="server" Text="Clear" Width="75px" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
					<tr>
						<td colSpan="2"><asp:datagrid id="DGR_LIST" CellPadding="1" Width="100%" PageSize="1" AutoGenerateColumns="False"
								Runat="server">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_CIF" HeaderText="CIF">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAMA" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="Tgl. Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="cu_npwp" HeaderText="npwp"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
