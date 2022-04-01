<%@ Page language="c#" Codebehind="InquiryPerSektor.aspx.cs" AutoEventWireup="True" Inherits="SME.PIC.InquiryPerSektor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InquiryPerSektor</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" --><LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PORTFOLIO INFORMATION</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="100%">
								<tr id="TR_EX_CONTENT" runat="server" width="100%">
									<TD vAlign="top" align="center" width="100%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="10%">KSEBI</TD>
												<TD style="WIDTH: 5px">:</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KSEBM" AutoPostBack="True" CssClass="Mandatory" Runat="server" Width="40%"></asp:dropdownlist><asp:button id="RETRIEVE" runat="server" Text="Retrieve" onclick="RETRIEVE_Click"></asp:button></TD>
											</TR>
										</table>
									</TD>
								</tr>
							</TABLE>
						</TD>
					</TR>
					<TR height="20">
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<table>
								<tr>
									<td align="center"><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="ID_UPLOAD" HeaderText="ID">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TIPE" HeaderText="ITEM">
													<HeaderStyle Width="30%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="30%"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FILE_UPLOAD_NAME" HeaderText="DOCUMENT">
													<HeaderStyle Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle Width="40%"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="FUNCTION">
													<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="DOWNLOAD" runat="server" CommandName="Download">Download</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn Visible="False">
													<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="VIEW" runat="server" CommandName="View">View</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FILE_UPLOAD_NAME" HeaderText="ID">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></td>
								</tr>
							</table>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
