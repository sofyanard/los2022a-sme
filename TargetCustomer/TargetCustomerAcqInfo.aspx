<%@ Page language="c#" Codebehind="TargetCustomerAcqInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.TargetCustomer.TargetCustomerAcqInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TargetCustomerAcqInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="FAcqInfo" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<TD class="tdheader1" align="center" colSpan="2">Acquire Information</TD>
					</TR>
					<tr>
						<td class="tdNoBorder" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder><asp:label id="lbl_trgcuref" runat="server" Visible="False"></asp:label><asp:label id="lbl_aprv" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="HEIGHT: 7px"><asp:textbox id="txt_acqinfo" Runat="server" TextMode="MultiLine" Width="100%" Height="150"></asp:textbox></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<tr>
						<td class="TDBGColor2" align="center"><asp:button id="btn_send" Runat="server" Width="100px" Text="Send" CssClass="button1" onclick="btn_send_Click"></asp:button><INPUT class="button1" style="WIDTH: 100px" onclick="javascript:window.close()" type="button"
								value="Close"></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
