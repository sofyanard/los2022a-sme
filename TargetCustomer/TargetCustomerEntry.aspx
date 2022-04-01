<%@ Page language="c#" Codebehind="TargetCustomerEntry.aspx.cs" AutoEventWireup="True" Inherits="SME.TargetCustomer.TargetCustomerEntry" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TargetCustomerEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include  file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
        <%= popUp%>
		<script language="javascript">
			function approve()
			{
				conf = confirm("Are you sure you want to accept?");
				if (conf)
				{
					return true;		
				}
				else
				{
					return false;
				}
			}
			function SearchSektorEkonomi(bifrm, biobj, biurl)
			{	
				Urlnya = biurl + "../InitialDataEntry/SearchSektorEkonomi.aspx" + "?bifrm=" + bifrm + "&biobj=" + biobj;
				window.open(Urlnya,"SearchSektorEkonomi","status=no,scrollbars=no,width=800,height=600")
			}

			function HitungLimit() {
			    var CP_EXLIMITVAL = window.document.getElementById('TXT_TARGETLIMITVAL').value;
			    var CP_EXRPLIMIT = window.document.getElementById('TXT_TARGETLIMITRATE').value;
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
			    window.document.getElementById('TXT_TARGETLIMIT').value = CP_LIMIT;
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table8">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Targetting Customer Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A>
							<A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Target Customer Info
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RDO_RFCUSTOMERTYPE_SelectedIndexChanged"></asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1">Nama Pemohon</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_FIRSTNAME" runat="server" CssClass="mandatory"
											MaxLength="50" Width="300px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_MIDDLENAME" runat="server" MaxLength="50"
											Width="300px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_LASTNAME" runat="server" MaxLength="50"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tanggal Lahir</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_DAY" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_YEAR" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">No. KTP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_IDCARDNUM" runat="server" MaxLength="50"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_NPWP" runat="server" MaxLength="25"
											Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ADDR1" runat="server" MaxLength="100"
											Width="300px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ADDR2" runat="server" MaxLength="100"
											Width="300px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ADDR3" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CITY" runat="server" ReadOnly="True"></asp:textbox><asp:textbox id="LBL_CU_CITY" runat="server" style="display:none"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px">
                                        <asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" AutoPostBack="True"
											MaxLength="6" Columns="6" ontextchanged="TXT_CU_ZIPCODE_TextChanged"></asp:textbox>
                                        <!--<asp:button id="BTN_SEARCHPERSONAL" runat="server" Text="Search" onclick="BTN_SEARCHPERSONAL_Click"></asp:button>-->
                                        <input type="button" value="Search" onclick="window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE&trgObjID2=TXT_CU_ADDR3&trgObjID3=TXT_CU_CITY&trgObjID4=LBL_CU_CITY', 'SearchZipcode', 'status=no,scrollbars=no,width=640,height=480'); return false;">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_COMPANY" runat="Server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Nama Pemohon</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPTYPE" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNAME" runat="server" CssClass="mandatory2"
											MaxLength="50" Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">NPWP</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNPWP" runat="server" MaxLength="25"
											Width="300px"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Alamat</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR1" runat="server" MaxLength="100"
											Width="300px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR2" runat="server" MaxLength="100"
											Width="300px"></asp:textbox><BR>
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR3" runat="server" MaxLength="100"
											Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kota</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPCITY" runat="server" ReadOnly="True"></asp:textbox><asp:textbox id="LBL_CU_COMPCITY" runat="server" style="display:none"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kode Pos</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
                                        <asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPZIPCODE" runat="server" AutoPostBack="True"
											MaxLength="6" Columns="6" ontextchanged="TXT_CU_COMPZIPCODE_TextChanged"></asp:textbox>
                                        <!--<asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button>-->
                                        <input type="button" value="Search" onclick="window.open('../InitialDataEntry/SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE&trgObjID2=TXT_CU_COMPADDR3&trgObjID3=TXT_CU_COMPCITY&trgObjID4=LBL_CU_COMPCITY', 'SearchZipcode', 'status=no,scrollbars=no,width=640,height=480'); return false;">
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_TARGET" runat="server">
						<TD vAlign="top">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD colSpan="3"><asp:textbox id="TXT_TRG_CU_REF" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox>&nbsp;
										<asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tanggal Rencana Proses</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLPROSES_DAY" runat="server" CssClass="mandatory"
											MaxLength="2" Width="24px" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TGLPROSES_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TGLPROSES_YEAR" runat="server" CssClass="mandatory"
											MaxLength="4" Width="36px" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Unit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TARGETUNIT" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_TARGETUNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">RM/AM</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TARGETUSER" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">IAC Remark</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_IACREMARK" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Jenis Industri</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JENISINDUSTRI" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Sektor Ekonomi BI 1</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEKTOREKONOMI1" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SEKTOREKONOMI1_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Sektor Ekonomi BI 2</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEKTOREKONOMI2" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SEKTOREKONOMI2_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Sektor Ekonomi BI 3</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEKTOREKONOMI3" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_SEKTOREKONOMI3_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Sektor Ekonomi BI 4</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_SEKTOREKONOMI4" runat="server" Enabled="False"></asp:dropdownlist>&nbsp;
										<INPUT id="BTN_SEARCHSE" onclick="SearchSektorEkonomi('Form1','TXT_TEMPBI', '')" type="button"
											value="Search Sektor Ekonomi" name="BTN_SEARCHSE">&nbsp;
										<asp:textbox id="TXT_TEMPBI" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMPBI_TextChanged"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Contact Person</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CONTACTPERSON" runat="server" Width="300px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_KETERANGAN" runat="server" Width="300px"
											Rows="5" MaxLength="250" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD vAlign="top">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td colspan="3"></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" width="129">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JENISKREDIT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Segmen Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SEGMENLIMIT" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Target Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TARGETLIMITCUR" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="TXT_TARGETLIMITVAL" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_TARGETLIMIT'))"
											onkeyup="HitungLimit()" runat="server" MaxLength="25"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Exchange Rate</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_TARGETLIMITRATE" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_TARGETLIMIT'))"
											onkeyup="HitungLimit()" runat="server" MaxLength="10">1</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Target Limit in IDR</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TARGETLIMIT" runat="server" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<tr>
									<td colspan="3"></td>
								</tr>
								<TR>
									<TD class="tdHeader1" vAlign="top" width="50%" colSpan="3">Rencana Booking</TD>
								</TR>
								<TR>
									<TD colSpan="3"><ASP:DATAGRID id="DG_GRID" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
											AllowPaging="True" PageSize="5">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
												<asp:BoundColumn DataField="TERM_DATE" HeaderText="Tanggal">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TERM_VALUE" HeaderText="Nilai">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
												</asp:ButtonColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Tanggal Rencana Booking</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TERM_DATE_DAY" runat="server" MaxLength="2"
											Width="24px" Columns="4"></asp:textbox>
										<asp:dropdownlist id="DDL_TERM_DATE_MONTH" runat="server"></asp:dropdownlist>
										<asp:textbox onkeypress="return numbersonly()" id="TXT_TERM_DATE_YEAR" runat="server" MaxLength="4"
											Width="36px" Columns="4"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="129">Nilai Booking</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_TERM_VALUE" onblur="FormatCurrency(this)"
											runat="server" MaxLength="25"></asp:textbox></TD>
								</TR>
								<TR id="Tr1" runat="server">
									<TD vAlign="top" align="center" width="50%" colSpan="3">
										<asp:button id="BTN_SAVE_TERM" runat="server" Width="200px" Text="Save Rencana Booking" onclick="BTN_SAVE_TERM_Click"></asp:button>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_PERSONAL2" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE_P" runat="server" CssClass="Button1" Width="80px" Text="Save" onclick="BTN_SAVE_P_Click"></asp:button></TD>
					</TR>
					<TR id="TR_COMPANY2" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE_C" runat="server" CssClass="Button1" Width="80px" Text="Save" onclick="BTN_SAVE_C_Click"></asp:button></TD>
					</TR>
					<TR id="TR_FORWARD" runat="server">
						<TD vAlign="top" align="left" width="100%" colSpan="2">
							<TABLE width="100%">
								<TR>
									<TD class="TDBGColor1">Acceptance Forward To</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APRV" runat="server"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_UPDATE" runat="server" CssClass="Button1" Text="Forward for Acceptance" onclick="BTN_UPDATE_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_APRVBU" runat="server">
						<TD vAlign="top" align="left" width="100%" colSpan="2">
							<TABLE width="100%">
                                <!--
								<TR>
									<TD class="TDBGColor1">Next Acceptance (Risk)</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_ASSIGNBU" runat="server"></asp:dropdownlist></TD>
								</TR>
                                -->
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="3"><asp:button id="BTN_APRVBU" runat="server" CssClass="Button1" Text="Accept" onclick="BTN_APRVBU_Click"></asp:button>&nbsp;&nbsp;
										<asp:button id="BTN_ACQINFOBU" runat="server" CssClass="Button1" Text="Acquire Information" onclick="BTN_ACQINFOBU_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_APRVRISK" runat="server">
						<TD vAlign="top" align="left" width="100%" colSpan="2">
							<TABLE width="100%">
								<TR>
									<TD class="TDBGColor1">Acceptance Assign To</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_ASSIGNRISK" runat="server"></asp:dropdownlist></TD>
									<TD class="TDBGColor2"><asp:button id="BTN_ASSIGNRISK" runat="server" CssClass="Button1" Text="Assign" onclick="BTN_ASSIGNRISK_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="4"><asp:button id="BTN_APRVRISK" runat="server" CssClass="Button1" Text="Accept" onclick="BTN_APRVRISK_Click"></asp:button>&nbsp;&nbsp;
										<asp:button id="BTN_ACQINFORISK" runat="server" CssClass="Button1" Text="Acquire Information" onclick="BTN_ACQINFORISK_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
