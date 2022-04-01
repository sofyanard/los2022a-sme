<%@ Page language="c#" Codebehind="ListInitiation.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.ListInitiation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListInitiation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder" style="WIDTH: 482px">
								<TABLE id="Table8">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 200px" align="center"><B><asp:label id="LBL_TITLEPAGE" runat="server"></asp:label></B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<td colspan="2">
								<ASP:DATAGRID id="dg_list_initiation" runat="server" Width="100%" AutoGenerateColumns="False">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="IPPS_REGNO" HeaderText="Reference#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="INIT_DATE" HeaderText="Initiation Date" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="OWNER_ID" HeaderText="PIC">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="view" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</ASP:DATAGRID>
							</td>
						</tr>
						<tr id="TR_INITIATION" runat="server">
							<td vAlign="top" align="center" colSpan="2"><asp:button id="btn_new" runat="server" CssClass="Button1" Text="New Initiation" onclick="btn_new_Click"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
