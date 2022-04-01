<%@ Page language="c#" Codebehind="BICheckingResultEntryCBI.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.BIChecking.BICheckingResultEntryCBI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BICheckingEntry</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_entries.html" -->
		<!-- #include file = "../../include/cek_mandatory.html" -->
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
			
			function cek_mandatory3(frm, alamat)
			{
				max_elm = (frm.elements.length) - 2;
				lanjut = true;
				for (var i=1; i<=max_elm; i++)
				{
					elm = frm.elements[i];
					nm_kolom = "kotak";
					if (elm.className == "mandatory3" && (elm.value == "" || elm.value == "0,00") && (elm.type == "text" || elm.type == "select-one"))
					{
						r = elm.parentElement.parentElement;
						d = r.cells(0).innerText;
						alert(d + " tidak boleh kosong...");
						lanjut = false;
						elm.focus();
						return false;
					}
				}
				if (lanjut)
				{

					if (alamat != undefined && alamat != "" )
						frm.action = alamat;

					return true;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
								<TABLE id="Table3">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>BI Checking Result Entry</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="../../Image/MainMenu.jpg"></A>
								<A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">BI CHECKING RESULT ENTRY</TD>
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
													<td class="TDBGColor1" width="150">Application No.</td>
													<td width="15"></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" Columns="35" ReadOnly Runat="server"></asp:textbox><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Reference No.</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Tanggal Aplikasi</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Sub-Segment/Program</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Unit</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Team Leader</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_AP_TMLDRNM" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">RM / SBO</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Business Unit</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_BU_DESC" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
											</TABLE>
										</td>
										<td class="td" vAlign="top">
											<TABLE cellSpacing="0" cellPadding="0" width="100%">
												<tr>
													<td class="TDBGColor1" width="150">Nama Pemohon</td>
													<td width="15"></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1" vAlign="top">Alamat</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Columns="35" ReadOnly Runat="server"></asp:textbox><br>
														<asp:textbox id="TXT_CU_ADDR2" Columns="35" ReadOnly Runat="server"></asp:textbox><br>
														<asp:textbox id="TXT_CU_ADDR3" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Kota</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">No. Telp</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<tr>
													<td class="TDBGColor1">Bidang Usaha</td>
													<td></td>
													<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Columns="35" ReadOnly Runat="server"></asp:textbox></td>
												</tr>
												<TR style="DISPLAY: none">
													<TD class="TDBGColor1">Data Available</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:checkbox id="CHK_BS_BIDATAAVAIL" runat="server"></asp:checkbox></TD>
												</TR> <!-- Additional Field : Right --></TABLE>
										</td>
									</tr>
								</TABLE>
							</td>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">BlackList Info</TD>
						</TR>
						<TR>
							<TD colSpan="2">
								<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="50%" border="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px">Perusahaan Tercatat dalam Daftar Hitam 
											di BI</TD>
										<TD><asp:radiobuttonlist id="RDO_AP_BLBIUSAHA" runat="server" RepeatDirection="Horizontal" Width="150px">
												<asp:ListItem Value="1">Ya</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px">Key Person Tercatat dalam Daftar Hitam 
											di BI</TD>
										<TD><asp:radiobuttonlist id="RDO_AP_BLBIMGMT" runat="server" RepeatDirection="Horizontal" Width="150px">
												<asp:ListItem Value="1">Ya</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px">Pemilik Tercatat dalam Daftar Hitam di 
											BI</TD>
										<TD><asp:radiobuttonlist id="RDO_AP_BLBIPEMILIK" runat="server" RepeatDirection="Horizontal" Width="150px">
												<asp:ListItem Value="1">Ya</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px; HEIGHT: 13px">Kolektibilitas perusahaan 
											saat ini di bank lain (IDI BI)
										</TD>
										<TD style="HEIGHT: 13px"><asp:dropdownlist id="DDL_ACCBK" runat="server" Width="136px" CssClass="mandatory3"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px; HEIGHT: 13px">Kolektibilitas perusahaan 
											12 bulan terakhir di bank lain (IDI BI)
										</TD>
										<TD style="HEIGHT: 13px"><asp:dropdownlist id="DDL_ACCBK12BLN" runat="server" Width="136px" CssClass="mandatory3"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px">Kolektibilitas pemilik saat ini di bank 
											lain (IDI BI)</TD>
										<TD><asp:dropdownlist id="DDL_OCBK" runat="server" Width="136px" CssClass="mandatory3"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px">Kolektibilitas pemilik 12 bulan 
											terakhir di bank lain (IDI BI)</TD>
										<TD><asp:dropdownlist id="DDL_OCBK12BLN" runat="server" Width="136px" CssClass="mandatory3"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px">Kolektibilitas Key Person saat ini di 
											bank lain (IDI BI)</TD>
										<TD><asp:dropdownlist id="DDL_MCBKS" runat="server" Width="136px" CssClass="mandatory3"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 366px">Kolektibilitas Key Person 12 bulan 
											terakhir di bank lain (IDI BI)</TD>
										<TD><asp:dropdownlist id="DDL_MCBKS12BLN" runat="server" Width="136px" CssClass="mandatory3"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD colSpan="2"><asp:radiobuttonlist id="RDO_AP_BLBIPERNAH" runat="server" RepeatDirection="Horizontal" Width="150px"
									Visible="False">
									<asp:ListItem Value="1">Ya</asp:ListItem>
									<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
								</asp:radiobuttonlist>
								<asp:Label id="Label1" runat="server" Visible="False">[dulu Y/N ini untuk Nasabah BL di BI]</asp:Label></TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" colSpan="2"><asp:button id="BTN_UPDATE_BI" runat="server" Text="Update BI" CssClass="Button1" onclick="BTN_UPDATE_BI_Click"></asp:button></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">Data Kredit</TD>
						</TR>
						<%if (Request.QueryString["bi"] != "0") { %>
						<TR id="TR_DATAKREDIT">
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
									<tr>
										<td>
											<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1">Nama</TD>
													<TD>&nbsp;</TD>
													<TD class="TDBGColorValue" style="HEIGHT: 13px"><asp:dropdownlist id="DDL_NAMA" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_NAMA_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_H_ALAMAT" runat="server" Visible="False"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Alamat</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT" runat="server" ReadOnly="True" Width="200px" Rows="4" TextMode="MultiLine"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Bank</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BANKID" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Jenis Kredit</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRP_CREDTYPE" runat="server" Width="200px"
															CssClass="mandatory" MaxLength="30"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Rekening</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_BRP_REKENING" runat="server" Width="200px"
															MaxLength="13" CssClass="]["></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
										<td>
											<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1">Mata Uang</TD>
													<TD>&nbsp;</TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CUR_ID" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Limit</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_BRP_LIMIT" onblur="FormatCurrency(this)"
															runat="server" CssClass="mandatory" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Baki Debet</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_BRP_BAKIDEBET" onblur="FormatCurrency(this)"
															runat="server" CssClass="mandatory" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tunggakan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_BRP_TUNGGAKAN" onblur="FormatCurrency(this)"
															runat="server" CssClass="mandatory" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Sifat Kredit</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRP_SIFATKREDIT" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
										<td>
											<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1">Jenis Penggunaan</TD>
													<TD>&nbsp;</TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRP_JENISGUNA" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tanggal PK</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_BRP_TANGGALPK_DAY" runat="server" Columns="4"
															Width="24px" CssClass="mandatory" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BRP_TANGGALPK_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_BRP_TANGGALPK_YEAR" runat="server" Columns="4"
															Width="36px" CssClass="mandatory" MaxLength="4"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Jangka Waktu</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRP_JANGKAWAKTU" runat="server" CssClass="mandatory"
															MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Kolek</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_COLLECTID" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Jaminan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRP_JAMINAN" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:label id="LBL_H_SHSEQ" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE" runat="server" Text="Save" CssClass="Button1" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
								<asp:button id="BTN_CANCEL" runat="server" Text="Cancel" CssClass="Button1" onclick="BTN_CANCEL_Click"></asp:button><asp:label id="LBL_H_ACCSEQ" runat="server" Visible="False"></asp:label></TD>
						</TR>
						<% } %>
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="CS_SEQ"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="BR_SEQ"></asp:BoundColumn>
										<asp:BoundColumn DataField="NAME" HeaderText="Nama">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ALAMAT" HeaderText="Alamat">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BANKNAME" HeaderText="Bank">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CREDTYPE" HeaderText="Jenis Kredit ">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REKENING" HeaderText="Rekening">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CUR_DESC" HeaderText="Mata Uang">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LIMIT" HeaderText="Limit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BAKIDEBET" HeaderText="Baki Debet">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TUNGGAKAN" HeaderText="Tunggakan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="SIFATKREDIT" HeaderText="Sifat Kredit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="JENISGUNA" HeaderText="Jenis Penggunaan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TANGGALPK" HeaderText="Tanggal PK">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="JANGKAWAKTU" HeaderText="Jangka Waktu">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="COLLECTDESC" HeaderText="Kolek">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="JAMINAN" HeaderText="Jaminan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="BANKID"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="COLLECTID"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="CUR_ID"></asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
												<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">DATA AGUNAN</TD>
						</TR>
						<%if (Request.QueryString["bi"] != "0") { %>
						<TR id="TR_DATAJAMINAN">
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2">
								<TABLE id="Table12" cellSpacing="0" cellPadding="0" width="100%">
									<tr>
										<td>
											<TABLE id="Table17" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1">Nama</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_NAMA2" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_NAMA2_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_H_ALAMAT2" runat="server" Visible="False"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Alamat</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT2" runat="server" ReadOnly="True" Width="200px" Rows="4" TextMode="MultiLine"
															MaxLength="30"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Jenis Agunan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRC_JENISAGUNAN" runat="server" Width="200px"
															CssClass="mandatory" MaxLength="30"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Ukuran</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRC_UKURAN" runat="server" Width="200px"
															MaxLength="30"></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
										<td>
											<TABLE id="Table18" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1">Lokasi</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRC_LOKASI" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No Bukti Pemilikan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRC_BUKTIPEMILIKAN" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tanggal Bukti</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_BRC_TANGGALBUKTI_DAY" runat="server" Columns="4"
															Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BRC_TANGGALBUKTI_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_BRC_TANGGALBUKTI_YEAR" runat="server"
															Columns="4" Width="36px" MaxLength="4"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Pengikatan</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRC_PENGIKATAN" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
										<td>
											<TABLE id="Table19" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD class="TDBGColor1">Mata Uang</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CUR_ID2" runat="server"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Nilai Taksasi</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_BRC_NILAITAKSASI" onblur="FormatCurrency(this)"
															runat="server" MaxLength="20"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">Tanggal Penilaian</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_BRC_TANGGALPENILAIAN_DAY" runat="server"
															Columns="4" Width="24px" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_BRC_TANGGALPENILAIAN_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_BRC_TANGGALPENILAIAN_YEAR" runat="server"
															Columns="4" Width="36px" MaxLength="4"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No Referensi</TD>
													<TD></TD>
													<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_BRC_REF" runat="server" MaxLength="30"></asp:textbox></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:label id="LBL_H_SHSEQ2" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE2" runat="server" Text="Save" CssClass="Button1" onclick="BTN_SAVE2_Click"></asp:button>&nbsp;
								<asp:button id="BTN_CANCEL2" runat="server" Text="Cancel" CssClass="Button1" onclick="BTN_CANCEL2_Click"></asp:button><asp:label id="LBL_H_ACCSEQ2" runat="server" Visible="False"></asp:label></TD>
						</TR>
						<% } %>
						<!-- <TR>
							<TD class="TDBGColor1">Reg-No :</TD>
							<TD style="HEIGHT: 13px"><asp:dropdownlist id="DDL_REG_NO" runat="server" Width="250px" CssClass="mandatory3"></asp:dropdownlist></TD>
						</TR> -->
						<TR>
							<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="Datagrid2" runat="server" AutoGenerateColumns="False" AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="CS_SEQ"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="BR_SEQ"></asp:BoundColumn>
										<asp:BoundColumn DataField="NAME" HeaderText="Nama">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ALAMAT" HeaderText="Alamat">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="JENISAGUNAN" HeaderText="Jenis Agunan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="UKURAN" HeaderText="Ukuran">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LOKASI" HeaderText="Lokasi">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BUKTIPEMILIKAN" HeaderText="No Bukti">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TANGGALBUKTI" HeaderText="Tanggal Bukti">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="PENGIKATAN" HeaderText="Pengikatan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CUR_DESC" HeaderText="Mata Uang">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="NILAITAKSASI" HeaderText="Nilai Taksasi">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TANGGALPENILAIAN" HeaderText="Tanggal Penilaian">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="REF" HeaderText="No. Ref">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="CUR_ID"></asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="Linkbutton1" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
												<asp:LinkButton id="Linkbutton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:datagrid></TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
								<%if (Request.QueryString["bi"] != "0" && Request.QueryString["bi"] != "2") { %>
								<asp:button id="BTN_UPDATESTATUS" runat="server" Text="Update Status" CssClass="Button1" onclick="BTN_UPDATESTATUS_Click"></asp:button>
								<%}%>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
