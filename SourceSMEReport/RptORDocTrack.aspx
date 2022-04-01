<%@ Page language="c#" Codebehind="RptORDocTrack.aspx.cs" AutoEventWireup="True" Inherits="SourceSMEReport.RptORDocTrack" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptORDocTrack</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function Batal()
		{
			document.Form1.TXT_TGL1.value	= "";
			document.Form1.DDL_BLN1.value	= "";
			document.Form1.TXT_THN1.value	= "";
			document.Form1.TXT_TGL2.value	= "";
			document.Form1.DDL_BLN2.value	= "";
			document.Form1.TXT_THN2.value	= "";
			document.Form1.DDL_BRANCH.value	= "";
			document.Form1.DDL_FROM.value	= "";
			document.Form1.DDL_TO.value		= "";
		}
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" --><LINK href="style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table10" height="90%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td vAlign="top" align="center" colSpan="2" height="180">
							<TABLE id="Table1" height="180" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">--></TD>
								</TR>
								<TR>
									<TD class="tdHeader1" colSpan="2">DOCUMENTS TRACKING&nbsp;REPORT
										<asp:Label id="Label1" runat="server">Label</asp:Label></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="100">Periode</TD>
												<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" Columns="2" CssClass="mandatory"
														MaxLength="2" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" CssClass="mandatory"
														MaxLength="4" Width="45px"></asp:textbox>&nbsp;To
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" Columns="2" CssClass="mandatory"
														MaxLength="2" Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" CssClass="mandatory"
														MaxLength="4" Width="45px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">From</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_FROM" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">To</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_TO" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
											</TR> <!-- Additional Field : Right -->
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 13px">Cabang/CBC/Group</TD>
												<TD style="HEIGHT: 13px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 13px"><asp:dropdownlist id="DDL_BRANCH" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 13px">Team</TD>
												<TD style="HEIGHT: 13px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 13px">
													<asp:DropDownList id="ddl_team" runat="server"></asp:DropDownList></TD>
											</TR> <!-- Additional Field : Right --></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
										<asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="60px" Text="Find" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
										<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">
										&nbsp;<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print" onclick="Btn_Print_Click"></asp:button>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<TR align="center" height="400">
						<TD vAlign="top" colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Toolbar="Default" Height="310px"
								Parameters="False"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
