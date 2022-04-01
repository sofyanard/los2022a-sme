<%@ Page language="c#" Codebehind="NotaryLegalSigning.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditOperations.NotaryAssignment.NotaryLegalSigning" %>
<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../../CommonForm/DocumentUpload.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NotaryLegalSigning</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../style.css" type="text/css" rel="stylesheet">
		<!-- #include file = "../../include/cek_all.html" -->
		<!-- #include file="../../include/OpenWindow.html" -->
		<script language="javascript">
			function deleteconfirm()
			{
				conf = confirm("Are you sure you want to delete?");
				if (conf)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Notary Assignment : 
											Notary Legal Signing</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../../Body.aspx"><IMG src="/SME/Image/MainMenu.jpg"></A><A href="../../Logout.aspx" target="_top"><IMG src="/SME/Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<tr>
						<td class="tdHeader1" colSpan="2">Notaris</td>
					</tr>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DG_NOTARY" runat="server" AutoGenerateColumns="False" PageSize="5" CellPadding="1"
								AllowPaging="True" Width="100%">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="NTID"></asp:BoundColumn>
									<asp:BoundColumn DataField="NT_NAME" HeaderText="Nama Notaris">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NT_ADDRESS" HeaderText="Alamat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
									<asp:BoundColumn DataField="CL_DESC" HeaderText="Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Detail Proses">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:datagrid id="DG_DETAIL" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
												AllowPaging="True" PageSize="10">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="SUBSEQ"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="ITEMPEKERJAAN"></asp:BoundColumn>
													<asp:BoundColumn DataField="PEKERJAANDESC" HeaderText="Item Pekerjaan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="NA_FINISHDATE" HeaderText="Target Penyelesaian" DataFormatString="{0:dd-MMM-yyyy}">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="BTNEDIT" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="BTNDEL" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<tr>
						<td class="td" colSpan="2">
							<TABLE cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<TABLE cellSpacing="0" cellPadding="0">
											<tr>
												<td class="TDBGColor1" width="150">Nama Notaris</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_NT_NAME" ReadOnly="True" Runat="server" Columns="35"></asp:textbox><INPUT id="BTN_SEARCH_NOTARY" onclick="openSetWindow('SearchNotary.aspx?targetFormID=Form1&amp;targetObjectID=TXT_NTID&amp;targetObjectDesc=TXT_NT_NAME', '460', '232');"
														type="button" size="20" value="..." name="BTN_SEARCH_NOTARY" runat="server">
													<asp:textbox id="TXT_NTID" Width="1px" Runat="server" 
                                                        ontextchanged="TXT_NTID_TextChanged"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1" vAlign="top">Alamat</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_NT_ADDR1" ReadOnly="True" Runat="server" Columns="35"></asp:textbox><br>
													<asp:textbox id="TXT_NT_ADDR2" ReadOnly="True" Runat="server" Columns="35"></asp:textbox><br>
													<asp:textbox id="TXT_NT_ADDR3" ReadOnly="True" Runat="server" Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kota</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_NT_CITY" ReadOnly="True" Runat="server" Columns="35"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
									<td class="td" vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0">
											<tr>
												<td class="TDBGColor1" width="150">&nbsp;E-mail</td>
												<td width="15"></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_NT_EMAIL" ReadOnly="True" Runat="server" Columns="35"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">No Telepon</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_NT_PHNAREA" ReadOnly="True" Runat="server" Columns="5"></asp:textbox><asp:textbox id="TXT_NT_PHNNUM" ReadOnly="True" Runat="server" Columns="15"></asp:textbox><asp:textbox id="TXT_NT_PHNEXT" ReadOnly="True" Runat="server" Columns="5"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Fax</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_NT_FAXAREA" ReadOnly="True" Runat="server" Columns="5"></asp:textbox><asp:textbox id="TXT_NT_FAXNUM" Runat="server" Columns="15"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGColor1">Kode Pos</td>
												<td></td>
												<td class="TDBGColorValue"><asp:textbox id="TXT_NT_ZIPCODE" ReadOnly="True" Runat="server" Columns="6"></asp:textbox></td>
											</tr>
										</TABLE>
									</td>
								</tr>
							</TABLE>
						</td>
					</tr>
					<tr>
						<td class="td" colSpan="2">
							<table cellSpacing="2" cellPadding="2" width="100%">
								<tr>
									<td class="td" vAlign="top" width="50%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="TDBGCOLOR1" width="150">Tanggal</td>
												<td width="15"></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_NA_APPNTDATETIMEDAY" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_NA_APPNTDATETIMEMONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_NA_APPNTDATETIMEYEAR" Runat="server" Columns="4"
														MaxLength="4"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">Jam</td>
												<td></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_NA_APPNTDATETIMEHOUR" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox>:
													<asp:textbox onkeypress="return numbersonly()" id="TXT_NA_APPNTDATETIMEMINUTE" Runat="server"
														Columns="2" MaxLength="2"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1" vAlign="top" width="150">Catatan</td>
												<td width="15"></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NA_REMARKS" Runat="server" Columns="40"
														MaxLength="100" TextMode="MultiLine" Height="50" Rows="4"></asp:textbox></td>
											</tr>
											<tr>
												<td><asp:label id="LBL_SEQ" Runat="server" Visible="False"></asp:label></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">Agunan</td>
												<td width="15"></td>
												<td class="TDBGCOLORValue"><asp:dropdownlist id="DDL_COL" Runat="server"></asp:dropdownlist></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">No. Cover Note</td>
												<td></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NA_COVERNO" Runat="server" Columns="25"
														MaxLength="20"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">Tanggal Cover Note</td>
												<td></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDATE_DAY" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_COVERDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDATE_YEAR" Runat="server" Columns="4"
														MaxLength="4"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">Tanggal Jatuh Tempo Cover Note</td>
												<td></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDUEDATE_DAY" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_COVERDUEDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_COVERDUEDATE_YEAR" Runat="server" Columns="4"
														MaxLength="4"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">No. Surat Order ke Notaris</td>
												<td></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NA_ORDERNO" Runat="server" Columns="25"
														MaxLength="20"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">Tanggal Surat Order ke Notaris</td>
												<td></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_ORDERDATE_DAY" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_ORDERDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_ORDERDATE_YEAR" Runat="server" Columns="4"
														MaxLength="4"></asp:textbox></td>
											</tr>
											<tr>
												<td class="TDBGCOLOR1">Tanggal PK</td>
												<td></td>
												<td class="TDBGCOLORValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_PKDATE_DAY" Runat="server" Columns="2"
														MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_PKDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_PKDATE_YEAR" Runat="server" Columns="4"
														MaxLength="4"></asp:textbox></td>
											</tr>
										</table>
									</td>
									<td class="td" vAlign="top">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td class="tdHeader1" colSpan="2">Detail Proses</td>
											</tr>
											<tr>
												<td class="td" vAlign="top" width="50%">
													<table cellSpacing="0" cellPadding="0" width="100%">
														<TR width="100%">
															<TD colSpan="3"><ASP:DATAGRID id="DG_PROCESS" runat="server" AutoGenerateColumns="False" PageSize="5" CellPadding="1"
																	AllowPaging="True" Width="100%">
																	<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
																	<Columns>
																		<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
																		<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
																		<asp:BoundColumn Visible="False" DataField="SUBSEQ"></asp:BoundColumn>
																		<asp:BoundColumn Visible="False" DataField="ITEMPEKERJAAN"></asp:BoundColumn>
																		<asp:BoundColumn DataField="PEKERJAANDESC" HeaderText="Item Pekerjaan">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Left"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="NA_FINISHDATE" HeaderText="Target Penyelesaian" DataFormatString="{0:dd-MMM-yyyy}">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:TemplateColumn HeaderText="Function">
																			<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																			<ItemTemplate>
																				<asp:LinkButton id="BTNEDIT2" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
																				<asp:LinkButton id="BTNDEL2" runat="server" CommandName="delete">Delete</asp:LinkButton>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																	</Columns>
																	<PagerStyle Mode="NumericPages"></PagerStyle>
																</ASP:DATAGRID></TD>
														</TR>
														<tr>
															<td class="TDBGCOLOR1">Jenis Item Pekerjaan</td>
															<td width="15"></td>
															<td class="TDBGCOLORValue"><asp:dropdownlist id="DDL_NA_ITEM" Runat="server"></asp:dropdownlist></td>
														</tr>
														<tr>
															<td class="TDBGCOLOR1">Target Penyelesaian</td>
															<td></td>
															<td class="TDBGCOLORValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_FINISHDATE_DAY" Runat="server" Columns="2"
																	MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_FINISHDATE_MONTH" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_FINISHDATE_YEAR" Runat="server" Columns="4"
																	MaxLength="4"></asp:textbox></td>
														</tr>
														<tr>
															<td><INPUT id="Button2" onclick="openSetWindow('InfoItemPekerjaan.aspx?', '480', '480');" type="button"
																	size="200" value="Info Item Pekerjaan" name="BTN_INFO" runat="server">
																<asp:label id="LBL_SUBSEQ" Runat="server" Visible="False"></asp:label></td>
														</tr>
														<TR>
															<TD class="TDBGColor2" align="center" width="100%" colSpan="3">
                                                                <asp:button id="BTN_SAVE2" Runat="server" Text="Simpan Detail Proses" 
                                                                    CssClass="button1" onclick="BTN_SAVE2_Click"></asp:button>&nbsp;
																<asp:button id="BTN_CLEAR2" Runat="server" Text="Hapus" CssClass="button1" 
                                                                    onclick="BTN_CLEAR2_Click"></asp:button></TD>
														</TR>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="TDBGColor2" align="center" colSpan="2"><asp:button id="BTN_SAVE" 
                                Runat="server" Text="Simpan Data Notaris" CssClass="button1" 
                                onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="BTN_CLEAR" Runat="server" Text="Hapus" CssClass="button1" 
                                onclick="BTN_CLEAR_Click"></asp:button>
							<%if(Request.QueryString["na"] != "2") {%>
							<asp:label id="LBL_REGNO" Runat="server" Visible="False"></asp:label><asp:label id="LBL_CUREF" Runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" Runat="server" Visible="False"></asp:label>
							<%}%>
						</TD>
					</TR>
					<tr>
                        <td colspan="2">
                            <uc1:docupload id="DocUpload1" runat="server"></uc1:docupload>
                        </td>
                    </tr>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
