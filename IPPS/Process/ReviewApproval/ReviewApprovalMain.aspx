<%@ Page language="c#" Codebehind="ReviewApprovalMain.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.ReviewApproval.ReviewApprovalMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ReviewApprovalMain</title>
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Review Approval</B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right"><A href="ListCustomer.aspx?si="></A><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">General Info</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 6px">Unit</TD>
										<TD style="WIDTH: 15px; HEIGHT: 6px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 6px"><asp:textbox id="TXT_unit" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Reference#</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_reference" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">Request Date</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_request_date" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
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
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Received Date</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="txt_received_date" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Department Head</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_dep_head" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1"></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">PIC</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_pic" runat="server" Enabled="False"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Decision</TD>
						</TR>
						<tr>
							<TD class="TDBGColorValue" align="left" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_DECISION" runat="server" TextMode="MultiLine"
									MaxLength="100" Height="100px" Width="100%"></asp:textbox></TD>
						</tr>
						<tr>
							<td vAlign="top" align="right">
								<asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>
							</td>
							<td vAlign="top" align="left">
								<asp:button id="BTN_CLEAR" runat="server" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>
							</td>
						</tr>
						<tr>
						</tr>
						<tr>
							<td vAlign="top" align="right"><asp:button id="btn_update" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_update_Click"></asp:button></td>
							<td vAlign="top" align="left"><asp:button id="BTN_BACKREVIEW" runat="server" CssClass="Button1" Text="Back to review" onclick="BTN_BACKREVIEW_Click"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
