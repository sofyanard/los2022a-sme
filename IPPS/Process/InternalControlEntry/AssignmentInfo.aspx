<%@ Page language="c#" Codebehind="AssignmentInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.InternalControlEntry.AssignmentInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssignmentInfo</title>
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment Info</B></TD>
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
										<TD class="TDBGColorValue"><asp:textbox id="TXT_unit" runat="server" BorderStyle="None" ReadOnly="True" Width="300px" Enabled="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Reference#:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_reference" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"
												Enabled="False"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Request Date:</TD>
										<TD class="TDBGColorValue">
											<asp:textbox id="TXT_request_date" runat="server" ReadOnly="True" Width="320px" Enabled="False"></asp:textbox>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px"></TD>
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
										<TD class="TDBGColor1" style="WIDTH: 129px">Received Date:</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_RECEIVED" runat="server" Width="24px"
												Columns="4" MaxLength="2" Enabled="False"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_RECEIVED" runat="server" Enabled="False"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_RECEIVED" runat="server" Width="36px"
												Columns="4" MaxLength="4" Enabled="False"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Department Head:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_DEPTHEAD" runat="server" AutoPostBack="True" Enabled="False"></asp:dropdownlist></TD>
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
										<TD class="TDBGColor1" style="WIDTH: 129px">PIC:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_PIC" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<tr align="center">
							<td vAlign="top" align="center" colspan="2"><asp:button id="BTN_UPDATE" runat="server" Text="Update Status" CssClass="Button1"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
