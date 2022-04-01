<%@ Page language="c#" Codebehind="KetentuanKredit.aspx.cs" AutoEventWireup="True" Inherits="ketentuankredit.loan.KetentuanKredit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>KetentuanKredit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<script language="javascript">
			/**
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
			}***/
			
			function konfirHapus()
			{
				alert("Kredit tidak bisa dihapus karena aplikasi akan tidak memiliki kredit !");
				return false;
				
				/**
				conf = confirm("Aplikasi tidak punya ketentuan kredit. Reject aplikasi ?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}**/
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
                <% if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
				<TR>
					<TD>
						<TABLE id="Table2">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><a name="Top">Ketentuan 
											Kredit</a></B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><asp:imagebutton id="BTN_BACK" runat="server" Visible="False" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
					</td>
				</TR>
				<TR>
					<TD class="tdnoborder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
                <% } %>
				<TR>
					<TD class="tdheader1" colSpan="2">Informasi Umum</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD>
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_AP_REGNO" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">No. Referensi</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CU_REF" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Tanggal Aplikasi</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_AP_SIGNDATE" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Program</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_PROGRAMDESC" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Unit</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_BRANCH_NAME" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Supervisi</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:label id="LBL_AP_TEAMLEADER" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Analis</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:label id="LBL_AP_RELMNGR" runat="server"></asp:label></TD>
										</TR> <!-- Additional Field : Right --></TABLE>
								</TD>
								<TD>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 21px" width="150">Segmen</TD>
											<TD style="WIDTH: 15px; HEIGHT: 21px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:label id="LBL_GR_BUSINESSUNIT" runat="server"></asp:label><asp:label id="Label2" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Channels</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CHANNEL_DESC" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Agen Pemasaran</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:label id="LBL_AP_SALESAGENCY" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Kode Sumber</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:label id="LBL_AP_SRCCODE" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR> <!-- 14 --> <!-- 21 --> <!-- Additional Field : Right --></TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1"></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1">Permohonan Baru</TD>
											<TD>:</TD>
											<TD><asp:radiobuttonlist id="RDO_PBARU" runat="server" AutoPostBack="True" RepeatLayout="Flow" onselectedindexchanged="RDO_PBARU_SelectedIndexChanged_1">
													<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
													<asp:ListItem Value="0">Tidak (ketentuan lama dan penarikan fas sendiri)</asp:ListItem>
													<asp:ListItem Value="2">Withdrawal (penarikan dari fasilitas induk)</asp:ListItem>
													<asp:ListItem Value="3">Past Due NCL</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Perusahaan Channeling&nbsp;<BR>
												(for earmarking by facility)</TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_CHANNCOMP" runat="server" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_CHANNCOMP_SelectedIndexChanged"></asp:dropdownlist>&nbsp;| 
												Remaining Core System Limit (Rp) :
												<asp:label id="LBL_REMAINING_EMAS_LIMIT" runat="server"></asp:label></TD>
										</TR>
                                        <TR>
											<TD class="TDBGColor1">Nasabah Ambil Alih Bank Lain</TD>
											<TD>:</TD>
											<TD>
                                                <asp:CheckBox ID="CB_IsTakeOver" runat="server" />
                                            </TD>
										</TR>
										<TR>
											<TD class="TDBGColor1"><asp:label id="AA_NO" runat="server">No. Akomodasi Rekening</asp:label></TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_AANO" runat="server" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_AANO_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Produk NCL</TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_NCLPROD" runat="server" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_NCLPROD_SelectedIndexChanged"></asp:dropdownlist>&nbsp;Remaining 
												Limit :&nbsp;
												<asp:label id="LBL_REMAINING_NCL_LIMIT" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1"><asp:label id="LBL_FACILITY_CODE" runat="server">Fasilitas</asp:label></TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_PRODUCTID" runat="server" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_FACILITY_CODE_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_ACC_SEQ" runat="server" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_ACC_SEQ_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">No Rekening</TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_ACC_NO" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_ACC_NO_SelectedIndexChanged"></asp:dropdownlist><asp:label id="LBL_SEQ_TITLE" runat="server" Visible="False">Sequence</asp:label><asp:label id="LBL_ACC_NO" runat="server" Visible="False">No Rekening</asp:label><asp:label id="LBL_ACC_NOVAL" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Perihal/Jenis Permohonan</TD>
											<TD>:</TD>
											<TD><asp:textbox id="TXT_KETKREDIT_DESC" runat="server" CssClass="mandatory" Width="300px"></asp:textbox><asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Proyek</TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_PRJ_CODE" runat="server"></asp:dropdownlist>&nbsp; <INPUT onclick="javascript:PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');"
													type="button" size="10" value="View Project List">&nbsp;(for earmarking by 
												project)</TD>
										</TR>
									</TABLE>
									<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label>
                                    <asp:button id="BTN_PROJECTLIST" runat="server" Visible="False" 
                                        Text="Lihat Daftar Proyek (unused)"></asp:button></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2">
                                    <asp:button id="BTN_ADD" runat="server" CssClass="button1" 
                                        Width="175px" Text="Tambah Ketentuan" onclick="BTN_ADD_Click"></asp:button>
                                    <asp:button id="BTN_CANCEL" runat="server" Visible="False" CssClass="button1" Width="140px"
										Text="Batal Ketentuan" onclick="BTN_CANCEL_Click"></asp:button>
                                    <asp:button id="BTN_CANCEL_ADD" runat="server" Visible="False" 
                                        CssClass="Button1" Text="Batal Tambah" onclick="BTN_CANCEL_ADD_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE class="TD" id="TBL_DETAIL" cellSpacing="1" cellPadding="1" width="100%" border="0"
							runat="server">
							<TR>
								<TD>
									<TABLE id="TBL_TITLE" style="WIDTH: 368px; HEIGHT: 23px" cellSpacing="1" cellPadding="1"
										width="368" border="0" runat="server">
										<TR>
											<TD class="tdbgcolor1" style="WIDTH: 123px">Ketentuan Kredit</TD>
											<TD>:</TD>
											<TD><asp:label id="LBL_KETENTUAN_KREDIT" runat="server" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><IFRAME id="creddetail" name="credit" src="" frameBorder="0" width="100%" height="600" runat="server"></IFRAME>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">Daftar Ketentuan Kredit</TD>
							</TR>
							<TR>
								<TD><ASP:DATAGRID id="DGR_KETENTUANKREDIT" runat="server" Width="100%" PageSize="5" AutoGenerateColumns="False"
										AllowPaging="True">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="KET_CODE" HeaderText="KET_CODE">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="KET_DESC" HeaderText="Deskripsi Ketentuan">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AA_NO" HeaderText="AA No.">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ACC_NO" HeaderText="No Rek">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EARMARK_AMOUNT_PRJ" HeaderText="Earmark Amount (Prj)" DataFormatString="{0:00,00.00}">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="Function">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="LNK_ADD" runat="server" CommandName="add">Add Product</asp:LinkButton>&nbsp;
													<asp:LinkButton id="LNK_VIEW" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
													<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2">
                                    <asp:button id="BTN_SAVE" runat="server" Enabled="False" 
                                        CssClass="button1" Width="200px" Text="Simpan Ketentuan Kredit" 
                                        onclick="BTN_SAVE_Click"></asp:button>
                                    <% if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
									<asp:button id="BTN_UPDATE_STATUS" runat="server" Enabled="False" CssClass="button1" Width="125px"
										Text="Update Status" onclick="BTN_UPDATE_STATUS_Click"></asp:button>
                                    <% } %>
									<asp:listbox id="ListBox2" runat="server" Visible="False" Width="10px" Height="25px"></asp:listbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
