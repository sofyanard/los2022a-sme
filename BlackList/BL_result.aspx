<%@ Page language="c#" Codebehind="BL_result.aspx.cs" AutoEventWireup="True" Inherits="SME.BlackList.BL_result" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/SME/style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="20" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="2" cellPadding="2" width="100%">
				<%if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="Table1">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Black List</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" Visible="False" onclick="BTN_BACK_Click"></asp:imagebutton><A href="/SME/Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="/SME/Image/logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<% } %>
				<TR>
					<TD class="tdHeader1" colSpan="2">Informasi Umum</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Application No.</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Reference No.</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">ID&nbsp;No.</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_KTPNO" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Tgl Lahir/Tgl berdiri</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_TGLLAHIR" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px" vAlign="top">Product</TD>
								<TD style="WIDTH: 15px" vAlign="top">:</TD>
								<TD class="TDBGColorValue"></TD>
							</TR>
						</TABLE>
						<asp:listbox id="LST_PRODUCT" runat="server" Width="450px" Rows="6"></asp:listbox></TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" width="150">Name</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="150">Address
								</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"
										Rows="4" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="HEIGHT: 21px" width="150">City</TD>
								<TD style="WIDTH: 15px; HEIGHT: 21px">:</TD>
								<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox id="TXT_CITY" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="150">Phone Number</TD>
								<TD style="WIDTH: 15px">:</TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_PHNNO" runat="server" BorderStyle="None" ReadOnly="True" Width="300px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" width="150" colSpan="3">Pengurus</TD>
							</TR>
							<TR>
								<TD class="TDBGColorValue" align="center" width="150" colSpan="3"><asp:listbox id="LST_PENGURUS" runat="server" Width="368px"></asp:listbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<%if (Request.QueryString["bl"] != "0"){%>
				<TR>
					<TD class="td" align="center" colSpan="2"><asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label>
                        <asp:button class="button1" id="Button1" runat="server" Width="100px" 
                            Text="Proses" onclick="Button1_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" align="center" colSpan="2">Hasil Duplikasi
					</TD>
				</TR>
				<TR>
					<TD class="td" colSpan="2"><asp:datagrid id="DataGrid2" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="5"
							CellPadding="1">
							<Columns>
								<asp:BoundColumn DataField="regno" HeaderText="Application Number">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="Tgl Applikasi" DataFormatString="{0:dd-MMM-yyy}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NAME" HeaderText="Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ADDR" HeaderText="Address">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TGL" HeaderText="Tgl Lahir/ Tgl Berdiri" DataFormatString="{0:dd-MMM-yyyy}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TLP" HeaderText="Telepon">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IDTYPE" HeaderText="ID Type">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CARDNO" HeaderText="ID Number">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="product" HeaderText="Product">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="KET_DESC" HeaderText="Ketentuan Kredit">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TRACKNAME" HeaderText="Status Applikasi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="view">
									<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="cu_ref" HeaderText="cusproduct"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:datagrid id="Datagrid3" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
							CellPadding="1">
							<Columns>
								<asp:BoundColumn DataField="NAME" HeaderText="Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ADDR" HeaderText="Address">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TGL" HeaderText="Tanggal Lahir" DataFormatString="{0:dd-MMM-yyyy}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TLP" HeaderText="Telepon">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CARDNO" HeaderText="ID Number">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TRACKNAME" HeaderText="Posisi">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:label id="Label2" runat="server" Visible="False">Not Duplicate</asp:label></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" align="center" colSpan="2">Hasil BlackList</TD>
				</TR>
				<TR>
					<TD class="td" align="center" colSpan="2"><asp:dropdownlist id="DDL_BLKRITERIA" runat="server"></asp:dropdownlist><asp:dropdownlist id="DDL_BLKRITERIAVALUE" runat="server"></asp:dropdownlist>
                        <asp:button id="BTN_PROSES_BL" runat="server" Width="100px" Text="Proses" 
                            CssClass="button1" onclick="BTN_PROSES_BL_Click"></asp:button><asp:datagrid id="DataGrid1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="5"
							CellPadding="1" onselectedindexchanged="DataGrid1_SelectedIndexChanged">
							<Columns>
								<asp:BoundColumn DataField="NAME" HeaderText="Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ADDR" HeaderText="Address">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="idtype" HeaderText="ID Type">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="idno" HeaderText="ID Number">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SR" HeaderText="Source">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RR" HeaderText="Reason">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="EXP" HeaderText="Expired Date" DataFormatString="{0:dd-MMM-yyyy}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:label id="Label1" runat="server" Visible="False">Not Blacklist</asp:label></TD>
				</TR>
				<%}%>
				<TR>
					<TD class="tdHeader1" align="left" colSpan="2">Input Hasil BlackList</TD>
				</TR>
				<TR>
					<TD class="td" align="left" colSpan="2">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 358px">Pemilik Tercatat sebagai Daftar Hitam 
									di Bank</TD>
								<TD style="WIDTH: 5px"></TD>
								<TD><asp:radiobuttonlist id="RDO_BM_BL_PEMILIK" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="1">Ya</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 358px">Manajemen&nbsp;Tercatat sebagai Daftar 
									Hitam di Bank</TD>
								<TD style="WIDTH: 5px"></TD>
								<TD><asp:radiobuttonlist id="RDO_BM_BL_MGMT" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="1">Ya</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 358px">Perusahaan Tercatat sebagai Daftar 
									Hitam di Bank</TD>
								<TD style="WIDTH: 5px"></TD>
								<TD><asp:radiobuttonlist id="RDO_BM_BL_PERUSAHAAN" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="1">Ya</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 358px">Perusahaan Tercatat sebagai Daftar 
									Hitam di BI</TD>
								<TD style="WIDTH: 5px"></TD>
								<TD><asp:radiobuttonlist id="RDO_BI_BL_PERUSAHAAN" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="1">Ya</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 358px">Manajemen Tercatat sebagai Daftar Hitam 
									di BI</TD>
								<TD style="WIDTH: 5px"></TD>
								<TD><asp:radiobuttonlist id="RDO_BI_BL_MGMT" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="1">Ya</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 358px">Pemilik Tercatat sebagai Daftar Hitam 
									di BI</TD>
								<TD style="WIDTH: 5px"></TD>
								<TD><asp:radiobuttonlist id="RDO_BI_BL_PEMILIK" runat="server" Width="150px" RepeatDirection="Horizontal">
										<asp:ListItem Value="1">Ya</asp:ListItem>
										<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
									</asp:radiobuttonlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="td" align="left" colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:radiobuttonlist id="RDO_BM_BL_PERNAH" runat="server" Visible="False" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">Ya</asp:ListItem>
							<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
						</asp:radiobuttonlist><asp:radiobuttonlist id="RDO_BI_BL_PERNAH" runat="server" Visible="False" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">Ya</asp:ListItem>
							<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" align="center" colSpan="2">Catatan</TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_MEMO" runat="server" Width="100%" Height="104px"></asp:textbox></TD>
				</TR>
				<%if (Request.QueryString["bl"] != "0"){%>
				<TR>
					<TD align="center" colSpan="2"><asp:button id="BTN_SAVE" runat="server" 
                            Text="Simpan" CssClass="BUTTON1" onclick="BTN_SAVE_Click"></asp:button>
                        <asp:button id="Button2" runat="server" Width="150px" Text="Lanjut" 
                            CssClass="button1" onclick="Button2_Click"></asp:button>
						<% if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
						<asp:button id="Button3" runat="server" Text="Tolak" CssClass="button1" 
                            onclick="Button3_Click"></asp:button>
						<% } %>
					</TD>
				</TR>
				<%}%>
			</TABLE>
		</form>
	</body>
</HTML>
