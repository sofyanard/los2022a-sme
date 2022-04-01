<%@ Page language="c#" Codebehind="Maintenance.aspx.cs" AutoEventWireup="True" Inherits="SME.Synchronization.Maintenance" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Maintenance</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/sme/style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Synchronization - Result 
										Maintenance</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 14px" align="left" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Result Text File</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" vAlign="top" align="left" colSpan="2"><asp:datagrid id="DataGrid1" runat="server" CellPadding="1" PageSize="1" AutoGenerateColumns="False"
							Width="100%">
							<Columns>
								<asp:BoundColumn DataField="FL_CODE" HeaderText="FILE CODE"></asp:BoundColumn>
								<asp:BoundColumn DataField="FL_NAME" HeaderText="FILE NAME"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="STATUS"></asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
										<asp:HyperLink id="FL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="FL_URL" Visible="False"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Result Log</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" vAlign="top" align="center" width="100%" colSpan="2"><asp:listbox id="LST_MEMO" runat="server" Width="100%" Height="128px"></asp:listbox></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2"><asp:button class="button1" id="Button3" runat="server" Text="Upload File" Visible="False"></asp:button></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 670px" colSpan="2"><asp:listbox id="ListBox2" runat="server" Width="100%" Height="102px" Visible="False"></asp:listbox><asp:textbox id="TXT_AUDITDESC" runat="server" Visible="False">Upload Text file .. end</asp:textbox></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
