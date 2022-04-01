<%@ Page language="c#" Codebehind="SPPKLetter_Main.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.SPPKLetter_Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SPPKLetter_Main</title>
		<script language="javascript">
function print_frame() {
	window.parent.framesppk.focus();
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
						<INPUT id="BTN_PRINT" onclick="print_frame();" type="button" value="PRINT" name="BTN_PRINT"
							class="Button1" style="WIDTH: 64px">&nbsp; <INPUT id="BTN_BACK" onclick="javascript:history.back();" type="button" value="BACK" name="BTN_BACK"
							class="Button1" style="WIDTH: 64px">
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
