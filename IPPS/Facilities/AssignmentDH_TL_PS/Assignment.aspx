<%@ Page language="c#" Codebehind="Assignment.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Facilities.AssignmentDH_TL_PS.Assignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Assignment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE width="100%" border="0">
				<TR>
					<TD align="left" width="50%">
						<TABLE id="Table1">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="/sme/Body.aspx"><IMG src="/sme/Image/MainMenu.jpg"></A>
						<A href="/sme/Logout.aspx" target="_top"><IMG src="/sme/Image/Logout.jpg"></A>
					</TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colspan="2"></TD>
				</TR>
			</TABLE>
			<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="50%" border="0">
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px" width="40%"><asp:label id="LBL_TXT_Reference" runat="server">Reference# :</asp:label></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px" width="60%"><asp:textbox id="TXT_Reference" Runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 7px" width="40%"><asp:label id="LBL_TXT_Requester_Unit" runat="server">Requester Unit :</asp:label></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 7px" width="60%"><asp:textbox id="TXT_Requester_Unit" Runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%">Current Track :</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%"><asp:textbox id="TXT_Current_Track" Runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%">Current DH PP :</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%">
										<asp:dropdownlist id="ddl_Current_DH_PP" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%">Current Secretaries PP :</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%">
										<asp:dropdownlist id="ddl_Current_Secretaries_PP" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%">Current TL/PS PP :</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%"><asp:textbox id="txt_Current_TLPS_PP" Runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%">Current DH Reviewer :</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%">
										<asp:dropdownlist id="ddl_Current_DH_Reviewer" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%">Current PIC Reviewer :</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%">
										<asp:dropdownlist id="ddl_Current_PIC_Reviewer" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 3px" width="40%">Current Admin KMS :</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 3px" width="60%">
										<asp:dropdownlist id="DDL_Current_Admin_KMS" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TBODY>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<table width="100%">
				<tr>
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
						<asp:button id="BTN_assign" runat="server" Text="Assign" CssClass="button1"></asp:button>&nbsp;&nbsp;</TD>
				</tr>
			</table>
		</FORM>
	</BODY>
</HTML>
