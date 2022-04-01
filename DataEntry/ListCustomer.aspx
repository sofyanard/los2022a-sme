<%@ Page language="c#" Codebehind="ListCustomer.aspx.cs" AutoEventWireup="True" Inherits="Websysca.ListCustomer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>List Customer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Customer List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" width="590" border="1" style="WIDTH: 590px; HEIGHT: 200px">
								<TR>
									<TD class="tdHeader1">Kriteria Pencarian</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
												<TD width="17"></TD>
												<TD width="342" class="TDBGColorValue" style="WIDTH: 342px">
													<asp:textbox id="txt_Name" runat="server" onkeypress="return kutip_satu()" MaxLength="20" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Aplikasi</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox id="txt_ProsID" MaxLength="20" runat="server" onkeypress="return kutip_satu()" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox id="txt_IdCard" MaxLength="20" runat="server" onkeypress="return kutip_satu()" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD style="WIDTH: 342px">
													<asp:textbox id="txt_NPWP" runat="server" MaxLength="20" onkeypress="return kutip_satu()" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
												<TD style="HEIGHT: 18px"></TD>
												<TD style="WIDTH: 400px; HEIGHT: 18px">
													<P class="TDBGColorValue"><asp:textbox id="txt_Date" runat="server" Columns="3" MaxLength="2" onkeypress="return numbersonly()"></asp:textbox>
														<asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year" runat="server" Columns="3" MaxLength="4" onkeypress="return numbersonly()"></asp:textbox>&nbsp;s/d
														<asp:textbox id="txt_Date1" runat="server" MaxLength="2" Columns="3" onkeypress="return numbersonly()"></asp:textbox>
														<asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist>
														<asp:textbox id="txt_Year1" runat="server" MaxLength="4" Columns="3" onkeypress="return numbersonly()"></asp:textbox></P>
												</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" vAlign="middle">Kondisi</TD>
												<TD vAlign="middle"></TD>
												<TD vAlign="top" class="TDBGColorValue" style="WIDTH: 342px"><asp:radiobuttonlist id="RDB_COND" runat="server" RepeatDirection="Horizontal" CellSpacing="0" Height="24px"
														CellPadding="0" Width="208px">
														<asp:ListItem Value="And">Dan</asp:ListItem>
														<asp:ListItem Value="Or" Selected="True">Atau</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" style="WIDTH: 521px">
                                                    <asp:button id="btn_Find" runat="server" Text="Cari" Width="75px" 
                                                        CssClass="button1" onclick="btn_Find_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" Width="100%" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tanggal Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AP_LIMITEXPOSURE" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SU_FULLNAME" HeaderText="Nama Analis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:ButtonColumn Text="Lihat" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="AP_CA" HeaderText="AP_CA"></asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label>
							<asp:label id="LBL_USERID" runat="server" visible="false"></asp:label>
							<asp:label id="LBL_CBC" runat="server"  visible="false"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
