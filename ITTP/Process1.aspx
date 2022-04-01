<%@ Page language="c#" Codebehind="Process1.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.Process1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Process1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<script language="javascript">
			/**
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}***/
			
			function konfirHapus()
			{
				alert("Kredit tidak bisa dihapus karena aplikasi akan tidak memiliki kredit !");
				return false;
				
				/**
				conf = confirm("Aplikasi tidak punya ketentuan kredit. Reject aplikasi ?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}**/
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table2">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><a name="Top">Ketentuan 
											Kredit</a></B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" Visible="False"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
					</td>
				</TR>
				<TR>
					<TD class="tdnoborder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">Ketentuan Kredit</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 346px">NCL</TD>
											<TD>:</TD>
											<TD><asp:radiobuttonlist id="RDO_NCL" runat="server" AutoPostBack="True" Width="150px" Height="8px" RepeatDirection="Horizontal">
													<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
													<asp:ListItem Value="2">No</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 346px"><asp:label id="Label1" runat="server">NCL Product.</asp:label></TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_NCLPRODUCTID" runat="server" Width="304px" CssClass="mandatory2" Height="16px"></asp:dropdownlist><asp:label id="LBL_REMAINING" runat="server" Width="168px" Height="14px">Remaining Limit   :</asp:label><asp:label id="LBL_CP_LIMIT" runat="server" Width="168px" Height="14px"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 346px"></TD>
											<TD></TD>
											<TD><asp:label id="Label2" runat="server" Width="304px" Height="14px"></asp:label><asp:label id="LBL_PENDING" runat="server" Width="168px" Height="14px">Pending Transaction Limit :</asp:label><asp:label id="LBL_TRX_LIMIT" runat="server" Width="168px" Height="14px"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 346px; HEIGHT: 22px"><asp:label id="LBL_FACILITY_CODE" runat="server">Facility</asp:label></TD>
											<TD style="HEIGHT: 22px">:</TD>
											<TD style="HEIGHT: 22px"><asp:dropdownlist id="DDL_PRODUCTID1" runat="server" Width="56px" CssClass="mandatory2" Height="16px"></asp:dropdownlist><asp:dropdownlist id="DDL_ACC_SEQ" runat="server" Width="48px" CssClass="mandatory2"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 346px"><FONT size="2">Reason</FONT></TD>
											<TD></TD>
											<TD><asp:textbox id="TXT_CP_NOTES" runat="server" Width="300px" CssClass="mandatory2" MaxLength="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 346px"><FONT size="2">Transaction Type</FONT></TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_APPTYPE" runat="server" Width="304px" CssClass="mandatory2" Height="24px"></asp:dropdownlist><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
									<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2"><asp:button id="BTN_ADD" runat="server" Width="125px" CssClass="button1" Text="Add"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" Width="140px" CssClass="button1"
										Text="Cancel Ketentuan"></asp:button><asp:button id="BTN_CANCEL_ADD" runat="server" Visible="False" CssClass="Button1" Text="Cancel"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE class="TD" id="TBL_DETAIL" cellSpacing="1" cellPadding="1" width="100%" border="0"
							runat="server">
							<TR>
								<TD>
									<TABLE id="TBL_TITLE" style="WIDTH: 368px; HEIGHT: 23px" cellSpacing="1" cellPadding="1"
										width="368" border="0" runat="server">
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 123px">Reason</TD>
											<TD>:</TD>
											<TD><asp:label id="LBL_CP_NOTES" runat="server" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><IFRAME id="creddetail" name="credit" src="" frameBorder="0" width="100%" height="600" runat="server"></IFRAME>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">List Request</TD>
							</TR>
							<TR>
								<TD><ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
										PageSize="5">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="TRAN_TYPE" HeaderText="Transaction Type">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
											<asp:BoundColumn DataField="FACILITY" HeaderText="Facility">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AMOUNT" HeaderText="Amount" DataFormatString="{0:00,00.00}">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID"></asp:BoundColumn>
											<asp:BoundColumn DataField="TENOR" HeaderText="Tenor">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Function">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													&nbsp;&nbsp;&nbsp;
													<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2"><asp:button id="BTN_SAVE" runat="server" Enabled="False" Width="180px" CssClass="button1" Text="Save Ketentuan Kredit"></asp:button>
									<% if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
									<asp:button id="BTN_UPDATE_STATUS" runat="server" Enabled="False" Width="125px" CssClass="button1"
										Text="Update Status"></asp:button>
									<% } %>
									<asp:listbox id="ListBox2" runat="server" Visible="False" Width="10px" Height="25px"></asp:listbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
