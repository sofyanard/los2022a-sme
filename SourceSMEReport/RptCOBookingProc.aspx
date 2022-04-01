<%@ Page language="c#" Codebehind="RptCOBookingProc.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptCOBookingProc" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCOBookingProc</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_REGION.value	= "";
			document.Form1.DDL_CBC.value	= "";
			document.Form1.DDL_Branch.value	= "";
			document.Form1.DDL_TEAM.value	= "";
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
						<td align="right">
							<asp:ImageButton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2" align="center" height="197" style="HEIGHT: 197px">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="550" height="160">
								<TBODY>
									<TR>
										<TD class="tdHeader1" colSpan="2">
											<asp:Label id="LBL_CBC" runat="server" Visible="False">LBL_CBC</asp:Label>
											<asp:Label id="LBL_BRANCH" runat="server" Visible="False">LBL_BRANCH</asp:Label>
											<asp:Label id="LBL_REGION" runat="server" Visible="False">LBL_REGION</asp:Label>SLA 
											CO BOOKING PROCESS REPORT
											<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label>
											<asp:Label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:Label></TD>
									</TR>
									<TR>
										<TD class="td" style="HEIGHT: 63px" vAlign="top" width="50%">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
												<TBODY>
													<TR>
														<TD class="TDBGColor1" style="HEIGHT: 23px">IDE Start Date</TD>
										</TD>
										<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox id="TXT_Day1" runat="server" Width="32px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_Month1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_Year1" runat="server" Width="48px" CssClass="mandatory"></asp:textbox>&nbsp;TO
											<asp:textbox id="TXT_Day2" runat="server" Width="38px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_Month2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_Year2" runat="server" Width="60px" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 18px">Region</TD>
										<TD style="HEIGHT: 18px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 18px">
											<asp:DropDownList id="DDL_REGION" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REGION_SelectedIndexChanged"></asp:DropDownList></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 15px">CBC</TD>
										<TD style="HEIGHT: 15px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Cabang/CBC/Group</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BRANCH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Team</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:DropDownList id="DDL_TEAM" runat="server"></asp:DropDownList></TD>
									</TR> <!-- Additional Field : Right --></TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Text=" Find " onclick="BTN_LIHAT_Click"></asp:button>
							&nbsp; <input type="button" id="Button2" name="Button2" Value="Cancel" Class="Button1" onClick="Batal()">
							&nbsp;<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print" onclick="Btn_Print_Click"></asp:button>
						</TD>
					</TR>
					</TD></TR>
				</TABLE>
				<TR align="center">
					<TD vAlign="top" colSpan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
                    </TD>
				</TR>
				</TBODY></TABLE>
			</center>
		</form>
	</body>
</HTML>
