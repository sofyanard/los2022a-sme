<%@ Page language="c#" Codebehind="ApprvPerubahanJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.ApprvPerubahanJaminan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ApprvPerubahanJaminan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD align="center" width="100%" colSpan="2">
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
												<asp:DropDownList id="DDL_PRJ_CODE" runat="server" Width="150px" Enabled="False"></asp:DropDownList>
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
											<TD><asp:label id="LBL_EARMARK_AMOUNT" runat="server"></asp:label></TD>
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
												<asp:textbox id="txt_limit" runat="server" MaxLength="15" Columns="50" Width="150px" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Jangka Waktu</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:textbox id="txt_tenor" runat="server" MaxLength="3" Columns="5" Width="40px" ReadOnly></asp:textbox>&nbsp;
												<asp:textbox id="txt_tenorcode" runat="server" MaxLength="5" Columns="5" Width="40px" ReadOnly></asp:textbox></TD>
										</TR>
										<TR id="tr_fix" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">&nbsp;Suku Bunga Fix</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_fix" runat="server" MaxLength="6" Columns="10" Width="40px" ReadOnly></asp:textbox>%</TD>
										</TR>
										<TR id="tr_float" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px; HEIGHT: 22px">Suku Bunga Mengambang</TD>
											<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 22px"><asp:dropdownlist id="ddl_rate" runat="server" Enabled="False" Visible="False"></asp:dropdownlist><asp:textbox id="txt_rate" runat="server" MaxLength="10" Columns="10" Width="40px" ReadOnly></asp:textbox>%
												<asp:dropdownlist id="ddl_varcode" runat="server" Enabled="False"></asp:dropdownlist><asp:textbox id="txt_variance" runat="server" MaxLength="10" Columns="10" Width="40px" ReadOnly></asp:textbox>%
											</TD>
										</TR>
										<TR id="tr_install" runat="server">
											<TD class="TDBGColor1" style="WIDTH: 140px">Installment</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_installment" runat="server" MaxLength="15" Columns="10" Width="152px" ReadOnly></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="td" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Tujuan Penggunaan</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_purpose" runat="server" MaxLength="200" Columns="200" Width="280px" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Sifat Kredit</TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_sifat" runat="server" MaxLength="100" Columns="100" Width="176px" ReadOnly></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 18px">Total Agunan dalam Rp.</TD>
											<TD style="WIDTH: 15px; HEIGHT: 18px"></TD>
											<TD class="TDBGColorValue" style="HEIGHT: 18px"><asp:textbox id="txt_totcoll" runat="server" MaxLength="100" Columns="100" Width="100px" ReadOnly></asp:textbox><asp:textbox id="txt_exrplimit" runat="server" MaxLength="50" Columns="50" Width="24px" Visible="False"
													Height="16px"></asp:textbox><asp:textbox id="txt_exlimitval" runat="server" MaxLength="50" Columns="50" Width="24px" Visible="False"
													Height="16px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px" vAlign="top"><asp:label id="lbl_exlimitval" runat="server" Visible="False"></asp:label>Remark
												<asp:label id="lbl_decsta" runat="server" Visible="False"></asp:label></TD>
											<TD style="WIDTH: 15px"></TD>
											<TD class="TDBGColorValue"><asp:textbox id="txt_remark" runat="server" MaxLength="50" Columns="50" Width="280px" Height="40px"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2"><asp:label id="LBL_PRODUCT" runat="server" Font-Bold="True"></asp:label></td>
				</tr>
				<TR>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_APPTYPE" runat="server" Width="250px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCT" runat="server" Width="250px" ReadOnly="True" BorderStyle="None"
											AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Pembentukan</TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_REVOLVING" runat="server" Width="250px" ReadOnly="True" BorderStyle="None"
											AutoPostBack="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit
										<asp:label id="LBL_CURRENCY" runat="server"></asp:label></TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_LIMIT" runat="server" Width="250px" ReadOnly="True" BorderStyle="None"
											CssClass="angka"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_CP_LOANPURPOSE" runat="server" Enabled="False" Width="250px"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
					<TD vAlign="top" width="50%">
						<FIELDSET>
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="170">Tenor</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_JANGKAWAKTU" runat="server" MaxLength="3" Columns="4" ReadOnly="True" BorderStyle="None"
											CssClass="angka"></asp:textbox>&nbsp;
										<asp:label id="LBL_TENORCODE" runat="server" Font-Bold="True"></asp:label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Keterangan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_KETERANGAN" runat="server" Width="250px" Height="60px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
							</TABLE>
						</FIELDSET>
					</TD>
				</TR>
				<tr>
					<td class="tdHeader1" align="center" width="100%" colSpan="2">Jaminan Yang Diubah
						<asp:label id="LBL_AA_NO" runat="server" Visible="False"></asp:label></td>
				</tr>
				<TR>
					<td align="center" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="70%" CellPadding="1" AutoGenerateColumns="False"
							AllowPaging="True" PageSize="3" HorizontalAlign="Center">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="cl_desc" HeaderText="Collateral Description">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="coltypedesc" HeaderText="Collateral Type">
									<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cl_percent" HeaderText="% of Use">
									<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cl_value" HeaderText="Start Nomial">
									<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="End Nominal">
									<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></td>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<tr>
					<td class="tdHeader1" align="center" colSpan="2">Jaminan Pengganti</td>
				</tr>
				<TR>
					<td align="center" colSpan="2"><ASP:DATAGRID id="DatGrd1" runat="server" Width="90%" CellPadding="1" AutoGenerateColumns="False"
							AllowPaging="True" PageSize="3" HorizontalAlign="Center">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
								<asp:BoundColumn DataField="cl_desc" HeaderText="Collateral Description">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="coltypedesc" HeaderText="Collateral Type">
									<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="lc_percentage" HeaderText="% of Use">
									<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cl_value" HeaderText="Start Nomial">
									<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="lc_value" HeaderText="End Nominal">
									<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ACTION" HeaderText="Action">
									<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Visible="False" Text="Delete" HeaderText="Function" CommandName="Delete">
									<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></td>
				</TR>
				<TR id="tr_ad_title" runat="server">
					<TD class="tdheader1" align="center" colSpan="2">Decision
						<asp:label id="lbl_usergroup" Runat="server"></asp:label></TD>
				</TR>
				<TR id="tr_ad_override" runat="server">
					<TD align="center" colSpan="2">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
							<TBODY>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Decision Status</TD>
									<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px">
										<asp:textbox id="txt_decsta" runat="server" ReadOnly="True" Width="288px" Columns="10" MaxLength="10"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px">Override Status</TD>
									<TD style="WIDTH: 14px; HEIGHT: 14px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 14px">
										<asp:textbox id="txt_decovrsta" runat="server" ReadOnly="True" Width="40px" Columns="100" MaxLength="100"></asp:textbox></TD>
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
											CssClass="mandatory" Columns="100" MaxLength="100" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 161px; HEIGHT: 15px" vAlign="top">Remark</TD>
									<TD style="WIDTH: 14px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px">
										<asp:textbox onkeypress="return kutip_satu()" id="txt_decremark" runat="server" Width="288px"
											Columns="50" MaxLength="50" TextMode="MultiLine" Rows="5"></asp:textbox></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 161px">
										<asp:TextBox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:TextBox></TD>
					</TD>
					<TD style="WIDTH: 14px"></TD>
					<TD class="TDBGColorValue" align="left">
						<%if (Request.QueryString["sta"] != "view") {%>
						<asp:button id="btn_override" CssClass="button1" Text="Override" Runat="server" onclick="btn_override_Click"></asp:button>
						<asp:Button id="BTN_EARMARK" runat="server" CssClass="button1" Text="Re-Earmark" Visible="False" onclick="BTN_EARMARK_Click"></asp:Button>
						<%}%>
					</TD>
				</TR>
				<TR id="tr_confirm_negative" runat="server">
					<TD style="WIDTH: 161px"></TD>
					<TD style="WIDTH: 14px"></TD>
					<TD class="TDBGColorValue" align="left">
						<asp:Label id="Label1" runat="server" Font-Bold="True" ForeColor="Red">Hasil Earmark akan negatif. Lanjutkan ?</asp:Label>&nbsp;
						<asp:Button id="BTN_NEGATIVE_YES" runat="server" Width="75px" Text="Yes" onclick="BTN_NEGATIVE_YES_Click"></asp:Button>&nbsp;
						<asp:Button id="BTN_NEGATIVE_NO" runat="server" Width="75px" Text="No" onclick="BTN_NEGATIVE_NO_Click"></asp:Button></TD>
				</TR>
			</TABLE>
			</TD></TR></TBODY></TABLE>
		</form>
	</body>
</HTML>
