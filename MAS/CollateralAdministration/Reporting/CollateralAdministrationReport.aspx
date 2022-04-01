<%@ Page language="c#" Codebehind="CollateralAdministrationReport.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.Reporting.CollateralAdministrationReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralAdministrationReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Collateral Administration 
											Reporting</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="PH_SUBMENU" runat="server"></asp:placeholder></TD>
					</tr>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 124px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 151px">Periode Booking</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" MaxLength="4" Columns="4"></asp:textbox>&nbsp; 
													to &nbsp;
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 151px; HEIGHT: 13px">Distrik</TD>
												<TD style="HEIGHT: 13px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 13px"><asp:dropdownlist id="DDL_DISTRIK" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_DISTRIK_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 151px; HEIGHT: 20px">Cluster</TD>
												<TD style="HEIGHT: 20px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_CLUSTER" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CLUSTER_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 151px">Unit</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_UNIT" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
										<asp:button id="BTN_CLEAR" runat="server" Width="109px" Text="CLEAR" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">GENERATE REPORT</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Format</TD>
									<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="280px"></asp:dropdownlist><asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" HeaderText="regnum"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="TEMPLATE_ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FE_USERID"></asp:BoundColumn>
												<asp:BoundColumn DataField="FE_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="FE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="FE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FE_URL" HeaderText="Download URL"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
