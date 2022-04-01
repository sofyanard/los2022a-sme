<%@ Page language="c#" Codebehind="DetailLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.NotaryAssignment.DetailLegalSigning_Data" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetailLegalSigning_Data</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_entries.html" -->
		<!-- #include file = "../../include/onepost.html" -->
		<!-- #include file = "../../include/ConfirmBox.html" -->
		<!-- #include  file="../../include/popup.html" -->
        <%= popUp%>
		<script language="javascript">
			/***
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
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Detail Legal Signing</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">Info Pemohon</td>
					</tr>
					<tr>
						<td colSpan="2">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" style="HEIGHT: 6px" width="150">No. Application</td>
												<td style="HEIGHT: 6px" width="15"></td>
												<td class="TDBGColorValue" style="HEIGHT: 6px"><asp:textbox id="TXT_AP_REGNO" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Referensi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Aplikasi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Sub-Segment/Program</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Supervisi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_TMLDRNM" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Analis</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Segmen</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BU_DESC" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Pemohon</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" vAlign="top">Alamat</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Width="297px" ReadOnly Runat="server"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR2" Width="297px" ReadOnly Runat="server"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR3" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Telp</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Bidang Usaha</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Width="297px" ReadOnly Runat="server"></asp:textbox></td>
											</tr>
										</TABLE>
										<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label></td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">Asuransi Jiwa</td>
					</tr>
					<tr>
						<td colSpan="2"><asp:datagrid id="DataGrid1" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="3" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRCOMPDESC" HeaderText="Nama Perusahaan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSRTYPEDESC" HeaderText="Insurance Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_POLICYNO" HeaderText="No Polis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_CUR" HeaderText="Mata Uang">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_VALUE" HeaderText="Nilai Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATESTART" HeaderText="Tanggal Mulai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_DATEEND" HeaderText="Tanggal Akhir">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_PERCENTAGE" HeaderText="% Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AN_PREMI" HeaderText="Premi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IC_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="IT_ID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="RATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CUR_ID"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="BTNEDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNDEL" runat="server" CommandName="delete">Delete</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNLNK_PRINT" runat="server" CommandName="print">Print</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<TABLE id="TBL_ENTRY" cellSpacing="2" cellPadding="2" width="100%" runat="server">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Perusahaan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_INSRCOMP" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_AP_INSRCOMP_SelectedIndexChanged"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Rating</td>
												<td></td>
												<td class="TDBGColorValue"><asp:dropdownlist id="DDL_ICRATE" Runat="server"></asp:dropdownlist></td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Jenis Asuransi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_INSRTYPE" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">No. Polis</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_POLICYNO" Runat="server" MaxLength="20"
														Columns="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Mata Uang</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_CUR" runat="server"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</td>
									<TD class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nilai Pertanggungan</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_INSRAMNT" Runat="server" MaxLength="20"
														Columns="25" CssClass="angka"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal mulai</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_DAY" Runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_DATESTART_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATESTART_YEAR" Runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="150">Tanggal akhir</TD>
												<TD width="15"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_DAY" Runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_DATEEND_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_DATEEND_YEAR" Runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">% Pertanggungan</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_INSRPCT" Runat="server" MaxLength="4"
														Columns="4" CssClass="angkamandatory"></asp:textbox>%</TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Premi</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_INSRPREMI" Runat="server" MaxLength="20"
														ColumnsCssClass="angka"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</tr>
								<TR>
									<TD class="td" align="center" colSpan="2"><asp:button id="BTN_TAMBAH" runat="server" Text="Tambah" width="75px" cssclass="button1" onclick="BTN_TAMBAH_Click"></asp:button><asp:label id="LBL_H_SEQ" Runat="server" Visible="False">0</asp:label>
                                        <asp:button id="BTN_CANCEL" runat="server" Visible="False" Text="Batal" 
                                            width="75px" cssclass="button1" onclick="BTN_CANCEL_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">Fasilitas</td>
					</tr>
					<tr>
						<td colSpan="2"><asp:datagrid id="Datagrid2" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
								PageSize="20">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ"></asp:BoundColumn>
									<asp:BoundColumn DataField="FACILITY" HeaderText="Fasilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Fungsi">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:radiobuttonlist id="RBL_FAC" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Lanjut</asp:ListItem>
												<asp:ListItem Value="0">Tunda</asp:ListItem>
											</asp:radiobuttonlist>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="CP_CONFIRMBOOK"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ALLOWCHG"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2">
							<%if((Request.QueryString["na"] != "0") && (Request.QueryString["na"] != "2")) {%>
							<asp:button id="BTN_UPDATE" Runat="server" CssClass="button1" Text="Update Status" onclick="BTN_UPDATE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_RETURNTOBU" Runat="server" CssClass="button1" 
                                Text="Kembali ke Konfirmasi" onclick="BTN_RETURNTOBU_Click"></asp:button>
							<%}%>
							<asp:textbox id="TXT_TEMP" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
