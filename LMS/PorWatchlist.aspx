<%@ Page language="c#" Codebehind="PorWatchlist.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PorWatchlist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PorWatchlist</title>
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>WATCHLIST</B></TD>
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
						<TR id="Tr1" runat="server">
							<TD class="tdheader1" colSpan="2">Portfolio Watchlist Checking Summary</TD>
						</TR>
						<TR>
							<TD colSpan="2"><ASP:DATAGRID id="DG_PORWATCH" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="5"
									CellPadding="1" AllowPaging="True">
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
										<asp:BoundColumn DataField="PORWATCHLIST_REASON" HeaderText="Penyebab Watchlist">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Left"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="PORACCOUNT_STRATEGY"></asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Account Strategi">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:DropDownList id="DDL_ACCSTRAT" runat="server"></asp:DropDownList>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:BoundColumn Visible="False" DataField="TARGET_PELAKSANAAN"></asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Target Pelaksanaan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:textbox onkeypress="return numbersonly()" id="TXT_TARGET_PELAKSANAAN_DAY" runat="server"
													Columns="3" MaxLength="2"></asp:textbox>
												<asp:dropdownlist id="DDL_TARGET_PELAKSANAAN_MONTH" runat="server"></asp:dropdownlist>
												<asp:textbox onkeypress="return numbersonly()" id="TXT_TARGET_PELAKSANAAN_YEAR" runat="server"
													Columns="5" MaxLength="4"></asp:textbox>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></TD>
						</TR>
						<TR id="TR_CHECK" runat="server">
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVESUMM" runat="server" CssClass="Button1" Text="Save Watchlist Checking Summary" onclick="BTN_SAVESUMM_Click"></asp:button></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" width="100%" colSpan="2">Decision</TD>
						</TR>
					</TBODY>
				</TABLE>
				<TABLE>
					<TR>
						<TD width="50%" colSpan="2">
							<TABLE>
								<TR id="TR_WEWENANG" runat="server">
									<TD class="TDBGColor1" vAlign="middle">Wewenang Memutus</TD>
									<TD vAlign="middle"><asp:dropdownlist id="DDL_WEWENANG" Runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									<TD vAlign="middle"><asp:button id="BTN_SAVE" Runat="server" CssClass="button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
				<TABLE>
					<TR id="TR_UPDATE" runat="server">
						<TD class="tdBGColor2" vAlign="top" align="center" colSpan="3"><asp:button id="BTN_UPDATE" Runat="server" Width="200px" CssClass="button1" Text="Forward to Acceptance" onclick="BTN_UPDATE_Click"></asp:button></TD>
					</TR>
					<TR id="TR_ADVIS" runat="server">
						<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle">Advis 
							Assign to</TD>
						<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="top"><asp:dropdownlist id="DDL_ADVIS" Runat="server"></asp:dropdownlist></TD>
						<TD class="tdBGColor2" style="WIDTH: 500px; HEIGHT: 15px" vAlign="top" align="center"><asp:button id="BTN_ADVIS" Runat="server" Width="200px" CssClass="Button1" Text="Assign to Advis" onclick="BTN_ADVIS_Click"></asp:button></TD>
					</TR>
					<TR id="TR_ADVISREPLY" runat="server">
						<TD class="tdBGColor2" align="center" colSpan="3"><asp:button id="BTN_ADVISREPLY" Runat="server" Width="200px" CssClass="button1" Text="Forward to Acceptance" onclick="BTN_ADVISREPLY_Click"></asp:button></TD>
					</TR>
					<TR id="TR_FORWARD" runat="server">
						<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle"><asp:label id="LBL_FORWARD" Runat="server">Next Acceptance Forward to</asp:label></TD>
						<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="top"><asp:dropdownlist id="DDL_FORWARD" Runat="server"></asp:dropdownlist></TD>
						<TD class="tdBGColor2" style="WIDTH: 500px; HEIGHT: 15px" vAlign="top" align="center"><asp:button id="BTN_FORWARD" Runat="server" Width="200px" CssClass="Button1" Text="Forward" onclick="BTN_FORWARD_Click"></asp:button></TD>
					</TR>
					<TR id="TR_ACCEPT" runat="server">
						<TD class="tdBGColor2" align="center" colSpan="3"><asp:button id="BTN_ACCEPT" Runat="server" Width="200px" CssClass="button1" Text="Accept" onclick="BTN_ACCEPT_Click"></asp:button></TD>
					</TR>
					<TR id="TR_ACQINFO2" runat="server">
						<TD class="tdBGColor2" align="center" colSpan="3"><asp:button id="BTN_ACQINFO" Runat="server" Width="200px" CssClass="button1" Text="Acquire Information" onclick="BTN_ACQINFO_Click"></asp:button><asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
