<%@ Page language="c#" Codebehind="CandMEXIMBILL.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.CandMEXIMBILL" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CandMEXIMBILL</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="50%" border="1">
								<TR>
									<TD class="tdHeader1">EXIMBILL APPLICATION DATA</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR id="TR_UNIT" runat="server">
												<TD class="TDBGColor1" width="50%">Unit :</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_UNIT" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR id="TR_STATUS" runat="server">
												<TD class="TDBGColor1" width="50%">Status Data :</TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_STATUS" runat="server" AutoPostBack="false"></asp:dropdownlist></TD>
											</TR>
											<!-- Additional Field : Right -->
											<TR>
												<TD vAlign="top" align="center" colSpan="3"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
													<asp:button id="BTN_FIND" runat="server" Text="Find" CssClass="Button1" Width="100px" onclick="BTN_FIND_Click"></asp:button>&nbsp;
													<asp:button id="BTN_CANCEL" Text="Cancel" CssClass="Button1" Runat="server" Width="100px" onclick="BTN_CANCEL_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD vAlign="top" colSpan="2"><cc1:reportviewer id="Reportviewer1" runat="server" Height="510px" Parameters="False" Width="100%"
								Toolbar="Default"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
