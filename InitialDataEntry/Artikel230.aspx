<%@ Page language="c#" Codebehind="Artikel230.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.Artikel230" enableViewState="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Artikel 230</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/child.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<!--
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 509px">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Artikel 230</B></TD>
								</TR>
							</TABLE>
							<asp:Label id="LBL_REGNO" runat="server"></asp:Label>
							<asp:Label id="LBL_CUREF" runat="server"></asp:Label>
							<asp:Label id="LBL_TC" runat="server"></asp:Label>
							<asp:Label id="LBL_MC" runat="server"></asp:Label>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">Pemberian Kredit Yang Dilarang</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 19px" colSpan="2">
							<P>Pemberian Kredit yang dilarang antara lain :</P>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 18px" vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							</TABLE>
							<TABLE id="Table2" style="WIDTH: 948px; HEIGHT: 16px" cellSpacing="1" cellPadding="1" width="948"
								border="0">
							</TABLE>
							<asp:placeholder id="PH_ARTIKEL" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 19px" vAlign="top" align="left" colSpan="2">
							<P>Di samping butir-butir di atas, Risk &amp; Capital Comittee secara berkala 
								menetapkan kredit yang dilarang.
								<BR>
								<BR>
								Dengan ini saya menyatakan bahwa aplikasi ini tidak termasuk kriteria di atas.</P>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="  Yes  " CssClass="Button1" onclick="BTN_YES_Click"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:button id="BTN_NO" runat="server" Text="   No   " CssClass="Button1" onclick="BTN_NO_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
