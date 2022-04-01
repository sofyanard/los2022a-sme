<%@ Page language="c#" Codebehind="LoanListDataCO2.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCorrectionRequir.LoanListDataCO2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoanListDataCO2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<table width="100%" border="0">
					<tr>
						<td align="left">
							<TABLE id="Table31">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>LOAN&nbsp;LIST DATA</B></TD>
								</TR>
							</TABLE>
						</td>
						<TD class="tdNoBorder" align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</tr>
					<tr>
						<td></td>
					</tr>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 10px" width="145">Account#</TD>
									<TD style="WIDTH: 4px; HEIGHT: 10px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 17px" width="342"><asp:textbox id="TXT_ACT_NO" runat="server" MaxLength="30" Width="280px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 10px" width="145">Customer Name</TD>
									<TD style="WIDTH: 4px; HEIGHT: 10px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 17px" width="342"><asp:textbox id="TXT_CUST_NAME" runat="server" MaxLength="30" Width="280px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 10px" width="145">BUC</TD>
									<TD style="WIDTH: 4px; HEIGHT: 10px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 17px" width="342"><asp:DropDownList id="DDL_BUC" runat="server" Width="280px" MaxLength="30"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 10px" width="145">Branch Name</TD>
									<TD style="WIDTH: 4px; HEIGHT: 10px">:</TD>
									<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 17px" width="342"><asp:DropDownList id="DDL_BRANCH" runat="server" Width="280px" MaxLength="30"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_FIND" runat="server" Width="100px" Text="FIND" CssClass="BUTTON1" onclick="BTN_FIND_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DGR_LOANBU_LIST" runat="server" Width="100%" PageSize="15" AllowPaging="True"
								CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Data Date" DataField="DATA_DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Account #" DataField="ACCTNO">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Customer Name" DataField="CUST_NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="RCO Unit" DataField="rco_unit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="BUC eMAS" DataField="BUC">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Error Message" DataField="ERROR_MSG" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LB_VIEW" runat="server" CommandName="Edit">Edit</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LB_UPDATE" runat="server" CommandName="update_status">Update Status</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</table>
			</CENTER>
		</form>
	</body>
</HTML>
