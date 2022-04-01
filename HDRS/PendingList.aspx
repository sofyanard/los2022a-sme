<%@ Page language="c#" Codebehind="PendingList.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.PendingList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PendingList</title>
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
          ><B>PENDING PROBLEM 
          LIST</B></TD></TR></TABLE></TD>
    <td align=right><A href="../Body.aspx" ><IMG src="../Image/MainMenu.jpg" ></A><A href="../Logout.aspx" target=_top ><IMG src="../Image/Logout.jpg" ></A></TD></TR>
  <TR>
    <TD align=center colSpan=2>
      <TABLE class=td id=Table1 style="WIDTH: 590px; HEIGHT: 200px" 
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
                ><asp:textbox onkeypress="return kutip_satu()" id=TXT_HRS runat="server" Width="280px" MaxLength="20"></asp:textbox></TD></TR>
              <TR>
                <TD class=TDBGColor1>Aplication#</TD>
                <TD width=17></TD>
                <TD class=TDBGColorValue style="WIDTH: 342px" width=342 
                ><asp:textbox onkeypress="return kutip_satu()" id=TXT_AP runat="server" Width="280px" MaxLength="20"></asp:textbox></TD></TR>
              <TR>
                <TD class=TDBGColor1>Customer Name</TD>
                <TD></TD>
                <TD class=TDBGColorValue style="WIDTH: 342px" 
                ><asp:textbox onkeypress="return kutip_satu()" id=TXT_CUST runat="server" Width="280px" MaxLength="25"></asp:textbox></TD></TR>
              <TR>
                <TD class=TDBGColor1>PIC Respon Unit</TD>
                <TD></TD>
                <TD class=TDBGColorValue style="WIDTH: 342px" 
                ><asp:dropdownlist id=DDL_PIC2 runat="server" AutoPostBack="True"></asp:dropdownlist></TD></TR>
              <TR>
                <TD style="WIDTH: 521px" vAlign=top align=center colSpan=3 
                ></TD></TR></TABLE><asp:button id=BTN_FIND runat="server" Width="100px" Text="FIND" CssClass="button1" onclick="BTN_FIND_Click"></asp:button><asp:button id=BTN_CLEAR runat="server" Width="100px" Text="CLEAR" CssClass="button1" onclick="BTN_CLEAR_Click"></asp:button></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=center colSpan=2>&nbsp;</TD></TR>
  <TR>
    <TD colSpan=2><ASP:DATAGRID id=DGR_PROBLEM runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="HRS#" DataField="H_HRS#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" Width="200px"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="H_APP#" HeaderText="APPLICATION#">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="H_CUSTOMER" HeaderText="CUSTOMER NAME">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SU_FULLNAME" HeaderText="SEND BY">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="H_UNIT" HeaderText="UNIT SEND BY ">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SEND_TO" HeaderText="PIC RESPON">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="sg_grpname" HeaderText="PIC RESPON UNIT">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="FUNCTION">
										<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
										<ItemTemplate>
											<asp:LinkButton id="edit_cab" runat="server" CommandName="View">View</asp:LinkButton>&nbsp;
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD></TR>
  <TR></TR>
					<TR>
						<TD class="tdH" colSpan="2"></TD>
					</TR>
					<TR>
						<TD class="tdH" colSpan="2"><asp:label id="Label1" runat="server"></asp:label></TD>
					</TR></TABLE></CENTER></FORM>
	</body>
</HTML>
