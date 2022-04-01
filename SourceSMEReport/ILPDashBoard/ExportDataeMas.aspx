<%@ Page language="c#" Codebehind="ExportDataeMas.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.ILPDashBoard.ExportDataeMas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExportDataeMas</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="setMandatory2()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Export Data</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">File Export</TD>
				</TR>
				<tr>
					<TD vAlign="top" width="50%">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="tdHeader1" colSpan="3">File Permohonan Baru</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="75">File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_NEW" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38"
										name="File1" runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_NEW" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD_NEW"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ErrorMessage="Hanya file xls yang diperbolehkan!"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT_NEW" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD_NEW" runat="server" Text="Upload" onclick="BTN_UPLOAD_NEW_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"></TD>
							</TR>
							<TR>
								<TD class="tdHeader1" colSpan="3">File Perubahan Limit</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="75">File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_LIMIT" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38"
										name="File2" runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_LIMIT" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" ControlToValidate="TXT_FILE_UPLOAD_LIMIT"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ErrorMessage="Hanya file xls yang diperbolehkan!"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT_LIMIT" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD_LIMIT" runat="server" Text="Upload" onclick="BTN_UPLOAD_LIMIT_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"></TD>
							</TR>
							<TR>
								<TD class="tdHeader1" colSpan="3">File Perpanjangan</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="75">File</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD_RENEWAL" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38"
										name="File3" runat="Server"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Status</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_RENEWAL" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="Regularexpressionvalidator3" runat="server" ControlToValidate="TXT_FILE_UPLOAD_RENEWAL"
										ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ErrorMessage="Hanya file xls yang diperbolehkan!"></asp:regularexpressionvalidator></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1"></TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT_RENEWAL" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD_RENEWAL" runat="server" Text="Upload" onclick="BTN_UPLOAD_RENEWAL_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"></TD>
							</TR>
						</table>
					</TD>
					<td vAlign="top" width="50%">
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="5"
										CellPadding="1" AllowPaging="True">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="ID_UPLOAD_EXP" HeaderText="No" Visible="False">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle Width="10px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FILE_UPLOAD_EXP_NAME" HeaderText="Destination File">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
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
									</ASP:DATAGRID></TD>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
