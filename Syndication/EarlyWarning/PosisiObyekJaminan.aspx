<%@ Page language="c#" Codebehind="PosisiObyekJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.EarlyWarning.PosisiObyekJaminan" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>PosisiObyekJaminan</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table2" cellSpacing="1" cellPadding="1" width="550" border="1" height="195">
								<TR>
									<TD class="tdHeader1">POSISI OBYEK JAMINAN</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="30%"><asp:label id="LBL_TXT_TGL_JATUH_TEMPO" runat="server">Periode :</asp:label></TD>
												<TD class="TDBGColorValue" colSpan="2">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL1" runat="server" Width="24px" MaxLength="2"
														Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN1" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN1" runat="server" Width="36px" MaxLength="4"
														Columns="4"></asp:textbox>
													to
													<asp:textbox onkeypress="return numbersonly()" id="TXT_TGL2" runat="server" Width="24px" MaxLength="2"
														Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_BLN2" runat="server"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_THN2" runat="server" Width="36px" MaxLength="4"
														Columns="4"></asp:textbox>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="30%" style="HEIGHT: 15px">Customer Name :</TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_CUSTOMER_NM" Runat="server" Width="100%"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="30%">Bank Name :</TD>
												<TD class="TDBGColorValue"><asp:DropDownList ID="DDL_BANK_NM" Runat="server" Width="100%"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="2"></TD>
											</TR>
											<TR>
												<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
													<asp:button id="BTN_FIND" runat="server" Width="80px" CssClass="button1" Text="FIND" onclick="BTN_FIND_Click"></asp:button>&nbsp;&nbsp;
													<asp:Button id="BTN_CANCEL" runat="server" Width="80px" CssClass="button1" Text="CANCEL" onclick="BTN_CANCEL_Click"></asp:Button>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR align="center">
						<TD vAlign="top" colSpan="2"><cc1:reportviewer id="ReportViewer1" runat="server" Width="100%" Toolbar="Default" Parameters="False"
								Height="510px"></cc1:reportviewer></CC1:REPORTVIEWER></TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
