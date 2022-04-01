<%@ Page language="c#" Codebehind="AcqInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.InitiationValidation.AcqInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Acquire Information</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="FAcqInfo" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<!--
					<tr>
						<td style="WIDTH: 922px">
						</td>
						<td class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</td>
					</tr>
					-->
					<TR>
						<TD class="tdheader1" align="center" colSpan="2">Acquire Information</TD>
					</TR>
					<tr>
						<td class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder><asp:label id="lbl_regno" runat="server" Visible="False"></asp:label><asp:label id="lbl_curef" runat="server" Visible="False"></asp:label><asp:label id="lbl_prod" runat="server" Visible="False"></asp:label><asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label><asp:label id="lbl_track" runat="server" Visible="False"></asp:label><asp:label id="lbl_userid" runat="server" Visible="False"></asp:label><asp:label id="LBL_APRV" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="HEIGHT: 7px"><asp:textbox id="txt_acqinfo" Height="150" Width="100%" TextMode="MultiLine" Runat="server"></asp:textbox></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<tr>
						<td class="TDBGColor2" align="center">
							<asp:button id="btn_send" Width="100px" Runat="server" CssClass="button1" Text="Send" onclick="btn_send_Click"></asp:button>
							<INPUT class="button1" style="WIDTH: 100px" onclick="javascript:window.close()" type="button"
								value="Close">
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
