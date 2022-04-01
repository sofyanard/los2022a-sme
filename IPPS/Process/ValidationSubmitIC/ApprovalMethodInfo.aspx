<%@ Page language="c#" Codebehind="ApprovalMethodInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.ValidationSubmitIC.ApprovalMethodInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalMethodInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder" style="WIDTH: 482px">
								<TABLE id="Table8">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Approval Method Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right"><A href="ListCustomer.aspx?si="></A> <A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">REMARK FOR UPDATE</TD>
						</TR>
						<tr>
							<TD class="TDBGColorValue" align="left" colspan="2">
								<asp:textbox onkeypress="return kutip_satu()" id="TXT_REMARK" runat="server" Width="100%" Height="100px"
									MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Unit</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_unit" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Reference#</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_reference" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">Request Date</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_request_date" runat="server" ReadOnly="True" Width="300px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1"></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Forward to Approval</TD>
						</TR>
						<TR>
							<TD colspan="2"><b>
									<ASP:DATAGRID id="dg_forward_approval" runat="server" Width="100%" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="id" Visible="False" />
											<asp:BoundColumn DataField="no" HeaderText="No.">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="reqname" HeaderText="Request">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="approvalmethod" HeaderText="Approval Method">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Committeename" HeaderText="Committee Name">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Committeedate" HeaderText="Committee Date">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="approvedby" HeaderText="Approved by">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Function">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="Edit" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
													<asp:LinkButton id="Delete" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</ASP:DATAGRID></b></TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1">
											Request</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px">
											<asp:dropdownlist CssClass="mandatory" id="ddl_request" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Approval Method</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px">
											<asp:dropdownlist id="ddl_approval_method" CssClass="mandatory" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Approved by</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px">
											<asp:TextBox id="txt_approval_by" runat="server" CssClass="mandatory"></asp:TextBox>
											<asp:Button id="btn_search" runat="server" Text="..."></asp:Button></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1">Committee Name</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px">
											<asp:dropdownlist id="ddl_committee_name" CssClass="mandatory" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">
											&nbsp;Committee Date</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="txt_tgl_date" runat="server" Width="24px"
												Columns="4" MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_BLN_date" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_THN_date" runat="server" Width="36px"
												Columns="4" MaxLength="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Remark</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="Textbox1" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<tr align="center">
							<td vAlign="top" align="right"><asp:button id="BTN_Insert" runat="server" Width="65px" Text="Insert" CssClass="Button1"></asp:button></td>
							<td vAlign="top" align="left"><asp:button id="BTN_clear" runat="server" Width="106px" Text="Clear" CssClass="Button1"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
				<BR>
				<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TBODY>
						<TR>
							<TD align="center" width="100%" class="TDBGColor2">
								<asp:button id="btn_update_status" runat="server" Text="Update Status" CssClass="button1"></asp:button></TD>
						</TR>
					</TBODY>
				</table>
			</center>
		</form>
		</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
