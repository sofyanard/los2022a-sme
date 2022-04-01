<%@ Page language="c#" Codebehind="AssignmentComplyMain.aspx.cs" AutoEventWireup="True" Inherits="SME.Booking.Channeling.AssignmentComplyMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Verification Assignment</title>
<META http-equiv=Content-Type content="text/html; charset=windows-1252">
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../style.css" type=text/css rel=stylesheet >
		<!-- #include  file="../../include/cek_entries.html" -->
		<!-- #include  file="../../include/onepost.html" -->
		<!-- #include  file="../../include/ConfirmBox.html" -->
		<!-- #include  file="../../include/cek_mandatoryOnly.html" -->
		<!-- #include  file="../../include/popup.html" -->
  </HEAD>
<body leftMargin=0 topMargin=0 MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server">
<center>
<TABLE id=Table1 cellSpacing=2 cellPadding=2 width="100%" 
  ><TBODY>
  <TR>
    <TD class=tdNoBorder><!--<img src="../Image/HeaderDetailDataEntry.jpg">-->
      <TABLE id=Table2>
        <TR>
          <TD class=tdBGColor2 style="WIDTH: 400px" align=center 
          ><B><B 
            >Comply, Review and Legal Doc 
          </B>Condition</B></TD></TR></TABLE></TD>
    <TD class=tdNoBorder align=right><A href="ListBooking.aspx?mc=CHAN007&amp;tc=TCHAN7.0" ></A><asp:imagebutton id=BTN_BACK runat="server" ImageUrl="/SME/Image/back.jpg"></asp:imagebutton><A href="../../Body.aspx" ><IMG src="/SME/Image/MainMenu.jpg" ></A><A href="../../Logout.aspx" target=_top ><IMG src="/SME/Image/Logout.jpg" ></A></TD></TR>
  <TR>
    <TD class=tdNoBorder style="HEIGHT: 41px" align=center colSpan=2 
    ><asp:placeholder id=Menu 
      runat="server"></asp:placeholder></TD></TR>
  <TR>
    <TD class=tdHeader1 colSpan=2>GENERAL INFO</TD></TR>
  <TR>
    <TD class=td vAlign=top width="50%">
      <TABLE id=Table6 cellSpacing=0 cellPadding=0 width="100%" 
      >
        <TR>
          <TD class=TDBGColor1 style="WIDTH: 886px; HEIGHT: 23px" 
          >Business Unit </TD>
          <TD style="WIDTH: 1px; HEIGHT: 23px">:</TD>
          <TD class=TDBGColorValue style="HEIGHT: 23px"><asp:dropdownlist id=DDL_AP_BOOKINGBRANCH runat="server" CssClass="mandatory" Width="300px" Enabled="False"></asp:dropdownlist></TD></TR>
        <TR>
          <TD class=TDBGColor1 style="WIDTH: 886px">CO 
            Unit </TD>
          <TD style="WIDTH: 1px">:</TD>
          <TD class=TDBGColorValue><asp:dropdownlist id=DDL_AP_CCOBRANCH runat="server" CssClass="mandatory" Width="300px" Enabled="False"></asp:dropdownlist></TD></TR></TABLE></TD>
    <TD class=td vAlign=top width="50%">
      <TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%" 
      >
        <TR>
          <TD class=TDBGColor1 width=150>Application Date 
          </TD>
          <TD style="WIDTH: 1px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=txt_DD_B runat="server" CssClass="mandatory" Width="40px" Enabled="False"></asp:textbox>&nbsp; 
<asp:dropdownlist id=ddl_MM_B runat="server" CssClass="mandatory" Width="152px" Enabled="False"></asp:dropdownlist>&nbsp; 
<asp:textbox id=txt_YY_B runat="server" CssClass="mandatory" Width="80px" Enabled="False"></asp:textbox></TD></TR>
        <TR>
          <TD class=TDBGColor1>Application Number </TD>
          <TD style="WIDTH: 1px">:</TD>
          <TD class=TDBGColorValue><asp:textbox id=TXT_APPLICATION runat="server" CssClass="mandatory" Width="290px" Enabled="False" ReadOnly="True" BorderStyle="None"></asp:textbox></TD></TR></TABLE></TD></TR>
  <TR>
    <TD class=tdNoBorder align=center colSpan=2 
  ></TD></TR></TBODY></TABLE>
