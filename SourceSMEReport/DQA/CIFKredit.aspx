<%@ Page language="c#" Codebehind="CIFKredit.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.DQA.CIFKredit" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CIFKredit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_WILAYAH.value	= "";
			document.Form1.DDL_KELOMPOK.value	= "";
			document.Form1.DDL_UNIT.value	= "";
			document.Form1.DDL_AREA.value	= "";
			document.Form1.DDL_RCO.value	= "";
		}
		</script>
		<!-- #include file="../../include/cek_all.html"-->
		<!-- #include file="../../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD style="HEIGHT: 124px" vAlign="top" align="center" colSpan="2" height="124">
							<TABLE id="Table11" cellSpacing="2" cellPadding="2" width="100%">
								<TBODY>
									<TR>
										<TD class="tdHeader1" colSpan="2">CIF Kredit</TD>
									</TR>
									<TR>
										<TD class="td" style="HEIGHT: 36px" vAlign="top" width="90%">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 16px">
														Segment</TD>
													<TD style="WIDTH: 8px; HEIGHT: 16px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_KELOMPOK" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_KELOMPOK_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 12px">Wilayah</TD>
													<TD style="WIDTH: 8px; HEIGHT: 12px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 12px"><asp:dropdownlist id="DDL_WILAYAH" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR id="TR_UNIT" runat="server">
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 16px">Unit Kerja</TD>
													<TD style="WIDTH: 8px; HEIGHT: 16px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_UNIT" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;
														<asp:Label id="LBL_RCO" runat="server">/ RCO</asp:Label>
														<asp:dropdownlist id="DDL_RCO" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
												</TR>
												<TR id="TR_AREA" runat="server">
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 10px">Area</TD>
													<TD style="WIDTH: 8px; HEIGHT: 10px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_AREA" runat="server" AutoPostBack="false"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 18px">Status Data</TD>
													<TD style="WIDTH: 8px; HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_STATUS" runat="server" AutoPostBack="false"></asp:dropdownlist></TD>
												</TR>
												<!-- Additional Field : Right --></TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Text="Find" onclick="BTN_LIHAT_Click"></asp:button>&nbsp;
											<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;&nbsp;
										</TD>
									</TR>
						</TD>
					</TR>
				</TABLE>
				</TD></TR></TBODY></TABLE>
				<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%">
					<TR align="center">
						<TD colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Parameters="False" Height="510px"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
				</TBODY></TABLE></center>
		</form>
	</body>
</HTML>
