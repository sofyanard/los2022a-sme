<%@ Page language="c#" Codebehind="RekananTercela.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.RekananTercela" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RekananTercela</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Daftar&nbsp;Orang Tercela</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<tr>
						<td>
							<table width="100%">
							</table>
						</td>
					</tr>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" style="WIDTH: 590px" cellSpacing="1" cellPadding="1" width="590"
								border="1">
								<TR>
									<TD class="tdHeader1">Mencari&nbsp;Orang Tercela</TD>
								</TR>
								<TR>
									<TD vAlign="bottom" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Nama</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px" width="342">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CR_NAMA" runat="server" Width="280px" MaxLength="20"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Identitas</TD>
												<TD></TD>
												<TD class="TDBGColorValue" style="WIDTH: 342px">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CR_ID" runat="server" Width="168px" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Bidang Keahlian</TD>
												<TD></TD>
												<TD class='A"TDBGColorValue"' style="HEIGHT: 10px"><asp:dropdownlist id="DDL_BDG_KEAHLIAN" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 521px" vAlign="top" align="center" colSpan="3"></TD>
											</TR>
										</TABLE>
										<asp:button id="btn_Find" runat="server" Width="200px" Text="Find Rekanan" CssClass="button1" onclick="btn_Find_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Daftar Rekanan Tercela</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_DAFTAR" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
								AllowPaging="True" Visible="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="seq" HeaderText="seq" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nama" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="tempat_lahir" HeaderText="Tempat Lahir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="tgl_lahir" HeaderText="Tanggal Lahir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="no_identitas" HeaderText="No.Identitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="alamat" HeaderText="Alamat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="rfrekanantype" HeaderText="rfrekanantype" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="rekanandesc" HeaderText="Bidang Keahlian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="lnk_edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="lnk_delete">Delete</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="lnk_view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</table>
				<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
					<!--
								<TR>
									<TD style="HEIGHT: 43px" vAlign="top" width="50%" colSpan="2"><STRONG>Retrieve Function</STRONG></TD>
								</TR>
								-->
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px">Nama</TD>
									<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NAMA" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_NAMA" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px">Tempat Lahir</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_BIRTH_PLACE" runat="server" Width="300px"
											MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_BIRTH_PLACE" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px">Tanggal Lahir</TD>
									<TD></TD>
									<TD class="TDBGColorValue" align="left">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_DAY" runat="server" Width="24px" MaxLength="2"
											Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR" runat="server" Width="36px" MaxLength="4"
											Columns="4"></asp:textbox></TD>
									<TD>
										<asp:label id="LBL_DAY" runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_MONTH" runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_YEAR" runat="server" Visible="False"></asp:label>
									</TD>
								</TR>
							</TABLE>
							<asp:label id="SEQ" runat="server" Visible="False"></asp:label>
						<TD class="td" vAlign="top" align="center">
							<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 23px" width="125">No.Identitas</TD>
									<TD style="WIDTH: 17px; HEIGHT: 23px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_ID" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_ID" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="125">Alamat</TD>
									<TD style="WIDTH: 17px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ADDRESS" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									<TD><asp:label id="LBL_ADDRESS" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 21px">Bidang Keahlian</TD>
									<TD style="HEIGHT: 21px"></TD>
									<TD class='A"TDBGColorValue"' style="HEIGHT: 10px">
										<asp:dropdownlist id="DDL_JNS_REKANAN" runat="server" AutoPostBack="True"></asp:dropdownlist>
									</TD>
									<TD><asp:label id="LBL_JNS_REKANAN" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
							<BR>
						</TD>
						<asp:label id="TXT_SEQ" Visible="False" Runat="server"></asp:label></TR>
				</TABLE>
				</TR></TABLE>
				<table>
					<tr>
						<td>
							<table align="center" width="100%">
								<TR>
									<TD class="TDBGColor1" width="140">Alasan</TD>
									<TD style="WIDTH:9px"></TD>
									<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CAT" runat="server" Width="900px" Height="100px"
											MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
									<TD><asp:label id="LBL_CAT" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</table>
						</td>
					</tr>
					<TR>
						<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" Text="Insert" CssClass="button1" onclick="BTN_INSERT_Click"></asp:button><asp:button id="BTN_UPDATE" runat="server" Text="Update" CssClass="button1" onclick="BTN_UPDATE_Click"></asp:button><asp:button id="BTN_CLEAR" runat="server" Text="Clear" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button></TD>
					</TR>
					<tr>
						<td><asp:textbox id="FLAG" runat="server" Visible="False"></asp:textbox></td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
