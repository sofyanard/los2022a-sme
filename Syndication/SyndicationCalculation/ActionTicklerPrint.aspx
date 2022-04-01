<%@ Page language="c#" Codebehind="ActionTicklerPrint.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.SyndicationCalculation.ActionTicklerPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ActionTicklerPrint</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD align="left" colSpan="2"><asp:label id="LBL_TITLE_PAGE" runat="server" Font-Bold="True" Font-Size="200%">ACTION TICKLER</asp:label></TD>
								</TR>
								<TR>
									<TD align="left" colSpan="2"><asp:label id="LBL_TITLE_CUST" runat="server" Font-Bold="True" Font-Size="200%"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right" colSpan="2"><IMG src="../../Image/LogoMandiri.jpg">
						</TD>
					</TR>
					<TR>
						<TD colSpan="3"></TD>
					</TR>
				</TABLE>
				<TABLE id="TBL_ACTION" width="100%" border="1" runat="server">
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
