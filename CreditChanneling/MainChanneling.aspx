<%@ Page language="c#" Codebehind="MainChanneling.aspx.cs" AutoEventWireup="True" Inherits="SME.Credit_Channeling.MainChanneling" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Upload File</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<script language="javascript">
			function refreshParent() {
				window.opener.document.Form1.submit();
			}
		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table5">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Channeling to End 
										Users</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table1" style="WIDTH: 450px; HEIGHT: 208px" cellSpacing="1" cellPadding="1"
							width="450" border="0">
							<TR>
								<TD class="tdheader1">Credit Channeling to End Users</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px; HEIGHT: 22px">Sub-segment/Program</TD>
											<TD style="WIDTH: 8px; HEIGHT: 22px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:dropdownlist id="DDL_PROGRAM" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PROGRAM_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px">Nama Petugas</TD>
											<TD style="WIDTH: 8px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_SU_FULLNAME" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px">Nama RM/SBO</TD>
											<TD style="WIDTH: 8px"></TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_RELMNGR" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px">Nama Perusahaan</TD>
											<TD style="WIDTH: 8px"></TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_COMPNAME" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_COMPNAME_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px">AA No.</TD>
											<TD style="WIDTH: 8px">:</TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AANO" runat="server" CssClass="mandatory" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_AANO_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px">No. Fasilitas</TD>
											<TD style="WIDTH: 8px">:</TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SIBS_PRODID" runat="server" CssClass="mandatory" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_SIBS_PRODID_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_ACC_SEQ" runat="server" CssClass="mandatory" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_ACC_SEQ_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px">Sisa Plafond</TD>
											<TD style="WIDTH: 8px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_CH_PLAFOND_LOS" runat="server" ReadOnly="True" BorderStyle="None" Width="200px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 159px">Kadaluwarsa</TD>
											<TD style="WIDTH: 8px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_CH_TENOR" runat="server" ReadOnly="True" BorderStyle="None" Width="104px"></asp:textbox><asp:textbox id="TXT_CH_TENORDESC" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="TDBGCOLOR1">File</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><INPUT class="mandatory" id="TXT_FILE_UPLOAD" style="WIDTH: 380px; HEIGHT: 19px" type="file"
													size="44" name="TXT_FILE_UPLOAD" runat="server"></TD>
										</TR>
										<TR>
											<TD class="TDBGCOLOR1">Status
											</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
													ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS)$" ErrorMessage="Only xls files are allowed!"></asp:regularexpressionvalidator></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="LBL_BPREXIST" runat="server" Visible="False"></asp:label><asp:label id="LBL_LIMIT" runat="server" Visible="False"></asp:label><asp:label id="LBL_BATCHNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CH_NAMAFILE" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TDBGCOLOR2" align="center"><asp:button id="BTN_UPLOAD" runat="server" CssClass="BUTTON1" Width="113" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button><asp:button id="BTN_NEXT" runat="server" CssClass="BUTTON1" Enabled="False" Width="113" Text="Next" onclick="BTN_NEXT_Click"></asp:button><asp:label id="LBL_AP_REGNO" runat="server" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 163px">Format File</TD>
											<TD></TD>
											<TD>
												<P><asp:hyperlink id="HyperLink1" runat="server" Font-Bold="True" NavigateUrl="..\CreditChannelingUpload\FORMAT CHANNELING.xls"
														Target="_blank">Download</asp:hyperlink><asp:dropdownlist id="DDL_BUSINESSUNIT" runat="server" Visible="False">
														<asp:ListItem Value="SM100" Selected="True">Small Business Unit</asp:ListItem>
													</asp:dropdownlist></P>
											</TD>
										</TR>
									</TABLE>
									<asp:label id="LBL_MSGTRIP" runat="server" Visible="False">0</asp:label>
									<STRONG></STRONG>
								</TD>
							</TR>
						</TABLE>
						<P>
							<asp:DataGrid id="DatGrdTemp" runat="server" Width="437px" ForeColor="Black" PageSize="100" AutoGenerateColumns="False"
								ShowFooter="True" AllowSorting="True" AllowPaging="True" GridLines="Vertical" CellPadding="1"
								BackColor="White" BorderWidth="1px" BorderColor="#DEDFDE">
								<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CE5D5A"></SelectedItemStyle>
								<AlternatingItemStyle BackColor="White"></AlternatingItemStyle>
								<ItemStyle BackColor="#F7F7DE"></ItemStyle>
								<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#6B696B"></HeaderStyle>
								<FooterStyle BackColor="#CCCC99"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="NONAS" HeaderText="NONAS"></asp:BoundColumn>
									<asp:BoundColumn DataField="NAMA" HeaderText="NAMA"></asp:BoundColumn>
									<asp:BoundColumn DataField="ALAMAT" HeaderText="ALAMAT"></asp:BoundColumn>
									<asp:BoundColumn DataField="IDENTITAS" HeaderText="IDENTITAS"></asp:BoundColumn>
									<asp:BoundColumn DataField="TGLAHIR" HeaderText="TGLAHIR"></asp:BoundColumn>
									<asp:BoundColumn DataField="LIMIT" HeaderText="LIMIT"></asp:BoundColumn>
									<asp:BoundColumn DataField="HARGABELI" HeaderText="HARGABELI"></asp:BoundColumn>
									<asp:BoundColumn DataField="SBUN" HeaderText="SBUN"></asp:BoundColumn>
									<asp:BoundColumn DataField="JW" HeaderText="JW"></asp:BoundColumn>
									<asp:BoundColumn DataField="JB" HeaderText="JB"></asp:BoundColumn>
									<asp:BoundColumn DataField="MERKB" HeaderText="MERKB"></asp:BoundColumn>
									<asp:BoundColumn DataField="TYPE" HeaderText="TYPE"></asp:BoundColumn>
									<asp:BoundColumn DataField="TAHUN" HeaderText="TAHUN"></asp:BoundColumn>
									<asp:BoundColumn DataField="NORANGKA" HeaderText="NORANGKA"></asp:BoundColumn>
									<asp:BoundColumn DataField="NOMESIN" HeaderText="NOMESIN"></asp:BoundColumn>
									<asp:BoundColumn DataField="NOPK" HeaderText="NOPK"></asp:BoundColumn>
									<asp:BoundColumn DataField="TGPK" HeaderText="TGPK"></asp:BoundColumn>
									<asp:BoundColumn DataField="JDOK" HeaderText="JDOK"></asp:BoundColumn>
									<asp:BoundColumn DataField="PENDAPATAN" HeaderText="PENDAPATAN"></asp:BoundColumn>
									<asp:BoundColumn DataField="JPTG" HeaderText="JPTG"></asp:BoundColumn>
									<asp:BoundColumn DataField="NPTG" HeaderText="NPTG"></asp:BoundColumn>
									<asp:BoundColumn DataField="KONA" HeaderText="KONA"></asp:BoundColumn>
									<asp:BoundColumn DataField="MKERJA" HeaderText="MKERJA"></asp:BoundColumn>
									<asp:BoundColumn DataField="TPGUNA" HeaderText="TPGUNA"></asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#F7F7DE" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
