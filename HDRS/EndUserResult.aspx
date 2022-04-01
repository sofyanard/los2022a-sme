<%@ Page language="c#" Codebehind="EndUserResult.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.EndUserResult" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EndUserResult</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_all.html" -->
		<!-- #include file="../include/popup.html" --><LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function keluar()
		{
			if (confirm("Are you sure want to finish ?"))
				document.Fmain.submit();
		}
		
			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder">
								<TABLE id="Table8">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>END USER RESULT</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_MENU" runat="server" ImageUrl="../Image/MainMenu.jpg" onclick="BTN_MENU_Click"></asp:imagebutton><asp:imagebutton id="BTN_LOGOUT" runat="server" ImageUrl="../Image/Logout.jpg" onclick="BTN_LOGOUT_Click"></asp:imagebutton></TD>
						<TR id="TR_ACQ" runat="server">
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:hyperlink id="HL_ACQ" runat="server" ForeColor="Blue" Visible="False">Acquire Info</asp:hyperlink></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">END USER INFO</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">Area/Group</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AREA" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Unit</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_UNIT" runat="server" Width="300px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
								</TABLE>
								<asp:label id="LBL_r" runat="server" Visible="False"></asp:label><asp:label id="LBL_REKANANTYPEID" runat="server" Visible="False"></asp:label><asp:label id="LBL_AP_PROG_CODE" runat="server" Visible="False"></asp:label></TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1">HRS#</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_HRS" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="150">Tanggal Entry</TD>
										<TD style="WIDTH: 15px">:</TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_TGL" runat="server" Width="300px" ReadOnly="True"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">SEND MESSAGE</TD>
						</TR>
						<tr align="center">
							<td vAlign="top" width="100%" colSpan="2">
								<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
									<TR>
										<TD align="center" width="15%" bgColor="#b5c7e7"><STRONG>APPLICATION</STRONG></TD>
										<TD align="center" width="17%" bgColor="#b5c7e7"><STRONG>CUSTOMER NAME</STRONG></TD>
										<TD align="center" width="18%" bgColor="#b5c7e7"><STRONG>PROBLEM TYPE</STRONG></TD>
										<TD align="center" width="50%" bgColor="#b5c7e7"><STRONG>DESCRIPTION</STRONG></TD>
									</TR>
									<tr>
										<td align="center" width="15%" valign="top"><asp:textbox id="TXT_NO_AP" Width="100%" ReadOnly="True" CssClass="Mandatory" Runat="server"></asp:textbox></td>
										<td align="center" width="17%" valign="top"><asp:textbox id="TXT_CUST" Width="100%" ReadOnly="True" CssClass="Mandatory" Runat="server"></asp:textbox></td>
										<td align="center" width="18%" valign="top"><asp:dropdownlist id="DDL_PROBLEM" Width="100%" CssClass="Mandatory" Runat="server" Enabled="False"></asp:dropdownlist></td>
										<td align="center" width="50%" valign="top"><asp:textbox id="TXT_DESC" Width="100%" ReadOnly="True" Runat="server" MaxLength="8000" TextMode="MultiLine"
												Height="150px" CssClass="Mandatory"></asp:textbox></td>
									</tr>
								</table>
							</td>
						</tr>
						<TR>
							<TD vAlign="top" width="100%" colSpan="2" rowSpan="2">
								<table cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><ASP:DATAGRID id="DATA_EXPORT" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
												CellPadding="1" PageSize="5">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="ID_UPLOAD_HELPDESK" HeaderText="No">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle Width="50%"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="FILE_UPLOAD_HELPDESK_NAME" HeaderText="Destination File">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id="UPL_HELPDESK_DOWNLOAD" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
								</table>
							</TD>
						<tr>
							<td></td>
						</tr>
						<TR>
							<TD class="tdHeader1" colSpan="2">RESPON</TD>
						</TR>
						<tr align="center">
							<td vAlign="top" width="100%" colSpan="2">
								<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="1">
									<TR>
										<TD align="center" width="30%" bgColor="#b5c7e7"><STRONG>DESCRIPTION</STRONG></TD>
									</TR>
									<tr>
										<td align="center" width="30%"><asp:textbox id="TXT_RESPON" Width="100%" ReadOnly="True" CssClass="Mandatory" Runat="server"
												MaxLength="8000" TextMode="MultiLine" Height="150px"></asp:textbox></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<TD vAlign="top" width="100%" colSpan="2" rowSpan="2">
								<table cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD><ASP:DATAGRID id="DATA_EXPORT_RESPON" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
												CellPadding="1" PageSize="5">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" HeaderText="No">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle Width="10px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="FILE_UPLOAD_HELPDESK_NAME_RESPON" HeaderText="Destination File">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="50%" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id="UPL_HELPDESK_DOWNLOAD2" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
									<tr>
										<td></td>
									</tr>
									<tr align="center">
										<td class="TDBGColor2" vAlign="top" align="center" width="100%" colSpan="2">&nbsp;&nbsp;&nbsp;
											<asp:button id="BTN_ACQ" runat="server" Width="121px" CssClass="Button1" Text="ACQUIRE INFO" onclick="BTN_ACQ_Click"></asp:button><asp:textbox id="TXT_TEMP" runat="server" Width="1px" ReadOnly="True" BorderStyle="None"></asp:textbox>&nbsp;&nbsp;
											<asp:button id="BTN_FINISH" runat="server" Width="65px" CssClass="Button1" Text="FINISH" onclick="BTN_FINISH_Click"></asp:button></td>
									</tr>
								</table>
								<table id="Table41" cellSpacing="0" cellPadding="0" width="100%">
									<tr>
										<td align="center"><asp:placeholder id="Placeholder2" runat="server"></asp:placeholder><asp:label id="lbl_regnum" runat="server" Visible="False"></asp:label><asp:label id="HTH_TRACKBY1" runat="server" Visible="False"></asp:label><asp:label id="HTH_TRACKBY_NEXT" runat="server" Visible="False"></asp:label><asp:label id="TXT_SEND_BY" runat="server" Visible="False"></asp:label><asp:label id="HTH_PICTRACK" runat="server" Visible="False"></asp:label></td>
									</tr>
								</table>
								<table width="100%">
									<TR>
										<TD><ASP:DATAGRID id="DGR_SLA" runat="server" Visible="False" Width="100%" AutoGenerateColumns="False"
												CellPadding="1" PageSize="5">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="HTH_HRS#">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="HTH_TRACKCODE">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="HTH_TRACKDATE">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="HTH_TRACKBY">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="HTH_STATUSBY">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="SEQ">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
									<TR>
										<TD><ASP:DATAGRID id="DGR_PIC" runat="server" Visible="False" Width="100%" AutoGenerateColumns="False"
												CellPadding="1" PageSize="5">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="H_HRS#">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle Width="10px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="PIC_ASSIGN">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</ASP:DATAGRID></TD>
									</TR>
								</table>
		</form>
		</TD></TR></TBODY></TABLE></CENTER>
	</body>
</HTML>
