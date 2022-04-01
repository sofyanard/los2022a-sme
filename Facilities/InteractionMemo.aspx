<%@ Page language="c#" Codebehind="InteractionMemo.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.InteractionMemo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InteractionMemo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			a = confirm("Are you sure want to finish ?");
			if (a)
				window.location = "CustInteraction.aspx";
		}
		</script>
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD class="TDBGColorValue">
						<TABLE cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD class="tdNoBorder" width="421">
									<TABLE id="Table6">
										<TR>
											<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Interaction Memo</B></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
							</TR>
							<TR>
								<TD class="tdSmallHeader" colSpan="2">DATA PRIBADI</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" width="50%">
									<TABLE class="td" width="100%">
										<TR>
											<TD class="TDBGColor1" width="100">Nomor Aplikasi</TD>
											<TD width="9">:</TD>
											<TD class="TDBGColorValue">
												<asp:label id="LBL_APPNO" runat="server" Font-Bold="True"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Nama</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue">
												<asp:label id="LBL_NAME" runat="server" Font-Bold="True"></asp:label>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
								<TD align="center" width="50%" valign="top">
									<TABLE class="td" width="100%">
										<TR>
											<TD class="TDBGColor1" width="100">
												CIF</TD>
											<TD width="9">:</TD>
											<TD class="TDBGColorValue">
												<asp:label id="LBL_CIF" runat="server" Font-Bold="True"></asp:label>&nbsp;</TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">NPWP</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue">
												<asp:label id="LBL_NPWP" runat="server" Font-Bold="True"></asp:label>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center" colspan="2">
									<asp:DataGrid id="DGR_PRODUCT" Runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
										Width="100%">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="PRODUCTID" HeaderText="Product ID">
												<HeaderStyle Width="100px" CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="productdesc" HeaderText="Product">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="tenor" HeaderText="Tenor">
												<HeaderStyle Width="100px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cp_limit" HeaderText="Limit">
												<HeaderStyle Width="120px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="status" HeaderText="Status">
												<HeaderStyle Width="120px" CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:DataGrid>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="TDBGColorValue">
						<TABLE cellSpacing="2" cellPadding="2" width="100%" align="center" border="1">
							<TR>
								<TD width="100%"></TD>
							</TR>
							<TR>
								<TD class="tdSmallHeader" width="100%">COMMENT</TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue">
									<asp:TextBox onkeypress="return kutip_satu()" id="TXT_COMMENT" runat="server" Width="98%" TextMode="MultiLine"
										Rows="5" MaxLength="500"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="tdSmallHeader" align="center" width="100%">ANSWER</TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue">
									<asp:TextBox onkeypress="return kutip_satu()" id="TXT_ANSWER" runat="server" Width="98%" Rows="5"
										TextMode="MultiLine" MaxLength="500"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor2">
									<asp:button id="BTN_FIND" runat="server" Text="SAVE" CssClass="Button1" Width="75px" onclick="BTN_FIND_Click"></asp:button>&nbsp;&nbsp;<INPUT class="button1" type="button" value="FINISH" onclick="keluar()"></TD>
							</TR>
							<tr>
								<td class="TDBGColorValue">
									<asp:DataGrid ID="DGR_MEMO" Runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="ci_seq" HeaderText="No.">
												<HeaderStyle Width="50px" CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ci_date" HeaderText="Tgl. Input">
												<HeaderStyle Width="120px" CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ci_content" HeaderText="Comment">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CI_ANSWER" HeaderText="Answer">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ci_userid" HeaderText="User By">
												<HeaderStyle Width="120px" CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:DataGrid>
								</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
