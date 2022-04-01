<%@ Page language="c#" Codebehind="Permohonan.aspx.cs" AutoEventWireup="True" Inherits="dbrbm.Data_Entry.Permohonan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Permohonan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<% if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
				<TR>
					<TD>
						<TABLE id="Table2">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><a name="Top"> Permohonan</a></B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><asp:imagebutton id="BTN_BACK" runat="server" Visible="False" ImageUrl="../../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
					</td>
				</TR>
				<TR>
					<TD class="tdnoborder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<% } %>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">
									Permohonan</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 405px; HEIGHT: 88px">
												Permohonan</TD>
											<TD style="WIDTH: 1px; HEIGHT: 88px">:</TD>
											<TD style="HEIGHT: 90px"><asp:radiobuttonlist id="RDO_PBARU" runat="server" AutoPostBack="True" RepeatLayout="Flow" Height="80px">
													<asp:ListItem Value="1" Selected="True">Baru</asp:ListItem>
													<asp:ListItem Value="0">Perpanjangan</asp:ListItem>
													<asp:ListItem Value="2">Peningkatan Klasifikasi</asp:ListItem>
													<asp:ListItem Value="3">Pengaktifan Kembali</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 405px">Jenis</TD>
											<TD style="WIDTH: 1px">:</TD>
											<TD><asp:dropdownlist id="DDL_JENISREKANAN" runat="server" AutoPostBack="True" Enabled="False"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 405px">Keterangan</TD>
											<TD style="WIDTH: 1px">:</TD>
											<TD>
												<asp:TextBox id="TXT_KETERANGAN" runat="server" Width="176px"></asp:TextBox>
												<asp:label id="SEQ" runat="server" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
									<asp:label id="LBL_NOREG" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2"><asp:button id="BTN_ADD" runat="server" CssClass="button1" Width="125px" Text="Add Permohonan" onclick="BTN_ADD_Click"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" CssClass="button1" Width="140px"
										Text="Cancel Permohonan"></asp:button><asp:button id="BTN_CANCEL_ADD" runat="server" Visible="False" CssClass="Button1" Text="Cancel Add"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">List Permohonan</TD>
							</TR>
							<TR>
								<TD><ASP:DATAGRID id="DGR_PERMOHONAN" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False"
										AllowPaging="True">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="no_registrasi" HeaderText="no_registrasi">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="apptype" HeaderText="Jenis Permohonan">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="productid" HeaderText="Jenis Rekanan">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="keterangan" HeaderText="Keterangan">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Function">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													&nbsp;&nbsp;&nbsp;
													<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2"><asp:button id="BTN_SAVE" runat="server" Enabled="False" CssClass="button1" Width="180px" Text="Save Permohonan"></asp:button>
									<% if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
									<asp:button id="BTN_UPDATE_STATUS" runat="server" Enabled="False" CssClass="button1" Width="125px"
										Text="Update Status"></asp:button>
									<% } %>
									<asp:listbox id="ListBox2" runat="server" Visible="False" Width="10px" Height="25px"></asp:listbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
