<%@ Page language="c#" Codebehind="GenerateText.aspx.cs" AutoEventWireup="True" Inherits="SME.Synchronization.GenerateText" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GenerateText</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Synchronization - 
										Generate Text</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
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
					<TD class="tdNoBorder" vAlign="top" align="center" width="100%" colSpan="2">
						<asp:listbox id="LST_MEMO" runat="server" Width="100%" Height="128px"></asp:listbox>
					</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2">
						<asp:button class="button1" id="Button1" runat="server" Width="200px" Text="Generate Text" onclick="Button1_Click"></asp:button>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:listbox id="ListBox2" runat="server" Width="100%" Height="102px" Visible="False"></asp:listbox>
						<asp:textbox id="TXT_TRACK" runat="server" Visible="False"></asp:textbox>
						<asp:textbox id="TXT_WHERE" runat="server" Visible="False"></asp:textbox>
						<asp:TextBox id="TXT_AUDITDESC" runat="server" Visible="False">Generate Text file .. end</asp:TextBox>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
