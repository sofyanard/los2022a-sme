<%@ Page language="c#" Codebehind="AssignmentDataProcess.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.AssignmentDataProcess" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssignmentDataProcess</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr>
					<td align="left">
						<TABLE id="Table31">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>ASSIGNMENT PROCESS</B></TD>
							</TR>
						</TABLE>
					</td>
					<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</tr>
				<TR>
					<TD class="tdHeader1" style="HEIGHT: 31px" colspan="2">ASSIGNMENT PENDING TASK LIST</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="590" border="1">
							<TR>
								<TD vAlign="bottom">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 17px">Data#</TD>
											<TD style="HEIGHT: 17px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 17px" width="342"><asp:DropDownList ID="DDL_DATA" Runat="server"></asp:DropDownList></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 2px">Current Unit</TD>
											<TD style="HEIGHT: 2px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 2px" width="342"><asp:textbox id="TXT_CURR_UNIT" runat="server" MaxLength="100" Width="280px" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 21px">Current PIC</TD>
											<TD style="HEIGHT: 21px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 21px" width="342"><asp:textbox id="TXT_CURR_PIC" runat="server" MaxLength="100" Width="280px" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 12px">Assign to Unit</TD>
											<TD style="HEIGHT: 12px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 12px"><asp:dropdownlist id="DDL_ASSIGN_UNIT" runat="server"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 6px">Assign to PIC</TD>
											<TD style="HEIGHT: 6px">:</TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 6px"><asp:DropDownList ID="DDL_ASSIGN_PIC" Runat="server"></asp:DropDownList></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td colspan="2" align="center" class="TDBGColor2"><asp:button id="btn_Find" runat="server" Width="85px" CssClass="button1" Text="ASSIGN" onclick="btn_Find_Click"></asp:button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
