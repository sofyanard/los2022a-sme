<%@ Page language="c#" Codebehind="ValidationInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.InitiationValidation.ValidationInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ValidationInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../include/onepost.html" -->
		<!-- #include file="../../../include/ConfirmBox.html" -->
		<!-- #include file="../../../include/cek_all.html" -->
		<!-- #include file="../../../include/popup.html" -->
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Validation Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right"><A href="ListCustomer.aspx?si="></A><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">General Info</TD>
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
							<TD class="tdHeader1" colSpan="2">Validation Result</TD>
						</TR>
						<tr>
							<TD style="HEIGHT: 288px" colSpan="2">
								<table width="100%">
									<TBODY>
										<tr>
											<td vAlign="top" width="25%" rowSpan="2">
												<table width="100%">
													<tr>
														<td class="tdHeader1">Request</td>
													</tr>
													<tr>
														<td><ASP:DATAGRID id="DGR_REQUEST" runat="server" Width="100%" AutoGenerateColumns="False">
																<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																<Columns>
																	<asp:BoundColumn Visible="False" DataField="IPPS_REGNO"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="REQ_SEQ"></asp:BoundColumn>
																	<asp:BoundColumn DataField="req_desc"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="POLICYTYPE_DESC"></asp:BoundColumn>
																	<asp:TemplateColumn>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		<ItemTemplate>
																			<asp:LinkButton id="link" runat="server" CommandName="link"></asp:LinkButton>&nbsp;
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
															</ASP:DATAGRID></td>
													</tr>
												</table>
											</td>
											<td width="75%">
												<table width="100%">
													<tr>
														<td class="tdHeader1">Request Info</td>
													</tr>
													<tr>
														<td>
															<table width="100%">
																<tr>
																	<td vAlign="top" width="50%">
																		<TABLE id="Tabler0" cellSpacing="1" cellPadding="2" width="100%">
																			<TR>
																				<TD class="TDBGColor1">Select Existing Policy</TD>
																				<TD style="WIDTH: 15px">:</TD>
																				<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_select_policy" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1">Request Type</TD>
																				<TD style="WIDTH: 15px">:</TD>
																				<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_req_type" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1">Policy Type</TD>
																				<TD style="WIDTH: 15px">:</TD>
																				<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_pol_type" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist></TD>
																			</TR>
																		</TABLE>
																	</td>
																	<td vAlign="top" width="50%">
																		<TABLE id="Tabler1" cellSpacing="1" cellPadding="2" width="100%">
																			<TR>
																				<TD class="TDBGColor1">Request Purpose</TD>
																				<TD style="WIDTH: 15px">:</TD>
																				<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_request_purpose" runat="server" Enabled="False" AutoPostBack="True"></asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1">Impl. Target Date</TD>
																				<TD style="WIDTH: 15px">:</TD>
																				<TD class="TDBGColorValue"><asp:textbox id="txt_Impl_Target_Date" runat="server" ReadOnly="True" Enabled="False"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD class="TDBGColor1">Remark</TD>
																				<TD style="WIDTH: 15px">:</TD>
																				<TD class="TDBGColorValue"><asp:textbox id="txt_remarks" runat="server" ReadOnly="True" Enabled="False"></asp:textbox></TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table width="100%">
													<tr>
														<td class="tdHeader1">Decision</td>
													</tr>
													<tr>
														<td>
															<table>
																<TR>
																	<TD class="TDBGColor1" style="HEIGHT: 5px">Result</TD>
																	<TD style="WIDTH: 15px; HEIGHT: 5px">:</TD>
																	<TD class="TDBGColorValue" style="HEIGHT: 5px"><asp:dropdownlist id="ddl_result" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
																	<td style="HEIGHT: 5px"><asp:button id="btn_accept" runat="server" Width="65px" Text="Accept" CssClass="Button1" onclick="btn_accept_Click"></asp:button></td>
																</TR>
																<TR>
																	<TD class="TDBGColor1">Re Assign</TD>
																	<TD style="WIDTH: 15px">:</TD>
																	<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_reassign" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
																	<td><asp:button id="btn_process" runat="server" Width="65px" Text="Process" CssClass="Button1" onclick="btn_process_Click"></asp:button><asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" Width="1px" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></td>
																</TR>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</TBODY>
								</table>
							</TD>
						</tr>
						<tr>
							<td class="tdHeader1" colSpan="2">Submit to Reviewer</td>
						</tr>
						<tr>
							<td style="HEIGHT: 39px" vAlign="top" width="50%">
								<TABLE id="Table9" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1">Request</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_request" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</td>
							<td style="HEIGHT: 39px" vAlign="top" width="50%">
								<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1">Unit Reviewer</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="txt_unit_review" runat="server" ReadOnly="True" Width="300px" AutoPostBack="True"
												CssClass="mandatory" ontextchanged="txt_unit_review_TextChanged"></asp:textbox><asp:button id="btn_search_unit" runat="server" Text="..." onclick="btn_search_unit_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</td>
						</tr>
						<tr align="center">
							<td vAlign="top" align="right"><asp:button id="BTN_save" runat="server" Text="Save" CssClass="Button1" onclick="BTN_save_Click"></asp:button></td>
							<td vAlign="top" align="left"><asp:button id="BTN_clear" runat="server" Text="Clear" CssClass="Button1" onclick="BTN_clear_Click"></asp:button><asp:label id="lbl_list_code" runat="server" Visible="False"></asp:label><asp:textbox id="TXT_UNITTEMP" runat="server" BorderStyle="None" AutoPostBack="True" Visible="False" ontextchanged="TXT_UNITTEMP_TextChanged"></asp:textbox></td>
						</tr>
						<tr>
							<td colSpan="2"><ASP:DATAGRID id="dg_list_request" runat="server" Width="100%" AutoGenerateColumns="False">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="reqseq" HeaderText="No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="reqtype" HeaderText="Request Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="poltype" HeaderText="Policy Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="reviewr" HeaderText="Unit Reviewer">
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
						<tr>
							<td class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="btn_update" runat="server" Text="Submit" CssClass="Button1" onclick="btn_update_Click"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
