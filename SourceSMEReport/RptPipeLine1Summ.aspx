<%@ Page language="c#" Codebehind="RptPipeLine1Summ.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPipeLine1Summ" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPipeLine1Summ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_REGION.value	= "";
			document.Form1.DDL_BUSINESSUNIT.value	= "";
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
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD style="HEIGHT: 121px" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="70%">
								<TBODY>
									<TR>
										<TD class="tdHeader1" colSpan="2">
											<asp:label id="LBL_BU" runat="server" Visible="False" Width="56px">LBL_BU</asp:label>PIPELINE&nbsp;REPORT&nbsp;BY 
											CBC/BRANCHES (SUMMARY)&nbsp;
											<asp:label id="Label1" runat="server" Visible="False">Label</asp:label>
											<asp:Label id="LBL_RM" runat="server" Visible="False">LBL_RM</asp:Label></TD>
									</TR>
									<TR>
										<TD class="td" style="HEIGHT: 36px" vAlign="top" width="70%">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">IDE Start Date</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" Width="30px" CssClass="mandatory"
															MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" Width="45px" CssClass="mandatory"
															MaxLength="4"></asp:textbox>&nbsp;To
														<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" Width="30px" CssClass="mandatory"
															MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" Width="45px" CssClass="mandatory"
															MaxLength="4"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 15px">Region</TD>
													<TD style="HEIGHT: 15px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_REGION" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REGION_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">Business Unit</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_BUSINESSUNIT" runat="server" AutoPostBack="false"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">Area</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 18px">
														<asp:DropDownList id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 1px">Branch</TD>
													<TD style="HEIGHT: 1px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 1px">
														<asp:DropDownList id="DDL_BRANCH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 1px">Team</TD>
													<TD style="HEIGHT: 1px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 1px">
														<asp:DropDownList id="DDL_TEAM" runat="server"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">AO</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 18px">
														<asp:DropDownList id="DDL_RM" runat="server"></asp:DropDownList></TD>
												</TR>
												<!-- Additional Field : Right --></TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Text=" Find " onclick="BTN_LIHAT_Click"></asp:button>&nbsp;
											<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">
											&nbsp;<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print" onclick="Btn_Print_Click"></asp:button>
										</TD>
									</TR>
						</TD>
					</TR>
				</TABLE>
				<TR align="center">
					<TD vAlign="top" colSpan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
                    </TD>
				</TR>
				</TBODY></TABLE></center>
		</form>
	</body>
</HTML>
