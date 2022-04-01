<%@ Page language="c#" Codebehind="PermohonanBaruKI.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PermohonanBaruKI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PermohonanBaruKI</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Permohonan Baru</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Loan</TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_APPTYPE" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_LIMIT" runat="server" onkeypress="return numbersonly()" MaxLength="15"
											CssClass="mandatory" Width="200px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tenor</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CP_TENOR" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;</TD>
									<TD></TD>
									<TD class="TDBGColorValue">&nbsp;
										<asp:Label id="LBL_USERID" runat="server" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat Proyek</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_PROJADDR1" MaxLength="100" runat="server" Width="175px"></asp:TextBox><BR>
										<asp:TextBox id="TXT_CP_PROJADDR2" MaxLength="100" runat="server" Width="175px"></asp:TextBox><BR>
										<asp:TextBox id="TXT_CP_PROJADDR3" MaxLength="100" runat="server" Width="175px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai Proyek</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_PROJVALUE" MaxLength="15" onkeypress="return numbersonly()" runat="server"
											Width="200px"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2">
							<P>
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD align="center" colSpan="1">
											<ASP:DATAGRID id="DatGrd" runat="server" Width="60%" CellPadding="1" PageSize="3" AutoGenerateColumns="False"
												AllowPaging="True">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="CL_SEQ" HeaderText="Sequence"></asp:BoundColumn>
													<asp:BoundColumn DataField="COLTYPEDESC" HeaderText="Jenis Jaminan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
									<TR>
										<TD align="center" width="50%">
											<TABLE id="Table5" cellSpacing="2" cellPadding="0" width="400">
												<TR>
													<TD class="tdLabel" width="100">Jenis Jaminan</TD>
													<TD width="17">:</TD>
													<TD class="TDBGColorValue">
														<asp:dropdownlist id="DDL_CL_TYPE" runat="server"></asp:dropdownlist></TD>
													<TD align="center" width="80" rowSpan="2">
														<asp:Button id="BTN_INSCOLL" runat="server" CssClass="button1" Text="Insert" onclick="BTN_INSCOLL_Click"></asp:Button></TD>
												</TR>
												<TR>
													<TD class="tdLabel" width="100">Nilai</TD>
													<TD width="17">:</TD>
													<TD class="TDBGColorValue">
														<asp:TextBox id="TXT_CL_VALUE" MaxLength="15" onkeypress="return numbersonly()" runat="server"
															Width="200px"></asp:TextBox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" Width="70px" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Width="70px" Text="Next" onclick="Button2_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CP_FACILITYNO" HeaderText="Fasilitas No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<ASP:BoundColumn Visible="False" DataField="APPTYPE" HeaderText="APPTYPE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</ASP:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<ASP:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</ASP:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMITCHGTO" HeaderText="Perubahan Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORDESC" HeaderText="Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CHGTENORDESC" HeaderText="Perubahan Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
