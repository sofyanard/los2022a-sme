<%@ Control Language="c#" AutoEventWireup="True" Codebehind="NotaExport.ascx.cs" Inherits="SME.CEA.CommonForm.NotaExport" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
	<TR>
		<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Document Export</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 540px" vAlign="top" width="540">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Format</TD>
					<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
					<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:dropdownlist id="DDL_FORMAT_TYPE" Width="280px" runat="server"></asp:dropdownlist><asp:button id="BTN_EXPORT" Width="64px" runat="server" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
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
					<TD><ASP:DATAGRID id="DATA_EXPORT" Width="100%" runat="server" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="REGNUM"></asp:BoundColumn>
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
