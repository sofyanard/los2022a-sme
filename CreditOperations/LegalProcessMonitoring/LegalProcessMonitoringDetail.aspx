<%@ Page language="c#" Codebehind="LegalProcessMonitoringDetail.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.LegalProcessMonitoring.LegalProcessMonitoringDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LegalProcessMonitoringDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../../include/onepost.html" -->
		<!-- #include file="../../include/ConfirmBox.html" -->
		<!-- #include  file="../../include/popup.html" -->
        <%= popUp%>
		<script language="javascript">
			/**
			function update()
			{
				conf = confirm("Are you sure you want to update?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}**/
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Legal Processing 
											Monitoring : List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right">
							<asp:ImageButton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:ImageButton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">Info Pemohon</td>
					</tr>
					<tr>
						<td colSpan="2">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">No Aplikasi</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox><asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Referensi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Aplikasi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Sub-Segment/Program</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Supervisi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_TMLDRNM" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Analis</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Segmen</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BU_DESC" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Pemohon</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" vAlign="top">Alamat</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR2" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR3" Columns="35" ReadOnly Runat="server" Width="300px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Telp</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Bidang Usaha</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Columns="35" ReadOnly Runat="server" Width="300px" BorderStyle="None"></asp:textbox></td>
											</tr>
											<TR>
												<TD class="TDBGColor1">Notaris</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_NT_NAME" Runat="server" ReadOnly BorderStyle="None" ColumnsWidth="300px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Rating</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="DDL_RATE" Runat="server"></asp:dropdownlist>
													<asp:label id="LBL_H_RATEID" Runat="server" Visible="False"></asp:label>
													<asp:label id="LBL_H_NTID" Runat="server" Visible="False"></asp:label></TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td colSpan="2">
							<table id="tbl_acqinfo" runat="server" cellSpacing="0" cellPadding="0" width="100%">
								<tr>
									<td align="center">
									
									<iframe id="if1" style="WIDTH: 100%; HEIGHT: 200px" name="if1" scrolling="no" src="../../Approval/Acqinfo.aspx?regno=<%=Request.QueryString["regno"]%>&curef=<%=Request.QueryString["curef"]%>&prod=<%=Request.QueryString["prod"]%>&sta=view"></iframe>
									
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2"><b>Notaris</b></td>
					</tr>
					<tr>
						<TD colSpan="2"><ASP:DATAGRID id="Datagrid1" runat="server" CellPadding="1" Width="100%" PageSize="5" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Fasilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="LEGALSTADESC" HeaderText="Dokumen Legal">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NT_NAME" HeaderText="Nama Notaris">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NA_APPNTDATETIME" HeaderText="Tanggal Meeting">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Notary Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_NOTARYSTATUS" runat="server"></asp:Image>
											<asp:Label id="LBL_NOTARYSTATUS" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="NOTARYSTATUS"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_NOTARYSTATUS" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID"></asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</tr>
					<tr>
						<TD colSpan="2"><ASP:DATAGRID id="Datagrid2" runat="server" CellPadding="1" Width="100%" PageSize="5" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CL_DESC" HeaderText="Jaminan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IKATDESC" HeaderText="Dokumen Legal">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NT_NAME" HeaderText="Nama Notaris">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NA_APPNTDATETIME" HeaderText="Tanggal Meeting">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Notary Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_NOTARYSTATUS2" runat="server"></asp:Image>
											<asp:Label id="LBL_NOTARYSTATUS2" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="NOTARYSTATUS"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_NOTARYSTATUS2" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</tr>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Text="Simpan" 
                                onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_UPDATE" runat="server" Text="Update Status" CssClass="Button1" onclick="BTN_UPDATE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_RETURNTOBU" Runat="server" CssClass="button1" 
                                Text="Kembali Ke Konfirmasi" onclick="BTN_RETURNTOBU_Click"></asp:button>
							<asp:textbox id="TXT_TEMP" runat="server" BorderStyle="None" Width="1px" ontextchanged="TXT_TEMP_TextChanged"></asp:textbox>
						</TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
