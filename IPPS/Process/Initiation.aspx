<%@ Page language="c#" Codebehind="Initiation.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.Initiation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CollateralData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Policy &amp; Procedure 
												Initiation</B></TD>
									</TR>
								</TABLE>
							</TD>
							<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="/SME/Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></td>
						</TR>
						<tr>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">GENERAL INFO</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
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
							<TD class="tdHeader1" colSpan="2">Request Info</TD>
						</TR>
						<TR>
							<TD><b><asp:radiobuttonlist id="rdo_req_info" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" onselectedindexchanged="rdo_req_info_SelectedIndexChanged">
										<asp:ListItem Value="1">New</asp:ListItem>
										<asp:ListItem Value="0">Update</asp:ListItem>
									</asp:radiobuttonlist></b></TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1">Select Existing Policy</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_select_policy" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Request Type</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_req_type" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Policy Type</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_pol_type" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
									<TR>
										<TD class="TDBGColor1">Request Purpose</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:dropdownlist id="ddl_req_pur" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Implement Target Date</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="txt_tgl_tar_date" runat="server" Width="24px"
												Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_tar_date" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_tar_date" runat="server" Width="36px"
												Columns="4" MaxLength="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Remark</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="txt_remark" runat="server" BorderStyle="None" Width="300px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<tr align="center">
							<td vAlign="top" align="right"><asp:label id="LBL_REQ_SEQ" runat="server" Visible="False"></asp:label><asp:button id="BTN_Insert" runat="server" Width="100px" Text="Save" CssClass="Button1" onclick="BTN_Insert_Click"></asp:button></td>
							<td vAlign="top" align="left"><asp:button id="BTN_clear" runat="server" Width="100px" Text="Clear" CssClass="Button1" onclick="BTN_clear_Click"></asp:button></td>
						</tr>
						<tr>
							<td colSpan="2"><ASP:DATAGRID id="dg_list_request" runat="server" Width="100%" AutoGenerateColumns="False">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="IPPS_REGNO" Visible="False" />
										<asp:BoundColumn DataField="REQ_SEQ" HeaderText="No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REQ_ISNEW" Visible="False" />
										<asp:BoundColumn DataField="REQUEST_TYPE" Visible="False" />
										<asp:BoundColumn DataField="REQUEST_TYPE_DESC" HeaderText="Request Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="EXISTING_POLICY" Visible="False" />
										<asp:BoundColumn DataField="EXISTING_POLICY_DESC" HeaderText="Existing Policy">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="POLICY_TYPE" Visible="False" />
										<asp:BoundColumn DataField="POLICY_TYPE_DESC" HeaderText="Policy Type">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REQUEST_PURPOSE" Visible="False" />
										<asp:BoundColumn DataField="REQUEST_PURPOSE_DESC" HeaderText="Request Purpose">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="IMPLEMENT_TERGET_DATE" HeaderText="Target Date" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REMARK" Visible="False" />
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
							<TD class="tdHeader1" colSpan="2"><asp:label id="LBL_UPLOAD" runat="server">Document Upload</asp:label></TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="30%">File :</TD>
										<TD class="TDBGColorValue" width="50%"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 100%; HEIGHT: 19px" disabled type="file" size="38"
												name="File1" runat="Server"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="30%">Status :</TD>
										<TD class="TDBGColorValue" width="50%"><asp:label id="Label4" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
												ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ErrorMessage="Hanya file xls yang diperbolehkan!"></asp:regularexpressionvalidator></TD>
									</TR>
									<TR>
										<TD></TD>
										<TD class="TDBGColorValue" width="50%"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
									</TR>
									<TR>
										<TD></TD>
										<TD style="HEIGHT: 21px" align="center" colSpan="2"><asp:button id="BTN_UPLOAD" runat="server" Width="80px" Text="Upload" Font-Bold="True" Enabled="False"></asp:button></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="3"></TD>
									</TR>
								</TABLE>
							</TD>
							<TD style="HEIGHT: 42px" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
												CellPadding="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="TEMPLATE_ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="FE_USERID"></asp:BoundColumn>
													<asp:BoundColumn DataField="FE_FILENAME" HeaderText="FILE NAME">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id="FE_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="FE_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="FE_URL" HeaderText="Download URL"></asp:BoundColumn>
												</Columns>
											</ASP:DATAGRID></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="td" style="WIDTH: 483px" vAlign="top" width="483"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">No. Nota</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="txt_no_nota" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"
												CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Reference#</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="txt_reference2" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TBODY>
										<TR>
											<TD class="TDBGColor1">Nota Date</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="txt_tgl_nota" runat="server" Width="24px"
													Columns="4" MaxLength="2" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="ddl_bln_nota" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_thn_nota" runat="server" Width="36px"
													Columns="4" MaxLength="4" CssClass="mandatory"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Subject</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_subject" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"
													CssClass="mandatory"></asp:textbox></TD>
										</TR>
									</TBODY>
								</TABLE>
							</TD>
						</TR>
						<tr>
							<td vAlign="top" align="center" colSpan="2"><asp:button id="btn_update" runat="server" CssClass="Button1" Text="Update Status" onclick="btn_update_Click"></asp:button></td>
						</tr>
					</TBODY>
				</TABLE>
			</center>
		</form>
		</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
