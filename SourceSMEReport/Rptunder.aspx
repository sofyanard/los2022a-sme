<%@ Page language="c#" Codebehind="Rptunder.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.Rptunder" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Rptunder</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.TXT_Day1.value	= "";
			document.Form1.DDL_Month1.value	= "";
			document.Form1.TXT_Year1.value	= "";
			document.Form1.TXT_Day2.value	= "";
			document.Form1.DDL_Month2.value	= "";
			document.Form1.TXT_Year2.value	= "";
			document.Form1.DDL_Branch.value	= "";
			document.Form1.DDL_CBC.value	= "";
		}
		</script>
		<!-- #include file="../include/cek_all.html"-->
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"></A></td>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2" height="160">
							<TABLE id="Table2" height="160" cellSpacing="2" cellPadding="2" width="90%">
								<TBODY>
									<TR>
										<TD class="tdHeader1" colSpan="2" style="HEIGHT: 2px">&nbsp;</TD>
									</TR>
									<TR>
										<TD class="td" style="HEIGHT: 63px" align="center" vAlign="middle" width="80%"><STRONG><FONT size="5">&nbsp;&nbsp;</FONT><FONT size="4">Under 
													Construction</FONT></STRONG>&nbsp;&nbsp;</TD>
									</TR>
									<TR>
										<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp;&nbsp;&nbsp;</TD>
									</TR>
						</TD>
					</TR>
				</TABLE>
				<TR align="center">
					<TD colSpan="2"></TD>
				</TR>
				</TBODY></TABLE></center>
		</form>
	</body>
</HTML>
