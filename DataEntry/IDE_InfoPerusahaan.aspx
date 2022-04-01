<%@ Page language="c#" Codebehind="IDE_InfoPerusahaan.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.IDE_InfoPerusahaan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>IDE_InfoPerusahaan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryColl.html" -->
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" colSpan="2">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: Info 
											Perusahaan</B></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<asp:label id="lbl_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Data Kepemilikan 
							Perusahaan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="45%" colSpan="2" align="center"><ASP:DATAGRID id="DatGridPengurus" runat="server" CellPadding="1" PageSize="1" AutoGenerateColumns="False"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_DOB" HeaderText="Tgl Lahir/Pendirian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_IDCARDNUM" HeaderText="No. KTP/AKTA">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CS_NPWP" HeaderText="NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="JOBTITLEDESC" HeaderText="Jabatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_STOCKPERC" HeaderText="Saham (%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="EDUCATIONDESC" HeaderText="Pendidikan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AGE" HeaderText="Umur">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="EXPDESC" HeaderText="Pengalaman">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_KEYPERSON1" HeaderText="Pemilik">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS_DESC" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_REMARK" HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID><BR>
							<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD vAlign="top" width="50%" colSpan="2"><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RDO_RFCUSTOMERTYPE_SelectedIndexChanged"></asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px" width="129">Nama</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_FIRSTNAME" runat="server" Width="300px"
														CssClass="mandatoryColl" MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_MIDDLENAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_LASTNAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Nomor KTP/Nomor Akta Pendirian</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_IDCARDNUM" runat="server" Width="300px"
														CssClass="mandatoryColl" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Alamat KTP/ AlamatPerusahaan</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR1" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR2" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_ADDR3" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_CITY" runat="server" Width="175px" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Kode Pos</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_ZIPCODE" runat="server" AutoPostBack="True" MaxLength="6" Columns="6" ontextchanged="TXT_CS_ZIPCODE_TextChanged"></asp:textbox><asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Kepemilikan&nbsp;Rumah</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:dropdownlist id="DDL_CS_HOMESTA" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Remark</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left">
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_REMARK" runat="server" Width="300px"
														MaxLength="200" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
										</TABLE>
										<asp:label id="SEQ" runat="server"></asp:label></TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px" width="125">Tgl Lahir/<BR>
													Tanggal Pendirian</TD>
												<TD style="WIDTH: 17px; HEIGHT: 14px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 14px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_DAY" runat="server" Width="24px"
														MaxLength="2" Columns="4" CssClass="mandatoryColl"></asp:textbox><asp:dropdownlist id="DDL_CS_DOB_MONTH" runat="server" CssClass="mandatoryColl"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_YEAR" runat="server" Width="36px"
														MaxLength="4" Columns="4" CssClass="mandatoryColl"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px" width="125">Pendidikan Terakhir</TD>
												<TD style="WIDTH: 17px; HEIGHT: 18px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 18px" align="left"><asp:dropdownlist id="DDL_CS_EDUCATION" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="125">NPWP</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CS_NPWP" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 21px">Job Title</TD>
												<TD style="HEIGHT: 21px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_JOBTITLE" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 1px">Pengalaman</TD>
												<TD style="HEIGHT: 1px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 1px" align="left"><asp:dropdownlist id="DDL_CS_EXPERIENCE" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Stock
												</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return digitsonly()" id="TXT_CS_STOCKPERC" runat="server" Width="48px"
														CssClass="mandatoryColl" MaxLength="5"></asp:textbox>&nbsp;%
													<asp:label id="LBL_TOTPERC" runat="server" Visible="False">100</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">Status</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left"><asp:radiobutton id="RDO_CS_NATSTAT0" runat="server" Text="WNI" Checked="True" GroupName="RDG_CS_NATSTAT"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="RDO_CS_NATSTAT1" runat="server" Text="WNA" GroupName="RDG_CS_NATSTAT"></asp:radiobutton></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">Jenis Kelamin</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left">
													<asp:dropdownlist id="DDL_CS_SEX" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">Status Pernikahan</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left">
													<asp:dropdownlist id="DDL_CS_MARITAL" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">Jumlah Anak</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left">
													<asp:textbox onkeypress="return numbersonly()" id="TXT_CS_CHILDREN" runat="server" MaxLength="4"
														Columns="3">0</asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">Mulai Menetap</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left">
													<asp:textbox id="TXT_CS_MULAIMENETAPMM" runat="server" MaxLength="2" Columns="2"></asp:textbox>(MM)
													<asp:textbox id="TXT_CS_MULAIMENETAPYY" runat="server" MaxLength="4" Columns="4"></asp:textbox>(YYYY)</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">
													Pemilik</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_KEY_PERSON" runat="server" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
														<asp:ListItem Value="0">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_STOCKHOLDER" runat="server" CssClass="button1" Text="Add Stockholder" onclick="BTN_STOCKHOLDER_Click"></asp:button><asp:button id="BTN_UPDATE_NEW" runat="server" Visible="False" CssClass="button1" Text="Update" onclick="BTN_UPDATE_NEW_Click"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" CssClass="button1" Text="Cancel" onclick="BTN_CANCEL_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Hubungan Dengan Bank 
							Mandiri</TD>
					</TR>
					<TR>
						<TD class="td" align="center" colSpan="2">
							<TABLE id="Table_BM" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="TDBGColor1" width="100">Giro Sejak</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMGIRODAY" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CI_BMGIROMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMGIROYEAR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tabungan Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMSAVINGDAY" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CI_BMSAVINGMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMSAVINGYEAR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Debitur Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMDEBITURDAY" runat="server" MaxLength="2"
											Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CI_BMDEBITURMONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CI_BMDEBITURYEAR" runat="server" MaxLength="4"
											Columns="4"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
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
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="TD" align="center" colSpan="2">
							<%if (Request.QueryString["exist"] == "1") {%>
							<TABLE id="TBL_CUST_LOAN_INFO" cellSpacing="1" cellPadding="1" width="100%" border="0"
								runat="server">
								<TR>
									<TD class="tdHeader1">Customer Loan Info</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD>
													<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1">&nbsp;</TD>
															<TD></TD>
															<TD class="TDBGColorValue"><asp:radiobuttonlist id="RB_ACCOUNT" runat="server" Width="327px" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RB_ACCOUNT_SelectedIndexChanged">
																	<asp:ListItem Value="0" Selected="True">Existing AA# entry in LOS</asp:ListItem>
																	<asp:ListItem Value="1">New AA# entry in LOS</asp:ListItem>
																</asp:radiobuttonlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="HEIGHT: 8px">AA No.</TD>
															<TD style="HEIGHT: 8px"></TD>
															<TD class="TDBGColorValue" style="HEIGHT: 8px"><asp:dropdownlist id="DDL_AI_AA_NO" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_AI_AA_NO" runat="server" Visible="False"
																	Width="136px" MaxLength="20" CssClass="mandatory"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="HEIGHT: 17px">No.&nbsp;Fasilitas</TD>
															<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
															<TD class="TDBGColorValue" style="HEIGHT: 16px"><asp:dropdownlist id="DDL_AI_FACILITY" runat="server" AutoPostBack="True" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_STATUS" runat="server" Visible="False"
																	Width="96px" CssClass="mandatory">insert</asp:textbox>&nbsp;
																<asp:textbox onkeypress="return numbersonly()" id="TXT_AI_SEQ" runat="server" Width="100px" MaxLength="15"
																	CssClass="mandatory"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
												<TD>
													<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD class="TDBGColor1" style="HEIGHT: 15px" width="150">Product</TD>
															<TD style="WIDTH: 15px; HEIGHT: 15px"></TD>
															<TD class="TDBGColorValue" style="HEIGHT: 15px"><asp:dropdownlist id="DDL_PRODUCT" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" width="150">No. Rekening</TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AI_NOREK" runat="server" Width="300px"
																	MaxLength="13" Columns="25" CssClass="]["></asp:textbox></TD>
														</TR>
														<TR>
															<TD width="150"></TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR>
														<TR>
															<TD width="150"></TD>
															<TD style="WIDTH: 15px"></TD>
															<TD class="TDBGColorValue"></TD>
														</TR> <!--<TR>
									<TD class="TDBGColor1" width="150">Limit&nbsp; Account</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AI_LIMIT" runat="server" AutoPostBack="True"
											CssClass="angka">0</asp:textbox></TD>
								</TR>--></TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor2"><asp:button id="BTN_NEW" runat="server" Width="75px" CssClass="button1" Text="Save" onclick="BTN_NEW_Click"></asp:button><asp:button id="Button1" runat="server" Width="75px" CssClass="button1" Text="Cancel" onclick="Button1_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center"><ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" PageSize="3" AutoGenerateColumns="False"
											Width="100%" HorizontalAlign="Center" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="aa_no" HeaderText="AA No.">
													<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="productid" HeaderText="No. Fasilitas">
													<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="limit" HeaderText="Total Limit / Baki Debet">
													<HeaderStyle HorizontalAlign="Right" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Tenor" HeaderText="Tenor">
													<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="acc_no" HeaderText="No. Rekening">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="acc_seq" HeaderText="Sequence">
													<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="limit" HeaderText="Limit Account">
													<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:ButtonColumn Text="Edit" CommandName="Edit">
													<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:ButtonColumn>
												<asp:ButtonColumn Text="Delete" CommandName="Delete">
													<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:ButtonColumn>
												<asp:BoundColumn Visible="False" DataField="bc_tenor" HeaderText="tenor"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="bc_tenorcode" HeaderText="tenorcode"></asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
							<% } %>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button>
							<asp:button id="BTN_UPDATE" runat="server" Width="100px" CssClass="Button1" Text="Continue" onclick="BTN_UPDATE_Click"></asp:button><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
