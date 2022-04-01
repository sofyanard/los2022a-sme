<%@ Page language="c#" Codebehind="ListLegal.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.ListLegal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListLegal</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" align="left" colSpan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD align="left">
										<TABLE id="Table6" style="HEIGHT: 25px">
											<TR>
												<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><B>Legal Signing List</B></B></TD>
											</TR>
										</TABLE>
									</TD>
									<TD align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" align="center">
					<TR>
						<TD align="center" width="100%">
							<TABLE class="td" id="Table3" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Kriteria Pencarian</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342">
													<asp:textbox onkeypress="return kutip_satu()" id="txt_Name" runat="server" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Application No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px">
													<asp:textbox onkeypress="return kutip_satu()" id="txt_ProsID" runat="server" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px">
													<asp:textbox onkeypress="return kutip_satu()" id="txt_IdCard" runat="server" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD style="WIDTH: 342px">
													<asp:textbox onkeypress="return kutip_satu()" id="txt_NPWP" runat="server" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD style="WIDTH: 400px; HEIGHT: 18px">
													<P class="TDBGColorValue">
														<asp:textbox id="txt_Date" runat="server" Columns="3" MaxLength="2" onkeypress="return numbersonly();"></asp:textbox>
														<asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year" runat="server" Columns="3" MaxLength="4" onkeypress="return numbersonly();"></asp:textbox>&nbsp;s/d
														<asp:textbox id="txt_Date1" runat="server" Columns="3" MaxLength="2" onkeypress="return numbersonly();"></asp:textbox>
														<asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year1" runat="server" Columns="3" MaxLength="4" onkeypress="return numbersonly();"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" vAlign="middle">Kondisi</TD>
												<TD vAlign="middle"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" vAlign="top">
													<asp:radiobuttonlist id="RDB_COND" runat="server" Width="208px" CellPadding="0" Height="24px" CellSpacing="0"
														RepeatDirection="Horizontal">
														<asp:ListItem Value="And">Dan</asp:ListItem>
														<asp:ListItem Value="Or" Selected="True">Atau</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3">
													<asp:button id="btn_Find" runat="server" Text="Cari" Width="75px" 
                                                        CssClass="button1" onclick="btn_Find_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD width="100%" align="center">
							<asp:button id="Button1" runat="server" Text="F i n d" Visible="False"></asp:button>
							<asp:textbox id="TXT_AP_REGNO" runat="server" Visible="False"></asp:textbox>
							<asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label></TD>
					</TR>
					<tr>
						<td width="100%"><asp:datagrid id="DGR_LIST" Runat="server" AutoGenerateColumns="False" PageSize="15" CellPadding="1"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Reference #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_RM" HeaderText="Analis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tgl. Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn Visible="False">
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="undo">Undo</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_CO" HeaderText="AP_CO"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
