<%@ Page language="c#" Codebehind="PorGeneralInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PorGeneralInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PorGeneralInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>GENERAL INFO</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR id="TR_ACQINFO" runat="server">
							<TD class="tdheader1" colSpan="2">Information acquired</TD>
						</TR>
						<TR id="TR_ACQINFO1" runat="server">
							<TD colSpan="2"><asp:textbox id="TXT_ACQINFO" Runat="server" ReadOnly="True" TextMode="MultiLine" Width="100%"
									Height="100px"></asp:textbox></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" width="100%" colSpan="2">Remark</TD>
						</TR>
						<TR>
							<TD width="100%" colSpan="2">
								<P><asp:textbox onkeypress="return kutip_satu()" id="TXT_REMARK" Runat="server" TextMode="MultiLine"
										Width="100%" Height="100px"></asp:textbox></P>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Portfolio Watchlist Checking</TD>
						</TR>
						<TR width="100%">
							<TD colSpan="2"><ASP:DATAGRID id="DG_PORWATCH" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
									PageSize="5" AutoGenerateColumns="False">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn HeaderText="No">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="LMS_REGNO"></asp:BoundColumn>
										<asp:BoundColumn DataField="CIF_NO" HeaderText="CIF">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Nasabah">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="SCORE" HeaderText="Scoring">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Account">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
											<ItemTemplate>
												<asp:datagrid id="DG_ACCOUNT" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
													AllowPaging="True" PageSize="10">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="LMS_REGNO"></asp:BoundColumn>
														<asp:BoundColumn DataField="ACC_NO" HeaderText="Acc No.">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="KOL_CURR" HeaderText="Current Kol">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="KOL_LAST6M" HeaderText="Kol 6 Bln">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="Qualitative">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
											<ItemTemplate>
												<asp:datagrid id="DG_QUAL" runat="server" AllowPaging="True" Width="100%" CellPadding="1" AutoGenerateColumns="False"
													PageSize="10">
													<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="LMS_REGNO"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="PORWATCHID"></asp:BoundColumn>
														<asp:BoundColumn DataField="PORWATCHDESC" HeaderText="Watchlist Item">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="ISCHECKED"></asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Compliance">
															<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:radiobuttonlist id="RBL_CHECKED" runat="server" RepeatDirection="Horizontal">
																	<asp:ListItem Value="1">Yes</asp:ListItem>
																	<asp:ListItem Value="0">No</asp:ListItem>
																</asp:radiobuttonlist>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle Mode="NumericPages"></PagerStyle>
												</asp:datagrid>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn HeaderText="Result">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR id="TR_CHECK" runat="server">
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVEQUAL" runat="server" CssClass="Button1" Text="Save Watchlist Checking" onclick="BTN_SAVEQUAL_Click"></asp:button></TD>
						</TR>
						<TR id="TR_REV" runat="server">
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_FWDTOLOANREV" runat="server" CssClass="Button1" Text="Forward To Loan Review" onclick="BTN_FWDTOLOANREV_Click"></asp:button>&nbsp;
								<asp:button id="BTN_FWDTOWATCH" runat="server" CssClass="Button1" Text="Forward to Watchlist" onclick="BTN_FWDTOWATCH_Click"></asp:button>&nbsp;
								<asp:button id="BTN_FINISH" runat="server" CssClass="Button1" Text="Finish" onclick="BTN_FINISH_Click"></asp:button>&nbsp;
								<asp:button id="BTN_NOREVIEW" runat="server" CssClass="Button1" Text="No Review" onclick="BTN_NOREVIEW_Click"></asp:button></TD>
						</TR>
						<TR id="TR_APRV" runat="server">
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_ACQUIRE" runat="server" CssClass="Button1" Text="Acquire Information" onclick="BTN_ACQUIRE_Click"></asp:button>&nbsp;
								<asp:button id="BTN_ACCEPT" runat="server" CssClass="Button1" Text="Accept" onclick="BTN_ACCEPT_Click"></asp:button>&nbsp;
								<asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
