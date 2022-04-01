<%@ Page language="c#" Codebehind="DataUpload.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.DataUpload" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataUpload</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>UPLOAD DATA</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">
								Result</TD>
						</TR>
						<TR>
							<TD class="td" colSpan="2">
								<asp:TextBox id="TXT_RESULT" runat="server" Height="92px" TextMode="MultiLine" Width="100%"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" vAlign="top" align="center" width="50%" colSpan="2">
								Textfile</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:button id="BTN_PROCESS" CssClass="button1" Width="101px" Text="Process" Runat="server" onclick="BTN_PROCESS_Click"></asp:button>&nbsp;</TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
