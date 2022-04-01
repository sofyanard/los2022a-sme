<%@ Page language="c#" Codebehind="ScoringSend.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.ScoringSend" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Neraca</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table6">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Pre Scoring - Sending 
												Data to StrategyWare</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<tr>
							<td colSpan="2"></td>
						</tr>
						<!--  separator ------------------------------------------------------------------------------------------------------------------------------------------>
						<TR>
							<td class="tdNoBorder" align="center" colSpan="2">x
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="tdHeader1" align="center" width="100%" colSpan="2">Pengiriman Data ke 
											StrategyWare</TD>
									</TR>
								</TABLE>
							</td>
						</TR>
						<!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Send" Width="100px" onclick="BTN_SAVE_Click"></asp:button>
								<asp:button id="BTN_NEXT" runat="server" CssClass="Button1" Text="Next" Width="100px" Enabled="False" onclick="BTN_NEXT_Click"></asp:button></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
