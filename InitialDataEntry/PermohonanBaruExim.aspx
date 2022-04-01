<%@ Page language="c#" Codebehind="PermohonanBaruExim.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PermohonanBaruExim" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PermohonanBaruExim</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryColl.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
		    function HitungLimit() {
		        var CP_EXLIMITVAL = window.document.getElementById('TXT_CP_EXLIMITVAL').value;
		        var CP_EXRPLIMIT = window.document.getElementById('TXT_CP_EXRPLIMIT').value;
		        var CP_LIMIT;
		        var EXLIMIT;
		        var EXRPLIMIT;

		        if (IsNumeric(parseFloat(CP_EXLIMITVAL)))
		            EXLIMIT = parseFloat(CP_EXLIMITVAL.replace(/\./g, ''));
		        else
		            EXLIMIT = 0;

		        if (IsNumeric(parseFloat(CP_EXRPLIMIT)))
		            EXRPLIMIT = parseFloat(CP_EXRPLIMIT.replace(/\./g, ''));
		        else
		            EXRPLIMIT = 0;
		        CP_LIMIT = EXLIMIT * EXRPLIMIT;
		        /*CP_LIMIT = CP_LIMIT.replace('.', ',');*/
		        window.document.getElementById('TXT_CP_LIMIT').value = CP_LIMIT;
		    }

		    function HitungColValue() {
		        var CL_FOREIGNVAL = window.document.getElementById('TXT_CL_FOREIGNVAL').value;
		        var CL_EXCHANGERATE = window.document.getElementById('TXT_CL_EXCHANGERATE').value;
		        var CL_VALUE;
		        var FOREIGNVAL;
		        var EXCHANGERATE;

		        if (IsNumeric(parseFloat(CL_FOREIGNVAL)))
		            FOREIGNVAL = parseFloat(CL_FOREIGNVAL.replace(/\./g, ''));
		        else
		            FOREIGNVAL = 0;

		        if (IsNumeric(parseFloat(CL_EXCHANGERATE)))
		            EXCHANGERATE = parseFloat(CL_EXCHANGERATE.replace(/\./g, ''));
		        else
		            EXCHANGERATE = 0;
		        CL_VALUE = FOREIGNVAL * EXCHANGERATE;
		        /*CL_VALUE = CL_VALUE.replace('.', ',');*/
		        window.document.getElementById('TXT_CL_VALUE').value = CL_VALUE;
		    }			
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
									<TD class="TDBGColor1" width="180">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_APPTYPE" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_EXLIMITVAL" onkeypress="return digitsonly()" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeyup="HitungLimit()" runat="server" CssClass="mandatory" MaxLength="15" 
                                            ontextchanged="TXT_CP_EXLIMITVAL_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Exchange Rate to IDR</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_EXRPLIMIT" onkeyup="HitungLimit()" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMIT'))"
											onkeypress="return digitsonly()" runat="server" CssClass="mandatory" MaxLength="10">1</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit in IDR</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_LIMIT" runat="server" ReadOnly="True" Width="300px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_JANGKAWKT" runat="server" CssClass="mandatory" Columns="3" MaxLength="3"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server" CssClass="mandatory"></asp:dropdownlist>
										<asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD></TD>
									<TD></TD>
								</TR>
							</TABLE>
							<asp:CheckBox id="CHK_NCL_LIMIT" runat="server" AutoPostBack="True" Checked="True" Text="NCL Limit saja"
								Font-Bold="True" oncheckedchanged="CHK_NCL_LIMIT_CheckedChanged"></asp:CheckBox>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_NOTES" runat="server" Width="100%" Height="100px" TextMode="MultiLine"
											onkeypress="return kutip_satu()" MaxLength="300"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;Collateral</TD>
									<TD></TD>
									<TD>
										<asp:CheckBox id="CHK_COLLATERAL" runat="server" Text="(check for yes)" 
                                            AutoPostBack="True" oncheckedchanged="CHK_COLLATERAL_CheckedChanged"></asp:CheckBox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:label>
							<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Visible="False"></asp:DropDownList>
						</TD>
					</TR>
					<TR id="TR_NCL" runat="server">
						<TD class="td" colSpan="2">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="180">Tanggal Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_ISSUEDATE_DD" runat="server" Width="24px" Columns="4" MaxLength="2" onkeypress="return digitsonly()"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_ISSUEDATE_MM" runat="server"></asp:dropdownlist>
										<asp:textbox id="TXT_CP_ISSUEDATE_YY" runat="server" Width="36px" Columns="4" MaxLength="4" onkeypress="return digitsonly()"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Jatuh Tempo</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_DUEDATE_DD" runat="server" Width="24px" onkeypress="return digitsonly()"
											Columns="4" MaxLength="2"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_DUEDATE_MM" runat="server"></asp:dropdownlist>
										<asp:textbox id="TXT_CP_DUEDATE_YY" runat="server" Width="36px" onkeypress="return digitsonly()"
											Columns="4" MaxLength="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Dasar Permohonan Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_REQUEST" MaxLength="100" runat="server" onkeypress="return kutip_satu()"
											Width="500px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Ditujukan Kepada</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_ISSUETO" MaxLength="100" runat="server" onkeypress="return kutip_satu()"
											Width="500px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_ISSUEADDR1" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="175px"></asp:TextBox><BR>
										<asp:TextBox id="TXT_CP_ISSUEADDR2" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="175px"></asp:TextBox><BR>
										<asp:TextBox id="TXT_CP_ISSUEADDR3" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="175px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Barang / Komoditi</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_COMMODITYNAME" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="500px"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_COMMODITYAMNT" MaxLength="6" runat="server" onkeypress="return digitsonly()"
											Width="50px">0</asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nilai FOB/CIF/CNF</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_VALUE" runat="server" MaxLength="15" onkeypress="return digitsonly()">0</asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bank Koresponden</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_CP_BANKCORR" runat="server"></asp:DropDownList>
										<asp:DropDownList id="DDL_CP_BANKCORRCITY" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD width="17"></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CP_BANKADDR1" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="175px"></asp:TextBox><BR>
										<asp:TextBox id="TXT_CP_BANKADDR2" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="175px"></asp:TextBox><BR>
										<asp:TextBox id="TXT_CP_BANKADDR3" onkeypress="return kutip_satu()" MaxLength="100" runat="server"
											Width="175px"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COLL" runat="server">
						<TD align="center" colSpan="2" class="td">
							<TABLE id="TableKu" cellSpacing="2" cellPadding="2" width="100%" border="0">
								<TR>
									<TD align="center" colSpan="2">
										<ASP:DATAGRID id="DatGrd" runat="server" Width="75%" CellPadding="1" PageSize="7" AutoGenerateColumns="False"
											AllowPaging="True">
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
									<TD class="td" vAlign="top" align="center" width="50%">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD width="129" colSpan="3">
													<asp:radiobuttonlist id="RDO_COLLATERAL" runat="server" AutoPostBack="True" Width="150px" RepeatDirection="Horizontal">
														<asp:ListItem Value="1" Selected="True">New</asp:ListItem>
														<asp:ListItem Value="2">Existing</asp:ListItem>
													</asp:radiobuttonlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="129">Jenis Jaminan</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_CL_TYPE" runat="server"></asp:dropdownlist>
													<asp:dropdownlist id="DDL_CL_TYPE_EXISTING" runat="server" AutoPostBack="True" Visible="False" onselectedindexchanged="DDL_CL_TYPE_EXISTING_SelectedIndexChanged"></asp:dropdownlist>
													<asp:Label id="LBL_SISAUTILIZATION" runat="server" Visible="False">100</asp:Label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Keterangan</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_CL_DESC" onkeypress="return kutip_satu()" runat="server" CssClass="mandatoryColl"
														MaxLength="50" Width="300px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatoryColl"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Currency</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatoryColl" AutoPostBack="True" onselectedindexchanged="DDL_CL_CURRENCY_SelectedIndexChanged"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" width="129">Nilai</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_CL_FOREIGNVAL" onkeypress="return digitsonly()" onkeyup="HitungColValue()"
														onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUE'))" runat="server"
														CssClass="mandatoryColl" MaxLength="15" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="129">Exchange Rate to Rp</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_CL_EXCHANGERATE" onkeypress="return digitsonly()" onkeyup="HitungColValue()"
														onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CL_VALUE'))" runat="server"
														CssClass="mandatoryColl" MaxLength="5" Width="200px">1</asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="129">Nilai in Rp</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_CL_VALUE" runat="server" ReadOnly="True" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">% Use</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_LC_PERCENTAGE" runat="server" onkeypress="return digitsonly()" CssClass="mandatoryColl"
														MaxLength="3" Width="50px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" width="50%" colSpan="2">
										<asp:button id="BTN_INSCOLL" runat="server" Text="Tambah Collateral" CssClass="button1" onclick="BTN_INSCOLL_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" Width="70px" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Width="70px" Text="Next" Enabled="False"
								Visible="False" onclick="Button2_Click"></asp:button>
							<asp:button id="Button1" runat="server" CssClass="Button1" Visible="False" Width="150px" Text="Update Status"
								Enabled="False" onclick="Button1_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
							<ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
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
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
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
