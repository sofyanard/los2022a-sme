<%@ Page language="c#" Codebehind="InquiryByStatus.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.InquiryByStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InquiryByStatus</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Inquiry by Status</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><STRONG>
								<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
									width="590" border="1">
									<TR>
										<TD class="tdHeader1">Search Criteria</TD>
									</TR>
									<TR>
										<TD vAlign="top">
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px" width="221">Nama Rekanan</TD>
													<TD width="17"></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAME" runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px">NPWP</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ID" runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px">No. Aplikasi</TD>
													<TD></TD>
													<TD style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REGNUM" runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px; HEIGHT: 18px">Tanggal Lahir/Berdiri 
														Perusahaan</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD style="WIDTH: 400px; HEIGHT: 18px">
														<P class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL" runat="server" MaxLength="2" Columns="3"></asp:textbox><asp:dropdownlist id="DDL_BLN" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN" runat="server" MaxLength="4" Columns="3"></asp:textbox></P>
													</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px">Jenis Rekanan</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:dropdownlist id="DDL_JNS_REKANAN" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="center" colSpan="3"><asp:button id="BTN_FIND" runat="server" Width="105px" CssClass="button1" Text="Find " onclick="BTN_FIND_Click"></asp:button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</STRONG>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2">
							<asp:Label id="Label2" runat="server" Font-Bold="True">Tracking Status</asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:Label Runat="server" ID="LBL_REGNUM" Font-Bold="True" Visible="False"></asp:Label><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="regnum"></asp:BoundColumn>
									<asp:BoundColumn DataField="trackcode" HeaderText="Track Number">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="trackname" HeaderText="Track Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="th_trackdate" HeaderText="Track Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="th_trackby" HeaderText="Update by">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="th_nextby" HeaderText="Next Update">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrdInfo" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="REKANAN_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="REGNUM" HeaderText="No. Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAMEREKANAN" HeaderText="Nama Rekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ID_NUMBER" HeaderText="ID Number">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REKANANDESC" HeaderText="Jenis Rekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
