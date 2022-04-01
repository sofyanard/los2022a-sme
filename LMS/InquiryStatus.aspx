<%@ Page language="c#" Codebehind="InquiryStatus.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.InquiryStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InquiryStatus</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
			function MinLengthValidation(obj,len)
			{
				if ((obj.value.length < len) && (obj.value.length > 0))
				{
					alert("Minimal "+len+" karakter!");
					obj.value = "";
					obj.focus;
				}
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD align="left" colSpan="1">
							<TABLE id="Table3">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Inquiry Status</B></TD>
								</TR>
							</TABLE>
						</TD>
						<td align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" height="195" cellSpacing="1" cellPadding="1" width="590"
								border="1">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="170">LMS Application No.</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_LMSREG" runat="server" MaxLength="20"
														Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="170">CIF No.</TD>
												<TD width="5"></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CIF" runat="server" MaxLength="20"
														Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Nama Pemohon</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_Name" onblur="MinLengthValidation(Form1.txt_Name,3)"
														runat="server" MaxLength="50" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">KTP&nbsp;No.</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_IdCard" runat="server" MaxLength="30" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">NPWP</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="txt_NPWP" runat="server" MaxLength="25" Width="200px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Tanggal Lahir</TD>
												<TD></TD>
												<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_DD" runat="server" MaxLength="2"
														Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MM" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_YY" runat="server" MaxLength="4"
														Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="5"></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" height="10"><asp:button id="btn_Find" runat="server" Width="180px" Text="Find" CssClass="button1" onclick="btn_Find_Click"></asp:button>&nbsp;
													<asp:button id="btn_clear" runat="server" Width="180px" Text="Clear" CssClass="button1" onclick="btn_clear_Click"></asp:button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2"><b>Tracking Status</b></TD>
					</TR>
					<TR>
						<TD colSpan="2"><asp:label id="LBL_APREGNO" runat="server" Font-Bold="True" Visible="False"></asp:label>
							<p><ASP:DATAGRID id="DG_TRACK" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
									AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="LMS_REGNO" HeaderText="LMS App. No."></asp:BoundColumn>
										<asp:BoundColumn DataField="TRACKCODE" HeaderText="Track Code">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TRACKNAME" HeaderText="Track Description">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TH_TRACKDATE" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TH_TRACKBYNAME" HeaderText="Updated By">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="SG_GRPNAME" HeaderText="Unit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="TH_TRACKNEXTBYNAME" HeaderText="Next Update">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</ASP:DATAGRID></p>
							<p><ASP:DATAGRID id="DG_APP" runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False"
									AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn DataField="LMS_REGNO" HeaderText="LMS Application No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LMS_RECVDATE" HeaderText="LMS Receive Date" DataFormatString="{0:dd MMMM yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CIF_NO" HeaderText="CIF No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="CU_NAME" HeaderText="Nama Pemohon">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="ID_NO" HeaderText="ID No.">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:ButtonColumn>
									</Columns>
									<PagerStyle Mode="NumericPages"></PagerStyle>
								</ASP:DATAGRID></p>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
