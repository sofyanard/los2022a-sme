<%@ Page language="c#" Codebehind="AppraisalAssignment.aspx.cs" AutoEventWireup="True" Inherits="SME.VerificationAssignment.AppraisalAssignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Appraisal Assignment</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to Re-Appraised?");
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
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" colSpan="2">Penugasan</TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<td vAlign="top" width="45%">
							<table cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td">
										<asp:Table id="Table_List" runat="server" Width="100%" CellPadding="0" CellSpacing="0" CssClass="TDBGColor21">
											<asp:TableRow>
												<asp:TableCell CssClass="tdSmallHeader" Width="38%">Agunan</asp:TableCell>
												<asp:TableCell CssClass="tdSmallHeader" Width="62%" ColumnSpan="3">Penugasan</asp:TableCell>
											</asp:TableRow>
										</asp:Table>
									</td>
								</tr>
								<tr>
									<td align="center">&nbsp;
										<asp:TextBox id="TXT_JML_JAMINAN" runat="server" Visible="False" Width="51px"></asp:TextBox>&nbsp;
										<asp:Label id="LBL_CU_REF" runat="server" Visible="False"></asp:Label>
										<asp:Label id="LBL_AP_REGNO" runat="server" Visible="False"></asp:Label>
										<asp:Label id="LBL_COBRANCH" runat="server" Visible="False"></asp:Label>
									</td>
								</tr>
							</table>
						</td>
						<td width="55%" vAlign="top"><iframe id="coldetail" name="coldetail" width="100%" height="580" frameborder="0"></iframe>
						</td>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
