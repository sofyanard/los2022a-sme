<%@ Page language="c#" Codebehind="jaminan_detail.aspx.cs" AutoEventWireup="True" Inherits="SME.HistoricalLoanInfo.Collateral.jaminan_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>jaminan_detail</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					
					<% if (Request.QueryString["sta"] != "view") {%>
					
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" width="30%" align="center"><B>Detail Data Entry : Data Jaminan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg"></asp:ImageButton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR id="TR_SUBMENU" runat="server">
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="PH_SUBMENU" runat="server" Visible=False ></asp:placeholder></TD>
					</TR>
					
					<%} %>
					
					<TR>
						<TD class="tdHeader1" colSpan="2">DATA JAMINAN</TD>
					</TR>
					<TR>
						<TD valign="top" width="30%">
					
						<iframe id="scol" name="scol" scrolling="auto" src="Jaminan_List.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&tc=<%=Request.QueryString["tc"]%>&de=<%=Request.QueryString["de"]%>" width="100%" height="540" frameborder="0"></iframe>
					
						</TD>
						<TD>
							<iframe id="coldetail" name="coldetail" width="100%" height="660" frameborder="0" scrolling="no">
							</iframe>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
