<%@ Page language="c#" Codebehind="arParentCBI.aspx.cs" AutoEventWireup="True" Inherits="SME.CBI.arParentCBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>arParent</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table2">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Detail Data Entry: Aspek 
										Teknis, NCL &amp; Proyek</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="IMG_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="IMG_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
			</TABLE>
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdHeader1" vAlign="top" align="center" colSpan="2"><B>ASPEK TEKNIS, NCL 
							&amp; PROYEK</B></TD>
				</TR>
				<tr>
					<td class="td" vAlign="top" align="right" width="50%" colSpan="2"><asp:label id="LBL_REGNO" Visible="False" Runat="server"></asp:label><asp:label id="LBL_CUREF" Visible="False" Runat="server"></asp:label><asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label></td>
				</tr>
				<TR>
					<TD class="td" vAlign="top" width="100%" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<td vAlign="top" width="20%">
										<table cellSpacing="2" cellPadding="2" width="100%">
											<tr>
												<td class="td"><asp:table id="Table_List" runat="server" Width="100%" CellPadding="0" CellSpacing="0" CssClass="TDBGColor21">
														<asp:TableRow>
															<asp:TableCell ColumnSpan="2" Width="100%" Text="Ketentuan Kredit" CssClass="tdSmallHeader"></asp:TableCell>
														</asp:TableRow>
													</asp:table></td>
											</tr>
										</table>
										<P align="center">
											Ketentuan Kredit:
											<!-- <asp:dropdownlist id="ddl_KetentuanKredit" runat="server">
												<asp:ListItem Value="0"> - SELECT -</asp:ListItem>
											</asp:dropdownlist><br> -->
											<asp:dropdownlist id="ddl_Pilih" runat="server">
												<asp:ListItem Value="0"> - SELECT -</asp:ListItem>
												<asp:ListItem Value="1">Aspek Teknis</asp:ListItem>
												<asp:ListItem Value="2">Non Cash Loan</asp:ListItem>
												<asp:ListItem Value="3">Project</asp:ListItem>
												<asp:ListItem Value="4">Note</asp:ListItem>
											</asp:dropdownlist><br>
											<asp:Button id="btn_Insert" runat="server" Text="Insert" onclick="btn_Insert_Click"></asp:Button></P>
									</td>
									<td width="80%"><iframe id="if_Child" name="ApprResult" frameBorder="0" width="100%" height="425" runat="server">
										</iframe>
									</td>
								</TR>
							</TBODY>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
