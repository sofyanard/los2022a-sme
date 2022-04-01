<%@ Page language="c#" Codebehind="TesChart.aspx.cs" AutoEventWireup="True" Inherits="SME.TesChart" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TesChart</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- set up the jquery -->
		<script src="jQuery/Main/jquery-1.7.1.min.js" type="text/javascript"></script>
		<script src="jQuery/Chart/highcharts.js" type="text/javascript"></script>
		<script src="jQuery/Chart/highchartThemes/gray.js" type="text/javascript"></script>
		<script type="text/javascript" src="jQuery/Chart/modules/exporting.js"></script>
		<!-- hide the box with CSS -->
		<link rel="stylesheet" type="text/css" href="CSS/pras.css"/>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<div id="container" style="MARGIN: 0px auto; WIDTH: 800px; HEIGHT: 400px"></div>
			<asp:TextBox id="internalcustomer" CssClass="tobehide" runat="server"></asp:TextBox>
			<asp:TextBox id="validation" CssClass="tobehide" runat="server"></asp:TextBox>
			<asp:TextBox id="selfassesment" CssClass="tobehide" runat="server"></asp:TextBox>
		</form>
		<script type="text/javascript">
			var chart;
			
			$(document).ready(function() {
			var selfassesment;
			var internalcustomer;
			var validation;
			
				selfassesment = parseInt($("#selfassesment").val());
				internalcustomer = parseInt($("#internalcustomer").val());
				validation = parseInt($("#validation").val()); 
			
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
	</body>
</HTML>
