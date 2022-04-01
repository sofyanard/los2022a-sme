<%@ Page language="c#" Codebehind="ChooseDataType.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.Facilities.InquiryDataDictionary.ChooseDataType" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainReportDQA</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
		<!-- <script language="javascript">
		function view_report(mc, bu)
		{
			for ( i=0 ; i<13; i++)
			{
				if (eval("document.Form1.RB_1("+i+").checked"))
					window.location	= eval("document.Form1.RB_1("+i+").value") + "?mc="+mc + "&BU=" + bu;
			}
		}
		</script>-->
	</HEAD>
	<body onload="click_rb()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD style="WIDTH: 146px" width="146" height="35"></TD>
					<td align="right"><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td colSpan="2">
						<table id="TBL_MainTable" cellSpacing="2" cellPadding="2" width="100%" align="center" border="1"
							runat="server">
							<TR>
								<TD class="tdHeader1" align="center" colSpan="2">DATA TYPE
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
