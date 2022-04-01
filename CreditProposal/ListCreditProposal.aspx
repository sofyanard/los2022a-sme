<%@ Page language="c#" Codebehind="ListCreditProposal.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.ListCreditProposal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Credit Proposal List</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 23px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Proposal List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right" style="HEIGHT: 23px"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD colSpan="2" align="center"><STRONG>
								<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
									width="590" border="1">
									<TR>
										<TD class="tdHeader1">Kriteria Pencarian</TD>
									</TR>
									<TR>
										<TD vAlign="top">
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
													<TD width="17"></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px" width="342">
														<asp:textbox id="txt_Name" MaxLength="20" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No. Aplikasi</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px">
														<asp:textbox id="txt_ProsID" MaxLength="20" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px">
														<asp:textbox id="txt_IdCard" MaxLength="20" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">NPWP</TD>
													<TD></TD>
													<TD style="WIDTH: 342px">
														<asp:textbox id="txt_NPWP" MaxLength="20" onkeypress="return kutip_satu()" runat="server"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD style="WIDTH: 400px; HEIGHT: 18px">
														<P class="TDBGColorValue">
															<asp:textbox id="txt_Date" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="2"></asp:textbox>
															<asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist>
															<asp:textbox id="txt_Year" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="4"></asp:textbox>&nbsp;s/d
															<asp:textbox id="txt_Date1" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="2"></asp:textbox>
															<asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist>
															<asp:textbox id="txt_Year1" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="4"></asp:textbox></P>
													</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" vAlign="middle">Kondisi</TD>
													<TD vAlign="middle"></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px" vAlign="top">
														<asp:radiobuttonlist id="RDB_COND" runat="server" Width="208px" CellPadding="0" RepeatDirection="Horizontal"
															CellSpacing="0" Height="24px">
															<asp:ListItem Value="And">Dan</asp:ListItem>
															<asp:ListItem Value="Or" Selected="True">Atau</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="center" colSpan="3">
														<asp:button id="btn_Find" runat="server" Text="Cari" Width="75px" 
                                                            CssClass="button1" onclick="btn_Find_Click"></asp:button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</STRONG>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:Label id="LBL_COUNT_APP" runat="server" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:TextBox id="TXT_AP_REGNO" runat="server" Visible="False"></asp:TextBox>
							<asp:Button id="BtnFind" runat="server" Text="Cari" Visible="False"></asp:Button>
							<asp:Label id="LBL_USERID" runat="server" Visible="False"></asp:Label></TD>
					</TR>
					<!--<tr>
						<td align="center" colSpan="2"><asp:placeholder id="placeholder1" runat="server"></asp:placeholder></td>
					</tr>-->
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
					</TABLE>
			</center>
		</form>
	</body>
</HTML>
