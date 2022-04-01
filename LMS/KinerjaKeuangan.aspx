<%@ Register TagPrefix="uc1" TagName="GenInfo" Src="CommonGeneralInfo.ascx" %>
<%@ Page language="c#" Codebehind="KinerjaKeuangan.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.KinerjaKeuangan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KinerjaKeuangan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<script language="javascript">
			/**
			function update() {
				conf = confirm("Are you sure you want to update?");
				if (conf) {
					return true;
				}
				else {
					return false;
				}
			}**/
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<center>
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table2">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> KINERJA KEUANGAN</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="MainCreditAnalysis.aspx?"></A>
								<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton>
								<A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="SubMenu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<uc1:GenInfo id="GenInfo1" runat="server"></uc1:GenInfo>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
		</center>
	</body>
</HTML>
