<%@ Page language="c#" Codebehind="AssignmentToPIC.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.ICAssignValidation.AssignmentToPIC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssignmentToPIC</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder" style="WIDTH: 482px">
								<TABLE id="Table8">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment to PIC</B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right">
								<A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Unit:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT" runat="server" BorderStyle="None" ReadOnly="True" Width="300px" Enabled="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Reference#:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_REFERENCE" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"
												Enabled="False"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Request Date:</TD>
										<TD class="TDBGColorValue">
											<asp:textbox id="TXT_REQUEST_DATE" runat="server" ReadOnly="True" Width="320px" Enabled="False"></asp:textbox>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1"></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Assignment</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483">
								<TABLE id="Table9" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1">Received Date:</TD>
										<TD class="TDBGColorValue">
											<asp:textbox id="TXT_RECEIVED_DATE" runat="server" ReadOnly="True" Enabled="False" Width="300px"></asp:textbox>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Department Head:</TD>
										<TD class="TDBGColorValue">
											<asp:textbox id="TXT_DEPTHEAD" runat="server" ReadOnly="True" Enabled="False" Width="300px"></asp:textbox>
										</TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">PIC:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_PIC" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<tr align="center">
							<td vAlign="top" align="right"><asp:button id="BTN_ASSIGN" runat="server" Width="65px" Text="Assign" CssClass="Button1" onclick="BTN_ASSIGN_Click"></asp:button></td>
							<td vAlign="top" align="left"><asp:button id="BTN_CANCEL" runat="server" Width="65px" Text="Cancel" CssClass="Button1" onclick="BTN_CANCEL_Click"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
