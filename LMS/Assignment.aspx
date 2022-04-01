<%@ Page language="c#" Codebehind="Assignment.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.Assignment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Assignment</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
						<TD align="left" colSpan="2"><b>Assignment</b></TD>
					</TR>
					<TR id="TR_LIST" runat="server">
						<TD colSpan="2">
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
					<TR id="TR_DETAIL" runat="server">
						<TD colSpan="2">
							<asp:label id="LBL_APREGNO" runat="server" Font-Bold="True" Visible="False"></asp:label>
							<p>
								<table>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle">RM Assign 
											to</TD>
										<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="middle"><asp:dropdownlist id="DDL_RM" Runat="server"></asp:dropdownlist></TD>
										<TD style="WIDTH: 500px; HEIGHT: 15px" vAlign="middle" class="tdBGColor2" align="center">
											<asp:button id="BTN_ASSIGNRM" Runat="server" Width="200px" Text="Assign" CssClass="Button1" onclick="BTN_ASSIGNRM_Click"></asp:button>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 200px; HEIGHT: 15px" vAlign="middle">Next 
											Process Assign to</TD>
										<TD style="WIDTH: 300px; HEIGHT: 15px" vAlign="middle"><asp:dropdownlist id="DDL_NEXTTR" Runat="server"></asp:dropdownlist></TD>
										<TD style="WIDTH: 500px; HEIGHT: 15px" vAlign="middle" class="tdBGColor2" align="center">
											<asp:button id="BTN_ASSIGNNEXTTR" Runat="server" Width="200px" Text="Assign" CssClass="Button1" onclick="BTN_ASSIGNNEXTTR_Click"></asp:button>
										</TD>
									</TR>
								</table>
							</p>
						</TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
