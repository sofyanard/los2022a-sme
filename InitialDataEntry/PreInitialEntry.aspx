<%@ Page language="c#" Codebehind="PreInitialEntry.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PreInitialEntry" enableViewState="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GeneralInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Pre Initial Entry</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2"><asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label>Customer 
							Info</TD>
					</TR>
					<TR id="TR_PERSONAL" runat="server">
						<TD vAlign="top" align="center" colSpan="2">
							<TABLE class="td" id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD colSpan="2"><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
											Enabled="False" onselectedindexchanged="RDO_RFCUSTOMERTYPE_SelectedIndexChanged"></asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="1">
										<TABLE id="Table6" style="WIDTH: 464px; HEIGHT: 25px" cellSpacing="1" cellPadding="1" width="464"
											border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 107px">Perihal</TD>
												<TD>:</TD>
												<TD><asp:textbox onkeypress="return kutip_satu();" id="TXT_PRE_PERIHAL" runat="server" Width="300px"
														MaxLength="50" CssClass="mandatory"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td">
										<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px">Mata Uang</TD>
												<TD>:</TD>
												<TD><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" Width="81px" CssClass="mandatory"></asp:dropdownlist>&nbsp;</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 142px">Application Amount</TD>
												<TD></TD>
												<TD><asp:textbox onkeypress="return digitsonly();" id="TXT_PRE_APPAMOUNT" onblur="FormatCurrency(this)"
														runat="server" Width="222px" MaxLength="15" CssClass="mandatory"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="td">
										<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Nama Pemohon</TD>
												<TD></TD>
												<TD>:</TD>
												<TD><asp:textbox onkeypress="return kutip_satu();" id="TXT_CU_FIRSTNAME" runat="server" Width="300px"
														MaxLength="50" CssClass="mandatory" ReadOnly="True"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu();" id="TXT_CU_MIDDLENAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu();" id="TXT_CU_LASTNAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<!-- Pipeline JT -->
											<TR id="TR_TGL_APL" runat="server">
												<TD class="TDBGColor1" style="HEIGHT: 20px">
													<asp:label id="LBL_TGL_APL" runat="server" Visible="True"></asp:label>
												</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD style="HEIGHT: 20px">:</TD>
												<TD style="HEIGHT: 20px"><asp:textbox onkeypress="return numbersonly()" id="TXT_DAY_APP" runat="server" Width="24px" MaxLength="2"
														CssClass="mandatory" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MONTH_APP" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_APP" runat="server" Width="36px"
														MaxLength="4" CssClass="mandatory" Columns="4"></asp:textbox></TD>
											</TR>
											<!-- Additional Field Tanggal Terima -- Pipeline JT -->
											<TR id="TR_TGL_TRM" runat="server">
												<TD class="TDBGColor1" style="HEIGHT: 20px">Tanggal Terima</TD>
												<TD style="HEIGHT: 20px"></TD>
												<TD style="HEIGHT: 20px">:</TD>
												<TD style="HEIGHT: 20px"><asp:textbox onkeypress="return numbersonly()" id="TXT_DAY_TRM" runat="server" Width="24px" MaxLength="2"
														CssClass="mandatory" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_MONTH_TRM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR_TRM" runat="server" Width="36px"
														MaxLength="4" CssClass="mandatory" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 20px">
													<asp:label id="LBL_RMUSER" runat="server" Visible="True"></asp:label>
												</TD>
												<TD></TD>
												<TD>:</TD>
												<TD><asp:dropdownlist id="DDL_RMUSER" runat="server" Enabled="False" CssClass="mandatory"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top">
										<TABLE id="tblKTP" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 141px"><asp:label id="Label1" runat="server">No KTP</asp:label></TD>
												<TD></TD>
												<TD>:</TD>
												<TD><asp:textbox onkeypress="return kutip_satu();" id="TXT_CU_IDCARDNUM" runat="server" Width="300px"
														MaxLength="50" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 141px"><asp:label id="Label2" runat="server">Tgl Kadaluarsa</asp:label></TD>
												<TD></TD>
												<TD>:</TD>
												<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_DAY" runat="server" Width="24px"
														MaxLength="2" ReadOnly="True" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_IDCARDEXP_MONTH" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_YEAR" runat="server" Width="36px"
														MaxLength="4" ReadOnly="True" Columns="4"></asp:textbox></TD>
											</TR>
										</TABLE>
										<TABLE id="tblNPWP" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 141px"><asp:label id="Label3" runat="server">No NPWP</asp:label></TD>
												<TD></TD>
												<TD>:</TD>
												<TD><asp:textbox onkeypress="return kutip_satu();" id="TXT_CU_NPWP" runat="server" Width="296px"
														MaxLength="25" ReadOnly="True"></asp:textbox></TD>
											</TR>
											&lt;--!jito --&gt;
											<TR id="TR_DDL_UNIT" runat="server">
												<TD class="TDBGColor1" style="WIDTH: 141px"><asp:label id="Label4" runat="server">Assign To Unit</asp:label></TD>
												<TD></TD>
												<TD>:</TD>
												<TD>
													<asp:dropdownlist id="DDL_UNIT" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
										<asp:label id="LBL_MC" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRE_SEQSURAT" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF2" runat="server" Visible="False"></asp:label><asp:label id="LBL_EXIST" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR id="TR_BUTTON" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_UPDATE" runat="server" Visible="False" Width="101px" CssClass="Button1"
								Text="Update" onclick="BTN_UPDATE_Click"></asp:button><asp:button id="BTN_ADD" runat="server" Width="101px" CssClass="Button1" Text="Add" onclick="BTN_ADD_Click"></asp:button><asp:button id="BTN_CANCEL" runat="server" Width="101" CssClass="Button1" Text="Cancel" onclick="BTN_CANCEL_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" align="center" colSpan="2"><asp:label id="LBL_MESSAGE" runat="server" Visible="False"></asp:label>Pending 
							Applications</TD>
					</TR>
					<TR id="Grid_Add" runat="server">
						<TD class="td" vAlign="top" align="center" colSpan="2"><ASP:DATAGRID id="DatGridPreEntry" runat="server" Width="942px" CellPadding="1" PageSize="5" AutoGenerateColumns="False"
								AllowSorting="True" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRE_SEQSURAT" HeaderText="PRE_SEQSURAT"></asp:BoundColumn>
									<asp:BoundColumn DataField="PRE_PERIHAL" HeaderText="Perihal">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRE_APPENTRYDATE" HeaderText="Tanggal Aplikasi" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AMOUNT" HeaderText="App Amount" DataFormatString="{0:0,00.00}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RMUSER_NAME" HeaderText="RM User">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="pre_idcardexp" HeaderText="Tgl Kedaluarsa" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="View">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="Delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="AP_REGNO"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR id="Grid_Exist" runat="server">
						<TD class="td" vAlign="top" align="center" colSpan="2">
							<ASP:DATAGRID id="DatGridExist" runat="server" Width="942px" AllowPaging="True" AllowSorting="True"
								AutoGenerateColumns="False" PageSize="5" CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Nasabah">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_CUSTTYPE" HeaderText="Jenis Nasabah">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_CARD" HeaderText="KTP/NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NUM" HeaderText="Nomor KTP/NPWP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
