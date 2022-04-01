<%@ Page language="c#" Codebehind="RptDebiturDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.RptDebiturDetail" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptDebiturDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html"-->
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Report Debitur Watchlist 
												Detail</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">
								<TABLE class="td" id="Table1" height="195" cellSpacing="1" cellPadding="1" width="590"
									border="1">
									<TR>
										<TD class="tdHeader1">Search Criteria</TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center">
											<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1">LMS Received Date</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLFROM_DD" runat="server" MaxLength="2"
															Columns="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_TGLFROM_MM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLFROM_YY" runat="server" MaxLength="4"
															Columns="4" CssClass="mandatory"></asp:textbox>&nbsp;to&nbsp;
														<asp:textbox onkeypress="return numbersonly()" id="TXT_TGLTO_DD" runat="server" MaxLength="2"
															Columns="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_TGLTO_MM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLTO_YY" runat="server" MaxLength="4"
															Columns="4" CssClass="mandatory"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Business Unit</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUSINESSUNIT" Runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Region</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_REGION" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_REGION_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">CBC</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CBC" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CBC_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Branch</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BRANCH" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BRANCH_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">RM</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_RM" Runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="170">CIF No.</TD>
													<TD width="5"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CIF" runat="server" Width="200px" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nama Pemohon</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_NAME" onblur="MinLengthValidation(Form1.txt_Name,3)"
															runat="server" Width="200px" MaxLength="50"></asp:textbox></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="center" colSpan="3" height="5"></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="btn_Find" runat="server" Width="180px" Text="Find" CssClass="button1" onclick="btn_Find_Click"></asp:button>&nbsp;
														<asp:button id="btn_clear" runat="server" Width="180px" Text="Clear" CssClass="button1" onclick="btn_clear_Click"></asp:button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR align="center">
							<TD colSpan="2">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="100%" Height="510px"></rsweb:ReportViewer>
                            </TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
