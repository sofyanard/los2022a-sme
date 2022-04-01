<%@ Page language="c#" Codebehind="ListSPPKConfirm.aspx.cs" AutoEventWireup="True" Inherits="SME.SPPK.ListSPPKConfirm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListSPPKConfirm</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- bbb -->
		<script language="javascript">
			function update(aksi)
			{
				if (processing) return false;
				conf = confirm("Are you sure you want to " + aksi + " ?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>SPPK Confirm List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<td style="HEIGHT: 28px" colSpan="2">
							<table>
								<tr>
									<td style="WIDTH: 110px"><STRONG>Cari Nasabah</STRONG></td>
									<td style="WIDTH: 5px"><STRONG>:</STRONG></td>
									<td><asp:textbox id="txt_regno" runat="server" onkeypress="return kutip_satu()" MaxLength="20" Columns="30"
											Width="176px"></asp:textbox></td>
									<td style="WIDTH: 5px"></td>
									<td><asp:Button Text="C a r i" runat="server" ID="btn_cari" 
                                            onclick="btn_cari_Click"></asp:Button></td>
								</tr>
							</table>
							<asp:Label id="LBL_COUNT_APP" runat="server" Font-Bold="True"></asp:Label>
						</td>
					</tr>
					<tr>
						<td style="WIDTH: 50%" colSpan="2"><asp:datagrid id="dgListSPPK" runat="server" AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SU_FULLNAME" HeaderText="Analis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tgl. Aplikasi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AGING" HeaderText="Aging">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CheckBox1" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_RELMNGR" HeaderText="AP_RELMNGR"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD></TD>
									<TD></TD>
									<TD align="right"></TD>
								</TR>
								<TR>
									<TD>
										<asp:Button id="BTN_PROJECTLIST" runat="server" Text="View Project List" Visible="False" onclick="BTN_PROJECTLIST_Click"></asp:Button>
										<INPUT type="button" size="10" value="View Project List" onclick="javascript:PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');">
										<asp:Label id="LBL_AP_REGNO" runat="server" Visible="False"></asp:Label>
									</TD>
									<TD></TD>
									<TD align="right">
										<asp:Button id="btn_BackVA" runat="server" Text="Analisa Ulang" 
                                            CssClass="button1" onclick="btn_BackVA_Click"></asp:Button>&nbsp;
										<asp:Button id="btn_Appeal" runat="server" Text="Appeal" CssClass="button1" 
                                            Width="100px" onclick="btn_Appeal_Click" Visible="False"></asp:Button>
										&nbsp;
										<asp:Button id="btn_Update" runat="server" Text="Update Status" CssClass="button1" onclick="btn_Update_Click"></asp:Button></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
