<%@ Page language="c#" Codebehind="SPPKBPRINT.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.SPPKBPRINT" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SPPKPRINT</title>
		<script language="javascript">
function print_frame() {
	window.parent.framesppk.focus();
	window.print();
}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD></TD>
					<TD align="center"><INPUT id="BTN_PRINT" Class="Button1" onclick="print_frame();" type="button" value="Print"
							name="BTN_PRINT" style="WIDTH: 49px">&nbsp; <INPUT id="BTN_BACK" Class="Button1" onclick="javascript:history.back();" type="button"
							value="Back" name="BTN_BACK" style="WIDTH: 49px">
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center"><asp:placeholder id="PH1" runat="server"></asp:placeholder>
					</TD>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center">
						<asp:TextBox id="TXT_HEIGHT" runat="server" ForeColor="White" BorderStyle="None" Visible="False"></asp:TextBox>
						<asp:Label id="Label1" runat="server" ForeColor="White" Visible="False"></asp:Label>&nbsp;</TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
