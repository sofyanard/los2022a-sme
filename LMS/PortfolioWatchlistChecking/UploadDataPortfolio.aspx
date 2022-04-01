<%@ Page language="c#" Codebehind="UploadDataPortfolio.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PortfolioWatchlistChecking.UploadDataPortfolio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>UploadDataPortfolio</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>RISK&nbsp;UPLOAD DATA</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2">&nbsp;</TD>
				</TR>
				<tr>
					<td colspan="2" class="tdHeader1" valign="middle" runat="server" ID="Td2">
						DOCUMENT</td>
				</tr>
				<tr>
					<td vAlign="top" width="50%">
						<asp:datagrid id="DATGRD_SOURCE" runat="server" CellPadding="1" PageSize="5" AutoGenerateColumns="False"
							Width="100%" AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="Source File">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="SOURCEFILE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</td>
					<td vAlign="top" width="50%">
						<asp:datagrid id="DATA_UPLOAD" runat="server" CellPadding="1" PageSize="5" AutoGenerateColumns="False"
							Width="100%" AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_DATA_RISK" HeaderText="ID_UPLOAD_DATA_RISK">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="Destination File">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="FILE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="FILE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<table align="center" width="50%">
							<tr>
								<td vAlign="top" width="50%">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" width="75">File</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
													runat="Server"></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Status</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Hanya file xls yang diperbolehkan!"
													ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ControlToValidate="TXT_FILE_UPLOAD"></asp:regularexpressionvalidator></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1"></TD>
											<TD></TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3"></TD>
										</TR>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