<table cellSpacing=2 cellPadding=2 width="100%">
  <TR>
    <TD class=tdHeader1 colSpan=3>PLAFOND INFO</TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 49%" width=484 
      >Plafond Owner</TD>
    <TD style="WIDTH: 1%">:</TD>
    <TD class=TDBGColorValue><asp:label id=LBL_PLAFOND_OWNER runat="server" Width="320px">Label</asp:label></TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 49%">Remainaning 
      eMAS Limit</TD>
    <TD style="WIDTH: 1%">:</TD>
    <TD class=TDBGColorValue><asp:label id=LBL_REMAINING_EMAS runat="server" Width="320px">Label</asp:label></TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 49%">Pending 
    Limit</TD>
    <TD style="WIDTH: 1%">:</TD>
    <TD class=TDBGColorValue><asp:label id=LBL_PENDING_LIMIT runat="server" Width="320px">Label</asp:label></TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 49%">Available 
      Limit</TD>
    <TD style="WIDTH: 1%">:</TD>
    <TD class=TDBGColorValue><asp:label id=LBL_AVAILBALE_LIMIT runat="server" Width="320px">Label</asp:label></TD></TR>
  <TR>
    <TD class=tdNoBorder align=center colSpan=3 
  ></TD></TR></TABLE>
<table cellSpacing=2 cellPadding=2 width="100%">
  <TR>
    <TD class=tdHeader1 colSpan=3>LEGAL SIGNING 
    CONDITION</TD></TR>
  <TR id=TR_LEGALSIGNING2 runat="server">
    <TD class=TDBGColor1 style="WIDTH: 16.78%">Syarat</TD>
    <TD style="WIDTH: 0.09%">:</TD>
    <TD class=TDBGColorValue><asp:dropdownlist id=DDL_PROSES runat="server" CssClass="mandatory" Width="670px"></asp:dropdownlist></TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 16.78%">Tanggal 
      Dipenuhi</TD>
    <TD style="WIDTH: 0.09%">:</TD>
    <TD class=TDBGColorValue><asp:textbox id=TXT_TGL runat="server" CssClass="mandatory" Width="32px"></asp:textbox>&nbsp; 
<asp:dropdownlist id=DDL_BLN runat="server" CssClass="mandatory" Width="136px"></asp:dropdownlist><asp:textbox id=TXT_THN runat="server" CssClass="mandatory" Width="88px"></asp:textbox><asp:label id=LBL_REGNO Runat="server" Visible="False"></asp:label><asp:label id=LBL_TC Runat="server" Visible="False"></asp:label></TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 16.78%" 
    >Keterangan</TD>
    <TD style="WIDTH: 0.09%">:</TD>
    <TD class=TDBGColorValue><asp:textbox id=TXT_KET runat="server" Width="654px" Height="88px" TextMode="MultiLine"></asp:textbox>&nbsp; 
    </TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 16.78%">Next 
      Periode</TD>
    <TD style="WIDTH: 0.09%">:</TD>
    <TD class=TDBGColorValue><asp:textbox id=TXT_COV_NEXTDATE_DAY2 runat="server" Width="32px"></asp:textbox>&nbsp; 
<asp:dropdownlist id=DDL_COV_NEXTDATE_MONTH2 runat="server" Width="136px"></asp:dropdownlist><asp:textbox id=TXT_COV_NEXTDATE_YEAR2 runat="server" Width="88px"></asp:textbox></TD></TR>
  <TR>
    <TD class=TDBGColor1 style="WIDTH: 16.78%">Status</TD>
    <TD style="WIDTH: 0.09%">:</TD>
    <TD class=TDBGColorValue><asp:checkbox id=CHK_COV_ISFINISH2 runat="server" Text="Check For Finished"></asp:checkbox></TD></TR>
  <TR>
    <TD class=tdNoBorder style="WIDTH: 133px" align=left 
    ></TD></TR></TABLE>
