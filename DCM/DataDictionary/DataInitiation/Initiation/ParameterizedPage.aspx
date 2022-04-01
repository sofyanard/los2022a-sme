<%@ Page language="c#" Codebehind="ParameterizedPage.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataDictionary.DataInitiation.Initiation.ParameterizedPage" SmartNavigation="true" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table id="TBL_maintable" width="100%" runat="server" border="1">
					<TR>
						<TD align="left">
							<TABLE id="Table31" border="1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><asp:label id="LBL_PAGENAME" runat="server"></asp:label></B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../../../image/Back.jpg"></asp:imagebutton>
							<A href="../../../Body.aspx"><IMG height="25" src="../../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
