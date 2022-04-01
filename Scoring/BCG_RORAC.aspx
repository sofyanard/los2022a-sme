<%@ Page language="c#" Codebehind="BCG_RORAC.aspx.cs" AutoEventWireup="True" Inherits="SME.RORAC.BCG_RORAC" %>
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
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<CENTER>
			<form id="Form1" method="post" runat="server">
				<TABLE id="Table1">
					<TR>
						<TD style="HEIGHT: 83px">
							<TABLE id="Table2" style="HEIGHT: 170px" cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD colSpan="3">
										<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										</TABLE>
										<TABLE id="Table4" style="WIDTH: 656px" borderColor="black" cellSpacing="1" cellPadding="1"
											width="656" border="1">
											<TR>
												<TD class="tdHeader1" colSpan="6"><STRONG>RORAC Result&nbsp; </STRONG>
												</TD>
											</TR>
											<TR vAlign="top">
												<TD colSpan="3">
													<TABLE width="100%">
														<!--<TR>
															<TD align="center" bgColor="#e5ebf4" colSpan="6"><STRONG>Financial Rating</STRONG></TD>
														</TR>-->
														<TR>
															<TD>
																<TABLE width="100%">
																	<TR vAlign="top">
																		<TD>
																			<TABLE borderColor="black" width="100%" border="1">
																				<TR>
																					<TD class="TDBGColor1" width="25%">RORAC&nbsp;Period</TD>
																					<TD><asp:textbox id="TXT_FINANCIAL_PERIOD" runat="server" ReadOnly="True" Columns="45"></asp:textbox>&nbsp;
																					</TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1" width="25%">Net Annualized Return</TD>
																					<TD><asp:textbox id="TXT_NPAT_ANNUALIZED" runat="server" ReadOnly="True" Columns="45"></asp:textbox>
																						&nbsp;
																						<DIV style="FONT-STYLE: normal; WIDTH: 70px; DISPLAY: inline; FONT-FAMILY: Verdana; HEIGHT: 15px; COLOR: black; FONT-SIZE: 15px"
																							ms_positioning="FlowLayout">(x1000000)</DIV>
																					</TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Total Economic Capital</TD>
																					<TD><asp:textbox id="TXT_ECONOMIC_CAPITAL" runat="server" ReadOnly="True" Columns="45"></asp:textbox>
																						&nbsp;
																						<DIV style="FONT-STYLE: normal; WIDTH: 70px; DISPLAY: inline; FONT-FAMILY: Verdana; HEIGHT: 15px; COLOR: black; FONT-SIZE: 15px"
																							ms_positioning="FlowLayout">(x1000000)</DIV>
																					</TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">RORAC (%)</TD>
																					<TD><asp:textbox id="TXT_RORAC_PRECENTAGE" runat="server" ReadOnly="True" Columns="45"></asp:textbox>&nbsp;
																					</TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">AVE</TD>
																					<TD><asp:textbox id="TXT_AVE" runat="server" ReadOnly="True" Columns="45"></asp:textbox>
																						&nbsp;
																						<DIV style="FONT-STYLE: normal; WIDTH: 70px; DISPLAY: inline; FONT-FAMILY: Verdana; HEIGHT: 15px; COLOR: black; FONT-SIZE: 15px"
																							ms_positioning="FlowLayout">(x1000000)</DIV>
																					</TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">
																						Reference of&nbsp;RORAC (%)</TD>
																					<TD><asp:textbox id="TXT_REQUIREMENT_NILAI_RORAC" runat="server" ReadOnly="True" Columns="45"></asp:textbox>&nbsp;
																					</TD>
																				</TR>
																				<TR>
																					<TD class="TDBGColor1">Reference of AVE</TD>
																					<TD><asp:textbox id="TXT_REQUIREMENT_NILAI_AVE" runat="server" ReadOnly="True" Columns="45"></asp:textbox>
																						&nbsp;
																						<DIV style="FONT-STYLE: normal; WIDTH: 70px; DISPLAY: inline; FONT-FAMILY: Verdana; HEIGHT: 15px; COLOR: black; FONT-SIZE: 15px"
																							ms_positioning="FlowLayout">(x1000000)</DIV>
																					</TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_CU_REF" runat="server" Visible="False"></asp:label>
						</TD>
					</TR>
				</TABLE>
			</form>
		</CENTER>
		<script language="javascript">
		</script>
		</TR></TBODY></TABLE>
	</body>
</HTML>
