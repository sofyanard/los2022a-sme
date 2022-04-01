<%@ Page language="c#" Codebehind="AprvAbsentee.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.AprvAbsentee" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Abesentee</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryonly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/onepost.html" -->
		<script language="javascript">
		function hapus()
		{
			if (processing) {
				//alert("Delete is in progress. Please wait ...");
				return false;	
			}
			
			conf = confirm("Apakah Anda yakin ingin menghapus record ini?");
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
	<BODY>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
				<TR>
					<TD class="tdNoBorder">
						<TABLE id="TableHeader">
							<TR>
								<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Apr</B></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="tdNoBorder" align="right"><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" align="center" width="50%">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Branch</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_SEARCH_BRANCH" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">Group</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_SEARCH_GROUP" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">User ID</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="txt_SEARCH_USERID" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">User Name</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="txt_SEARCH_USERNAME" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 129px" align="right"><asp:button id="btn_SEARCH" runat="server" Text="Search" Width="100px" onclick="btn_SEARCH_Click"></asp:button></TD>
								<TD></TD>
								<TD><asp:button id="btn_CLEAR" runat="server" Text="Clear" Width="100px" onclick="btn_CLEAR_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><ASP:DATAGRID id="DatGrd" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1"
							AllowPaging="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="USERID" SortExpression="USERID" HeaderText="User ID">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SU_FULLNAME" SortExpression="SU_FULLNAME" HeaderText="User Name">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SG_GRPNAME" SortExpression="SG_GRPNAME" HeaderText="Group">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="STATUS" HeaderText="Status Absen">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ABSENSTART" HeaderText="Mulai Absen" DataFormatString="{0:dd-MM-yyyy}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ABSENEND" HeaderText="Akhir Absen" DataFormatString="{0:dd-MM-yyyy}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PENGGANTI" HeaderText="Pengganti">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Function">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="75px"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton id="lnkEdit" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
										<asp:LinkButton id="lnkDelete" runat="server" CommandName="delete">Delete</asp:LinkButton>&nbsp;
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</ASP:DATAGRID></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">&nbsp;
						<asp:label id="lbl_RESULT" runat="server" Font-Bold="True" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Detail Information</TD>
				</TR>
				<TR>
					<TD class="td" vAlign="top" width="50%">
						<TABLE id="tbl_DETAIL" cellSpacing="0" cellPadding="0" width="100%" runat="server">
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">User ID</TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:textbox id="txt_USERID" runat="server" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="WIDTH: 129px">User Name</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:dropdownlist id="ddl_USERNAME" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_USERNAME_SelectedIndexChanged"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Group</TD>
								<TD style="WIDTH: 15px"></TD>
								<TD class="TDBGColorValue"><asp:textbox id="txt_GROUP" runat="server" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Mulai Absen</TD>
								<TD></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="txt_STARTABS_DD" Width="25px" CssClass="mandatory"
										Columns="2" Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_STARTABS_MM" CssClass="mandatory" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_STARTABS_YY" Width="40px" CssClass="mandatory"
										Columns="4" Runat="server" MaxLength="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">Akhir Absen</TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="txt_ENDABS_DD" Width="25px" CssClass="mandatory"
										Columns="2" Runat="server" MaxLength="2"></asp:textbox><asp:dropdownlist id="ddl_ENDABS_MM" CssClass="mandatory" Runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="txt_ENDABS_YY" Width="40px" CssClass="mandatory"
										Columns="4" Runat="server" MaxLength="4"></asp:textbox></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD class="TDBGColorValue"></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1" style="HEIGHT: 17px">Pengganti</TD>
								<TD style="HEIGHT: 17px"></TD>
								<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="ddl_PUSERNAME" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="ddl_PUSERNAME_SelectedIndexChanged"></asp:dropdownlist><asp:button id="btn_CARIPENGGANTI" runat="server" Text="Cari Penggati" onclick="btn_CARIPENGGANTI_Click"></asp:button></TD>
							</TR>
							<TR>
								<TD class="TDBGColor1">User ID</TD>
								<TD></TD>
								<TD class="TDBGColorValue"><asp:textbox id="txt_PUSERID" runat="server" ReadOnly="True"></asp:textbox></TD>
							</TR>
							<tr>
								<td class="TDBGColor1">Group</td>
								<td></td>
								<td class="TDBGColorValue"><asp:textbox id="txt_PGROUP" runat="server" ReadOnly="True"></asp:textbox></td>
							</tr>
							<TR>
								<TD colSpan="3"></TD>
							</TR>
						</TABLE>
					</TD>
					<TD class="td" vAlign="top" width="50%"></TD>
				</TR>
				<TR>
					<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="btn_NEW" runat="server" Text="New" Width="70px" CssClass="Button1" onclick="btn_NEW_Click"></asp:button>&nbsp;&nbsp;
						<asp:button id="btn_SAVE" runat="server" Text="Save" Width="70px" CssClass="Button1" Visible="False" onclick="btn_SAVE_Click"></asp:button><asp:button id="btn_CANCEL" runat="server" Text="Cancel" Width="70px" CssClass="Button1" Visible="False" onclick="btn_CANCEL_Click"></asp:button><asp:label id="lbl_SQLStatement" runat="server" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
