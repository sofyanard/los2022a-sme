<%@ Page language="c#" Codebehind="DocumentTrackingSend.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.DocumentTrackingSend" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DocumentTrackingSend</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Document Tracking</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"></td>
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
												<td class="TDBGColor1" style="HEIGHT: 6px" width="150">Application No.</td>
												<td style="HEIGHT: 6px" width="15"></td>
												<td class="TDBGColorValue" style="HEIGHT: 6px"><asp:textbox id="TXT_AP_REGNO" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Reference No.</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Tanggal Aplikasi</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_SIGNDATE" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Sub-Segment/Program</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_PROGRAMDESC" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Cabang/CBC/Group</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_NAME" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Team Leader</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_TMLDRNM" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Relationship Manager</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_AP_RMNM" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Business Unit</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BU_DESC" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGColor1" width="150">Nama Pemohon</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_NAME" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" vAlign="top">Alamat</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR1" Runat="server" ReadOnly Width="297px"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR2" Runat="server" ReadOnly Width="297px"></asp:textbox><br>
													<asp:textbox id="TXT_CU_ADDR3" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_CITYNM" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No. Telp</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_CU_PHN" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Bidang Usaha</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_BUSSTYPEDESC" Runat="server" ReadOnly Width="297px"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="tdHeader1" colSpan="2">Document Tracking Data</td>
					</tr>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" CellPadding="1" PageSize="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOCTYPEDESC" HeaderText="Jenis">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DOCDESC" HeaderText="Deskripsi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AT_KETERANGAN" HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Available">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_AT_FIX" runat="server"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AT_FIX"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Original">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_ORIGINAL" runat="server"></asp:CheckBox>
											<asp:Image id="IMG_ORIGINAL" runat="server"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="ORIGINAL"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Send To">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:DropDownList id="DDL_SENDTO" runat="server"></asp:DropDownList>
											<asp:Label id="LBL_SENDTO" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Send Purpose">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:DropDownList id="DDL_PURPOSEID" runat="server"></asp:DropDownList>
											<asp:Label id="LBL_DTP_DESC" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Notes">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox id="TXT_NOTES" runat="server"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="NOTES"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="RECVBY"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DOCTYPEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DOCID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PURPOSEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SENDTO"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Send">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="CHK_SEND" runat="server"></asp:CheckBox>
											<asp:Image id="IMG_SEND" runat="server"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="SENDINGTONAME"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DTP_DESC"></asp:BoundColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_ACTION" Runat="server" CssClass="button1" Text="CONFIRM SEND" onclick="BTN_ACTION_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
