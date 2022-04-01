<%@ Page language="c#" Codebehind="BPR.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.MainBPR" %>
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
		<!-- #include file="../include/cek_all.html" -->
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
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Final Scoring : B P R</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD align="right" class="tdNoBorder"><A href="ListScoring.aspx?tc=1.7&amp;mc=006"></A>
							<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../Image/back.jpg" onclick="ImageButton1_Click"></asp:ImageButton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Personal Data</TD>
					</TR>
					<TR>
						<TD class="" colSpan="2">
						
							<iframe id="if1" style="WIDTH: 100%; HEIGHT: 190px" name="if1" src="/SME/SPPK/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view" scrolling="no"></iframe>
						
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"><strong>BPR</strong></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="165"><strong>TOTAL SCORE FI-RATING</strong></TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SR_BPRTOTAL" runat="server" Width="176px" CssClass="angka" onkeypress="return numbersonly();" onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150"><strong>BANK MANDIRI RATING</strong></TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_SR_BPRBMRATING" runat="server" Width="128px" Height="16px"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" Width="140px"></asp:button>&nbsp;
						<%if (Request.QueryString["scr"] != "0") {%>
						<asp:button id="updatestatus" runat="server" Text="Update Status" CssClass="Button1" Width="140px"></asp:button>
						<%}%>
						&nbsp;</TD>
					</TR>
					<tr>
						<td colspan="2" style="VISIBILITY: hidden">
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
