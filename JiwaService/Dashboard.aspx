<%@ Page language="c#" Codebehind="Dashboard.aspx.cs" AutoEventWireup="True" Inherits="SME.JiwaService.Dashboard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<HTML>
	<HEAD>
		<TITLE>Dashboard</TITLE>
			<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
			<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
			<META name="CODE_LANGUAGE" Content="C#">
			<META name=vs_defaultClientScript content="JavaScript">
			<META name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
			<LINK href="../style.css" type="text/css" rel="stylesheet">
			<SCRIPT language="javascript">
				function view_report(mc, bu)
				{
					for ( i=0 ; i<13; i++)
					{
						if (eval("document.Form1.RB_1("+i+").checked"))
							window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc="+mc;
					}
				}
			</SCRIPT>
	</HEAD>
	<BODY MS_POSITIONING="GridLayout" onload="click_rb()">
		<FORM id="Form1" method="post" runat="server">
			<INPUT type="hidden" name="cs1" value="#fffff0"> <INPUT type="hidden" name="cs2" value="white">
			<INPUT type="hidden" name="cs3" value="#e5ebf4"> <INPUT type="hidden" name="cs4" value="whitesmoke">
			<TABLE id="Table1" width="96%" border="0">
				<TR>
					<TD class=tdNoBorder align=right><A href="/SME/Body.aspx" ><IMG src="/SME/Image/MainMenu.jpg" ></A><A href="/SME/Logout.aspx" target=_top ><IMG src="/SME/Image/Logout.jpg" ></A></TD></TR>
				</TR>
				<TR>
					<TD colspan="2">
						<TABLE cellpadding="2" cellspacing="2" border="1" width="100%" align="center">
							<TR>
								<TD class="tdHeader1" colspan="2" align="center">
									<B>EASY SERVICE MANAGEMENT DASHBOOARD</B></TD>
							</TR>
							<TR runat="server" id="TR_PARAMETER">
								<TD id="id01" class="TDBGColor1" align="center"><INPUT type="radio" value="ParameterReport.aspx" name="RB_1"></TD>
								<TD id="id02" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label0" runat="server"> Parameter Audit Trail Report</asp:Label></TD>
							</TR>
							<TR runat="server" id="TR_SELF">
								<TD id="id11" class="TDBGColor1" align="center"><INPUT type="radio" value="SelfReport.aspx" name="RB_1"></TD>
								<TD id="id12" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label1" runat="server"> Self Assessment Report</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_INTERNAL">
								<TD id="id21" class="TDBGColor1" align="center"><INPUT type="radio" value="InternalReport.aspx" name="RB_1"></TD>
								<TD id="id22" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label2" runat="server"> Internal Customer Score</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_SCORE">
								<TD id="id31" class="TDBGColor1" align="center"><INPUT type="radio" value="ScoreReport.aspx" name="RB_1"></TD>
								<TD id="id32" class="TDBGColorValue">&nbsp;
									<asp:Label id="Label3" runat="server"> Overall Jiwa Service Score</asp:Label>
								</TD>
							</TR>
							<TR runat="server" id="TR_PENDING">
								<TD class="TDBGColor1" id="id41" align="center"><INPUT type="radio" value="PendingReport.aspx" name="RB_1"></TD>
								<TD id="id42" class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label4" runat="server"> Pending Task List</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2" colSpan="2" height="90%" align="center">&nbsp;<INPUT class="BUTTON1" type="button" value="VIEW" onclick="view_report('<%=Request.QueryString["mc"] %>')"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
