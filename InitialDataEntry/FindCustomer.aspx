<%@ Page language="c#" Codebehind="FindCustomer.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.FindCustomer" errorPage="../SME_Error.aspx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FindCustomer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px; font-weight: 700;" align="center">Daftar 
                                        Nasabah</TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Kriteria Pencarian</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">CIF No.</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CIF" runat="server" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Pemohon</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="txt_Name" runat="server" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_IdCard" runat="server" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tanggal Lahir</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return digitsonly()" id="Textbox2" runat="server" MaxLength="2" Columns="3"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="Textbox1" runat="server" MaxLength="4" Columns="3"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_NPWP" runat="server" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
										<asp:button id="btn_Find" runat="server" CssClass="button1" 
                                            Text="Cari Eksisting" Width="200px" onclick="btn_Find_Click"></asp:button>&nbsp;
										<%if (Request.QueryString["tc"] != "" && Request.QueryString["tc"] != null&& Request.QueryString["tc"] != "1.0") {%>
										<asp:button id="BTN_NEW" runat="server" CssClass="button1" Text="Nasabah Baru" 
                                            Width="200px" onclick="BTN_NEW_Click"></asp:button>
										<% } else { %>
										<asp:button id="BTN_NEW_PREENTRY" runat="server" CssClass="button1" 
                                            Text="Nasabah Baru" Width="200px" onclick="BTN_NEW_PREENTRY_Click"></asp:button>
										<% } %>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="CU_CIF" HeaderText="CIF No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CUST_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NPWP" HeaderText="NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" Text="Continue" CausesValidation="false" CommandName="View"></asp:LinkButton>&nbsp;&nbsp;
											<asp:LinkButton id="LNK_CONT_PREENTRY" runat="server" Text="Continue" CausesValidation="false" CommandName="View2">Continue</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2">
							<%if (Request.QueryString["tc"] != "" && Request.QueryString["tc"] != null) {%>
							<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdheader1">Aplikasi Berjalan</TD>
								</TR>
								<TR>
									<TD><ASP:DATAGRID id="DatGrd_PendingApp" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
											PageSize="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="PRE_SEQSURAT" HeaderText="PRE_SEQSURAT"></asp:BoundColumn>
												<asp:BoundColumn DataField="CU_CIF" HeaderText="CIF No.">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CUST_NAME" HeaderText="Nama Pemohon">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CU_NPWP" HeaderText="NPWP">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PRE_APPAMOUNT" HeaderText="Application Amount" DataFormatString="{0:0,00.00}">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PRE_APPENTRYDATE" HeaderText="Tanggal Aplikasi" DataFormatString="{0:dd-MMM-yyyy}">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="View">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="View2">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:ButtonColumn>
												<asp:BoundColumn Visible="False" DataField="PRE_SEQSURAT">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="AP_REGNO"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
							<% } %>
						</TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
