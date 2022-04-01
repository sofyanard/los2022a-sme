<%@ Page language="c#" Codebehind="ControlAndMonitoring.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.ControlAndMonitoring" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>ControlAndMonitoring</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function click_rb()
		{
			for ( i=0 ; i<29; i++)
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

		function view_report(mc)
		{
			for ( i=0 ; i<29; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
					window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc=" + mc;
					//window.location	=  eval("document.Form1.RB_1("+i+").value") + "?Posisi="+i
 		    }
		}
		</script>
	</HEAD>
	<BODY onload="click_rb()" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<input type="hidden" name="cs1" value="#fffff0"> <input type="hidden" name="cs2" value="white">
			<input type="hidden" name="cs3" value="#e5ebf4"> <input type="hidden" name="cs4" value="whitesmoke">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD width="146" height="35" style="WIDTH: 146px"></TD>
					<TD align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<TABLE id="TBL_MainTable" cellpadding="2" cellspacing="2" border="1" width="100%" align="center"
							runat="server">
							<TR>
								<TD class="tdHeader1" colspan="2" align="center">
									CONTROL &amp; MONITORING</TD>
							</TR>
							<TR>
								<TD id="id01" onmouseover="mouse_over('0')" onmouseout="mouse_out('0')" onclick="klik('0')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="CandMCAP.aspx" name="RB_1" onclick="click_rb()"></TD>
								<td id="id02" onmouseover="mouse_over('0')" onmouseout="mouse_out('0')" onclick="klik('0')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label0" runat="server"> CAP Application Data</asp:Label></td>
							</TR>
							<TR>
								<TD id="id11" onmouseover="mouse_over('1')" onmouseout="mouse_out('1')" onclick="klik('1')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="CandMEXIMBILL.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id12" onmouseover="mouse_over('1')" onmouseout="mouse_out('1')" onclick="klik('1')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label1" runat="server"> EXIMBILL Application Data</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD id="id21" onmouseover="mouse_over('2')" onmouseout="mouse_out('2')" onclick="klik('2')"
									class="TDBGColor1" align="center"><INPUT type="radio" value="CandMOPICS.aspx" name="RB_1" onclick="click_rb()"></TD>
								<TD id="id22" onmouseover="mouse_over('2')" onmouseout="mouse_out('2')" onclick="klik('2')"
									class="TDBGColorValue">&nbsp;
									<asp:Label id="Label2" runat="server"> OPIC Application Data</asp:Label>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2" colSpan="2" height="90%" align="center">
									<INPUT class="BUTTON1" onclick="view_report('<%=Request["mc"]%>')" type="button" value="VIEW REPORT">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
	</BODY>
</HTML>
