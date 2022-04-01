<%@ Page language="c#" Codebehind="BlackListText.aspx.cs" AutoEventWireup="True" Inherits="SME.BlackList.BlackListText" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BlackListText</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/SME/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2"
				cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 444px">
						<TABLE id="Table2">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Internal Checking</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="/SME/Body.aspx">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:ImageButton><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="/SME/Image/logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
						<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<tr>
					<TD class="tdNoBorder" style="HEIGHT: 800px" align="center" colSpan="2">						
						<iframe id="if1" src="<%=Request.QueryString["file"]%>" scrolling=auto frameborder=no width="100%" height="100%"></iframe>							
					</TD>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
