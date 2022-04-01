<%@ Page language="c#" Codebehind="RptCOBIRequest.aspx.cs" AutoEventWireup="true" Inherits="SourceSMEReport.RptCOBIRequest" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptCOBIRequest</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
			document.Form1.DDL_BRANCH.value		= "";
			document.Form1.DDL_RM.value	= "";
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
							<asp:ImageButton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td vAlign="top" align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1"><asp:label id="LBL_CBC" runat="server" Visible="False"></asp:label><asp:label id="LBL_BRANCH" runat="server" Visible="False"></asp:label><asp:label id="LBL_RM" runat="server" Visible="False"></asp:label>
										<asp:Label id="LBL_REGION" runat="server" Visible="False">LBL_REGION</asp:Label>CO 
										BI REQUEST REPORT
										<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label>
										<asp:Label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:Label></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1">BI Request Date</TD>
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" Width="30px" CssClass="mandatory"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" Width="40px" CssClass="mandatory"
											MaxLength="4"></asp:textbox>&nbsp;To
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" Width="30px" CssClass="mandatory"
											MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" Width="40px" CssClass="mandatory"
											MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Region</TD>
									<TD style="HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px">
										<asp:DropDownList id="DDL_REGION" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REGION_SelectedIndexChanged"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Area</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 12px">Branch</TD>
									<TD style="HEIGHT: 12px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:dropdownlist id="DDL_BRANCH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR> <!-- Additional Field : Right -->
								<TR>
									<TD class="TDBGColor1">AO</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_RM" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center">
							<asp:button id="BTN_SAVE" runat="server" Text="Find" CssClass="Button1" Width="60px" onclick="BTN_SAVE_Click"></asp:button>
							<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">
							<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print" onclick="Btn_Print_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR align="center">
					<TD colSpan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
					</TD>
				</TR>
				</TBODY></TABLE>
			</center>
		</form>
	</body>
</HTML>
