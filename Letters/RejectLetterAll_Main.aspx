<%@ Page language="c#" Codebehind="RejectLetterAll_Main.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.RejectLetterAll_Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RejectLetter_Main</title>
		<script language="javascript">
function print_frame() {
	window.parent.framereject.focus();
	window.print();
}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD></TD>
					<TD align="center"><INPUT class="Button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
							name="BTN_PRINT">&nbsp; <INPUT class="Button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
							value="Back" name="BTN_BACK">
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center"><asp:placeholder id="PH1" runat="server"></asp:placeholder></TD>
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
