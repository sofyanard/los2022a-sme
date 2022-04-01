<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="RptPortfolioBUC.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPortfolioBUC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPortfolioBUC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_INDUSTRY_NAME.value	= "";
			document.Form1.DDL_SEGMENT.value		= "";
			document.Form1.DDL_BUC.value			= "";
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
									<TD class="tdHeader1"><asp:label id="LBL_BUC" runat="server" Visible="False"></asp:label><asp:label id="LBL_GROUP" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGION" runat="server" Visible="False">LBL_REGION</asp:label>PORTFOLIO 
										PER BUC
									</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 235px">Industry Name</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_INDUSTRY_NAME" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 235px">Segment</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEGMENT" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SEGMENT_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 235px">BUC</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUC" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR> <!-- Additional Field : Right --></TBODY></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="BTN_SAVE" runat="server" Text="Find" Width="60px" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Clear" name="Button2">&nbsp;
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Parameters="False" Height="510px"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
