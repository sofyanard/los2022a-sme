<%@ Control Language="c#" AutoEventWireup="True" Codebehind="WatchlistItem.ascx.cs" Inherits="SME.LMS.WatchlistItem" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table width="100%">
	<tr>
		<TD align="center" colSpan="2">
			<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="TDBGColor1">Segmen</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_BUSSUNIT" Runat="server" AutoPostBack="True" onselectedindexchanged="DDL_BUSSUNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
				</TR>
			</TABLE>
		</TD>
	</tr>
	<tr>
		<td class="tdHeader1" width="100%" colSpan="2">Watchlist Item</td>
	</tr>
	<TR width="100%">
		<TD colSpan="2"><ASP:DATAGRID id="DGR_WATCH" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False" Width="100%"
				runat="server">
				<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="BUSSUNITID"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="WATCHID"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="SUBWATCHID"></asp:BoundColumn>
					<asp:BoundColumn DataField="WATCHDESC" HeaderText="Watchlist Item">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SUBWATCHDESC" HeaderText="Watchlist Sub Item">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Watchlist Sub Sub Item">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
						<ItemTemplate>
							<asp:radiobuttonlist id="RBL_SUBSUBWATCH" runat="server" RepeatDirection="Horizontal"></asp:radiobuttonlist>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="ISWATCHLISTDESC" HeaderText="Watchlist">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ISMANDATORYDESC" HeaderText="Mandatory">
						<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle Mode="NumericPages"></PagerStyle>
			</ASP:DATAGRID></TD>
	</TR>
	<tr>
		<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button></td>
	</tr>
	<TR>
		<TD class="tdHeader1" colSpan="2">Watchlist Summary</TD>
	</TR>
	<TR>
		<TD align="center" colSpan="2">
			<TABLE id="Table2" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="TDBGColor1">Kategori</TD>
					<TD style="WIDTH: 15px">:</TD>
					<TD class="TDBGColorValue"><asp:textbox id="TXT_KATEGORI" Width="300px" runat="server" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1">Faktor Penyebab</TD>
					<TD>:</TD>
					<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_FAKTOR" Width="300px" runat="server" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
				</TR>
				<TR>
					<TD class="TDBGColor1">Follow Up</TD>
					<TD>:</TD>
					<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_FOLLOW" Width="300px" runat="server" BorderStyle="None" ReadOnly="True"></asp:textbox></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</table>
