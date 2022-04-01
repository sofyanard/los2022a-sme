<%@ Page language="c#" Codebehind="eBizCardPola.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.eBizCardPola" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>eBizCardPola</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatoryOnly.html" -->
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<asp:label id="lbl_CU_CUSTTYPEID" runat="server" Visible="False"></asp:label>
					<TR>
						<TD class="tdHeader1" vAlign="top" width="45%" colSpan="2">eBiz Card Info</TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">Distributor</TD>
						<TD>
							:
							<asp:DropDownList id="DDL_DIST" runat="server" Width="208px" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_DIST_SelectedIndexChanged"></asp:DropDownList></TD>
					</TR>
					<TR>
						<TD class="TDBGColor1">Distributor Code</TD>
						<TD>:
							<asp:DropDownList id="DDL_DISTCODE" runat="server" Width="208px" CssClass="mandatory"></asp:DropDownList></TD>
					</TR>
					<%if (Request.QueryString["de"] == "1") {%>
					<TR>
						<TD vAlign="top" align="center" width="45%" colSpan="2">
							<asp:Button id="BTN_SAVEDIST" runat="server" CssClass="button1" Text="Save" onclick="BTN_SAVEDIST_Click"></asp:Button></TD>
					</TR>
					<%}%>
					<TR>
						<TD class="td" vAlign="top" width="45%" colSpan="2"><ASP:DATAGRID id="DGR_EBIZ" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="1"
								PageSize="5" AutoGenerateColumns="False" Width="944px">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="AP_REGNO" HeaderText="AP_REGNO"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="SEQ" HeaderText="Seq">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="NAME" SortExpression="NAME" HeaderText="Name">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IDCARDNUM" SortExpression="IDCARDNUM" HeaderText="No. KTP">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ISSUANCEDATE" SortExpression="ISSUANCEDATE" HeaderText="Tanggal Issue"
										DataFormatString="{0:dd-MMM-yyy}">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ENDORSENAME_1" SortExpression="ENDORSENAME_1" HeaderText="Endorse Name 1">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ENDORSENAME_2" SortExpression="ENDORSENAME_2" HeaderText="Endorse Name 2">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LinkButton1" runat="server" CommandName="edit">Edit</asp:LinkButton>&nbsp;
											<asp:LinkButton id="LinkButton2" runat="server" CommandName="delete">Delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID><BR>
							<TABLE id="TBL_INPUT" cellSpacing="2" cellPadding="2" width="100%" border="0" runat="server">
								<TR>
									<TD class="td" vAlign="top" width="50%">
										<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="WIDTH: 129px" width="129">Nama</TD>
												<TD style="WIDTH: 17px"></TD>
												<TD class="TDBGColorValue" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_EBIZ_FIRSTNAME" runat="server" Width="300px"
														CssClass="mandatory" MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_EBIZ_MIDDLENAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox><BR>
													<asp:textbox onkeypress="return kutip_satu()" id="TXT_EBIZ_LASTNAME" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 129px"></TD>
												<TD></TD>
												<TD align="left"></TD>
											</TR>
										</TABLE>
										<asp:label id="LBL_SEQ" runat="server" Visible="False"></asp:label>
										<asp:Label id="LBL_DISTTYPE" runat="server" Visible="False" Width="56px"></asp:Label></TD>
									<TD class="td" vAlign="top" align="center">
										<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px" width="125">Nomor KTP</TD>
												<TD style="WIDTH: 17px; HEIGHT: 14px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 14px" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_EBIZ_IDCARDNUM" runat="server" Width="300px"
														CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 14px" width="125">KTP Issued Date</TD>
												<TD style="WIDTH: 17px; HEIGHT: 14px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 14px" align="left"><asp:textbox onkeypress="return numbersonly()" id="TXT_EBIZ_ISSUE_DAY" runat="server" Width="24px"
														MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_EBIZ_ISSUE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_EBIZ_ISSUE_YEAR" runat="server" Width="36px"
														MaxLength="4" Columns="4"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 9px" width="125">Endorse Name 1</TD>
												<TD style="WIDTH: 17px; HEIGHT: 9px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 9px" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ENDORSENAME_1" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" style="HEIGHT: 6px" width="125">Endorse Name 2</TD>
												<TD style="WIDTH: 17px; HEIGHT: 6px"></TD>
												<TD class="TDBGColorValue" style="HEIGHT: 6px" align="left"><asp:textbox onkeypress="return kutip_satu()" id="TXT_ENDORSENAME_2" runat="server" Width="300px"
														MaxLength="50"></asp:textbox></TD>
											</TR>
										</TABLE>
										<BR>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<%if (Request.QueryString["de"] == "1") {%>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><asp:button id="BTN_NEW" runat="server" Width="101" CssClass="Button1" Text="New" onclick="BTN_NEW_Click"></asp:button><asp:button id="BTN_SAVE" runat="server" Visible="False" Width="101" CssClass="Button1" Text="Save" onclick="BTN_SAVE_Click"></asp:button><asp:button id="BTN_UPDATE" runat="server" Visible="False" Width="101" CssClass="Button1" Text="Update" onclick="BTN_UPDATE_Click"></asp:button><asp:button id="BTN_CANCEL" runat="server" Visible="False" Width="101" CssClass="Button1" Text="Cancel" onclick="BTN_CANCEL_Click"></asp:button></TD>
					</TR>
					<%}%>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2"><INPUT class="button1" id="BTN_CLOSE" style="WIDTH: 101px" onclick="window.close()" type="button"
								value="Close"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
