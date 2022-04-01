<%@ Page language="c#" Codebehind="SendAndReceive.aspx.cs" AutoEventWireup="True" Inherits="SME.SendAndReceive.SendAndReceive" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SendAndReceive</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="document.Form1.TXT_AP_REGNO.focus()" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="5" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 354px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">--></TD>
						<TD class="tdNoBorder" align="right" colSpan="2"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD>
							<fieldset><legend>Application Info</legend>Application No.
								<asp:textbox id="TXT_AP_REGNO" runat="server"></asp:textbox><asp:button id="search" runat="server" Text="Search" onclick="search_Click"></asp:button></fieldset>
						</TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD width="48%">
							<fieldset><legend>Application To Be Process</legend>
								<TABLE style="HEIGHT: 250px" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="HEIGHT: 227px" vAlign="top"><asp:table id="Table2" runat="server" Width="100%" CellSpacing="0" CellPadding="0">
												<asp:TableRow>
													<asp:TableCell Text="Application No." CssClass="tdSmallHeader"></asp:TableCell>
													<asp:TableCell Text="Nama" CssClass="tdSmallHeader"></asp:TableCell>
													<asp:TableCell Text="Receive Date" CssClass="tdSmallHeader"></asp:TableCell>
													<asp:TableCell Text=" " CssClass="tdSmallHeader"></asp:TableCell>
												</asp:TableRow>
											</asp:table></TD>
									</TR>
									<TR>
										<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="delete" runat="server" Text="Delete" CssClass="Button1" onclick="delete_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</fieldset>
						</TD>
						<TD align="center"><asp:button id="move" runat="server" Text=">>" CssClass="Button1" ToolTip="Send / Receive" onclick="move_Click"></asp:button><br>
							<br>
							<asp:button id="remove" runat="server" Text="<<" CssClass="Button1" ToolTip="Undo Send / Receive" onclick="remove_Click"></asp:button></TD>
						<TD width="48%">
							<fieldset><legend>List Registered Application</legend>
								<TABLE style="HEIGHT: 250px" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD style="HEIGHT: 227px" vAlign="top"><asp:table id="Table3" runat="server" Width="100%" CellSpacing="0" CellPadding="0">
												<asp:TableRow>
													<asp:TableCell Text="Application No." CssClass="tdSmallHeader"></asp:TableCell>
													<asp:TableCell Text="Nama" CssClass="tdSmallHeader"></asp:TableCell>
													<asp:TableCell Text="Receive Date" CssClass="tdSmallHeader"></asp:TableCell>
													<asp:TableCell Text=" " CssClass="tdSmallHeader"></asp:TableCell>
												</asp:TableRow>
											</asp:table></TD>
									</TR>
									<TR>
										<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="sendreceive" runat="server" Text="Send / Receive" CssClass="Button1" onclick="sendreceive_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</fieldset>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
