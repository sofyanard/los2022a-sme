<%@ Page language="c#" Codebehind="Withdrawal.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.Withdrawal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PerubahanLimit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="vbscript">
			function HitungLimit()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CP_EXLIMITCHGTO.value) then
				
				EXLIMIT = cdbl(obj.TXT_CP_EXLIMITCHGTO.value)
			else
				EXLIMIT = 0
			end if
			
			if isnumeric(obj.TXT_CP_EXRPLIMITCHGTO.value) then
				EXRPLIMIT = cdbl(obj.TXT_CP_EXRPLIMITCHGTO.value)
			else
				EXRPLIMIT = 0
			end if
			obj.TXT_CP_LIMITCHGTO.value = EXLIMIT * EXRPLIMIT
		end function
		</script>
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
			
			function updateImpact() 
			{
				// Rekening Baru
				if (Form1.DDL_WITHDRAWLID.value == '03') 
				{	
					Form1.TXT_CP_JANGKAWKT.className = "mandatory";
					Form1.DDL_CP_TENORCODE.className = "mandatory";					
				}
				// Perubahan Limit
				else if (Form1.DDL_WITHDRAWLID.value == '04') 
				{	
					Form1.TXT_CP_JANGKAWKT.className = "";
					Form1.DDL_CP_TENORCODE.className = "";
				}
			}
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<!--
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B> Initial Data Entry: 
											Withdrawal</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2">
							<asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Loan</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPTYPE" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">AA No.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_AA_NO" runat="server" CssClass="mandatory" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_AA_NO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 15px">No. Fasilitas</TD>
									<TD style="WIDTH: 15px; HEIGHT: 15px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 15px">
										<asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory" AutoPostBack="True" Enabled="False" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_FACILITYNO" runat="server" CssClass="mandatory" Enabled="False" onselectedindexchanged="DDL_FACILITYNO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTDESC" MaxLength="80" onkeypress="return kutip_satu()" runat="server"
											Width="300px" ReadOnly="True"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Withdrawal</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:DropDownList id="DDL_WITHDRAWLID" runat="server" onchange="updateImpact()" CssClass="mandatory"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">&nbsp;Tenor</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD>
										<asp:textbox id="TXT_CP_JANGKAWKT" runat="server" CssClass="mandatory" MaxLength="3" onkeypress="return digitsonly()"
											Columns="3"></asp:textbox>
										<asp:dropdownlist id="DDL_CP_TENORCODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Limit Diminta</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_EXLIMITCHGTO" onkeypress="return numbersonly()" onkeyup="HitungLimit()"
											MaxLength="15" onblur="FormatCurrency(document.Form1.TXT_CP_LIMITCHGTO)" runat="server" CssClass="mandatory"
											Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Exchange Rate to Rp.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_EXRPLIMITCHGTO" onkeyup="HitungLimit()"
											MaxLength="15"
											runat="server" CssClass="mandatory" Width="200px">1</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Limit Diminta in Rp.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_LIMITCHGTO" MaxLength="15" runat="server"
											Width="200px"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_NOTES" runat="server" Height="72px" TextMode="MultiLine" MaxLength="200"
											onkeypress="return kutip_satu()" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:Label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_USERID" runat="server" Visible="False"></asp:Label>
							<asp:label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:label>
							<asp:DropDownList id="DDL_CU_CHANNELCOMP" runat="server" Enabled="False" Visible="False" onselectedindexchanged="DDL_CU_CHANNELCOMP_SelectedIndexChanged"></asp:DropDownList>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="70px" Text="Save" onclick="BTN_SAVE_Click"></asp:button>
							<asp:button id="Button2" runat="server" CssClass="Button1" Width="70px" Text="Next" Visible="False" onclick="Button2_Click"></asp:button>
							<asp:button id="Button1" runat="server" CssClass="Button1" Width="150px" Visible="False" Text="Update Status" onclick="Button1_Click"></asp:button></TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" align="center" width="50%" colSpan="2"><ASP:DATAGRID id="DATAGRID1" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="CP_FACILITYNO" HeaderText="Fasilitas No">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="120px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE" HeaderText="APPTYPE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Jenis Kredit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMIT" HeaderText="Limit">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CP_LIMITCHGTO" HeaderText="Limit Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORDESC" HeaderText="Tenor">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TENORLAMA" HeaderText="Tenor Lama">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
				</TABLE>
			</center>
		</form>
		<script language="javascript">
		function buka()
		{
			window.open("../DataEntry/SkalaAngsuran_Main.aspx", "", "width=640,height=400, scrollbars=yes");
		}
		</script>
	</body>
</HTML>
