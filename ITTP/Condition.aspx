<%@ Page language="c#" Codebehind="Condition.aspx.cs" AutoEventWireup="True" Inherits="SME.ITTP.Condition" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Condition</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function CekEntry(str)
		{
			DDL = eval("document.Form1.DDL_"+str);
			TXT	= eval("document.Form1.TXT_"+str);
			if (DDL.value == "" && TXT.value == "")
			{
				alert("Syarat Tidak Boleh Kosong !!");
				return false;
			}
			else
			{
				return true;
			}
		}
		
		//TODO : How to use this function using include file ?
		// Fungsi ini sebenarnya sudah ada di /include/cek_entries.html,
		// tapi kalau pake #include file, screen-protection tidak berfungsi.
		function kutip_satu()
		{
			if ((event.keyCode == 35) || (event.keyCode == 39))
			{
				return false;
			} else
			{
				return true;
			}	
		}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdNoBorder"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table2">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Condition</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Condition</TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><ASP:DATAGRID id="DatGrd_PK" runat="server" AutoGenerateColumns="False" PageSize="7" Width="100%"
								CellPadding="1" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="Application No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="SEQ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="No.">
										<HeaderStyle Width="5%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SYARAT_DESC" HeaderText="Description">
										<HeaderStyle Width="88%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" Width="88%"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Document">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:datagrid id="DG_PKDOC" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
												AllowPaging="True" PageSize="5" ShowHeader="False">
												<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="COVSEQ"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="FILESEQ"></asp:BoundColumn>
													<asp:BoundColumn HeaderText="No.">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="35px"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="COVFILENAME" HeaderText="File Name">
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
														<ItemTemplate>
															<asp:HyperLink id="HL_DOWNLOAD1" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LB_DELETE1" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="USERID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="COVURL" HeaderText="User ID"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="SY_JENISPRODUCT" HeaderText="Jenis Product">
										<HeaderStyle Width="88%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="Upload File" HeaderText="Function" CommandName="Upload">
										<HeaderStyle Width="7%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:ButtonColumn Text="Delete" HeaderText="Function" CommandName="Delete">
										<HeaderStyle Width="7%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID><asp:textbox id="TXT_TEMP_PK" runat="server" Width="1px" ReadOnly="True" BorderStyle="None" ontextchanged="TXT_TEMP_PK_TextChanged"></asp:textbox></TD>
					</TR>
					<TR id="TR_JNSPROD_SYARATPK" runat="server">
						<TD align="center" width="100%" colSpan="2">
							<asp:dropdownlist id="DDL_PK" runat="server" Width="750px"></asp:dropdownlist></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 17px" align="center" width="100%" colSpan="2"><asp:textbox onkeypress="return kutip_satu()" id="TXT_PK" runat="server" Width="100%" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><asp:button id="BTNINSERT_PK" runat="server" Width="75px" CssClass="button1" Text="Insert" onclick="BTNINSERT_PK_Click"></asp:button>&nbsp;&nbsp;<asp:label id="LBL_H_JNSNASABAH" runat="server" Visible="False"></asp:label><asp:label id="LBL_H_PROGRAMID" runat="server" Visible="False"></asp:label></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
