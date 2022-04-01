<%@ Page language="c#" Codebehind="ApprvPerubahanSyarat.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprvPerubahanSyarat" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprvPerubahanSyarat</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="center" colSpan="2">
						<%if (Request.QueryString["sta"] != "view") {%>
						<asp:linkbutton id="lb_struc" Runat="server" Font-Bold="True" onclick="lb_struc_Click">Credit Structure</asp:linkbutton><BR>
						<BR>
						<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" border="1">
							<TR>
								<TD>
									<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD class="TDBGColor1">Project Info</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD>
												<asp:DropDownList id="DDL_PROJECT_CODE" runat="server" Width="150px" Enabled="False"></asp:DropDownList>
												<asp:Button id="btn_Save" runat="server" Visible="False" Text="Save" onclick="btn_Save_Click"></asp:Button>
												<asp:Label id="LBL_PRJ_CODE" runat="server" Visible="False"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD>
									<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="100%" border="1">
										<TR>
											<TD class="TDBGColor1">Earmark Amount</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD>
												<asp:Label id="LBL_EARMARK_AMOUNT" runat="server"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<BR>
						<%}%>
						<TABLE id="kreditAwal" cellSpacing="2" cellPadding="2" width="100%" runat="server">
							<TR>
								<TD class="td" vAlign="top" width="50%">
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Limit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">Rp.
												<asp:textbox id="Textbox1" runat="server" ReadOnly Width="150px" MaxLength="15" Columns="50"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px">Jangka Waktu</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_tenor" runat="server" ReadOnly Width="40px" MaxLength="3" Columns="5"></asp:textbox>&nbsp;
												<asp:textbox id="txt_tenorcode" runat="server" ReadOnly Width="40px" MaxLength="5" Columns="5"></asp:textbox></TD>
										</TR>
										<TR id="tr_fix" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Suku Bunga Fix</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_fix" runat="server" ReadOnly Width="40px" MaxLength="6" Columns="10"></asp:textbox>%</TD>
										</TR>
										<TR id="tr_float" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Suku Bunga Mengambang</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px">
												<asp:dropdownlist id="ddl_rate" runat="server" Enabled="False" Visible="False"></asp:dropdownlist>
												<asp:textbox id="txt_rate" runat="server" ReadOnly Width="40px" MaxLength="10" Columns="10"></asp:textbox>%
												<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist>
												<asp:textbox id="txt_variance" runat="server" ReadOnly Width="40px" MaxLength="10" Columns="10"></asp:textbox>%
											</TD>
										</TR>
										<TR id="tr_install" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Installment</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_installment" runat="server" ReadOnly Width="152px" MaxLength="15" Columns="10"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_purpose" runat="server" ReadOnly Width="280px" MaxLength="200" Columns="200"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_sifat" runat="server" ReadOnly Width="176px" MaxLength="100" Columns="100"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Agunan dalam Rp.</TD>
											<TD style="WIDTH: 15px; HEIGHT: 18px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 18px">
												<asp:textbox id="txt_totcoll" runat="server" ReadOnly Width="100px" MaxLength="100" Columns="100"></asp:textbox>
												<asp:textbox id="txt_exrplimit" runat="server" Width="24px" MaxLength="50" Height="16px" Columns="50"
													Visible="False"></asp:textbox>
												<asp:textbox id="txt_exlimitval" runat="server" Width="24px" MaxLength="50" Height="16px" Columns="50"
													Visible="False"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px" vAlign="top">
												<asp:label id="lbl_exlimitval" runat="server" Visible="False"></asp:label>Remark
												<asp:label id="lbl_decsta" runat="server" Visible="False"></asp:label></TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox id="txt_remark" runat="server" Width="280px" MaxLength="50" TextMode="MultiLine"
													Height="40px" Columns="50"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="tdHeader1" colSpan="2">
						<asp:Label id="LBL_TITLE" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_APPTYPE" runat="server" Width="250px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Kredit</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTDESC" onkeypress="return kutip_satu()" runat="server" Width="250px"
										ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">
									Pembentukan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" onkeypress="return kutip_satu()" runat="server" Width="250px"
										ReadOnly="True" AutoPostBack="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">AA No.</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AA_NO" runat="server" AutoPostBack="True" Enabled="False"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Limit</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_LIMIT" runat="server" ReadOnly="True" Width="250px" BorderStyle="None" MaxLength="15"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tenor</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_TENORDESC" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Tujuan Penggunaan</TD>
								<TD></TD>
								<TD class="TDBGColorValue">
									<asp:DropDownList id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False" Width="250px"></asp:DropDownList></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_NOTES" runat="server" Width="250px" Height="135px" onkeypress="return kutip_satu()"
										TextMode="MultiLine" Enabled="False"></asp:textbox></TD>
							</TR>
						</TABLE>
						<asp:dropdownlist id="DDL_FACILITYNO" runat="server" AutoPostBack="True" Enabled="False" Visible="False"></asp:dropdownlist>
					</TD>
				</TR>
				<TR id="tr_ad_title" runat="server">
					<TD class="tdheader1" align="center" colSpan="2">Decision
						<asp:label id="lbl_usergroup" Runat="server"></asp:label></TD>
				</TR>
				<TR id="tr_ad_override" runat="server">
					<TD align="center" colSpan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Decision Status</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decsta" runat="server" ReadOnly="True" Width="288px" MaxLength="10" Columns="10"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Status</TD>
								<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 14px">
									<asp:textbox id="txt_decovrsta" runat="server" ReadOnly="True" Width="40px" MaxLength="100" Columns="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Reason</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:dropdownlist id="ddl_decovrreason" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decovrreason" runat="server" Width="223px"
										CssClass="mandatory" MaxLength="100" TextMode="MultiLine" Columns="100"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px" vAlign="top">Remark</TD>
								<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 15px">
									<asp:textbox onkeypress="return kutip_satu()" id="txt_decremark" runat="server" Width="288px"
										MaxLength="50" TextMode="MultiLine" Columns="50" Rows="5"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 161px">
									<asp:TextBox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:TextBox></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue" align="left">
									<%if (Request.QueryString["sta"] != "view") {%>
									<asp:button id="btn_override" CssClass="button1" Text="Override" Runat="server"></asp:button>
									<asp:Button id="BTN_EARMARK" runat="server" CssClass="button1" Text="Re-Earmark" Visible="False" onclick="BTN_EARMARK_Click"></asp:Button>
									<%}%>
								</TD>
							</TR>
							<TR id="tr_confirm_negative" runat="server">
								<TD style="WIDTH: 161px"></TD>
								<TD style="WIDTH: 14px"></TD>
								<TD class="TDBGColorValue" align="left">
									<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red">Hasil Earmark akan negatif. Lanjutkan ?</asp:Label>
									<asp:Button id="BTN_NEGATIVE_YES" runat="server" Width="75px" Text="Yes" onclick="BTN_NEGATIVE_YES_Click"></asp:Button>
									<asp:Button id="BTN_NEGATIVE_NO" runat="server" Width="75px" Text="No" onclick="BTN_NEGATIVE_NO_Click"></asp:Button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
