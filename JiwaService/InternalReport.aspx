<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="InternalReport.aspx.cs" AutoEventWireup="True" Inherits="SME.JiwaService.InternalReport" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>InternalReport</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
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
							<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="750" border="1" height="195">
								<TR>
									<TD class="tdHeader1">INTERNAL CUSTOMER SCORE REPORTING</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="25%" style="HEIGHT: 15px">Provider Group Name :</TD>
												<TD class='A"TDBGColorValue"' width="75%" style="HEIGHT: 15px"><asp:DropDownList ID="DDL_GROUP" Runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="DDL_GROUP_SelectedIndexChanged"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="25%" style="HEIGHT: 15px">Provider Department Name :</TD>
												<TD class='A"TDBGColorValue"' width="75%" style="HEIGHT: 15px"><asp:DropDownList ID="DDL_DEPT" Runat="server" Width="100%"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="25%" style="HEIGHT: 15px">Internal Customer Name :</TD>
												<TD class='A"TDBGColorValue"' width="75%" style="HEIGHT: 15px"><asp:DropDownList ID="DDL_BRANCH" Runat="server" Width="100%"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="25%">Scoring Date :</TD>
												<TD class="TDBGColorValue" width="75%">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" MaxLength="2" Columns="2" Width="5%"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN1" runat="server" Width="25%"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" MaxLength="4" Columns="4" Width="10%"></asp:textbox>&nbsp; 
													to &nbsp;
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" MaxLength="2" Columns="2" Width="5%"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN2" runat="server" Width="25%"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" MaxLength="4" Columns="4" Width="10%"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
													<asp:button id="BTN_Find" runat="server" Text="Find" Width="80px" CssClass="button1" onclick="BTN_Find_Click"></asp:button>&nbsp;&nbsp;
													<asp:Button id="BTN_Cancel" runat="server" Width="80px" Text="Cancel" CssClass="button1" onclick="BTN_Cancel_Click"></asp:Button>
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
