<%@ Register TagPrefix="uc1" TagName="DocUpload" Src="../CommonForm/DocumentUpload.ascx" %>
<%@ Page language="c#" Codebehind="GeneralInfo.aspx.cs" AutoEventWireup="True" Inherits="SME.InitialDataEntry.GeneralInfo" enableViewState="True" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GeneralInfo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../style.css" type="text/css" rel="stylesheet">
		<!-- #include file="../include/cek_mandatory.html" -->
		<!-- #include file="../include/cek_entries.html" -->
		<!-- #include file="../include/popup.html" -->

        <link type="text/css" rel="stylesheet" href="../include/bootstrap.min.css" />
		<link type="text/css" rel="stylesheet" href="../include/bootstrap-select.min.css" />
		<script type="text/javascript" src="../include/jquery.min.js"></script>
		<script type="text/javascript" src="../include/bootstrap.min.js"></script>
		<script type="text/javascript" src="../include/bootstrap-select.min.js"></script>

		<script language="javascript">
			function SearchSektorEkonomi(bifrm, biobj, biurl)
			{	
				Urlnya = biurl + "../InitialDataEntry/SearchSektorEkonomi.aspx" + "?bifrm=" + bifrm + "&biobj=" + biobj;
				window.open(Urlnya,"SearchSektorEkonomi","status=no,scrollbars=no,width=800,height=600")
            }
		</script>

        <script>
            function FillDDL2() {
                var id1 = $("#DDL_bmsektor").val();

                $.ajax
				({
				    type: "POST",
				    url: "../WebServices/BMSektorWebService.asmx/QueryDDL2",
				    data: JSON.stringify({ par: 'ID', val: id1 }),
				    dataType: "json",
				    contentType: "application/json; charset=utf-8",
				    success: function (result) {
				        $("#DDL_bmsubsektor").empty();
				        $.each(result.d, function () {
				            $("#DDL_bmsubsektor").append($("<option></option>").val(this['Value']).html(this['Text']));
				        });
				        $("#DDL_bmsubsektor").selectpicker('refresh');
				    },
				    error: function (xhr, status, error) {
				        alert(error.toString());
				    }
				});
            }

            function FillDDL3() {
                var id2 = $("#DDL_bmsubsektor").val();

                $.ajax
				({
				    type: "POST",
				    url: "../WebServices/BMSektorWebService.asmx/QueryDDL3",
				    data: JSON.stringify({ par: 'ID', val: id2 }),
				    dataType: "json",
				    contentType: "application/json; charset=utf-8",
				    success: function (result) {
				        $("#DDL_bmsubsubsektor").empty();
				        $.each(result.d, function () {
				            $("#DDL_bmsubsubsektor").append($("<option></option>").val(this['Value']).html(this['Text']));
				        });
				        $("#DDL_bmsubsubsektor").selectpicker('refresh');
				    },
				    error: function (xhr, status, error) {
				        alert(error.toString());
				    }
				});
            }

            function FillDDL4() {
                var id3 = $("#DDL_bmsubsubsektor").val();
                if (id3 == "") {
                    EmptyDDL4();
                    return;
                }

                $.ajax
				({
				    type: "POST",
				    url: "../WebServices/BMSektorWebService.asmx/QueryDDL4",
				    data: JSON.stringify({ par: 'ID', val: id3 }),
				    dataType: "json",
				    contentType: "application/json; charset=utf-8",
				    success: function (result) {
				        $("#DDL_SEKTOREKONOMIBI").empty();
				        $.each(result.d, function () {
				            $("#DDL_SEKTOREKONOMIBI").append($("<option></option>").val(this['Value']).html(this['Text']));
				        })
				    },
				    error: function (xhr, status, error) {
				        alert(error.toString());
				    }
				});
            }

            function EmptyDDL3() {
                $("#DDL_bmsubsubsektor").empty();
            }

            function EmptyDDL4() {
                $("#DDL_SEKTOREKONOMIBI").empty();
            }

            function FillTXT2() {
                document.getElementById("TXT_bmsubsektor").value = document.getElementById("DDL_bmsubsektor").value;
            }

            function FillTXT3() {
                document.getElementById("TXT_bmsubsubsektor").value = document.getElementById("DDL_bmsubsubsektor").value;
            }
		</script>

        <script>
            $(document).ready(function () {
                $("#DDL_CU_MARITAL").change(function () {
                    $.ajax
					({
					    url: "../include/ajaxtext.txt",
					    success: function (result) {
					        if ($("#DDL_CU_MARITAL").val() == "1") {
					            $("#TXT_CU_SPOUSE_FNAME").addClass("mandatory2");
					        }
					        else {
					            $("#TXT_CU_SPOUSE_FNAME").removeClass("mandatory2");
					        }
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#CHB_CU_KTPADDR").on('change', function () {
                    $.ajax
					({
					    url: "../include/ajaxtext.txt",
					    success: function (result) {
					        if ($("#CHB_CU_KTPADDR").is(':checked')) {
					            document.getElementById("TXT_CU_KTPADDR1").value = document.getElementById("TXT_CU_ADDR1").value;
					            document.getElementById("TXT_CU_KTPADDR2").value = document.getElementById("TXT_CU_ADDR2").value;
					            document.getElementById("TXT_CU_KTPADDR3").value = document.getElementById("TXT_CU_ADDR3").value;
					            document.getElementById("TXT_CU_KTPCITY").value = document.getElementById("TXT_CU_CITY").value;
					            document.getElementById("LBL_CU_KTPCITY").value = document.getElementById("LBL_CU_CITY").value;
					            document.getElementById("TXT_CU_KTPZIPCODE").value = document.getElementById("TXT_CU_ZIPCODE").value;
					        }
					        else {
					            document.getElementById("TXT_CU_KTPADDR1").value = "";
					            document.getElementById("TXT_CU_KTPADDR2").value = "";
					            document.getElementById("TXT_CU_KTPADDR3").value = "";
					            document.getElementById("TXT_CU_KTPCITY").value = "";
					            document.getElementById("LBL_CU_KTPCITY").value = "";
					            document.getElementById("TXT_CU_KTPZIPCODE").value = "";
					        }
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#CHB_CU_NAMAPELAPORAN").on('change', function () {
                    $.ajax
					({
					    url: "../include/ajaxtext.txt",
					    success: function (result) {
					        if ($("#CHB_CU_NAMAPELAPORAN").is(':checked')) {
					            document.getElementById("TXT_CU_NAMAPELAPORAN").value = document.getElementById("TXT_CU_FIRSTNAME").value;
					        }
					        else {
					            document.getElementById("TXT_CU_NAMAPELAPORAN").value = "";
					        }
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#DDL_CU_HUBEXECBM").change(function () {
                    $.ajax
					({
					    url: "../include/ajaxtext.txt",
					    success: function (result) {
					        if (($("#DDL_CU_HUBEXECBM").val() == "501") || ($("#DDL_CU_HUBEXECBM").val() == "502") || ($("#DDL_CU_HUBEXECBM").val() == "503")) {
					            $("#DDL_CU_HUBKELBM").addClass("mandatory2");
					        }
					        else {
					            $("#DDL_CU_HUBKELBM").removeClass("mandatory2");
					        }
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#TXT_CU_ZIPCODE").blur(function () {
                    var zipcd = $("#TXT_CU_ZIPCODE").val();
                    alert(zipcd);
                    $.ajax
					({
					    type: "POST",
					    url: "../WebServices/IDEGeneralWS.asmx/QueryZipCode",
					    data: JSON.stringify({ par: 'ID', val: zipcd }),
					    dataType: "json",
					    contentType: "application/json; charset=utf-8",
					    success: function (result) {
					        //$.each(result.d, function(i, field) {
					        //	alert(field.toString());
					        //});
					        alert('success');
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#TXT_CU_COMPZIPCODE").blur(function () {
                    var zipcd = $("#TXT_CU_COMPZIPCODE").val();
                    $.ajax
					({
					    type: "POST",
					    url: "../WebServices/IDEGeneralWS.asmx/QueryZipCode",
					    data: JSON.stringify({ par: 'ID', val: zipcd }),
					    dataType: "json",
					    contentType: "application/json; charset=utf-8",
					    success: function (result) {
					        $.each(result.d, function () {
					            if (this['Text'] == "CityID")
					                document.getElementById("LBL_CU_COMPCITY").value = this['Value'];
					            if (this['Text'] == "CityName")
					                document.getElementById("TXT_CU_COMPCITY").value = this['Value'];
					            if (this['Text'] == "Description")
					                document.getElementById("TXT_CU_COMPADDR3").value = this['Value'];
					        });
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#TXT_CU_KTPZIPCODE").blur(function () {
                    var zipcd = $("#TXT_CU_KTPZIPCODE").val();
                    $.ajax
					({
					    type: "POST",
					    url: "../WebServices/IDEGeneralWS.asmx/QueryZipCode",
					    data: JSON.stringify({ par: 'ID', val: zipcd }),
					    dataType: "json",
					    contentType: "application/json; charset=utf-8",
					    success: function (result) {
					        $.each(result.d, function () {
					            if (this['Text'] == "CityID")
					                document.getElementById("LBL_CU_KTPCITY").value = this['Value'];
					            if (this['Text'] == "CityName")
					                document.getElementById("TXT_CU_KTPCITY").value = this['Value'];
					            if (this['Text'] == "Description")
					                document.getElementById("TXT_CU_KTPADDR3").value = this['Value'];
					        });
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#TXT_CU_ZIPCODE").blur(function () {
                    var zipcd = $("#TXT_CU_ZIPCODE").val();
                    $.ajax
					({
					    type: "POST",
					    url: "../WebServices/IDEGeneralWS.asmx/QueryZipCode",
					    data: JSON.stringify({ par: 'ID', val: zipcd }),
					    dataType: "json",
					    contentType: "application/json; charset=utf-8",
					    success: function (result) {
					        $.each(result.d, function () {
					            if (this['Text'] == "CityID")
					                document.getElementById("LBL_CU_CITY").value = this['Value'];
					            if (this['Text'] == "CityName")
					                document.getElementById("TXT_CU_CITY").value = this['Value'];
					            if (this['Text'] == "Description")
					                document.getElementById("TXT_CU_ADDR3").value = this['Value'];
					        });
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });

                $("#RDO_BI_CHECKING").change(function () {
                    var list = document.getElementById("RDO_BI_CHECKING");
                    var inputs = list.getElementsByTagName("input");
                    $.ajax
					({
					    url: "../include/ajaxtext.txt",
					    success: function (result) {
					        if (inputs[0].checked) {
					            document.getElementById("LBL_CO").innerHTML = "Pelaksana :";
					            document.getElementById("DDL_GRPUNIT").setAttribute("style", "display:inline");
					        }
					        else {
					            document.getElementById("LBL_CO").innerHTML = "";
					            document.getElementById("DDL_GRPUNIT").setAttribute("style", "display:none");
					        }
					    },
					    error: function (xhr, status, error) {
					        alert(error.toString());
					    }
					});
                });
            });
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<center>
				<TABLE id="Table1" cellSpacing="2" cellPadding="2" width="100%">
					<TBODY>
						<TR>
							<TD class="tdNoBorder">
								<TABLE id="Table4">
									<TR>
										<TD class="tdBGColor2" style="WIDTH: 400px" align="center"><B>Initial Data Entry: 
												General Info</B></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="tdNoBorder" align="right"><A href="ListCustomer.aspx?si="></A><A href="../Body.aspx"><IMG src="../Image/MainMenu.jpg"></A><A href="../Logout.aspx" target="_top"><IMG src="../Image/Logout.jpg"></A></TD>
						</TR>
						<TR>
							<TD class="tdNoBorder" style="HEIGHT: 41px" align="center" colSpan="2"><asp:placeholder id="Menu" runat="server"></asp:placeholder></TD>
						</TR>
						<!--					
					<TR>
						<TD align="center" colSpan="2">
							<asp:LinkButton id="LNK_KETENTUAN230" runat="server" Font-Bold="True">Ketentuan 230</asp:LinkButton></TD>
					</TR>
					-->
						<TR>
							<TD class="tdHeader1" colSpan="2">Informasi Umum</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">Bank</TD>
										<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_AREAID" runat="server" Width="100%" ReadOnly="True" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px">KC/KCP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_BRANCH_CODE" runat="server" Width="100%" ReadOnly="True" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="HEIGHT: 12px">Sub-Segment/Program</TD>
										<TD style="WIDTH: 15px; HEIGHT: 12px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_PROG_CODE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Analis</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_RELMNGR" runat="server" Width="200px" BorderStyle="None"></asp:textbox><asp:label id="LBL_AP_RELMNGR" runat="server" Visible="False"></asp:label></TD>
									</TR>
									<!-- <TR>
										<TD class="TDBGColor1">Referensi</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CHANNEL_CODE" runat="server" AutoPostBack="true"></asp:dropdownlist><asp:textbox id="TXT_CON" runat="server" Width="1px" ReadOnly="True" AutoPostBack="True" BorderStyle="None" ontextchanged="TXT_CON_TextChanged"></asp:textbox></TD>
									</TR> -->
									<!-- <TR runat="server" id="TR_Source_Code">
										<TD class="TDBGColor1">Source Code</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_SRCCODE" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR> -->
									<!-- <TR runat="server" id="TR_Referal_NAME">
										<TD class="TDBGColor1">Referral Name</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_SRCNAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									</TR> -->
									<TR id="TR_GROSSSALES" runat="server">
										<TD class="TDBGColor1" style="HEIGHT: 41px">Gross Annual Sales</TD>
										<TD style="HEIGHT: 41px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 41px"><asp:dropdownlist id="DDL_AP_GRSALESCURR" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="TXT_AP_GROSSSALES" onblur="FormatCurrency(this)"
												runat="server" MaxLength="15" Columns="25"></asp:textbox></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 41px"><asp:label id="temp_areaid" runat="server"></asp:label></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 41px"><asp:label id="temp_userid" runat="server"></asp:label></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 41px"><asp:label id="temp_branchcode" runat="server"></asp:label></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 41px"><asp:label id="temp_grpunit" runat="server"></asp:label></TD>
									</TR>
									<TR>
										<TD></TD>
										<TD></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Booking Branch</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_BOOKINGBRANCH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Cabang Admin</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_CCOBRANCH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="150">Tanggal Aplikasi</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_DAY" runat="server" Width="24px"
												CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_AP_SIGNDATE_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_AP_SIGNDATE_YEAR" runat="server" Width="36px"
												CssClass="mandatory" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="150">Tanggal Penerusan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_RECVDATE" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="150">Segmen</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_BUSINESSUNIT" runat="server" CssClass="mandatory" AutoPostBack="True" onselectedindexchanged="DDL_AP_BUSINESSUNIT_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="150">No. Aplikasi</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_AP_REGNO" runat="server" Width="200px" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="150"></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_REF" runat="server" Visible="False"></asp:textbox></TD>
									</TR>
									<TR>
										<!-- pipeline -->
										<TD class="TDBGColor1" width="129"><asp:label id="Label_generalinfo1" runat="server"></asp:label></TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_SALESAGENCY" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_AP_SALESAGENCY_SelectedIndexChanged"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="Textbox_skbngpasar" onblur="FormatCurrency(this)"
												runat="server" MaxLength="15" Columns="25"></asp:textbox></TD>
										<!-- pipeline --></TR>
									<TR>
										<TD class="TDBGColor1" width="129"><asp:label id="Label_generalinfo2" runat="server"></asp:label></TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_AP_SALESSUPERV" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return digitsonly()" id="Textbox_skbngminta" onblur="FormatCurrency(this)"
												runat="server" MaxLength="15" Columns="25"></asp:textbox></TD>
									</TR>
									<TR id="TR_generalinfo3" runat="server">
										<TD class="TDBGColor1" width="129"><asp:label id="Label_generalinfo3" runat="server"></asp:label></TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_AP_SALESEXEC" runat="server"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD colSpan="2"><uc1:docupload id="DocUpload1" runat="server"></uc1:docupload></TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 129px; HEIGHT: 17px">No. Surat Nasabah / 
											Penawaran</TD>
										<TD style="WIDTH: 15px; HEIGHT: 17px"></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_SURATNSBNO" runat="server" Width="100%" CssClass="mandatory"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="150">Tanggal Surat</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_SURATNSBTGL_DAY" runat="server" Width="24px"
												CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_SURATNSBTGL_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_SURATNSBTGL_YEAR" runat="server" Width="36px"
												CssClass="mandatory" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="150">Tanggal Terima</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_SURATNSBTGLTRM_DAY" runat="server" Width="24px"
												CssClass="mandatory" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_SURATNSBTGLTRM_MONTH" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_SURATNSBTGLTRM_YEAR" runat="server" Width="36px"
												CssClass="mandatory" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top">
								<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%">
									<tr>
										<td></td>
									</tr>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="tdHeader1" vAlign="top" width="50%" colSpan="2">Info Nasabah
								<asp:textbox id="TXT_AUDITDESC_PROG" runat="server" Visible="False">Sub-Segment/Program pilih - </asp:textbox><asp:textbox id="TXT_AUDITDESC_BICHECK" runat="server" Visible="False">BI Checking by - </asp:textbox></TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="80%" border="0">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 228px">Suku Bangsa Papua</TD>
										<TD></TD>
										<TD><asp:radiobuttonlist id="RDO_CU_PERNAHJDNASABAHBM" runat="server" Width="150px" RepeatDirection="Horizontal">
												<asp:ListItem Value="1">Ya</asp:ListItem>
												<asp:ListItem Value="0" Selected="True">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD><asp:radiobuttonlist id="RDO_RFCUSTOMERTYPE" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" onselectedindexchanged="RDO_RFCUSTOMERTYPE_SelectedIndexChanged"></asp:radiobuttonlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR id="TR_PERSONAL" runat="server">
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table20" cellSpacing="0" cellPadding="0" width="100%">
                                    <TR>
										<TD colspan="3"><b>Data Pemohon</b></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px" width="164">CIF No.</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_P" runat="server" Width="200px" BorderStyle="None"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px" width="164">Gelar Sebelum Nama</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TITLEBEFORENAME" runat="server" Width="200px"
												MaxLength="15"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Nama Pemohon</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
											<asp:textbox id="TXT_CU_FIRSTNAME" runat="server" Width="300px" CssClass="mandatory2" MaxLength="50"></asp:textbox><BR>
												<asp:textbox id="TXT_CU_MIDDLENAME" runat="server" Width="300px" MaxLength="50" 
                                                    Visible="False"></asp:textbox>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Gelar Setelah Nama</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_LASTNAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Nama Alias</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ALIASNAME" runat="server" Width="300px" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Alamat Rumah</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_ADDR1" runat="server" Width="300px" CssClass="mandatory2" MaxLength="100"></asp:textbox><BR>
											<asp:textbox id="TXT_CU_ADDR2" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Kelurahan / Kecamatan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ADDR3" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Kota</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_CITY" runat="server" Width="175px" ReadOnly="True" CssClass="mandatory2"></asp:textbox><asp:textbox id="LBL_CU_CITY" runat="server" style="display:none"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Kode Pos</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px">
                                            <asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_ZIPCODE" runat="server" CssClass="mandatory2" MaxLength="6" Columns="6"></asp:textbox>
                                            <!--<asp:button id="BTN_SEARCHPERSONAL" runat="server" Text="Search" onclick="BTN_SEARCHPERSONAL_Click"></asp:button>-->
                                            <input type="button" value="Search" onclick="window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_ZIPCODE&trgObjID2=TXT_CU_ADDR3&trgObjID3=TXT_CU_CITY&trgObjID4=LBL_CU_CITY', 'SearchZipcode', 'status=no,scrollbars=no,width=640,height=480'); return false;">
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Kepemilikan Rumah</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_HOMESTA" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">&nbsp;Mulai Menetap</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px">
                                            <asp:textbox id="TXT_CU_MULAIMENETAPMM" runat="server" MaxLength="2" 
                                                Columns="2"></asp:textbox>(MM)
											<asp:textbox id="TXT_CU_MULAIMENETAPYY" runat="server" MaxLength="4" 
                                                Columns="4"></asp:textbox>&nbsp;(YYYY)</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">No. Telepon / HP</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_PHNAREA" runat="server" CssClass="mandatory2" MaxLength="5" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_PHNNUM" runat="server" Width="100px" CssClass="mandatory2" MaxLength="15"
												Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox id="TXT_CU_PHNEXT" runat="server" MaxLength="5" Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">No. Fax / No. Telepon</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_FAXAREA" runat="server" MaxLength="5" Columns="4"></asp:textbox><asp:textbox id="TXT_CU_FAXNUM" runat="server" Width="100px" MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox id="TXT_CU_FAXEXT" runat="server" MaxLength="5" Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Tempat Lahir</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox id="TXT_CU_POB" runat="server" Width="300px" CssClass="mandatory2" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Tanggal Lahir</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_DAY" runat="server" Width="24px"
												CssClass="mandatory2" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_DOB_MONTH" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_DOB_YEAR" runat="server" Width="36px"
												CssClass="mandatory2" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Status Perkawinan</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px">
                                            <asp:dropdownlist id="DDL_CU_MARITAL" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
                                    <TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Jenis Kelamin</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_SEX" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Kewarganegaraan</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:dropdownlist id="DDL_CU_CITIZENSHIP" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
                                    <TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Jumlah Anak</TD>
										<TD></TD>
										<TD class="TDBGColorValue" style="HEIGHT: 17px"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CHILDREN" runat="server" MaxLength="2"
												Columns="3"></asp:textbox></TD>
									</TR>
                                    <TR>
										<TD class="TDBGColor1" style="WIDTH: 161px">No Kartu Keluarga</TD>
										<TD style="WIDTH: 11px"></TD>
										<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_NOKARTUKELUARGA" runat="server" MaxLength="50"
												Columns="40"></asp:textbox></TD>
									</TR>
                                    <TR>
										<TD colspan="3"><b>Data Pasangan</b></TD>
									</TR>
									<TR>
										<TD colSpan="3">
											<TABLE id="Table11" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 161px">Nama Pasangan</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_FNAME" runat="server" MaxLength="50"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_MNAME" runat="server" MaxLength="50"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_LNAME" runat="server" MaxLength="50"
															Columns="40"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 161px">No KTP Pasangan</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox id="TXT_CU_SPOUSE_IDCARDNUM" runat="server" MaxLength="50" Columns="40"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 161px">Alamat KTP Pasangan</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR1" runat="server" MaxLength="100"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR2" runat="server" MaxLength="100"
															Columns="40"></asp:textbox><BR>
														<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_SPOUSE_KTPADDR3" runat="server" MaxLength="100"
															Columns="40"></asp:textbox></TD>
												</TR>
												<TR>
													<TD class="TDBGColor1" style="WIDTH: 161px">Tanggal Terbit KTP Pasangan</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_DAY" runat="server"
															Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_SPOUSE_KTPISSUEDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPISSUEDATE_YEAR" runat="server"
															Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
												</TR>
												<!-- <TR>
													<TD class="TDBGColor1" style="WIDTH: 161px">Tanggal Berakhir KTP Pasangan</TD>
													<TD style="WIDTH: 11px"></TD>
													<TD><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_DAY" runat="server"
															Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_SPOUSE_KTPEXPDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_SPOUSE_KTPEXPDATE_YEAR" runat="server"
															Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
												</TR> -->
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" runat="server">
                                    <TR>
										<TD colspan="3"><b>Data KTP</b></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. KTP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_IDCARDNUM" runat="server" Width="300px" CssClass="mandatory2" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tanggal Berakhir KTP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_DAY" runat="server" Width="24px"
												CssClass="mandatory2" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_IDCARDEXP_MONTH" runat="server" CssClass="mandatory2"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_IDCARDEXP_YEAR" runat="server" Width="36px"
												CssClass="mandatory2" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Alamat KTP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPADDR1" runat="server" Width="300px" CssClass="mandatory2" MaxLength="100"></asp:textbox>
                                            <asp:checkbox id="CHB_CU_KTPADDR" Text="Sama dengan Alamat Rumah" Runat="server"></asp:checkbox><BR>
											<asp:textbox id="TXT_CU_KTPADDR2" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Kecamatan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPADDR3" runat="server" Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kota</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_KTPCITY" runat="server" Width="175px" ReadOnly="True" CssClass="mandatory2"></asp:textbox><asp:textbox id="LBL_CU_KTPCITY" runat="server" style="display:none"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Kode Pos</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue">
                                            <asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_KTPZIPCODE" runat="server" CssClass="mandatory2" MaxLength="6" Columns="6"></asp:textbox>
                                            <!--<asp:button id="BTN_SEARCHKTPZIP" runat="server" Text="Search" onclick="BTN_SEARCHKTPZIP_Click"></asp:button>-->
                                            <input type="button" value="Search" onclick="window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_KTPZIPCODE&trgObjID2=TXT_CU_KTPADDR3&trgObjID3=TXT_CU_KTPCITY&trgObjID4=LBL_CU_KTPCITY', 'SearchZipcode', 'status=no,scrollbars=no,width=640,height=480'); return false;">
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jenis Alamat</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_P" runat="server"></asp:dropdownlist><asp:dropdownlist id="DDL_CU_JNSNASABAH_P" runat="server" CssClass="mandatory" Visible="False"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD></TD>
										<TD style="WIDTH: 15px"></TD>
										<TD></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Pendidikan Terakhir</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_EDUCATION" runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jabatan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JOBTITLE" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Bidang Usaha</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_BUSSTYPE" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Berdiri Sejak</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_ESTABLISHDD" runat="server" MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CU_ESTABLISHMM" runat="server"></asp:dropdownlist><asp:textbox id="TXT_CU_ESTABLISHYY" runat="server" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">NPWP</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_NPWP" runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Pendapatan Bersih/Bulan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return digitsonly()" id="TXT_CU_NETINCOMEMM" runat="server" Width="300px"
												MaxLength="15">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jumlah Karyawan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_EMPLOYEE" runat="server"
												MaxLength="4" Columns="5"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nama Ibu Kandung</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_MOTHER" runat="server" 
                                                Width="300px" CssClass="mandatory2" MaxLength="25"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Nama Pelaporan</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
                                            <asp:textbox id="TXT_CU_NAMAPELAPORAN" runat="server" Width="300px" 
                                                CssClass="mandatory2" MaxLength="100"></asp:textbox>
                                            <asp:checkbox id="CHB_CU_NAMAPELAPORAN" Text="Sama dengan Nama Pemohon" Runat="server"></asp:checkbox>
                                        </TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Negara Domisili</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_NEGARADOMISILI" 
                                                runat="server" CssClass="mandatory2"></asp:dropdownlist></TD>
									</TR>
                                    <TR>
										<TD class="TDBGColor1">Nama Instansi / Tempat Bekerja</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_TEMPATKERJA" runat="server" 
                                                Width="300px" MaxLength="100"></asp:textbox></TD>
									</TR>
                                    <TR>
										<TD class="TDBGColor1">Kode Instansi</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_KODEINSTANSI" 
                                                runat="server"></asp:dropdownlist></TD>
									</TR>
                                    <TR>
										<TD class="TDBGColor1">No. Pegawai</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
                                            <asp:textbox id="TXT_CU_NOPEGAWAI" runat="server" 
                                                Width="300px" MaxLength="25"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR id="TR_COMPANY" runat="Server">
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">CIF No.</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_CIF_C" runat="server" Width="200px"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Nama Perusahaan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNAME" runat="server" Width="200px"
												CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Jenis Badan Usaha</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_JNSNASABAH" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Berdiri Sejak</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHDD" runat="server" CssClass="mandatory"
												MaxLength="2" Columns="2"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPESTABLISHMM" runat="server" CssClass="mandatory"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPESTABLISHYY" runat="server" CssClass="mandatory"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Tempat Berdiri Perusahaan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPOB" runat="server" Width="200px"
												CssClass="mandatory" MaxLength="50"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Alamat Perusahaan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR1" runat="server" Width="300px"
												CssClass="mandatory" MaxLength="100"></asp:textbox><BR>
											<asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR2" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 164px">Kelurahan / Kecamatan</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPADDR3" runat="server" Width="300px"
												MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Kota</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPCITY" runat="server" Width="175px" ReadOnly="True" CssClass="mandatory"></asp:textbox><asp:textbox id="LBL_CU_COMPCITY" runat="server" style="display:none"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Kode Pos</TD>
										<TD></TD>
										<TD class="TDBGColorValue">
                                            <asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPZIPCODE" runat="server" CssClass="mandatory" MaxLength="6" Columns="6"></asp:textbox>
                                            <!--<asp:button id="BTN_SEARCHCOMP" runat="server" Text="Search" onclick="BTN_SEARCHCOMP_Click"></asp:button>-->
                                            <input type="button" value="Search" onclick="window.open('SearchZipcode.aspx?targetFormID=Form1&targetObjectID=TXT_CU_COMPZIPCODE&trgObjID2=TXT_CU_COMPADDR3&trgObjID3=TXT_CU_COMPCITY&trgObjID4=LBL_CU_COMPCITY', 'SearchZipcode', 'status=no,scrollbars=no,width=640,height=480'); return false;">
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Jenis Alamat</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_JNSALAMAT_C" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px"></TD>
										<TD></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">External Rating Company</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPEXTRATING_BY" runat="server" AutoPostBack="True" onselectedindexchanged="DDL_CU_COMPEXTRATING_BY_SelectedIndexChanged"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Rating Class</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPEXTRATING_CLASS" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Rating Date</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEXTRATING_DATE_DAY" runat="server"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPEXTRATING_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEXTRATING_DATE_YEAR" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Kode Listing Bursa</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPLISTINGCODE" runat="server"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" style="WIDTH: 166px">Tanggal Listing Bursa</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPLISTINGDATE_DAY" runat="server"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPLISTINGDATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPLISTINGDATE_YEAR" runat="server"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" width="129">Bidang Usaha</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_COMPBUSSTYPE" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Akta Pendirian</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPAKTAPENDIRIAN" runat="server" Width="296px" CssClass="mandatory"
												MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Tgl Terbit</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_DAY" runat="server"
												Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGASURANSI_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPTGASURANSI_YEAR" runat="server"
												Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Akta Perubahan Terakhir</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPAKTATERAKHIR_NO" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Tanggal Perubahan Terakhir</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPAKTATERAKHIR_DATE_DAY" runat="server"
												Width="24px" MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_COMPAKTATERAKHIR_DATE_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPAKTATERAKHIR_DATE_YEAR" runat="server"
												Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" width="129">Nama Notaris</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox id="TXT_CU_COMPNOTARYNAME" runat="server" Width="296px" MaxLength="20"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Jumlah Karyawan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPEMPLOYEE" runat="server" MaxLength="4"
												Columns="5">0</asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Telepon</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPPHNAREA" runat="server" CssClass="mandatory"
												MaxLength="5" Columns="4"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPPHNNUM" runat="server" Width="100px"
												CssClass="mandatory" MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPPHNEXT" runat="server" MaxLength="5"
												Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">No. Fax</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPFAXAREA" runat="server" MaxLength="5"
												Columns="4"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPFAXNUM" runat="server" Width="100px"
												MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPFAXEXT" runat="server" MaxLength="5"
												Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">NPWP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_COMPNPWP" runat="server" Width="200px"
												CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">TDP</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_TDP" runat="server" CssClass="mandatory"
												MaxLength="17"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tgl Penerbitan</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_DAY" runat="server" Width="24px"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLTERBIT_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLTERBIT_YEAR" runat="server" Width="36px"
												MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Tgl Jatuh Tempo</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_DAY" runat="server" Width="24px"
												MaxLength="2" Columns="4"></asp:textbox><asp:dropdownlist id="DDL_CU_TGLJATUHTEMPO_MONTH" runat="server"></asp:dropdownlist><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_TGLJATUHTEMPO_YEAR" runat="server"
												Width="36px" MaxLength="4" Columns="4"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1">Contact Person</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPERSON" runat="server" Width="300px"
												CssClass="mandatory" MaxLength="100"></asp:textbox></TD>
									</TR>
									<TR id="TR_telepon" runat="server">
										<TD class="TDBGColor1" width="129">No. Telepon</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CONTACTPHNAREA" runat="server" MaxLength="5"
												Columns="4"></asp:textbox><asp:textbox onkeypress="return kutip_satu()" id="TXT_CU_CONTACTPHNNUM" runat="server" Width="100px"
												MaxLength="15" Columns="10"></asp:textbox>&nbsp;Ext.
											<asp:textbox onkeypress="return numbersonly()" id="TXT_CU_CONTACTPHNEXT" runat="server" MaxLength="5"
												Columns="3"></asp:textbox></TD>
									</TR>
									<TR>
										<TD width="129"></TD>
										<TD></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR id="TR_koperasi" runat="server">
										<TD align="center" colSpan="3">Untuk Koperasi/Kelompok dan sebagainya</TD>
										<TD></TD>
										<TD class="TDBGColorValue"></TD>
									</TR>
									<TR id="TR_anggota" runat="server">
										<TD class="TDBGColor1" width="129">Jumlah Anggota</TD>
										<TD></TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return numbersonly()" id="TXT_CU_COMPANGGOTA" runat="server" MaxLength="4"
												Columns="5">0</asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- pipeline -->
						<TR id="TR_sektor" runat="Server">
							<TD class="td" vAlign="top" width="50%">
                                <TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Group Nasabah</TD>
										<TD class="TDBGColorValue"><asp:textbox id="DDL_groupnasabah" runat="server" Width="300px" AutoPostBack="False"></asp:textbox></TD>
									</TR>
                                    <div id="div_sektor">
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 1</TD>
										<TD class="TDBGColorValue">
                                            <asp:dropdownlist id="DDL_bmsektor" runat="server" CssClass="selectpicker mandatory" data-live-search="true" data-width="auto" data-style="btn-mandy" onchange="FillDDL2(),EmptyDDL3(),EmptyDDL4()"></asp:dropdownlist>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 2</TD>
										<TD class="TDBGColorValue">
                                            <asp:dropdownlist id="DDL_bmsubsektor" runat="server" CssClass="selectpicker mandatory" data-live-search="true" data-width="auto" data-style="btn-mandy" onchange="FillDDL3(),EmptyDDL4(),FillTXT2()"></asp:dropdownlist>
                                            <asp:textbox id="TXT_bmsubsektor" runat="server" style="display:none"></asp:textbox>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 3</TD>
										<TD class="TDBGColorValue">
                                            <asp:dropdownlist id="DDL_bmsubsubsektor" runat="server" CssClass="selectpicker mandatory" data-live-search="true" data-width="auto" data-style="btn-mandy" onchange="FillDDL4(),FillTXT3()"></asp:dropdownlist>
                                            <asp:textbox id="TXT_bmsubsubsektor" runat="server" style="display:none"></asp:textbox>
										</TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Sektor Ekonomi BI 4</TD>
										<TD class="TDBGColorValue">
                                            <asp:dropdownlist id="DDL_SEKTOREKONOMIBI" runat="server" CssClass="mandatory" Enabled="False"></asp:dropdownlist>&nbsp;
										</TD>
									</TR>
                                    </div>
									<TR>
										<TD class="TDBGColorValue" align="left" colSpan="2"><INPUT id="BTN_SEARCHSE" onclick="SearchSektorEkonomi('Form1', 'TXT_TEMPBI', '')" type="button"
												value="Search Sektor Ekonomi" name="BTN_SEARCHSE">&nbsp;
											<asp:textbox id="TXT_TEMPBI" runat="server" Width="1px" BorderStyle="None" ontextchanged="TXT_TEMPBI_TextChanged"></asp:textbox>&nbsp;
											<INPUT id="BTN_PG" onclick="window.open('PG2010.html')" type="button" value="Portfolio Guideline"
												name="BTN_PG">
										</TD>
									</TR>
								</TABLE>
							</TD>
							<TD class="td" vAlign="top" width="50%">
								<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Net Income</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_netincome" onblur="FormatCurrency(this)"
												runat="server" Width="200px" CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
									</TR>
									<!-- <TR>
										<TD class="TDBGColor1" align="right" width="180">Pendapatan Operasional</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_pendapatanoperasional" onblur="FormatCurrency(this)"
												runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
									</TR> -->
									<!-- <TR>
										<TD class="TDBGColor1" align="right" width="180">Pendapatan Non Operasional</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return signeddigitsonly()" id="Textbox_pendapatannon" onblur="FormatCurrency(this)"
												runat="server" Width="200px" MaxLength="25"></asp:textbox></TD>
									</TR> -->
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Lokasi Pabrik/Kebun/Proyek</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_lokasiproyek" runat="server" 
                                                CssClass="selectpicker mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Key Person</TD>
										<TD class="TDBGColorValue"><asp:textbox onkeypress="return kutip_satu()" id="Textbox_keyperson" runat="server" Width="200px"
												CssClass="mandatory" MaxLength="25"></asp:textbox></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Lokasi Dati II</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_LOKASIDATI2" runat="server" CssClass="selectpicker mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Hubungan Nasabah dengan Pejabat 
											Executive Bank</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_HUBEXECBM" runat="server" CssClass="mandatory"></asp:dropdownlist></TD>
									</TR>
									<TR>
										<TD class="TDBGColor1" align="right" width="180">Hubungan Keluarga</TD>
										<TD class="TDBGColorValue"><asp:dropdownlist id="DDL_CU_HUBKELBM" runat="server"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="td" vAlign="top" width="50%" colSpan="2">
								<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD style="WIDTH: 129px">IDI Bank Indonesia</TD>
										<TD style="WIDTH: 15px"></TD>
										<TD class="TDBGColorValue" style="WIDTH: 117px" width="117"><asp:radiobuttonlist id="RDO_BI_CHECKING" runat="server" Width="150px" RepeatDirection="Horizontal">
												<asp:ListItem Value="1" Selected="True">Ya</asp:ListItem>
												<asp:ListItem Value="0">Tidak</asp:ListItem>
											</asp:radiobuttonlist></TD>
										<TD class="TDBGColorValue" style="WIDTH: 304px">
											<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD style="WIDTH: 138px"><asp:label id="LBL_CO" runat="server">Pelaksana :</asp:label></TD>
													<TD><asp:dropdownlist id="DDL_GRPUNIT" runat="server"></asp:dropdownlist></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="TDBGColorValue">Tanggal Terakhir Cek:
											<asp:textbox id="TXT_BS_RECVDATE" runat="server" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD class="TDBGColor2" vAlign="top" align="center" colSpan="2">
                                <asp:button id="BTN_SAVE" runat="server" Width="100px" CssClass="Button1" 
                                    Text="Simpan" onclick="BTN_SAVE_Click"></asp:button>
                                <asp:button id="BTN_SAVECON" runat="server" Width="100px" CssClass="Button1" 
                                    Text="Simpan" onclick="BTN_SAVE_Click"></asp:button></TD>
						</TR>
					</TBODY>
				</TABLE>
			</center>
		</form>
	</body>
</HTML>
