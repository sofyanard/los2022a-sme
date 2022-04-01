<%@ Page language="c#" Codebehind="NormalisasiCIF.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.DQA.NormalisasiCIF" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NormalisasiCIF</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_WILAYAH.value	= "";
			document.Form1.DDL_AREA.value		= "";
			document.Form1.DDL_CABANG.value		= "";
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
							<TABLE id="Table11" cellSpacing="2" cellPadding="2" width="90%">
								<TBODY>
									<TR>
										<TD class="tdHeader1" colSpan="2">Normalisasi CIF</TD>
									</TR>
									<TR>
										<TD class="td" style="HEIGHT: 36px" vAlign="top" width="90%">
											<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 3px">Wilayah</TD>
													<TD style="WIDTH: 1px; HEIGHT: 3px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 3px"><asp:dropdownlist id="DDL_WILAYAH" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_WILAYAH_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR id="TR_AREA" runat="server">
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 20px">Area</TD>
													<TD style="WIDTH: 1px; HEIGHT: 20px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_AREA" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_AREA_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR id="TR_CABANG" runat="server">
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 18px">Cabang</TD>
													<TD style="WIDTH: 1px; HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_CABANG" runat="server" AutoPostBack="false"></asp:dropdownlist></TD>
												</TR>
												<TR id="TR_KELOMPOK" runat="server">
													<TD class="TDBGColor1" style="WIDTH: 119px; HEIGHT: 18px">BUC</TD>
													<TD style="WIDTH: 1px; HEIGHT: 18px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:dropdownlist id="DDL_KELOMPOK" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
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
						<TD colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Height="510px" Parameters="False" Width="100%"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
				</TBODY></TABLE></center>
		</form>
	</body>
</HTML>
