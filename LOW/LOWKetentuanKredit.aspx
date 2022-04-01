<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocumentUpload.ascx" %>
<%@ Page language="c#" Codebehind="LOWKetentuanKredit.aspx.cs" AutoEventWireup="True" Inherits="SME.LOW.LOWKetentuanKredit" %>
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
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B><a name="Top">General</a> 
										Info</B></TD>
							</TR>
						</TABLE>
					</TD>
					<td align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg" Visible="False" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A>
					</td>
				</TR>
				<TR>
					<TD class="tdnoborder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
				</TR>
				<% } %>
				<TR>
					<TD class="tdheader1" colSpan="2"><FONT face="Arial" size="3">Sub Segment Program 
							Information</FONT></TD>
				</TR>
				<TR id="TR_1" runat="server">
					<TD colSpan="2">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD width="50%">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 150px">Unit</TD>
											<TD style="WIDTH: 15px; HEIGHT: 21px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox id="TXT_UNIT" runat="server" ReadOnly="True" Width="100%" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">CBI #</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_CBI" runat="server" ReadOnly="True" Width="100%" Enabled="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Sub Segment Program</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_SUB_SEGMENT" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="HEIGHT: 22px">RM / SRM Unit</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_RM_SRM_UNIT" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_RM_SRM_UNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">RM / SRM</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_RM_SRM" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="50%">
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 150px">No. Surat&nbsp;Nasabah / 
												Penawaran&nbsp;</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 21px"><asp:textbox id="TXT_NO_SURAT_NASABAH" runat="server" Width="100%" CssClass="mandatory"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Tanggal Surat</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><asp:textbox id="TXT_DD_TGLSURAT" runat="server" Width="24px" CssClass="mandatory" ToolTip="Tanggal Surat"></asp:textbox><asp:dropdownlist id="DDL_MM_TGL_SURAT" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_YY_TGL_SURAT" runat="server" Width="88px" CssClass="mandatory"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Tanggal Terima / Kirim</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_DD_TGL_TERIMA" runat="server" Width="24px" CssClass="mandatory"></asp:textbox><asp:dropdownlist id="DDL_MM_TGL_TERIMA" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox id="TXT_YY_TGL_TERIMA" runat="server" Width="88px" CssClass="mandatory"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Credit Operation Unit</TD>
											<TD>:</TD>
											<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CO_UNIT" runat="server" CssClass="mandatory"></asp:dropdownlist>&nbsp;</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><uc1:docupload id="DocUpload1" runat="server"></uc1:docupload></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_SAVE_SUBSEGMENT" runat="server" Width="100px" CssClass="Button1" Text="Save" onclick="BTN_SAVE_SUBSEGMENT_Click"></asp:button>&nbsp;<asp:button id="BTN_CLEAR_SUBSEGMENT" runat="server" Width="100px" CssClass="Button1" Text="Clear" onclick="BTN_CLEAR_SUBSEGMENT_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE class="td" id="TBL_DGR_SUB_SEGMENT" cellSpacing="1" cellPadding="1" width="100%"
							border="0">
							<TR>
								<TD class="tdheader1">List Existing Sub Segment Program</TD>
							</TR>
							<TR>
								<TD><ASP:DATAGRID id="DGR_SUB_SEGMENT" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
										PageSize="5">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="CBI" HeaderText="CBI#">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PROGRAMDESC" HeaderText="Sub Segment Program">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SEQ" HeaderText="Seq #">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DATE_" HeaderText="Seq. Date" DataFormatString="{0:00,00.00}">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="STATUS" HeaderText="Status">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="FUNCTION">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<ItemTemplate>
													<asp:LinkButton id="Linkbutton1" runat="server" CommandName="add">Add Product</asp:LinkButton>&nbsp;
													<asp:LinkButton id="Linkbutton2" runat="server" CommandName="view">View</asp:LinkButton>&nbsp;
													<asp:LinkButton id="Linkbutton3" runat="server" CommandName="delete">Delete</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Mode="NumericPages"></PagerStyle>
									</ASP:DATAGRID></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr id="TR_KETENTUAN" runat="server">
					<TD align="center" colSpan="2">
				<TR>
					<TD align="center" colSpan="2">
						<TABLE class="td" id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1">Ketentuan Kredit</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1">CBI#</TD>
											<TD>:</TD>
											<TD><asp:label id="LBL_KETENTUAN_CBI" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Seq</TD>
											<TD>:</TD>
											<TD><asp:label id="LBL_KETENTUAN_SEQ" runat="server"></asp:label></TD>
										</TR>
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
											<TD class="TDBGColor1">Channeling Company&nbsp;<BR>
												(for earmarking by facility)</TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_CHANNCOMP" runat="server" Enabled="False" AutoPostBack="True" onselectedindexchanged="DDL_CHANNCOMP_SelectedIndexChanged"></asp:dropdownlist>&nbsp;| 
												Remaining eMAS Limit (Rp) :
												<asp:label id="LBL_REMAINING_EMAS_LIMIT" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1"><asp:label id="AA_NO" runat="server">AA No.</asp:label></TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_AANO" runat="server" Enabled="False" AutoPostBack="True" onselectedindexchanged="DDL_AANO_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1"><asp:label id="Label1" runat="server">NCL Product.</asp:label></TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_NCLPROD" runat="server" Enabled="False" AutoPostBack="True" onselectedindexchanged="DDL_NCLPROD_SelectedIndexChanged"></asp:dropdownlist>&nbsp;Remaining 
												Limit :&nbsp;
												<asp:label id="LBL_REMAINING_NCL_LIMIT" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1"><asp:label id="LBL_FACILITY_CODE" runat="server">Facility</asp:label></TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_PRODUCTID" runat="server" Enabled="False" AutoPostBack="True" onselectedindexchanged="DDL_FACILITY_CODE_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_ACC_SEQ" runat="server" Enabled="False" AutoPostBack="True" onselectedindexchanged="DDL_ACC_SEQ_SelectedIndexChanged"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">No Rekening</TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_ACC_NO" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_ACC_NO_SelectedIndexChanged"></asp:dropdownlist><asp:label id="LBL_SEQ_TITLE" runat="server" Visible="False">Sequence</asp:label><asp:label id="LBL_ACC_NO" runat="server" Visible="False">No Rekening</asp:label><asp:label id="LBL_ACC_NOVAL" runat="server" Visible="False"></asp:label><asp:label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:label><asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Perihal/Jenis Permohonan</TD>
											<TD>:</TD>
											<TD><asp:textbox id="TXT_KETKREDIT_DESC" runat="server" Width="300px" CssClass="mandatory"></asp:textbox><asp:label id="LBL_KET_CODE" runat="server" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Project</TD>
											<TD>:</TD>
											<TD><asp:dropdownlist id="DDL_PRJ_CODE" runat="server"></asp:dropdownlist>&nbsp; <INPUT onclick="javascript:PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');"
													type="button" size="10" value="View Project List">&nbsp;(for earmarking by 
												project)</TD>
										</TR>
									</TABLE>
									<asp:label id="LBL_REGNO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" runat="server" Visible="False"></asp:label><asp:label id="LBL_USERID" runat="server" Visible="False"></asp:label><asp:button id="BTN_PROJECTLIST" runat="server" Visible="False" Text="View Project List (unused)"></asp:button></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2"><asp:button id="BTN_ADD" runat="server" Width="125px" CssClass="button1" Text="Add Ketentuan" onclick="BTN_ADD_Click"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" Width="140px" CssClass="button1"
										Text="Cancel Ketentuan" onclick="BTN_CANCEL_Click"></asp:button><asp:button id="BTN_CANCEL_ADD" runat="server" Visible="False" CssClass="Button1" Text="Cancel Add" onclick="BTN_CANCEL_ADD_Click"></asp:button></TD>
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
								<TD class="tdheader1">List Ketentuan Kredit</TD>
							</TR>
							<TR>
								<TD><ASP:DATAGRID id="DGR_KETENTUANKREDIT" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
										PageSize="5">
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
								<TD class="tdbgcolor2"><asp:button id="BTN_SAVE" runat="server" Width="180px" CssClass="button1" Text="Save Ketentuan Kredit" onclick="BTN_SAVE_Click"></asp:button>
									<% if (Request.QueryString["mainregno"] == "" || Request.QueryString["mainregno"] == null) { %>
									<asp:button id="BTN_UPDATE_STATUS" runat="server" Width="125px" Enabled="False" CssClass="button1"
										Text="Update Status" onclick="BTN_UPDATE_STATUS_Click"></asp:button>
									<% } %>
									<asp:listbox id="ListBox2" runat="server" Visible="False" Width="10px" Height="25px"></asp:listbox></TD>
							</TR>
						</TABLE>
						<P><asp:label id="LBL_AP_REGNO" runat="server">Label</asp:label><asp:label id="LBL_CU_REF" runat="server">Label</asp:label><asp:label id="LBL_AP_SIGNDATE" runat="server">Label</asp:label><asp:label id="LBL_PROGRAMDESC" runat="server">Label</asp:label><asp:label id="LBL_BRANCH_NAME" runat="server">Label</asp:label><asp:label id="LBL_CHANNEL_DESC" runat="server">Label</asp:label><asp:label id="LBL_AP_SRCCODE" runat="server">Label</asp:label><asp:label id="LBL_AP_SALESAGENCY" runat="server">Label</asp:label><asp:label id="LBL_PROG_CODE" runat="server"></asp:label></P>
					</TD>
				</TR>
				</TD></tr></TR></TABLE>
		</form>
	</body>
</HTML>
