<%@ Page language="c#" Codebehind="ScoreRatingData.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.ScoreRatingData" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Relation With Bank</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/child.html" -->
		<script language="javascript">
			function cek_mandatory(frm, alamat)
			{
				max_elm = (frm.elements.length) - 2;
				lanjut = true;
				for (var i=1; i<=max_elm; i++)
				{
					elm = frm.elements[i];
					nm_kolom = "kotak";
					if (elm.className == "mandatory" && elm.value == "" && (elm.type == "text" || elm.type == "select-one"))
					{
						r = elm.parentElement.parentElement;
						d = r.cells(0).innerText;
						alert(d + " tidak boleh kosong...");
						lanjut = false;
						elm.focus();
						return false;
					}
				}
				return true;
			}
		</script>
		<script language="vbscript">
		function HitungLimit()
			SetLocale("in")
			set obj = document.Form1
			if isnumeric(obj.TXT_CG_CASHLOAN.value) then
				CASHLOAN = cdbl(obj.TXT_CG_CASHLOAN.value)
			else
				CASHLOAN = 0
			end if
			
			if isnumeric(obj.TXT_CG_NONCASHLOAN.value) then
				NONCASHLOAN = cdbl(obj.TXT_CG_NONCASHLOAN.value)
			else
				NONCASHLOAN = 0
			end if
			
			if isnumeric(obj.TXT_CG_OTHERS.value) then
				OTHERS = cdbl(obj.TXT_CG_OTHERS.value)
			else
				OTHERS = 0
			end if
			
			obj.TXT_CG_TOTAL.value = CASHLOAN + NONCASHLOAN + OTHERS	
			obj.TXT_CG_TOTAL.value = replace(obj.TXT_CG_TOTAL.value, ".", ",")
		end function			
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Scoring &amp; Rating 
							Data</TD>
					</TR>
					<TR>
						<TD class="td" vAlign="top" width="50%" style="HEIGHT: 136px" colSpan="1">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 22px" width="164">Prior Default 
										with Losses</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
										<asp:radiobuttonlist id="RDO_PRIORRESULT_LOSS" runat="server" RepeatDirection="Horizontal" Width="79px"
											Height="16px" onselectedindexchanged="RDO_PRIORRESULT_LOSS_SelectedIndexChanged">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 22px" width="164">Customer 
										Default Now</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
										<asp:radiobuttonlist id="RDO_REVOLVING_NOW" runat="server" RepeatDirection="Horizontal" Width="79px"
											Height="16px">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1" style="WIDTH: 164px; HEIGHT: 22px" width="164">Default with 
										Losses (CRG)</TD>
									<TD style="WIDTH: 15px; HEIGHT: 22px"></TD>
									<TD class="TDBGColorValue" style="HEIGHT: 22px">
										<asp:radiobuttonlist id="RDO_DEFAULT_LOSS" runat="server" RepeatDirection="Horizontal" Width="79px" Height="16px">
											<asp:ListItem Value="1">Yes</asp:ListItem>
											<asp:ListItem Value="0" Selected="True">No</asp:ListItem>
										</asp:radiobuttonlist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<!--<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Saldo Rata-rata dan Mutasi Rekening 
							Selama 6 Bulan Terakhir</TD>
					</TR>-->
					<TR>
						<TD style="HEIGHT: 1px" vAlign="top" colSpan="2"></TD>
					</TR>
					<!--<TR>
						<TD class="tdHeader1" vAlign="top" colSpan="2">Internal Checking</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" colSpan="2"><ASP:DATAGRID id="DatGridIC" runat="server" Width="95%" AutoGenerateColumns="False" PageSize="1"
								CellPadding="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" HeaderText="curef"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Category">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Confirm Information Bank">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Date">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="Remark">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="45px" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</ASP:DATAGRID></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 3px" vAlign="top" align="center" colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 3px" vAlign="top" align="center" colSpan="2">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="90%">
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Category</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:dropdownlist id="Dropdownlist6" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Confirm 
													Information Bank</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="Textbox13" runat="server" MaxLength="30"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 128px" align="right" width="128">Date</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="Textbox8" runat="server" Columns="4" Width="24px" MaxLength="2"></asp:textbox>
													<asp:dropdownlist id="Dropdownlist5" runat="server"></asp:dropdownlist>
													<asp:textbox id="Textbox7" runat="server" Columns="4" Width="36px" MaxLength="4"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 147px" align="right" width="147">Remark</TD>
												<TD style="WIDTH: 15px"></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="Textbox9" runat="server" Width="192px" MaxLength="20" TextMode="MultiLine" Height="70px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:button id="Button2" runat="server" Text="Insert"></asp:button></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>-->
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_SAVE" runat="server" Width="101" CssClass="Button1" Text="Save" Height="26" onclick="BTN_SAVE_Click"></asp:button>
							<INPUT class="Button1" style="WIDTH: 101px; HEIGHT: 26px" type="button" value="Close" onclick="javascript:window.close()"></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:radiobuttonlist id="RDO_CURR_KOLEKTIBILITAS" runat="server" RepeatDirection="Horizontal" Height="16px"
								Visible="False">
								<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
								<asp:ListItem Value="0">No</asp:ListItem>
							</asp:radiobuttonlist>
							<asp:DropDownList id="DDL_APP_CUR_COLLECTABILITAS" runat="server" Visible="False"></asp:DropDownList>
							<asp:radiobuttonlist id="RDO_RESTRUKTUR_KREDIT" runat="server" RepeatDirection="Horizontal" Height="16px"
								Visible="False">
								<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
								<asp:ListItem Value="0">No</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
