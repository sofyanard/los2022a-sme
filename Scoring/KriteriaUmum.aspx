<%@ Page language="c#" Codebehind="KriteriaUmum.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.MainKU" %>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Final Scoring : CRSS 
											Score Sheet</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD align="right" class="tdNoBorder"><A href="ListScoring.aspx?tc=1.7&amp;mc=006"></A>&nbsp;
							<asp:ImageButton id="ImageButton1" runat="server" ImageUrl="../Image/back.jpg"></asp:ImageButton>
							<A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
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
						<TD class="tdHeader1" colSpan="2">CRSS Score Sheet</TD>
					</TR>
					<TR>
						<TD vAlign="top" colspan="2" class="td">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="129"><STRONG>Total </STRONG>
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_SR_KUTOTAL" runat="server" Width="150px" CssClass="angka" onkeypress="return numbersonly();"
											onblur="FormatCurrency(this)"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"><STRONG>Actual Risk Factor </STRONG>
									</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_SR_KURISKFACTOR" onkeypress="return kutip_satu()" runat="server" Width="150px"></asp:textbox></TD>
								</TR>
							</TABLE>
							<table width="376">
								<tr>
									<td width="100%"></td>
								</tr>
								<tr>
									<td width="100%">
										Determination of BI rating (Risk Factor) and loan Loss Provision
									</td>
								</tr>
								<tr>
									<td valign="top">
										<table width="100%" align="left">
											<tr>
												<td width="20%" style="HEIGHT: 5px">7-15</td>
												<td width="5%" style="HEIGHT: 5px">=</td>
												<td width="15%" style="HEIGHT: 5px">Ia</td>
												<td width="60%" style="HEIGHT: 5px">1 % general provision</td>
											</tr>
											<tr>
												<td style="HEIGHT: 5px">16-20</td>
												<td style="HEIGHT: 5px">=</td>
												<td style="HEIGHT: 5px">Ib</td>
												<td style="HEIGHT: 5px">1 % general provision</td>
											</tr>
											<tr>
												<td style="HEIGHT: 5px">21-28</td>
												<td style="HEIGHT: 5px">=</td>
												<td style="HEIGHT: 5px">Ic</td>
												<td style="HEIGHT: 5px">1 % general provision</td>
											</tr>
											<tr>
												<td style="HEIGHT: 5px">29-35</td>
												<td style="HEIGHT: 5px">=</td>
												<td style="HEIGHT: 5px">II</td>
												<td style="HEIGHT: 5px">Min. 5 % - Max. 14,99 %</td>
											</tr>
											<tr>
												<td style="HEIGHT: 5px">36-42</td>
												<td style="HEIGHT: 5px">=</td>
												<td style="HEIGHT: 5px">III</td>
												<td style="HEIGHT: 5px">Min. 15 % - Max. 49,99 %</td>
											</tr>
											<tr>
												<td style="HEIGHT: 5px">43-49</td>
												<td style="HEIGHT: 5px">=</td>
												<td style="HEIGHT: 5px">IV</td>
												<td style="HEIGHT: 5px">Min. 50 % - Max. 99,99 %</td>
											</tr>
											<tr>
												<td style="HEIGHT: 5px">&gt; 50</td>
												<td style="HEIGHT: 5px">=</td>
												<td style="HEIGHT: 5px">V</td>
												<td style="HEIGHT: 5px">100 %</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" Width="140px"></asp:button>&nbsp; 
							<%if (Request.QueryString["scr"] != "0") {%>
						<asp:button id="updatestatus" runat="server" Text="Update Status" CssClass="Button1" Width="140px"></asp:button>
						<%}%> 
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
		<script language="javascript">
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
	</body>
</HTML>
