<%@ Page language="c#" Codebehind="Main.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditProposal.Main" %>
<%@ Register src="../CommonForm/DocumentExport.ascx" tagname="DocumentExport" tagprefix="uc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Credit Proposal</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/exportpost.html" -->
        <%= popUp%>
		<script language="javascript">		
		function confirmFwd()
		{
			conf = confirm("Apakah Anda yakin ingin forward ke approval?\nPastikan Anda sudah mencetak hasil scoring.");
			if (conf)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		function updateMsgF()
		{
			msg = "1. Penentuan kategori pemutus kredit agar memperhatikan limit kredit one obligor, security coverage agunan,";
			msg = msg + "\n   jenis permohonan kredit (baru, perpanjangan, tambahan), dan hasil rating/scoring.";
			msg = msg + "\n2. Agar review fasilitas dilengkapi dengan kesimpulan apakah terdapat posisi pincang atau tidak.";
			msg = msg + "\n3. Agar review covenant (untuk debitur existing) dilengkapi dengan penjelasan apakah covenant telah dipenuhi ";
			msg = msg + "\n   atau belum dipenuhi, serta diberikan penjelasan penyebabnya dan bagaimana tindak lanjutnya.";
			msg = msg + "\n4. Agar review kolektibilitas dilengkapi dengan penjelasan 3 pilar Bank Indonesia untuk kredit > Rp. 10 Milyar,";
			msg = msg + "\n   serta dicantumkan dasar penetapan kolektibilitas sesuai PBI, SPK, limit kredit dan realisasi pembayaran.";
			conf = confirm(msg);
			if (conf)
			{
				conf2 = confirm("Apakah Anda yakin ingin forward ke approval?");
				if (conf2)
				{
					return true;		
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		
		// Fungsi ini sebenarnya sudah ada di include/cek_entries.html
		// tapi dipisah karena kalau pake #include file, mekanisme protection-screen jadi bermasalah
		function kutip_satu()
			{
				if ((event.keyCode == 35) || (event.keyCode == 39))
				{
					return false;
				} else
				{
					return true;
				}	
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder" style="WIDTH: 539px"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Credit Proposal Info</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Umum</TD>
					</TR>
					<TR>
						<TD class="td" style="WIDTH: 540px" vAlign="top" width="540"><TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Aplikasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" BorderStyle="None" Width="150px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Referensi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" BorderStyle="None" Width="150px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Aplikasi</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" runat="server" BorderStyle="None" Width="150px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Sub-Segment/Program</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Unit</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Supervisi</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_TL" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Analis</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AP_RELMNGR" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR> <!-- Additional Field : Right --></TABLE>
							<asp:label id="LBL_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label></TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="150">Nama Pemohon</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAME" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Alamat</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ADDRESS1" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 11px">&nbsp;</TD>
									<TD style="HEIGHT: 11px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 11px"><asp:textbox id="TXT_ADDRESS2" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;</TD>
									<TD><asp:textbox id="TXT_VERIFY" runat="server" BorderStyle="None" Width="1px" ontextchanged="TXT_VERIFY_TextChanged"></asp:textbox></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_ADDRESS3" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kota</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CITY" runat="server" BorderStyle="None" Width="175px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">No. Telepon</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PHONENUM" runat="server" BorderStyle="None" Width="175px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Bidang Usaha</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_BUSINESSTYPE" runat="server" BorderStyle="None" Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR> <!-- 14 --> <!-- 21 --> <!-- Additional Field : Right --></TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 10px" colSpan="2">Document Upload
						</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="75">File</TD>
									<TD style="WIDTH: 15px">:</TD>
									<TD class="TDBGColorValue"><INPUT id="TXT_FILE_UPLOAD" style="WIDTH: 344px; HEIGHT: 19px" type="file" size="38" name="File1"
											runat="Server"></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS" runat="server" ForeColor="Red"></asp:label><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" ControlToValidate="TXT_FILE_UPLOAD"
											ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.xls|.XLS|.doc|.DOC|.txt|.TXT|.zip|.ZIP)$" ErrorMessage="Only xls, doc, txt or zip files are allowed!"></asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSREPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"><asp:button id="BTN_UPLOAD" runat="server" Text="Upload" onclick="BTN_UPLOAD_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</table>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DatGrid" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq"></asp:BoundColumn>
												<asp:BoundColumn HeaderText="No.">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Pertimbangan Overide</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CP_PERMASALAHAN" runat="server" Width="100%"
								TextMode="MultiLine" Height="85px"></asp:textbox><asp:textbox id="TXT_CP_EXCEPTION" runat="server" Width="100%" Visible="False" TextMode="MultiLine"
								Height="75px"></asp:textbox><asp:textbox id="TXT_CP_BLMDIPENUHI" runat="server" Width="100%" Visible="False" TextMode="MultiLine"
								Height="75px"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<table id="Table1" cellSpacing="2" cellPadding="2" width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">Portfolio Guideline</TD>
								</TR>
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 17px">Outstanding Limit</TD>
												<TD style="WIDTH: 12px; HEIGHT: 17px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_OUTSTANDING" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox><asp:textbox id="TXT_RATIO_LIMIT" runat="server" Width="40px" BorderStyle="None" Height="24px"></asp:textbox><asp:label id="percent" runat="server" Height="24px">%</asp:label><asp:label id="lbl_sekom3" runat="server" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 26px">Pending Limit</TD>
												<TD style="WIDTH: 12px; HEIGHT: 26px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 26px"><asp:textbox id="TXT_PENDING" runat="server" Width="200px" BorderStyle="None" Height="24px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 23px">Available Limit</TD>
												<TD style="WIDTH: 12px; HEIGHT: 23px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:textbox id="TXT_AVAILABLE" runat="server" Width="200px" BorderStyle="None" Height="17px"></asp:textbox><asp:textbox id="TXT_RATIO_AVAIL" runat="server" Width="40px" BorderStyle="None" Height="24px"></asp:textbox><asp:label id="percent2" runat="server" Height="24px">%</asp:label></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 24px">Industry Class</TD>
												<TD style="WIDTH: 12px; HEIGHT: 24px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox id="TXT_INDUSTRYCLASS" runat="server" Width="200px" BorderStyle="None" Height="22px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 592px; HEIGHT: 24px">Portfolio Status</TD>
												<TD style="WIDTH: 12px; HEIGHT: 24px">:</TD>
												<TD class="TDBGColorValue" style="HEIGHT: 24px"><asp:textbox id="TXT_STATUS" runat="server" Width="200px" BorderStyle="None" Height="22px"></asp:textbox></TD>
											</TR>
										</TABLE>
										<asp:label id="lbl_ksebi4" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_PORTFOLIO" runat="server" Width="100px" Text="Cek Portfolio" onclick="BTN_PORTFOLIO_Click"></asp:button></TD>
								</TR>
							</table>
						</TD>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" width="50%" colSpan="2">
							<TABLE class="td" id="Table8" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdHeader1">Pemutus</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="50%" border="0">
											<TR>
												<TD style="WIDTH: 208px"><asp:radiobutton id="rb_manual" Text="Manual" GroupName="fwdtype" Runat="server" Checked="True"></asp:radiobutton></TD>
												<TD><asp:dropdownlist id="ddl_manual" Runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 208px"><asp:checkbox id="chk_more2person" runat="server" Width="184px" Text="Submit To BOD Approval"
														AutoPostBack="True" oncheckedchanged="chk_more2person_CheckedChanged"></asp:checkbox></TD>
												<TD><asp:dropdownlist id="ddl_nextendorse" Runat="server" Enabled="False"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
										<asp:label id="Label1" runat="server" Visible="False">Next Endorse/Approval</asp:label><asp:radiobutton id="rb_auto" Visible="False" Text="Automatic" GroupName="fwdtype" Runat="server"></asp:radiobutton>
										<asp:TextBox id="TXT_ERRMSG" runat="server" Visible="False">Exception occured.\\nPlease contact system administrator for further informations.</asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" width="50%" colSpan="2">
                            <asp:button id="btn_acquireInfo" runat="server" Width="227px" 
                                Text="Kembali ke Proses Verifikasi" CssClass="Button1" 
                                onclick="btn_acquireInfo_Click"></asp:button>
                            <asp:button id="BTN_SAVE" runat="server" Text="Simpan" CssClass="Button1" 
                                onclick="BTN_SAVE_Click"></asp:button>
                            <asp:button id="updatestatus" runat="server" Width="151px" 
                                Text="Kirim Ke Pemutus" CssClass="Button1" onclick="updatestatus_Click"></asp:button>
                            <asp:button id="btn_PrintScoringResult" runat="server" Width="151px" 
                                Text="Cetak Hasil Scoring" CssClass="Button1" 
                                onclick="btn_PrintScoringResult_Click"></asp:button>
                        </TD>
					</TR>
                    <!--
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Document Export</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 540px" vAlign="top" width="540">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 19px" width="75">Format</TD>
									<TD style="WIDTH: 15px; HEIGHT: 19px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 19px"><asp:dropdownlist id="DDL_FORMAT_TYPE" runat="server" Width="280px" AutoPostBack="True"></asp:dropdownlist>
										<asp:button id="BTN_EXPORT" runat="server" Width="64px" Text="Export" onclick="BTN_EXPORT_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="HEIGHT: 17px">Ketentuan</TD>
									<TD style="HEIGHT: 17px">:</TD>
									<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_KETENTUAN" runat="server" Width="280px"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Status</TD>
									<TD>:</TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUS_EXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1"></TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:label id="LBL_STATUSEXPORT" runat="server" ForeColor="Red"></asp:label></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 21px" align="center" colSpan="3"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="3"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD style="HEIGHT: 42px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="473" AutoGenerateColumns="False" PageSize="1"
											CellPadding="1">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="nota_id">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FU_FILENAME" HeaderText="File Name">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
													<ItemTemplate>
														<asp:HyperLink id="HL_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="FU_USERID" HeaderText="User ID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="ket_code"></asp:BoundColumn>
											</Columns>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>-->
                    <tr>
                        <td colspan="2">
                            <uc1:DocumentExport ID="DocumentExportCP" runat="server" />
                        </td>
                    </tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
