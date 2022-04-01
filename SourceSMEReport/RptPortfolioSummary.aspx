<%@ Page language="c#" Codebehind="RptPortfolioSummary.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPortfolioSummary" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPortfolioSummary</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{

			document.Form1.DDL_INDUSTRYNAME.value = "";
			document.Form1.DDL_KSEBI4.value	= "";
		}
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD style="HEIGHT: 204px" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1"><asp:label id="LBL_INDUSTRY" runat="server" Visible="False"></asp:label><asp:label id="LBL_KSEBI" runat="server" Visible="False"></asp:label>PORTFOLIO 
										SUMMARY&nbsp;PER INDUSTRY CLASS&nbsp;
									</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1">Position Date</TD>
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL1" runat="server" CssClass="mandatory" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_THN1" runat="server" CssClass="mandatory" Width="40px"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="60px" Text="Find" onclick="BTN_SAVE_Click"></asp:button>&nbsp;<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;
						</TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR align="center">
					<TD colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Parameters="False" Height="510px"></cc1:reportviewer></TD>
				</TR>
				</TBODY></TABLE></center>
		</form>
	</body>
</HTML>
