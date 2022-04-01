<%@ Page language="c#" Codebehind="LOWAppraisalAssigment.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWAppraisalAssigment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LOWAppraisalAssigment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" width="30%" align="center"><B>Detail Data Entry : Data Jaminan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Appraisal Assignment</TD>
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
												<asp:TableCell CssClass="tdSmallHeader" Width="38%">Collateral</asp:TableCell>
												<asp:TableCell CssClass="tdSmallHeader" Width="62%" ColumnSpan="3">Appraisal Assignment</asp:TableCell>
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
