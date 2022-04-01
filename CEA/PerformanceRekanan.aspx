<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="PerformanceRekanan.aspx.cs" AutoEventWireup="false" Inherits="SME.CEA.PerformanceRekanan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PerformanceRekanan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="BTN_Back" runat="server" ImageUrl="../Image/Back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="550" border="1" height="195">
								<TR>
									<TD class="tdHeader1">PERFORMANCE&nbsp;REKANAN</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Assignment Date</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" MaxLength="2" Columns="2"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN1" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" MaxLength="4" Columns="4"></asp:textbox>&nbsp; 
													to &nbsp;
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" MaxLength="2" Columns="2"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN2" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" MaxLength="4" Columns="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="170">Region</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList ID="DDL_REGION" Runat="server" AutoPostBack="True"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 15px">Unit SBU</TD>
												<TD style="HEIGHT: 15px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:DropDownList ID="DDL_SBU" Runat="server"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Rekanan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_JNS_REK" Runat="server" AutoPostBack="True"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Rekanan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_Rekanan" Runat="server"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Klasifikasi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_KLASIFIKASI" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="5"></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10">
													<asp:button id="BTN_Find" runat="server" Text="Find" Width="80px" CssClass="button1"></asp:button>&nbsp;
													<asp:Button id="BTN_Cancel" runat="server" Width="80px" Text="Cancel" CssClass="button1"></asp:Button>
													<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label>
												</TD>
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
			</center>
		</form>
	</body>
</HTML>
