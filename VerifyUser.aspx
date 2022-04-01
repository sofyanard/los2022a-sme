<%@ Page language="c#" Codebehind="VerifyUser.aspx.cs" AutoEventWireup="True" Inherits="SME.VerifyUser" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>User Verification</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<!--		<LINK rev="stylesheet" href="design.css" type="text/css" rel="stylesheet"> -->
		<!-- #include file="include/child.html" -->
		<!-- #include file="include/cek_all.html" -->
		<!--<script language="JavaScript">
			if (top != self) { top.location = self.location; }
		</script>-->
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center><br>
				<TABLE id="Table2" style="Z-INDEX: 102; LEFT: 8px; TOP: 8px" cellSpacing="1" cellPadding="1"
					width="50%" border="1">
					<TR>
						<TD width="300"></TD>
						<TD class="tdHeader1" align="center" colSpan="2">User Verification</TD>
						<TD width="300"></TD>
					</TR>
					<TR>
						<TD width="300"></TD>
						<TD class="TDBGColor1" style="WIDTH: 139px" align="center">User
						</TD>
						<TD width="300"><asp:textbox id="TXT_USER" runat="server" Width="295" BackColor="White"></asp:textbox></TD>
						<TD width="300"></TD>
					</TR>
					<TR>
						<TD width="300"></TD>
						<TD class="TDBGColor1" style="WIDTH: 139px" align="center">Password</TD>
						<TD width="300"><asp:textbox id="TXT_PASSWORD" runat="server" Width="295px" TextMode="Password"></asp:textbox></TD>
						<TD width="300"></TD>
					</TR>
					<TR>
						<TD width="330"></TD>
						<TD align="center" colSpan="2"><asp:label id="Label1" runat="server" ForeColor="Red"></asp:label></TD>
						<TD width="300"></TD>
					</TR>
					<TR>
						<TD width="200"></TD>
						<TD class="TDBGColor2" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="67px" CssClass="Button1" Text="Ok" onclick="BTN_SAVE_Click"></asp:button><asp:button id="BTN_CANCEL" runat="server" Width="67" CssClass="Button1" Text="Cancel" onclick="BTN_CANCEL_Click"></asp:button></TD>
						<TD width="330"></TD>
					</TR>
				</TABLE>
			</center>
			&nbsp;
		</form>
	</body>
</HTML>
