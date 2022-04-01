<%@ Page language="c#" Codebehind="Housekeeping.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.Housekeeping" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Housekeeping</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<script language="javascript">
		function cek_mandatory(frm, mandatoryType, alamat)
		{
			max_elm = (frm.elements.length) - 2;
			lanjut = true;
			for (var i=1; i<=max_elm; i++)
			{
				elm = frm.elements[i];
				if (elm.className == "mandatory" + mandatoryType
					&& (elm.value == "" || elm.value == "0" || elm.value == "0,00") 
					&& (elm.type == "text" || elm.type == "select-one"))
				{
					r = elm.parentElement.parentElement;
					d = r.cells(0).innerText;
					alert(d + " tidak boleh kosong...");
					lanjut = false;
					elm.focus();
					return false;
				}
			}
			if (lanjut)
			{

				if (alamat != undefined && alamat != "" )
					frm.action = alamat;

				return true;
			}
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 21px">
						<TABLE style="WIDTH: 408px; HEIGHT: 17px" cellSpacing="0" cellPadding="0" width="408">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>House Keeping Application</B></TD>
							</TR>
						</TABLE>
						<asp:dropdownlist id="DDL_RFMODULE" runat="server" Visible="False" Enabled="False"></asp:dropdownlist>
						<A href="Body.aspx"></A>
					</TD>
					<TD style="HEIGHT: 21px" align="right">
						<!-- imagebutton BTN_BACK dihide karena kayaknya ga butuh diproses di server --><asp:imagebutton id="BTN_BACK" runat="server" Visible="False" ImageUrl="../Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/Back.jpg"></A>
						<A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A> <A href="../Logout.aspx" target="_top">
							<IMG src="../Image/Logout.jpg"></A>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="td" style="HEIGHT: 21px" align="center" bgColor="#ffff66" colSpan="2"><STRONG>PERHATIAN 
							: Aplikasi yang di-archive adalah aplikasi yang sudah BOOKING, aplikasi yang 
							sudah REJECT maupun aplikasi yang sudah&nbsp;CANCEL.
							<BR>
							Dengan demikian, 'Last Track Date' adalah&nbsp;tanggal pada saat BOOKING, 
							REJECT maupun CANCEL</STRONG></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px" align="center" colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="td" colSpan="2">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdHeader1">Archive Application to House Keeping Database
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1">Last Track&nbsp;Date</TD>
											<TD width="15"></TD>
											<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_DATE1" runat="server" MaxLength="2" Width="32px"
													CssClass="mandatory01"></asp:textbox><asp:dropdownlist id="DDL_MONTH1" runat="server" CssClass="mandatory01"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR1" runat="server" MaxLength="4" Width="82px"
													CssClass="mandatory01"></asp:textbox>&nbsp;s.d
												<asp:textbox onkeypress="return numbersonly()" id="TXT_DATE2" runat="server" MaxLength="2" Width="32px"
													CssClass="mandatory01"></asp:textbox><asp:dropdownlist id="DDL_MONTH2" runat="server" CssClass="mandatory01"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR2" runat="server" MaxLength="4" Width="82px"
													CssClass="mandatory01"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD width="15"></TD>
											<TD class="TDBGColorValue">
												<asp:button id="BTN_ARC_NEXT" runat="server" Text="VIEW APPLICATIONS" onclick="BTN_ARC_NEXT_Click"></asp:button>&nbsp;(To 
												view applications to be archived)</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD width="15"></TD>
											<TD class="TDBGColorValue">
												<asp:button id="BTN_ARC_HISTORY" runat="server" Text="VIEW LAST ARCHIVE" onclick="BTN_ARC_HISTORY_Click"></asp:button>&nbsp;(To 
												view last archived applications)</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD><asp:label id="LBL_RESULT" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<TABLE id="TBL_ARC_HISTORY" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
										<TR>
											<TD class="tdHeader1">
												<asp:Label id="LBL_TITLE_ARCHIVE" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD>
												Results&nbsp;:
												<asp:Label id="LBL_ARCHIVE_COUNT" runat="server"></asp:Label>&nbsp;item(s)</TD>
										</TR>
										<TR>
											<TD><asp:datagrid id="DGR_ARC_HISTORY" runat="server" Width="100%" AutoGenerateColumns="False">
													<Columns>
														<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="Application Date" DataFormatString="{0:dd-MMM-yyyy}">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CU_FULLNAME" HeaderText="Customer Name">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Product">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PROD_SEQ" HeaderText="SEQ">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="LASTTRACKDATE" HeaderText="Last Track Date" DataFormatString="{0:dd-MMM-yyyy}">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="LASTTRACKNAME" HeaderText="Last Track">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2"><asp:button id="BTN_BACKUP" runat="server" Width="107px" Text="Archive " CssClass="Button1" onclick="BTN_BACKUP_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="td" colSpan="2">
						<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdHeader1">Restore Application from House Keeping Database</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1">Last Track&nbsp;Date</TD>
											<TD width="15"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox onkeypress="return numbersonly()" id="TXT_DATE1_R" runat="server" Width="32px" MaxLength="2"
													CssClass="mandatory02"></asp:textbox>
												<asp:dropdownlist id="DDL_MONTH1_R" runat="server" CssClass="mandatory02"></asp:dropdownlist>
												<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR1_R" runat="server" Width="82px" MaxLength="4"
													CssClass="mandatory02"></asp:textbox>&nbsp;s.d
												<asp:textbox onkeypress="return numbersonly()" id="TXT_DATE2_R" runat="server" Width="32px" MaxLength="2"
													CssClass="mandatory02"></asp:textbox>
												<asp:dropdownlist id="DDL_MONTH2_R" runat="server" CssClass="mandatory02"></asp:dropdownlist>
												<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR2_R" runat="server" Width="82px" MaxLength="4"
													CssClass="mandatory02"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD width="15"></TD>
											<TD class="TDBGColorValue">
												<asp:button id="BTN_REST_NEXT" runat="server" Text="VIEW APPLICATIONS" onclick="BTN_REST_NEXT_Click"></asp:button>&nbsp;(To 
												view applications to be restored)</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD width="15"></TD>
											<TD class="TDBGColorValue">
												<asp:button id="BTN_REST_HISTORY" runat="server" Text="VIEW LAST RESTORE" onclick="BTN_REST_HISTORY_Click"></asp:button>&nbsp;(To 
												view last restored applications)</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD><asp:label id="LBL_RESULT_RESTORE" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
									<TABLE id="TBL_REST_HISTORY" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
										<TR>
											<TD class="tdHeader1">
												<asp:Label id="LBL_TITLE_RESTORE" runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD>Results&nbsp;:
												<asp:Label id="LBL_RESTORE_COUNT" runat="server"></asp:Label>&nbsp;item(s)</TD>
										</TR>
										<TR>
											<TD>
												<asp:datagrid id="DGR_REST_HISTORY" runat="server" Width="100%" AutoGenerateColumns="False">
													<Columns>
														<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="Application Date" DataFormatString="{0:dd-MMM-yyyy}">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CU_FULLNAME" HeaderText="Customer Name">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Product">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PROD_SEQ" HeaderText="SEQ">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="LASTTRACKDATE" HeaderText="Last Track Date" DataFormatString="{0:dd-MMM-yyyy}">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="LASTTRACKNAME" HeaderText="Last Track">
															<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
												</asp:datagrid></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2"><asp:button id="BTN_RESTORE" runat="server" Width="107px" Text="Restore" CssClass="Button1" onclick="BTN_RESTORE_Click"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:textbox onkeypress="return kutip_satu()" id="TXT_APPNO_RESTORE" runat="server" Visible="False"
							Width="300px"></asp:textbox>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="td" colSpan="2">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdHeader1">Delete Application from House Keeping Database</TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#ff6666"><STRONG style="COLOR: #ffffff">PERHATIAN : 
										Aplikasi yang dimasukkan akan dihapus secara PERMANEN dari database House 
										Keeping&nbsp;!</STRONG></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="TDBGColor1">Last Track Date</TD>
											<TD width="15"></TD>
											<TD class="TDBGColorValue">
												<asp:textbox onkeypress="return numbersonly()" id="TXT_DATE1_D" runat="server" Width="32px" MaxLength="2"
													CssClass="mandatory03"></asp:textbox>
												<asp:dropdownlist id="DDL_MONTH1_D" runat="server" CssClass="mandatory03"></asp:dropdownlist>
												<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR1_D" runat="server" Width="82px" MaxLength="4"
													CssClass="mandatory03"></asp:textbox>&nbsp;s.d
												<asp:textbox onkeypress="return numbersonly()" id="TXT_DATE2_D" runat="server" Width="32px" MaxLength="2"
													CssClass="mandatory03"></asp:textbox>
												<asp:dropdownlist id="DDL_MONTH2_D" runat="server" CssClass="mandatory03"></asp:dropdownlist>
												<asp:textbox onkeypress="return numbersonly()" id="TXT_YEAR2_D" runat="server" Width="82px" MaxLength="4"
													CssClass="mandatory03"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD>
												<asp:button id="BTN_DEL_NEXT" runat="server" Text="VIEW APPLICATIONS" onclick="BTN_DEL_NEXT_Click"></asp:button>&nbsp;(To 
												view application to be deleted)</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD>
												<asp:label id="LBL_RESULT_DELETE" runat="server" ForeColor="Red"></asp:label></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD colspan="3">
												<TABLE id="TBL_DEL_HISTORY" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
													<TR>
														<TD class="tdHeader1">
															<asp:Label id="LBL_TITLE_DELETE" runat="server"></asp:Label></TD>
													</TR>
													<TR>
														<TD>Results&nbsp;:
															<asp:Label id="LBL_DELETE_COUNT" runat="server"></asp:Label>&nbsp;item(s)</TD>
													</TR>
													<TR>
														<TD>
															<asp:datagrid id="DGR_DEL_HISTORY" runat="server" Width="100%" AutoGenerateColumns="False">
																<Columns>
																	<asp:BoundColumn DataField="AP_REGNO" HeaderText="Application No">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="AP_RECVDATE" HeaderText="Application Date" DataFormatString="{0:dd-MMM-yyyy}">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="CU_FULLNAME" HeaderText="Customer Name">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Product">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="PROD_SEQ" HeaderText="SEQ">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="LASTTRACKDATE" HeaderText="Last Track Date" DataFormatString="{0:dd-MMM-yyyy}">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="LASTTRACKNAME" HeaderText="Last Track">
																		<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	</asp:BoundColumn>
																</Columns>
															</asp:datagrid></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TDBGColor2">
									<asp:button id="BTN_DELETE" runat="server" CssClass="Button1" Width="107px" Text="Delete" onclick="BTN_DELETE_Click"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:textbox onkeypress="return kutip_satu()" id="TXT_APPNO_DELETE" runat="server" Width="300px"
							CssClass="mandatory03" Visible="False"></asp:textbox>
						<asp:button id="BTN_DEL_HISTORY" runat="server" Visible="False" Text="VIEW LAST DELETE"></asp:button>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
