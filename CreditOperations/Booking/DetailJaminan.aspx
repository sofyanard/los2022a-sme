<%@ Page language="c#" Codebehind="DetailJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.Booking.DetailJaminan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailJaminan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td colspan="2" class="tdHeader1" align="center"><B>Data Detail</B></td>
					</tr>
					<tr>
						<TD width="20%" valign="top">
							<asp:Table ID="TBL_JAMINAN" Runat="server" Width="100%" CssClass="BackGroundList"></asp:Table>
							<asp:Label id="LBL_REGNO" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_CUREF" Runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_TC" Runat="server" Visible="False"></asp:Label>
						</TD>
						<td><iframe id="frm_jaminan" name="frm_jaminan" scrolling="no" width="100%" height="600" frameborder="0"></iframe>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
