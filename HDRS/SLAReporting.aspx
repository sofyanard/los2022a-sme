<%@ Page language="c#" Codebehind="SLAReporting.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.SLAReporting" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SLAReporting</title>
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
									<TD class="tdHeader1">SLA HRS REPORTING</TD>
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
												<TD class="TDBGColor1" width="170">Problem Type :</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROB" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">PIC Group :</TD>
												<TD style="HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_PIC2" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_PIC2_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">PIC HRS :</TD>
												<TD style="HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_PIC" Runat="server"></asp:dropdownlist></TD>
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
						<TD vAlign="top" colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Height="510px" Parameters="False"
								Toolbar="Default"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
