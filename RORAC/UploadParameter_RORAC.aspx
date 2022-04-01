<%@ Page language="c#" Codebehind="UploadParameter_RORAC.aspx.cs" AutoEventWireup="True" Inherits="SME.RORAC.UploadParameter_RORAC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Upload Parameter RORAC</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Style.css">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" border="0" width="100%">
					<TR>
						<TD align="left">
							<TABLE id="Table3">
								<TR>
									<TD style="WIDTH: 400px" class="tdBGColor2" align="center"><B>Upload Parameter RORAC</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="td" border="1" cellSpacing="1" cellPadding="1" width="90%" height="35">
					<TR>
						<TD class="tdHeader1" colSpan="7">Documents</TD>
					</TR>
					<tr>
						<TD align="center"><ASP:DATAGRID id="DATA_TEMPLATE" runat="server" Width="400px" AutoGenerateColumns="False" CellPadding="1"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID_TEMPLATE_RORAC">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAMA_TEMPLATE_RORAC" HeaderText="Source File" ItemStyle-Width="350px"
										ItemStyle-HorizontalAlign="Center">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="70"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
						<TD align="center"><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="473px" AutoGenerateColumns="False" CellPadding="1"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="True" DataField="ID_UPLOAD_RORAC" HeaderText="No" ItemStyle-Width="10px">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FILE_UPLOAD_RORAC_NAME" HeaderText="Destination File">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id="UPL_RORAC_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="UPL_RORAC_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</tr>
				</TABLE>
				<br>
				<table cellSpacing="0" cellPadding="0" width="50%">
					<TR>
						<TD class="TDBGColor1" width="75">File</TD>
						<TD style="WIDTH: 15px">:</TD>
						<TD class="TDBGColorValue"><INPUT style="WIDTH: 344px; HEIGHT: 19px" id="TXT_FILE_UPLOAD" size="38" type="file" name="File1"
								runat="Server"></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">Status</TD>
						<TD>:</TD>
						<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
								ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1"></TD>
						<TD></TD>
						<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 21px" colSpan="3" align="center"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD colSpan="3" align="center"></TD>
					</TR>
				</table>
			</center>
			<br>
			<center>
				<table class="td" border="1" cellSpacing="1" cellPadding="1" width="60%" height="35">
					<TR>
						<TD class="tdHeader1" colSpan="7" height="35">Uploaded Data</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
								CellPadding="1">
							</ASP:DATAGRID>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
