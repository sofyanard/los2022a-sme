<%@ Page language="c#" Codebehind="DisbursementSheet.aspx.cs" AutoEventWireup="True" Inherits="SourceSMEReport.DisbursementSheet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DisbursementSheet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"></TD>
						<TD class="tdNoBorder" align="right"><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<td class="TDBGColor1" width="150"><strong>&nbsp;Application&nbsp;No.</strong></td>
						<td><asp:textbox onkeypress="return kutip_satu()" id="TXT_AP_REGNO" runat="server" MaxLength="20"></asp:textbox>&nbsp;
							<asp:label id="LBL_TC" Visible="False" Runat="server"></asp:label>
							<asp:label id="LBL_MC" Runat="server" Visible="False"></asp:label></td>
					</tr>
					<TR>
						<TD class="TDBGColor1" width="150"><strong>Applicants Name</strong></TD>
						<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA" runat="server" MaxLength="50" Width="240px"></asp:textbox>&nbsp;&nbsp;
							<asp:button id="Button1" runat="server" Text="F i n d" onclick="Button1_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD colspan="2" align=center bgcolor="Red"><STRONG style="COLOR: #ffffff">Note : Untuk deposito 
								sebagai collateral, diminta melaksanakan blokir deposito di BDS/eMAS setelah 
								rekening terbentuk </STRONG>
						</TD>
					</TR>
				</TABLE>
				<TABLE cellSpacing="2" cellPadding="2" width="100%" align="center">
					<TR>
						<TD width="100%">
							<asp:datagrid id="DGR_LIST" Runat="server" Width="100%" AllowPaging="True" CellPadding="1" PageSize="100"
								AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAMA" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SU_FULLNAME" HeaderText="RM">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="Receive Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="productdesc" HeaderText="Fasilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="KET_CODE"></asp:BoundColumn>
									<asp:BoundColumn DataField="ket_desc" HeaderText="Ketentuan Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="productid" HeaderText="productid"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ISCASHLOAN" HeaderText="cash"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cu_ref" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="prod_seq"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="report">Report</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Visible="False" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
