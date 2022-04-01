<%@ Page language="c#" Codebehind="ListScoring.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.ListScoring" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>List Scoring</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="fListSppk" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 44px" align="center"><TABLE id="Table3" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD>
										<TABLE id="Table2">
											<TR>
												<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Scoring List</B></TD>
											</TR>
										</TABLE>
									</TD>
									<TD align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
								</TR>
							</TABLE>
							<A href="../Body.aspx"></A>
							<TABLE class="td" id="Table5" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Kriteria Pencarian</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox id="txt_Name" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Aplikasi</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox id="txt_ProsID" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox id="txt_IdCard" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD style="WIDTH: 342px"><asp:textbox id="txt_NPWP" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD style="WIDTH: 400px; HEIGHT: 18px">
													<P class="TDBGColorValue">
														<asp:textbox id="txt_Date" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="2"></asp:textbox>
														<asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="4"></asp:textbox>&nbsp;s/d
														<asp:textbox id="txt_Date1" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="2"></asp:textbox>
														<asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year1" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="4"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" vAlign="middle">Kondisi</TD>
												<TD vAlign="middle"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" vAlign="top"><asp:radiobuttonlist id="RDB_COND" runat="server" Height="24px" CellSpacing="0" RepeatDirection="Horizontal"
														CellPadding="0" Width="208px">
														<asp:ListItem Value="And">Dan</asp:ListItem>
														<asp:ListItem Value="Or" Selected="True">Atau</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3"><asp:button id="btn_Find" 
                                                        runat="server" Text="Cari" Width="75px" CssClass="button1" 
                                                        onclick="btn_Find_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<A href="../Logout.aspx" target="_top"></A>
						</td>
					</tr>
					<TR>
						<TD style="HEIGHT: 2px">
							<asp:Label id="LBL_COUNT_APP" runat="server" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:textbox id="txt_regno" runat="server" Columns="30" MaxLength="20" Width="176px" Visible="False"></asp:textbox>
                            <asp:button id="btn_cari" runat="server" Text="Cari" Visible="False" 
                                onclick="btn_cari_Click"></asp:button><asp:label id="LBL_SQLFIND" runat="server" Visible="False"></asp:label>
							<asp:Label id="LBL_TC" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_MC" runat="server" Visible="False"></asp:Label></TD>
					</TR>
					<tr>
						<td style="WIDTH: 50%"><asp:datagrid id="dgListScoring" runat="server" CellPadding="1" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Cu_Ref"></asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SU_FULLNAME" HeaderText="Nama Analis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tgl. Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="VIEW">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="LIMITEXPOSURE" HeaderText="LIMITEXPOSURE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SCR_LINK" HeaderText="SCR_LINK"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AP_CA" HeaderText="AP_CA"></asp:BoundColumn>
								</Columns>
							</asp:datagrid></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
