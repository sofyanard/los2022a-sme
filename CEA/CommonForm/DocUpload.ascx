<%@ Control Language="c#" AutoEventWireup="True" Codebehind="DocUpload.ascx.cs" Inherits="SME.CEA.CommonForm.DocUpload" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
	<TR>
		<TD class="tdHeader1" width="100%" colSpan="2">Document Upload</TD>
	</TR>
	<TR>
		<TD vAlign="top" width="50%">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD class="TDBGColor1" width="75">File</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="TXT_FILE_UPLOAD" runat="Server"></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1">Status</TD>
					<TD>:</TD>
					<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
							ControlToValidate="TXT_FILE_UPLOAD" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$"></asp:regularexpressionvalidator></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1"></TD>
					<TD></TD>
					<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:label id="LBL_SUMBERDATA" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3"><FONT color="#0000ff">Note : disarankan utk mempercepat 
							proses tidak meng-klik tulisan download, tp di klik kanan saja dari tulisan 
							download tersebut, kemudian pilih "save target as"...simpan di lokal komputer</FONT></TD>
				</TR>
			</table>
		</TD>
		<TD vAlign="top" width="50%" rowSpan="2">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><ASP:DATAGRID id="DG_UPLOAD" CellPadding="1" PageSize="5" AutoGenerateColumns="False" Width="100%"
							runat="server" AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="REGNUM"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="GROUPFILE"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="FU_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="FU_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="FU_URL" HeaderText="Download URL"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</table>
		</TD>
	</TR>
	<TR>
	</TR>
</TABLE>
