<%@ Page language="c#" Codebehind="BlacklistDedupExposure.aspx.cs" AutoEventWireup="True" Inherits="SME.Approval.BlacklistDedupExposure" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BDE Checking</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TBODY>
					<TR id="tr_Blacklist_header" runat="server">
						<td class="tdheader1" vAlign="middle" colSpan="2">Blacklist Checking List</td>
					</TR>
					<tr id="tr_dg_Blacklist" runat="server">
						<td style="HEIGHT: 109px" colSpan="2"><asp:datagrid id="dg_list" runat="server" AutoGenerateColumns="False" Height="100px" AllowPaging="True"
								BorderColor="White" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ap_Regno"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BL_NAME" HeaderText="NAME">
										<HeaderStyle Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BL_IDTYPE" HeaderText="ID TYPE">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BL_IDNUMBER" HeaderText="ID NUMBER">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BL_SOURCE" HeaderText="SOURCE">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="BL_STARTDATE" HeaderText="START DATE" DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Inquiry">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id="view" runat="server">View</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="" PrevPageText="" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<TR id="tr_Deduplikasi_header" runat="server">
						<td class="tdheader1" vAlign="middle" colSpan="2">Duplicate Checking List</td>
					</TR>
					<tr id="tr_dg_Deduplikasi" runat="server">
						<td style="HEIGHT: 109px" colSpan="2"><asp:datagrid id="dg_Dedup" runat="server" AutoGenerateColumns="False" Height="100px" AllowPaging="True"
								BorderColor="White" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="ap_regno"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ap_regno_cdb"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="seq"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CUST. REFF">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="NAME">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_BORNDATE" HeaderText="DOB" DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CU_IDNUMBER" HeaderText="ID NUMBER">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="modulename" HeaderText="BUC">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ap_recvdate" HeaderText="Tgl Apply" DataFormatString="{0:dd/MM/yyyy}">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ap_status" HeaderText="Status">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="View">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
										<ItemTemplate>
											<asp:HyperLink id="view1" runat="server">View</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle NextPageText="" PrevPageText="" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<TR id="tr_Exposure_header" runat="server">
						<td class="tdheader1" vAlign="middle" colSpan="2">Total Exposure</td>
					</TR>
					<tr id="tr_dg_Exposure" runat="server">
						<td style="HEIGHT: 109px" colSpan="2"><asp:datagrid id="dg_exposure" runat="server" AutoGenerateColumns="False" Height="100px" AllowPaging="True"
								BorderColor="White" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<HeaderStyle Wrap="False" HorizontalAlign="Center"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CIF" HeaderText="CIF">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="norekening" HeaderText="NO. REKENING">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Limitkredit" HeaderText="LIMIT KREDIT" DataFormatString="{0:00,00.00}">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="bakidebet" HeaderText="BAKI DEBET" DataFormatString="{0:00,00.00}">
										<HeaderStyle Width="13%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Statusrekening" HeaderText="STATUS REKENING">
										<HeaderStyle Width="12%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Kolekbilitas" HeaderText="KOLEKTABILITAS">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="jeniskredit" HeaderText="PRODUCT NAME">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="150px"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle NextPageText="" PrevPageText="" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></td>
					</tr>
					<TR id="tr_button" runat="server">
						<td class="tdheader1" vAlign="middle" colSpan="2"><asp:button id="btn_continue" runat="server" CssClass="button1" Text="Continue" onclick="btn_continue_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="btn_reject" runat="server" CssClass="button1" Text="Reject" onclick="btn_reject_Click"></asp:button>&nbsp;&nbsp;&nbsp;
							<asp:button id="btn_rechecking" runat="server" CssClass="button1" Text="ReChecking" Visible="False" onclick="btn_rechecking_Click"></asp:button></td>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
