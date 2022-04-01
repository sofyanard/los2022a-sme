<%@ Page language="c#" Codebehind="ApprovalMethodInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.FinalDraftEntry.ApprovalMethodInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalMethodInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval Method Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right"><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</tr>
						<TR id="tr_remark" runat="server" visible="false">
							<TD class="tdHeader1" colSpan="2">REMARK FOR UPDATE</TD>
						</TR>
						<tr id="tr_remark1" runat="server" visible="false">
							<TD class="TDBGColorValue" align="left" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REMARK_APP" runat="server" Width="100%"
									MaxLength="100" TextMode="MultiLine" Height="100px"></asp:textbox></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Unit</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_unit" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Reference#</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_reference" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Request Date</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_request_date" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
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
						<tr>
							<td colSpan="2"><ASP:DATAGRID id="dg_list_request" runat="server" Width="100%" AutoGenerateColumns="False">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="appr_seq" Visible="False" />
										<asp:BoundColumn DataField="idd" HeaderText="No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="req_seq" Visible="False" />
										<asp:BoundColumn DataField="req_seqname" HeaderText="Request">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="appr_code" Visible="False" />
										<asp:BoundColumn DataField="appr_name" HeaderText="Approval Method">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="committee_code" Visible="False" />
										<asp:BoundColumn DataField="committee_name" HeaderText="Committee Name">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="committee_date" HeaderText="Committee Date">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="appr_id" Visible="False" />
										<asp:BoundColumn DataField="appr_by" HeaderText="Approved by">
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
								</ASP:DATAGRID></td>
						</tr>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table9" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Request</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist CssClass="mandatory" id="DDL_REQUEST" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Approval Method</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist CssClass="mandatory" id="DDL_APP_METHOD" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Approved by</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox CssClass="mandatory" id="TXT_APPBY" runat="server" Width="261px" ReadOnly="True" ontextchanged="TXT_APPBY_TextChanged"></asp:textbox><asp:button id="BTN_APPBY" Width="24px" Runat="server" Text="..." onclick="BTN_APPBY_Click"></asp:button><asp:label id="lbl_id" runat="server" Visible="False"></asp:label><asp:label id="lbl_name" runat="server" Visible="False"></asp:label>
											<asp:label id="Label1" runat="server" Visible="False"></asp:label></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Committee Name</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist CssClass="mandatory" id="DDL_COMNAME" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Committee Date</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_COM" runat="server" Width="24px" MaxLength="2"
												Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_COM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_COM" runat="server" Width="36px" MaxLength="4"
												Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Remark</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="txt_remarks" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<tr align="center">
							<td vAlign="top" align="right">
								<asp:TextBox id="txt_temp" runat="server" Visible="False" ontextchanged="txt_temp_TextChanged"></asp:TextBox><asp:button id="BTN_Insert" runat="server" Width="65px" Text="Insert" CssClass="Button1" onclick="BTN_Insert_Click"></asp:button></td>
							<td vAlign="top" align="left"><asp:button id="BTN_clear" runat="server" Width="65px" Text="Clear" CssClass="Button1" onclick="BTN_clear_Click"></asp:button></td>
						</tr>
						<tr>
							<td vAlign="top" align="center" colSpan="2"><asp:button id="btn_update" runat="server" Text="Update Status" CssClass="Button1" onclick="btn_update_Click"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
