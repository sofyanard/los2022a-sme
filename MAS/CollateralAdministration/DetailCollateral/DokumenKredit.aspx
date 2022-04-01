<%@ Page language="c#" Codebehind="DokumenKredit.aspx.cs" AutoEventWireup="True" Inherits="SME.MAS.CollateralAdministration.DetailCollateral.DokumenKredit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DokumenKredit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../../include/cek_all.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 536px; HEIGHT: 50px"
					borderColor="gray" cellSpacing="1" cellPadding="1" width="100%" border="0">
				</TABLE>
				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td vAlign="top" align="center"></td>
					</tr>
					<tr>
						<td><ASP:DATAGRID id="DGR_DU" runat="server" AutoGenerateColumns="False" PageSize="1" CellPadding="1"
								Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="DOC_ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="DOC_DESC" HeaderText="Item">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NamaNotaris_Asuransi" HeaderText="Notaris/Asuransi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="FIX"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Avail">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHB_AT_FIX" Runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="tanggalterbit"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Tanggal Terbit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox ID="terbitday" Runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
											<asp:DropDownList ID="terbitbln" Runat="server"></asp:DropDownList>
											<asp:TextBox ID="terbitthn" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="tanggalterima"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Tanggal Terima">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox onkeypress="return numbersonly()" id="terimaday" Runat="server" MaxLength="2" Columns="2"></asp:TextBox>
											<asp:DropDownList id="terimabln" Runat="server"></asp:DropDownList>
											<asp:TextBox onkeypress="return numbersonly()" id="terimathn" Runat="server" MaxLength="4" Columns="4"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="EXPDATE"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Tanggal Expire">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox ID="TXT_EXPDATEDAY" Runat="server" Columns="2" MaxLength="2" onKeypress="return numbersonly()"></asp:TextBox>
											<asp:DropDownList ID="DDL_EXPDATEMONTH" Runat="server"></asp:DropDownList>
											<asp:TextBox ID="TXT_EXPDATEYEAR" Runat="server" Columns="4" MaxLength="4" onKeypress="return numbersonly()"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="KETERANGAN"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox ID="TXT_KETERANGAN" Runat="server" Columns="25" onKeypress="return kutip_satu()"
												TextMode="MultiLine"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="RECEIVEDDATE"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Tanggal Receive">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox onkeypress="return numbersonly()" id="TXT_RECEIVEDATEDAY" Runat="server" MaxLength="2"
												Columns="2"></asp:TextBox>
											<asp:DropDownList id="DDL_RECEIVEDATEMONTH" Runat="server"></asp:DropDownList>
											<asp:TextBox onkeypress="return numbersonly()" id="TXT_RECEIVEDATEYEAR" Runat="server" MaxLength="4"
												Columns="4"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="MANDATORY"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="delete" runat="server" CommandName="Delete">Delete</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label><input type="hidden" name="sta">
							<P align="center">&nbsp;</P>
						</td>
					</tr>
					<TR>
						<TD style="HEIGHT: 48px">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="1">
								<TR>
									<TD align="center">Item
										<asp:dropdownlist id="DDL_NEWITEM" runat="server" AutoPostBack="true" onselectedindexchanged="DDL_NEWITEM_SelectedIndexChanged"></asp:dropdownlist>
										<asp:dropdownlist id="ddl_notaris_asuransi" runat="server" Visible="False"></asp:dropdownlist>
										<asp:button id="Button1" runat="server" Text="Insert" onclick="Button1_Click"></asp:button>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center">
							<asp:button id="BTN_save" Runat="server" CssClass="button1" Text="Save" onclick="BTN_save_Click"></asp:button>
							<asp:Label id="lbl_regno2" runat="server" Visible="False" />
							<asp:Label id="lbl_col_id" runat="server" Visible="False" />
							<asp:Label id="lbl_kredit" runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
