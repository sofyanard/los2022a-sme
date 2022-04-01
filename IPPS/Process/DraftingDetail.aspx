<%@ Page language="c#" Codebehind="DraftingDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.IPPS.Process.DraftingDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DraftingDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="100%">
				<tr>
					<td><asp:label id="LBL_REQ_DISP" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td class="tdHeader1">Format</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr>
								<td vAlign="top" width="50%">
									<TABLE id="Table9" cellSpacing="1" cellPadding="2" width="100%">
										<TR>
											<TD class="TDBGColor1">Nama</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox id="TXT_DRAFT_NAME" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Edisi</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox id="TXT_DRAFT_EDITION" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Revisi</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue" style="HEIGHT: 20px"><asp:textbox id="TXT_DRAFT_REVISION" runat="server"></asp:textbox></TD>
										</TR>
									</TABLE>
								</td>
								<td vAlign="top" width="50%">
									<TABLE id="Table65" cellSpacing="1" cellPadding="2" width="100%">
										<TR>
											<TD class="TDBGColor1">Berlaku Sejak Tgl.</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_OLD_DATE_DAY" runat="server" MaxLength="2"
													Columns="3"></asp:textbox><asp:dropdownlist id="DDL_OLD_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_OLD_DATE_YEAR" runat="server" MaxLength="4"
													Columns="5"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Tgl. yang digantikan</TD>
											<TD style="WIDTH: 15px">:</TD>
											<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_NEW_DATE_DAY" runat="server" MaxLength="2"
													Columns="3"></asp:textbox><asp:dropdownlist id="DDL_NEW_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_NEW_DATE_YEAR" runat="server" MaxLength="4"
													Columns="5"></asp:textbox></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
							<tr>
							<TR>
								<TD class="tdbgcolor2" colSpan="2"><asp:button id="BTN_SAVE_DRAFT" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_DRAFT_Click"></asp:button></TD>
							</TR>
						</table>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<TABLE width="100%">
							<TR>
								<TD class="tdHeader1" colSpan="2">Out Line</TD>
							</TR>
							<TR>
								<TD class="tdHeader1" width="50%">Existing</TD>
								<TD class="tdHeader1" width="50%">Revise / New</TD>
							</TR>
							<TR>
								<TD><asp:textbox id="TXT_OLD_OUTLINE" runat="server" width="100%" Rows="10" TextMode="MultiLine"></asp:textbox></TD>
								<TD><asp:textbox id="TXT_NEW_OUTLINE" runat="server" width="100%" Rows="10" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="tdbgcolor2" colSpan="2"><asp:button id="BTN_SAVE_OUTLINE" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_OUTLINE_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<table width="100%">
							<tr>
								<td class="tdHeader1">Contain</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td class="TDBGColor1">Jumlah BAB :</td>
								<td><asp:dropdownlist id="DDL_BAB" runat="server"></asp:dropdownlist>&nbsp;
									<asp:button id="btn_insert_jmlh_bab" runat="server" Text="Insert" onclick="btn_insert_jmlh_bab_Click"></asp:button></td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td width="100%"><ASP:DATAGRID id="DG_CONTAIN" runat="server" AutoGenerateColumns="False" Width="100%">
										<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
										<Columns>
											<asp:BoundColumn DataField="IPPS_REGNO" Visible="False" />
											<asp:BoundColumn DataField="REQ_SEQ" Visible="False" />
											<asp:BoundColumn DataField="CNT_SEQ" Visible="False" />
											<asp:BoundColumn DataField="CHAPTER" HeaderText="Bab">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OLD_CONTAIN" Visible="False" />
											<asp:TemplateColumn HeaderText="Old">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox ID="TXT_OLD_CONTAIN" Runat="server" Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="NEW_CONTAIN" Visible="False" />
											<asp:TemplateColumn HeaderText="Revise/New">
												<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:TextBox ID="TXT_NEW_CONTAIN" Runat="server" Rows="10" TextMode="MultiLine" Width="100%"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</ASP:DATAGRID></td>
							</tr>
							<tr>
								<td class="tdbgcolor2" colSpan="2"><asp:button id="BTN_SAVE_CONTAIN" runat="server" CssClass="button1" Text="Save" onclick="BTN_SAVE_CONTAIN_Click"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
