<%@ Page language="c#" Codebehind="InquiryStatus.aspx.cs" AutoEventWireup="True" Inherits="SME.Facilities.InquiryStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InquiryStatus</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_entries.html" -->
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table4" width="100%" border="0">
					<TR>
						<TD class="tdNoBorder" width="421"><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
							<TABLE id="Table6">
								<TR>
									<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Inquiry Status</B></TD>
								</TR>
							</TABLE>
						</TD>
						<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<TABLE class="td" id="Table1" cellSpacing="1" cellPadding="1" border="1" style="WIDTH: 590px; HEIGHT: 200px">
								<TR>
									<TD class="tdHeader1">Search Criteria</TD>
								</TR>
								<TR>
									<TD vAlign="top">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="TDBGColor1" width="160">Application Number</TD>
												<TD width="17"></TD>
												<TD class="TDBGColorValue" width="342">
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_APPNO" runat="server" MaxLength="20" Width="200px"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">
													Name</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_NAME" runat="server" MaxLength="50" Width="200px"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">Application Date</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:textbox id="TXT_DATE" runat="server" Columns="3" MaxLength="2" onkeypress="return numbersonly()"></asp:textbox>
													<asp:dropdownlist id="DDL_MONTH" runat="server"></asp:dropdownlist>
													<asp:textbox id="TXT_YEAR" runat="server" Columns="4" MaxLength="4" onkeypress="return numbersonly()"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">ID Number</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:TextBox onkeypress="return kutip_satu()" id="TXT_IDNUMBER" runat="server" MaxLength="30"
														Width="200px"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">Area</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DDL_AREA" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_AREA_SelectedIndexChanged"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1" width="160">Unit</TD>
												<TD></TD>
												<TD class="TDBGColorValue">
													<asp:DropDownList id="DDL_BRANCH" runat="server"></asp:DropDownList></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="center" colSpan="3" width="100%"><asp:button id="BTN_FIND" runat="server" Text="Find" Width="75px" CssClass="button1" onclick="BTN_FIND_Click"></asp:button>&nbsp;
													<asp:Button id="BTN_CLEAR" runat="server" Text="Clear" Width="75px" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:Button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="left" colSpan="2">
							<asp:Label id="Label2" runat="server" Font-Bold="True">Tracking Status</asp:Label></TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:Label id="LBL_APREGNO" runat="server" Font-Bold="True" Visible="False"></asp:Label>
							<p>
								<ASP:DATAGRID id="DatGrd" runat="server" CellPadding="1" Width="100%" AutoGenerateColumns="False"
									AllowPaging="True">
									<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
									<Columns>
										<asp:BoundColumn Visible="False" DataField="ap_regno" HeaderText="ap_regno"></asp:BoundColumn>
										<asp:BoundColumn DataField="trackcode" HeaderText="Track Code">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="trackNAME" HeaderText="Track Description">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="th_trackdate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="su_fullname" HeaderText="Updated By">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="sg_grpname" HeaderText="Unit">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="productid" HeaderText="PRODUCTID"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="apptype" HeaderText="APPTYPE"></asp:BoundColumn>
										<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
										<asp:BoundColumn DataField="SU_FULLNAME_NEXT" HeaderText="Next Update">
											<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
											<ItemStyle HorizontalAlign="Center"></ItemStyle>
										</asp:BoundColumn>
									</Columns>
								</ASP:DATAGRID></p>
							<ASP:DATAGRID id="DatGrd_App" runat="server" AutoGenerateColumns="False" PageSize="15" Width="100%"
								CellPadding="1" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="AP_REGNO" HeaderText="Applicaiton No">
										<HeaderStyle Width="10%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Nama" HeaderText="Name">
										<HeaderStyle Width="22%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ap_recvdate" HeaderText="Receive Date" DataFormatString="{0:dd-MMM-yyyy}">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cu_idcardnum" HeaderText="Card ID No">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PRODUCTDESC" HeaderText="Product">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PRODUCTID" HeaderText="PRODUCTID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="APPTYPE" HeaderText="APPTYPE"></asp:BoundColumn>
									<asp:BoundColumn DataField="APPTYPEDESC" HeaderText="Jenis Pengajuan">
										<HeaderStyle Width="15%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="PROD_SEQ" HeaderText="PROD_SEQ"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle Width="8%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="LINK_VIEW" runat="server" CommandName="View">View</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID>
						</TD>
					</TR>
					<TR id="TR_STATUS" runat="server">
						<TD class="tdH" colSpan="2">
							<table width="100%">
								<TR>
									<TD class="td" vAlign="top">
										<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">Application No.</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Application Seq.</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PROD_SEQ" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Application Type</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_APPTYPE" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Product ID</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_PRODUCTID" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">AA Ref No.</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AA_NO" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Account Seq.</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_ACC_SEQ" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Current Track</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_CURRTRACK" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<!-- Additional Field : Right -->
										</TABLE>
									</TD>
									<TD class="td" vAlign="top">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
											<TR>
												<TD class="TDBGColor1">RM</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_RELMNGR" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">CA</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_CA" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">CO Unit</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_CCOBRANCH" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">CO Officer</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_CO" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Current Approval</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_APRVNEXTBY" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">Final Approval</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_APRVUNTIL" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">PIC Approval Committee</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_APRVCOMMITEE" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<TR>
												<TD class="TDBGColor1">PS Risk Verification</TD>
												<TD style="WIDTH: 15px">:</TD>
												<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_PRRKBY" runat="server" ReadOnly="True" Width="100%" BorderStyle="None"></asp:textbox></TD>
											</TR>
											<!-- Additional Field : Right -->
										</TABLE>
									</TD>
								</TR>
							</table>
						</TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
					<tr>
						<td class="tdH" colspan="2" align="center" style="VISIBILITY: hidden">
							<table width="500">
								<TR>
									<TD width="50%" align="center" vAlign="top">
										<FIELDSET>
											<legend>
												<asp:Label id="LBL_PRODUCTID" runat="server" Font-Bold="True">M e m o</asp:Label>
											</legend>
											<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD width="100%" align="left">
														<asp:TextBox id="TextBox4" onkeypress="return kutip_satu()" runat="server" Width="320px" Height="48px"
															TextMode="MultiLine"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD width="100%" align="center">
														<asp:Button id="BTN_VIEWSAVE" runat="server" Text="View" Width="75px" CssClass="button1"></asp:Button>&nbsp;
														<asp:Button id="BTN_NEWCANCEL" runat="server" Text="New" Width="75px" CssClass="button1"></asp:Button></TD>
												</TR>
											</TABLE>
										</FIELDSET>
									</TD>
									<TD width="50%" align="center" vAlign="top">
										<FIELDSET>
											<LEGEND>
												<asp:Label id="Label1" runat="server" Font-Bold="True">Facilities</asp:Label>
											</LEGEND>
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
												<TR>
													<TD width="100%" align="center">
														<asp:Button id="BTN_INFO" runat="server" Text="  Customer Info  " Width="179px" CssClass="button1"></asp:Button></TD>
												</TR>
												<TR>
													<TD width="100%" align="center">
														<asp:Button id="BTN_MISSDOC" runat="server" Text="Missing Document" Width="179" CssClass="button1"></asp:Button></TD>
												</TR>
												<TR>
													<TD width="100%"></TD>
												</TR>
											</TABLE>
										</FIELDSET>
									</TD>
								</TR>
							</table>
						</td>
					<TR>
						<TD width="50%" vAlign="top">
						</TD>
						<TD width="50%" vAlign="top">
						</TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
