<%@ Page language="c#" Codebehind="WalletSizePrint.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.WalletShareTarget.WalletSizePrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WalletSizePrint</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		  function cetak()
		  {
		    TRPRINT.style.display = "none";
		    window.print();
		    TRPRINT.style.display = "";
		  }
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="right" colSpan="2"><IMG src="../../Image/LogoMandiri.jpg">
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="LBL_TITLE_PAGE" runat="server" Font-Bold="True" Font-Size="200%">WALLET SIZE</asp:label></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_SCENARIO" width="100%" border="1" runat="server">
				</TABLE>
				<TABLE width="100%" border="0">
					<TR id="TRPRINT">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><INPUT style="FONT-WEIGHT: bold; FONT-SIZE: 150%; COLOR: white; BACKGROUND-COLOR: #18386b"
								onclick="cetak()" type="button" value="Print">
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
