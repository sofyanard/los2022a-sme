<%@ Page language="c#" Codebehind="SkalaAngsuran_Main.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.SkalaAngsuran_Main" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Skala Angsuran</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; WIDTH: 760px; POSITION: absolute; TOP: 8px; HEIGHT: 819px"
				cellSpacing="0" cellPadding="0" width="760" border="0">
				<TR>
					<TD style="FONT-SIZE: x-small; FONT-FAMILY: Tahoma; HEIGHT: 17px">
						Jenis Skala Angsuran :
						<asp:PlaceHolder id="PH_JENIS_ANGSURAN" runat="server"></asp:PlaceHolder>
					</TD>
					<TD style="HEIGHT: 17px">&nbsp;&nbsp;&nbsp;</TD>
				<TR>
					<TD colspan="3">
						<iframe id="if" name="if" tabIndex="0" frameBorder="no" width="800" height="800" scrolling="yes"
							style="WIDTH: 760px; HEIGHT: 800px"></iframe>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
