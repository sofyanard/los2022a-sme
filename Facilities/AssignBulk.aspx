<%@ Page language="c#" Codebehind="AssignBulk.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.AssignBulk" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AssignBulk</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
						<TABLE id="Table4">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Assignment</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="FindCustomer.aspx?mc=060"><img src="../Image/back.jpg"></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2"></TD>
				</TR>
				<tr>
					<td colSpan="2">
						<TABLE cellSpacing="2" cellPadding="2" width="100%">
							<tr>
								<td class="td" vAlign="top" width="50%">
									<TABLE cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="TDBGColor1">User ID</td>
											<td></td>
											<td class="TDBGColorValue"><asp:textbox id="TXT_USERID" BorderStyle="None" Width="300px" Runat="server" ReadOnly></asp:textbox></td>
										</tr>
										<tr>
											<td class="TDBGColor1">User Name</td>
											<td></td>
											<td class="TDBGColorValue"><asp:textbox id="TXT_USERNAME" BorderStyle="None" Width="300px" Runat="server" ReadOnly></asp:textbox></td>
										</tr>
									</TABLE>
								</td>
								<td class="td" vAlign="top">
									<TABLE cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="TDBGColor1">Group</td>
											<td></td>
											<td class="TDBGColorValue"><asp:textbox id="TXT_GROUPNAME" BorderStyle="None" Width="300px" Runat="server" ReadOnly></asp:textbox></td>
										</tr>
										<tr>
											<td class="TDBGColor1">Branch</td>
											<td></td>
											<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCHNAME" BorderStyle="None" Width="300px" Runat="server" ReadOnly></asp:textbox></td>
										</tr>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<table id="Table3" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="center">
						<asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder>
					</td>
				</tr>
			</table>
			<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="center">
						<iframe id="if2" width="100%" height="800" name="if2" src="" scrolling="auto"></iframe>
					</td>
				</tr>
			</table>
			</TABLE>
		</form>
	</body>
</HTML>
