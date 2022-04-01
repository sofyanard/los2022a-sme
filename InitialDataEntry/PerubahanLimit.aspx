<%@ Page language="c#" Codebehind="PerubahanLimit.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.PerubahanLimit" %>
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
        <script language="javascript">
            function IsNumeric(n)
            {
                return !isNaN(parseFloat(n)) && isFinite(n);
            }

            function HitungLimit()
            {
                var CP_EXLIMITVAL = window.document.getElementById('TXT_CP_EXLIMITCHGTO').value;
                var CP_EXRPLIMIT = window.document.getElementById('TXT_CP_EXRPLIMITCHGTO').value;
                var CP_LIMIT;
                var EXLIMIT;
                var EXRPLIMIT;

                if (IsNumeric(parseFloat(CP_EXLIMITVAL)))
                    EXLIMIT = parseFloat(CP_EXLIMITVAL.replace(/\./g, ''));
                else
                    EXLIMIT = 0;

                if (IsNumeric(parseFloat(CP_EXRPLIMIT)))
                    EXRPLIMIT = parseFloat(CP_EXRPLIMIT.replace(/\./g, ''));
                else
                    EXRPLIMIT = 0;
                CP_LIMIT = EXLIMIT * EXRPLIMIT;
                /*CP_LIMIT = CP_LIMIT.replace('.', ',');*/
                window.document.getElementById('TXT_CP_LIMITCHGTO').value = CP_LIMIT;
            }
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
			
			function SaveMsg()
			{			
				msg = "1. Agar dicheck apakah tujuan proposal sudah sesuai dengan surat permohonan calon debitur.";
				
				conf = confirm(msg);
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
					<!--
					<TR>
						<TD class="tdNoBorder">
							<TABLE id="Table4">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
											Perubahan Limit</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					-->
					<TR>
						<TD class="tdHeader1" colSpan="2">Informasi Loan</TD>
					</TR>
					<TR id="TR_JENISPENGAJUAN" runat="server">
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Jenis Pengajuan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_APPTYPE" runat="server" AutoPostBack="True" CssClass="mandatory" onselectedindexchanged="DDL_APPTYPE_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Akomodasi Rekening</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_AA_NO" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_AA_NO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">No. Fasilitas</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_PRODUCTID" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_PRODUCTID_SelectedIndexChanged"></asp:dropdownlist><asp:dropdownlist id="DDL_FACILITYNO" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_FACILITYNO_SelectedIndexChanged"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Kredit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTDESC" MaxLength="80" runat="server" Width="300px" ReadOnly="True"
											BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD>
										<asp:Label id="LBL_PRODUCTID" runat="server" Visible="False"></asp:Label>
										<asp:Label id="LBL_USERID" runat="server" Visible="False"></asp:Label></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Limit</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_LIMIT" MaxLength="15" onkeypress="return numbersonly()" runat="server" ReadOnly="True"
											Width="200px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jangka Waktu</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_TENORDESC" runat="server" ReadOnly="True" Width="200px" BorderStyle="None"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tujuan Penggunaan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CP_LOANPURPOSE" runat="server"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
							<asp:DropDownList id="DDL_PROJECT" runat="server" Visible="False"></asp:DropDownList>
							<asp:label id="LBL_OLDJANGKAWKT" runat="server" Visible="False"></asp:label>
						</TD>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Limit Diminta</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:dropdownlist id="DDL_CP_LIMITCHG" runat="server" CssClass="mandatory">
											<asp:ListItem Value="+" Selected="True">+</asp:ListItem>
											<asp:ListItem Value="-">-</asp:ListItem>
										</asp:dropdownlist><asp:textbox id="TXT_CP_EXLIMITCHGTO" onkeypress="return digitsonly()" onkeyup="HitungLimit()"
											MaxLength="15" Width="200" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMITCHGTO'))" runat="server"
											CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Kurs Valuta ke Rp.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_EXRPLIMITCHGTO" onkeyup="HitungLimit()" onkeypress="return digitsonly()"
											MaxLength="15" onblur="FormatCurrency(this), FormatCurrency(document.getElementById('TXT_CP_LIMITCHGTO'))"
											runat="server" Width="200px" CssClass="mandatory">1</asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Limit Diminta in Rp.</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue">
										<asp:textbox id="TXT_CP_LIMITCHGTO" Width="200" onkeypress="return numbersonly()" MaxLength="15"
											runat="server"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 129px">Keterangan</TD>
									<TD style="WIDTH: 15px"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CP_NOTES" runat="server" Height="72px" TextMode="MultiLine" MaxLength="100"
											onkeypress="return kutip_satu()" Width="100%"></asp:textbox></TD>
								</TR>
							</TABLE>
							<asp:label id="LBL_MAINREGNO" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPROD_SEQ" runat="server" Visible="False"></asp:label>
							<asp:label id="LBL_MAINPRODUCTID" runat="server" Visible="False"></asp:label>
						</TD>
					</TR>
					<TR id="TR_BUTTONS" runat="server">
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">
                            <asp:button id="BTN_SAVE" runat="server" CssClass="Button1" Width="70px" 
                                Text="Simpan" onclick="BTN_SAVE_Click"></asp:button>&nbsp;
							<asp:button id="Button2" runat="server" CssClass="Button1" Width="70px" 
                                Text="Lanjut" Enabled="False"
								Visible="False" onclick="Button2_Click"></asp:button>
							<asp:button id="Button1" runat="server" CssClass="Button1" Width="150px" Visible="False" Text="Update Status"
								Enabled="False" onclick="Button1_Click"></asp:button></TD>
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
									<asp:BoundColumn DataField="CP_EXLIMITVAL" HeaderText="Limit">
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
		<asp:ListBox id="ListBox2" style="Z-INDEX: 101; LEFT: 761px; POSITION: absolute; TOP: 453px"
			runat="server" Width="8px" Visible="False" Height="20px"></asp:ListBox>
	</body>
</HTML>
