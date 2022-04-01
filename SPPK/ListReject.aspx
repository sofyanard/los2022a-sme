<%@ Page language="c#" Codebehind="ListReject.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.ListReject" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListReject</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/onepost.html" -->
		<script language="javascript">
			function update(aksi)
			{
				if (processing) 
				{
					alert(aksi + " is in progress. Please wait ...");
					return false;
				}
				
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
						<TD style="HEIGHT: 28px">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
										<TABLE id="Table6">
											<TR>
												<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Reject List<B>&nbsp;</B></B></TD>
											</TR>
										</TABLE>
									</TD>
									<TD align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
								</TR>
							</TABLE>
							<table>
								<TR>
									<TD style="WIDTH: 110px"><STRONG>Cari Nasabah </STRONG>
									</TD>
									<TD style="WIDTH: 5px"><STRONG>:</STRONG></TD>
									<TD><asp:textbox id="txt_regno" runat="server" onkeypress="return kutip_satu()" MaxLength="20" Columns="30"
											Width="176px"></asp:textbox></TD>
									<TD style="WIDTH: 5px"></TD>
									<TD><asp:button id="btn_cari" runat="server" Text="C a r i" 
                                            onclick="btn_cari_Click"></asp:button></TD>
								</TR>
							</table>
						</TD>
					</TR>
					<tr>
						<td style="WIDTH: 50%"><asp:datagrid id="dgListReject" runat="server" Width="100%" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tgl. Aplikasi">
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
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="view">Print</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD></TD>
									<TD></TD>
									<TD align="right"></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD align="right">
										<asp:Button id="btn_BackVA" runat="server" Text="Analisa Ulang" 
                                            CssClass="button1" onclick="btn_BackVA_Click"></asp:Button>&nbsp;
										<asp:button id="Button1" runat="server" Text="Appeal" CssClass="button1" 
                                            Width="140px" onclick="Button1_Click" Visible="False"></asp:button>&nbsp;
										<asp:button id="Button2" runat="server" Text="Update Status" CssClass="button1" Width="140" onclick="Button2_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
