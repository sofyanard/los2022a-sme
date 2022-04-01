<%@ Page language="c#" Codebehind="DetailJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.DetailJaminan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailJaminan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><asp:label id="Label1" runat="server"></asp:label></B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="ListCustomer.aspx?si="></A><A href="../../../Body.aspx"><IMG src="../../../Image/MainMenu.jpg"></A><A href="../../../Logout.aspx" target="_top"><IMG src="../../../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Unit / Cabang</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_UNIT_CABANG" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;
										<asp:checkbox id="CHB_is_rekanan" Runat="server"></asp:checkbox>&nbsp;Rekanan</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px; HEIGHT: 16px"><asp:label id="Label2" runat="server"></asp:label></TD>
									<TD style="HEIGHT: 16px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_name" runat="server" MaxLength="100" Width="300px"
											TextMode="SingleLine" CssClass="mandatory"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px">Alamat</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" vAlign="top" rowSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="Textbox1" runat="server" Width="300px" TextMode="MultiLine"
											Height="50px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 141px"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" Width="75px" CssClass="Button1" Text="INSERT" onclick="BTN_INSERT_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" Width="75px" CssClass="Button1" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button></td>
					</tr>
					<tr>
						<td><asp:label id="TXT_SEQ" Runat="server" Visible="False"></asp:label></td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="seq" HeaderText="No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="10px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Branch" HeaderText="Unit / Cabang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Name" HeaderText="Nama Asuransi/Notaris">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Alamat" HeaderText="Alamat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="rekanan" Visible="False" />
									<asp:TemplateColumn HeaderText="Rekanan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHB_REKAN" Runat="server" Enabled=False ></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_data" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="delete_data" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="TR_COLL" runat="server" Visible="False">
						<TD class="td" colSpan="2">
							<P>
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD class="td" vAlign="top" align="center" colSpan="2">
											<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" width="129">Keterangan Jaminan</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" MaxLength="150"
															Width="300px" CssClass="mandatory"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">eMAS Colateral ID</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_SIBS_COLID" runat="server" Width="300px" BorderStyle="None"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Bukti Kepemilikan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUKTI_KEPEMILIKAN" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Bentuk Pengikatan</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 1px"><asp:dropdownlist id="DDL_BENTUK_PENGIKATAN" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 11px">Klasifikasi Jaminan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Currency</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Bank</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE" onblur="FormatCurrency(this)" runat="server" Width="200px" CssClass="mandatory"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Pasar</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE2" onblur="FormatCurrency(this)" runat="server" Width="200px" CssClass="mandatory"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Asuransi</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEINS" onblur="FormatCurrency(this)" runat="server" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Pengikatan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEIKAT" onblur="FormatCurrency(this)" runat="server" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUEPPA" onblur="FormatCurrency(this)" runat="server" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Likuidasi</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUELIQ" onblur="FormatCurrency(this)" runat="server" Width="200px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tanggal Penilaian</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_TGLPENILAIAN_DAY" runat="server" MaxLength="2" CssClass="mandatory" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TGLPENILAIAN_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_TGLPENILAIAN_YEAR" runat="server" MaxLength="4" CssClass="mandatory" Columns="4"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Penilaian Oleh</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PENILAI_OLEH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR id="trrr" runat="server" Visible="False">
						<TD class="TDBGColor2" align="center" width="50%" colSpan="2"><asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Update"></asp:button><asp:button id="BTN_SAVE" runat="server" CssClass="button1" Text="Save"></asp:button><asp:label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:button id="UPDATETOAPPRISAL" runat="server" CssClass="button1" Text="Update To Appraisal"></asp:button></TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
