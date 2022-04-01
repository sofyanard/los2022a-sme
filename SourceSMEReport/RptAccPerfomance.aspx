<%@ Page language="c#" Codebehind="RptAccPerfomance.aspx.cs" AutoEventWireup="True" Inherits="SourceSMEReport.RptAccPerfomance" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptAccPerfomance</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function Batal()
		{
			//document.Form1.TXT_TGL1.value	= "";
			//document.Form1.DDL_BLN1.value	= "";
			//document.Form1.TXT_THN1.value	= "";
			//document.Form1.TXT_TGL2.value	= "";
			//document.Form1.DDL_BLN2.value	= "";
			//document.Form1.TXT_THN2.value	= "";
			document.Form1.DDL_Branch.value	= "";
			document.Form1.DDL_AREA.value	= "";
			document.Form1.DDL_UNIT.value	= "";
		}
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" --><LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table10" style="WIDTH: 978px; HEIGHT: 112px" height="112" cellSpacing="0" cellPadding="0"
					width="978" border="0">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td style="HEIGHT: 3px" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table1" height="180" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">--></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" colSpan="2">
										ANALYST PERFORMANCE REPORT
										<asp:label id="Label1" runat="server" Visible="False">Label</asp:label><asp:label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:label></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1">DDE End Date</TD>
									</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" Columns="2" CssClass="mandatory"
											MaxLength="2" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" CssClass="mandatory"
											MaxLength="4" Width="45px"></asp:textbox>&nbsp;To
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" Columns="2" CssClass="mandatory"
											MaxLength="2" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" CssClass="mandatory"
											MaxLength="4" Width="45px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px">Region</TD>
									<TD style="HEIGHT: 18px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_AREA" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_AREA_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR> <!-- Additional Field : Right -->
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Cabang/CBC/Group</TD>
									<TD style="HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:dropdownlist id="DDL_Branch" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_Branch_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TEAM" runat="server"></asp:dropdownlist></TD>
								</TR>
								<!--											
											<TR>
												<TD class="TDBGColor1">PS</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_UNIT" runat="server">
														<asp:ListItem Value="PS">PS</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
-->
								<!-- Additional Field : Right -->
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="60px" Text="Find" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;
							<asp:button id="Btn_Print" runat="server" CssClass="Button1" Width="60px" Text="Print" onclick="Btn_Print_Click"></asp:button></TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR align="center" height="400">
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
