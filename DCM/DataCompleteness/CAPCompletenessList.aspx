<%@ Register TagPrefix="cc1" Namespace="Microsoft.Samples.ReportingServices" Assembly="ReportViewer" %>
<%@ Page language="c#" Codebehind="CAPCompletenessList.aspx.cs" AutoEventWireup="false" Inherits="SME.DCM.DataCompleteness.CAPCompletenessList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CAPCompletenessList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
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
						<td align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
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
										<asp:TextBox id="TextBox1" runat="server" Width="247px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 2px">Account# :</TD>
									<TD style="HEIGHT: 2px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 2px">
										<asp:TextBox id="TextBox2" runat="server" Width="247px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Customer Name :</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TextBox3" runat="server" Width="246px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD height="10" vAlign="top" colSpan="3" align="center"><asp:button id="btn_Find" runat="server" Width="180px" CssClass="button1" Text="Find "></asp:button>&nbsp;
										<asp:button id="BTN_CLEAR" runat="server" Width="180px" CssClass="button1" Text="Clear"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<br>
				<center>
					<table cellSpacing="0" cellPadding="0" width="100%" align="center">
						<TR align="center">
							<TD colSpan="1">
								<ASP:DATAGRID id="DGR_CIF_LIST" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
									Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn HeaderText="Data Date" DataField="">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="" HeaderText="CIF#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="" HeaderText="Account#">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="" HeaderText="Customer Name">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="" HeaderText="Unit Name">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="" HeaderText="Error Message">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader" Width="10%"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="edit_data" runat="server" CommandName="edit_data">View</asp:LinkButton>&nbsp;
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
					</table>
				</center>
			</center>
		</form>
	</body>
</HTML>
