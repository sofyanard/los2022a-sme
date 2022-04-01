<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="EXPORT_RORAC.aspx.cs" AutoEventWireup="True" Inherits="SME.RORAC.EXPORT_RORAC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Report RORAC Result</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Style.css">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" border="0" width="100%">
					<TR>
						<TD align="left">
							<TABLE id="Table3">
								<TR>
									<TD style="WIDTH: 400px" class="tdBGColor2" align="center"><B>Report RORAC Result</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="td" border="1" cellSpacing="1" cellPadding="1" width="590" height="195">
					<TR>
						<TD class="tdHeader1">Search Criteria</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Business Unit</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="_ddlBisnisUnit" runat="server" Width="300px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Region</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="_ddlRegion" runat="server" Width="300px" AutoPostBack="True" onselectedindexchanged="_ddlRegion_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">CBC</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="_ddlCBC" runat="server" Width="300px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Branch</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="_ddlBranch" runat="server" Width="300px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">RM</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="_ddlRM" runat="server" Width="300px" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">CIF No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="_txtCIF" runat="server" Width="200px" MaxLength="40"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemohon</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="_txtNamaPemohon" runat="server" Width="200px" MaxLength="40"></asp:textbox></TD>
								</TR>
								<TR>
									<TD height="5" vAlign="top" colSpan="3" align="center"></TD>
								</TR>
								<TR>
									<TD height="10" vAlign="top" colSpan="3" align="center"><asp:button id="btn_Find" runat="server" Width="180px" CssClass="button1" Text="Find " onclick="btn_Find_Click"></asp:button>&nbsp;
										<asp:button id="BTN_CLEAR" runat="server" Width="180px" CssClass="button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<br>
				<center>
					<table cellSpacing="0" cellPadding="10" width="100%" align="center">
						<TR align="center">
							<TD colSpan="2">
								<cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Height="510px" Parameters="False"></cc1:reportviewer></TD>
						</TR>
					</table>
				</center>
			</center>
		</form>
	</body>
</HTML>
