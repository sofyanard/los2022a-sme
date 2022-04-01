<%@ Page language="c#" Codebehind="Collateral_Ar.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.Collateral_Ar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Suku Bunga</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../../../include/cek_all.html" -->
		<!-- #include  file="../../../include/cek_entries.html" -->
		<SCRIPT language="JavaScript">
		function win(){
			window.opener.location.href="window-refreshing.php";
			self.close();
			
		}
		
		function RefreshParent(){
		   parent.location.reload();
}
		</SCRIPT>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Penarikan/Penerbitan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<A href="ListCustomer.aspx?si="></A>
							<asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg"></asp:imagebutton>
							<A href="../../../Body.aspx"><IMG height="25" src="../../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Simulasi Suku Bunga</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_LOANACCOUNT" runat="server">Loan Account :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_LOANACCOUNT" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TENOR" runat="server">Tenor :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_TENOR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_FIXEDRATE" runat="server">Fixed Rate :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FIXEDRATE" runat="server" Width="100%"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:label id="Label2" runat="server"> %</asp:label></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_FLOATINGRATE" runat="server">Floating Rate :</asp:label></TD>
									<TD class="TDBGColorValue" width="40%"><asp:dropdownlist id="DDL_FLOAT" runat="server" Width="100%"></asp:dropdownlist></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_FLOAT" runat="server"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:label id="Label1" runat="server"> %</asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_VAR" runat="server">Variance:</asp:label></TD>
									<TD class="TDBGColorValue" width="40%"><asp:dropdownlist id="DDL_VAR" runat="server" Width="100%"></asp:dropdownlist></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_VAR" runat="server"></asp:textbox></TD>
									<TD class="TDBGColorValue"><asp:label id="Label4" runat="server"> %</asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_INSTALL" runat="server">Installment :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="3"><asp:textbox id="TXT_INSTALL" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label><asp:button id="BTN_INSERT" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_INSERT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="100px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DG_SUKUBUNGA" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENOR" HeaderText="Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FIXED_RATE" HeaderText="Fixed Rate">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FLOATING_RATE" HeaderText="Floating Rate">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CODE" HeaderText="Code">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="VARIANCE" HeaderText="Variance">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSTALLMENT" HeaderText="Installment">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="Label3" runat="server" Visible="False"></asp:label><asp:button id="BTN_SIMULATE" runat="server" Width="100px" CssClass="button1" Text="SIMULATE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_VIEW" runat="server" Width="100px" CssClass="button1" Text="VIEW"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Simulasi Alternatif Pencairan</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_LOANACCOUNT2" runat="server">Loan Account :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_LOANACCOUNT2" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_BULAN" runat="server">Jumlah Bulan :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_BULAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_PERSEN" runat="server">% :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PERSEN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_PENCAIRAN" runat="server">Jumlah Pencairan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENCAIRAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="Label14" runat="server" Visible="False"></asp:label><asp:button id="BTN_INSERT2" runat="server" Width="100px" CssClass="button1" Text="INSERT"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR2" runat="server" Width="100px" CssClass="button1" Text="CLEAR"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DG_PENCAIRAN" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JUMLAHBULAN" HeaderText="Jumlah Bulan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERSEN" HeaderText="%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JUMLAHCAIR" HeaderText="Jumlah Pencairan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="Label15" runat="server" Visible="False"></asp:label><asp:button id="BTN_SIMULATE2" runat="server" Width="100px" CssClass="button1" Text="SIMULATE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_VIEW2" runat="server" Width="100px" CssClass="button1" Text="VIEW"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Simulasi Alternatif Pembayaran</TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_LOANACCOUNT3" runat="server">Loan Account :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2">
										<asp:dropdownlist id="DDL_LOANACCOUNT3" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_BULAN2" runat="server">Jumlah Bulan :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox id="TXT_BULAN2" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_PERSEN2" runat="server">% :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PERSEN2" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_JUMLAHBAYAR" runat="server">Jumlah :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JUMLAHBAYAR" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_KODE" runat="server">Kode Pembayaran :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2">
										<asp:dropdownlist id="DDL_KODE" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="Label9" runat="server" Visible="False"></asp:label>
							<asp:button id="Button1" runat="server" Width="100px" CssClass="button1" Text="INSERT"></asp:button>&nbsp;&nbsp;
							<asp:button id="Button2" runat="server" Width="100px" CssClass="button1" Text="CLEAR"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DG_PEMBAYARAN" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JUMLAHBULAN" HeaderText="Jumlah Bulan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERSEN" HeaderText="%">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="JUMLAH" HeaderText="Jumlah">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KODE" HeaderText="Kode Pembayaran">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton3" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="Linkbutton4" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="Label10" runat="server" Visible="False"></asp:label>
							<asp:button id="BTN_SIMULATE3" runat="server" Width="100px" CssClass="button1" Text="SIMULATE"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_VIEW3" runat="server" Width="100px" CssClass="button1" Text="VIEW"></asp:button></TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
