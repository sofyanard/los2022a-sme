<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="UnitReporting.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.UnitReporting" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UnitReporting</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="BTN_Back" runat="server" ImageUrl="../Image/Back.jpg" onclick="BTN_Back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" valign="middle" colSpan="2">
							<TABLE class="td" id="Table1" height="130" cellSpacing="1" cellPadding="1" width="550"
								border="1">
								<TR>
									<TD class="tdHeader1">
										UNIT PERFORMANCE REPORTING</TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="170">
													Segment&nbsp;:</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEGMENT" AutoPostBack="True" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">Area&nbsp;:</TD>
												<TD style="HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_AREA" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_AREA_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">Unit&nbsp;:</TD>
												<TD style="HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_UNIT" Runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_CANCEL" runat="server" CssClass="button1" Width="80px" Text="CANCEL" onclick="BTN_CANCEL_Click"></asp:button>&nbsp;<asp:button id="Button3" runat="server" CssClass="button1" Width="80px" Text="PRINT" Visible="False"></asp:button>&nbsp;<asp:button id="BTN_FIND" runat="server" CssClass="button1" Width="80px" Text="FIND" onclick="BTN_FIND_Click"></asp:button></TD>
					</TR>
					<TR align="center">
						<TD vAlign="top" colSpan="2"><cc1:reportviewer id="ReportViewer2" runat="server" Width="100%" Toolbar="Default" Parameters="False"
								Height="510px"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
