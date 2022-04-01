<%@ Page language="c#" Codebehind="CollateralLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.Legal.CollateralLegalSigning" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralLegalSigning</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border=0>
					<tr>
						<td colspan="2" class="tdHeader1"><B>Jaminan</B></td>
					</tr>
					<tr>
						<td width="25%" valign="top">
							<asp:Table ID="TBL_JAMINAN" Runat="server" CssClass="BackGroundList"></asp:Table>
						</td>
						<td><iframe id="frm_jaminan" name="frm_jaminan" scrolling="auto" width="100%" height="390" frameborder="0"></iframe></td>
					</tr>
					<tr>
						<td align="center" colspan="2">
							<input type="button" value="View Asuransi Jaminan" class="button1">
							<asp:Label ID="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label ID="LBL_TC" Runat="server" Visible="False"></asp:Label>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
