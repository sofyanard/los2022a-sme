<%@ Page language="c#" Codebehind="RptPenolakanKredit.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptPenolakanKredit" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptPenolakanKredit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			//document.Form1.TXT_Day1.value	= "";
			//document.Form1.DDL_Month1.value	= "";
			//document.Form1.TXT_Year1.value	= "";
			//document.Form1.TXT_Day2.value	= "";
			//document.Form1.DDL_Month2.value	= "";
			//document.Form1.TXT_Year2.value	= "";
			document.Form1.DDL_CBC.value	= "";
			document.Form1.DDL_Branch.value	= "";
			document.Form1.ddl_team.value	= "";
			document.Form1.DDL_PROGRAM.value	= "";
			document.Form1.DDL_Product.value	= "";
		}
		</script>
		<!-- #include file="../include/cek_all.html"-->
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD width="20%" height="35"></TD>
						<td align="right"><asp:imagebutton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2" height="160">
							<TABLE id="Table1" height="160" cellSpacing="2" cellPadding="2" width="550">
								<TR>
									<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_CBC" runat="server" Visible="False">LBL_CBC</asp:label><asp:label id="LBL_BRANCH" runat="server" Visible="False">LBL_BRANCH</asp:label><asp:label id="LBL_PRODUCT" runat="server" Visible="False">LBL_PRODUCT</asp:label><asp:label id="LBL_INDUSTRI" runat="server" Visible="False">LBL_INDUSTRI</asp:label><asp:label id="LBL_PROGRAM" runat="server" Visible="False">LBL_PROGRAM</asp:label>LAPORAN 
										PENOLAKAN KREDIT
										<asp:label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:label></TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 63px" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 23px">IDE Start Date</TD>
									</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox onkeypress="return numbersonly()" id="TXT_Day1" runat="server" CssClass="mandatory"
											Width="32px"></asp:textbox><asp:dropdownlist id="DDL_Month1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_Year1" runat="server" CssClass="mandatory"
											Width="48px"></asp:textbox>&nbsp;TO
										<asp:textbox onkeypress="return numbersonly()" id="TXT_Day2" runat="server" CssClass="mandatory"
											Width="38px"></asp:textbox><asp:dropdownlist id="DDL_Month2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_Year2" runat="server" CssClass="mandatory"
											Width="60px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 15px">CBC</TD>
									<TD style="HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Cabang/CBC/Group</TD>
									<TD style="HEIGHT: 20px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="DDL_Branch" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_Branch_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 13px">Team</TD>
									<TD style="HEIGHT: 13px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 13px"><asp:dropdownlist id="ddl_team" runat="server" onselectedindexchanged="ddl_team_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROGRAM" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_PROGRAM_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Product</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_Product" runat="server"></asp:dropdownlist></TD>
								</TR> <!-- Additional Field : Right -->
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_LIHAT" runat="server" CssClass="Button1" Text=" Find " onclick="BTN_LIHAT_Click"></asp:button>&nbsp;
							<input class="Button1" id="Button2" onclick="Batal()" type="button" value="Cancel" name="Button2">
							&nbsp;<asp:button id="Btn_Print" runat="server" CssClass="Button1" Width="60px" Text="Print" onclick="Btn_Print_Click"></asp:button>
							<!--<asp:button id="BTN_CANCEL" runat="server" Text="Batal" CssClass="Button1"></asp:button>--></TD>
					</TR>
				</TABLE>
				</TD></TR>
				<TR align="center">
					<TD vAlign="top" colSpan="2">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
                    </TD>
				</TR>
				</TBODY></TABLE>
			</center>
		</form>
	</body>
</HTML>
