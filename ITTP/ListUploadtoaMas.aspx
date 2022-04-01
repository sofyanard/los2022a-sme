<%@ Page language="c#" Codebehind="ListUploadtoaMas.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.ListUploadtoaMas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListUploadtoaMas</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fListApp" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 43px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Upload List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right" style="HEIGHT: 43px"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR> <!--<tr>
					asdfasdfs
						<td align="center" colSpan="2"><asp:placeholder id="placeholder1" runat="server"></asp:placeholder></td>
					</tr>-->
					<tr>
						<td style="HEIGHT: 34px" colSpan="2">
							<table>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 110px">Find Customer</td>
									<td style="WIDTH: 5px"></td>
									<td><asp:textbox id="txt_regno" runat="server" Width="176px" Columns="30" MaxLength="20" onkeypress="return kutip_satu()"></asp:textbox></td>
									<td style="WIDTH: 5px"></td>
									<td>
										<asp:button id="btn_cari" runat="server" Text="F i n d"></asp:button>
										<asp:label id="lbl_prod" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label>
										<asp:label id="lbl_apptype" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label>
										<asp:label id="lbl_track" runat="server" Width="176px" Columns="30" MaxLength="20" Visible="False"></asp:label>
										<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
									</td>
								</tr>
							</table>
						</td>
					<TR>
						<TD style="HEIGHT: 34px" bgcolor="#ff0000" colSpan="2" align="center"><FONT face="Arial Unicode MS" color="white" size="3"><STRONG>Note 
									: Untuk deposito sebagai collateral, diminta melasanakan blokir di BDS/eMAS</STRONG></FONT></TD>
					</TR>
					</tr>
					<tr>
						<td style="WIDTH: 50%" colSpan="2"><asp:datagrid id="dgListApproval" runat="server" AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Customer Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Appl. Date" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Limit" DataFormatString="{0:00.00,00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TRXTYPE" HeaderText="Transaction Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PICBU" HeaderText="PIC Bussiness Unit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CONFIRM" HeaderText="Confirm">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
