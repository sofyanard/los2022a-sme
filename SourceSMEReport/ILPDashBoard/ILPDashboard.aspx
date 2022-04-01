<%@ Page language="c#" Codebehind="ILPDashboard.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.ILPDashBoard.ILPDashboard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ILPDashboard</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
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

		function view_report(mc, bu)
		{
			for ( i=0 ; i<31; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
					window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc=" + mc + "&BU=" + bu;
//				    window.location	=  eval("document.Form1.RB_1("+i+").value") + "?Posisi="+i
 		    }
		}
		</script>
	</HEAD>
	<body onload="click_rb()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<input type="hidden" value="#fffff0" name="cs1"> <input type="hidden" value="white" name="cs2">
			<input type="hidden" value="#e5ebf4" name="cs3"> <input type="hidden" value="whitesmoke" name="cs4">
			<!--<center> -->
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 105px" width="105" height="35"></TD>
					<td align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colSpan="2">
						<table cellSpacing="2" cellPadding="2" width="100%" border="1">
							<TR>
								<TD class="tdHeader1" colSpan="4" align="center">ILP Dashboard</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id01" onmouseover="mouse_over('0')" onclick="klik('0')" onmouseout="mouse_out('0')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" CHECKED value="ExportDataeMas.aspx" name="RB_1"></TD>
								<td class="TDBGColorValue" id="id02" onmouseover="mouse_over('0')" onclick="klik('0')"
									onmouseout="mouse_out('0')" style="WIDTH: 48%">&nbsp;
									<asp:label id="LBL_1" runat="server">Export Data eMas</asp:label></td>
								<TD class="TDBGColor1" id="id11" onmouseover="mouse_over('1')" onclick="klik('1')" onmouseout="mouse_out('1')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptScoringProcess.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id12" onmouseover="mouse_over('1')" onclick="klik('1')"
									onmouseout="mouse_out('1')" style="WIDTH: 48%">&nbsp;
									<asp:label id="Label3" runat="server">Scoring Process</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" onmouseover="mouse_over('2')" onclick="klik('2')" onmouseout="mouse_out('2')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptILPUtilizationNew.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('2')" onclick="klik('2')"
									onmouseout="mouse_out('2')" style="WIDTH: 48%">&nbsp;
									<asp:label id="Label4" runat="server">ILP Utilization (Permohonan Baru)</asp:label></TD>
								<TD class="TDBGColor1" id="id31" onmouseover="mouse_over('3')" onclick="klik('3')" onmouseout="mouse_out('3')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptRatingProcess.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id32" onmouseover="mouse_over('3')" onclick="klik('3')"
									onmouseout="mouse_out('3')" style="WIDTH: 48%">&nbsp;
									<asp:label id="Label5" runat="server">Rating Process</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id41" onmouseover="mouse_over('4')" onclick="klik('4')" onmouseout="mouse_out('4')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptILPUtilizationLimit.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id42" onmouseover="mouse_over('4')" onclick="klik('4')"
									onmouseout="mouse_out('4')" style="WIDTH: 48%">&nbsp;
									<asp:label id="Label6" runat="server">ILP Utilization (Perubahan Limit)</asp:label></TD>
								<TD class="TDBGColor1" id="id51" onmouseover="mouse_over('5')" onclick="klik('5')" onmouseout="mouse_out('5')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptReviewRisk.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id52" onmouseover="mouse_over('5')" onclick="klik('5')"
									onmouseout="mouse_out('5')" style="WIDTH: 48%">&nbsp;
									<asp:label id="Label1" runat="server">Review Risk</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id61" onmouseover="mouse_over('6')" onclick="klik('6')" onmouseout="mouse_out('6')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptILPUtilizationRenewal.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id62" onmouseover="mouse_over('6')" onclick="klik('6')"
									onmouseout="mouse_out('6')" style="WIDTH: 48%">&nbsp;
									<asp:label id="Label2" runat="server">ILP Utilization (Perpanjangan)</asp:label></TD>
								<TD class="TDBGColor1" id="id71" onmouseover="mouse_over('7')" onclick="klik('7')" onmouseout="mouse_out('7')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptReviewCreditOperation.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id72" onmouseover="mouse_over('7')" onclick="klik('7')"
									onmouseout="mouse_out('7')" style="WIDTH: 48%">&nbsp;&nbsp;
									<asp:label id="Label777" runat="server">Review Credit Operation</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id81" onmouseover="mouse_over('8')" onclick="klik('8')" onmouseout="mouse_out('8')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptTATEndToEndProcess.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id82" onmouseover="mouse_over('8')" onclick="klik('8')"
									onmouseout="mouse_out('8')" style="WIDTH: 48%">&nbsp;&nbsp;
									<asp:label id="Label8" runat="server">TAT End To End Process</asp:label></TD>
								<TD class="TDBGColor1" id="id91" onmouseover="mouse_over('9')" onclick="klik('9')" onmouseout="mouse_out('9')"
									align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptPosisiAgunan.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id92" onmouseover="mouse_over('9')" onclick="klik('9')"
									onmouseout="mouse_out('9')" style="WIDTH: 48%">&nbsp;&nbsp;
									<asp:label id="Label7" runat="server">Posisi Agunan</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id101" onmouseover="mouse_over('10')" onclick="klik('10')"
									onmouseout="mouse_out('10')" align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptAttachmentNotaAnalisa.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id102" onmouseover="mouse_over('10')" onclick="klik('10')"
									onmouseout="mouse_out('10')" style="WIDTH: 48%">&nbsp;&nbsp;
									<asp:label id="Label99" runat="server">Attachment Nota Analisa</asp:label></TD>
								<TD class="TDBGColor1" id="id111" onmouseover="mouse_over('11')" onclick="klik('11')"
									onmouseout="mouse_out('11')" align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptCollateralCoverage.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id112" onmouseover="mouse_over('11')" onclick="klik('11')"
									onmouseout="mouse_out('11')" style="WIDTH: 48%">&nbsp;&nbsp;
									<asp:label id="Label109" runat="server">Collateral Coverage</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id121" onmouseover="mouse_over('12')" onclick="klik('12')"
									onmouseout="mouse_out('12')" align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptVerificatorProcess.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id122" onmouseover="mouse_over('12')" onclick="klik('12')"
									onmouseout="mouse_out('12')" style="WIDTH: 48%">&nbsp;&nbsp;
									<asp:label id="Label129" runat="server">Verificator Process</asp:label></TD>
								<TD class="TDBGColor1" id="id131" onmouseover="mouse_over('13')" onclick="klik('13')"
									onmouseout="mouse_out('13')" align="center" style="WIDTH: 3%"></TD>
								<TD class="TDBGColorValue" id="id132" onmouseover="mouse_over('13')" onclick="klik('13')"
									onmouseout="mouse_out('13')" style="WIDTH: 48%">&nbsp;&nbsp;</TD>
							</TR>
							<TR runat="server" id="TR_1">
								<TD class="TDBGColor1" id="id141" onmouseover="mouse_over('14')" onclick="klik('14')"
									onmouseout="mouse_out('14')" align="center" style="WIDTH: 3%"><INPUT onclick="click_rb()" type="radio" value="RptVerificatorProcess.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id142" onmouseover="mouse_over('14')" onclick="klik('14')"
									onmouseout="mouse_out('14')" style="WIDTH: 48%">&nbsp;&nbsp;
									<asp:label id="Label16" runat="server">Verificator Process</asp:label></TD>
								<TD class="TDBGColor1" id="id151" style="WIDTH: 3%"></TD>
								<TD class="TDBGColorValue" id="id152" style="WIDTH: 48%">&nbsp;&nbsp;</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2" colSpan="4" height="90%" align="center">
									<INPUT class="BUTTON1" onclick="view_report('<%=Request["mc"]%>','<%=Request["BU"]%>')" type="button" value="VIEW REPORT">
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</TABLE>
			<CENTER></CENTER>
		</form>
	</body>
</HTML>
