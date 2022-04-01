<%@ Page language="c#" Codebehind="TrackList.aspx.cs" AutoEventWireup="True" Inherits="SME.HDRS.TrackList" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>TrackList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
function print_frame() {
	//window.parent.framelkkn.focus();
	tr_print.style.display = "none";
	window.print();
	tr_print.style.display = "";
}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<table>
					<tr id="tr_print" align="center">
						<td width="3%" colSpan="2"><INPUT class="button1" id="BTN_PRINT" onclick="print_frame();" type="button" value="Print"
								name="BTN_PRINT"><INPUT class="button1" id="BTN_BACK" onclick="javascript:history.back();" type="button"
								value="Back" name="BTN_BACK">
						</td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<tr align="center">
						<td class="td" colSpan="2"><STRONG>QUESTION AND ANSWER</STRONG></td>
					</tr>
					<tr>
						<td></td>
					</tr>
					<TR width="100%">
						<TD colSpan="2"><ASP:DATAGRID id="DGR_QA" runat="server" AutoGenerateColumns="False" CellPadding="1" AllowPaging="True"
								Width="100%" PageSize="20" DESIGNTIMEDRAGDROP="466">
								<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="PROBLEM TYPE" DataField="prob_desc">
										<HeaderStyle Width="20%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="QUESTION" DataField="h_problem">
										<HeaderStyle Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn HeaderText="ANSWER" DataField="h_respon">
										<HeaderStyle Width="40%" CssClass="tdSmallHeader"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle Mode="NumericPages"></PagerStyle>
							</ASP:DATAGRID></TD>
					</TR>
				</table>
			</center>
		</form>
	</body>
</HTML>
