<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="RptPortfolioCollCov.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPortfolioCollCov" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPortfolioCollCov</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			//document.Form1.TXT_TGL1.value	= "";
			//document.Form1.DDL_BLN1.value	= "";
			//document.Form1.TXT_THN1.value	= "";
			//document.Form1.TXT_TGL2.value	= "";
			//document.Form1.DDL_BLN2.value	= "";
			//document.Form1.TXT_THN2.value	= "";
			document.Form1.DDL_REGION.value	= "";
			document.Form1.DDL_CBC.value	= "";
			document.Form1.DDL_BRANCH.value	= "";
			document.Form1.DDL_TEAM.value	= "";
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
						<td align="right">
							<asp:ImageButton id="btn_back" runat="server" ImageUrl="../image/back.jpg"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2" align="center" style="HEIGHT: 204px">
							<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1">
										<asp:Label id="LBL_CBC" runat="server" Visible="False"></asp:Label>
										<asp:Label id="LBL_BRANCH" runat="server" Visible="False"></asp:Label>
										<asp:Label id="LBL_REGION" runat="server" Visible="False">LBL_REGION</asp:Label>
										PORTFOLIO COLLATERAL COVERAGE
										<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label>
										<asp:Label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:Label>
									</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1">Industry Name</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue">
														<asp:DropDownList id="DropDownList1" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Group</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue">
														<asp:DropDownList id="DropDownList2" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">BUC</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue">
														<asp:DropDownList id="DropDownList3" runat="server" AutoPostBack="True"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 15px">
														Position Date</TD>
									</TD>
									<TD style="WIDTH: 15px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:textbox id="TXT_TGL1" runat="server" Width="30px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_THN1" runat="server" Width="40px" CssClass="mandatory"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right -->
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center">
							<asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="60px" Text="Find"></asp:button>
							&nbsp;<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;
							<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print"></asp:button>
						</TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR align="center">
					<TD colSpan="2">
						<cc1:ReportViewer id="ReportViewer1" runat="server" Width="100%" Height="510px" Parameters="False"></cc1:ReportViewer>
					</TD>
				</TR>
				</TBODY></TABLE>
			</center>
		</form>
	</body>
</HTML>
