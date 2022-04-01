<%@ Page language="c#" Codebehind="PermohonanBaru.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PermohonanBaru" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PermohonanBaru</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryColl.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="vbscript">
		function HitungLimit()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CP_EXLIMITVAL.value) then
				EXLIMIT = cdbl(obj.TXT_CP_EXLIMITVAL.value)
			else
				EXLIMIT = 0
			end if
			
			if isnumeric(obj.TXT_CP_EXRPLIMIT.value) then
				EXRPLIMIT = cdbl(obj.TXT_CP_EXRPLIMIT.value)
			else
				EXRPLIMIT = 0
			end if
			obj.TXT_CP_LIMIT.value = EXLIMIT * EXRPLIMIT	
			obj.TXT_CP_LIMIT.value = replace(obj.TXT_CP_LIMIT.value, ".", ",")
		end function
		
		function HitungColValue()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CL_FOREIGNVAL.value) then
				FOREIGNVAL = cdbl(obj.TXT_CL_FOREIGNVAL.value)
			else
				FOREIGNVAL = 0
			end if
			
			if isnumeric(obj.TXT_CL_EXCHANGERATE.value) then
				EXCHANGE = cdbl(obj.TXT_CL_EXCHANGERATE.value)
			else
				EXCHANGE = 0
			end if
			obj.TXT_CL_VALUE.value = FOREIGNVAL * EXCHANGE
			obj.TXT_CL_VALUE.value = replace(obj.TXT_CL_VALUE.value, ".", ",")
		end function			
		</script>
		<script language="javascript">
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<!--
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Permohonan Baru</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Loan</TD>
					</TR>
					<TR id="TR_JENISPENGAJUAN" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPTYPE" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PRODUCTID" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXLIMITVAL" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
											onkeyup="HitungLimit()" runat="server" CssClass="mandatory" MaxLength="15"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Exchange Rate to Rp</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CP_EXRPLIMIT" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CP_LIMIT)"
											onkeyup="HitungLimit()" runat="server" CssClass="mandatory" MaxLength="15">1</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit in Rp</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_LIMIT" runat="server" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CP_JANGKAWKT" runat="server" CssClass="mandatory"
											MaxLength="3" Columns="3"></asp:textbox><asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
							<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Visible="False"></asp:DropDownList>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_NOTES" runat="server" MaxLength="200"
											TextMode="MultiLine" Height="100px" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Collateral</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_COLLATERAL" runat="server" 
                                            AutoPostBack="True" Text="(check for yes)" 
                                            oncheckedchanged="CHK_COLLATERAL_CheckedChanged"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alih Debitur</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_ALIHDEB" runat="server" AutoPostBack="True" Text="(check for yes)" oncheckedchanged="CHK_ALIHDEB_CheckedChanged"></asp:checkbox></TD>
								</TR>
								<TR id="TR_OLDCIFNO" runat="server">
									<TD class="TDBGColor1">Old CIF No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDCIFNO" runat="server" CssClass="mandatory" MaxLength="19"></asp:textbox></TD>
								</TR>
								<TR id="TR_OLDACCNO" runat="server">
									<TD class="TDBGColor1">Old Account No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_OLDACCNO" runat="server" CssClass="mandatory" MaxLength="19"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:label>
						</TD>
					</TR>
					<TR id="TR_COLL" runat="server">
						<TD class="td" colSpan="2">
							<P>
								<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<TR>
										<TD align="center" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="75%" AutoGenerateColumns="False" PageSize="7"
												CellPadding="1">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="CL_SEQ" HeaderText="Sequence"></asp:BoundColumn>
													<asp:BoundColumn DataField="CL_DESC" HeaderText="Keterangan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="COLTYPEID" HeaderText="Col Type"></asp:BoundColumn>
													<asp:BoundColumn DataField="COLTYPEDESC" HeaderText="Jenis Jaminan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="LC_PERCENTAGE" HeaderText="% Use">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn HeaderText="Nilai Akhir">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="ISNEW" HeaderText="ISNEW"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_CURRENCY" HeaderText="Currency"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_COLCLASSIFY" HeaderText="ColClassify"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_FOREIGNVAL" HeaderText="ForeignValue"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_EXCHANGERATE" HeaderText="ExchangeRate"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
									<TR>
										<TD class="td" vAlign="top" align="center" width="50%"><TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD width="129" colSpan="3"><asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" AutoPostBack="True" Width="150px" RepeatDirection="Horizontal" onselectedindexchanged="RDO_COLLATERAL_SelectedIndexChanged">
															<asp:ListItem Value="1" Selected="True">New</asp:ListItem>
															<asp:ListItem Value="2">Existing</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129"><asp:label id="Label1" runat="server"></asp:label></TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_TYPE" runat="server"></asp:dropdownlist><asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" AutoPostBack="True" Visible="False" onselectedindexchanged="DDL_CL_TYPE_EXISTING_SelectedIndexChanged"></asp:dropdownlist><asp:label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:label></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1"><asp:label id="Label2" runat="server"></asp:label></TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CL_DESC" runat="server" CssClass="mandatoryColl"
															MaxLength="150" Width="300px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 11px">Klasifikasi Jaminan</TD>
													<TD style="WIDTH: 15px; HEIGHT: 11px"></TD>
													<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Currency</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatoryColl" AutoPostBack="True" onselectedindexchanged="DDL_CL_CURRENCY_SelectedIndexChanged"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="td" vAlign="top" align="center">
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1" width="129">Nilai</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_FOREIGNVAL" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE)"
															onkeyup="HitungColValue()" runat="server" CssClass="mandatoryColl" MaxLength="15" Width="300px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129">Exchange Rate to Rp</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CL_EXCHANGERATE" onblur="FormatCurrency(this), FormatCurrency(document.Form1.TXT_CL_VALUE)"
															onkeyup="HitungColValue()" runat="server" MaxLength="10" Width="300px">1</asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" width="129">Nilai in Rp</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_VALUE" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">% Use</TD>
													<TD style="WIDTH: 15px"></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_LC_PERCENTAGE" runat="server" CssClass="mandatoryColl"
															MaxLength="3" Width="50px"></asp:textbox></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD align="center" width="50%" colSpan="2"><asp:button id="BTN_INSCOLL" runat="server" CssClass="button1" Text="Tambah Collateral" onclick="BTN_INSCOLL_Click"></asp:button></TD>
									</TR>
								</TABLE>
							</P>
						</TD>
					</TR>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="125px" Text="Save" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Visible="False" Width="125px" Text="Next"
								Enabled="False" onclick="Button2_Click"></asp:button><asp:button id="Button1" runat="server" CssClass="Button1" Visible="False" Width="150px" Text="Update Status"
								Enabled="False" onclick="Button1_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CP_FACILITYNO" HeaderText="Fasilitas No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE" HeaderText="APPTYPE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_EXLIMITVAL" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMITCHGTO" HeaderText="Limit Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORDESC" HeaderText="Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORLAMA" HeaderText="Tenor Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
									<asp:TemplateColumn Visible="false">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
		<script language="javascript">
		function buka()
		{
			window.open("../DataEntry/SkalaAngsuran_Main.aspx", "", "width=640,height=400, scrollbars=yes");
		}
		</script>
	</body>
</HTML>
