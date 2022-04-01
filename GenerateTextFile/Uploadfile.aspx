<%@ Page language="c#" Codebehind="Uploadfile.aspx.cs" AutoEventWireup="True" Inherits="Upload_File_booking.Create_File" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
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
			<TABLE id="Table1" width="100%" cellSpacing="2" cellPadding="2" border="0">
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 670px"></TD>
					<TD class="tdNoBorder" align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 14px" align="left" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Generate Text File</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 100%; HEIGHT: 67px" vAlign="top" align="left" colSpan="2"><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
							CellPadding="1">
							<Columns>
								<asp:BoundColumn DataField="FL_CODE" HeaderText="FILE CODE"></asp:BoundColumn>
								<asp:BoundColumn DataField="FL_NAME" HeaderText="FILE NAME"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="STATUS"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Result Log</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" width="100%" vAlign="top" align="center" colSpan="2"><asp:listbox id="LST_MEMO" runat="server" Height="128px" Width="100%"></asp:listbox></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" colSpan="2" align="center">
						<asp:button class="button1" id="Button3" runat="server" Text="Upload File" onclick="Button3_Click"></asp:button>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 670px" colSpan="2"><asp:listbox id="ListBox2" runat="server" Height="102px" Width="100%" Visible="False"></asp:listbox>
						<asp:TextBox id="TXT_AUDITDESC" runat="server" Visible="False">Upload Text file .. end</asp:TextBox></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
