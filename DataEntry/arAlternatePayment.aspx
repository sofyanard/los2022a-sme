<%@ Page language="c#" Codebehind="arAlternatePayment.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.arAlternatePayment" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Alternate Payment Schedule</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/child.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<script language="javascript">
		function numberscommaonly()
		{
			//alert(event.keyCode);
			if ((event.keyCode>=48) && (event.keyCode<=57))
			{ // membolehkan input seperti: 9,
				return true;
			} else if (event.keyCode == 44)
			{
				return true;
			} else
			{
				return false;
			}
		}
		</script>
		<script language="vbscript">
		
		'Fungsi untuk menghitung 
		function getDrawDownPayment()
			SetLocale("in")
			set obj = document.Form1
			
			if isnumeric(obj.TXT_AP_DDS_BEFORE.value) then
				TOTALDDS = cdbl(obj.TXT_AP_DDS_BEFORE.value)
			else
				TOTALDDS = 0
			end if
			if isnumeric(obj.TXT_PERCENTAGE.value) then
				PERCENT = cdbl(obj.TXT_PERCENTAGE.value)
			else
				PERCENT = 0
			end if
			If PERCENT > 100 Then
				obj.TXT_PERCENTAGE.value = ""
				obj.TXT_DRAWDOWN_AMOUNT.value = ""
				obj.TXT_ALTERNATE_PAYMENT.value = ""
				MsgBox "Percentage tidak boleh melebihi 100%", ,"Perhatian!"
				Exit Function
			End If
			if isnumeric(obj.TXT_LIMIT.value) then
				LIMIT = cdbl(obj.TXT_LIMIT.value)
			else
				LIMIT = 0
			end if
			
			'MsgBox LIMIT & " " & PERCENT & " " & TOTALDDS
			If obj.TXT_ALTERNATE_PAYMENT.disabled Then
				
				DRAWDOWN = (PERCENT / 100) * LIMIT
				TOTAL = TOTALDDS + DRAWDOWN
				TOTAL = FormatNumber(TOTAL,2)
				obj.TXT_DRAWDOWN_AMOUNT.value = FormatNumber(DRAWDOWN,2)
				obj.TXT_AP_DDS.value = TOTAL
			Else 
				PAYMENT = (PERCENT / 100) * LIMIT
				TOTAL = TOTALDDS + PAYMENT
				TOTAL = FormatNumber(TOTAL,2)
				obj.TXT_ALTERNATE_PAYMENT.value = FormatNumber(PAYMENT,2)
				obj.TXT_AP_DDS.value = TOTAL
			End If
			'FormatCurrency(obj.TXT_LIMIT)
			'FormatCurrency(obj.TXT_AP_DDS)
			
		end function
		
		'Menghitung persentase dana yang dibayar atau diambil dari total pinjaman
		function getPercentage()
			SetLocale("in")
			set obj = document.Form1

			If PERCENT > 100 Then
				obj.TXT_PERCENTAGE.value = ""
				obj.TXT_DRAWDOWN_AMOUNT.value = ""
				obj.TXT_ALTERNATE_PAYMENT.value = ""
				MsgBox "Percentage tidak boleh melebihi 100%", ,"Perhatian!"
				Exit Function
			End If
	
			if isnumeric(obj.TXT_AP_DDS_BEFORE.value) then
				TOTALDDS = cdbl(obj.TXT_AP_DDS_BEFORE.value)
			else
				TOTALDDS = 0
			end if
			's = Replace(obj.TXT_DRAWDOWN_AMOUNT.value,".","")
			's = Replace(s,",",".")			
			if isnumeric(obj.TXT_DRAWDOWN_AMOUNT.value) then
				DRAWDOWN = cdbl(obj.TXT_DRAWDOWN_AMOUNT.value)
			else
				DRAWDOWN = 0
			end if
			if isnumeric(obj.TXT_LIMIT.value) then
				LIMIT = cdbl(obj.TXT_LIMIT.value)
			else
				LIMIT = 0
			end if
			'MsgBox TOTALDDS & " " & DRAWDOWN & " " & LIMIT
			If LIMIT > 0 Then
				HASIL = (DRAWDOWN / LIMIT) * 100
			Else
				HASIL = 0
			End If
			'MsgBox HASIL
			obj.TXT_PERCENTAGE.value = FormatNumber(HASIL,2)
			TOTAL = TOTALDDS + DRAWDOWN
			'MsgBox TOTAL
			obj.TXT_AP_DDS.value = FormatNumber(TOTAL,2)
			FormatCurrency(obj.TXT_LIMIT)
			'FormatCurrency(obj.TXT_AP_DDS)
		
		end function
		
		function convertCurrency(obj_curr)
			SetLocale("in")
			set obj = document.Form1
			v_curr = obj.obj_curr.value
			v_curr = replace(v_curr, ".", "")
			if isnumeric(v_curr) then
				v_curr = formatnumber(v_curr, 2)
			else
				v_curr = 0
			end if
			obj.obj_curr.value = v_curr
		end function

		
		function getPayPercent()
			SetLocale("in")
			set obj = document.Form1
			
			if isnumeric(obj.TXT_AP_DDS_BEFORE.value) then
				TOTALDDS = cdbl(obj.TXT_AP_DDS_BEFORE.value)
			else
				TOTALDDS = 0
			end if
			s = Replace(obj.TXT_ALTERNATE_PAYMENT.value,".","")
			s = Replace(s,",",".")
			if isnumeric(s) then
				PAYMENT = cdbl(obj.TXT_ALTERNATE_PAYMENT.value)
			else
				PAYMENT = 0
			end if

			if isnumeric(obj.TXT_LIMIT.value) then
				LIMIT = cdbl(obj.TXT_LIMIT.value)
			else
				LIMIT = 0
			end if
				
			If LIMIT > 0 Then
				HASIL = (PAYMENT / LIMIT) * 100
			Else
				HASIL = 0
			End If
			obj.TXT_PERCENTAGE.value = formatnumber(HASIL,2)
			TOTAL = TOTALDDS + PAYMENT
			obj.TXT_AP_DDS.value = TOTAL
			FormatCurrency(obj.TXT_LIMIT)
			FormatCurrency(obj.TXT_AP_DDS)
		end function
	
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="tdheader1">Draw Down Schedule / Alternate Payment</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 127px">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TBODY>
								<TR>
									<TD style="HEIGHT: 50px" colSpan="4"><asp:radiobuttonlist id="RBL_AP_DDS" runat="server" Width="416px" RepeatDirection="Horizontal" AutoPostBack="True"
											Font-Bold="True" onselectedindexchanged="RBL_AP_DDS_SelectedIndexChanged">
											<asp:ListItem Value="DDS" Selected="True">Draw Down Schedule</asp:ListItem>
											<asp:ListItem Value="AP">Alternate Payment</asp:ListItem>
										</asp:radiobuttonlist></TD>
									<TD style="HEIGHT: 50px" colSpan="2">
										<asp:label id="LBL_SELECT" runat="server" Visible="False">DDS</asp:label>
										<asp:label id="LBL_IS_INSTALLMENT" runat="server" Visible="False"></asp:label></TD>
								</TR>
								<TR>
									<TD class="tdsmallheader">Nth Month</TD>
									<TD class="tdsmallheader">Percentage</TD>
									<TD class="tdsmallheader">Draw Down Amount</TD>
									<TD class="tdsmallheader">Alternate Payment</TD>
									<TD class="tdSmallHeader">Kode Pembayaran</TD>
									<TD class="tdSmallHeader">Catatan</TD>
								</TR>
								<TR>
									<TD align="center"><asp:textbox onkeypress="return digitsonly()" id="TXT_SEQ_MONTH" runat="server"></asp:textbox></TD>
									<TD align="center"><asp:textbox onkeypress="return numberscommaonly()" id="TXT_PERCENTAGE" onkeyup="getDrawDownPayment()"
											runat="server" MaxLength="5"></asp:textbox></TD>
									<TD align="center"><asp:textbox onkeypress="return numbersonly()" id="TXT_DRAWDOWN_AMOUNT" onkeyup="getPercentage()"
											runat="server"></asp:textbox></TD>
									<TD align="center"><asp:textbox onkeypress="return numbersonly()" id="TXT_ALTERNATE_PAYMENT" onkeyup="getPayPercent()"
											runat="server" Enabled="False" BackColor="Gainsboro"></asp:textbox></TD>
									<TD align="center">
										<asp:dropdownlist id="DDL_PAYCODE" Width="118px" Runat="server" BackColor="Gainsboro" Enabled="False"></asp:dropdownlist></TD>
									<TD align="center">
										<asp:textbox onkeypress="return kutip_satu()" id="TXT_CATATAN" runat="server" MaxLength="50"
											CssClass="][" BackColor="Gainsboro" Enabled="False"></asp:textbox>
									</TD>
								</TR>
								<TR>
									<TD align="center" colSpan="6">
										<asp:button id="BTN_INSERT" runat="server" Text="Insert" CssClass="button1" onclick="BTN_INSERT_Click"></asp:button>&nbsp;<asp:button id="BTN_UPDATE" runat="server" Width="60px" Visible="False" CssClass="button1" Text="Update" onclick="BTN_UPDATE_Click"></asp:button>&nbsp;<asp:button id="BTN_CANCEL" runat="server" Width="60px" Visible="False" CssClass="button1" Text="Cancel" onclick="BTN_CANCEL_Click"></asp:button></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="6">
										<asp:label id="LBL_NEGO" runat="server" Visible="False"></asp:label>
										<asp:label id="LBL_INTERESTTYPE" runat="server" Visible="False"></asp:label></TD>
								</TR>
							</TBODY>
						</TABLE>
						<asp:label id="LBL_CP_LIMIT" runat="server" Font-Bold="True">Loan Amount:</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="TXT_LIMIT" onblur="FormatCurrency(this)" runat="server" Width="208px" AutoPostBack="True"
							Font-Bold="True" MaxLength="15" ForeColor="DimGray" Enabled="False" ReadOnly="True" BorderStyle="None"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="LBL_AP_DDS" runat="server" Font-Bold="True">Total Draw Down:</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="TXT_AP_DDS" onblur="FormatCurrency(this)" runat="server" Width="208px" AutoPostBack="True"
							Font-Bold="True" MaxLength="15" ForeColor="DimGray" Enabled="False" ReadOnly="True" BorderStyle="None"></asp:textbox>&nbsp;
						<asp:textbox id="TXT_AP_DDS_BEFORE" onblur="FormatCurrency(this)" runat="server" Width="1px"
							AutoPostBack="True" Font-Bold="True" ForeColor="White" ReadOnly="True" BorderStyle="None">0</asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="TXT_SELECT" onblur="FormatCurrency(this)" runat="server" Width="1px" AutoPostBack="True"
							Font-Bold="True" ForeColor="White" ReadOnly="True" BorderStyle="None">DDS</asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD><asp:datagrid id="DGR_ALTERNATEPAYMENT" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="TblAlternating"></AlternatingItemStyle>
							<Columns>
								<asp:BoundColumn DataField="SEQ_MONTH" SortExpression="SEQ_MONTH" HeaderText="Nth Month">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PERCENTAGE" HeaderText="Percentage" DataFormatString="{0:N2}%">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DRAWDOWN_AMOUNT" HeaderText="Draw Down Amount" DataFormatString="{0:0,00.00}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ALTERNATE_PAYMENT" HeaderText="Alternate Payment" DataFormatString="{0:0,00.00}">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAY_CODE" HeaderText="Kode Bayar">
									<HeaderStyle CssClass="tdSmallHeader"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="REMARK"></asp:BoundColumn>
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
					<TD class="tdbgcolor2"><asp:label id="QUERY" runat="server" Visible="False"></asp:label><asp:label id="LBL_SORT_TYPE" runat="server" Visible="False">ASC</asp:label><INPUT class="button1" id="BTN_SAVE" onclick="javascript:window.close();" type="button"
							value="Close">
						<asp:button id="BTN_CALCULATE" runat="server" Visible="False" CssClass="button1" Text="Calculate"></asp:button><asp:label id="LBL_COL_SORT" runat="server" Visible="False">SEQ_MONTH</asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
