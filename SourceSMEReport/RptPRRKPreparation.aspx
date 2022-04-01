<%@ Page language="c#" Codebehind="RptPRRKPreparation.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPRRKPreparation" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPRRKPreparation</title>
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
			document.Form1.DDL_CBC.value		= "";
			document.Form1.DDL_BRANCH.value	= "";
			document.Form1.DDL_TEAM.value	= "";
			document.Form1.DDL_PS.value		= "";
			
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
						<td align="right"><asp:imagebutton id="btn_Back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_Back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td vAlign="top" align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="550">
								<TR>
									<TD class="tdHeader1">
										PRRK PREPARATION&nbsp;REPORT
										<asp:label id="Label1" runat="server" Visible="False">Label</asp:label>
										<asp:Label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:Label></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1">IDE Start Date</TD>
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL1" runat="server" CssClass="mandatory" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_THN1" runat="server" CssClass="mandatory" Width="40px"></asp:textbox>&nbsp;To
										<asp:textbox id="TXT_TGL2" runat="server" CssClass="mandatory" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_THN2" runat="server" CssClass="mandatory" Width="60px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 16px">Region</TD>
									<TD style="HEIGHT: 16px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_REGION" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REGION_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">CBC</TD>
									<TD style="HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:dropdownlist id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 16px">Cabang/CBC/Group</TD>
									<TD style="HEIGHT: 16px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_BRANCH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TEAM" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">PS</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PS" runat="server"></asp:dropdownlist></TD>
								</TR> <!-- Additional Field : Right -->
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Width="60px" Text="Find" onclick="BTN_LIHAT_Click"></asp:button>&nbsp;
							<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;
							<asp:button id="Btn_Print" runat="server" CssClass="Button1" Width="60px" Text="Print" onclick="Btn_Print_Click"></asp:button></TD>
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
	</body>
</HTML>
