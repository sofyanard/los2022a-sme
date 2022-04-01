<%@ Page language="c#" Codebehind="ApprovalCommite2.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprovalCommite2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprovalCommite2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
        <%= popUp%>
		<script language="javascript">
		//TODO : How to use this function using include file ?
		// Fungsi ini sebenarnya sudah ada di /include/cek_entries.html,
		// tapi kalau pake #include file, screen-protection tidak berfungsi.
		function kutip_satu()
		{
			if ((event.keyCode == 35) || (event.keyCode == 39))
			{
				return false;
			} else
			{
				return true;
			}	
		}		
		
		function numbersonly()
		{
			if (event.keyCode<48||event.keyCode>57)
			{
				return false;
			} else
			{
				return true;
			}	
		}
		
		/**
		function update() {
			if (processing) return false;
			conf = confirm("Are you sure you want to update?");
			if (conf) {
				return true; 
			}
			else {
				return false;
			}
		}
		**/
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>&nbsp;Approval : Approval 
											Commite</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<asp:label id="lbl_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label>
					<TR>
						<TD align="center" colSpan="2">
							<!--
							<iframe id="if1" style="WIDTH: 998px; HEIGHT: 190px" name="if1" src="../SPPK/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view" scrolling="no"></iframe>
							--></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Approval Commitee</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DGR_APRVCOMMITEE" runat="server" Width="100%" PageSize="10" AllowPaging="True"
								AutoGenerateColumns="False" CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="ADC_SEQ" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="USERID" Visible="False"></asp:BoundColumn>
									<asp:BoundColumn DataField="USERNAME" HeaderText="Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DECISION" HeaderText="Decision">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DECDATE" HeaderText="Date" DataFormatString="{0:DD-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="lb_delgroup" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="middle" width="45%" colSpan="2">
							<TABLE id="TBL_ENTRY" cellSpacing="2" cellPadding="2" width="100%" border="0" runat="server">
								<TR>
									<TD class="td" vAlign="middle" align="center" width="100%">
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" vAlign="middle">Name</TD>
												<TD class="TDBGColorValue" vAlign="middle" align="left"><asp:dropdownlist id="DDL_CURR_APRV" runat="server"></asp:dropdownlist></TD>
												<TD class="TDBGColor1" vAlign="middle">Decision</TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RBL_CURR_DEC" runat="server" RepeatDirection="Horizontal">
														<asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
														<asp:ListItem Value="0">Reject</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD class="TDBGColorValue" vAlign="middle" align="center"><asp:button id="BTN_INSERT" runat="server" Width="200px" Text="Insert Commitee" CssClass="Button1" onclick="BTN_INSERT_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">eMAS Approval</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="70%">
							<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0" runat="server">
								<TR>
									<TD class="TDBGColor1">Business Unit</TD>
									<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_EMAS_BU" runat="server"></asp:dropdownlist>&nbsp;
									</TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RBL_EMAS_BU" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
											<asp:ListItem Value="0">Reject</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Risk Unit</TD>
									<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_EMAS_RISK" runat="server"></asp:dropdownlist></TD>
									<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RBL_EMAS_RISK" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
											<asp:ListItem Value="0">Reject</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="middle" align="center" width="70%"><asp:button id="BTN_SAVE" 
                                runat="server" Width="200px" Text="Save Core Approval" CssClass="Button1" 
                                onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
					<tr>
						<td colSpan="2"><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_MC" runat="server" Visible="False"></asp:label><asp:textbox id="TXT_TEMP" runat="server" Width="1px" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></td>
					</tr>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_ACQINFO" runat="server" Width="200px" 
                                Text="Acquire Information" CssClass="Button1"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_UPDATESTATUS" runat="server" Width="200px" CssClass="Button1" Text="Update Status" onclick="BTN_UPDATESTATUS_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
