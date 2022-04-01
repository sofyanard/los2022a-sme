<%@ Page language="c#" Codebehind="InquiryPengalaman.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.InquiryPengalaman" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InquiryPengalaman</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD width="20%" height="35"></TD>
					<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
							width="590" border="1">
							<TR>
								<TD class="tdHeader1">Pekerjaan&nbsp;Rekanan</TD>
							</TR>
							<TR>
								<TD vAlign="top">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 221px">No. Registrasi</TD>
											<TD></TD>
											<TD style="WIDTH: 342px"><asp:textbox id="TXT_REGNUM" runat="server" MaxLength="20"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 221px" width="221">Nama Rekanan</TD>
											<TD width="17"></TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox id="TXT_NAMA" runat="server" MaxLength="20"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 221px">Pekerjaan Rekanan&nbsp;</TD>
											<TD></TD>
											<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox id="TXT_EXP" runat="server" MaxLength="100"></asp:textbox></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3"><asp:button id="BTN_FIND" runat="server" Text="Find " CssClass="button1" Width="105px" onclick="BTN_FIND_Click"></asp:button>
												<asp:button id="BTN_CLEAR" runat="server" Width="105px" CssClass="button1" Text="Cancel"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR align="center">
					<TD vAlign="top" colSpan="2"><cc1:reportviewer id="ReportViewer2" runat="server" Width="100%" Toolbar="Default" Parameters="False"
							Height="510px"></cc1:reportviewer></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
