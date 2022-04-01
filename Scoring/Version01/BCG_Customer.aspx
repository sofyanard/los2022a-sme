<%@ Page language="c#" Codebehind="BCG_Customer.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.Version01.BCG_Customer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
		<!-- #include file="../../include/onepost.html" -->
		<!-- #include file="../../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="90%" border="0">
					<TR>
						<TD style="HEIGHT: 83px">
							<TABLE id="Table2" style="HEIGHT: 170px" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="tdHeader1" colSpan="3">
										<asp:Label id="LABEL" runat="server" Width="56px" Height="16px">Customer</asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 418px; HEIGHT: 20px" width="418">Customer 
										Financial Risk Grade</TD>
									<TD style="HEIGHT: 20px" width="15"></TD>
									<TD style="HEIGHT: 20px">
										<asp:DropDownList id="DDL_SR_RISKGRADE" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SR_RISKGRADE_SelectedIndexChanged"></asp:DropDownList>
										<asp:TextBox id="TXT_RISKGRADE" runat="server" Height="19px" Width="125px" ReadOnly="True"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px; TEXT-ALIGN: center" colspan="3"><STRONG>After 
											Payment History &amp; Qualitative Ranting Industry Review</STRONG></TD>
									<!--
									<TD style="HEIGHT: 20px" width="15"></TD>
									<TD style="HEIGHT: 20px">									
									</TD>
									-->
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 418px; HEIGHT: 5px" width="418">Class Upgrade</TD>
									<TD style="HEIGHT: 5px" width="15"></TD>
									<TD style="HEIGHT: 5px">
										<asp:DropDownList id="DDL_SR_CLSGRADE" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SR_CLSGRADE_SelectedIndexChanged"></asp:DropDownList>
										<asp:TextBox id="TXT_CLSGRADE" runat="server" Height="19px" Width="125px" ReadOnly="True"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="" colspan="3"></TD>
									<!--
									<TD style="HEIGHT: 20px" width="15"></TD>
									<TD style="HEIGHT: 20px">
									</TD>
									-->
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 418px; HEIGHT: 20px" width="418">Financial and 
										Qualitative Rating</TD>
									<TD style="HEIGHT: 20px" width="15"></TD>
									<TD style="HEIGHT: 20px">
										<asp:DropDownList id="DDL_BCGFINRATING" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BCGFINRATING_SelectedIndexChanged"></asp:DropDownList>
										<asp:TextBox id="TXT_RISKTYPE" runat="server" Height="19px" Width="125px" ReadOnly="True"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 418px">Probability of Default (P(d))</TD>
									<TD></TD>
									<TD>
										<asp:TextBox id="TXT_SR_BCGPROBDEF" runat="server" Width="136px" Height="19px" CssClass="angka"
											onkeypress="return numbersonly();"></asp:TextBox></TD>
								</TR>
								<tr>
									<td colspan="2">
									</td>
								</tr>
							</TABLE>
							<asp:Label id="LBL_SR_BCGYRAVG" runat="server" Height="16px" Width="24px" Visible="False"></asp:Label>
							<asp:Label id="LBL_CU_REF" runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD align="center" class="TDBGColor2">
							<asp:button id="btnSave" runat="server" CssClass="Button1" Text="Save" Width="140px" onclick="btnSave_Click"></asp:button>&nbsp;
							<%if (Request.QueryString["scr"] != "0") {%>
							<asp:button id="btnUpdateStatus" runat="server" CssClass="Button1" Text="Update Status" Width="140" onclick="btnUpdateStatus_Click"></asp:button>
							<%}%>
							</TD>
					</TR>
					<tr>
						<td style="VISIBILITY: hidden">
							<asp:CompareValidator id="PROBDEF_VALID" runat="server" ErrorMessage="<li> Probability of Default harus angka"
								ControlToValidate="TXT_SR_BCGPROBDEF" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator><BR>
							<asp:ValidationSummary id="VALID_SUMMARY" runat="server" ShowMessageBox="True"></asp:ValidationSummary>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
	<script language=javascript>
	/**
	function update() {
		ans = confirm("Are you sure you want to update?");
		
		if (ans) {
			return true;
		}
		else {
			return false;
		}
	}**/
	</script>
</HTML>
