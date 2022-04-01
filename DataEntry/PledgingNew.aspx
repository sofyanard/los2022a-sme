<%@ Page language="c#" Codebehind="PledgingNew.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.PledgingNew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PledgingNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/onepost.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
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
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<%if (Request.QueryString["tc"] == "5.4") {%>
					<% } else { %>
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Detail Data Entry : 
											Pledging</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="../Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<% } %>
					<TR>
						<TD class="tdHeader1" colSpan="2">Fasilitas dan Agunan yang Belum di-Pledge</TD>
					</TR>
					<TR vAlign="top">
						<TD>
							<TABLE width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">Fasilitas</TD>
								</TR>
								<TR>
									<TD><ASP:DATAGRID id="DG_CUSTFAC" runat="server" ShowFooter="True" AutoGenerateColumns="False" CellPadding="1"
											Width="100%" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn DataField="AA_NO" HeaderText="No. Akomodasi Rekening">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PRODUCTID" HeaderText="No. Fasilitas">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="ACC_SEQ" HeaderText="Seq#">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="APPTYPE" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Permohonan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="LIMIT" HeaderText="Limit">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="BAKI_DEBET" HeaderText="Baki Debet">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:checkbox id="chk_pledgefac" runat="server"></asp:checkbox>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Center"></FooterStyle>
													<FooterTemplate>
														<asp:LinkButton id="lnk_allfac" runat="server" CommandName="allfac">Pilih Semua</asp:LinkButton>
													</FooterTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="CU_REF" Visible="False"></asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
						<TD>
							<TABLE width="100%">
								<TR>
									<TD class="tdHeader1" colSpan="2">Agunan</TD>
								</TR>
								<TR>
									<TD><ASP:DATAGRID id="DG_CUSTCOL" runat="server" ShowFooter="True" AutoGenerateColumns="False" CellPadding="1"
											Width="100%" AllowPaging="True">
											<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_TYPE" Visible="False"></asp:BoundColumn>
												<asp:BoundColumn DataField="CL_TYPEDESC" HeaderText="Jenis Agunan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="SIBS_COLID" HeaderText="ID Core">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_DESC" HeaderText="Keterangan">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai">
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:checkbox id="chk_pledgecol" runat="server"></asp:checkbox>
													</ItemTemplate>
													<FooterStyle HorizontalAlign="Center"></FooterStyle>
													<FooterTemplate>
														<asp:LinkButton id="lnk_allcol" runat="server" CommandName="allcol">Pilih Semua</asp:LinkButton>
													</FooterTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</ASP:DATAGRID></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
								<TR>
									<TD class="TDBGColor1">Grup</TD>
									<TD>:</TD>
									<TD><asp:dropdownlist id="DDL_GROUP" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;
										<asp:button id="BTN_NEW" runat="server" Text="Tambah Grup" 
                                            onclick="BTN_NEW_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD class="tdbgcolor2" colSpan="3"><asp:button id="BTN_ADD" runat="server" 
                                            Width="125px" Text="Tambah" CssClass="button1" onclick="BTN_ADD_Click"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Pledging Group</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DG_PLEDGINGMAIN" runat="server" AutoGenerateColumns="False" CellPadding="1"
								Width="100%" AllowPaging="True" PageSize="5">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="PL_SEQ" HeaderText="Group">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Fasilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:datagrid id="DG_PLEDGINGFAC" runat="server" ShowFooter="True" AutoGenerateColumns="False"
												CellPadding="1" Width="100%" AllowPaging="True" PageSize="5">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<FooterStyle Font-Bold="True" ForeColor="White" BackColor="Gray"></FooterStyle>
												<Columns>
													<asp:BoundColumn DataField="AA_NO" HeaderText="No. Akomodasi Rekening">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<FooterStyle HorizontalAlign="Center"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PRODUCTID" HeaderText="No. Fasilitas">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="ACC_SEQ" HeaderText="Seq#">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="APPTYPE" Visible="False"></asp:BoundColumn>
													<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="App. Type">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="LIMIT" HeaderText="Limit">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
														<FooterStyle HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="BAKI_DEBET" HeaderText="Baki Debet">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
														<FooterStyle HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="RATIO_LIMIT" HeaderText="Ratio Limit (%)">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<FooterStyle HorizontalAlign="Center"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="RATIO_BADE" HeaderText="Ratio Bade (%)">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<FooterStyle HorizontalAlign="Center"></FooterStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="lb_delfac" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Agunan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:datagrid id="DG_PLEDGINGCOL" runat="server" AllowPaging="True" ShowFooter="True" Width="100%"
												CellPadding="1" AutoGenerateColumns="False" PageSize="5">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<FooterStyle Font-Bold="True" ForeColor="White" BackColor="Gray"></FooterStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="CL_SEQ"></asp:BoundColumn>
													<asp:BoundColumn DataField="CL_TYPE" Visible="False"></asp:BoundColumn>
													<asp:BoundColumn DataField="CL_TYPEDESC" HeaderText="Col. Type">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="SIBS_COLID" HeaderText="SIBS Col. ID">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_DESC" HeaderText="Keterangan">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<FooterStyle HorizontalAlign="Center"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="CL_VALUE" HeaderText="Nilai">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
														<FooterStyle HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="lb_delcol" runat="server" CommandName="delete">Hapus</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="lb_delgroup" runat="server" CommandName="delete">Hapus</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Detail Pledging</TD>
					</TR>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DG_LISTPLEDGING" runat="server" AutoGenerateColumns="False" CellPadding="1"
								Width="100%" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AA_NO" HeaderText="No. Akomodasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTID" HeaderText="No. Fasilitas">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACC_SEQ" HeaderText="Seq#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACC_NO" HeaderText="No. Rek">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="CL_DESC" HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SIBS_COLID" HeaderText="ID Core">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PERCENTAGE" HeaderText="Persentasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
