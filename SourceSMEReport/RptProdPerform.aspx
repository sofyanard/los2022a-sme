<%@ Page language="c#" Codebehind="RptProdPerform.aspx.cs" AutoEventWireup="True" Inherits="SourceSMEReport.RptProdPerform" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptProdPerform</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			
			document.Form1.DDL_Branch.value	= "";
			document.Form1.DDL_CBC.value	= "";
			document.Form1.DDL_Product.value	= "";
			document.Form1.ddl_team.value	= "";
			document.Form1.DDL_Industri.value	= "";
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
						<td align="right">
							<asp:ImageButton id="btn_back" runat="server" ImageUrl="../image/back.jpg" onclick="btn_back_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD vAlign="top" colSpan="2" align="center" height="160">
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="550" height="160">
								<TR>
									<TD class="tdHeader1" colSpan="2">
										<asp:Label id="LBL_CBC" runat="server" Visible="False">LBL_CBC</asp:Label>
										<asp:Label id="LBL_BRANCH" runat="server" Visible="False">LBL_BRANCH</asp:Label>
										<asp:Label id="LBL_PRODUCT" runat="server" Visible="False">LBL_PRODUCT</asp:Label>
										<asp:Label id="LBL_INDUSTRI" runat="server" Visible="False">LBL_INDUSTRI</asp:Label>
										<asp:Label id="LBL_PROGRAM" runat="server" Visible="False">LBL_PROGRAM</asp:Label>PRODUCT 
										PERFORMANCE&nbsp;REPORT
										<asp:Label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:Label></TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 63px" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TBODY>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 23px">IDE Start Date</TD>
									</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox id="TXT_Day1" runat="server" onkeypress="return numbersonly()" Width="32px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_Month1" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_Year1" runat="server" Width="48px" onkeypress="return numbersonly()" CssClass="mandatory"></asp:textbox>&nbsp;TO
										<asp:textbox id="TXT_Day2" runat="server" onkeypress="return numbersonly()" Width="38px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_Month2" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_Year2" runat="server" onkeypress="return numbersonly()" Width="60px" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 15px">Area</TD>
									<TD style="HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_CBC" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 10px">Branch</TD>
									<TD style="HEIGHT: 10px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 10px"><asp:dropdownlist id="DDL_Branch" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_Branch_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Team</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="ddl_team" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 25px">Sub-Segment/Program</TD>
									<TD style="HEIGHT: 25px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 25px">
										<asp:DropDownList id="DDL_PROGRAM" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PROGRAM_SelectedIndexChanged"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Product</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_Product" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Industry</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_Industri" runat="server" onselectedindexchanged="DDL_Industri_SelectedIndexChanged"></asp:DropDownList></TD>
								</TR> <!-- Additional Field : Right -->
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:button id="BTN_LIHAT" runat="server" Text="Find" CssClass="Button1" onclick="BTN_LIHAT_Click"></asp:button>
							&nbsp; <input type="button" id="Button2" name="Button2" Value="Cancel" Class="Button1" onClick="Batal()">
							&nbsp;<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print" onclick="Btn_Print_Click"></asp:button>
							<!--<asp:button id="BTN_CANCEL" runat="server" Text="Batal" CssClass="Button1"></asp:button>-->
						</TD>
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
