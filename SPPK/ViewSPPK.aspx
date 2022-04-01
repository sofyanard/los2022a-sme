<%@ Page language="c#" Codebehind="ViewSPPK.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.ViewSPPK" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ViewSPPK</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">Informasi Pemohon
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label><asp:label id="lbl_curef" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
							
							<iframe id="if1" style="WIDTH: 100%; HEIGHT: 190px" name="if1" src="appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&amp;sta=view"
								scrolling="no"></iframe>
							
						</td>
					</tr>
				</table>
				<table id="Table5" cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<td align="left">
							<asp:Button id="BTN_RECALC_INSTALLMENT" runat="server" Text="Re-Calculate Installment"></asp:Button>
						</td>
					</TR>
				</table>
				<table id="Table3" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>&nbsp;
							<asp:LinkButton id="btnPrint" runat="server" Font-Bold="True" Visible="False">Compose SPPK</asp:LinkButton></td>
					</tr>
				</table>
				<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
							
							<iframe id="if2" style="WIDTH: 100%; HEIGHT: 700px" name="if2" src="../dataentry/custproduct.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&amp;sta=view"
								scrolling="yes"></iframe>
							
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
