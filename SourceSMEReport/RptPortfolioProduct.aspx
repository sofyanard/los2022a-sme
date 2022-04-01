<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="RptPortfolioProduct.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPortfolioProduct" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPortfolioProduct</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_INDUSTRY_NAME.value	= "";
			document.Form1.DDL_CL.value	= "";
			document.Form1.DDL_NCL.value	= "";
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
									<TD class="tdHeader1">PORTFOLIO PER PRODUCT
										<asp:label id="Label1" runat="server" Visible="False">Label</asp:label><asp:label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:label></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 233px; HEIGHT: 12px">Industry Name</TD>
													<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:dropdownlist id="DDL_INDUSTRY_NAME" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 233px">Product Cash Loan</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 233px">Product Non Cash Loan</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_NCL" runat="server"></asp:dropdownlist></TD>
												</TR> <!-- Additional Field : Right --></TBODY></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="60px" Text="Find" onclick="BTN_SAVE_Click"></asp:button>&nbsp;<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Clear" name="Button2">&nbsp;
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
