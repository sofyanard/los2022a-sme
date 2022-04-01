<%@ Page language="c#" Codebehind="Memo.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.Memo2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Memo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table2">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Memo</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_TM_CONTENT" runat="server" Height="72px"
							Width="100%" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD colspan="2" align="center">
						<asp:button id="BTN_SAVE" runat="server" cssclass="button1" Text="Simpan" 
                            width="75px" onclick="BTN_SAVE_Click"></asp:button>
						<asp:TextBox id="TXT_REGNO" runat="server" Visible="False"></asp:TextBox>
						<asp:TextBox id="TXT_TMSEQ" runat="server" Visible="False"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<ASP:DATAGRID id="DatGrd" runat="server" Height="80px" Width="100%" HorizontalAlign="Center" AllowPaging="True"
							AutoGenerateColumns="False" CellPadding="1">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
								<asp:BoundColumn DataField="TM_SEQ" HeaderText="No.">
									<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TM_DATE" HeaderText="Tanggal">
									<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TM_COntent" HeaderText="Deskripsi">
									<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SU_FUllname" HeaderText="Oleh">
									<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="sg_grpname" HeaderText="Petugas">
									<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Fungsi">
									<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LINK_EDIT" runat="server" CommandName="Edit">Ubah</asp:LinkButton>&nbsp;
										<asp:LinkButton id="LINK_DELETE" runat="server" CommandName="Delete">Hapus</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="TM_USERID" HeaderText="TM_USERID">
									<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
