<%@ Page language="c#" Codebehind="FindCustomer.aspx.cs" AutoEventWireup="True" Inherits="dbrbm.Data_Entry.FindCustomer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FindCustomer</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>List Rekanan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
								width="590" border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Nama Rekanan</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REK_NAME" runat="server" MaxLength="20"
														Width="280px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342"><asp:textbox onkeypress="return kutip_satu()" id="TXT_REK_ID" runat="server" MaxLength="20" Width="280px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tanggal Lahir/Berdiri Perusahaan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGL_LAHIR" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_BLN_LAHIR" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_THN_LAHIR" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 30px">Jenis Rekanan</TD>
												<TD style="HEIGHT: 30px"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px; HEIGHT: 25px"><asp:dropdownlist id="DDL_JNS_REKANAN" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Registrasi</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NoReg" runat="server" MaxLength="25" Width="168px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
										<%if (Request.QueryString["tc"] != "" && Request.QueryString["tc"] != null&& Request.QueryString["tc"] != "1.0") {%>
										<asp:button id="BTN_NEW" runat="server" Width="200px" CssClass="button1" Text="New Rekanan" onclick="BTN_NEW_Click"></asp:button>
										<% } else { %>
										<% } %>
										&nbsp;
										<asp:button id="btn_Find" runat="server" Width="200px" CssClass="button1" Text="Existing Rekanan" onclick="btn_Find_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="Registrasi#" DataField="REKANAN_REF">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAMEREKANAN" HeaderText="Nama Rekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ID_NUMBER" HeaderText="NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REKANANDESC" HeaderText="Jenis Rekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Continue" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
