<%@ Page language="c#" Codebehind="ProjectInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.CustomerBasicInformation.ProjectInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>ProjectInfo</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>PROJECT INFO</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">PRODUK YANG DIHASILKAN &amp; DIJUAL</TD>
					</TR>
					<TR>
						<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_PRODUCT" runat="server" TextMode="MultiLine" Height="100px" Width="100%"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_SAVE_PRODUCT" runat="server" Width="100px" Text="SAVE" CssClass="button1" onclick="BTN_SAVE_PRODUCT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_PRODUCT" runat="server" Width="100px" Text="CLEAR" CssClass="button1" onclick="BTN_CLEAR_PRODUCT_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">PROYEK</TD>
					</TR>
					<TR>
						<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_PROYEK" runat="server" TextMode="MultiLine" Height="100px" Width="100%"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_SAVE_PROYEK" runat="server" Width="100px" Text="SAVE" CssClass="button1" onclick="BTN_SAVE_PROYEK_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_PROYEK" runat="server" Width="100px" Text="CLEAR" CssClass="button1" onclick="BTN_CLEAR_PROYEK_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
