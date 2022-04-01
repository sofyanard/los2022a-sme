<%@ Page language="c#" Codebehind="InquiryDataAll.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.Facilities.InquiryDataDictionary.InquiryDataAll" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataCIFIn</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><asp:label id="LBL_PAGE" runat="server">Label</asp:label></B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../../../image/Back.jpg"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="../../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A>
						</TD>
					</tr>
					<TR id="TR_MENU" runat="server">
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_PAGE_2ND" runat="server">Label</asp:label></TD>
					</TR>
					<tr>
						<td colSpan="2"></td>
					</tr>
					<TR>
						<td colSpan="2">
							<table width="100%">
								<tr>
									<TD>
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="80%">
											<TR width="100%">
												<TD class="TDBGColor1" width="15%">Field Name</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_NO_CIF" runat="server" Width="100%"></asp:textbox></TD>
												<TD width="25%"><asp:button id="BTN_SRCHFIELDNAME" Width="100%" Text="Find" CssClass="BUTTON1" Runat="server"></asp:button></TD>
											</TR>
											<tr>
												<td colSpan="4"><asp:dropdownlist id="DropDownList1" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged"></asp:dropdownlist></td>
											</tr>
										</TABLE>
									</TD>
									<td>
										<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="80%">
											<TR width="100%">
												<TD class="TDBGColor1" width="15%">Description</TD>
												<TD>:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="Textbox1" runat="server" Width="100%"></asp:textbox></TD>
												<TD width="25%"><asp:button id="BTN_SRCHDESC" Width="100%" Text="Find" CssClass="BUTTON1" Runat="server"></asp:button></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</table>
						</td>
					</TR>
					<TR>
						<TD colSpan="2">
							<ASP:DATAGRID id="DGR_INQUIRY" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="NUMBER" HeaderText="NO">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELDS_NAME" HeaderText="FIELDS NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTIONS" HeaderText="DESCRIPTION">
										<HeaderStyle Width="500px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="50%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="CHECK FOR SELECT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="edit_cab" runat="server" AutoPostBack="True"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2"><asp:label id="LBL_DOCUMENT" runat="server">Label</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">Format</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="70%" AutoPostBack="True"></asp:dropdownlist><asp:button id="BTN_EXPORT" runat="server" Width="25%" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
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
							</TABLE>
						</TD>
						<TD vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
											PageSize="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
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
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="FE_URL" HeaderText="File Name" Visible="False">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
