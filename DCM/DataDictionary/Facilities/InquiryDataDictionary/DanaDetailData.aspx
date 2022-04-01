<%@ Page language="c#" Codebehind="DanaDetailData.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.Facilities.InquiryDataDictionary.DanaDetailData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DanaDetailData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="form1" method="post" runat="server">
			<!-- <center> -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>DANA PIHAK KETIGA LIST 
										DATA</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td><asp:Label ID="LBL_TEMPLATE" Runat="server" Visible="False"></asp:Label></td>
				</tr>
				<TR>
					<TD class="tdHeader1" colSpan="2">DANA DETAIL DATA</TD>
				</TR>
				<TR id="TR_FIND" runat="server">
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Field Name :</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:textbox id="TXT_FIELD_NAME" runat="server" MaxLength="15" Width="200px"></asp:textbox></TD>
								<td><asp:button id="BTN_SEARCH_FIELD" Runat="server" Text="Search" onclick="BTN_SEARCH_FIELD_Click"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Description :</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:textbox id="TXT_DESC" runat="server" MaxLength="15" Width="200px"></asp:textbox></TD>
								<td><asp:button id="BTN_SEARCH_DESC" Runat="server" Text="Search" onclick="BTN_SEARCH_DESC_Click"></asp:button></td>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NO" DataField="CODE">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="FIELDS NAME" DataField="FIELDSNAME">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="DESCRIPTION" DataField="FIELDSDESCRIPTION">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">DATA DICTIONARY DOCUMENT 
						EXPORT</TD>
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
			</TABLE>
		</form>
	</body>
</HTML>
