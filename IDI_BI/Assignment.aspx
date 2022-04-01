<%@ Page language="c#" Codebehind="Assignment.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.Assignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Assignment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> ASSIGNMENT</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">
							CUSTOMER DATA</TD>
					</TR>
					<tr id="TR_CATATAN" runat="server">
						<td class="td" vAlign="top" width="60%">
							<TABLE id="Table61" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 21px">IDI BI Request #</TD>
									<TD style="WIDTH: 15px; HEIGHT: 21px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 43px; HEIGHT: 21px"><asp:textbox id="TXT_IDI_REQ" runat="server" BorderStyle="None" ReadOnly="True" Width="352px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Current Track</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_TRACK" runat="server" BorderStyle="None" ReadOnly="True" Width="352px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Current RM</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 43px"><asp:textbox id="TXT_OFFICER" runat="server" BorderStyle="None" ReadOnly="True" Width="352px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">
										Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_PIC2" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_PIC2_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">RM</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_PIC" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_ASG" runat="server" Text="ASSIGN" CssClass="button1" onclick="BTN_ASG_Click"></asp:button></TD>
					</TR>
				</table>
				<table id="Table41" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><asp:placeholder id="Placeholder2" runat="server"></asp:placeholder><asp:label id="TXT_TGL_SERVER" runat="server" Visible="False"></asp:label><asp:label id="PICID_TXT" runat="server" Visible="False"></asp:label><asp:label id="lbl_rekananref" runat="server" Visible="False"></asp:label><asp:label id="BUSS_ID_TXT" runat="server" Visible="False"></asp:label><asp:label id="txt_dept" runat="server" Visible="False"></asp:label><asp:label id="TXT_STATUSBY" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
