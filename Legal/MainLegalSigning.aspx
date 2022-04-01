<%@ Page language="c#" Codebehind="MainLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.MainLegalSigning" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainLegalSigning</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Legal Signing : Main</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder>
							<asp:Label ID="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_TC" Runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
					<tr>
						<td align="center" colspan="2">
							<asp:PlaceHolder ID="PlaceHolder1" Runat="server"></asp:PlaceHolder>
						</td>
					</tr>
					<tr>
						<TD colspan="2">
						
						<iframe id="frm_data" name="frm_data" scrolling="auto" width="100%" height="470" frameborder="1" src="DetailLegalSigning.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&tc=<%=Request.QueryString["tc"]%>"></iframe>
						
						</TD>
					</tr>
					<tr>
						<td colspan="2" align="center">
							<asp:Button ID="BTN_UPDATE" Runat="server" CssClass="button1" Text="Lanjutkan"></asp:Button>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
