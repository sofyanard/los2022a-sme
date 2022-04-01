<%@ Page language="c#" Codebehind="MainReportDQA2.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.DQA.MainReportDQA2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainReportDQA2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
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
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="click_rb()">
		<form id="Form1" method="post" runat="server">
			<input type="hidden" name="cs1" value="#fffff0"> <input type="hidden" name="cs2" value="white">
			<input type="hidden" name="cs3" value="#e5ebf4"> <input type="hidden" name="cs4" value="whitesmoke">
			<TABLE id="Table4" width="96%" border="0">
				<TR>
					<TD width="146" height="35" style="WIDTH: 146px"></TD>
					<td align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colspan="2">
						<table cellpadding="2" cellspacing="2" border="1" width="100%" align="center">
							<TR>
								<TD class="tdHeader1" colspan="2" align="center">
									CONTROL &amp; MONITORING</TD>
							</TR>
							<TR>
								<TD id="id01" onmouseover="mouse_over('0')" onmouseout="mouse_out('0')" onclick="klik('0')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="BUCDana.aspx" name="RB_1" onclick="click_rb()"></TD>
								<td id="id02" onmouseover="mouse_over('0')" onmouseout="mouse_out('0')" onclick="klik('0')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label0" runat="server"> BUC Dana</asp:Label></td>
							</TR>
							<TR>
								<TD id="id11" onmouseover="mouse_over('1')" onmouseout="mouse_out('1')" onclick="klik('1')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="BUCKredit.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id12" onmouseover="mouse_over('1')" onmouseout="mouse_out('1')" onclick="klik('1')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label1" runat="server"> BUC Kredit</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD id="id21" onmouseover="mouse_over('2')" onmouseout="mouse_out('2')" onclick="klik('2')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="CIFDana.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id22" onmouseover="mouse_over('2')" onmouseout="mouse_out('2')" onclick="klik('2')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label2" runat="server"> CIF Dana</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD id="id31" onmouseover="mouse_over('3')" onmouseout="mouse_out('3')" onclick="klik('3')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="CIFKredit.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id32" onmouseover="mouse_over('3')" onmouseout="mouse_out('3')" onclick="klik('3')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label3" runat="server"> CIF Kredit</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id41" onmouseover="mouse_over('4')" onclick="klik('4')" onmouseout="mouse_out('4')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="Perkreditan.aspx" name="RB_1"></TD>
								<TD id="id42" onmouseover="mouse_over('4')" onmouseout="mouse_out('4')" onclick="klik('4')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label4" runat="server"> Perkreditan</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id51" onmouseover="mouse_over('5')" onclick="klik('5')" onmouseout="mouse_out('5')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="Agunan.aspx" name="RB_1"></TD>
								<TD id="id52" onmouseover="mouse_over('5')" onmouseout="mouse_out('5')" onclick="klik('5')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label5" runat="server"> Agunan</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id61" onmouseover="mouse_over('6')" onclick="klik('6')" onmouseout="mouse_out('6')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="ILPErrorChecking.aspx" name="RB_1"></TD>
								<TD id="id62" onmouseover="mouse_over('6')" onmouseout="mouse_out('6')" onclick="klik('6')"
									class="TDBGColorValue">&nbsp;&nbsp;
									<asp:Label id="Label6" runat="server"> ILP Error Checking</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2" colSpan="2" height="90%" align="center">&nbsp;<INPUT class="BUTTON1" type="button" value="VIEW REPORT" onclick="view_report()"></TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
			<CENTER></CENTER>
		</form>
	</body>
</HTML>
