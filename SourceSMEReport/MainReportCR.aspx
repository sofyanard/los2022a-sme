<%@ Page language="c#" Codebehind="MainReportCR.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.MainReportCR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainReportCR</title>
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
			for ( i=0 ; i<=2; i++)
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
			for ( i=0 ; i<=2; i++)
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
					<td align="right">&nbsp;&nbsp; <A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colspan="2">
						<table cellpadding="2" cellspacing="2" border="1" width="100%">
							<TR>
								<TD class="tdHeader1" colspan="2">CHARACTERISTIC&nbsp;REPORTING</TD>
							</TR>
							<TR>
								<TD id="id01" class="TDBGColor1" align="center" width="50" 
									onmouseover="mouse_over('0')"
									onclick="klik('0')" 
									onmouseout="mouse_out('0')"><INPUT type="radio" CHECKED value="RptDataAnalysis.aspx" name="RB_1" onclick="click_rb()">&nbsp;</TD>
								<td id="id02" class="TDBGColorValue" onmouseover="mouse_over('0')" onclick="klik('0')"
									onmouseout="mouse_out('0')">&nbsp;
									<asp:Label id="LBL_0" runat="server">Data Analysis Report</asp:Label></td>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id11" 
									onmouseover="mouse_over('1')" align="center" 
									onclick="klik('1')"
									onmouseout="mouse_out('1')"><INPUT onclick="click_rb()" type="radio" value="RptCaracterAnalysis.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id12" onmouseover="mouse_over('1')" onclick="klik('1')"
									onmouseout="mouse_out('1')">&nbsp;&nbsp;
									<asp:label id="LBL_1" runat="server">Characteristic Analysis Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" 
									onmouseover="mouse_over('2')" align="center" 
									onclick="klik('2')"
									onmouseout="mouse_out('2')"><INPUT onclick="click_rb()" type="radio" value="RptExportData.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('2')" onclick="klik('2')"
									onmouseout="mouse_out('2')">&nbsp;&nbsp;
									<asp:label id="LBL_2" runat="server">Other POR Report</asp:label></TD>
							</TR>
							<TR>
								<!--AHMAD-->
								<TD class="TDBGColor2" colSpan="2" height="90%">&nbsp;<INPUT class="BUTTON1" type="button" value="VIEW REPORT" onclick="view_report('<%=Request["mc"]%>','<%=Request["BU"]%>')"></TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
