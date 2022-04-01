<%@ Page language="c#" Codebehind="NotaryAssignmentList.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.NotaryAssignment.NotaryAssignmentList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NotaryAssignmentList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Notary Assignment List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD colSpan="2" align="center"><STRONG>
								<TABLE class="td" id="Table3" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
									width="590" border="1">
									<TR>
										<TD class="tdHeader1">Kriteria Pencarian</TD>
									</TR>
									<TR>
										<TD vAlign="top">
											<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
													<TD width="17"></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px" width="342">
														<asp:textbox onkeypress="return kutip_satu()" id="txt_Name" runat="server" MaxLength="50"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Application No.</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px">
														<asp:textbox onkeypress="return kutip_satu()" id="txt_ProsID" runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px">
														<asp:textbox onkeypress="return kutip_satu()" id="txt_IdCard" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 20px">NPWP</TD>
													<TD style="HEIGHT: 20px"></TD>
													<TD style="WIDTH: 342px; HEIGHT: 20px">
														<asp:textbox onkeypress="return kutip_satu()" id="txt_NPWP" runat="server" MaxLength="25"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD style="WIDTH: 400px; HEIGHT: 18px">
														<P class="TDBGColorValue">
															<asp:textbox id="txt_Date" runat="server" Columns="3" MaxLength="2" onkeypress="return numbersonly();"></asp:textbox>
															<asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist>
															<asp:textbox id="txt_Year" runat="server" Columns="3" MaxLength="4" onkeypress="return numbersonly();"></asp:textbox>&nbsp;s/d
															<asp:textbox id="txt_Date1" runat="server" Columns="3" MaxLength="2" onkeypress="return numbersonly();"></asp:textbox>
															<asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist>
															<asp:textbox id="txt_Year1" runat="server" Columns="3" MaxLength="4" onkeypress="return numbersonly();"></asp:textbox></P>
													</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" vAlign="middle">Kondisi</TD>
													<TD vAlign="middle"></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px" vAlign="top">
														<asp:radiobuttonlist id="RDB_COND" runat="server" Width="208px" CellPadding="0" Height="24px" CellSpacing="0"
															RepeatDirection="Horizontal">
															<asp:ListItem Value="And">Dan</asp:ListItem>
															<asp:ListItem Value="Or" Selected="True">Atau</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3">
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
							<asp:textbox id="TXT_AP_REGNO" runat="server" Visible="False"></asp:textbox>
							<asp:button id="BtnFind" runat="server" Text="F i n d" Visible="False"></asp:button></TD>
					</TR>
					<tr>
						<TD vAlign="top" align="center" colSpan="2">
							<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="True" Width="100%">
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tanggal Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_RELMNGR" HeaderText="Analis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Fungsi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											&nbsp;
											<asp:LinkButton id="LinkButton3" runat="server" CommandName="view">Lihat</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_CO" HeaderText="AP_CO"></asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
							<asp:Label id="LBL_H_TC" runat="server" Visible="False"></asp:Label>
						</TD>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
