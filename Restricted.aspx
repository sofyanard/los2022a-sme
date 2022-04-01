<%@ Page language="c#" Codebehind="Restricted.aspx.cs" AutoEventWireup="True" Inherits="SME.Restricted" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Restricted</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="2" cellPadding="2" width="100%" border="1">
				<TR>
					<TD align="center">
						<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="XX-Large">RESTRICTED AREA!!!</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Button id="Button1" runat="server" Text="Return To Main" onclick="Button1_Click"></asp:Button></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
