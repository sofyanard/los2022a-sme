<%@ Page language="c#" Codebehind="BPRRatingResult.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditAnalysis.BPR.BPRRatingResult" %>
<HTML>
	<HEAD>
		<title>Scoring</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_mandatory.html" -->
		<!-- #include file="../../include/cek_entries.html" -->
		<!-- #include file="../../include/onepost.html" -->
		<!-- #include file="../../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<center>
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1">
					<TR id="TR_KetAmbilScoreTerakhir" runat="server">
						<TD align="center" bgColor="red" colSpan="2"><STRONG><FONT color="#ffffff">Note : 
									Klik&nbsp; <EM>Calculate Rating&nbsp; </EM>untuk mengambil hasil rating 
									terakhir</FONT></STRONG></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 9px" colSpan="2">RATING&nbsp;RESPONSE</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<tr id="tr_hide1" runat="server">
									<td colSpan="3">
										<table width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px">Rating&nbsp;Clasification</TD>
												<TD style="WIDTH: 5px">:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1401" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px">Application Number</TD>
												<TD style="WIDTH: 5px">:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1402" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px" width="208">Date</TD>
												<TD style="WIDTH: 5px">:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1403" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px" width="208">Score</TD>
												<TD style="WIDTH: 5px">:</TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1404" runat="server"></asp:label></TD>
											</TR>
										</table>
									</td>
								</tr>
							</TABLE>
						</TD> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
							<asp:button id="Button1" runat="server" Text="Calculate Rating" CssClass="Button1" onclick="Button1_Click"></asp:button>&nbsp;<asp:button id="updatestatus" runat="server" CssClass="Button1" Text="Update Status" Enabled="False" onclick="updatestatus_Click"></asp:button>&nbsp;</TD>
					</TR>
					<tr>
						<td style="VISIBILITY: hidden" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						</td>
					</tr>
				</TABLE>
			</form>
		</center>
	</body>
</HTML>
