<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="EndUserReporting.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.EndUserReporting" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EndUserReporting</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
						<TD vAlign="middle" align="center" colSpan="2">
							<TABLE class="td" id="Table1" height="130" cellSpacing="1" cellPadding="1" width="550"
								border="1">
								<TR>
									<TD class="tdHeader1">END USER PERFORMANCE REPORTING</TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">HRS Received Date :</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" CssClass="mandatory"
														MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" CssClass="mandatory"
														MaxLength="4" Columns="4"></asp:textbox>&nbsp; to &nbsp;
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" CssClass="mandatory"
														MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" CssClass="mandatory"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="170">Segment&nbsp;:</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEGMENT" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SEGMENT_SelectedIndexChanged"></asp:dropdownlist></TD>
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
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_CANCEL" runat="server" CssClass="button1" Text="CANCEL" Width="80px" onclick="BTN_CANCEL_Click"></asp:button>&nbsp;<asp:button id="BTN_PRINT" runat="server" CssClass="button1" Text="PRINT" Width="80px" Visible="False"></asp:button>&nbsp;<asp:button id="BTN_FIND" runat="server" CssClass="button1" Text="FIND" Width="80px" onclick="BTN_FIND_Click"></asp:button></TD>
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