<table style="WIDTH: 100%; HEIGHT: 36px">
  <TR id=TR_LEGALSIGNING runat="server">
    <TD class=TDBGColor2 vAlign=top align=center colSpan=2><asp:button id=BTN_DF_INPUT runat="server" CssClass="BUTTON1" Width="153px" Text="SAVE" onclick="BTN_DF_INPUT_Click"></asp:button><asp:button id=BTN_PRINT runat="server" CssClass="BUTTON1" Width="150px" Text="PRINT" onclick="BTN_PRINT_Click"></asp:button><asp:button id=BTN_UPDATE runat="server" CssClass="BUTTON1" Width="153px" Text="UPDATE STATUS" onclick="BTN_UPDATE_Click"></asp:button><asp:button id=BTN_RETURNTOBU runat="server" CssClass="BUTTON1" Width="153px" Text="RETURN TO BU" onclick="BTN_RETURNTOBU_Click"></asp:button></TD></TR>
  <TR>
    <TD class=td colSpan=2><asp:datagrid id=DGR_LIST runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False" PageSize="1">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="seq" HeaderText="seq"></asp:BoundColumn>
									<asp:BoundColumn DataField="des" HeaderText="Syarat">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_accdate" HeaderText="Tanggal Dipenuhi">
										<HeaderStyle HorizontalAlign="Center" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sy_ket" HeaderText="Keterangan">
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
														<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
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
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:ButtonColumn>
									<asp:TemplateColumn HeaderText="Next Periode">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_COV_NEXTDATE_DAY" Columns="2" runat="server" 
 MaxLength="2"></asp:textbox>
											<asp:dropdownlist id="DDL_COV_NEXTDATE_MONTH" runat="server"></asp:dropdownlist>
											<asp:textbox onkeypress="return numbersonly()" id="TXT_COV_NEXTDATE_YEAR" Columns="4" runat="server" 
 MaxLength="4"></asp:textbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Status">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:checkbox id="CHK_COV_ISFINISH" runat="server" Text="Finish"></asp:checkbox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="Linkbutton1" runat="server" CommandName="delete">delete</asp:LinkButton>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn Visible="False" DataField="COV_NEXTDATE"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="COV_ISFINISH"></asp:BoundColumn>
								</Columns>
							</asp:datagrid><asp:textbox id=TXT_TEMP_PK runat="server" Width="1px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD></TR>
  <TR>
    <TD class=tdHeader1 colSpan=2>End User Facility</TD></TR>
  <TR>
    <TD class=td colSpan=2><asp:datagrid id=dgListEndUser runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False" PageSize="1" ShowFooter="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="USERNAME" HeaderText="End User Name">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APREGNO" HeaderText="Application No">
										<HeaderStyle HorizontalAlign="Center" Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FACILITY" HeaderText="Facility">
										<HeaderStyle Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Function">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:RadioButton id="rdo_yes" runat="server" GroupName="rdg_Decision" Text="Continue"></asp:RadioButton>
											<asp:RadioButton id="rdo_no" runat="server" GroupName="rdg_Decision" Text="Pending" Checked="True"></asp:RadioButton>
										</ItemTemplate>
										<FooterStyle HorizontalAlign="Center"></FooterStyle>
										<FooterTemplate>
											<asp:LinkButton id="Linkbutton4" runat="server" CommandName="yesall">All Cont</asp:LinkButton>
											<asp:LinkButton id="Linkbutton3" runat="server" CommandName="noall">All Pend</asp:LinkButton>
										</FooterTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></TD></TR></TABLE>
				<!-- <table id="TBL_FILEUPLOAD" cellSpacing="0" cellPadding="0" width="100%" runat="server">
					<tr>
						<td align="center">
							<iframe id="if2" width="100%" height="510" name="if2" src="..\..\..\CreditOperations\COUploadFile.aspx?regno=<%=Request.QueryString["regno"]%>">
							</iframe>
						</td>
					</tr>
				</table> --></CENTER></FORM>
	</body>
</HTML>
