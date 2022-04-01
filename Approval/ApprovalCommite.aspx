<%@ Page language="c#" Codebehind="ApprovalCommite.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprovalCommite" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Nasabah / Group Info</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
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
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<asp:label id="lbl_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label>
					<TR>
						<TD align="center" colSpan="2">
							<!--
							<iframe id="if1" style="WIDTH: 998px; HEIGHT: 190px" name="if1" src="../SPPK/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view" scrolling="no"></iframe>
							-->
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Approval Commitee</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DGR_APRVCOMMITEE" runat="server" CellPadding="1" PageSize="1" AutoGenerateColumns="False"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="COMMITEE_NAME" HeaderText="Approval">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AD_DECISION" HeaderText="Decision">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COMMITEENEXT_NAME" HeaderText="Next Approval">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ADC_NEXTDATE" HeaderText="Date" DataFormatString="{0:DD-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID><BR>
							<BR>
							<TABLE id="TBL_ENTRY" cellSpacing="2" cellPadding="2" width="100%" border="0" runat="server">
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Current Approval</TD>
												<TD width="14"></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CURR_APRV" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Current Approve Decision</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_DEC_CURR" runat="server" CssClass="mandatory">
														<asp:ListItem Value="-">- SELECT -</asp:ListItem>
														<asp:ListItem Value="1">Approve</asp:ListItem>
														<asp:ListItem Value="2">Reject</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Next Approval</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_NEXT_APRV" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Final&nbsp;Result</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_DEC_FINAL" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_DEC_FINAL_SelectedIndexChanged">
														<asp:ListItem Value="-">- SELECT -</asp:ListItem>
														<asp:ListItem Value="1">Approve</asp:ListItem>
														<asp:ListItem Value="2">Reject</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
										</TABLE>
										<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_MC" runat="server" Visible="False"></asp:label><asp:dropdownlist id="DDL_BU_APRV" runat="server" Visible="False" Enabled="False"></asp:dropdownlist><asp:dropdownlist id="DDL_CRM_APRV" runat="server" Visible="False" Enabled="False"></asp:dropdownlist>
									</TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">BU Approval</TD>
												<TD width="14"></TD>
												<TD class="TDBGColorValue" align="left"><asp:label id="LBL_BU_APPROVAL" runat="server" Width="200px"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">CRM Approval</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:label id="LBL_CRM_APPROVAL" runat="server" Width="200px"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">1st Approval</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:dropdownlist id="DDL_FIRSTAPPRV" runat="server" Enabled="False"></asp:dropdownlist>
													<asp:TextBox id="TXT_TEMP" runat="server" Width="1px" ReadOnly="True" ontextchanged="TXT_TEMP_TextChanged"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">2nd Approval</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:dropdownlist id="DDL_SECONDAPPRV" runat="server" Enabled="False"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
										<asp:label id="LBL_LAST_APPROVAL" runat="server" Visible="False"></asp:label><asp:dropdownlist id="DDL_LASTAPRV" runat="server" Visible="False"></asp:dropdownlist>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save"></asp:button>
							<asp:button id="BTN_ACQINFO" runat="server" CssClass="Button1" Text="Acquire Information" onclick="BTN_ACQINFO_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_UPDATESTATUS" runat="server" Width="120px" CssClass="Button1" Text="Update Status"
								Enabled="False" onclick="BTN_UPDATESTATUS_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
