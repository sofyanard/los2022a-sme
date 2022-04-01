<%@ Page language="c#" Codebehind="GenInfoWatchlist3.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.PortfolioWatchlistChecking.GenInfoWatchlist3" %>
<%@ Register TagPrefix="uc1" TagName="DocExport" Src="CommonForm/DocExport.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GenInfoWatchlist3</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- #include file="../../include/popup.html" -->
		<!-- #include file="../../include/cek_all.html" --><LINK href="../../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" width="100%" border="0">
				<TR>
					<TD align="left" colSpan="1">
						<TABLE id="Table3">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>GENERAL INFO</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
				</TR>
				<TR>
					<TD align="center" colSpan="2">&nbsp;</TD>
				</TR>
				<tr>
					<td class="tdHeader1" id="Td2" vAlign="middle" colSpan="2" runat="server">PORTOFOLIO 
						WATCHLIST CHECKING</td>
				</tr>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">No. Nota</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_NOTA" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Periode</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_PERIODE" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">No. LMS</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_LMS" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:label id="LBL_LOAN_TYPE_ID" runat="server" Visible="False"></asp:label><asp:label id="LBL_ANALYST" runat="server" Visible="False"></asp:label></TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="129">Tanggal Nota</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_NOTA" runat="server" Width="24px"
										ReadOnly="True" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_BLN_NOTA" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_NOTA" runat="server" Width="36px"
										MaxLength="4" Columns="4" Enabled="False"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Analyst</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_ANALYST" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">LMS Date</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_LMS_DATE" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td colSpan="3">
						<table id="Table33" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="30%"><ASP:DATAGRID id="DATGRD_PERIODE" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
										AllowPaging="True">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="loan id" DataField="loan_type_id" Visible="False">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="Jenis Kredit" DataField="loan_type">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn Text="Retrieve" HeaderText="Function" CommandName="Retrieve">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
											</asp:ButtonColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<td width="70%"></td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td width="100%" colSpan="2"><ASP:DATAGRID id="DATGRD_PORTFOLIO" runat="server" Width="100%" AllowPaging="True" CellPadding="1"
										AutoGenerateColumns="False" PageSize="20">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="Unit_name" HeaderText="Unit Name">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="jenis" HeaderText="Jenis">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="trashold" HeaderText="Threshold (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="bulan_ke_n_2" HeaderText="Bln ke n-2 (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="bulan_ke_n_1" HeaderText="Bln ke n-1 (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="bulan_ke_n" HeaderText="Bulan ke n (%)">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="status" HeaderText="Status">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Portfolio Strategy">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox Runat="server" Width="200px" TextMode="MultiLine" ID="TXT_STRATEGY"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="buc_cd">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="loan_type_id">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></td>
								<td width="80%"></td>
							</tr>
							<tr>
								<td class="TDBGColor2" colSpan="2"><asp:button id="Button1" CssClass="button1" Runat="server" Text="SAVE" onclick="Button1_Click"></asp:button>&nbsp;<asp:button id="BTN_CLEAR_PERIODE" Visible="False" CssClass="button1" Runat="server" Text="CLEAR" onclick="BTN_CLEAR_PERIODE_Click"></asp:button>
								</td>
							</tr>
							<tr>
								<td></td>
							</tr>
							<TR>
								<TD colSpan="2"><uc1:docexport id="DocExport1" runat="server"></uc1:docexport></TD>
							</TR>
							<tr>
								<td></td>
							</tr>
							<tr>
								<td class="tdHeader1" id="Td3" vAlign="middle" colSpan="2" runat="server">DECISION</td>
							</tr>
							<TR>
								<td>
									<table>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 80px">Assign to Advice</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_ASG" Width="200px" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											<td>&nbsp;<asp:button id="BTN_ASG" Width="141px" CssClass="button1" Runat="server" Text="Assign to Advice" onclick="BTN_ASG_Click"></asp:button></td>
										</TR>
									</table>
								</td>
							</TR>
							<tr>
								<td class="TDBGColor2" colSpan="2"><asp:button id="BTN_ACCEPT" CssClass="button1" Runat="server" Text="ACCEPT" onclick="BTN_ACCEPT_Click"></asp:button>&nbsp;<asp:button id="BTN_ACQ" CssClass="button1" Runat="server" Text="ACQUIRE INFO" onclick="BTN_ACQ_Click"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
