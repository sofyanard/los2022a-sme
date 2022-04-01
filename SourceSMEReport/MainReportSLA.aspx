<%@ Page language="c#" Codebehind="MainReportSLA.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.MainReportSLA" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainReportSLA</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
        /*
		function click_rb()
		{
			for ( i=0 ; i<13; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
				{
					eval("id"+i+"2.style.fontWeight		= 700");
					eval("id"+i+"1.style.backgroundColor= document.Form1.cs1.value");
					eval("id"+i+"2.style.backgroundColor= document.Form1.cs1.value");
				}
				else
				{
					eval("id"+i+"2.style.fontWeight		= 500");
					eval("id"+i+"1.style.backgroundColor= document.Form1.cs3.value");
					eval("id"+i+"2.style.backgroundColor= document.Form1.cs2.value");
				}
			}
		}

		function mouse_over(i)
		{
			eval("id"+i+"1.style.backgroundColor= document.Form1.cs4.value");
			eval("id"+i+"2.style.backgroundColor= document.Form1.cs4.value");
		}

		function klik(i)
		{
			eval("document.Form1.RB_1("+i+").checked=true");
		}

		function mouse_out(i)
		{
			if (eval("document.Form1.RB_1("+i+").checked"))
				click_rb();
			else
			{
				eval("id"+i+"1.style.backgroundColor= document.Form1.cs3.value");
				eval("id"+i+"2.style.backgroundColor= document.Form1.cs2.value");
			}
		}

		function view_report(mc, bu)
		{
			for ( i=0 ; i<13; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
					window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc="+mc + "&BU=" + bu;
			}
		}*/
		function click_rb() {
		    if (document.getElementsByName('RB_1')[i].checked) {
		        document.getElementById('id' + i + '2').style.fontWeight = 700;
		        document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs1")[0].value;
		        document.getElementById('id' + i + '2').style.backgroundColor = document.getElementsByName("cs1")[0].value;
		    }
		    else {
		        document.getElementById('id' + i + '2').style.fontWeight = 500;
		        document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs3")[0].value;
		        document.getElementById('id' + i + '2').style.backgroundColor = document.getElementsByName("cs2")[0].value;
		    }
		}

		function mouse_over(i) {
		    document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs4")[0].value;
		    document.getElementById('id' + i + '2').style.backgroundColor = document.getElementsByName("cs4")[0].value;
		}

		function klik(i) {
		    document.getElementsByName('RB_1')[i].checked = true;
		}

		function mouse_out(i) {
		    if (document.getElementsByName('RB_1')[i].checked) {
		        click_rb();
		    }
		    else {
		        document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs3")[0].value;
		        document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs2")[0].value;
		    }
		}

		function view_report(mc, bu) {
		    for (i = 0; i < 31; i++) {
		        if (document.getElementsByName('RB_1')[i].checked) {
		            window.location = document.getElementsByName('RB_1')[i].value + "?mc=" + mc + "&BU=" + bu;
		        }
		    }
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="click_rb()">
		<form id="Form1" method="post" runat="server">
			<input type="hidden" name="cs1" value="#fffff0"> <input type="hidden" name="cs2" value="white">
			<input type="hidden" name="cs3" value="#e5ebf4"> <input type="hidden" name="cs4" value="whitesmoke">
			<TABLE id="Table4" width="96%" border="0">
				<TR>
					<TD width="105" height="35" style="WIDTH: 105px"></TD>
					<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colspan="2">
						<table cellpadding="2" cellspacing="2" border="1" width="100%" align="center">
							<TR>
								<TD class="tdHeader1" colspan="2" align="center">SLA REPORTING</TD>
							</TR>
							<TR>
								<TD id="id01" onmouseover="mouse_over('0')" onmouseout="mouse_out('0')" onclick="klik('0')"
									class="TDBGColor1" align="center" width="50"><INPUT type="radio" value="RptSLABussinessUNit.aspx" name="RB_1" onclick="click_rb()">&nbsp;</TD>
								<td id="id02" onmouseover="mouse_over('0')" onmouseout="mouse_out('0')" onclick="klik('0')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="LBL_1" runat="server">SLA - Business Unit</asp:Label></td>
							</TR>
							<TR>
								<TD id="id11" onmouseover="mouse_over('1')" onmouseout="mouse_out('1')" onclick="klik('1')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="RPTSLABICKBUCO.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id12" onmouseover="mouse_over('1')" onmouseout="mouse_out('1')" onclick="klik('1')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label3" runat="server">SLA - BI Checking From BU to CO</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD id="id21" onmouseover="mouse_over('2')" onmouseout="mouse_out('2')" onclick="klik('2')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="RPTSLABICKCOBU.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id22" onmouseover="mouse_over('2')" onmouseout="mouse_out('2')" onclick="klik('2')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label4" runat="server">SLA - BI Checking From CO to BI</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD id="id31" onmouseover="mouse_over('3')" onmouseout="mouse_out('3')" onclick="klik('3')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="RptCollAppraisal.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id32" onmouseover="mouse_over('3')" onmouseout="mouse_out('3')" onclick="klik('3')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label5" runat="server">SLA - Collaterals Appraisal From BU to CO</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD id="id41" onmouseover="mouse_over('4')" onmouseout="mouse_out('4')" onclick="klik('4')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="RptCollApprAgency.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id42" onmouseover="mouse_over('4')" onmouseout="mouse_out('4')" onclick="klik('4')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label6" runat="server">SLA - Collaterals Appraisal From CO to Agency</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id51" onmouseover="mouse_over('5')" onclick="klik('5')" onmouseout="mouse_out('5')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptSLACRMApproval.aspx" name="RB_1"></TD>
								<TD id="id52" onmouseover="mouse_over('5')" onmouseout="mouse_out('5')" onclick="klik('5')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label7" runat="server">SLA PRRK / CRA</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id61" onmouseover="mouse_over('6')" onclick="klik('6')" onmouseout="mouse_out('6')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptCOBookingProc.aspx" name="RB_1"></TD>
								<TD id="id62" onmouseover="mouse_over('6')" onmouseout="mouse_out('6')" onclick="klik('6')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label1" runat="server">SLA CO Booking Process</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id71" onmouseover="mouse_over('7')" onclick="klik('7')" onmouseout="mouse_out('7')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptSLACRM.aspx" name="RB_1"></TD>
								<TD id="id72" onmouseover="mouse_over('7')" onmouseout="mouse_out('7')" onclick="klik('7')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label2" runat="server">SLA CRM</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id81" onmouseover="mouse_over('8')" onclick="klik('8')" onmouseout="mouse_out('8')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptSPPKSentReceipt.aspx" name="RB_1"></TD>
								<TD id="id82" onmouseover="mouse_over('8')" onmouseout="mouse_out('8')" onclick="klik('8')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label88" runat="server">SLA SPPK Sent - Received Report</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id91" onmouseover="mouse_over('9')" onclick="klik('9')" onmouseout="mouse_out('9')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RpttSLAAggrMntr.aspx" name="RB_1"></TD>
								<TD id="id92" onmouseover="mouse_over('9')" onmouseout="mouse_out('9')" onclick="klik('9')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label98" runat="server">SLA Agreement Signing Monitoring Report</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id101" onmouseover="mouse_over('10')" onclick="klik('10')"
									onmouseout="mouse_out('10')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptSLACO.aspx" name="RB_1"></TD>
								<TD id="id102" onmouseover="mouse_over('10')" onmouseout="mouse_out('10')" onclick="klik('10')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label108" runat="server">SLA for CO Report</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id111" onmouseover="mouse_over('11')" onclick="klik('11')"
									onmouseout="mouse_out('11')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptOverallSLA.aspx" name="RB_1"></TD>
								<TD id="id112" onmouseover="mouse_over('11')" onmouseout="mouse_out('11')" onclick="klik('11')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label118" runat="server">Overrall SLA Report</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id121" onmouseover="mouse_over('12')" onclick="klik('12')"
									onmouseout="mouse_out('12')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptExportDataOther.aspx" name="RB_1"></TD>
								<TD id="id122" onmouseover="mouse_over('12')" onmouseout="mouse_out('12')" onclick="klik('12')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label9" runat="server">Other BU Report</asp:Label>
								</TD>
							</TR>
							<TR>
								<!--AHMAD 2-->
								<TD class="TDBGColor2" colSpan="2" height="90%" align="center">&nbsp;<INPUT class="BUTTON1" type="button" value="VIEW REPORT" onclick="view_report('<%=Request["mc"]%>','<%=Request["BU"]%>')"></TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
			<CENTER></CENTER>
		</form>
	</body>
</HTML>
