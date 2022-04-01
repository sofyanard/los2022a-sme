<%@ Page language="c#" Codebehind="LOWBiayaPK.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWBiayaPK" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
  <head>
    <title>LOWBiayaPK</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" align="right" colSpan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<TABLE id="Table2">
											<TR>
												<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Notary Assignment : 
														Fasilitas Legal Signing</B></TD>
											</TR>
										</TABLE>
									</TD>
									<TD style="TEXT-ALIGN: right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
					<TR>
						<TD class="TDBGColor1">Booking Branch</TD>
						<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_BOOKINGBRANCH" runat="server" CssClass="mandatory"></asp:dropdownlist>&nbsp;&nbsp;
							<asp:button id="BTN_SAVE" runat="server" CssClass="button1" Text="SAVE"></asp:button></TD>
					</TR>
					</TD></TR>
					<tr>
						<td class="tdHeader1" align="center" colSpan="2"><B>Data Detail</B></td>
					</tr>
					<tr>
						<TD vAlign="top" width="20%"><asp:table id="TBL_FASILITAS" CssClass="BackGroundList" Width="100%" Runat="server"></asp:table><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></TD>
						<td><iframe id="frm_fasilitas" name="frm_fasilitas" frameBorder="0" width="100%" height="700"></iframe>
						</td>
					</tr>
					<TR id="TR_DOC" runat="server">
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Document Export</TD>
					</TR>
					<TR id="TR_DOC2" runat="server">
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Format</TD>
									<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:button id="BTN_EXPORT" runat="server" Text="Export" Width="64px"></asp:button></TD>
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
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" PageSize="1" AutoGenerateColumns="False"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="User ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="DOC_ID" HeaderText="User ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="FE_USERID" HeaderText="User ID"></asp:BoundColumn>
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
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<table cellSpacing="0" cellPadding="0" width="100%" id="TBL_FILEUPLOAD" runat="server">
					<tr>
						<td align="center">
							<iframe id="if2" width="100%" height="510" name="if2" src="..\COUploadFile.aspx?regno=<%=Request.QueryString["regno"]%>">
							</iframe>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
