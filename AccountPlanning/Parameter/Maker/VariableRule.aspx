<%@ Page language="c#" Codebehind="VariableRule.aspx.cs" AutoEventWireup="True" Inherits="SME.AccountPlanning.Parameter.Maker.VariableRule" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>SearchParameter</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
  </HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>VARIABLE PARAMETER - 
											MAKER</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../../Body.aspx"><IMG height="25" src="/SME/Image/MainMenu.jpg" width="106"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table3" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1"
								cellPadding="1" width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="40%">Variable ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_ID_PARAM" runat="server" MaxLength="20"
														Width="85%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Variable Name</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return kutip_satu()" id="TXT_VAR_NAME" runat="server" MaxLength="50"
														Width="85%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_FIND" runat="server" Width="180px" Text="Find Variable" CssClass="button1" onclick="BTN_FIND_Click"></asp:button>&nbsp;
													<asp:button id="BTN_NEW" runat="server" Width="180px" Text="New Variable" CssClass="button1" onclick="BTN_NEW_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrdVar" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True" PageSize="15">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="ID_AP_ITEM" HeaderText="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ID_AP_VARIABLE" HeaderText="Variable ID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Variable Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="QUERY" HeaderText="Query">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIELD" HeaderText="Field">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ISRANGE" HeaderText="Isrange">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="edit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="TR_EDIT_PARAMETER" runat="server">
						<TD align="center" colSpan="2">
							<TABLE class="td" id="TableEdit1" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1"
								cellPadding="1" width="590" border="1">
								<TR>
									<TD class="tdHeader1">Edit Variable</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="TableEdit2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="40%">ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_ID" runat="server" MaxLength="20"
														Width="95%" Enabled="False" BackColor="Silver"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Variable ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDITED_VARID" runat="server" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Variable Name</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDITED_DESC" runat="server" MaxLength="200" Width="95%" Height="58px" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Query</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDITED_QUERY" runat="server" MaxLength="200" Width="95%" Height="58px" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Field</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDITED_FIELD" runat="server" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Type</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:radiobuttonlist id="RDO_EDITED_TYPE" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True">
														<asp:ListItem Value="1">Range</asp:ListItem>
														<asp:ListItem Value="0">Non Range</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Status</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:radiobuttonlist id="RDO_EDITED_STATUS" runat="server" Width="150px" RepeatDirection="Horizontal"
														AutoPostBack="True">
														<asp:ListItem Value="1">Enable</asp:ListItem>
														<asp:ListItem Value="0">Disable</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<tr>
												<TD></TD>
											</tr>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_UPDATE_RULE" runat="server" Width="180px" Text="Update Rule" CssClass="button1" onclick="BTN_UPDATE_RULE_Click"></asp:button>&nbsp;
													<asp:button id="BTN_VIEW_DETAIL" runat="server" Width="180px" Text="View Detail" CssClass="button1" onclick="BTN_VIEW_DETAIL_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_NEW_PARAMETER" runat="server">
						<TD align="center" colSpan="2">
							<TABLE class="td" id="TableNew1" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1"
								cellPadding="1" width="590" border="1">
								<TR>
									<TD class="tdHeader1">Insert New Variable</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="TableEdit3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="40%">Variable ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_NEW_ID" runat="server" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Variable Name</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_NEW_DESC" runat="server" MaxLength="200" Width="95%" Height="58px" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Query</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_NEW_QUERY" runat="server" MaxLength="200" Width="95%" Height="58px" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Field</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_NEW_FIELD" runat="server" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Type</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:radiobuttonlist id="RDO_NEW_TYPE" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True">
														<asp:ListItem Value="1">Range</asp:ListItem>
														<asp:ListItem Value="0">Non Range</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Status</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:radiobuttonlist id="RDO_NEW_STATUS" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True">
														<asp:ListItem Value="1">Enable</asp:ListItem>
														<asp:ListItem Value="0">Disable</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_NEW_INSERT" runat="server" Width="180px" Text="Insert Variable" CssClass="button1" onclick="BTN_NEW_INSERT_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_ATTRIBUTE_RANGE" runat="server">
						<TD align="center" colSpan="2">
							<TABLE width="100%" border="0">
								<TR>
									<TD class="tdHeader1">Variable Range</TD>
								</TR>
								<TR>
									<TD colSpan="2"><ASP:DATAGRID id="DatGridVariableRange" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
											AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="ID_AP_ITEM_RANGE" HeaderText="ID">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="LOWEST" HeaderText="Lowest">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="HIGHEST" HeaderText="Highest">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="WEIGHT" HeaderText="Weight">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="edit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="delete">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
												</asp:ButtonColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
								<TR id="TR_EDIT_ATTRIBUTE_RANGE" runat="server">
									<TD align="center" colSpan="2">
										<TABLE class="td" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1" cellPadding="1"
											width="590" border="1">
											<TR>
												<TD class="tdHeader1">Edit Variable Range</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TDBGColor1" width="40%">ID</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_RANGEID" runat="server" MaxLength="20"
																	Width="95%" Enabled="False" BackColor="Silver"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">LOWEST</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_RANGELOWEST" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">HIGHEST</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_RANGEHIGHEST" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">WEIGHT</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_RANGEWEIGHT" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">CONDITION</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:radiobuttonlist id="RDO_EDITED_RANGECONDITION" runat="server" Width="352px" RepeatDirection="Horizontal"
																	AutoPostBack="True">
																	<asp:ListItem Value="3">BELOW</asp:ListItem>
																	<asp:ListItem Value="2">HIGH</asp:ListItem>
																	<asp:ListItem Value="1">NO INFORMATION</asp:ListItem>
																	<asp:ListItem Value="0">NORMAL</asp:ListItem>
																</asp:radiobuttonlist></TD>
														</TR>
														<TR>
															<TD></TD>
														</TR>
														<TR>
															<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_EDITED_RANGE" runat="server" Width="180px" Text="Update Variable Range"
																	CssClass="button1" onclick="BTN_EDITED_RANGE_Click"></asp:button>&nbsp;
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR id="TR_NEW_ATTRIBUTE_RANGE" runat="server">
									<TD align="center" colSpan="2">
										<TABLE class="td" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1" cellPadding="1"
											width="590" border="1">
											<TR>
												<TD class="tdHeader1">New Variable Range</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TDBGColor1" width="40%">LOWEST</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_NEW_RANGELOWEST" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">HIGHEST</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_NEW_RANGEHIGHEST" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">WEIGHT</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_NEW_RANGEWEIGHT" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">CONDITION</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:radiobuttonlist id="RDO_NEW_RANGECONDITION" runat="server" Width="352px" RepeatDirection="Horizontal"
																	AutoPostBack="True">
																	<asp:ListItem Value="3">BELOW</asp:ListItem>
																	<asp:ListItem Value="2">HIGH</asp:ListItem>
																	<asp:ListItem Value="1">NO INFORMATION</asp:ListItem>
																	<asp:ListItem Value="0">NORMAL</asp:ListItem>
																</asp:radiobuttonlist></TD>
														</TR>
														<TR>
															<TD></TD>
														</TR>
														<TR>
															<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_NEW_RANGE" runat="server" Width="180px" Text="Insert Variable Range" CssClass="button1" onclick="BTN_NEW_RANGE_Click"></asp:button>&nbsp;
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
					</TR>
					<TR id="TR_ATTRIBUTE_NONRANGE" runat="server">
						<TD align="center" colSpan="2">
							<TABLE width="100%" border="0">
								<TR>
									<TD class="tdHeader1">Variable Non Range</TD>
								</TR>
								<TR>
									<TD><ASP:DATAGRID id="DatGridVariableNonRange" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
											AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="ID_AP_ITEM_NON_RANGE" HeaderText="ID">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="VALUE" HeaderText="Value">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="WEIGHT" HeaderText="Weight">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="edit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="delete">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
												</asp:ButtonColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
								<TR id="TR_EDIT_ATTRIBUTE_NONRANGE" runat="server">
									<TD align="center" colSpan="2">
										<TABLE class="td" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1" cellPadding="1"
											width="590" border="1">
											<TR>
												<TD class="tdHeader1">Edit Attribute Non Range</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TDBGColor1" width="40%">ID</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_NONRANGEID" runat="server" MaxLength="20"
																	Width="95%" Enabled="False" BackColor="Silver"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">VALUE</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_NONRANGEVALUE" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">WEIGHT</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDITED_NONRANGEWEIGHT" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<tr>
															<TD></TD>
														</tr>
														<TR>
															<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_EDITED_NONRANGE" runat="server" Width="200px" Text="Update Variable Non Range"
																	CssClass="button1" onclick="BTN_EDITED_NONRANGE_Click"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR id="TR_NEW_ATTRIBUTE_NONRANGE" runat="server">
									<TD align="center" colSpan="2">
										<TABLE class="td" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1" cellPadding="1"
											width="590" border="1">
											<TR>
												<TD class="tdHeader1">New Variable Non Range</TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TDBGColor1" width="40%">VALUE</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="70%"><asp:textbox onkeypress="return digitsonly()" id="TXT_NEW_NONRANGEVALUE" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="40%">WEIGHT</TD>
															<TD width="5">:</TD>
															<TD class="TDBGColorValue" width="70%"><asp:textbox onkeypress="return digitsonly()" id="TXT_NEW_NONRANGEWEIGHT" runat="server" MaxLength="200"
																	Width="95%"></asp:textbox></TD>
														</TR>
														<tr>
															<TD></TD>
														</tr>
														<TR>
															<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_NEW_NONRANGE" runat="server" Width="180px" Text="Insert Attribute" CssClass="button1" onclick="BTN_NEW_NONRANGE_Click"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<asp:textbox id="TXT_ID_STATUS" runat="server" MaxLength="200" Width="280px " Visible="False"></asp:textbox></TABLE>
				<TABLE class="td" width="100%" border="1">
					<TR>
						<TD class="tdHeader1" colSpan="3">REQUEST PARAMETER</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="3">VARIABLE</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" colSpan="3"><asp:datagrid id="DatGridVariableReq" runat="server" Width="100%" AutoGenerateColumns="False"
								AllowPaging="True" PageSize="5">
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPT" HeaderText="Variable Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="edit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="delete">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR id="TR_VARIABLE_TEMP" runat="server">
						<TD align="center" colSpan="2">
							<TABLE class="td" id="TableEdit4" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1"
								cellPadding="1" width="590" border="1">
								<TR>
									<TD class="tdHeader1">Edit Variable</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="TableEdit5" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="40%">ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_IDTEMP" runat="server" MaxLength="20"
														Width="95%" Enabled="False" BackColor="Silver"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Variable ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDIT_VARIDTEMP" runat="server" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Variable Name</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDIT_DESCTEMP" runat="server" MaxLength="200" Width="95%" Height="58px"
														TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Query</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDIT_QUERYTEMP" runat="server" MaxLength="200" Width="95%" Height="58px"
														TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">Field</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox id="TXT_EDIT_FIELDTEMP" runat="server" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Type</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_EDIT_TYPETEMP" runat="server" Width="150px" RepeatDirection="Horizontal"
														AutoPostBack="True">
														<asp:ListItem Value="1">Range</asp:ListItem>
														<asp:ListItem Value="0">Non Range</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue"><asp:radiobuttonlist id="RDO_EDIT_STATUSTEMP" runat="server" Width="150px" RepeatDirection="Horizontal"
														AutoPostBack="True">
														<asp:ListItem Value="1">Enable</asp:ListItem>
														<asp:ListItem Value="0">Disable</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_UPDATE_VARIABLETEMP" runat="server" Width="180px" Text="Update Variable"
														CssClass="button1" onclick="BTN_UPDATE_VARIABLETEMP_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="3">VARIABLE RANGE</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" colSpan="3"><asp:datagrid id="DatGridVariableRangeReq" runat="server" Width="100%" AutoGenerateColumns="False"
								AllowPaging="True" PageSize="5">
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Deskripsi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LOWEST" HeaderText="Lowest">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="HIGHEST" HeaderText="Highest">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="WEIGHT" HeaderText="Weight">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="edit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="delete">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR id="TR_ATTRANGE_TEMP" runat="server">
						<TD align="center" colSpan="2">
							<TABLE class="td" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Edit Variable Range</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="40%">ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_RANGEIDTEMP" runat="server" MaxLength="20"
														Width="95%" Enabled="False" BackColor="Silver"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">LOWEST</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_RANGELOWESTTEMP" runat="server" MaxLength="200"
														Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">HIGHEST</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_RANGEHIGHESTTEMP" runat="server" MaxLength="200"
														Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">WEIGHT</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_RANGEWEIGHTTEMP" runat="server" MaxLength="200"
														Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">CONDITION</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:radiobuttonlist id="RDO_EDIT_RANGECONDITIONTEMP" runat="server" Width="352px" RepeatDirection="Horizontal"
														AutoPostBack="True">
														<asp:ListItem Value="3">BELOW</asp:ListItem>
														<asp:ListItem Value="2">HIGH</asp:ListItem>
														<asp:ListItem Value="1">NO INFORMATION</asp:ListItem>
														<asp:ListItem Value="0">NORMAL</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_EDIT_RANGETEMP" runat="server" Width="180px" Text="Update Variable Range"
														CssClass="button1" onclick="BTN_EDIT_RANGETEMP_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="3">VARIABLE NON RANGE</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" colSpan="3"><asp:datagrid id="DatGridVariableNonRangeReq" runat="server" Width="100%" AutoGenerateColumns="False"
								AllowPaging="True" PageSize="5">
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Deskripsi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VALUE" HeaderText="Value">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="WEIGHT" HeaderText="Weight">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Edit" HeaderText="Function" CommandName="edit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="delete">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR id="TR_ATTNONRANGE_TEMP" runat="server">
						<TD align="center" colSpan="2">
							<TABLE class="td" style="WIDTH: 590px; HEIGHT: 140px" height="140" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Edit Variable Non Range</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="40%">ID</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_NONRANGEIDTEMP" runat="server" MaxLength="20"
														Width="95%" Enabled="False" BackColor="Silver"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">VALUE</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_NONRANGEVALUETEMP" runat="server"
														MaxLength="200" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="40%">WEIGHT</TD>
												<TD width="5">:</TD>
												<TD class="TDBGColorValue" width="60%"><asp:textbox onkeypress="return digitsonly()" id="TXT_EDIT_NONRANGEWEIGHTTEMP" runat="server"
														MaxLength="200" Width="95%"></asp:textbox></TD>
											</TR>
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="BTN_EDIT_NONRANGETEMP" runat="server" Width="180px" Text="Update Attribute"
														CssClass="button1" onclick="BTN_EDIT_NONRANGETEMP_Click"></asp:button>&nbsp;
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<asp:textbox id="TXT_IDVARNONRANGE" runat="server" MaxLength="200" Width="280px" Visible="False"></asp:textbox><asp:textbox id="TXT_IDVARRANGE" runat="server" MaxLength="200" Width="280px" Visible="False"></asp:textbox><asp:textbox id="TXT_IDVARIABLE" runat="server" MaxLength="200" Width="280px" Visible="False"></asp:textbox><asp:textbox id="TXT_IDVARTEMP" runat="server" MaxLength="200" Width="280px" Visible="False"></asp:textbox><asp:textbox id="TXT_IDVARRANGETEMP" runat="server" MaxLength="200" Width="280px" Visible="False"></asp:textbox><asp:textbox id="TXT_IDVARNONRANGETEMP" runat="server" MaxLength="200" Width="280px" Visible="False"></asp:textbox></CENTER>
		</FORM>
	</BODY>
</HTML>
