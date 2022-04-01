<%@ Page language="c#" Codebehind="arAlternateRate.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.arAlternateRate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alternate Rate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/child.html" -->
		<!-- #include file="../include/popup.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
		function numberscommaonly()
		{
			//alert(event.keyCode);
			if ((event.keyCode>=48) && (event.keyCode<=57))
			{ // membolehkan input digit
				return true;
			} else if (event.keyCode == 44)
			{ // membolehkan input
				return true;
			} else
			{
				return false;
			}
		}
		function enableFixed()
		{
			Form1.TXT_FLOATINGRATE.value = "";
			Form1.TXT_FLOATINGRATE.Readonly = true;
			Form1.TXT_FIXEDRATE.Readonly = false;
			Form1.TXT_VARIANCE.value = "";
			Form1.TXT_VARIANCE.disabled = true;
			//Form1.DDL_CODE.SelectedIndex = 1;
			Form1.DDL_CODE.disabled = true;
			//Form1.DDL_CODE.
		}
		
		function enableFloat()
		{	
			Form1.TXT_FIXEDRATE.value = "";
			Form1.TXT_FIXEDRATE.Readonly = true;
			Form1.TXT_FLOATINGRATE.Readonly = false;
			Form1.TXT_VARIANCE.disabled = false;
			Form1.DDL_CODE.disabled = false;
		}
		</script>
		<script language="vbscript">
					
			
			Function viewSumTenor()
				SetLocale("in")
				If IsNumeric(Form1.TXT_OLD_TENOR.value) Then
					old_tenor = CInt(Form1.TXT_OLD_TENOR.value)
				Else
					old_tenor = 0
				End If
				'MsgBox old_tenor
				If IsNumeric(Form1.TXT_TENOR.value) Then
					tenor = Int(Form1.TXT_TENOR.value)
				Else
					tenor = 0
				End If
				sumtenor = old_tenor + tenor
				Form1.TXT_SUM_TENOR.value = sumtenor
			End Function
			
			Function strBiasa(strval)
				strBiasa = Replace(strval,"%","")
				strBiasa = Replace(strval,",00","")
				strBiasa = Replace(strBiasa,".","")
				strBiasa = Replace(strBiasa,",",".")
			End Function
			
			Function calcInstallment()
				SetLocale("in")
				Set obj = Document.Form1
				'jika tipenya bukan installment maka dilakukan kalkulasi installment
				'If obj.TXT_IS_INSTALLMENT.value = "YES" Then
					'tuliskan saja nilai installment yang diperoleh dari struktur kredit
					'lalu exit
					'FormatCurrency(obj.TXT_INSTALLMENT)
					'Exit Function
				'End If
				'MsgBox "Heli" & obj.TXT_IS_INSTALLMENT.value
				
				If IsNumeric(obj.TXT_TENOR.value) Then
					tenor = CDbl(obj.TXT_TENOR.value)
				Else
					tenor = 0
				End If 
				If IsNumeric(obj.TXT_FIXEDRATE.value) Then
					fixedrate = CDbl(obj.TXT_FIXEDRATE.value)
				Else
					fixedrate = 0
				End If 
				If IsNumeric(obj.TXT_FLOATINGRATE.value) Then
					floatrate = CDbl(obj.TXT_FLOATINGRATE.value)
				Else
					floatrate = 0
				End If
				If IsNumeric(obj.TXT_VARIANCE.value) Then
					variance = Cdbl(obj.TXT_VARIANCE.value)
				Else
					variance = 0
				End If
				'cek kode variance
				If (obj.DDL_CODE.SelectedIndex = 1) Then
					fixedrate = fixedrate + variance
					floatrate = floatrate + variance
				ElseIf (obj.DDL_CODE.SelectedIndex = 2) Then
					fixedrate = fixedrate - variance
					floatrate = floatrate - variance
				End If
				'MsgBox obj.TXT_LIMIT.value & ""
				If IsNumeric(obj.TXT_LIMIT.value) Then
					limit = CDbl(obj.TXT_LIMIT.value)
				Else 
					limit = 0
				End If
				
				'hitung installment jika fixed
				If (obj.TXT_FIXEDRATE.value <> "") And (tenor <> 0) Then 
					installment = (fixedrate/tenor) * (limit/100)
				ElseIf (obj.TXT_FLOATINGRATE.value <> "") And (tenor <> 0) Then
					installment = (floatrate/tenor) * (limit/100)
				Else
					installment = 0
				End If
				'MsgBox installment
				obj.TXT_INSTALLMENT.value = FormatNumber(installment,2)
				'MsgBox obj.TXT_INSTALLMENT.value
				FormatCurrency(obj.TXT_INSTALLMENT)
			End Function
			'fungsi currency yang berada di cek entries berbahaya
			'Error: 66,67 --> 6.667 
			Function FormatCurr(obj_curr)
				SetLocale("in")
				v_curr = obj_curr.value
				v_curr = replace(v_curr, ".", "")
				if isnumeric(v_curr) then
					v_curr = formatnumber(v_curr, 2)
				else
					v_curr = 0
				end if
				obj_curr.value = v_curr
			end function
		</script>
	</HEAD>
	<body leftMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="tdheader1">Alternate Rate</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 74px">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="tdsmallheader">Sequence</TD>
								<TD class="tdsmallheader">Tenor</TD>
								<TD class="tdsmallheader">Fixed Rate</TD>
								<TD class="tdsmallheader">Floating Rate</TD>
								<TD class="tdsmallheader">Code</TD>
								<TD class="tdsmallheader">Variance</TD>
								<TD class="tdsmallheader">Installment</TD>
								<TD><asp:label id="LBL_NEGO" runat="server" Visible="False"></asp:label></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_SEQ" runat="server"></asp:textbox></TD>
								<TD align="center"><asp:textbox onkeypress="return numbersonly()" id="TXT_TENOR" onkeyup="viewSumTenor()" runat="server"></asp:textbox></TD>
								<TD align="center"><asp:textbox onkeypress=" enableFixed(); return numberscommaonly(); " id="TXT_FIXEDRATE" runat="server"
										MaxLength="5"></asp:textbox></TD>
								<TD align="center"><asp:textbox onkeypress="  enableFloat(); return numberscommaonly();" id="TXT_FLOATINGRATE" runat="server"
										MaxLength="5"></asp:textbox></TD>
								<TD align="center"><asp:dropdownlist id="DDL_CODE" runat="server">
										<asp:ListItem Value=" " Selected="True">&nbsp;</asp:ListItem>
										<asp:ListItem Value="+">+</asp:ListItem>
										<asp:ListItem Value="-">-</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD align="center"><asp:textbox onkeypress="return numberscommaonly()" id="TXT_VARIANCE" MaxLength="4" runat="server"></asp:textbox></TD>
								<TD align="center"><asp:textbox onkeypress="return digitsonly()" id="TXT_INSTALLMENT" onblur="FormatCurrency(this)"
										runat="server"></asp:textbox></TD>
								<TD><asp:button id="BTN_INSERT" runat="server" Text="Insert" CssClass="button1" onclick="BTN_INSERT_Click"></asp:button><asp:button id="BTN_UPDATE" runat="server" Visible="False" Text="Update" CssClass="button1"
										Width="60px" onclick="BTN_UPDATE_Click"></asp:button></TD>
								<TD><asp:label id="LBL" runat="server"></asp:label></TD>
								<TD><asp:label id="LBL2" runat="server"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="7">
									<asp:label id="LBL_ISINSTALLMENT" runat="server" Visible="False"></asp:label>
									<asp:label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:label></TD>
								<TD><asp:button id="BTN_CANCEL" runat="server" Visible="False" Text="Cancel" CssClass="button1"
										Width="60px" onclick="BTN_CANCEL_Click"></asp:button></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
						<asp:label id="LBL_CP_TENOR" runat="server" Font-Bold="True">Tenor:</asp:label>&nbsp;&nbsp;&nbsp;
						<asp:textbox onkeypress="return digitsonly()" id="TXT_CP_TENOR" runat="server" MaxLength="3"
							Font-Bold="True" Enabled="False" BorderStyle="None"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;
						<asp:label id="LBL_SUM_TENOR" runat="server" Font-Bold="True">Akumulasi Tenor:</asp:label>&nbsp;&nbsp;&nbsp;
						<asp:textbox onkeypress="return digitsonly()" id="TXT_SUM_TENOR" runat="server" MaxLength="3"
							Width="160px" Font-Bold="True" Enabled="False" BorderStyle="None" AutoPostBack="True"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox onkeypress="return digitsonly()" id="TXT_OLD_TENOR" runat="server" MaxLength="3"
							Width="1px" Enabled="False" BorderStyle="None" AutoPostBack="True"></asp:textbox>&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;
						<asp:textbox onkeypress="return digitsonly()" id="TXT_LIMIT" runat="server" MaxLength="3" Width="1px"
							Enabled="False" BorderStyle="None"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox onkeypress="return digitsonly()" id="TXT_CP_INSTALLMENT" runat="server" MaxLength="3"
							Width="1px" Enabled="False" BorderStyle="None"></asp:textbox></TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DGR_ALTERNATERATE" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="SEQUENCE" SortExpression="SEQUENCE" HeaderText="Seq">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TENOR" HeaderText="Tenor">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FIXEDRATE" HeaderText="Fixed Rate">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FLOATINGRATE" HeaderText="Floating Rate">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="VARCODE" HeaderText="Code">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="VARIANCE" HeaderText="Variance">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="INSTALLMENT" HeaderText="Installment">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="tdbgcolor2"><asp:label id="LBL_SERBA" runat="server" Visible="False"></asp:label><asp:label id="LBL_SORT_TYPE" runat="server" Visible="False">ASC</asp:label><INPUT class="button1" id="BTN_SAVE" onclick="javascript:window.close();" type="button"
							value="Close">
						<asp:button id="BTN_CALCULATE" runat="server" Visible="False" Text="Calculate" CssClass="button1"></asp:button><asp:label id="LBL_SORT_EXP" runat="server" Visible="False">SEQUENCE</asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
