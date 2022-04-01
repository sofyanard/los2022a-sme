<%@ Page language="c#" Codebehind="RptCollAppraisal.aspx.cs" AutoEventWireup="True" Inherits="SourceSMEReport.RptCollAppraisal" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCollAppraisal</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY>
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
			document.Form1.DDL_Branch.value	= "";
			document.Form1.DDL_TEAM.value	= "";
		}
		</script>
		<!-- #include file="../include/cek_all.html"-->
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right">
							<asp:ImageButton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2" align="center" height="160">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="550" height="160">
								<TR>
									<TD class="tdHeader1" colSpan="2">
										<asp:Label id="LBL_CBC" runat="server" Visible="False">LBL_CBC</asp:Label>
										<asp:Label id="LBL_BRANCH" runat="server" Visible="False">LBL_BRANCH</asp:Label>
										<asp:Label id="LBL_REGION" runat="server" Visible="False">LBL_REGION</asp:Label>COLLATERAL 
										APPRAISAL FROM BU TO CO REPORT
										<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label>
										<asp:Label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:Label></TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 63px" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 23px">Appraisal Req Date</TD>
									</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox id="TXT_Day1" onkeypress="return numbersonly()" runat="server" Width="32px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_Month1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_Year1" runat="server" onkeypress="return numbersonly()" Width="48px" CssClass="mandatory"></asp:textbox>&nbsp;TO
										<asp:textbox id="TXT_Day2" onkeypress="return numbersonly()" runat="server" Width="38px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_Month2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_Year2" onkeypress="return numbersonly()" runat="server" Width="60px" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 15px">Region</TD>
									<TD style="HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px">
										<asp:DropDownList id="DDL_REGION" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REGION_SelectedIndexChanged"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px">CBC</TD>
									<TD style="HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 12px">Cabang/CBC/Group</TD>
									<TD style="HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:dropdownlist id="DDL_BRANCH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_TEAM" runat="server"></asp:DropDownList></TD>
								</TR> <!-- Additional Field : Right -->
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Text=" Find " onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;&nbsp;<INPUT class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;
							<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print" onclick="Btn_Print_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR align="center">
					<TD vAlign="top" colSpan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
                    </TD>
				</TR>
				</TBODY></TABLE>
			</center>
		</form>
	</BODY>
</HTML>
