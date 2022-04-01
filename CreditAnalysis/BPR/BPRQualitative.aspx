<%@ Page language="c#" Codebehind="BPRQualitative.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPRQualitative" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>BPR Qualitative</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../include/cek_all.html" --></SCRIPT>
  </HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder" style="WIDTH: 640px">
						<TABLE width="432" style="WIDTH: 432px; HEIGHT: 25px">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Credit Analysis&nbsp;: 
										Qualitative</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="MainCreditAnalysis.aspx?"></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
				</TR>
				<!-- FORMAT H (Qualitative Rating) ---------------------------------------------------------------------->
				<TR>
					<TD class="td" width="100%" colSpan="2">
						<table id="FORMAT_H" width="100%" runat="server">
							<!-- -------- rating qualitative new ----------------->
							<TR>
								<TD class="td" colSpan="2">
									<table width="100%">
										<tr>
											<td class="tdHeader1" width="100%" colSpan="2">Qualitative Rating</td>
										</tr>
										<TR width="100%">
											<TD colSpan="2"><ASP:DATAGRID id="DGR_QUAL" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
													AllowPaging="True">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="QUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="SUBQUALITATIVEID"></asp:BoundColumn>
														<asp:BoundColumn DataField="QUALITATIVEDESC" HeaderText="Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle Width="10%"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUBQUALITATIVEDESC" HeaderText="Sub Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle Width="15%"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Sub Sub Qualitative">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemTemplate>
																<asp:radiobuttonlist id="RBL_SUBSUBQUAL" runat="server" RepeatDirection="Vertical"></asp:radiobuttonlist>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="SCORE" HeaderText="Score" Visible="False">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</ASP:DATAGRID></TD>
										</TR>
										<tr>
											<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">&nbsp;&nbsp;
												<asp:button id="BTN_SAVEQUAL" runat="server" Text="Save Qualitative" CssClass="Button1" onclick="BTN_SAVEQUAL_Click"></asp:button>
											</td>
										</tr>
										<tr>
											<td class="td" align="center" colSpan="2"></td>
										</tr>
										<tr>
											<td class="td" colSpan="1">
												<table width="100%">
													<tr>
														<TD class="TDBGColor1" width="20%">Qualitative Total Score</TD>
														<TD width="1">:</TD>
														<TD width="80%" class="TDBGColorValue"><asp:label id="LBL_QSCORE" runat="server"></asp:label></TD>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<!-- FORMAT G (Small Business Enhancement) ---------------------------------------------------------------------->
			</TABLE>
			<!-- SEPARATOR -->
			<table id="TBL_SAVE" width="100%" runat="server">
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:label id="LBL_H_JNSNASABAH" runat="server" Visible="False"></asp:label><asp:label id="LBL_H_PROGRAMID" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
