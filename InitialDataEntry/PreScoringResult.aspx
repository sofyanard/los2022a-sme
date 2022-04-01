<%@ Page language="c#" Codebehind="PreScoringResult.aspx.cs" AutoEventWireup="True" Inherits="SME.Scoring.PreScoringResult" %>
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
						<TD class="tdNoBorder" align="right"><A href="ListScoring.aspx?tc=1.7&amp;mc=006"></A><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<P><asp:placeholder id="Menu" runat="server"></asp:placeholder></P>
							<P><asp:button id="BTN_SEND_ULANG" runat="server" Enabled="False" DESIGNTIMEDRAGDROP="29" Text="Send Ulang"
									Width="100px" CssClass="Button1" Visible="False" onclick="BTN_SEND_ULANG_Click"></asp:button><asp:button id="Button2" runat="server" Text="Retrieve Response" Width="134px" CssClass="Button1"
									Visible="False" onclick="Button2_Click"></asp:button>&nbsp;&nbsp;&nbsp;
								<asp:textbox id="OSC_FINAL_SCORE" runat="server" Width="80px" CssClass="angka" Visible="False"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;</P>
						</TD>
					</TR>
					<TR>
						<TD align="center" bgColor="red" colSpan="2"><STRONG><FONT color="#ffffff">Note : Klik <EM>Calculate</EM>
									ulang untuk mengambil hasil scoring terakhir</FONT></STRONG></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 9px" colSpan="2">SCORING&nbsp;RESPONSE</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 208px">Overal Strategy Ware Decision</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_OHD_SYS_DECISION" runat="server"></asp:label><asp:label id="LBL_OHD_SYS_DECISION_HIDDEN" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 208px">Score Clasifcation</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_A1401" runat="server"></asp:label><asp:label id="LBL_A1401_HIDEN" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<tr id="tr_hide1" runat="server">
									<td colSpan="3">
										<table width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px">Visit Indicator</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1402" runat="server"></asp:label><asp:label id="lblCounter" runat="server" Visible="False">0</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px" width="208">Financial Analysis Format</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1403" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px">Manual Review Type</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1404" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px">Pricing Class&nbsp;</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_A1405" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 208px">% Increase Requested</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:label id="LBL_G0001" runat="server"></asp:label></TD>
											</TR>
										</table>
									</td>
								</tr>
								<TR>
									<TD style="WIDTH: 208px"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 208px">Status Response</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></TD>
					</TR> <!-- ************************* separator *************------------------------------------------------------------------------------------------------------------------------------------------->
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 9px" colSpan="2">RULE REASON</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" colSpan="2"><ASP:DATAGRID id="dtGrid" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="REASON_CODE" HeaderText="Rule Reason Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DESCRIPTION" HeaderText="Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="TR_MICLOW" runat="server">
						<td class="tdNoBorder" colSpan="2">
							<TABLE id="TableMICLOW" cellSpacing="2" cellPadding="2" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">MICRO/LOWLINE</TD>
								</TR>
								<TR>
									<td class="tdNoBorder" align="center" colSpan="2">
										<TABLE id="TableMICLOWIN" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">w.c. Micro/Lowline Limit (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0002A" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">w.c. Kumlta Limit (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0004" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">w.c. Micro Limit (New Facility) 
													(ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0005" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">Low Line&nbsp;: Inv.Loan Std.Limit 
													(ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0006" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">Inv. Loan Micro Limit (New Facility) 
													(ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0007" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">Inv.Loan KUMLTA Limit (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0008" runat="server"></asp:label><asp:label id="LBL_A1407" runat="server" Visible="False"></asp:label><asp:label id="LBL_A1415" runat="server" Visible="False"></asp:label><asp:label id="LBL_A1412" runat="server" Visible="False"></asp:label><asp:label id="LBL_A1411" runat="server" Visible="False"></asp:label><asp:label id="LBL_A1414" runat="server" Visible="False"></asp:label><asp:label id="LBL_A1413" runat="server" Visible="False"></asp:label><asp:label id="LBL_A1410" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">
													<P>&nbsp;</P>
												</TD>
												<TD>&nbsp;&nbsp;&nbsp;</TD>
											</TR>
										</TABLE>
									</td>
								</TR> <!-- ************************* separator *************-------------------------------------------------------------------------------------------------------------------------------------------></TABLE>
						</td>
					</TR>
					<TR id="TR_PUKK" runat="server">
						<TD class="tdNoBorder" colSpan="2">
							<TABLE id="TablePUKK" cellSpacing="2" cellPadding="2" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">PUKK</TD>
								</TR>
								<TR>
									<td class="tdNoBorder" align="center" colSpan="2">
										<TABLE id="TablePUKKIN" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px"><P>w.c. PUKK Limit (ribuan)</P>
												</TD>
												<TD>&nbsp;&nbsp;
													<asp:label id="LBL_G0003" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">Ttl.Asset Less Lnd (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0031" runat="server"></asp:label><asp:label id="LBL_A1408" runat="server" Visible="False"></asp:label><asp:label id="Label2" runat="server" Visible="False">w.c. PUKK Multiplier</asp:label><asp:label id="LBL_A1409" runat="server" Visible="False"></asp:label>
													<asp:Label id="Label3" runat="server" Visible="False">Inv.Loan Multiplier </asp:Label><asp:textbox id="Textbox8" onblur="FormatCurrency(this)" runat="server" Width="128px" Visible="False"
														ReadOnly="True"></asp:textbox><asp:label id="Label4" runat="server">Termin (dalam bulan)</asp:label></TD>
											</TR>
										</TABLE>
									</td>
								</TR> <!-- ************************* separator *************-------------------------------------------------------------------------------------------------------------------------------------------></TABLE>
						</TD>
					</TR>
					<TR id="TR_SB" runat="server">
						<TD class="tdNoBorder" colSpan="2">
							<TABLE id="TableSB" cellSpacing="2" cellPadding="2" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">SMALL BUSINESS</TD>
								</TR>
								<TR>
									<TD class="tdNoBorder" align="center" colSpan="2">
										<TABLE id="TableSBIN" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">Inv.Loan Std.Limit (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0006A" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px"><P>w.c. Contractor Routine Limit Plafond 
														(ribuan)</P>
												</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0009" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">w.c. Contractor Termyn (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0010" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">w.c. Contractor Turnkey (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0011" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">w.c. SB 100 - 500 Mill Limit (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0012" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px">w.c. SB&gt;500 Mill Limit (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0013" runat="server"></asp:label><asp:label id="LBL_G0002" runat="server" Visible="False"></asp:label><asp:label id="LBL_A1405A" runat="server" Visible="False"></asp:label><asp:label id="Label1" runat="server" Visible="False">Pricing Class</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 18px">SB Bid Bond pa (ribuan)</TD>
												<TD style="HEIGHT: 18px">&nbsp;
													<asp:label id="LBL_G0014" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 20px">SB Advance Bond pa 
													(ribuan)</TD>
												<TD style="HEIGHT: 20px">&nbsp;
													<asp:label id="LBL_G0015" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 21px">SB Performance Bond pa 
													(ribuan)</TD>
												<TD style="HEIGHT: 21px">&nbsp;
													<asp:label id="LBL_G0016" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 19px">SB Retention Bond pa 
													(ribuan)</TD>
												<TD style="HEIGHT: 19px">&nbsp;
													<asp:label id="LBL_G0017" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 19px">SB Purchasing Bond pa 
													(ribuan)</TD>
												<TD style="HEIGHT: 19px">&nbsp;
													<asp:label id="LBL_G0018" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 19px">SB Total B/G Limit pa 
													(ribuan)</TD>
												<TD style="HEIGHT: 19px">&nbsp;
													<asp:label id="LBL_G0019" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 5px">SB L/C Limit (ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0020" runat="server"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR> <!-- ************************* separator *************-------------------------------------------------------------------------------------------------------------------------------------------></TABLE>
						</TD>
					</TR>
					<TR id="TR_MC" runat="server">
						<td class="tdNoBorder" colSpan="2">
							<TABLE id="TableMC" cellSpacing="2" cellPadding="2" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">MIDLLE CLASS BUSINESS</TD>
								</TR>
								<TR>
									<td class="tdNoBorder" align="center" colSpan="2">
										<TABLE id="TableMCIN" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 21px">Inv.Loan Std.Limit 
													(ribuan)</TD>
												<TD>&nbsp;
													<asp:label id="LBL_G0006B" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 294px; HEIGHT: 21px">MC Working Capital Limit 
													(jutaan)</TD>
												<TD style="HEIGHT: 21px">&nbsp;
													<asp:label id="LBL_G0021" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 20px">&nbsp;MC Contractor 
													Progress Payment&nbsp;&nbsp;Limit (ribuan)</TD>
												<TD style="HEIGHT: 20px">&nbsp;
													<asp:label id="LBL_G0022" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 20px">&nbsp;MC Contractor 
													Palfond&nbsp;Limit&nbsp;(ribuan)</TD>
												<TD style="HEIGHT: 20px">&nbsp;
													<asp:label id="LBL_G0023" runat="server"></asp:label><asp:label id="LBL_A1419" runat="server" Visible="False"></asp:label><asp:label id="Label5" runat="server" Visible="False">MC Non-Cash B/G-L/C Plafond Multiplier</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 20px">Contractor Turnkey 
													(ribuan)</TD>
												<TD style="HEIGHT: 20px">&nbsp;
													<asp:label id="LBL_G0011A" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 21px">MC Bid Bond (ribuan)
												</TD>
												<TD style="HEIGHT: 21px">&nbsp;
													<asp:label id="LBL_G0024" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 23px">MC Advance Bond&nbsp; 
													(ribuan)
												</TD>
												<TD style="HEIGHT: 23px">&nbsp;
													<asp:label id="LBL_G0025" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 23px">MC Performance Bond 
													(ribuan)</TD>
												<TD style="HEIGHT: 23px">&nbsp;
													<asp:label id="LBL_G0026" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 19px">MC Retention Bond&nbsp; 
													(ribuan)
												</TD>
												<TD style="HEIGHT: 19px">&nbsp;
													<asp:label id="LBL_G0027" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 23px">&nbsp;MC Bond Other than 
													Contractor (ribuan)</TD>
												<TD style="HEIGHT: 23px">&nbsp;
													<asp:label id="LBL_G0028" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 21px">MC NCash B/G Plafond 
													(ribuan)</TD>
												<TD style="HEIGHT: 21px">&nbsp;
													<asp:label id="LBL_G0029" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 293px; HEIGHT: 21px">&nbsp;% MC L/C 
													Limit&nbsp; (ribuan)</TD>
												<TD style="HEIGHT: 21px">&nbsp;
													<asp:label id="LBL_G0030" runat="server"></asp:label><asp:label id="lbl_AUDITDESC" runat="server" Visible="False">Pre-scoring - Update status</asp:label></TD>
											</TR>
										</TABLE>
									</td>
								</TR> <!-- ************************* separator *************-------------------------------------------------------------------------------------------------------------------------------------------></TABLE>
						</td>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="Button1" runat="server" DESIGNTIMEDRAGDROP="602" Text="Print Letter" Width="150px"
								CssClass="Button1" onclick="Button1_Click"></asp:button>&nbsp;<asp:button id="updatestatus" runat="server" Text="Update Status" Width="150px" CssClass="Button1"
								Enabled="False" onclick="updatestatus_Click"></asp:button>&nbsp;<asp:button id="BTN_PRN_SCORING" runat="server" Text="Print Scoring Result" Width="155px" CssClass="Button1" onclick="BTN_PRN_SCORING_Click"></asp:button></TD>
					</TR>
					<tr>
						<td style="VISIBILITY: hidden" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
