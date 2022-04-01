<%@ Page language="c#" Codebehind="PerjanjianPasalPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.PerjanjianKredit.PerjanjianPasalPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>PerjanjianPasalPrint</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
			function cetak()
			{
				TRPRINT.style.display = "none";
				window.print();
				TRPRINT.style.display = "";
			}
		</SCRIPT>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="right"><IMG src="../../Image/LogoMandiri.jpg">
						</TD>
					</TR>
					<TR>
						<TD align="center"><asp:label id="LBL_TXT_GROUP" runat="server" Font-Bold="True" Font-Underline="True" Font-Size="200%"></asp:label></TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:label id="Label2" runat="server">No.PK Awal : </asp:label>
							<asp:label id="LBL_NO_PK_AWAL" runat="server"></asp:label>
							<asp:label id="Label3" runat="server">Tgl.PK Awal : </asp:label>
							<asp:label id="LBL_TGL_PK_AWAL" runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD align="center">
							<asp:label id="Label4" runat="server">No.Addendum PK : </asp:label>
							<asp:label id="LBL_NO_ADDENDUM" runat="server"></asp:label>
							<asp:label id="Label5" runat="server">Tgl.Addendum PK : </asp:label>
							<asp:label id="LBL_TGL_ADDENDUM" runat="server"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_ACTION" width="100%" border="1" runat="server">
				</TABLE>
				<TABLE width="100%" border="0">
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="label1" runat="server">Dibuat Oleh</asp:label></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="LBL_TXT_NAME" runat="server" Font-Bold="True" Font-Underline="True"></asp:label></TD>
					</TR>
					<TR>
						<TD align="left"><asp:label id="LBL_TXT_NM_TITLE" runat="server"></asp:label>
						</TD>
					</TR>
				</TABLE>
				<TABLE width="100%" border="0">
					<TR id="TRPRINT">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><INPUT onclick="cetak()" type="button" value="Print" style="FONT-WEIGHT: bold; FONT-SIZE: 150%; COLOR: white; BACKGROUND-COLOR: #18386b">
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
