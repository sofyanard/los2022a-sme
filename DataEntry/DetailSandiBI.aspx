<%@ Page language="c#" Codebehind="DetailSandiBI.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.Booking.DetailSandiBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailSandiBI</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<%if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) {%>
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" width="30%" align="center"><B>Detail Data Entry : Sandi BI</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<%}%>
					<tr>
						<td colspan="2" class="tdHeader1" width="100%" align="center"><B>Sandi BI</B></td>
					</tr>
					<tr>
						<TD width="20%" valign="top">
							<asp:Table ID="TBL_FASILITAS" Runat="server" Width="100%" CssClass="BackGroundList"></asp:Table>
							<asp:Label id="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_TC" Runat="server" Visible="False"></asp:Label>
						</TD>
						<td><iframe id="frm_sandibi" name="frm_sandibi" scrolling="auto" width="100%" height="400" frameborder="0"></iframe>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
