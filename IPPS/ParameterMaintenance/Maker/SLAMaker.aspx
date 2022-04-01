<%@ Page language="c#" Codebehind="SLAMaker.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.ParameterMaintenance.Maker.SLAMaker" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SLAMaker</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<tbody>
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 482px">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center">
										<B>SLA Parameter : Maker</B></B>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right">
							<A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A> <A href="/SME/Logout.aspx" target="_top">
								<IMG src="/SME/Image/Logout.jpg"></A>
						</td>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">MAKER</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 483px" vAlign="top" width="483">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Policy Type</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_POLICYTYPE" runat="server" BorderStyle="None" Width="300px"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Request Type</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_REQUESTTYPE" runat="server" BorderStyle="None" Width="300px"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Stage Name</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_STAGENAME" runat="server" BorderStyle="None" Width="300px"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Track Code</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_TRACKCODE" runat="server" BorderStyle="None" Width="300px"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">SLA</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_SLA" runat="server" BorderStyle="None" Width="60px"></asp:textbox>
										<asp:DropDownList id="DDL_SLA" runat="server" BorderStyle="None"></asp:DropDownList>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">SLA Work Date</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue">
										<b>
											<asp:radiobuttonlist id="RDO_SLAWORKDATE" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
												<asp:ListItem Value="1">Work</asp:ListItem>
												<asp:ListItem Value="2">Calendar</asp:ListItem>
											</asp:radiobuttonlist>
										</b>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colspan="2">
							<asp:button id="BTN_INSERT" runat="server" Text="Insert" CssClass="button1"></asp:button>&nbsp;
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Existing Parameter</TD>
					</TR>
					<tr>
						<td colSpan="2">
							<ASP:DATAGRID id="DGR_EXISTINGPAR" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="id" Visible="False" />
									<asp:BoundColumn DataField="policytype" HeaderText="Policy Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="requesttype" HeaderText="Request Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="stagename" HeaderText="Stage Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="trackcode" HeaderText="Track Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SLA" HeaderText="SLA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SLAWORKDATE" HeaderText="SLA Work Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Edit" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="Delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID>
						</td>
					</tr>
					<TR>
						<TD class="tdHeader1" colSpan="2">Maintain Request</TD>
					</TR>
					<tr>
						<td colSpan="2">
							<ASP:DATAGRID id="DGR_MAINTREQ" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="id" Visible="False" />
									<asp:BoundColumn DataField="policytype" HeaderText="Policy Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="requesttype" HeaderText="Request Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="stagename" HeaderText="Stage Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="trackcode" HeaderText="Track Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SLA" HeaderText="SLA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SLAWORKDATE" HeaderText="SLA Work Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REQUEST" HeaderText="Request">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID>
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
