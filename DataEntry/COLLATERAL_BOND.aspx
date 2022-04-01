<%@ Page language="c#" Codebehind="COLLATERAL_BOND.aspx.cs" AutoEventWireup="True" Inherits="SME.DataEntry.COLLATERAL_BOND" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>COLLATERAL_BOND</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		    function update(regno, curef) {
		        if (regno != curef + 'C') {
		            parent.document.getElementById('Form1').action = "../VerificationAssignment/AppraisalAssignment.aspx?regno=" + regno + "&curef=" + curef;
		        }
		        else if (regno == curef + 'C') {
		            parent.document.getElementById('Form1').action = "../VerificationAssignment/AppraisalAssignmentCBI.aspx?regno=" + regno + "&curef=" + curef + "&mc=030";
		        }
		        parent.document.getElementById('Form1').submit();
		        return false;
		    }
		</script>
    <!-- #include  file="../include/cek_all.html" -->
    <!-- #include  file="../include/cek_entries.html" -->
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TR>
						<TD class="td" vAlign="top" width="50%">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
								<TR>
									<TD class="TDBGColor1" width="200">
										Keterangan&nbsp;Jaminan</TD>
									<TD width="15"></TD>
									<TD class="TDBGColorValue"><asp:textbox id="TXT_CL_DESC" onKeypress="return kutip_satu()" runat="server" MaxLength="50" Width=400
											Columns="25" CssClass="mandatory"></asp:textbox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Mata Uang</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_CURRENCY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Klasifikasi Jaminan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CL_COLCLASSIFY" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">SIBS Collateral ID</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox ID="TXT_SIBS_COLID" readonly Runat="server" MaxLength="35" Columns="30" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Bond</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_BONDTYPE" runat="server"></asp:DropDownList>&nbsp;
										<asp:CheckBox ID="CHB_CL_ISCASHEDVALUE" runat="server" Visible = "False" ></asp:CheckBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Regitrasi No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_REGNO" MaxLength="20" Columns="20" runat="server" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Security No.</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_SECURITYNO" MaxLength="20" Columns="20" runat="server" CssClass="mandatory"
											onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_BANK">
									<TD class="TDBGColor1">Nilai Bank</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PASAR">
									<TD class="TDBGColor1">Nilai Pasar</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUE2" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_ASURANSI">
									<TD class="TDBGColor1">Nilai Asuransi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEINS" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PENGIKATAN">
									<TD class="TDBGColor1">Nilai Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEIKAT" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_PENGURANG_PPA">
									<TD class="TDBGColor1">Nilai Pengurang PPA</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUEPPA" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR runat="server" id="TR_NILAI_LIKUIDASI">
									<TD class="TDBGColor1">Nilai Likuidasi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_VALUELIQ" runat="server" Columns="25" MaxLength="21" onkeypress="return numbersonly()"
											onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<!--<TR>
									<TD class="TDBGColor1">Nilai Pasar Saat Ini</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_MARKETVALUE" runat="server" MaxLength="21" Columns="25" onkeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>-->
								<TR>
									<TD class="TDBGColor1">Tanggal Pendaftaran</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_REGDATEDAY" MaxLength="2" Columns="2" runat="server" onkeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList id="DDL_CL_REGDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_REGDATEYEAR" MaxLength="4" Columns="4" runat="server" onkeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Diterbitkan Oleh</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
									<asp:TextBox id="TXT_CL_ISSUEDBY" MaxLength="20" Columns="20" runat="server" onKeypress="return kutip_satu()" Width=250></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Penerbitan</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_ISSUEDDATEDAY" MaxLength="2" Columns="2" runat="server" onkeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList id="DDL_CL_ISSUEDDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_ISSUEDDATEYEAR" MaxLength="4" Columns="4" runat="server" onkeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Tanggal Jatuh Tempo</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
										<asp:TextBox id="TXT_CL_DUEDATEDAY" MaxLength="2" Columns="2" runat="server" onkeypress="return numbersonly()"></asp:TextBox>
										<asp:DropDownList id="DDL_CL_DUEDATEMONTH" runat="server"></asp:DropDownList>
										<asp:TextBox id="TXT_CL_DUEDATEYEAR" MaxLength="4" Columns="4" runat="server" onkeypress="return numbersonly()"></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Kondisi</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_CONDITION" MaxLength="20" Columns="20" runat="server" onKeypress="return kutip_satu()"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Nama Pemilik</TD>
									<TD></TD>
									<TD class="TDBGColorValue">
									<asp:TextBox id="TXT_CL_OWNER" MaxLength="100"  CssClass="mandatory" Columns="20" runat="server" onKeypress="return kutip_satu()" Width=400></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Hubungan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_RELATIONSHIP"  CssClass="mandatory"  runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jumlah / ukuran Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:TextBox id="TXT_CL_COLLAMOUNT" MaxLength="21" Columns="25" runat="server" onkeypress="return numbersonly()"
											CssClass="mandatory" onblur = "FormatCurrency(this)"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Pengikatan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_IKATTYPE" runat="server" CssClass="mandatory" ></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Penilaian Menurut</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_VALACCRDTO" runat="server" CssClass="mandatory" ></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Peringkat Surat Berharga</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_PERINGKAT" runat="server"></asp:DropDownList></TD>
								</TR>
								<TR>
									<TD class="TDBGColor1">Jenis Agunan</TD>
									<TD></TD>
									<TD class="TDBGColorValue"><asp:DropDownList id="DDL_CL_JNSAGUNAN" runat="server" CssClass="mandatory"></asp:DropDownList></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="TDBGColor2" vAlign="top" align="center" width="50%" colSpan="2">&nbsp;
						<% if (Request.QueryString["appr"] == "1") { %>
							
							<INPUT type="button" value="Update" class="button1" onclick="return update('<%=Request.QueryString["regno"]%>','<%=Request.QueryString["curef"]%>');">&nbsp;
							<% }
                            else
                            {%>
                                <asp:Button runat="server" Class="Button1" id="update" Text="Update"/>
                            <%}%>
							<% if (Request.QueryString["de"] == "1") { %>
							<input type="button" id="Button1" name="Button1" Value="Save" Class="Button1" onClick="return cek_mandatory(document.getElementById('Form1'));">&nbsp;
							<% } %>
							<asp:Label id="LBL_CL_SEQ" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_REGNO" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_CUREF" runat="server" Visible="False"></asp:Label>
							<asp:Label id="LBL_TC" runat="server" Visible="False"></asp:Label>
						</TD>
					</TR>
				</TABLE>
			</CENTER>
		</form>
	</body>
</HTML>
