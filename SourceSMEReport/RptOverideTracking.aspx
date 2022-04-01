<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="RptOverideTracking.aspx.cs" AutoEventWireup="True" Inherits="SME.SourceSMEReport.RptOverideTracking" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptOverideTracking</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function Batal()
		{
			document.Form1.TXT_Day1.value	= "";
			document.Form1.DDL_Month1.value	= "";
			document.Form1.TXT_Year1.value	= "";
			document.Form1.TXT_Day2.value	= "";
			document.Form1.DDL_Month2.value	= "";
			document.Form1.TXT_Year2.value	= "";
			document.Form1.DDL_Branch.value	= "";
			document.Form1.DDL_CBC.value	= "";
			document.Form1.DDL_Product.value	= "";
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
							<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="500" height="160">
								<TR>
									<TD class="tdHeader1" colSpan="2">
										<asp:Label id="LBL_CBC" runat="server" Visible="False">LBL_CBC</asp:Label>
										<asp:Label id="LBL_BRANCH" runat="server" Visible="False">LBL_BRANCH</asp:Label>
										<asp:Label id="LBL_PRODUCT" runat="server" Visible="False">LBL_PRODUCT</asp:Label>
										<asp:Label id="LBL_INDUSTRI" runat="server" Visible="False">LBL_INDUSTRI</asp:Label>
										<asp:Label id="LBL_PROGRAM" runat="server" Visible="False">LBL_PROGRAM</asp:Label>OVERRIDE 
										TRACKING&nbsp;REPORT
										<asp:Label id="Label1" runat="server" Visible="False">Label</asp:Label>
										<asp:Label id="LBL_BU" runat="server" Visible="False">LBL_BU</asp:Label></TD>
								</TR>
								<TR>
									<TD class="td" style="HEIGHT: 63px" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 23px">Periode</TD>
												<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_Month" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_Year" runat="server" onkeypress="return numbersonly()" Width="60px" CssClass="mandatory"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 17px">Product</TD>
												<TD style="HEIGHT: 17px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 17px">
													<asp:DropDownList id="DDL_Product" runat="server" onselectedindexchanged="DDL_Product_SelectedIndexChanged"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 10px">Region</TD>
												<TD style="HEIGHT: 10px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 10px">
													<asp:dropdownlist id="DDL_REGION" runat="server"></asp:dropdownlist></TD>
											</TR> <!-- Additional Field : Right --></TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
										<asp:button id="BTN_LIHAT" runat="server" Text=" Find " CssClass="Button1" onclick="BTN_LIHAT_Click"></asp:button>
										&nbsp; <input type="button" id="Button2" name="Button2" Value="Batal" Class="Button1" onClick="Batal()">
										&nbsp;<asp:button id="Btn_Print" runat="server" Width="60px" CssClass="Button1" Text="Print" onclick="Btn_Print_Click"></asp:button>
										<!--<asp:button id="BTN_CANCEL" runat="server" Text="Batal" CssClass="Button1"></asp:button>-->
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD colSpan="2">
							<cc1:ReportViewer id="ReportViewer1" runat="server" Width="100%" Height="400px" Parameters="False"></cc1:ReportViewer>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
