<%@ Page language="c#" Codebehind="FasilitasLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.DetailLegalSigning" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailLegalSigning</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td colspan="2" class="tdHeader1" align="center"><B>Data Detail</B></td>
					</tr>
					<tr>
						<TD width="20%" valign="top">
							<asp:Table ID="TBL_FASILITAS" Runat="server" Width="100%" CssClass="BackGroundList"></asp:Table>
							<asp:Label id="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_TC" Runat="server" Visible="False"></asp:Label>
						</TD>
						<td><iframe id="frm_fasilitas" name="frm_fasilitas" scrolling="auto" width="100%" height="425" frameborder="0"></iframe></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
