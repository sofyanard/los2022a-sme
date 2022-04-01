<%@ Page language="c#" Codebehind="RptAuditTrial.aspx.cs" AutoEventWireup="false" Inherits="SourceSMEReport.RptAuditTrial" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptAuditTrial</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			
			document.Form1.DDL_BRANCH.value		= "";
			document.Form1.DDL_RM.value	= "";
			document.Form1.TXT_APREGNO.value	= "";
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
					<tr>
						<td vAlign="top" align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1">AUDIT TRAIL REPORT&nbsp;</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Track&nbsp;Date</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" MaxLength="2" CssClass="mandatory"
														Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" MaxLength="4" CssClass="mandatory"
														Width="40px"></asp:textbox>&nbsp;To
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" MaxLength="2" CssClass="mandatory"
														Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" MaxLength="4" CssClass="mandatory"
														Width="40px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px">Application No</TD>
												<TD style="HEIGHT: 14px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="TXT_APREGNO" 
                                                        runat="server" MaxLength="19" Width="200px"></asp:textbox></TD>
											</TR> <!-- Additional Field : Right -->
											<TR>
												<TD class="TDBGColor1">PIC</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_RM" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="60px" Text="Find" onclick="BTN_SAVE_Click"></asp:button>&nbsp;<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;
										<asp:button id="Btn_Print" runat="server" CssClass="Button1" Width="60px" Text="Print" onclick="Btn_Print_Click"></asp:button></TD>
								</TR>
							</TABLE>
							<asp:dropdownlist id="DDL_BRANCH" runat="server" AutoPostBack="True" Visible="False" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:dropdownlist>
						</td>
					</tr>
					<TR align="center">
						<TD colSpan="2">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
                        </TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
