<%@ Page language="c#" Codebehind="Generatefile.aspx.cs" AutoEventWireup="True" Inherits="Create_text_booking.Create_File" %>
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
		<script language="javascript">
			function generateonce() {
				if (processing) {
					alert("Generate File is in progress. Please wait ...");
					return false;
				}
				else
					return true;
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%" border="0">
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
								<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="CU_REF" HeaderText="Reference Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="Receive Date"></asp:BoundColumn>
								<asp:BoundColumn DataField="name" HeaderText="Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Application type"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">Result Log</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 133px" vAlign="top" align="center" width="100%"
						colSpan="2"><asp:listbox id="LST_MEMO" runat="server" Width="100%" Height="128px" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:listbox></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2"><asp:button class="button1" id="Button1" runat="server" Width="104px" Text="Generate Text" onclick="Button1_Click"></asp:button><BR>
						<BR>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 670px" colSpan="2"><asp:listbox id="ListBox2" runat="server" Width="100%" Height="102px" Visible="False" onselectedindexchanged="ListBox2_SelectedIndexChanged"></asp:listbox><asp:textbox id="TXT_TRACK" runat="server" Visible="False"></asp:textbox><asp:textbox id="TXT_WHERE" runat="server" Visible="False"></asp:textbox>
						<asp:TextBox id="TXT_AUDITDESC" runat="server" Visible="False">Generate Text file .. end</asp:TextBox></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
