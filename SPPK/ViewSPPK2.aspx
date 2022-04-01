<%@ Page language="c#" Codebehind="ViewSPPK2.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.ViewSPPK2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewSPPK2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fViewSppk" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> SPPK</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:ImageButton><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						<!--
						<td></td>
						<td class="tdNoBorder" align="right">
							<A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
							-->
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">Informasi Pemohon
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label><asp:label id="lbl_curef" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
							<iframe id="if1" style="WIDTH: 100%; HEIGHT: 190px" name="if1" src="appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view"
								scrolling="no"></iframe>
						</td>
					</tr>
				</table>
				<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<td align="left">
						</td>
					</TR>
				</table>
				<table id="Table3" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>&nbsp;</td>
					</tr>
				</table>
				<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
							<iframe id="if2" style="WIDTH: 100%; HEIGHT: 700px" name="if2" src="../dataentry/custproduct.aspx?regno=<%=Request.QueryString["regno"]%>&amp;curef=<%=Request.QueryString["curef"]%>&amp;sta=view"
								scrolling="yes"></iframe>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
