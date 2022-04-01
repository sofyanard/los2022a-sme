<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessCustomer.aspx.cs" Inherits="SME.MobileApplication.ProcessCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../include/bootstrap.min.css" />
	<link type="text/css" rel="stylesheet" href="../include/bootstrap-select.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <b>Process Customer From Mobile Apps</b>
                </div>
                <div class="col-md-6">
                </div>
                <div class="col-md-3">
                    <a href="ListCustomer.aspx?si="></a><a href="../Body.aspx">
                        <img src="../Image/MainMenu.jpg"></a>
                    <a href="../Logout.aspx" target="_top">
                        <img src="../Image/Logout.jpg"></a>
                </div>
            </div>

			<div><h3>1. New Customers From Mobile Apps</h3></div>

			<div><h5>Nasabah yang baru mendaftar lewat mobile apps dan belum diproses</h5></div>

			<div class="row">
				<div class="col-md-12">

				    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" >
                        <Columns>
							<asp:BoundField DataField="Id" />
                            <asp:BoundField DataField="NoIdentitas" HeaderText="No KTP" />
							<asp:BoundField DataField="NamaLengkap" HeaderText="Nama Lengkap" />
							<asp:BoundField DataField="TanggalLahir" HeaderText="Tanggal Lahir" DataFormatString="{0:dd-MMM-yyyy}" />
							<asp:BoundField DataField="AlamatRumah" HeaderText="Alamat Rumah" />
							<asp:BoundField DataField="KotaKabRumah" HeaderText="Kota/Kabupaten" />
							<asp:BoundField DataField="PropinsiRumah" HeaderText="Propinsi" />
                            <asp:ButtonField CommandName="detail" Text="Detail" />
                        </Columns>
                    </asp:GridView>

				</div>
			</div>

			<div><h3>2. Detail Customer From Mobile Apps</h3></div>

			<div><h5>Pilih satu nasabah dari tabel, klik Detail</h5></div>
			
			<div class="row">
				<div class="col-md-6">

					<dl class="row">
						<dt class="col-md-4">Gelar Sebelum</dt>
						<dd class="col-md-8"><asp:Label ID="LblGelarSebelum" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Nama Lengkap</dt>
						<dd class="col-md-8"><asp:Label ID="LblNamaLengkap" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Gelar Sesudah</dt>
						<dd class="col-md-8"><asp:Label ID="LblGelarSesudah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Jenis Kelamin</dt>
						<dd class="col-md-8"><asp:Label ID="LblJenisKelamin" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Tempat Lahir</dt>
						<dd class="col-md-8"><asp:Label ID="LblTempatLahir" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Tanggal Lahir</dt>
						<dd class="col-md-8"><asp:Label ID="LblTanggalLahir" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">No Identitas</dt>
						<dd class="col-md-8"><asp:Label ID="LblNoIdentitas" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Alamat Rumah</dt>
						<dd class="col-md-8"><asp:Label ID="LblAlamatRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kelurahan</dt>
						<dd class="col-md-8"><asp:Label ID="LblKelurahanRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kecamatan</dt>
						<dd class="col-md-8"><asp:Label ID="LblKecamatanRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kota/Kab</dt>
						<dd class="col-md-8"><asp:Label ID="LblKotaKabRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Propinsi</dt>
						<dd class="col-md-8"><asp:Label ID="LblPropinsiRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kode Pos</dt>
						<dd class="col-md-8"><asp:Label ID="LblKodePosRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Telepon Rumah</dt>
						<dd class="col-md-8"><asp:Label ID="LblTeleponRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Telepon Genggam</dt>
						<dd class="col-md-8"><asp:Label ID="LblTeleponGenggam" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Nama Ibu Kandung</dt>
						<dd class="col-md-8"><asp:Label ID="LblNamaIbuKandung" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Pendidikan</dt>
						<dd class="col-md-8"><asp:Label ID="LblPendidikan" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Status Perkawinan</dt>
						<dd class="col-md-8"><asp:Label ID="LblStatusPerkawinan" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kewarganegaraan</dt>
						<dd class="col-md-8"><asp:Label ID="LblKewarganegaraan" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Status Rumah</dt>
						<dd class="col-md-8"><asp:Label ID="LblStatusRumah" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

				</div>
				<div class="col-md-6">

					<dl class="row">
						<dt class="col-md-4">Id</dt>
						<dd class="col-md-8"><asp:Label ID="LblId" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">User Name</dt>
						<dd class="col-md-8"><asp:Label ID="LblUserName" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4"></dt>
						<dd class="col-md-8">
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4"></dt>
						<dd class="col-md-8">Data Pekerjaan
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Jenis Pekerjaan</dt>
						<dd class="col-md-8"><asp:Label ID="LblJenisPekerjaan" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Pendapatan</dt>
						<dd class="col-md-8"><asp:Label ID="LblPendapatan" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Alamat Kantor</dt>
						<dd class="col-md-8"><asp:Label ID="LblAlamatKantor" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kota/Kab</dt>
						<dd class="col-md-8"><asp:Label ID="LblKotaKabKantor" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Propinsi</dt>
						<dd class="col-md-8"><asp:Label ID="LblPropinsiKantor" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kode Pos</dt>
						<dd class="col-md-8"><asp:Label ID="LblKodePosKantor" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Telepon</dt>
						<dd class="col-md-8"><asp:Label ID="LblTeleponKantor" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4"></dt>
						<dd class="col-md-8">
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4"></dt>
						<dd class="col-md-8">Data Saudara Tidak Serumah
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Nama</dt>
						<dd class="col-md-8"><asp:Label ID="LblNamaSaudara" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Alamat</dt>
						<dd class="col-md-8"><asp:Label ID="LblAlamatSaudara" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kota/Kab</dt>
						<dd class="col-md-8"><asp:Label ID="LblKotaKabSaudara" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Propinsi</dt>
						<dd class="col-md-8"><asp:Label ID="LblPropinsiSaudara" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Kode Pos</dt>
						<dd class="col-md-8"><asp:Label ID="LblKodePosSaudara" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4">Hubungan</dt>
						<dd class="col-md-8"><asp:Label ID="LblHubunganSaudara" runat="server" Text=""></asp:Label>
                        </dd>
					</dl>

					<dl class="row">
						<dt class="col-md-4"></dt>
						<dd class="col-md-8">
                        </dd>
					</dl>

				</div>
			</div>

			<div class="row">
				<div class="col-md-12">

				    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-sm" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView2_PageIndexChanging" >
						<Columns>
							<asp:BoundField DataField="Id" />
							<asp:BoundField DataField="Caption" HeaderText="Caption" />
                            <asp:TemplateField HeaderText="File Name">  
								<ItemTemplate>  
									<asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" CommandArgument='<%# Eval("FileUrl") %>'  
                                            OnClick="downloadFile" Text='<%# Eval("FileName") %>' />  
								</ItemTemplate>  
							</asp:TemplateField>
                        </Columns>
                    </asp:GridView>

				</div>
			</div>

			<div><h3>3. Search For Existing Customer</h3></div>

			<div class="row">
				<div class="col-md-6">
                    <div class="form-group form-row">
                        <label for="noktp" class="col-md-4">No KTP</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="noktp" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group form-row">
                        <label for="nama" class="col-md-4">Nama</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="nama" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group form-row">
                        <label for="tanggal" class="col-md-4">Tanggal Lahir</label>
                        <div class="col-md-8">
                            <asp:TextBox type="date" ID="tanggal" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group form-row">
                        <label for="alamat" class="col-md-4">Alamat</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="alamat" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group form-row">
                        <label for="kota" class="col-md-4">Kota</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="kota" runat="server" CssClass="selectpicker form-control" data-live-search="true">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn btn-primary mx-2" OnClick="Button1_Click" />
				    <asp:Button ID="Button2" runat="server" Text="Clear" CssClass="btn btn-danger mx-2" OnClick="Button2_Click" />
				</div>
				<div class="col-md-6"></div>
			</div>

			<div><h3>4. Existing Customers</h3></div>

			<div><h5>Search untuk memastikan nasabah sudah ada atau belum</h5></div>

			<div class="row">
				<div class="col-md-12">

				    <asp:GridView ID="GridView3" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView3_PageIndexChanging" >
                        <Columns>
							<asp:BoundField DataField="CU_REF" HeaderText="Cust Ref No" />
							<asp:BoundField DataField="CU_CIF" HeaderText="CIF No" />
                            <asp:BoundField DataField="CU_IDCARDNUM" HeaderText="No KTP" />
							<asp:BoundField DataField="CU_NAME" HeaderText="Nama" />
							<asp:BoundField DataField="CU_DOB" HeaderText="Tanggal Lahir" DataFormatString="{0:dd-MMM-yyyy}" />
							<asp:BoundField DataField="CU_ADDRESS" HeaderText="Alamat" />
							<asp:BoundField DataField="CITYNAME" HeaderText="Kota/Kabupaten" />
                        </Columns>
                    </asp:GridView>

				</div>
			</div>

			<div><h3>5. Process Customer From Mobile Apps</h3></div>

			<div class="row">
				<div class="col-md-6">
					<h5>Pastikan pencarian sudah dilakukan dengan benar</b></h5>
					<h5>Jika Nasabah Existing <b>Tidak Ditemukan</b></h5>
					<asp:Button ID="Button3" runat="server" Text="Proses Sebagai New Customer" CssClass="btn btn-primary" OnClick="Button3_Click" />
				</div>
				<div class="col-md-6">
					<h5>Jika Nasabah Existing <b>Ditemukan</b>, Hubungkan (silakan copy <b>Cust Ref No</b> dari tabel)</h5>
					<div class="row">
						<div class="col-md-4">
							Existing Cust Ref No
						</div>
						<div class="col-md-8">
							<asp:TextBox ID="TxtLosCuRef" runat="server" CssClass="form-control"></asp:TextBox>
						</div>
					</div>
					<div class="row mt-3">
						<div class="col-md-4"></div>
						<div class="col-md-8">
							<asp:Button ID="Button4" runat="server" Text="Proses Sebagai Existing Customer" CssClass="btn btn-primary" OnClick="Button4_Click" />
						</div>
					</div>
				</div>
			</div>

			<br />
			<br />

			<!-- Modal -->
            <div class="modal fade" id="popModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            body
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>

    <script type="text/javascript" src="../include/jquery.min.js"></script>
	<script type="text/javascript" src="../include/popper.min.js"></script>
	<script type="text/javascript" src="../include/bootstrap.min.js"></script>
	<script type="text/javascript" src="../include/bootstrap-select.min.js"></script>

	<script type="text/javascript">
        function ShowModal(title, body) {
            $("#popModal .modal-title").html(title);
            $("#popModal .modal-body").html(body);
            $("#popModal").modal("show");
		}
    </script>
</body>
</html>
