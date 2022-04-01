<%@ Page language="c#" Codebehind="CAPCompletenessList.aspx.cs" AutoEventWireup="True" Inherits="SME.DCM.DataCompleteness.CAP.CAPCompletenessList" %>
<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>CAPCompletenessList</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table4" border="0" width="100%">
					<TR>
						<TD align="left">
							<TABLE id="Table3">
								<TR>
									<TD style="WIDTH: 400px" class="tdBGColor2" align="center"><B>CAP Data Completeness 
											List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
				</TABLE>
				<TABLE id="Table1" class="td" border="1" cellSpacing="1" cellPadding="1" width="590">
					<TR>
						<TD class="tdHeader1">Search Criteria</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">CIF# :</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CIF" runat="server" Width="247px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Account# :</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_ACCOUNT" runat="server" Width="247px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Customer Name :</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CUSTNAME" runat="server" Width="247px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD height="10" vAlign="top" colSpan="3" align="center">
										<asp:button id="BTN_FIND" runat="server" Width="100px" CssClass="button1" Text="Find " onclick="BTN_FIND_Click"></asp:button>&nbsp;
										<asp:button id="BTN_CLEAR" runat="server" Width="100px" CssClass="button1" Text="Clear" onclick="BTN_CLEAR_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<BR>
				<CENTER>
					<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center">
						<TR align="center">
							<TD colSpan="1">
								<ASP:DATAGRID id="DGR_CIF_LIST" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
									Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="datadate" HeaderText="Data Date">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="cif#" HeaderText="CIF#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="actno" HeaderText="Account#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="customer" HeaderText="Customer Name">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="unit" HeaderText="Unit Name">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="error" HeaderText="Error Message">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader" Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">Edit</asp:LinkButton>&nbsp;
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Status">
											<HeaderStyle CssClass="tdSmallHeader" Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="update_status" runat="server" CommandName="update_status">Update Status</asp:LinkButton>&nbsp;
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID>
							</TD>
						</TR>
					</TABLE>
				</CENTER>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
