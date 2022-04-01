<%@ Page language="c#" Codebehind="ListScoring.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.ListScoring" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListScoring</title>
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
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>List Rekanan</B></TD>
								</TR>
							</TABLE>
						</TD>
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
													<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="txt_Name" runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px">ID#</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_ID" runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px; HEIGHT: 18px">Tanggal Lahir/Berdiri 
														Perusahaan</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD style="WIDTH: 400px; HEIGHT: 18px">
														<P class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="txt_Date" runat="server" MaxLength="2" Columns="3"></asp:textbox><asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_Year" runat="server" MaxLength="4" Columns="3"></asp:textbox></P>
													</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px">Jenis Rekanan</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:dropdownlist id="DDL_JenisRekanan" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 221px">No. Registrasi</TD>
													<TD></TD>
													<TD style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="txt_NoReg" runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="center" colSpan="3"><asp:button id="btn_Find" runat="server" Width="105px" CssClass="button1" Text="Find Rekanan"></asp:button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</STRONG>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" Width="1024px" AutoGenerateColumns="False"
								PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Register#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Nama_Rekanan" HeaderText="Nama Rekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ID_Number" HeaderText="ID Number">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Jenis_Rekanan" HeaderText="Jenis Rekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="Continue">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
					</tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
