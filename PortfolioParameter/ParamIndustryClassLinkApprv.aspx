<%@ Page language="c#" Codebehind="ParamIndustryClassLinkApprv.aspx.cs" AutoEventWireup="True" Inherits="SME.PortfolioParameter.ParamIndustryClassLinkApprv" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ParamIndustryClassLinkApprv</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
							</TABLE>
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD style="HEIGHT: 41px" width="400">
										<TABLE id="Table5" style="WIDTH: 408px; HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="408"
											border="0">
											<TR>
												<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Parameter - Approval</B></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG height="25" src="../Image/MainMenu.jpg" width="106"></A>
										<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">INDUSTRY CLASS LINK</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="left" width="50%" colSpan="2"><asp:datagrid id="DTG_APPR" runat="server" Width="100%" AllowPaging="True" PageSize="5" AutoGenerateColumns="False"
								ShowFooter="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="PD_INDUSTRY_NAMECD" HeaderText="Industry Name Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PD_INDUSTRY_NAME" HeaderText="KSEBM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PD_INDUSTRY_CLASSCD" HeaderText="Industry Class Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PD_INDUSTRY_CLASS" HeaderText="Industry Class">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PD_RATIO_LIMIT" HeaderText="Ratio Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PD_KSEBMCD" HeaderText="KSEBM Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PD_KSEBMDESC" HeaderText="KSEBM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BI_SEQ" HeaderText="BI SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BI_DESC" HeaderText="KSEBI Level 3">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PENDINGSTATUS" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Approve">
										<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButton id="Radiobutton1" runat="server" GroupName="approval_status"></asp:RadioButton>
										</ItemTemplate>
										<FooterTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="allAppr">Select All</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Reject">
										<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButton id="Radiobutton2" runat="server" GroupName="approval_status"></asp:RadioButton>
										</ItemTemplate>
										<FooterTemplate>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="allReject">Select All</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Pending">
										<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButton id="Radiobutton3" runat="server" GroupName="approval_status" Checked="True"></asp:RadioButton>
										</ItemTemplate>
										<FooterTemplate>
											<asp:LinkButton id="Linkbutton3" runat="server" CommandName="allPend">Select All</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="left" width="50%" colSpan="2">&nbsp;&nbsp;
							<asp:button id="BTN_SUBMIT" CssClass="button1" Text="Submit" Runat="server" onclick="BTN_SUBMIT_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
