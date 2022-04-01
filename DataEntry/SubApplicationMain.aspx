<%@ Page language="c#" Codebehind="SubApplicationMain.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.SubApplicationMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Sub Application</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/child.html" -->
		<script language="javascript">
			function batal()
			{
				conf = confirm("Are you sure you want to cancel?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="center" colSpan="2"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Sub Application</B></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" align="center" colSpan="2">
						<asp:LinkButton id="LNK_GEN_INFO" runat="server" onclick="LNK_GEN_INFO_Click">General Info</asp:LinkButton>&nbsp;&nbsp;
						<asp:LinkButton id="LNK_INFO_PERUSAHAAN" runat="server" onclick="LNK_INFO_PERUSAHAAN_Click">Info Perusahaan</asp:LinkButton>&nbsp;&nbsp;
						<asp:LinkButton id="LNK_BLACKLIST" runat="server" onclick="LNK_BLACKLIST_Click">Black List</asp:LinkButton>&nbsp;&nbsp;
						<asp:LinkButton id="LNK_STRUK_KRED" runat="server" onclick="LNK_STRUK_KRED_Click">Struktur Kredit</asp:LinkButton>&nbsp;&nbsp;
						<asp:LinkButton id="LNK_JAMINAN" runat="server" onclick="LNK_JAMINAN_Click">Data Jaminan</asp:LinkButton>&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="LNK_DTBO" runat="server" onclick="LNK_DTBO_Click">DTBO</asp:LinkButton>&nbsp;
						<asp:LinkButton id="LNK_SANDIBI" runat="server" onclick="LNK_SANDIBI_Click">Sandi BI</asp:LinkButton>&nbsp;</TD>
				</TR>
				<tr>
					<td width="100%" colspan="2"><iframe id="IF_SubDetail" name="ProdDetail" tabIndex="0" frameBorder="no" width="100%" height="500"
							runat="server" scrolling="auto" class="TD"></iframe>
					</td>
				</tr>
				<TR>
					<TD width="100%" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="tdbgcolor2" width="100%" colSpan="2">
						<asp:Label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_MAINCUREF" runat="server" Visible="False"></asp:Label>
						<asp:Button id="BTN_SAVE" runat="server" Text="Save &amp; Close" CssClass="button1" onclick="BTN_SAVE_Click"></asp:Button>
						<asp:Button id="BTN_CANCEL" runat="server" CssClass="button1" Text="Cancel Application" Visible="False" onclick="BTN_CANCEL_Click"></asp:Button>
						<asp:Label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:Label>
						<asp:Label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:Label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
