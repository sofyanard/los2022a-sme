<%@ Page language="c#" Codebehind="JiwaServiceScoreBoard.aspx.cs" AutoEventWireup="True" Inherits="SME.JiwaService.JiwaServiceScoreBoard" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>JiwaServiceScoreBoard</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- set up the jquery -->
		<script src="../jQuery/Main/jquery-1.7.1.min.js" type="text/javascript"></script>
		<script src="../jQuery/Chart/highcharts.js" type="text/javascript"></script>
		<script src="../jQuery/Chart/highchartThemes/gray.js" type="text/javascript"></script>
		<script src="../jQuery/Chart/modules/exporting.js" type="text/javascript"></script>
		<!-- hide the box with CSS -->
		<LINK rel="stylesheet" type="text/css" href="../CSS/pras.css">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>SCORE BOARD</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">PROVIDER INFORMATION</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Name :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAME" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Group Name :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_GROUP" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Department Name :</TD>
									<TD class='A"TDBGColorValue"' width="50%"><asp:dropdownlist id="DDL_DEPT_NAME" runat="server" CssClass="Mandatory" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Information Date :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DATE" runat="server" ReadOnly="True" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><asp:label id="LBL_DEPT" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
				<TABLE id="Table5" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2"></TD>
						<!--<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2"><asp:button id="BTN_RETRIEVE" runat="server" Width="100px" CssClass="Button1" Text="RETRIEVE"></asp:button>--> 
						</TD>
					</TR>
				</TABLE>
				<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<div id="container" style="MARGIN: 0px auto; WIDTH: 800px; HEIGHT: 400px" runat="server"></div>
						<asp:TextBox id="internalcustomer" CssClass="tobehide" runat="server"></asp:TextBox>
						<asp:TextBox id="validation" CssClass="tobehide" runat="server"></asp:TextBox>
						<asp:TextBox id="selfassesment" CssClass="tobehide" runat="server"></asp:TextBox>
						<asp:TextBox id="undefined" CssClass="tobehide" runat="server"></asp:TextBox>
					</TR>
				</TABLE>
				<TABLE id="Table7" cellSpacing="2" cellPadding="2" width="100%">
					<TR id="TR_SCORING" runat="server">
						<TD><asp:label id="BOBOT_SELF" runat="server" Visible="False"></asp:label><asp:label id="BOBOT_INTERNAL" runat="server" Visible="False"></asp:label><asp:label id="BOBOT_VALIDATION" runat="server" Visible="False"></asp:label></TD>
						<td><asp:label id="TXT_SCORE_SELF" runat="server"></asp:label><asp:label id="TXT_SCORE_INTERNAL" runat="server"></asp:label><asp:label id="TXT_SCORE_VALIDATION" runat="server"></asp:label></td>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%">Total Score :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_SCORE" runat="server" ReadOnly="True" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%">Category :</TD>
									<TD class="TDBGColorValue" width="50%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CATEGORY" runat="server" ReadOnly="True" Width="100%" ForeColor="#ff0000"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
		<script type="text/javascript">
							var chart;
							
							$(document).ready(function() {
							var selfassesment;
							var internalcustomer;
							var validation;
							//var undefined;
							
								selfassesment = parseInt($("#selfassesment").val());
								internalcustomer = parseInt($("#internalcustomer").val());
								validation = parseInt($("#validation").val()); 
								//undefined = parseInt($("#undefined").val()); 
							
								chart = new Highcharts.Chart({
									chart: {
										renderTo: 'container',
										plotBackgroundColor: null,
										plotBorderWidth: null,
										plotShadow: false
									},
									title: {
										text: ''
									},
									tooltip: {
										formatter: function() {
											return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';
										}
									},
									plotOptions: {
										pie: {
											allowPointSelect: true,
											cursor: 'pointer',
											dataLabels: {
												enabled: true,
												color: '#000000',
												connectorColor: '#000000',
												formatter: function() {
													return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %';
												}
											}
										}
									},
									series: [{
										type: 'pie',
										name: '',
										data: [
											['Self Assessment', selfassesment],
											['Internal Customer', internalcustomer],
											//['Undefined', undefined],
											{
												name: 'Validation',    
												y: validation,
												sliced: true,
												selected: true
											}
										]
									}]
								});
							}
							);
		</script>
	</BODY>
</HTML>
