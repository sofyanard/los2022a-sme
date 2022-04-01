<%@ Page language="c#" Codebehind="RptBPRChanneling.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptBPRChanneling" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptBPRChanneling</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_COMPNAME.value	= "";
			document.Form1.DDL_FACILITY.value	= "";
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
						<TD style="HEIGHT: 149px" vAlign="top" align="center" colSpan="2" height="149">
							<TABLE id="Table1" height="160" cellSpacing="2" cellPadding="2" width="70%">
								<TBODY>
									<TR>
										<TD class="tdHeader1" colSpan="2">BPR CHANNELING -&nbsp; BATCH 
											APPLICATION&nbsp;REPORT&nbsp;
											<asp:label id="Label1" runat="server" Visible="False">Label</asp:label><asp:label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:label></TD>
									</TR>
									<TR>
										<TD class="td" style="HEIGHT: 63px" vAlign="top" width="70%">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">BPR - BPR Name</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_COMPNAME" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_COMPNAME_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 13px">Facility</TD>
													<TD style="HEIGHT: 13px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 13px"><asp:dropdownlist id="DDL_FACILITY" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_FACILITY_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Date of Submission</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL1" runat="server" Width="32px" CssClass="mandatory" ontextchanged="TXT_TGL1_TextChanged"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory" onselectedindexchanged="DDL_BLN1_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="TXT_THN1" runat="server" Width="48px" CssClass="mandatory" ontextchanged="TXT_THN1_TextChanged"></asp:textbox>&nbsp;To
														<asp:textbox id="TXT_TGL2" runat="server" Width="32px" CssClass="mandatory" ontextchanged="TXT_TGL2_TextChanged"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory" onselectedindexchanged="DDL_BLN2_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="TXT_THN2" runat="server" Width="48px" CssClass="mandatory" ontextchanged="TXT_THN2_TextChanged"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Batch No.</TD>
													<TD></TD>
													<TD><asp:dropdownlist id="DDL_BATCHNO" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<!-- Additional Field : Right --></TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" Text=" Find " CssClass="Button1" onclick="BTN_LIHAT_Click"></asp:button>&nbsp;
											<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Batal" name="Button2">
											&nbsp;<asp:button id="Btn_Print" runat="server" Width="60px" Text="Print" CssClass="Button1" onclick="Btn_Print_Click"></asp:button>
										</TD>
									</TR>
						</TD>
					</TR>
				</TABLE>
				<TR align="center">
					<TD colSpan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
                    </TD>
				</TR>
				</TBODY></TABLE></center>
		</form>
	</body>
</HTML>
