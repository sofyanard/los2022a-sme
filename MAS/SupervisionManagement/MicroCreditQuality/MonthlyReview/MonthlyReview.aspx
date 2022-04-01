<%@ Page language="c#" Codebehind="MonthlyReview.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.SupervisionManagement.MicroCreditQuality.MonthlyReview.MonthlyReview" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MonthlyReview</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="form1" method="post" runat="server">
			<!-- <center> -->
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table8">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>MONTHLY REVIEW</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" Visible="False"></asp:imagebutton><A href="../../../../Body.aspx"><IMG src="../../../../Image/MainMenu.jpg"></A><A href="../../../../Logout.aspx" target="_top"><IMG src="../../../../Image/Logout.jpg"></A></td>
				</TR>
				<tr>
					<td></td>
				</tr>
				<TR id="TR_FIND" runat="server">
					<TD class="tdNoBorder" vAlign="top" width="50%">
						<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Periode :</TD>
								<TD style="WIDTH: 15px">Tanggal :</TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:TextBox Runat="server" ID="TXT_TGL" Width="41px"></asp:TextBox></TD>
								<TD style="WIDTH: 15px">Bulan :</TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:DropDownList Runat="server" ID="DDL_BLN"></asp:DropDownList></TD>
								<TD style="WIDTH: 15px">Tahun :</TD>
								<TD class="TDBGColorValue" style="WIDTH: 208px"><asp:DropDownList Runat="server" ID="DDL_THN"></asp:DropDownList></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" vAlign="top" width="50%"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							CellPadding="1" PageSize="5">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="seq" Visible="False" DataField="unit_seq#">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Unit / Cabang" DataField="branch_name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Distrik" DataField="distrik_code">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="Cluster" DataField="cluster_code">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Dokumen Kredit">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:radiobuttonlist id="RDO_DOC_KREDIT" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Lengkap</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MMM OTS">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList Runat="server" ID="DDL_MMM_OTS"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Kualitas Monitoring MMM  (1 paling baik)">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:radiobuttonlist id="RDO_MONITORING_MMM" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">1</asp:ListItem>
											<asp:ListItem Value="2">2</asp:ListItem>
											<asp:ListItem Value="3">3</asp:ListItem>
											<asp:ListItem Value="4">4</asp:ListItem>
											<asp:ListItem Value="5">5</asp:ListItem>
										</asp:radiobuttonlist>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Indikasi Calo/Fiktif">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:radiobuttonlist id="RDO_INDIKASI_CALO" runat="server" Width="150px" AutoPostBack="True" RepeatDirection="Horizontal">
											<asp:ListItem Value="Y">Ya</asp:ListItem>
											<asp:ListItem Value="N">Tidak</asp:ListItem>
										</asp:radiobuttonlist>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Risk Level">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:DropDownList Runat="server" ID="DDL_RISK_LEVEL" Enabled="False" CssClass="mandatory"></asp:DropDownList>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Keterangan Tambahan">
									<HeaderStyle CssClass="tdSmallHeader" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:TextBox Runat="server" ID="TXT_REASON" TextMode="MultiLine" Width="100%" Height="70px"></asp:TextBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="delete_data" runat="server" CommandName="delete_data">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<tr align="center">
					<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">
						<asp:button id="BTN_SAVE" runat="server" Width="75px" CssClass="Button1" Text="SAVE" onclick="BTN_SAVE_Click"></asp:button>
						<asp:button id="BTN_CLEAR" runat="server" Width="75px" CssClass="Button1" Text="CLEAR" Visible="False" onclick="BTN_CLEAR_Click"></asp:button>
						<asp:button id="BTN_PRINT" runat="server" Width="75px" CssClass="Button1" Text="PRINT" onclick="BTN_PRINT_Click"></asp:button>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
