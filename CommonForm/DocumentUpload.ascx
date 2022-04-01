<%@ Control Language="c#" AutoEventWireup="True" Codebehind="DocumentUpload.ascx.cs" Inherits="SME.CommonForm.DocumentUpload" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
	<TR>
		<TD class="tdHeader1" width="100%" colSpan="2">Document Upload</TD>
	</TR>
	<TR>
		<TD vAlign="top" width="50%">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td><asp:datagrid id="DG_TEMPLATE" CellPadding="1" PageSize="1" AutoGenerateColumns="False" Width="100%"
							runat="server">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="SEQ" HeaderText="No">
									<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TEMPLATE_DESC" HeaderText="Source File">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="HP_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="TEMPLATE_FILENAME"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TEMPLATE_PATH"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TEMPLATE_URL"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
			</table>
		</TD>
		<TD vAlign="top" width="50%" rowSpan="2">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><ASP:DATAGRID id="DG_UPLOAD" CellPadding="1" PageSize="1" AutoGenerateColumns="False" Width="100%"
							runat="server">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
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
						</ASP:DATAGRID></TD>
				</TR>
			</table>
		</TD>
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
					<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ErrorMessage="Only xls(x), doc(x), txt, pdf, jpg or zip files are allowed!"
							ControlToValidate="TXT_FILE_UPLOAD" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.xlsx|.XLSX|.doc|.DOC|.docx|.DOCX|.txt|.TXT|.zip|.ZIP|.pdf|.PDF|.jpg|.JPG|.jpeg|.JPEG)$"></asp:regularexpressionvalidator></TD>
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
	</TR>
</TABLE>
