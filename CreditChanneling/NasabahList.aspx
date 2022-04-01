<%@ Page language="c#" Codebehind="NasabahList.aspx.cs" AutoEventWireup="True" Inherits="SME.CreditChanneling.NasabahList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>NasabahList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
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
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD>
						<TABLE id="Table4">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Nasabah</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD align="right"><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" Visible="False" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<TABLE class="td" id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdheader1" colSpan="2">Batch Info</TD>
							</TR>
							<TR>
								<TD width="50%">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Batch No</TD>
											<TD style="WIDTH: 12px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_BATCHNO" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Nama File</TD>
											<TD style="WIDTH: 12px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CH_NAMAFILE" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">User Upload</TD>
											<TD style="WIDTH: 12px; HEIGHT: 22px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CH_USERID" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Upload Date</TD>
											<TD style="WIDTH: 12px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CH_UPLOADDATE" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1" style="WIDTH: 164px">Jumlah Nasabah</TD>
											<TD style="WIDTH: 12px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_JUM_NASABAH" runat="server"></asp:label>&nbsp;orang</TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="50%">
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD class="TDBGColor1">Application Ref.</TD>
											<TD style="WIDTH: 13px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_AP_REGNO" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Customer Ref.</TD>
											<TD style="WIDTH: 13px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CUREF" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Nama BPR</TD>
											<TD style="WIDTH: 13px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CH_BPR_DESC" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Plafond LOS</TD>
											<TD style="WIDTH: 13px">:</TD>
											<TD class="TDBGColorValue">Rp.
												<asp:label id="LBL_CH_PLAFOND_LOS" runat="server"></asp:label></TD>
										</TR>
										<TR>
											<TD class="TDBGColor1">Kadaluwarsa</TD>
											<TD style="WIDTH: 13px">:</TD>
											<TD class="TDBGColorValue"><asp:label id="LBL_CH_TENOR" runat="server"></asp:label>&nbsp;bulan</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
							AllowSorting="True" AllowPaging="True" ShowFooter="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="NONAS" SortExpression="NONAS" HeaderText="No. Nasabah">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_NAMA" SortExpression="CH_NAMA" HeaderText="Nama Nasabah">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_LIMIT" SortExpression="CH_LIMIT" HeaderText="Limit" DataFormatString="IDR {0:0,00.00}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_JW" SortExpression="CH_JW" HeaderText="Tenor" DataFormatString="{0} bulan">
									<HeaderStyle Width="80px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_PENDAPATAN" SortExpression="CH_PENDAPATAN" HeaderText="Pendapatan"
									DataFormatString="IDR {0:0,00.00} /bulan">
									<HeaderStyle Width="150px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CH_MKERJA" SortExpression="CH_MKERJA" HeaderText="Masa Kerja" DataFormatString="{0} tahun">
									<HeaderStyle Width="80px" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CH_ISLENGKAP" HeaderText="CH_ISLENGKAP"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Status">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Image id="IMG_STATUS" runat="server"></asp:Image>
										<asp:Label id="LBL_STATUS" runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle Width="8%" CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="LNK_VIEW" runat="server" Text="View" CommandName="view" CausesValidation="false">View</asp:LinkButton>&nbsp;
										<asp:LinkButton id="lnk_DeleteReject" runat="server" Text="View" CommandName="delete" CausesValidation="false">Delete</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="CH_ISACCEPT" HeaderText="CH_ISACCEPT"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="BATCHSEQ" HeaderText="BATCHSEQ"></asp:BoundColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD class="tdbgcolor2" colSpan="2"><asp:label id="LBL_ISLENGKAPSEMUA" runat="server" Visible="False">1</asp:label><asp:button id="BTN_SCORING" runat="server" Visible="False" Width="113" CssClass="BUTTON1" Text="Start Scoring" onclick="BTN_SCORING_Click"></asp:button><asp:button id="BTN_EARMARK" runat="server" Visible="False" Width="120px" CssClass="BUTTON1"
							Text="Earmark" onclick="BTN_EARMARK_Click"></asp:button><asp:button id="BTN_UPDATE" runat="server" Visible="False" Width="120px" CssClass="BUTTON1"
							Text="Update Status" onclick="BTN_UPDATE_Click"></asp:button><asp:label id="LBL_SORTTYPE" runat="server" Visible="False">ASC</asp:label><asp:label id="LBL_SORTEXP" runat="server" Visible="False">NONAS</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px" colSpan="2"><asp:textbox id="TXT_NEGATIVE" runat="server" Visible="False">NO</asp:textbox></TD>
				</TR>
				<TR id="tr_confirm_negative" runat="server">
					<TD style="HEIGHT: 20px" colSpan="2"><asp:label id="LBL_NEGATIVE" runat="server" Font-Bold="True" ForeColor="Red">Hasil earmarking akan negatif. Lanjutkan ?</asp:label>&nbsp;
						<asp:button id="BTN_NEGATIVE_YES" runat="server" Width="75px" Text="Yes" onclick="BTN_NEGATIVE_YES_Click"></asp:button>&nbsp;
						<asp:button id="BTN_NEGATIVE_NO" runat="server" Width="75px" Text="No" onclick="BTN_NEGATIVE_NO_Click"></asp:button></TD>
				</TR>
				<TR id="TR_SCORING_RESULT" runat="server">
					<TD colSpan="2">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="TDBGColor1" width="15%">Jumlah Accepted</TD>
								<TD width="2%">:</TD>
								<TD class="TDBGColorValue" width="33%"><asp:label id="LBL_JUML_NASABAH_ACCEPTED" runat="server"></asp:label>&nbsp;orang</TD>
								<TD class="TDBGColor1" width="15%">Total Limit Accept</TD>
								<TD width="2%">:</TD>
								<TD class="TDBGColorValue" width="33%"><asp:label id="lbl_TotalLimitAccept" runat="server"></asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Jumlah Rejected</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="LBL_JUML_NASABAH_REJECTED" runat="server"></asp:label>&nbsp;orang</TD>
								<TD class="TDBGColor1">Dana dari Bank</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="lbl_DanaDariBank" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD class="TDBGColor1">
									<P>Dana dari Channeling</P>
								</TD>
								<TD>:</TD>
								<TD class="TDBGColorValue"><asp:label id="lbl_DanaDariChanneling" runat="server"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_NONAS" runat="server" Visible="False" Width="226"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_NAMA" runat="server" Visible="False" Width="226px"></asp:textbox><asp:label id="LBL_BPR_NO" runat="server" Visible="False"></asp:label><asp:label id="LBL_CH_PLAFOND_EMAS" runat="server" Visible="False"></asp:label><asp:textbox onkeypress="return numbersonly()" id="TXT_LIMIT1" runat="server" Visible="False"
							Width="100px"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_LIMIT2" runat="server" Visible="False"
							Width="100px"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_JW1" runat="server" Visible="False" Width="100px"></asp:textbox><asp:textbox onkeypress="return numbersonly()" id="TXT_JW2" runat="server" Visible="False" Width="100px"></asp:textbox><asp:label id="lbl_SCORE" runat="server" Visible="False"></asp:label><asp:label id="LBL_TC" runat="server" Visible="False"></asp:label><asp:label id="LBL_MC" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
