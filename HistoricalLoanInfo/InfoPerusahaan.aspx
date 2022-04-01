<%@ Page language="c#" Codebehind="InfoPerusahaan.aspx.cs" AutoEventWireup="True" Inherits="SME.HistoricalLoanInfo.InfoPerusahaan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InfoPerusahaan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Info Perusahaan</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<asp:label id="lbl_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">Data Kepemilikan dan 
							Pengurus&nbsp;Perusahaan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DatGridPengurus" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
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
									<asp:BoundColumn DataField="CS_DOB" HeaderText="Tgl Lahir/Pendirian/Kadaluwarsa KITAS">
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
									<asp:BoundColumn DataField="CS_KEYPERSON1" HeaderText="Key Person">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="STATUS_DESC" HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CS_REMARK" HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="view">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID><BR>
							<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD style="HEIGHT: 43px" vAlign="top" width="50%" colSpan="2"><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" onclick="setMandatory2()" runat="server" RepeatDirection="Horizontal"
											AutoPostBack="True" Enabled="False"></asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px" width="129">Nama</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_FIRSTNAME" runat="server" Width="300px" MaxLength="50" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox><BR>
													<asp:textbox id="TXT_CS_MIDDLENAME" runat="server" Width="300px" MaxLength="50" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox><BR>
													<asp:textbox id="TXT_CS_LASTNAME" runat="server" Width="300px" MaxLength="50" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Nomor KTP/Nomor Akta Pendirian/KITAS</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_IDCARDNUM" runat="server" Width="300px" MaxLength="50" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Alamat KTP/ AlamatPerusahaan</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_ADDR1" runat="server" Width="300px" MaxLength="50" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><BR>
													<asp:textbox id="TXT_CS_ADDR2" runat="server" Width="300px" MaxLength="50" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><BR>
													<asp:textbox id="TXT_CS_ADDR3" runat="server" Width="300px" MaxLength="50" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_CITY" runat="server" Width="175px" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Kode Pos</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_ZIPCODE" runat="server" AutoPostBack="True" MaxLength="6" Columns="6"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Kepemilikan Rumah</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_HOMESTA" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 127px">Remark</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_REMARK" runat="server" Width="300px" MaxLength="200" TextMode="MultiLine"
														ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
										</TABLE>
										<asp:label id="SEQ" runat="server" Visible="False"></asp:label></TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 23px" width="125">Tgl Lahir/<BR>
													Tgl&nbsp;Pendirian/Tgl Kadaluwarsa KITAS</TD>
												<TD style="WIDTH: 17px; HEIGHT: 23px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox id="TXT_CS_DOB_DAY" runat="server" Width="24px" MaxLength="2" Columns="4" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_CS_DOB_MONTH" runat="server" CssClass="mandatoryColl" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist><asp:textbox id="TXT_CS_DOB_YEAR" runat="server" Width="36px" MaxLength="4" Columns="4" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 18px" width="125">Pendidikan Terakhir</TD>
												<TD style="WIDTH: 17px; HEIGHT: 18px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 18px" align="left"><asp:dropdownlist id="DDL_CS_EDUCATION" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="125">NPWP</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_NPWP" runat="server" Width="300px" MaxLength="50" ReadOnly="True" BackColor="Gainsboro"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 21px">Job Title</TD>
												<TD style="HEIGHT: 21px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_JOBTITLE" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 1px">Pengalaman</TD>
												<TD style="HEIGHT: 1px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 1px" align="left"><asp:dropdownlist id="DDL_CS_EXPERIENCE" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Stock
												</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_STOCKPERC" runat="server" Width="48px" MaxLength="5" CssClass="" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox>&nbsp;%
													<asp:label id="LBL_TOTPERC" runat="server" Visible="False">100</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">Status</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left"><asp:radiobutton id="RDO_CS_NATSTAT0" runat="server" Text="WNI" GroupName="RDG_CS_NATSTAT" Checked="True"
														Enabled="False"></asp:radiobutton>&nbsp;&nbsp;&nbsp;
													<asp:radiobutton id="RDO_CS_NATSTAT1" runat="server" Text="WNA" GroupName="RDG_CS_NATSTAT" Enabled="False"></asp:radiobutton></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jenis Kelamin</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_SEX" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Status Pernikahan</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:dropdownlist id="DDL_CS_MARITAL" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Jumlah Anak</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_CHILDREN" runat="server" MaxLength="2" Columns="3" ReadOnly="True" BackColor="Gainsboro">0</asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Mulai Menetap
												</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox id="TXT_CS_MULAIMENETAPMM" runat="server" MaxLength="2" Columns="2" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox>(MM)
													<asp:textbox id="TXT_CS_MULAIMENETAPYY" runat="server" MaxLength="4" Columns="4" ReadOnly="True"
														BackColor="Gainsboro"></asp:textbox>(YYYY)</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Key Person</TD>
												<TD></TD>
												<TD class="TDBGColorValue" align="left"><asp:radiobuttonlist id="RDO_KEY_PERSON" runat="server" Width="150px" RepeatDirection="Horizontal" AutoPostBack="True"
														Enabled="False">
														<asp:ListItem Value="1">Ya</asp:ListItem>
														<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<%if (Request.QueryString["bi"] == "" || Request.QueryString["bi"] == null) {%>
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
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_BMGIRODAY" runat="server" MaxLength="2" Columns="2" ReadOnly="True" BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_CI_BMGIROMONTH" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist><asp:textbox id="TXT_CI_BMGIROYEAR" runat="server" MaxLength="4" Columns="4" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tabungan Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_BMSAVINGDAY" runat="server" MaxLength="2" Columns="2" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_CI_BMSAVINGMONTH" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist><asp:textbox id="TXT_CI_BMSAVINGYEAR" runat="server" MaxLength="4" Columns="4" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Debitur Sejak</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CI_BMDEBITURDAY" runat="server" MaxLength="2" Columns="2" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox><asp:dropdownlist id="DDL_CI_BMDEBITURMONTH" runat="server" Enabled="False" BackColor="Gainsboro"></asp:dropdownlist><asp:textbox id="TXT_CI_BMDEBITURYEAR" runat="server" MaxLength="4" Columns="4" ReadOnly="True"
											BackColor="Gainsboro"></asp:textbox></TD>
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
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CO_CREDTYPE" runat="server" MaxLength="30"
														Columns="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Bank</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CO_BANKNAME" runat="server" MaxLength="30"
														Columns="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Limit</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CO_LIMIT" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Baki Debet</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CO_BAKIDEBET" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1">Tgk. Pokok</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CO_TGKPOKOK" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tgk. Bunga</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CO_TGKBUNGA" runat="server" MaxLength="21"
														Columns="25" CssClass="angka"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">J.W/Tgl. Jth. Tempo</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_CO_DUEDATEDAY" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CO_DUEDATEMONTH" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CO_DUEDATEYEAR" runat="server" MaxLength="4"
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
									<TD><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="3"
											CellPadding="1" HorizontalAlign="Center">
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
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
								<TR>
									<TD class="tdHeader1">Loan Account&nbsp;jika&nbsp;Main Owner&nbsp;dan Key Person 
										adalah BM debitur</TD>
								</TR>
								<TR>
									<TD><ASP:DATAGRID id="DatGrdAccStockHolder" runat="server" Width="100%" AutoGenerateColumns="False"
											PageSize="3" CellPadding="1" HorizontalAlign="Center">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="SEQ">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="HOLD_ACC_SEQ" HeaderText="HOLD_ACC_SEQ">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="HOLD_NAME" HeaderText="Nama">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="HOLD_KEY_PERSON" HeaderText="Key Person">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="HOLD_ACC_NO" HeaderText="No Rekening">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_HOLD_ACC_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label>
							<asp:placeholder id="PH_SUBMENU" runat="server" Visible="False"></asp:placeholder>
						</TD>
					</TR>
					<% } %>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
