<%@ Page language="c#" Codebehind="ViewSIDText.aspx.cs" AutoEventWireup="True" Inherits="SME.IDI_BI.ViewSIDText" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>View SID Text</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
function print_frame() {
	//window.parent.framelkkn.focus();
	tr_print.style.display = "none";
	window.print();
	tr_print.style.display = "";
}
		</script>
</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="MainTable" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="2"
				cellPadding="2" width="100%">				
				<TR id="TR_TEXT" runat="server">
					<TD align="center" colSpan="2"><asp:textbox id="TXT_TEXT" runat="server" ReadOnly="True" Font-Names="Courier New" Columns="180"
							Rows="30" TextMode="MultiLine"></asp:textbox>
					</TD>
				</TR>
				
				<tr id="TR_SIDTEXT" runat="server">
					<td width="100%" colspan="2">
						<iframe id="frSID" name="frSID" runat="server" width="100%"></iframe>
					</td>
				</tr>
				<asp:label id="Label5" runat="server" Visible="False"></asp:label>
				<asp:label id="Label4" runat="server" Visible="False"></asp:label>
			</TABLE>
		</FORM>
	</body>
</HTML>
