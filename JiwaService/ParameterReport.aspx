<%@ Page language="c#" Codebehind="ParameterReport.aspx.cs" AutoEventWireup="false" Inherits="SME.JiwaService.ParameterReport" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ParameterReport</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg"></asp:imagebutton><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="550" border="1" height="195">
								<TR>
									<TD class="tdHeader1">PARAMETER AUDIT TRAIL REPORT</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="20%" style="HEIGHT: 15px">Parameter :</TD>
												<TD class='A"TDBGColorValue"' width="80%"><asp:DropDownList ID="DDL_PARAMETER" Runat="server" AutoPostBack="True" CssClass="Mandatory" Width="100%"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="20%" style="HEIGHT: 15px">Date :</TD>
												<TD class="TDBGColorValue" width="80%">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" MaxLength="2" Columns="2"
														width="5%"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN1" runat="server" width="25%"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" MaxLength="4" Columns="4"
														width="10%"></asp:textbox>
													to
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" MaxLength="2" Columns="2"
														width="5%"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN2" runat="server" width="25%"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" MaxLength="4" Columns="4"
														width="10%"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px" width="20%">User :</TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 15px" width="80%"><asp:DropDownList ID="DDL_USER" Runat="server" Width="100%"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
													<asp:button id="BTN_Find" runat="server" Text="Find" Width="80px" CssClass="button1"></asp:button>&nbsp;&nbsp;
													<asp:Button id="BTN_Cancel" runat="server" Width="80px" Text="Cancel" CssClass="button1"></asp:Button>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD vAlign="top" colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Toolbar="Default" Parameters="False"
								Height="510px"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
