<%@ Page language="c#" Codebehind="UploadDataeMAS.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PortfolioWatchlistChecking.UploadDataeMAS" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UploadDataeMAS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>eMAS UPLOAD DATA</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2">&nbsp;</TD>
				</TR>
				<tr>
					<td vAlign="top" colSpan="2">
						<TABLE id="Table61" cellSpacing="0" cellPadding="0" width="60%">
							<TR>
								<TD class="TDBGColor1" width="100">Periode Data</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL_PERIODE" runat="server" Width="30px" CssClass="mandatory" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_PERIODE" CssClass="mandatory" Runat="server"></asp:dropdownlist><asp:textbox id="TXT_THN_PERIODE" runat="server" Width="60px" CssClass="mandatory" MaxLength="4"></asp:textbox></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td class="tdHeader1" vAlign="top" colSpan="2" runat="server">PORTFOLIO</td>
				</tr>
				<tr>
					<td colSpan="2">
						<table id="Table33" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td vAlign="top" width="20%"><ASP:DATAGRID id="DATGRD_PERIODE" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="Periode Data" DataField="PERIODE_DATA">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" HeaderText="Function" CommandName="Retrieve">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<td vAlign="top" width="80%"><ASP:DATAGRID id="DATGRD_PORTFOLIO" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="CIF#" DataField="CIF_NO">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Account#" DataField="ACCT_NO">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Customer Name" DataField="CUST_NAME">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Facility Code" DataField="F_CODE">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Loan Type" DataField="LOAN_TYPE">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Total Limit" DataField="F_LIMIT">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="BUC Code" DataField="BUC_CD">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="BUC Name" DataField="BUC_DESC">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Kole" DataField="KOLE">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
							</tr>
							<tr>
								<td class="TDBGColor2" colSpan="2"><asp:button id="BTN_CLEAR_PERIODE" CssClass="button1" Runat="server" Text="CLEAR" onclick="BTN_CLEAR_PERIODE_Click"></asp:button><asp:label id="LBL_TGL_PERIODE" runat="server" Visible="False"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="tdHeader1" id="Td1" vAlign="middle" colSpan="2" runat="server">DATA 
						UPLOAD</td>
				</tr>
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
					<td vAlign="top" width="50%"><asp:datagrid id="DATA_UPLOAD" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
							AutoGenerateColumns="False" PageSize="5">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_DATA_EMAS" HeaderText="ID_UPLOAD_DATA_EMAS">
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
						</asp:datagrid></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
