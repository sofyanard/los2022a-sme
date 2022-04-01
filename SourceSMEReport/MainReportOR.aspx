<%@ Page language="c#" Codebehind="MainReportOR.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.MainReportOR" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainReportOR</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function click_rb()
		{
		    for (i = 0; i < 29; i++) {
		        /*
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
		        }*/
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
		}

		function mouse_over(i)
		{
		    //eval("id"+i+"1.style.backgroundColor= document.Form1.cs4.value");
		    document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs4")[0].value;
		    //eval("id" + i + "2.style.backgroundColor= document.Form1.cs4.value");
		    document.getElementById('id' + i + '2').style.backgroundColor = document.getElementsByName("cs4")[0].value;
		}

		function klik(i)
		{
		    //eval("document.Form1.RB_1("+i+").checked=true");
		    document.getElementsByName('RB_1')[i].checked = true;
		}

		/*function mouse_out(i)
		{
			if (eval("document.Form1.RB_1("+i+").checked"))
				click_rb();
			else
			{
				eval("id"+i+"1.style.backgroundColor= document.Form1.cs3.value");
				eval("id"+i+"2.style.backgroundColor= document.Form1.cs2.value");
			}
		}*/
		function mouse_out(i) {
		    if (document.getElementsByName('RB_1')[i].checked) 
            {
		        click_rb();
		    }
		    else {
		        document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs3")[0].value;
		        document.getElementById('id' + i + '1').style.backgroundColor = document.getElementsByName("cs2")[0].value;
		    }
		}

        /*
		function view_report(mc, bu)
		{
			for ( i=0 ; i<31; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
					window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc=" + mc + "&BU=" + bu;
//				    window.location	=  eval("document.Form1.RB_1("+i+").value") + "?Posisi="+i
 		    }
		}*/

		function view_report(mc, bu) 
        {
            for (i = 0; i < 31; i++) 
            {
		        if (document.getElementsByName('RB_1')[i].checked) {
		            window.location = document.getElementsByName('RB_1')[i].value + "?mc=" + mc + "&BU=" + bu;
                }
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
					<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colSpan="2">
						<table cellSpacing="2" cellPadding="2" width="100%" border="1">
							<TR>
								<TD class="tdHeader1" colSpan="4" align="center">OPERATIONAL&nbsp;REPORTING</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id01" onmouseover="mouse_over('0')" onclick="klik('0')" onmouseout="mouse_out('0')" align="center">
                                    <INPUT onclick="click_rb()" type="radio" CHECKED value="RptBussinesUnit.aspx" name="RB_1">
                                </TD>
								<td class="TDBGColorValue" id="id02" onmouseover="mouse_over('0')" onclick="klik('0')" onmouseout="mouse_out('0')">
									<asp:label id="LBL_1" runat="server">Business Unit BI Request Report</asp:label>
                                </td>
								<TD class="TDBGColor1" id="id11" onmouseover="mouse_over('1')" onclick="klik('1')" onmouseout="mouse_out('1')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptCOBIRequest.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id12" onmouseover="mouse_over('1')" onclick="klik('1')"
									onmouseout="mouse_out('1')">&nbsp;
									<asp:label id="Label3" runat="server">CO BI Request Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id21" onmouseover="mouse_over('2')" onclick="klik('2')" onmouseout="mouse_out('2')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptBUApprReq.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id22" onmouseover="mouse_over('2')" onclick="klik('2')"
									onmouseout="mouse_out('2')">&nbsp;
									<asp:label id="Label4" runat="server">Business Unit Appraisal Request Report</asp:label></TD>
								<TD class="TDBGColor1" id="id31" onmouseover="mouse_over('3')" onclick="klik('3')" onmouseout="mouse_out('3')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptCoApprReq.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id32" onmouseover="mouse_over('3')" onclick="klik('3')"
									onmouseout="mouse_out('3')">&nbsp;
									<asp:label id="Label5" runat="server">CO Appraisal Request Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id41" onmouseover="mouse_over('4')" onclick="klik('4')" onmouseout="mouse_out('4')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptCustResponse.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id42" onmouseover="mouse_over('4')" onclick="klik('4')"
									onmouseout="mouse_out('4')">&nbsp;
									<asp:label id="Label6" runat="server"> SPPK Response Report</asp:label></TD>
								<TD class="TDBGColor1" id="id51" onmouseover="mouse_over('5')" onclick="klik('5')" onmouseout="mouse_out('5')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptBooking.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id52" onmouseover="mouse_over('5')" onclick="klik('5')"
									onmouseout="mouse_out('5')">&nbsp;
									<asp:label id="Label1" runat="server">Booking Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id61" onmouseover="mouse_over('6')" onclick="klik('6')" onmouseout="mouse_out('6')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptAccPerfomance.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id62" onmouseover="mouse_over('6')" onclick="klik('6')"
									onmouseout="mouse_out('6')">&nbsp;
									<asp:label id="Label2" runat="server">Analyst / Public Accountant Performance Report</asp:label></TD>
								<TD class="TDBGColor1" id="id71" onmouseover="mouse_over('7')" onclick="klik('7')" onmouseout="mouse_out('7')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptCoNotaryMntr.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id72" onmouseover="mouse_over('7')" onclick="klik('7')"
									onmouseout="mouse_out('7')">&nbsp;&nbsp;
									<asp:label id="Label777" runat="server">CO Notary Monitoring Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id81" onmouseover="mouse_over('8')" onclick="klik('8')" onmouseout="mouse_out('8')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptOpeDetail.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id82" onmouseover="mouse_over('8')" onclick="klik('8')"
									onmouseout="mouse_out('8')">&nbsp;&nbsp;
									<asp:label id="Label8" runat="server">Daily Position Report (Detail)</asp:label></TD>
								<TD class="TDBGColor1" id="id91" onmouseover="mouse_over('9')" onclick="klik('9')" onmouseout="mouse_out('9')"
									align="center"><INPUT onclick="click_rb()" type="radio" value="RptInsuranceMntr.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id92" onmouseover="mouse_over('9')" onclick="klik('9')"
									onmouseout="mouse_out('9')">&nbsp;&nbsp;
									<asp:label id="Label7" runat="server">Credit Operation - Insurance Monitoring Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id101" onmouseover="mouse_over('10')" onclick="klik('10')"
									onmouseout="mouse_out('10')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptRMApprovalAppeal.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id102" onmouseover="mouse_over('10')" onclick="klik('10')"
									onmouseout="mouse_out('10')">&nbsp;&nbsp;
									<asp:label id="Label99" runat="server">Regional Manager - Approval Report (Appeal)</asp:label></TD>
								<TD class="TDBGColor1" id="id111" onmouseover="mouse_over('11')" onclick="klik('11')"
									onmouseout="mouse_out('11')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptPenolakanKredit.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id112" onmouseover="mouse_over('11')" onclick="klik('11')"
									onmouseout="mouse_out('11')">&nbsp;&nbsp;
									<asp:label id="Label109" runat="server">Laporan Penolakan Kredit</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id121" onmouseover="mouse_over('12')" onclick="klik('12')"
									onmouseout="mouse_out('12')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptBUApproval.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id122" onmouseover="mouse_over('12')" onclick="klik('12')"
									onmouseout="mouse_out('12')">&nbsp;&nbsp;
									<asp:label id="Label129" runat="server">BU Approval Report</asp:label></TD>
								<TD class="TDBGColor1" id="id131" onmouseover="mouse_over('13')" onclick="klik('13')"
									onmouseout="mouse_out('13')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptRMApproval.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id132" onmouseover="mouse_over('13')" onclick="klik('13')"
									onmouseout="mouse_out('13')">&nbsp;&nbsp;
									<asp:label id="Label139" runat="server">CRM Approval Report</asp:label></TD>
							</TR>
							<!--Begin Pipeline Summary-->
							<TR>
								<TD class="TDBGColor1" id="id141" onmouseover="mouse_over('14')" onclick="klik('14')"
									onmouseout="mouse_out('14')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptPipeLine1Summ.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id142" onmouseover="mouse_over('14')" onclick="klik('14')"
									onmouseout="mouse_out('14')">&nbsp;&nbsp;
									<asp:label id="Label16" runat="server">Pipeline Report by CBC/Branches Summary (Cash Loan and Non Cash Loan)</asp:label></TD>
								<TD class="TDBGColor1" id="id151" onmouseover="mouse_over('15')" onclick="klik('15')"
									onmouseout="mouse_out('15')" align="center">
									<INPUT onclick="click_rb()" type="radio" value="RptPipeLinePerProductSumm.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id152" onmouseover="mouse_over('15')" onclick="klik('15')"
									onmouseout="mouse_out('15')">&nbsp;&nbsp;
									<asp:label id="Label10" runat="server">Pipeline Report by Product Summary (Cash Loan and Non Cash Loan)</asp:label></TD>
							</TR>
							<!--End Pipeline Summary-->
							<TR>
								<TD class="TDBGColor1" id="id161" onmouseover="mouse_over('16')" onclick="klik('16')"
									onmouseout="mouse_out('16')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptPipeLine1.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id162" onmouseover="mouse_over('16')" onclick="klik('16')"
									onmouseout="mouse_out('16')">&nbsp;&nbsp;
									<asp:label id="Label169" runat="server">Pipeline Report by CBC/Branches Detail (Cash Loan and Non Cash Loan)</asp:label></TD>
								<TD class="TDBGColor1" id="id171" onmouseover="mouse_over('17')" onclick="klik('17')"
									onmouseout="mouse_out('17')" align="center">
									<INPUT onclick="click_rb()" type="radio" value="RptPipeLinePerProduct.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id172" onmouseover="mouse_over('17')" onclick="klik('17')"
									onmouseout="mouse_out('17')">&nbsp;&nbsp;
									<asp:label id="Label179" runat="server">Pipeline Report by Product Detail (Cash Loan and Non Cash Loan)</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id181" onmouseover="mouse_over('18')" onclick="klik('18')"
									onmouseout="mouse_out('18')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptScorePerformance.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id182" onmouseover="mouse_over('18')" onclick="klik('18')"
									onmouseout="mouse_out('18')">&nbsp;&nbsp;
									<asp:label id="Label189" runat="server">Scoring Performance Report</asp:label></TD>
								<TD class="TDBGColor1" id="id191" onmouseover="mouse_over('19')" onclick="klik('19')"
									onmouseout="mouse_out('19')" align="center">
									<INPUT onclick="click_rb()" type="radio" value="RpteBizCard.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id192" onmouseover="mouse_over('19')" onclick="klik('19')"
									onmouseout="mouse_out('19')">&nbsp;&nbsp;
									<asp:label id="Label190" runat="server">eBiz Card Holder Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id201" onmouseover="mouse_over('20')" onclick="klik('20')"
									onmouseout="mouse_out('20')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptPRRKPreparation.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id202" onmouseover="mouse_over('20')" onclick="klik('20')"
									onmouseout="mouse_out('20')">&nbsp;&nbsp;
									<asp:label id="Label20" runat="server">PRRK Preparation Report</asp:label></TD>
								<TD class="TDBGColor1" id="id211" onmouseover="mouse_over('21')" onclick="klik('21')"
									onmouseout="mouse_out('21')" align="center">
									<INPUT onclick="click_rb()" type="radio" value="RptPSPerformance.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id212" onmouseover="mouse_over('21')" onclick="klik('21')"
									onmouseout="mouse_out('21')">&nbsp;&nbsp;
									<asp:label id="Label21" runat="server">PS Performance Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id221" onmouseover="mouse_over('22')" onclick="klik('22')"
									onmouseout="mouse_out('22')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptBPRChanneling.aspx" name="RB_1" ></TD>
								<TD class="TDBGColorValue" id="id222" onmouseover="mouse_over('22')" onclick="klik('22')"
									onmouseout="mouse_out('22')">&nbsp;&nbsp;
									<asp:label id="Label220" runat="server">BPR Channeling - Batch Application Report</asp:label></TD>
								<TD class="TDBGColor1" id="id231" onmouseover="mouse_over('23')" onclick="klik('23')"
									onmouseout="mouse_out('23')" align="center">
									<INPUT onclick="click_rb()" type="radio" value="RptDocumentTracking.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id232" onmouseover="mouse_over('23')" onclick="klik('23')"
									onmouseout="mouse_out('23')">&nbsp;&nbsp;
									<asp:label id="Label2310" runat="server">Document Tracking Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id241" onmouseover="mouse_over('24')" onclick="klik('24')"
									onmouseout="mouse_out('24')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptDisbursementBranch.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id242" onmouseover="mouse_over('24')" onclick="klik('24')"
									onmouseout="mouse_out('24')">&nbsp;&nbsp;
									<asp:label id="Label249" runat="server">Disbursement Report by Kantor Pusat/Kanwil, Branches</asp:label></TD>
								<TD class="TDBGColor1" id="id251" onmouseover="mouse_over('25')" onclick="klik('25')"
									onmouseout="mouse_out('25')" align="center">
									<INPUT onclick="click_rb()" type="radio" value="RptDisbursementProd.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id252" onmouseover="mouse_over('25')" onclick="klik('25')"
									onmouseout="mouse_out('25')">&nbsp;&nbsp;
									<asp:label id="Label250" runat="server">Disbursement Report by Kantor Pusat/Kanwil, Product</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id261" onmouseover="mouse_over('26')" onclick="klik('26')"
									onmouseout="mouse_out('26')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptAuditTrial.aspx" name="RB_1" ></TD>
								<TD class="TDBGColorValue" id="id262" onmouseover="mouse_over('26')" onclick="klik('26')"
									onmouseout="mouse_out('26')">&nbsp;&nbsp;
									<asp:label id="Label26" runat="server">Audit Trail Report</asp:label></TD>
								<TD class="TDBGColor1" id="id271" onmouseover="mouse_over('27')" onclick="klik('27')"
									onmouseout="mouse_out('27')" align="center">
									<INPUT onclick="click_rb()" type="radio" value="RptApplicationTracking.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id272" onmouseover="mouse_over('27')" onclick="klik('27')"
									onmouseout="mouse_out('27')">&nbsp;&nbsp;
									<asp:label id="Label27" runat="server">Application Tracking Report</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id281" onmouseover="mouse_over('28')" onclick="klik('28')"
									onmouseout="mouse_out('28')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptKoperasi.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id282" onmouseover="mouse_over('28')" onclick="klik('28')"
									onmouseout="mouse_out('28')">&nbsp;&nbsp;
									<asp:label id="Label28" runat="server">Relationship - Kelompok & Koperasi Report</asp:label></TD>
								<TD class="TDBGColor1" id="id291" align="center">&nbsp;</TD>
								<TD class="TDBGColorValue" id="id292">&nbsp;&nbsp;
									<asp:label id="Label29" runat="server">&nbsp;</asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" id="id301" onmouseover="mouse_over('30')" onclick="klik('30')"
									onmouseout="mouse_out('30')" align="center"><INPUT onclick="click_rb()" type="radio" value="RptPipelinePerProductStage.aspx" name="RB_1"></TD>
								<TD class="TDBGColorValue" id="id302" onmouseover="mouse_over('30')" onclick="klik('30')"
									onmouseout="mouse_out('30')">&nbsp;&nbsp;
									<asp:label id="Label30" runat="server">Pipeline - by stage</asp:label></TD>
								<TD class="TDBGColor1" id="id311" align="center">&nbsp;</TD>
								<TD class="TDBGColorValue" id="id312">&nbsp;&nbsp;
									<asp:label id="Label31" runat="server">&nbsp;</asp:label></TD>
							</TR>
							<!--								
								<TR>
									<TD class="TDBGColor1" id="id91" onmouseover="mouse_over('9')" onclick="klik('9')" onmouseout="mouse_out('9')"><INPUT onclick="click_rb()" type="radio" value="RptORDocTrack.aspx" name="RB_1"></TD>
									<TD class="TDBGColorValue" id="id92" onmouseover="mouse_over('9')" onclick="klik('9')"
										onmouseout="mouse_out('9')">&nbsp;&nbsp;
										<asp:label id="Label9" runat="server">Document Tracking Report</asp:label></TD>
								</TR>
-->
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
