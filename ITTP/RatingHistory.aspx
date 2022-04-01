<%@ Page language="c#" Codebehind="RatingHistory.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.RatingHistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RatingHistory</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="fListApp" method="post" runat="server">
			<center>
				<table id="Table1" cellSpacing="2" cellPadding="2" width="1196">
					<TR>
						<TD class="tdHeader1" colSpan="2">Rating History</TD>
					</TR>
					<tr>
						<td style="WIDTH: 100%" colSpan="2"><asp:datagrid id="dgratinghistory" runat="server" AutoGenerateColumns="False" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="Ref #">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="REGNO"></asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Application Date" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KATEGORI" HeaderText="Klasifikasi">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="profilrisk" HeaderText="Profil Risiko">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RISKAPPETITE" HeaderText="Risk Appetite">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="KLASIFIKASIID" HeaderText="Kategori">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="riskprof" HeaderText="Kategori Risk Profile Produk">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="catatan" HeaderText="Catatan">
										<HeaderStyle Width="25%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Detail Input" CommandName="View">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
							<asp:label id="lbl_prod" runat="server" MaxLength="20" Columns="30" Width="176px" Visible="False"></asp:label>
							<asp:label id="lbl_apptype" runat="server" MaxLength="20" Columns="30" Width="176px" Visible="False"></asp:label>
							<asp:label id="lbl_track" runat="server" MaxLength="20" Columns="30" Width="176px" Visible="False"></asp:label>
							<asp:label id="lbl_userid" runat="server" Visible="False"></asp:label>
						</td>
					</tr>
				</table>
			</center>
		</form>
	</body>
</HTML>
