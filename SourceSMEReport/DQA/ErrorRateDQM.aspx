<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="ErrorRateDQM.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.DQA.ErrorRateDQM" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ErrorRateDQM</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.DDL_POSISI_ERROR.value	= "";
			document.Form1.DDL_JENIS_DATA.value	= "";
		}
		</script>
		<!-- #include file="../../include/cek_all.html"-->
		<!-- #include file="../../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table11" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../../image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD style="HEIGHT: 124px" vAlign="top" align="center" colSpan="2" height="124">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="70%">
								<TR>
									<TD class="tdHeader1" colSpan="2">ERROR RATE DATA</TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 36px" vAlign="top" width="70%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">Data Type :</TD>
												<TD style="HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px">
													<asp:dropdownlist id="DDL_JENIS_DATA" runat="server" AutoPostBack="false" CssClass="mandatory"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">
													Open Date :</TD>
												<TD style="HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" CssClass="mandatory"
														Width="30px" MaxLength="2" Columns="2"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" CssClass="mandatory"
														Width="45px" MaxLength="4"></asp:textbox>&nbsp;to
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" CssClass="mandatory"
														Width="30px" MaxLength="2" Columns="2"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" CssClass="mandatory"
														Width="45px" MaxLength="4"></asp:textbox></TD>
											</TR>
											<!-- Additional Field : Right -->
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Text="Find"></asp:button>&nbsp;
										<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Height="510px" Parameters="False"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
