<%@ Page language="c#" Codebehind="CollateralInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.Syndication.CustomerBasicInformation.CollateralInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>CollateralInfo</TITLE>
		<META name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<META name="CODE_LANGUAGE" Content="C#">
		<META name="vs_defaultClientScript" content="JavaScript">
		<META name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>COLLATERAL INFO</B></TD>
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
						<TD class="tdHeader1" colSpan="2">COLLATERAL</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><asp:datagrid id="DATA_GRID" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="SEQ" Visible="False">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COLL_DESC" HeaderText="Nama Jaminan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="COLL_TYPE_DESC" HeaderText="Jenis Jaminan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOC_DESC" HeaderText="Doc.Type">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NO_DOC" HeaderText="No.Dokumen">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PENGIKATAN_DESC" HeaderText="Jenis Pengikatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PENGIKATAN_VAL" HeaderText="Nilai Pengikatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="REMARK" HeaderText="Ket.Pengikatan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INSURANCE_DESC" HeaderText="Asuransi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>
											<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</asp:datagrid></TD>
					</TR>
					<TR>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NAMA_JAMINAN" runat="server">Nama Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NAMA_JAMINAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_JENIS_JAMINAN" runat="server">Jenis Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JENIS_JAMINAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_DOC_TYPE" runat="server">Document Type :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_DOC_TYPE" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NO_DOC" runat="server">Nomor Dokumen :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_NO_DOC" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PEMBERI_JAMINAN" runat="server">Pemberi Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PEMBERI_JAMINAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ALAMAT_AGUNAN" runat="server">Alamat Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_ALAMAT_AGUNAN" runat="server" Width="100%" Height="40px" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_AGUNAN" runat="server">Nilai Agunan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NILAI_AGUNAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" style="HEIGHT: 7px" vAlign="top" width="50%">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_PENERIMA_JAMINAN" runat="server">Penerima Jaminan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PENERIMA_JAMINAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_LUAS" runat="server">Luas/satuan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_LUAS" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_JENIS_PENGIKATAN" runat="server">Jenis Pengikatan :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:dropdownlist id="DDL_JENIS_PENGIKATAN" runat="server" Width="100%"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_NILAI_PENGIKATAN" runat="server">Nilai Pengikatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="TXT_NILAI_PENGIKATAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_KET_PENGIKATAN" runat="server">Keterangan Pengikatan :</asp:label></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_KET_PENGIKATAN" runat="server" Width="100%"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" width="50%"><asp:label id="LBL_TXT_ASURANSI" runat="server">Asuransi :</asp:label></TD>
									<TD class="TDBGColorValue" colSpan="2"><asp:radiobuttonlist id="RDO_ASURANSI" runat="server" Width="150px" RepeatDirection="Horizontal">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" colSpan="3" height="10">
							<asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label>
							<asp:button id="BTN_SAVE" runat="server" CssClass="button1" Width="100px" Text="INSERT" onclick="BTN_SAVE_Click"></asp:button>&nbsp;&nbsp;
							<asp:button id="BTN_CLEAR" runat="server" CssClass="button1" Width="100px" Text="CLEAR" onclick="BTN_CLEAR_Click"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</FORM>
	</BODY>
</HTML>
