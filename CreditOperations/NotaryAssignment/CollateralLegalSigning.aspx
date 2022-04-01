<%@ Page language="c#" Codebehind="CollateralLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.NotaryAssignment.CollateralLegalSigning" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralLegalSigning</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" border="0">
					<TR>
						<TD colspan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<TABLE id="Table2">
											<TR>
												<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Notary Assignment : 
														Collateral Legal Signing</B></TD>
											</TR>
										</TABLE>
									</TD>
									<TD style="TEXT-ALIGN: right">
										<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td colspan="2" class="tdHeader1"><B>Jaminan</B></td>
					</tr>
					<tr>
						<td valign="top" width="30%">
							<asp:Table ID="TBL_JAMINAN" Runat="server" CssClass="BackGroundList" Width="100%"></asp:Table>
						</td>
						<td><iframe id="frm_jaminan" name="frm_jaminan" width="100%" height="700" frameborder="0"></iframe>
						</td>
					</tr>
					<tr>
						<td align="center" colspan="2">&nbsp;
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
