<%@ Page language="c#" Codebehind="BiayaPK.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.BiayaPK" %>
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
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" align="right" colspan="2">
							<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<TABLE id="Table2">
											<TR>
												<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Proposal&nbsp;: 
														Biaya-biaya</B></TD>
											</TR>
										</TABLE>
									</TD>
									<TD style="TEXT-ALIGN: right">
										<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:ImageButton><A href="../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
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
						<td><iframe id="frm_fasilitas" name="frm_fasilitas" width="100%" height="700" frameborder="0"></iframe>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
