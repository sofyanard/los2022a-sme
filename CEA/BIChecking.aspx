<%@ Page language="c#" Codebehind="BIChecking.aspx.cs" AutoEventWireup="false" Inherits="SME.CEA.BIChecking" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BIChecking</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
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
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>BI Checking Result Entry</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<TR>
							<TD class="tdHeader1" colSpan="2">BI Checking Result List</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" DESIGNTIMEDRAGDROP="33" CellPadding="1" PageSize="1"
									AutoGenerateColumns="False" Width="100%">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<ASP:BoundColumn DataField="SEQ" Visible="False"></ASP:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="REKANAN_REF"></asp:BoundColumn>
										<asp:BoundColumn DataField="NAMA" HeaderText="Nama">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="IDI_DATE" HeaderText="Tgl IDI BI">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="BANK_NAME" HeaderText="Nama Bank">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CREDIT_TYPE" HeaderText="Jenis Kredit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CBAL" HeaderText="Baki Debet">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="KOLE" HeaderText="Kolektibilitas">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TUNGGAKAN_AGE" HeaderText="Umur Tunggakan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TOT_TUNGGAKAN" HeaderText="Total Tunggakan">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="POSITION_DATE" HeaderText="Posisi Data">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Function">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
											<ItemTemplate>
												<asp:LinkButton id="LNK_EDIT" runat="server" CommandName="lnk_edit">Edit</asp:LinkButton>&nbsp;
												<asp:LinkButton id="LNK_DELETE" runat="server" CommandName="lnk_delete">Delete</asp:LinkButton>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</ASP:DATAGRID><BR>
								<TABLE id="Table9" cellSpacing="2" cellPadding="2" width="100%" border="0">
									<!--
								<TR>
									<TD style="HEIGHT: 43px" vAlign="top" width="50%" colSpan="2"><STRONG>Retrieve Function</STRONG></TD>
								</TR>
								-->
									<TBODY>
										<TR>
											<TD class="td" vAlign="top" width="50%">
												<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
													<TBODY>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 144px; HEIGHT: 23px">Nama</TD>
															<TD style="WIDTH: 15px; HEIGHT: 23px"></TD>
															<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_NAMA" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 127px">Nama Bank</TD>
															<TD></TD>
															<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_BANK" runat="server"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 129px">Tgl. IDI BI</TD>
															<TD></TD>
															<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_DAY" runat="server" Width="24px"
																	Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_IDI_BI_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CS_DOB_YEAR" runat="server" Width="36px"
																	Columns="4" MaxLength="4"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 129px">Posisi Data</TD>
															<TD></TD>
															<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_POS_DT_DAY" runat="server" Width="24px"
																	Columns="4" MaxLength="2"></asp:textbox><asp:dropdownlist id="DDL_POSISI_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_POS_DT_YEAR" runat="server" Width="36px"
																	Columns="4" MaxLength="4"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="TDBGColor1" style="WIDTH: 127px">Jenis Kredit</TD>
															<TD></TD>
															<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="CREDIT_TYPE" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
														</TR>
													</TBODY>
												</TABLE>
												<asp:label id="SEQ" runat="server" Visible="False"></asp:label>
											<TD class="td" vAlign="top" align="center">
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
													<TR>
														<TD class="TDBGColor1" style="HEIGHT: 23px" width="125">Baki Debet</TD>
														<TD style="WIDTH: 17px; HEIGHT: 23px"></TD>
														<TD class="TDBGColorValue" style="HEIGHT: 23px" align="left"><asp:textbox onkeypress="return kutip_satu()" id="BAKI_DEBET" runat="server" Width="300px" MaxLength="50"
																AutoPostBack="True"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="TDBGColor1" width="125">Kolektibilitas</TD>
														<TD style="WIDTH: 17px"></TD>
														<TD class="TDBGColorValue" style="HEIGHT: 23px"><asp:dropdownlist id="DDL_KOLE" runat="server"></asp:dropdownlist></TD>
													</TR>
													<TR>
														<TD class="TDBGColor1" style="HEIGHT: 21px">Umur Tunggakan</TD>
														<TD style="HEIGHT: 21px"></TD>
														<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TUNGGAKAN_AGE" runat="server" Width="300px"
																MaxLength="50"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="TDBGColor1" style="HEIGHT: 22px">Total Tunggakan
														</TD>
														<TD style="HEIGHT: 22px"></TD>
														<TD class="TDBGColorValue" style="HEIGHT: 22px" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TOT_TUNGGAKAN" runat="server" Width="300px"
																MaxLength="50" AutoPostBack="True"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="TDBGColor1" style="HEIGHT: 20px">Remark</TD>
														<TD style="HEIGHT: 20px"></TD>
														<TD class="TDBGColorValue" style="HEIGHT: 20px" align="left"><asp:textbox onkeypress="return kutip_satu()" id="REMARK" runat="server" Width="300px" MaxLength="200"
																Height="24px"></asp:textbox></TD>
													</TR>
												</TABLE>
												<BR>
											</TD>
											<asp:label id="TXT_SEQ" Visible="False" Runat="server"></asp:label></TR>
										<TR>
											<TD vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_INSERT" runat="server" CssClass="button1" Text="Insert"></asp:button><asp:button id="BTN_UPDATE" runat="server" CssClass="button1" Text="Update"></asp:button><asp:button id="BTN_Clear" runat="server" CssClass="button1" Text="Clear"></asp:button></TD>
										</TR>
									</TBODY>
								</TABLE>
							</TD>
						</TR>
						<%if (Request.QueryString["bi"] == "" || Request.QueryString["bi"] == null) {%>
						<% } %>
					</TBODY>
				</TABLE>
				<table id="Table4" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td align="center"><asp:placeholder id="Placeholder2" runat="server"></asp:placeholder><asp:label id="LBL_REK_REF" runat="server" Visible="False"></asp:label><asp:label id="LBL_REK_REG" runat="server" Visible="False"></asp:label></td>
					</tr>
				</table>
			</center>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE>
		<CENTER></CENTER>
		</FORM>
	</body>
</HTML>
