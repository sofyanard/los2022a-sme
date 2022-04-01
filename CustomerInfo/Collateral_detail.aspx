<%@ Page language="c#" Codebehind="Collateral_detail.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.Collateral_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>jaminan_detail</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Collateral Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A>
							<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="ImageButton1_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Collateral Info</TD>
					</TR>
					<TR>
						<TD valign="top" width="100%" colspan="2">
						
						<iframe id="scola" name="scola" scrolling="auto" src="InfoCollateral.aspx?sta=<%=Request.QueryString["sta"]%>&curef=<%=Request.QueryString["curef"]%>&tc=<%=Request.QueryString["tc"]%>&mc=<%=Request.QueryString["mc"]%>" width="100%" height="240" frameborder="0"></iframe>
						
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA JAMINAN</TD>
					</TR>
					<TR>
						<TD valign="top" width="30%" align="center">
						
						<iframe id="scol" name="scol" scrolling="auto" src="Collateral_List.aspx?&sta=<%=Request.QueryString["sta"]%>&curef=<%=Request.QueryString["curef"]%>&tc=<%=Request.QueryString["tc"]%>&mc=<%=Request.QueryString["mc"]%>&regno=<%=Request.QueryString["regno"]%>" width="100%" height="620" frameborder="0"></iframe>
						
						</TD>
						<TD valign="top">
							<iframe id="coldetail" name="coldetail" width="100%" height="660" frameborder="0" scrolling="no">
							</iframe>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
