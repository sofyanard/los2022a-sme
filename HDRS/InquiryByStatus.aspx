<%@ Page language="c#" Codebehind="InquiryByStatus.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.InquiryByStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>InquiryByStatus</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../Style.css" type=text/css rel=stylesheet >
  </HEAD>
<body MS_POSITIONING="GridLayout">
<form id=Form1 method=post runat="server">
<center>
<TABLE id=Table4 width="100%" border=0>
  <TR>
    <TD align=left colSpan=1>
      <TABLE id=Table3>
        <TR>
          <TD class=tdBGColor2 style="WIDTH: 400px" align=center 
          ><B>INQUIRY BY 
        STATUS</B></TD></TR></TABLE></TD>
    <td align=right><asp:imagebutton id=BTN_BACK runat="server" ImageUrl="/SME/Image/back.jpg" onclick="BTN_BACK_Click"></asp:imagebutton><A href="../Body.aspx" ></A><A href="../Body.aspx" ><IMG src="../Image/MainMenu.jpg" ></A><A href="../Logout.aspx" target=_top ><IMG src="../Image/Logout.jpg" ></A></TD></TR>
  <TR>
    <TD align=center colSpan=2>
      <TABLE class=td id=Table1 style="WIDTH: 590px; HEIGHT: 100px" 
      cellSpacing=1 cellPadding=1 width=590 border=1>
        <TR>
          <TD class=tdHeader1>SEARCH CRITERIA</TD></TR>
        <TR>
          <TD vAlign=middle align=center>
            <TABLE id=Table2 cellSpacing=0 cellPadding=0 width="100%" border=0 
            >
              <TR>
                <TD class=TDBGColor1>HRS#</TD>
                <TD width=17></TD>
                <TD class=TDBGColorValue style="WIDTH: 342px" width=342 
                ><asp:textbox onkeypress="return kutip_satu()" id=TXT_HRS runat="server" MaxLength="20" Width="280px"></asp:textbox></TD></TR>
              <TR>
                <TD class=TDBGColor1>Application#</TD>
                <TD width=17></TD>
                <TD class=TDBGColorValue style="WIDTH: 342px" width=342 
                ><asp:textbox onkeypress="return kutip_satu()" id=TXT_AP runat="server" MaxLength="20" Width="280px"></asp:textbox></TD></TR>
              <TR>
                <TD class=TDBGColor1>Customer Name</TD>
                <TD></TD>
                <TD class=TDBGColorValue style="WIDTH: 342px" 
                ><asp:textbox onkeypress="return kutip_satu()" id=TXT_CUST runat="server" MaxLength="25" Width="280px"></asp:textbox></TD></TR>
              <TR>
                <TD style="WIDTH: 521px" vAlign=top align=center colSpan=3 
                ></TD></TR></TABLE><asp:button id=btn_Find runat="server" Width="100px" CssClass="button1" Text="FIND" onclick="btn_Find_Click"></asp:button><asp:button id=btn_Clear runat="server" Width="100px" CssClass="button1" Text="CLEAR" onclick="btn_Clear_Click"></asp:button></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=center colSpan=2>&nbsp;</TD></TR>
  <TR id=TR_CUR runat="server">
    <TD colSpan=2><ASP:DATAGRID id=DGR_CUR runat="server" Width="100%" AllowPaging="True" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="hth_hrs#" HeaderText="HRS#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="h_received_date" HeaderText="HRS DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="h_customer" HeaderText="CUSTOMER NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="curtrack" HeaderText="CURRENT TRACK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="su_fullname" HeaderText="TRACK BY">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="hth_status" HeaderText="STATUS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="View" HeaderText="Function" CommandName="View">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="60px"></ItemStyle>
									</asp:ButtonColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD></TR>
  <TR id=TR_LIST runat="server">
    <TD colSpan=2><ASP:DATAGRID id=DGR_LIST runat="server" Width="100%" CellPadding="1" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn DataField="hth_hrs#" HeaderText="HRS#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="h_received_date" HeaderText="HRS DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="curtrack" HeaderText="CURRENT TRACK">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="hth_trackdate" HeaderText="TRACK DATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="su_fullname" HeaderText="TRACK BY">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="next_update" HeaderText="NEXT UPDATE">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="hth_status" HeaderText="STATUS">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD></TR>
  <TR></TR>
  <TR>
    <TD class=tdH colSpan=2></TD></TR>
  <TR>
    <TD class=tdH colSpan=2><asp:label id=Label1 runat="server"></asp:label></TD></TR></TABLE></CENTER></FORM>
	</body>
</HTML>
