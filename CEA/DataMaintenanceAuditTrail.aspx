<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="DataMaintenanceAuditTrail.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.DataMaintenanceAuditTrail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DataMaintenanceAuditTrail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			
			document.Form1.DDL_JENISDATA.value		= "";
			document.Form1.DDL_JENISREKANAN.value	= "";
			document.Form1.TXT_NAMAREKAN.value	= "";
		}
		</script>
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Tab1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" width="50%">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Data Maintenance Audit 
											Trail</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<tr>
						<td vAlign="top" align="center" colSpan="2">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="500">
								<TR>
									<TD class="tdHeader1">SEARCH CRITERIA&nbsp;</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Track&nbsp;Date</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" MaxLength="2" CssClass="mandatory"
														Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" MaxLength="4" CssClass="mandatory"
														Width="40px"></asp:textbox>&nbsp;To
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" MaxLength="2" CssClass="mandatory"
														Width="30px"></asp:textbox><asp:dropdownlist id="DDL_BLN2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" MaxLength="4" CssClass="mandatory"
														Width="40px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Data</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JENISDATA" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 3px">Jenis Rekanan</TD>
												<TD style="HEIGHT: 8px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 8px"><asp:dropdownlist id="DDL_JENISREKANAN" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px">Nama Rekanan</TD>
												<TD style="HEIGHT: 14px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 14px"><asp:textbox id="TXT_NAMAREKAN" runat="server" MaxLength="18" Width="200px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center"><asp:button id="BTN_Find" runat="server" CssClass="Button1" Width="60px" Text="Find" onclick="BTN_Find_Click"></asp:button>&nbsp;
										<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">&nbsp;
									</TD>
								</TR>
							</TABLE>
						</td>
					<TR align="center">
						<TD colSpan="2"><cc1:reportviewer id="ReportViewer2" runat="server" Width="100%" Parameters="False" Height="510px"></cc1:reportviewer></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
