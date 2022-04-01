<%@ Page language="c#" Codebehind="Approval.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.Approval" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>Approval</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" -->
        <%= popUp%>
		<script language="javascript">
		function continueApproval(action)
		{			
			pesan = "Penentuan kategori pemutus kredit agar memperhatikan limit kredit one obligor, security coverage agunan,";
			pesan = pesan + "\n jenis permohonan kredit (baru, perpanjangan, tambahan), dan hasil rating/scoring.";
			pesan = pesan + "\n Are you sure you want to " + action + " ? ";
			
			//pesan = "Are you sure you want to " + action + " ? ";			
			conf = confirm(pesan);
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td style="WIDTH: 495px">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Approval</B></TD>
								</TR>
							</TABLE>
						</td>
						<td class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</tr>
					<tr>
						<td class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></td>
					</tr>
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2"><asp:label id="lbl_apptype" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_PROD_SEQ" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_regno" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_curef" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_prod" runat="server" Visible="False"></asp:label>
							Informasi Pemohon
							<asp:label id="lbl_track" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_eye" runat="server" Visible="False"></asp:label>
							<asp:label id="mc" runat="server" Visible="False"></asp:label>
							<asp:label id="lbl_aprvuntil" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
				</table>
				<table id="Table2" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center">
							
						<iframe id="if1" style="WIDTH: 100%; HEIGHT: 185px" name="if1" src="../SPPK/appinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&sta=view" scrolling="no"></iframe>
						
							<asp:TextBox id="TXT_AUDITTRAIL_DESC" runat="server" Visible="False">PS Verification Requested. Prepare by </asp:TextBox>
						</td>
					</tr>

					<TR id="TR_INFO_CRM" runat="server">
						<TD vAlign="top" width="100%">
							<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="tdheader1">Information acquired</TD>
								</TR>
								<TR>
									<TD>
										<asp:TextBox id="txt_acqinfo" Width="100%" Runat="server" ReadOnly="True" TextMode="MultiLine"
											Height="150"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</table>
				<table id="Table3" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td vAlign="top">
							<asp:table id="tbl_prod" runat="server" CssClass="BackGroundList" CellSpacing="0" CellPadding="0"
								Width="100%"></asp:table>
							<br>
							<br>
							<asp:Button id="BTN_PROJECTLIST" runat="server" Text="View Project List" Visible="False" onclick="BTN_PROJECTLIST_Click"></asp:Button>
							<INPUT type="button" size="10" value="View Project List" onclick="javascript:PopupPage('../ProjectInfo.aspx?targetFormID=Form1', '800','600');">
							<BR>
						</td>
						<td align="right">
							<iframe id="if2" style="WIDTH: 800px; HEIGHT: 650px" name="if2" src="" scrolling="auto"
								frameborder="no"></iframe>
						</td>
					</tr>
				</table>
				<TABLE id="Table5" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" width="50%" colSpan="2">Limit Exposure</TD>
					</TR>
				</TABLE>
				<TABLE id="Table6" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="TDBGColor1" style="WIDTH: 135px" align="right">Limit Rp.</td>
						<td style="WIDTH: 12px">:</td>
						<td class="TDBGColor1" style="WIDTH: 122px"><asp:label id="lbl_limexp" Runat="server"></asp:label></td>
						<td style="WIDTH: 110px"></td>
						<td class="TDBGColor1" style="WIDTH: 136px">Apply Value Rp.</td>
						<td style="WIDTH: 12px">:</td>
						<td class="TDBGColor1" style="WIDTH: 112px" align="right"><asp:label id="lbl_reqlim" Runat="server"></asp:label></td>
						<td></td>
					</tr>
				</TABLE>
				<table id="Table7" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" width="50%" colSpan="2">Rasio-rasio Proyeksi</td>
					</tr>
					<tr>
						<td class="td" vAlign="top" width="50%">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td style="WIDTH: 140px"><b>Rentabilitas</b></td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">ROA</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_roa" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">ROE</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_roe" runat="server" Width="80px" Columns="10" MaxLength="10" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Net Profit Margin</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_netprofit" runat="server" Width="80px" Columns="10" MaxLength="10" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">ROI</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_roi" runat="server" Width="80px" Columns="10" MaxLength="10" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Networth</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_networth" runat="server" Width="80px" Columns="10" MaxLength="10" ReadOnly></asp:textbox></td>
								</tr>
								<tr>
									<td style="WIDTH: 140px"><b>Pertumbuhan</b></td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Penjualan</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_jual" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Laba Bersih</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_laba" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></td>
								</tr>
								<tr>
									<td style="WIDTH: 140px"><b>Leverage</b></td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Debt Equity Ratio</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_der" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 140px">Total Aktiva/Modal</td>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="txt_totakt" runat="server" ReadOnly Width="80px" MaxLength="5" Columns="5"></asp:textbox>%</TD>
								</tr>
								<tr>
									<td style="WIDTH: 140px"></td>
									<td style="WIDTH: 15px"></td>
									<td><asp:textbox id="txt_cashvel" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly
											Visible="False"></asp:textbox>
										<asp:textbox id="txt_colcov" runat="server" Visible="False" ReadOnly Width="80px" MaxLength="5"
											Columns="5"></asp:textbox>
									</td>
								</tr>
							</table>
						</td>
						<td class="td" vAlign="top">
							<table cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td style="WIDTH: 166px"><b>Likuiditas</b></td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Current Ratio</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_curratio" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Debt Service Coverage</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_dsc" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td style="WIDTH: 166px"><b>Activity</b></td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Days Receivable (Hari)</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_dayrec" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Days Inventory (Hari)</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_dayinv" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Days Account Payable(Hari)</td>
									<td style="WIDTH: 15px">&nbsp;</td>
									<td class="TDBGColorValue"><asp:textbox id="txt_dayaccpay" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Trade Cycle</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_trade" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></td>
								</tr>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 166px">Total Asset Turn Over</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="txt_totaset" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></TD>
								</TR>
								<tr>
									<td style="WIDTH: 166px"><b>Biaya</b></td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"></td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Laba Kotor/Penjualan</td>
									<td style="WIDTH: 15px"></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_labakotor" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox>%</td>
								</tr>
								<tr>
									<td class="TDBGColor1" style="WIDTH: 166px">Biaya Umum &amp; Adm Penjualan</td>
									<td style="WIDTH: 15px">
										<asp:textbox id="TXT_VERIFY" runat="server" Width="1px" BorderStyle="None"></asp:textbox></td>
									<td class="TDBGColorValue"><asp:textbox id="txt_biayaadm" runat="server" Width="80px" Columns="5" MaxLength="5" ReadOnly></asp:textbox></td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<table id="Table8" cellSpacing="2" cellPadding="2" width="100%">
					<tr>
						<td class="tdHeader1" style="WIDTH: 910px" width="910"><b>Catatan</b></td>
					</tr>
					<tr>
						<td style="WIDTH: 910px; HEIGHT: 76px" vAlign="top">
							<P><asp:textbox onkeypress="return kutip_satu()" id="txt_remark" Width="100%" Runat="server" Height="97px"
									TextMode="MultiLine"></asp:textbox></P>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2"><asp:button id="BTN_PORTFOLIO" runat="server" Width="100px" Text="Cek Portfolio"></asp:button></TD>
					</TR>
                    <tr>
                        <td>
                            <table id="tableNote" runat="server">
                                
                            </table>
                        </td>
                    </tr>
                    <tr id="rows_warning" runat="server">
                        <td align=center>
                            <asp:Label runat="server" ID="lbl_warning" Font-Bold="True" Font-Size="Large" 
                                ForeColor="Red"></asp:Label>
                            <asp:Button ID="Button1" runat="server" CssClass="Button1" Text="Simpan Hasil Review" />
                        </td>
                    </tr>
					<tr  id="header" runat="server">
						<td class="tdHeader1" style="WIDTH: 910px; HEIGHT: 14px" vAlign="top">Cek Jika 
                            Setuju 
						</td>
					</tr>
					<tr id="cbList" runat="server">
						<td style="WIDTH: 910px; HEIGHT: 27px" vAlign="top"><asp:checkboxlist id="cbl_prod" Width="278px" Runat="server" Height="12px"></asp:checkboxlist><asp:checkboxlist id="cbl_prodrej" Width="936px" Runat="server" Height="12px"></asp:checkboxlist></td>
					</tr>
					<tr id="trDecision" runat="server">
						<td class="tdHeader1" style="WIDTH: 910px" vAlign="top"><STRONG>Keputusan</STRONG></td>
					</tr>
					</table>
				<table id="DECISION_PANEL" runat="server">
					<tr id="tr_prrk" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px; HEIGHT: 11px" vAlign="top"><asp:label id="lbl_prrk" Runat="server">PS Verification By</asp:label></td>
						<td style="WIDTH: 387px; HEIGHT: 11px" vAlign="top"><asp:dropdownlist id="ddl_prrk" Runat="server"></asp:dropdownlist></td>
						<td style="WIDTH: 423px; HEIGHT: 11px" vAlign="top"><asp:button id="btn_pprk" 
                                CssClass="button1" Width="200px" Runat="server" Text="Penugasan Review"></asp:button></td>
					</tr>
					<tr id="tr_appeal" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"><asp:label id="lbl_appeal" Runat="server">Appeal To</asp:label></td>
						<td style="WIDTH: 387px" vAlign="top"><asp:dropdownlist id="ddl_appeal" Runat="server"></asp:dropdownlist></td>
						<td style="WIDTH: 423px" vAlign="top"><asp:button id="btn_appeal" 
                                CssClass="button1" Width="155px" Runat="server" Text="Banding"></asp:button></td>
					</tr>
					<tr id="tr_fwdmanual" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"><asp:radiobutton id="rb_manual" Runat="server" Text="Manual" GroupName="fwdtype"></asp:radiobutton><asp:radiobutton id="rb_auto" Runat="server" Text="Automatic" GroupName="fwdtype" Checked></asp:radiobutton></td>
						<td style="WIDTH: 387px" vAlign="top"><asp:dropdownlist id="ddl_manual" Runat="server"></asp:dropdownlist></td>
						<td style="WIDTH: 423px" vAlign="top"><asp:button id="btn_fwdrej" 
                                CssClass="button1" Width="155px" Runat="server" Text="Kirim ke Pemutus"></asp:button></td>
					</tr>
					<tr id="tr_fwdrisk" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"></td>
						<td style="WIDTH: 387px" vAlign="top"><asp:label id="LBL_RISKUNITNAME" Runat="server"></asp:label></td>
						<td style="WIDTH: 423px" vAlign="top">
							<asp:button id="btn_fwdrisk" CssClass="button1" Width="155px" Runat="server" 
                                Text="Penerusan Ke Unit Risk"></asp:button>
						</td>
					</tr>
					<tr id="tr_approve" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"><asp:label id="lbl_aprvwith" Runat="server">Approve With</asp:label></td>
						<td style="WIDTH: 387px" vAlign="top"><asp:dropdownlist id="ddl_aprvwith" Runat="server"></asp:dropdownlist></td>
						<td style="WIDTH: 423px" vAlign="top"><asp:button id="btn_aprvrej" 
                                CssClass="button1" Width="155px" Runat="server" Text="Setuju"></asp:button>&nbsp;
							<STRONG>&gt;&gt;Routing : </STRONG>
							<asp:Label id="LBL_APRV_ROUTING" runat="server" ForeColor="Blue" Font-Bold="True"></asp:Label></td>
					</tr>
					<tr id="tr_reject" runat="server">
						<td class="TDBGColor1" style="WIDTH: 154px" vAlign="top"><asp:label id="lbl_rejreason" Runat="server">Alasan Tolak</asp:label></td>
						<td style="WIDTH: 406px" vAlign="top"><asp:dropdownlist id="ddl_rjreason" Runat="server"></asp:dropdownlist></td>
						<td style="WIDTH: 423px" vAlign="top"><asp:button id="btn_reject" 
                                CssClass="button1" Width="155" Runat="server" Text="Tolak"></asp:button></td>
					</tr>
					<tr id="tr_reject1" runat="server">
						<td style="WIDTH: 154px" vAlign="top"></td>
						<td style="WIDTH: 406px" vAlign="top" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="txt_rjreason" runat="server" Width="280px"
								Columns="250" MaxLength="250"></asp:textbox></td>
					</tr>
					<tr align="center">
						<td colSpan="3">
							<asp:button id="btn_info" CssClass="button1" Runat="server" 
                                Text="Analisa Ulang"></asp:button>
							<asp:button id="btn_backtover" CssClass="button1" Runat="server" 
                                Text="Analisa Ulang"></asp:button>
							<asp:button id="btn_decision" CssClass="button1" Runat="server" 
                                Text="Riwayat Pemutusan"></asp:button>
							<asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" Width="1px"></asp:textbox>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
