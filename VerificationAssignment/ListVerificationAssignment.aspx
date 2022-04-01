<%@ Page language="c#" Codebehind="ListVerificationAssignment.aspx.cs" AutoEventWireup="True" Inherits="SME.VerificationAssignment.ListAssignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Verification Assignment List</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include  file="../include/cek_entries.html" -->
		<!-- #include file="../include/ConfirmBox.html" -->
		<script language="javascript">						
			/*******************************************************************************
				Ngga tahu kenapa fungsi update dibawah khusus di VA aja
				tidak bisa pakai konsep seperti yang lain dengan meng-include
				file onepost.html dan ConfirmBox.html
			*******************************************************************************/
			var submitCount = 0;
			
			function update()
			{
				if (submitCount > 0) {
					alert ("Update is in progress. Please wait ...");
					return false;
				}
				
				conf = confirm("Are you sure you want to update???");
				if (conf)
				{
					//alert ("Update is in progress. Please wait ...");
					submitCount++;
					return true;
				}
				else
				{
					return false;
				}
			}
			
			function updateMsgC()
			{
				msg = "1. Untuk agunan non fixed asset, agar diperhatikan apakah sumber data dan posisi stock & piutang masih cukup up-to-date.";
				msg = msg + "\n2. Untuk agunan fixed asset, agar diperhatikan masalaku SHGB.";
				msg = msg + "\n3. Apabila agunan adalah milik pihak ketiga, agar diberikan penjelasan apa kaitannya dengan calon debitur/debitur,.";
				msg = msg + "\n   dan jika tidak ada kaitannya agar dikemukakan risiko dan disyaratkan Indemnity Letter.";
				msg = msg + "\n4. Apabila agunan a/n pengurus, agar diperhatikan apakah di dalam Neraca telah dicatat sebagai asset PT.";
				msg = msg + "\n   Jika tidak termasuk dalam asset PT agar disyaratkan Surat Pernyataan dari pemilik agunan.";
				msg = msg + "\n   yang menyatakan setuju bahwa agunan tersebut digunakan untuk kepentingan usaha PT (Indemnity Letter).";
				msg = msg + "\n5. Apabila agunan telah dicatat dalam asset PT, agar dilengkapi dengan:";
				msg = msg + "\n   (1) Surat Pernyataan dari yang namanya tercantum dalam sertifikat bahwa asset tersebut merupakan asset PT, dan";
				msg = msg + "\n   (2) RUPS yang menyatakan bahwa asset tersebut merupakan asset PT.";
				msg = msg + "\n6. Agar diteliti apakah agunan dinilai oleh appraisal rekanan Bank Mandiri (KP/Wilayah)";
				msg = msg + "\n   dan diperhatikan apakah telah sesuai kelasnya.";
				msg = msg + "\n7. Agar diperiksa apakah masa penilaian appraisal masih berlaku.";
				msg = msg + "\n8. Agar diteliti apakah agunan ditutup pada asuradur rekanan dan diperhatikan apakah telah sesuai kelasnya.";
				msg = msg + "\n9. Agar diperiksa mengenai masalaku asuransi agunan.";
				conf = confirm(msg);
				if (conf)
				{
					conf2 = confirm("Are you sure you want to update?");
					if (conf2)
					{
						return true;		
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Verification Assignment 
											List</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD colSpan="2" align="center"><STRONG>
								<TABLE class="td" id="Table1" style="WIDTH: 590px; HEIGHT: 200px" cellSpacing="1" cellPadding="1"
									width="590" border="1">
									<TR>
										<TD class="tdHeader1">Kriteria Pencarian</TD>
									</TR>
									<TR>
										<TD vAlign="top">
											<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" width="160">Nama Pemohon</TD>
													<TD width="17"></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px" width="342">
														<asp:textbox id="txt_Name" runat="server" onkeypress="return kutip_satu()" MaxLength="20" Width="150px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">No. Aplikasi</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px">
														<asp:textbox id="txt_ProsID" onkeypress="return kutip_satu()" runat="server" MaxLength="20" Width="150px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">KTP&nbsp;No. / TDP No.</TD>
													<TD></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px">
														<asp:textbox id="txt_IdCard" onkeypress="return kutip_satu()" runat="server" MaxLength="20" Width="150px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1">NPWP</TD>
													<TD></TD>
													<TD style="WIDTH: 342px">
														<asp:textbox id="txt_NPWP" onkeypress="return kutip_satu()" runat="server" MaxLength="20" Width="150px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="HEIGHT: 18px">Dari Tanggal s/d Tanggal</TD>
													<TD style="HEIGHT: 18px"></TD>
													<TD style="WIDTH: 400px; HEIGHT: 18px">
														<P class="TDBGColorValue">
															<asp:textbox id="txt_Date" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="2"></asp:textbox>
															<asp:dropdownlist id="ddl_Month" runat="server"></asp:dropdownlist>
															<asp:textbox id="txt_Year" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="4"></asp:textbox>&nbsp;s/d
															<asp:textbox id="txt_Date1" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="2"></asp:textbox>
															<asp:dropdownlist id="ddl_Month1" runat="server"></asp:dropdownlist>
															<asp:textbox id="txt_Year1" onkeypress="return numbersonly()" runat="server" Columns="3" MaxLength="4"></asp:textbox></P>
													</TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" vAlign="middle">Kondisi</TD>
													<TD vAlign="middle"></TD>
													<TD class="TDBGColorValue" style="WIDTH: 342px" vAlign="top">
														<asp:radiobuttonlist id="RDB_COND" runat="server" CellPadding="0" Width="208px" RepeatDirection="Horizontal"
															CellSpacing="0" Height="24px">
															<asp:ListItem Value="And">Dan</asp:ListItem>
															<asp:ListItem Value="Or" Selected="True">Atau</asp:ListItem>
														</asp:radiobuttonlist></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="center" colSpan="3">
														<asp:button id="btn_Find" runat="server" Text="Cari" Width="75px" 
                                                            CssClass="button1" onclick="btn_Find_Click"></asp:button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</STRONG>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2">
							<asp:Label id="LBL_COUNT_APP" runat="server" Font-Bold="True"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:textbox id="TXT_AP_REGNO" runat="server" Visible="False"></asp:textbox>
							<asp:button id="BtnFind" runat="server" Text="F i n d" Visible="False"></asp:button>
							<asp:Label id="LBL_SQLFIND" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_REGNO" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_MSG" runat="server" Visible="False"></asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" AutoGenerateColumns="False" PageSize="1" Width="100%"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="No. Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="CU_REF" HeaderText="CU_REF"></asp:BoundColumn>
									<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="AP_SIGNDATE" HeaderText="Tanggal Aplikasi">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Lihat" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn Visible="False" DataField="AP_APPRSTATUS" HeaderText="AP_APPRSTATUS"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status Penilaian">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_LA_APPRSTATUS" runat="server"></asp:Image>
											<asp:Label id="LBL_LA_APPRSTATUS" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="CHECKBI" HeaderText="CHECKBI"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="BS_COMPLETE" HeaderText="BS_COMPLETE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status IDI BI">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_BS_COMPLETE" runat="server"></asp:Image>
											<asp:Label id="LBL_BS_COMPLETE" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_SITEVISITSTA" HeaderText="AP_SITEVISITSTA"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Status Kunjungan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_AP_SITEVISITSTA" runat="server"></asp:Image>
											<asp:Label id="LBL_AP_SITEVISITSTA" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="AP_ISAPPEAL" HeaderText="AP_ISAPPEAL"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Appealed Application" Visible="False">
										<HeaderStyle HorizontalAlign="Center" Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:Image id="IMG_AP_ISAPPEAL" runat="server"></asp:Image>
											<asp:Label id="LBL_AP_ISAPPEAL" runat="server"></asp:Label>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="90px"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LB_UPDATESTATUS" runat="server" Text="Update Status" CausesValidation="True"
												CommandName="UpdateStatus">Update Status</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
					</TABLE>
			</center>
		</form>
	</body>
</HTML>
