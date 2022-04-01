<%@ Page language="c#" Codebehind="DokumenJaminan.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.Documentation.DokumenJaminan" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>DokumenJaminan</TITLE>
		<META content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_entries.html" -->
  </HEAD>
	<BODY MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE width="100%" border="0">
					<TR>
						<TD align="left" width="50%">
							<TABLE id="Table1">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>DOKUMEN JAMINAN</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/image/Back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG height="25" src="../../Image/MainMenu.jpg" width="106"></A>
							<A href="../../Logout.aspx" target="_top"><IMG src="../../Image/Logout.jpg"></A>
						</TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="45%"><asp:label id="LBL_TXT_JAMINAN_AGUNAN" runat="server">Select Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue" width="45%"><asp:dropdownlist id="DDL_JAMINAN_AGUNAN" runat="server" Width="100%"></asp:dropdownlist><asp:label id="LBL_JAMINAN_AGUNAN" runat="server" Visible="False"></asp:label></TD>
									<TD width="10%"><asp:button id="BTN_AGUNAN" runat="server" Width="100px" CssClass="button1" Text="Select" onclick="BTN_AGUNAN_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					<TR>
						<TD class="tdHeader1" colSpan="2">DETAIL DOKUMEN AGUNAN</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_AGUNAN" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COLL_DESC" HeaderText="Nama Jaminan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COLTYPEDESC" HeaderText="Jenis Jaminan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CERTTYPEDESC" HeaderText="Doc.Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AKTA_DESC" HeaderText="Isi Akta">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NOTARY" HeaderText="Nama Notaris">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IKATDESC" HeaderText="Doc.Pengikatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NO_DOC_PENGIKATAN" HeaderText="No.Doc.Pengikatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ISSUED_DATE" HeaderText="Tgl.Terbit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EXP_DATE" HeaderText="Tgl.Kadaluarsa">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT_AGUNAN" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE_AGUNAN" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NM_JAMINAN" runat="server">Nama Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NM_JAMINAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TYPE_JAMINAN" runat="server">Jenis Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TYPE_JAMINAN" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TYPE_DOCUMENT" runat="server">Document Type :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TYPE_DOCUMENT" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ISI_AKTA" runat="server">Isi Akta :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ISI_AKTA" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NM_NOTARIS" runat="server">Nama Notaris :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NM_NOTARIS" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_DOC_PENGIKATAN" runat="server">Doc.Pengikatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_DOC_PENGIKATAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_DOC_PENGIKATAN" runat="server">No.Doc.Pengikatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_DOC_PENGIKATAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TGL_TERBIT_AGUNAN" runat="server">Tgl.Terbit :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TERBIT_DAY_AGUNAN" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TERBIT_MONTH_AGUNAN" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TERBIT_YEAR_AGUNAN" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_JATUH_TEMPO_AGUNAN" runat="server">Tgl.Kadaluarsa :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JATUH_TEMPO_DAY_AGUNAN" runat="server"
											Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_JATUH_TEMPO_MONTH_AGUNAN" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_JATUH_TEMPO_YEAR_AGUNAN" runat="server"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENYIMPANAN_AGUNAN" runat="server">Tempat Penyimpanan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENYIMPANAN_AGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_JNS_JAMINAN" runat="server" Visible="False"></asp:label><asp:label id="LBL_DOC_TYPE" runat="server" Visible="False"></asp:label><asp:label id="LBL_SEQ_AGUNAN" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE_AGUNAN" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_SAVE_AGUNAN_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_AGUNAN" runat="server" Width="100px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_AGUNAN_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="45%"><asp:label id="LBL_TXT_JAMINAN_ASURANSI" runat="server">Select Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue" width="45%"><asp:dropdownlist id="DDL_JAMINAN_ASURANSI" runat="server" Width="100%"></asp:dropdownlist><asp:label id="LBL_JAMINAN_ASURANSI" runat="server" Visible="False"></asp:label></TD>
									<TD width="10%"><asp:button id="BTN_ASURANSI" runat="server" Width="100px" CssClass="button1" Text="Select" onclick="BTN_ASURANSI_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					<TR>
						<TD class="tdHeader1" colSpan="2">DETAIL DOKUMEN ASURANSI</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DGR_ASURANSI" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NO_POLIS" HeaderText="Nomor Polis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="POLIS_DESC" HeaderText="Deskripsi Polis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CERTTYPEDESC" HeaderText="Doc.Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ISSUED_DATE" HeaderText="Tgl.Terbit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EXP_DATE" HeaderText="Tgl.Jatuh Tempo">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERTANGGUNGAN_TYPE" HeaderText="Jenis Pertanggungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERTANGGUNGAN_VAL" HeaderText="Nilai">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INS_COMPANY" HeaderText="Insurance Corp.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KONSORSIUM_PERCENT" HeaderText="Konsorsium(%)">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REMARK" HeaderText="Leader">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PLACE_DOC" HeaderText="Tempat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT_ASURANSI" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE_ASURANSI" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_POLIS" runat="server">Nomor Polis :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_POLIS" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_POLIS_DESC" runat="server">Deskripsi Polis :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_POLIS_DESC" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TYPE_DOC" runat="server">Jenis Dokumen :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TYPE_DOC" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TGL_TERBIT_ASURANSI" runat="server">Tgl.Terbit :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_TERBIT_DAY_ASURANSI" runat="server" Width="24px"
											MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_TERBIT_MONTH_ASURANSI" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_TERBIT_YEAR_ASURANSI" runat="server" Width="36px"
											MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_JATUH_TEMPO_ASURANSI" runat="server">Tgl.Jatuh Tempo :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:textbox onkeypress="return numbersonly()" id="TXT_JATUH_TEMPO_DAY_ASURANSI" runat="server"
											Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_JATUH_TEMPO_MONTH_ASURANSI" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_JATUH_TEMPO_YEAR_ASURANSI" runat="server"
											Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_TYPE_PERTANGGUNGAN" runat="server">Jenis Pertanggungan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_TYPE_PERTANGGUNGAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_PERTANGGUNGAN" runat="server">Nilai Pertanggungan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NILAI_PERTANGGUNGAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PERUSAHAAN_ASURANSI" runat="server">Perusahaan Asuransi :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PERUSAHAAN_ASURANSI" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KONSORSIUM" runat="server">Konsorsium(%) :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_KONSORSIUM" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LEADER_FLAG" runat="server">Leader Flag :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:checkbox id="CHK_LEADER_FLAG" Text="(check if Yes)" Runat="Server" Font-Bold="True"></asp:checkbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENYIMPANAN_ASURANSI" runat="server">Tempat Penyimpanan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENYIMPANAN_ASURANSI" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10"><asp:label id="LBL_SEQ_ASURANSI" runat="server" Visible="False"></asp:label><asp:button id="BTN_SAVE_ASURANSI" runat="server" Width="100px" CssClass="button1" Text="INSERT" onclick="BTN_SAVE_ASURANSI_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR_ASURANSI" runat="server" Width="100px" CssClass="button1" Text="CLEAR" onclick="BTN_CLEAR_ASURANSI_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
