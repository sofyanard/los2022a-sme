<%@ Page language="c#" Codebehind="AssigmentPIC.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.AssigmentPIC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssigmentPIC</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="590" border="1" style="WIDTH: 590px; HEIGHT: 200px">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
												<TD width="17"></TD>
												<TD width="342" class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_Name" runat="server" MaxLength="50" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Application No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_ProsID" runat="server" MaxLength="20" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_IdCard" runat="server" MaxLength="30" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD style="WIDTH: 342px">
													<asp:textbox onkeypress="return kutip_satu()" id="txt_NPWP" runat="server" MaxLength="25" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD style="WIDTH: 400px; HEIGHT: 18px">
													<P class="TDBGColorValue"><asp:textbox id="txt_Date" runat="server" onkeypress="return digitsonly()" Columns="3" MaxLength="2"></asp:textbox>
														<asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year" runat="server" Columns="3" onkeypress="return digitsonly()" MaxLength="4"></asp:textbox>&nbsp;s/d
														<asp:textbox id="txt_Date1" runat="server" MaxLength="2" onkeypress="return digitsonly()" Columns="3"></asp:textbox>
														<asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year1" runat="server" MaxLength="4" onkeypress="return digitsonly()" Columns="3"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" vAlign="middle">Condition</TD>
												<TD vAlign="middle"></TD>
												<TD vAlign="top" class="TDBGColorValue" style="WIDTH: 342px"><asp:radiobuttonlist id="RDB_COND" runat="server" RepeatDirection="Horizontal" CellSpacing="0" Height="24px"
														CellPadding="0" Width="208px">
														<asp:ListItem Value="And">And</asp:ListItem>
														<asp:ListItem Value="Or" Selected="True">Or</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" style="WIDTH: 521px"><asp:button id="btn_Find" runat="server" Text="Find" Width="75px" CssClass="button1"></asp:button>
													<asp:Label id="Label2" runat="server" Visible="False"></asp:Label>
													<asp:Label id="LBL_H_GRPUNIT" runat="server" Visible="False"></asp:Label>
													<asp:Label id="LBL_H_BUSUNIT" runat="server" Visible="False"></asp:Label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" Width="100%" PageSize="50" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Visible="False"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
					</tr>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
