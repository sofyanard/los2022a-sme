<%@ Page language="c#" Codebehind="TargetCustomerInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.TargetCustomer.TargetCustomerInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TargetCustomerInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Targetting Customer Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A>
							<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" width="100%" colSpan="2">Information</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="100%" colspan="2">
							<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td style="HEIGHT: 7px"><asp:textbox id="TXT_ACQINFO" Runat="server" TextMode="MultiLine" Width="100%" Height="150"></asp:textbox></td>
								</tr>
								<tr>
									<td></td>
								</tr>
								<tr id="TR_SAVE" runat="server">
									<td class="TDBGColor2" align="center">
										<asp:button id="BTN_SAVE" Runat="server" Width="100px" Text="Save" CssClass="button1" onclick="BTN_SAVE_Click"></asp:button>
									</td>
								</tr>
							</table>
						</TD>
					</TR>
					<TR id="TR_APRVBU" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="3">
							<asp:button id="BTN_ACQINFOBU" runat="server" CssClass="Button1" Text="Acquire Information" onclick="BTN_ACQINFOBU_Click"></asp:button>
						</TD>
					</TR>
					<TR id="TR_APRVRISK" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="4">
							<asp:button id="BTN_ACQINFORISK" runat="server" CssClass="Button1" Text="Acquire Information" onclick="BTN_ACQINFORISK_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
