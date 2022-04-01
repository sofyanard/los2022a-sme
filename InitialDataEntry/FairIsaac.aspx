<%@ Page language="c#" Codebehind="FairIsaac.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.MainFairIsaac" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Initial Scoring</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListScoring.aspx?tc=1.7&amp;mc=006"></A>
							<A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">FAIR ISAAC</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Overall STW Decision</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_SR_OVERALL" runat="server" CssClass="mandatory">
											<asp:ListItem Value="">- Pilih -</asp:ListItem>
										</asp:DropDownList><asp:textbox id="TXT_SR_OVERALL" CssClass="angka" runat="server" Width="150px" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 14px">Score Result</TD>
									<TD style="HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px">
										<asp:DropDownList id="DDL_SR_SCORE" runat="server" CssClass="mandatory">
											<asp:ListItem Value="">- Pilih -</asp:ListItem>
										</asp:DropDownList><asp:textbox id="TXT_SR_SCORE" CssClass="angka" runat="server" Width="150px" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Visit Indicator</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_SR_VISITINDCTR" runat="server">
											<asp:ListItem Value="">- Pilih -</asp:ListItem>
										</asp:DropDownList><asp:textbox id="TXT_SR_VISITINDCTR" CssClass="angka" runat="server" Width="150px" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="150">Rule Reason Codes</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_SR_RULECODE" runat="server">
											<asp:ListItem Value="">- Pilih -</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Credit Proposal Indicator</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_CREDPROP" runat="server">
											<asp:ListItem Value="">- Pilih -</asp:ListItem>
										</asp:DropDownList>
										<asp:textbox id="TXT_SR_CREDPROPOSAL" runat="server" CssClass="angka" Visible="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px">Manual Review Type</TD>
									<TD style="HEIGHT: 18px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 18px">
										<asp:DropDownList id="DDL_SR_MANREVIEW" runat="server">
											<asp:ListItem Value="">- Pilih -</asp:ListItem>
										</asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit Kalkulasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_SR_RESULT" onkeypress="return digitsonly()" onblur="FormatCurrency(this)"
											runat="server" Width="176" MaxLength="15"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<TD class="TDBGColor1">Decision</TD>
									<td width="15"></td>
									<td>
										<asp:DropDownList id="DDL_SR_DECISION" runat="server">
											<asp:ListItem Value="- Pilih -">- Pilih -</asp:ListItem>
										</asp:DropDownList></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 20px">Kode Override</TD>
									<td style="HEIGHT: 20px"></td>
									<td style="HEIGHT: 20px">
										<asp:DropDownList id="DDL_SR_OVERRIDE" runat="server">
											<asp:ListItem Value="- Pilih -">- Pilih -</asp:ListItem>
										</asp:DropDownList></td>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 18px">Score Recommendation</TD>
									<TD style="HEIGHT: 18px"></TD>
									<td style="HEIGHT: 18px">
										<asp:DropDownList id="DDL_SR_SCRRECOMM" runat="server">
											<asp:ListItem Value="- Pilih -">- Pilih -</asp:ListItem>
										</asp:DropDownList></td>
								</TR>
								<tr>
									<TD class="TDBGColor1">Decision Set By</TD>
									<td></td>
									<td>
										<asp:DropDownList id="DDL_SR_DECSETBY" runat="server">
											<asp:ListItem Value="- Pilih -">- Pilih -</asp:ListItem>
										</asp:DropDownList></td>
								</tr>
							</TABLE>
							<asp:Label id="LBL_USERID" runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" Width="75px" CssClass="BUTTON1" onclick="BTN_SAVE_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:button id="Button1" runat="server" Width="130px" Text="Print Letter" Visible="False" CssClass="Button1" onclick="Button1_Click"></asp:button>&nbsp;<asp:button id="updatestatus" runat="server" Text="Update Status" CssClass="Button1" Width="130px"
								Visible="False" onclick="updatestatus_Click"></asp:button>&nbsp;</TD>
					</TR>
					<tr>
						<td colspan="2" style="VISIBILITY: hidden">
							<asp:CompareValidator id="SROVERALL_VALID" runat="server" ErrorMessage="Overall STW Decision harus angka"
								ControlToValidate="TXT_SR_OVERALL" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>&nbsp;
							<asp:CompareValidator id="SRSCORE_VALID" runat="server" ErrorMessage="Score Result harus angka" ControlToValidate="TXT_SR_SCORE"
								Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>&nbsp;
							<asp:CompareValidator id="SRVISITINDCTR_VALID" runat="server" ErrorMessage="Visit Indicator harus angka"
								ControlToValidate="TXT_SR_VISITINDCTR" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>&nbsp;
							<asp:CompareValidator id="SRRULECODE_VALID" runat="server" ErrorMessage="Rule Reason Codes harus angka"
								ControlToValidate="TXT_SR_RULECODE" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>&nbsp;
							<asp:CompareValidator id="SRCREDPROP_VALID" runat="server" ErrorMessage="Credit Proposal Indicator harus angka"
								ControlToValidate="TXT_SR_CREDPROPOSAL" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>&nbsp;
							<asp:CompareValidator id="SRMANREV_VALID" runat="server" ErrorMessage="Manual Review Type harus angka"
								ControlToValidate="TXT_SR_MANREVIEWTYPE" Operator="DataTypeCheck" Type="Double">*</asp:CompareValidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:textbox id="TXT_SR_RULECODE" CssClass="angka" runat="server" Width="176px" Visible="False"></asp:textbox><asp:textbox id="TXT_SR_MANREVIEWTYPE" CssClass="angka" runat="server" Width="176" Visible="False"></asp:textbox>
							<asp:ValidationSummary id="VALID_SUMMARY" runat="server" ShowMessageBox="True" Height="42px"></asp:ValidationSummary>
						</td>
					</tr>
				</TABLE>
			</center>
		</form>
		<script language="javascript">
		/***
	function update() {
		ans = confirm("Are you sure you want to update?");
		
		if (ans) {
			return true;
		}
		else {
			return false;
		}
	}***/
		</script>
	</body>
</HTML>
