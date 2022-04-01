<%@ Page language="c#" Codebehind="AIPB2Print.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.AIPB2Print" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AIPB2Print</title>
		<script language="javascript">
function print_frame() {
	window.parent.frameaip2.focus();
	window.print();
}
		</script>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD></TD>
					<TD align="center">
						<INPUT id="BTN_PRINT" CssClass="Button1" onclick="print_frame();" type="button" value="Print"
							name="BTN_PRINT" class="Button1" runat="server" onserverclick="BTN_PRINT_ServerClick">&nbsp; <INPUT id="BTN_BACK" CssClass="Button1" onclick="javascript:history.back();" type="button"
							value="Back" name="BTN_BACK" class="Button1">
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center">
						<asp:PlaceHolder id="PH1" runat="server"></asp:PlaceHolder></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center">&nbsp;</TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
