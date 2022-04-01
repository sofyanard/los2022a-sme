<%@ Page language="c#" Codebehind="RevwCovenantSyarat.aspx.cs" AutoEventWireup="True" Inherits="SME.LMS.RevwCovenantSyarat" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RevwCovenantSyarat</title>
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
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Syarat-syarat</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><asp:imagebutton id="BTN_BACK" runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Syarat Penandatanganan Perjanjian Kredit</TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><ASP:DATAGRID id="DatGrd_PK" runat="server" CellPadding="1" Width="100%" PageSize="7" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DOCTYPEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
									<asp:BoundColumn HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SYARAT_DESC" HeaderText="Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SY_ACCDATE" HeaderText="Tanggal Dipenuhi">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SY_KET" HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
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
									<asp:ButtonColumn Text="Upload File" HeaderText="Function" CommandName="Upload">
										<HeaderStyle Width="7%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:TemplateColumn HeaderText="Next Periode">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_PK_NEXTDATE_DAY" Columns="2" runat="server"
												MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_PK_NEXTDATE_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_PK_NEXTDATE_YEAR" Columns="4" runat="server"
												MaxLength="4"></asp:textbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:checkbox id="CHK_PK_ISFINISH" runat="server" Text="Finish"></asp:checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="COV_NEXTDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="COV_ISFINISH"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID><asp:textbox id="TXT_TEMP_PK" runat="server" Width="1px" ReadOnly="True" BorderStyle="None" ontextchanged="TXT_TEMP_PK_TextChanged"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><asp:button id="BTNSAVE_PK" runat="server" Width="75px" Text="Save" CssClass="button1" onclick="BTNSAVE_PK_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" style="HEIGHT: 25px" colSpan="2">Syarat Penarikan / 
							Penerbitan Kredit</TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><ASP:DATAGRID id="DATGRID_TERBIT" runat="server" CellPadding="1" Width="100%" PageSize="7" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DOCTYPEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
									<asp:BoundColumn HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SYARAT_DESC" HeaderText="Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SY_ACCDATE" HeaderText="Tanggal Dipenuhi">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SY_KET" HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Document">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:datagrid id="DG_TERBITDOC" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
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
															<asp:HyperLink id="HL_DOWNLOAD2" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LB_DELETE2" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="USERID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="COVURL" HeaderText="User ID"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Upload File" HeaderText="Function" CommandName="Upload">
										<HeaderStyle Width="7%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:TemplateColumn HeaderText="Next Periode">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TERBIT_NEXTDATE_DAY" Columns="2" runat="server"
												MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_TERBIT_NEXTDATE_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_TERBIT_NEXTDATE_YEAR" Columns="4" runat="server"
												MaxLength="4"></asp:textbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:checkbox id="CHK_TERBIT_ISFINISH" runat="server" Text="Finish"></asp:checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="COV_NEXTDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="COV_ISFINISH"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID><asp:textbox id="TXT_TEMP_TERBIT" runat="server" Width="1px" ReadOnly="True" BorderStyle="None" ontextchanged="TXT_TEMP_TERBIT_TextChanged"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><asp:button id="BTNSAVE_TERBIT" runat="server" Width="75px" Text="Save" CssClass="button1" onclick="BTNSAVE_TERBIT_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="tdHeader1" colSpan="2">Syarat-syarat Lain</TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><ASP:DATAGRID id="DATGRID_LAIN" runat="server" CellPadding="1" Width="100%" PageSize="7" AutoGenerateColumns="False"
								AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DOCTYPEID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ"></asp:BoundColumn>
									<asp:BoundColumn HeaderText="No.">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SYARAT_DESC" HeaderText="Description">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SY_ACCDATE" HeaderText="Tanggal Dipenuhi">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SY_KET" HeaderText="Keterangan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Document">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:datagrid id="DG_LAINDOC" runat="server" AutoGenerateColumns="False" CellPadding="1" Width="100%"
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
															<asp:HyperLink id="HL_DOWNLOAD3" runat="server" Target="_blank">Download</asp:HyperLink>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn>
														<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:LinkButton id="LB_DELETE3" runat="server" CommandName="delete">Delete</asp:LinkButton>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn Visible="False" DataField="USERID" HeaderText="User ID"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="COVURL" HeaderText="User ID"></asp:BoundColumn>
												</Columns>
												<PagerStyle Mode="NumericPages"></PagerStyle>
											</asp:datagrid>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:ButtonColumn Text="Upload File" HeaderText="Function" CommandName="Upload">
										<HeaderStyle Width="7%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
									</asp:ButtonColumn>
									<asp:TemplateColumn HeaderText="Next Periode">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_LAIN_NEXTDATE_DAY" Columns="2" runat="server"
												MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_LAIN_NEXTDATE_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_LAIN_NEXTDATE_YEAR" Columns="4" runat="server"
												MaxLength="4"></asp:textbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:checkbox id="CHK_LAIN_ISFINISH" runat="server" Text="Finish"></asp:checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="COV_NEXTDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="COV_ISFINISH"></asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID><asp:textbox id="TXT_TEMP_LAIN" runat="server" Width="1px" ReadOnly="True" BorderStyle="None" ontextchanged="TXT_TEMP_LAIN_TextChanged"></asp:textbox></TD>
					</TR>
					<TR>
						<TD align="center" width="100%" colSpan="2"><asp:button id="BTNSAVE_LAIN" runat="server" Width="75px" Text="Save" CssClass="button1" onclick="BTNSAVE_LAIN_Click"></asp:button></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
