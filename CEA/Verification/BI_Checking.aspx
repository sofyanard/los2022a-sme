<%@ Page language="c#" Codebehind="BI_Checking.aspx.cs" AutoEventWireup="True" Inherits="SME.CEA.Verification.BI_Checking" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BI_Checking</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>BI Checking Result Entry</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="Imagebutton1" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACCOUNT" runat="server" Visible="False" NavigateUrl="Main.aspx">Main</asp:hyperlink><asp:hyperlink id="HL_BI_CECK" runat="server" Visible="False" NavigateUrl="DTBO\ListDTBO.aspx">BI Checking Result Entry</asp:hyperlink><asp:hyperlink id="HL_SITE_VISIT" runat="server" Visible="False" NavigateUrl="InfoPerusahaan.aspx">Site Visit</asp:hyperlink><asp:hyperlink id="HL_WAWANCARA" runat="server" Visible="False" NavigateUrl="TenagaAhli.aspx"> Wawancara</asp:hyperlink><asp:hyperlink id="HL_INISIASI" runat="server" Visible="False" NavigateUrl="TenagaAhli.aspx"> Inisiasi</asp:hyperlink></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">BI Checking Result List</TD>
					</TR>
					<TR>
						<TD class="td" colSpan="2" width="45%" vAlign="top"><ASP:DATAGRID id="DatGridPengurus" runat="server" DESIGNTIMEDRAGDROP="33" CellPadding="1" PageSize="1"
								AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="no_registrasi" HeaderText="noreg"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nama" HeaderText="Nama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="tgl_idibi" HeaderText="Tgl IDI BI">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="nama_bank" HeaderText="Nama Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="jenis_kredit" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="baki_debet" HeaderText="Baki Debet">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="kolektibilitas" HeaderText="Kol">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="umur_tunggakan" HeaderText="Umur Tunggakan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="tot_tunggakan" HeaderText="Total Tunggakan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="posisi_data" HeaderText="Posisi Data">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="catatan" HeaderText="Catatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID><BR>
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
												<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 26px" width="129">Nama</TD>
												<TD style="WIDTH: 17px; HEIGHT: 26px"></TD>
												<TD class="TDBGColorValue" align="left" style="HEIGHT: 26px">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_MIDDLENAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Nama Bank</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox5" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Tgl. IDI BI</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_DAY" runat="server" Width="24px"
														MaxLength="2" CssClass="mandatoryColl" Columns="4"></asp:textbox>
													<asp:dropdownlist id="DDL_CS_DOB_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_YEAR" runat="server" Width="36px"
														MaxLength="4" CssClass="mandatoryColl" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Posisi Data</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return numbersonly()" id="Textbox3" runat="server" Width="24px" MaxLength="2"
														CssClass="mandatoryColl" Columns="4"></asp:textbox>
													<asp:dropdownlist id="Dropdownlist1" runat="server" CssClass="mandatoryColl"></asp:dropdownlist>
													<asp:textbox onkeypress="return numbersonly()" id="Textbox2" runat="server" Width="36px" MaxLength="4"
														CssClass="mandatoryColl" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Jenis Kredit</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox6" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
										</TABLE>
										<asp:label id="SEQ" runat="server" Visible="False"></asp:label></TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 23px" width="125">Baki Debet</TD>
												<TD style="WIDTH: 17px; HEIGHT: 23px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox1" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="125">Kolektibilitas</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_NPWP" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 21px">Umur Tunggakan</TD>
												<TD style="HEIGHT: 21px"></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox7" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 22px">Total Tunggakan
												</TD>
												<TD style="HEIGHT: 22px"></TD>
												<TD class="TDBGColorValue" align="left" style="HEIGHT: 22px">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox8" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">Remark</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="Textbox4" runat="server" Width="300px" MaxLength="200"
														TextMode="MultiLine"></asp:textbox></TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" CssClass="button1" Text="Insert"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" CssClass="button1" Text="Cancel"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<%if (Request.QueryString["bi"] == "" || Request.QueryString["bi"] == null) {%>
					<!--
					<TR>
						<TD class="tdHeader1" align="center" colSpan="2">Hubungan Dengan Bank Lain</TD>
					</TR>
					<TR>
						<TD class="td" align="center" colSpan="3">
							<TABLE id="Table_OB1" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="TDBGColorValue" align="center"><ASP:DATAGRID id="DGR_OB" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CUST REF">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CO_SEQ" HeaderText="SEQ">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_CREDTYPE" HeaderText="Jenis Kredit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_BANKNAME" HeaderText="Nama Bank">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_LIMIT" HeaderText="Limit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_BAKIDEBET" HeaderText="Baki Debet">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_TGKPOKOK" HeaderText="Tgk. Pokok">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_TGKBUNGA" HeaderText="Tgk. Bunga">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO_DUEDATE" HeaderText="J.W/Tgl. Jth. Tempo">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="COLLECTDESC" HeaderText="Kolektibilitas">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
								<tr>
									<td>&nbsp;</td>
								</tr>
							</TABLE>
							<TABLE id="Table_OB2" cellSpacing="2" cellPadding="2" align="center" border="0">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="100">Jenis Kredit</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CO_CREDTYPE" runat="server" MaxLength="30"
														Columns="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Bank</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CO_BANKNAME" runat="server" MaxLength="30"
														Columns="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Limit</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_LIMIT" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Baki Debet</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_BAKIDEBET" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Tgk. Pokok</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGKPOKOK" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgk. Bunga</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_TGKBUNGA" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">J.W/Tgl. Jth. Tempo</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATEDAY" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CO_DUEDATEMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CO_DUEDATEYEAR" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Kolektibilitas</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CO_COLLECTABILITY" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
								<TR>
									<TD align="center" colSpan="2"><asp:button id="BTN_OBINSERT" runat="server" Text="Insert"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					-->
					<% } %>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
