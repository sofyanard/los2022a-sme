<%@ Page language="c#" Codebehind="UploadFile.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.FileUpload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Upload File</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdHeader1" colSpan="2">Documents</TD>
				</TR>
				<TR>
					<TD width="50%" valign="top">
						<table cellpadding="0" cellspacing="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="75">
									File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" type="file" size="30" name="File1" runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:Label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:Label>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Only xls, doc, txt or zip files are allowed!"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$"
										ControlToValidate="TXT_FILE_UPLOAD"></asp:RegularExpressionValidator></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1"></TD>
								<TD></TD>
								<TD class="TDBGColorValue">
									<asp:Label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:Label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
							</TR>
							<TR>
								<TD colspan="3" align="center">
									<asp:Button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:Button></TD>
							</TR>
						</table>
					</TD>
					<TD width="50%" valign="top" style="HEIGHT: 42px">
						<table cellpadding="0" cellspacing="0" width="100%">
							<TR>
								<TD>
									<ASP:DATAGRID id="DatGrid" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
										CellPadding="1">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="No.">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="FU_USERID"></asp:BoundColumn>
										</Columns>
									</ASP:DATAGRID></TD>
							</TR>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
