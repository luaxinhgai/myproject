using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySieuThi.Model;

namespace QuanLySieuThi.View
{
    public partial class cobTk : Form
    {
        BANHANGSIEUTHIEntities db = new BANHANGSIEUTHIEntities();
        public cobTk()
        {
            InitializeComponent();
        }
        private void DanhSoTtDgv(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
        private void tabPhieuNhapThem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnPhieuNhapThemChiTiet_Click(object sender, EventArgs e)
        {
            tabKho.SelectedTab = tabPageChiTiet;
            txtMaHienThiCt.Text = txtMaHienThi.Text;
            DgvXemChiTietLoad();
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool check = false;
            //kiểm tra xem mặt hàng đã có trong phiếu chưa
            for (int i = 0; i < dgvXemCt.Rows.Count - 1; i++)
            {
                if (int.Parse(dgvXemCt.Rows[i].Cells[0].Value.ToString()) == int.Parse(cobMatHangCt.SelectedValue.ToString()))
                {
                    check = true;
                    break;
                }

            }
            if (check == true)
            {
                MessageBox.Show("Mặt hàng bạn vừa chọn đã có trong phiếu!", "Chú ý", MessageBoxButtons.OK,
                      MessageBoxIcon.Warning);
            }
            else
            {
                //thêm mới
                try
                {
                    decimal soLuong = decimal.Parse(txtSoLuong.Text);
                    decimal donGia = decimal.Parse(txtDonGia.Text);
                    decimal thanhTien = soLuong * donGia;
                    string[] row = new string[] { cobMatHangCt.SelectedValue.ToString(), cobMatHangCt.Text, txtSoLuong.Text, txtDonGia.Text, thanhTien.ToString() };
                    dgvXemCt.Rows.Add(row);
                    //đánh số thứ tự
                    DanhSoTtDgv(dgvXemCt);
                    //tính tổng tiền
                    txtTienHangChit.Text = (decimal.Parse(txtTienHangChit.Text) + thanhTien).ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn phải nhập thông tin phiếu trước!");
                }
            }

        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            // DgvXemChiTietLoad();
            //đổ combobox
            cobMatHangCt.DataSource = db.HangHoas.ToList();
            cobMatHangCt.ValueMember = "MaHang";
            cobMatHangCt.DisplayMember = "TenHang";

            cobDoiTac.DataSource = db.DoiTacs.ToList();
            cobDoiTac.ValueMember = "MaDoiTac";
            cobDoiTac.DisplayMember = "TenDoiTac";

            cobNhanVien.DataSource = db.NhanViens.ToList();
            cobNhanVien.ValueMember = "MaNv";
            cobNhanVien.DisplayMember = "TenNv";
            //chỉ cho phép nhập số ở textboxx
            txtSoLuong.KeyPress += new KeyPressEventHandler(txtSoLuong_KeyPress);
            txtVat.KeyPress += new KeyPressEventHandler(txtVat_KeyPress);
            txtMaBaoCao.KeyPress += new KeyPressEventHandler(txtMaBaoCao_KeyPress);
            txtCk.KeyPress += new KeyPressEventHandler(textBox7_KeyPress);
        }
        private void DgvXemChiTietLoad()
        {
            dgvXemCt.ColumnCount = 5;
            dgvXemCt.Columns[0].HeaderText = "Mã hàng";
            dgvXemCt.Columns[0].Width = 100;
            dgvXemCt.Columns[1].HeaderText = "Tên hàng";
            dgvXemCt.Columns[1].Width = 150;
            dgvXemCt.Columns[2].HeaderText = "Số lượng";
            dgvXemCt.Columns[2].Width = 100;
            dgvXemCt.Columns[3].HeaderText = "Đơn giá";
            dgvXemCt.Columns[3].Width = 150;
            dgvXemCt.Columns[4].HeaderText = "Thành tiền";
            dgvXemCt.Columns[4].Width = 150;
        }

        private void txtDonGia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtDonGia.Text.Equals("0"))
                    return;
                double temp = Convert.ToDouble(txtDonGia.Text);
                txtDonGia.Text = temp.ToString("##.###");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xin mời nhập lại số tiền!");
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //chỉ cho phép nhập số ở textboxx
            txtSoLuong.KeyPress += new KeyPressEventHandler(txtSoLuong_KeyPress);
        }

        private void dgvXemCt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            tabKho.SelectedTab = tabPageThongTin;
            txtTienHangPhieu.Text = txtTienHangChit.Text;
            txtTongTien.Text = (decimal.Parse(txtTienHangPhieu.Text) * (100 + decimal.Parse(txtVat.Text) - decimal.Parse(txtCk.Text)) / 100).ToString();
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            txtVat.KeyPress += new KeyPressEventHandler(txtVat_KeyPress);

            txtTongTien.Text = (decimal.Parse(txtTienHangPhieu.Text) * (100 + decimal.Parse(txtVat.Text) - decimal.Parse(txtCk.Text) / 100)).ToString();
        }

        private void btnBoQuaThem_Click(object sender, EventArgs e)
        {

        }

        private void txtVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            txtCk.KeyPress += new KeyPressEventHandler(textBox7_KeyPress);
            txtTongTien.Text = (decimal.Parse(txtTienHangPhieu.Text) * (100 + decimal.Parse(txtVat.Text) - decimal.Parse(txtCk.Text) / 100)).ToString();
        }

        private void btnLuuThem_Click(object sender, EventArgs e)
        {
            if (cobPhieu.Text == "Phiếu nhập")
            {
                //nhập phiếu
                PhieuNhap phieuNhap = new PhieuNhap();
                try
                {
                    phieuNhap.MaHienThi = txtMaHienThi.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhập mã hiển thị!");
                }
                phieuNhap.MaNv = int.Parse(cobNhanVien.SelectedValue.ToString());
                phieuNhap.MaDoiTac = int.Parse(cobDoiTac.SelectedValue.ToString());
                phieuNhap.NgayNhap = dateNgayLap.Value;
                phieuNhap.GhiChu = txtGhiChu.Text;
                phieuNhap.TienHang = decimal.Parse(txtTienHangPhieu.Text);
                phieuNhap.ThueVat = decimal.Parse(txtVat.Text);
                phieuNhap.ChietKhau = decimal.Parse(txtCk.Text);
                phieuNhap.TongTien = decimal.Parse(txtTongTien.Text);
                phieuNhap.Status = true;
                db.PhieuNhaps.Add(phieuNhap);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Thêm phiếu nhập thành công!", "Thêm phiếu nhập", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm phiếu nhập!", "Thêm phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //nhập chi tiết phiếu
                int maPhieu = db.PhieuNhaps.Max(s => s.MaPhieu);
                for (int i = 0; i < dgvXemCt.Rows.Count - 1; i++)
                {
                    ChiTietNhap chiTietNhap = new ChiTietNhap();
                    chiTietNhap.MaPhieu = maPhieu;
                    chiTietNhap.MaHang = int.Parse(dgvXemCt.Rows[i].Cells[0].Value.ToString());
                    chiTietNhap.SoLuong = int.Parse(dgvXemCt.Rows[i].Cells[2].Value.ToString());
                    chiTietNhap.GiaNhap = decimal.Parse(dgvXemCt.Rows[i].Cells[3].Value.ToString());
                    db.ChiTietNhaps.Add(chiTietNhap);
                }
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Thêm chi tiết phiếu nhập thành công!", "Thêm chi tiết phiếu nhập", MessageBoxButtons.OK,
                      MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm chi tiết phiếu nhập!", "Thêm chi tiết phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (cobPhieu.Text == "Phiếu xuất")
                {
                    //nhập phiếu
                    PhieuXuat phieuXuat = new PhieuXuat();
                    try
                    {
                        phieuXuat.MaHienThi = txtMaHienThi.Text;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Nhập mã hiển thị!");
                    }
                    phieuXuat.MaNv = int.Parse(cobNhanVien.SelectedValue.ToString());
                    phieuXuat.MaDoiTac = int.Parse(cobDoiTac.SelectedValue.ToString());
                    phieuXuat.NgayXuat = dateNgayLap.Value;
                    phieuXuat.GhiChu = txtGhiChu.Text;
                    phieuXuat.TienHang = decimal.Parse(txtTienHangPhieu.Text);
                    phieuXuat.ThueVat = decimal.Parse(txtVat.Text);
                    phieuXuat.ChietKhau = decimal.Parse(txtCk.Text);
                    phieuXuat.TongTien = decimal.Parse(txtTongTien.Text);
                    phieuXuat.Status = true;
                    db.PhieuXuats.Add(phieuXuat);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Thêm phiếu xuất thành công!", "Thêm phiếu xuất", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thêm phiếu xuất!", "Thêm phiếu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //nhập chi tiết phiếu
                    int maPhieu = db.PhieuXuats.Max(s => s.MaPhieu);
                    for (int i = 0; i < dgvXemCt.Rows.Count - 1; i++)
                    {
                        ChiTietXuat chiTietXuat = new ChiTietXuat();
                        chiTietXuat.MaPhieu = maPhieu;
                        chiTietXuat.MaHang = int.Parse(dgvXemCt.Rows[i].Cells[0].Value.ToString());
                        chiTietXuat.SoLuong = int.Parse(dgvXemCt.Rows[i].Cells[2].Value.ToString());
                        chiTietXuat.GiaXuat = decimal.Parse(dgvXemCt.Rows[i].Cells[3].Value.ToString());
                        db.ChiTietXuats.Add(chiTietXuat);
                    }
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Thêm chi tiết phiếu xuất thành công!", "Thêm chi tiết phiếu xuất", MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thêm chi tiết phiếu xuất!", "Thêm chi tiết phiếu xuất", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại phiếu cần nhập!");
                }
            }
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cobMatHangCt.SelectedItem = dgvXemCt.CurrentRow.Cells[1].Value.ToString();
            txtSoLuong.Text = dgvXemCt.CurrentRow.Cells[2].Value.ToString();
            txtDonGia.Text = dgvXemCt.CurrentRow.Cells[3].Value.ToString();
            btnThem.Visible = false;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sua == false)
            {
                dgvXemCt.Rows.Remove(dgvXemCt.CurrentRow);
            }
            else
            {
                int maPhieu = int.Parse(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
                DialogResult result =
                    MessageBox.Show(
                        "Việc xóa dữ liệu sẽ tự cập nhật các thông tin liên quan và bạn không thể khôi phục lại. Bạn có chắc muốn sửa không?",
                        "Xóa chi tiết phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int maHang = int.Parse(dgvXemCt.CurrentRow.Cells[0].Value.ToString());

                    //thao tác trên form
                    txtTienHangChit.Text = (decimal.Parse(txtTienHangChit.Text) - decimal.Parse(dgvXemCt.CurrentRow.Cells[4].Value.ToString())).
                     ToString();
                    txtTienHangPhieu.Text = txtTienHangChit.Text;
                    txtTongTien.Text = (decimal.Parse(txtTienHangPhieu.Text) * (100 + decimal.Parse(txtVat.Text) - decimal.Parse(txtCk.Text)) / 100).ToString();
                    //thao tác trên csdl
                    var detail =
                        db.ChiTietNhaps.Where(
                            s => s.MaPhieu == maPhieu && s.MaHang == maHang)
                            .FirstOrDefault();
                    db.ChiTietNhaps.Remove(detail);
                    var query = db.PhieuNhaps.Where(s => s.MaPhieu == maPhieu).FirstOrDefault();
                    query.TienHang = decimal.Parse(txtTienHangPhieu.Text);
                    query.TongTien = decimal.Parse(txtTongTien.Text);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Xóa dữ liệu thành công, các thay đổi về tiền hàng đã được tự động cập nhật",
                           "Xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể xóa dữ liệu",
                          "Xóa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sửaToolStripMenuItem1_Click(sender, e);
                    tabKho.SelectedTab = tabPageChiTiet;
                }
            }

        }

        private void txtTimKiem_MouseClick(object sender, MouseEventArgs e)
        {
            txtTimKiem.Text = null;
        }

        private void SetColumnDgvDanhSach()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã phiếu";
            dgvDanhSach.Columns[0].Width = 50;
            dgvDanhSach.Columns[1].HeaderText = "Mã hiển thị";
            //dgvDanhSach.Columns[1].Width = 200;
            dgvDanhSach.Columns[2].HeaderText = "Ngày lập phiếu";
            //  dgvDanhSach.Columns[2].Width = 10;
            dgvDanhSach.Columns[3].HeaderText = "Đối tác";
            dgvDanhSach.Columns[3].Width = 180;
            dgvDanhSach.Columns[4].HeaderText = "Nhân viên";
            dgvDanhSach.Columns[4].Width = 180;
            dgvDanhSach.Columns[5].HeaderText = "Tổng tiền";
            //dgvDanhSach.Columns[5].Width = 210;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cobXemPhieu.Text == "Phiếu nhập")
            {
                try
                {
                    var query = from s in db.PhieuNhaps
                                where dateFrom.Value <= s.NgayNhap && dateTo.Value >= s.NgayNhap
                                select
                                    new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayNhap, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
                    dgvDanhSach.DataSource = query.ToList();
                    DanhSoTtDgv(dgvDanhSach);
                    SetColumnDgvDanhSach();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không có phiếu được lập trong thời gian này!", "Danh sáchs phiếu nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else
            {
                if (cobXemPhieu.Text == "Phiếu xuất")
                {
                    try
                    {
                        var query = from s in db.PhieuXuats
                                    where dateFrom.Value <= s.NgayXuat && dateTo.Value >= s.NgayXuat
                                    select
                                   new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayXuat, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
                        dgvDanhSach.DataSource = query.ToList();
                        DanhSoTtDgv(dgvDanhSach);
                        SetColumnDgvDanhSach();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không có phiếu được lập trong thời gian này!", "Danh sách phiếu xuất",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                else
                {
                    MessageBox.Show("Chọn loại phiếu cần xem!");
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cobTimm.Text == "Phiếu nhập")
            {
                try
                {
                    var query = from s in db.PhieuNhaps
                                where s.MaHienThi.Contains(txtTimKiem.Text) || s.DoiTac.TenDoiTac.Contains(txtTimKiem.Text) || s.NhanVien.TenNv.Contains(txtTimKiem.Text)
                                select
                                 new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayNhap, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
                    dgvDanhSach.DataSource = query.ToList();
                    SetColumnDgvDanhSach();
                    DanhSoTtDgv(dgvDanhSach);
                }
                catch (Exception)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Tìm kiếm", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
            else
            {
                if (cobTimm.Text == "Phiếu xuất")
                {
                    try
                    {
                        var query = from s in db.PhieuXuats
                                    where s.MaHienThi.Contains(txtTimKiem.Text) || s.DoiTac.TenDoiTac.Contains(txtTimKiem.Text) || s.NhanVien.TenNv.Contains(txtTimKiem.Text)
                                    select
                                     new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayXuat, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
                        dgvDanhSach.DataSource = query.ToList();
                        DanhSoTtDgv(dgvDanhSach);
                        SetColumnDgvDanhSach();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Tìm kiếm", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Chọn loại phiếu cần xem!");
                }
            }
        }

        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ma = int.Parse(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
            tabKho.SelectedTab = tabPageThongTin;
            cobPhieu.Text = cobXemPhieu.Text;
            if (cobXemPhieu.Text == "Phiếu nhập")
            {
                var query = db.PhieuNhaps.Where(s => s.MaPhieu == ma).FirstOrDefault();
                txtMaHienThi.Text = query.MaHienThi;
                txtMaHienThiCt.Text = query.MaHienThi;
                cobDoiTac.SelectedItem = query.MaDoiTac;
                cobNhanVien.SelectedItem = query.MaNv;
                dateNgayLap.Value = query.NgayNhap.Value;
                txtTienHangPhieu.Text = query.TienHang.ToString();
                txtTienHangChit.Text = query.TienHang.ToString();
                txtVat.Text = query.ThueVat.ToString();
                txtCk.Text = query.ChietKhau.ToString();
                txtTongTien.Text = query.TongTien.ToString();
                txtGhiChu.Text = query.GhiChu;

                var detail = from s in db.ChiTietNhaps
                             where (s.MaPhieu == ma)
                             select
                                 new
                                 {
                                     maHang = s.MaHang,
                                     tenHang = s.HangHoa.TenHang,
                                     soLuong = s.SoLuong,
                                     donGia = s.GiaNhap,
                                     thanhTien = s.SoLuong * s.GiaNhap
                                 };
                dgvXemCt.DataSource = detail.ToList();
                dgvXemCt.Columns[0].HeaderText = "Mã hàng";
                dgvXemCt.Columns[0].Width = 100;
                dgvXemCt.Columns[1].HeaderText = "Tên hàng";
                dgvXemCt.Columns[1].Width = 200;
                dgvXemCt.Columns[2].HeaderText = "Số lượng";
                dgvXemCt.Columns[2].Width = 100;
                dgvXemCt.Columns[3].HeaderText = "Đơn giá";
                dgvXemCt.Columns[3].Width = 150;
                dgvXemCt.Columns[4].HeaderText = "Thành tiền";
                dgvXemCt.Columns[4].Width = 150;

                txtMaHienThi.ReadOnly = true;
                cobDoiTac.Enabled = false;
                cobNhanVien.Enabled = false;
                dateNgayLap.Enabled = false;
                txtVat.ReadOnly = true;
                txtCk.ReadOnly = true;
                groupSua.Visible = true;
                groupThem.Visible = false;
                groupThemMatHang.Visible = false;
                groupMatHang.Visible = false;
            }
            else
            {

                var query = db.PhieuXuats.Where(s => s.MaPhieu == ma).FirstOrDefault();
                txtMaHienThi.Text = query.MaHienThi;
                txtMaHienThiCt.Text = query.MaHienThi;
                cobDoiTac.SelectedItem = query.MaDoiTac;
                cobNhanVien.SelectedItem = query.MaNv;
                dateNgayLap.Value = query.NgayXuat.Value;
                txtTienHangPhieu.Text = query.TienHang.ToString();
                txtTienHangChit.Text = query.TienHang.ToString();
                txtVat.Text = query.ThueVat.ToString();
                txtCk.Text = query.ChietKhau.ToString();
                txtTongTien.Text = query.TongTien.ToString();
                txtGhiChu.Text = query.GhiChu;

                var detail = from s in db.ChiTietXuats
                             where (s.MaPhieu == ma)
                             select
                                 new
                                 {
                                     maHang = s.MaHang,
                                     tenHang = s.HangHoa.TenHang,
                                     soLuong = s.SoLuong,
                                     donGia = s.GiaXuat,
                                     thanhTien = s.SoLuong * s.GiaXuat
                                 };
                dgvXemCt.DataSource = detail.ToList();
                dgvXemCt.Columns[0].HeaderText = "Mã hàng";
                dgvXemCt.Columns[0].Width = 100;
                dgvXemCt.Columns[1].HeaderText = "Tên hàng";
                dgvXemCt.Columns[1].Width = 200;
                dgvXemCt.Columns[2].HeaderText = "Số lượng";
                dgvXemCt.Columns[2].Width = 100;
                dgvXemCt.Columns[3].HeaderText = "Đơn giá";
                dgvXemCt.Columns[3].Width = 150;
                dgvXemCt.Columns[4].HeaderText = "Thành tiền";
                dgvXemCt.Columns[4].Width = 150;

                txtMaHienThi.ReadOnly = true;
                cobPhieu.Enabled = false;
                cobDoiTac.Enabled = false;
                cobNhanVien.Enabled = false;
                dateNgayLap.Enabled = false;
                txtVat.ReadOnly = true;
                txtCk.ReadOnly = true;
                groupSua.Visible = true;
                groupThem.Visible = false;
                groupThemMatHang.Visible = false;
                groupMatHang.Visible = false;
            }
        }

        private bool sua = false; //biến này để trả về thông báo lúc sửa trực tiếp vào dữ liệu
        private void btnSuaSua_Click(object sender, EventArgs e)
        {
            txtMaHienThi.ReadOnly = false;
            cobPhieu.Enabled = true;
            cobDoiTac.Enabled = true;
            cobNhanVien.Enabled = true;
            dateNgayLap.Enabled = true;
            txtVat.ReadOnly = false;
            txtCk.ReadOnly = false;
            groupSua.Visible = true;
            groupThem.Visible = false;
            groupThemMatHang.Visible = true;
            groupMatHang.Visible = true;
            sua = true;
        }
        private void EditDetailDgvXemCt()
        {
            dgvXemCt.CurrentRow.Cells[2].Value = txtSoLuong.Text;
            dgvXemCt.CurrentRow.Cells[3].Value = txtDonGia.Text;
            dgvXemCt.CurrentRow.Cells[4].Value = decimal.Parse(txtSoLuong.Text) * decimal.Parse(txtDonGia.Text);
            txtTienHangCt.Text = "0";
            for (int i = 0; i < dgvXemCt.RowCount - 1; i++)
            {
                txtTienHangCt.Text =
                    (decimal.Parse(txtTienHangCt.Text) + decimal.Parse(dgvXemCt.Rows[i].Cells[4].Value.ToString()))
                        .ToString();
            }
            txtTienHangPhieu.Text = txtTienHangChit.Text;
            txtTongTien.Text = (decimal.Parse(txtTienHangPhieu.Text) * (100 + decimal.Parse(txtVat.Text) - decimal.Parse(txtCk.Text)) / 100).ToString();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (sua == false)
            {
                EditDetailDgvXemCt();
            }
            else
            {
                int maPhieu = int.Parse(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
                DialogResult result =
                    MessageBox.Show(
                        "Việc sửa dữ liệu sẽ tự cập nhật các thông tin liên quan và bạn không thể khôi phục lại. Bạn có chắc muốn sửa không?",
                        "Sửa chi tiết phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int maHang = int.Parse(cobMatHangCt.SelectedValue.ToString());
                    EditDetailDgvXemCt();
                    var detail =
                        db.ChiTietNhaps.Where(
                            s => s.MaPhieu == maPhieu && s.MaHang == maHang)
                            .FirstOrDefault();
                    detail.SoLuong = long.Parse(txtSoLuong.Text);
                    detail.GiaNhap = decimal.Parse(txtDonGia.Text);

                    var query = db.PhieuNhaps.Where(s => s.MaPhieu == maPhieu).FirstOrDefault();
                    query.TienHang = decimal.Parse(txtTienHangPhieu.Text);
                    query.TienHang = decimal.Parse(txtTongTien.Text);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Sửa dữ liệu thành công, các thay đổi về tiền hàng đã được tự động cập nhật",
                           "Sửa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Không thể sửa dữ liệu",
                          "Sửa dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    sửaToolStripMenuItem1_Click(sender, e);
                    tabKho.SelectedTab = tabPageChiTiet;
                    btnThem.Visible = true;
                    // db.ChiTietNhaps.Remove(query);
                    //dgvXemCt.Rows.RemoveAt(dgvXemCt.CurrentRow.Index);
                    //DanhSoTtDgv(dgvXemCt);
                    //for (int i = 0; i < dgvXemCt.RowCount - 1; i++)
                    //{
                    //    txtTienHangCt.Text =
                    //        (decimal.Parse(txtTienHangCt.Text) + decimal.Parse(dgvXemCt.Rows[i].Cells[4].Value.ToString()))
                    //            .ToString();
                    //}
                    //MessageBox.Show("Xóa dữ liệu thành công!");
                }
            }
        }

        private void sửaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            xemChiTiếtToolStripMenuItem_Click(sender, e);
            btnSuaSua_Click(sender, e);
        }

        private void xemDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cobPhieu.Text = "Phiếu nhập";
            tabKho.SelectedTab = tabPageDahSach;
            cobXemPhieu.Text = "Phiếu nhập";
            var query = from s in db.PhieuNhaps
                        select
                            new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayNhap, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
            dgvDanhSach.DataSource = query.ToList();
            DanhSoTtDgv(dgvDanhSach);
            SetColumnDgvDanhSach();

        }

        private void danhSáchPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cobPhieu.Text = "Phiếu xuất";
            cobXemPhieu.Text = "Phiếu xuất";
            tabKho.SelectedTab = tabPageDahSach;
            var query = from s in db.PhieuXuats
                        select
                        new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayXuat, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
            dgvDanhSach.DataSource = query.ToList();
            DanhSoTtDgv(dgvDanhSach);
            SetColumnDgvDanhSach();
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int ma = int.Parse(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
            if (cobXemPhieu.Text == "Phiếu nhập")
            {
                try
                {
                    var query = db.PhieuNhaps.Where(s => s.MaPhieu == ma).FirstOrDefault();
                    DialogResult result = MessageBox.Show("Việc xóa phiếu nhập sẽ không thể khôi phục lại, bạn có chắc chắn muốn xóa phiếu nhập này không!",
                        "Xóa phiếu nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var detail = db.ChiTietNhaps.Where(s => s.MaPhieu == ma);
                        foreach (var item in detail)
                        {
                            db.ChiTietNhaps.Remove(item);
                        }
                        db.PhieuNhaps.Remove(query);
                        db.SaveChanges();
                        MessageBox.Show("Xóa phiếu nhập thành công!", "Xóa phiếu", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa phiếu nhập!", "Xóa phiếu", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    var query = db.PhieuXuats.Where(s => s.MaPhieu == ma).FirstOrDefault();
                    DialogResult result = MessageBox.Show("Việc xóa phiếu xuất sẽ không thể khôi phục lại, bạn có chắc chắn muốn xóa phiếu nhập này không!",
                        "Xóa phiếu xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var detail = db.ChiTietXuats.Where(s => s.MaPhieu == ma);
                        foreach (var item in detail)
                        {
                            db.ChiTietXuats.Remove(item);
                        }
                        db.PhieuXuats.Remove(query);
                        db.SaveChanges();
                        MessageBox.Show("Xóa phiếu xuất thành công!", "Xóa phiếu", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể xóa phiếu xuất!", "Xóa phiếu", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }
            }
        }

        private void danhSáchPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cobPhieu.Text = "Phiếu nhập";
            tabKho.SelectedTab = tabPageDahSach;
            cobXemPhieu.Text = "Phiếu nhập";
            var query = from s in db.PhieuNhaps
                        select
                            new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayNhap, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
            dgvDanhSach.DataSource = query.ToList();
            DanhSoTtDgv(dgvDanhSach);
            SetColumnDgvDanhSach();
        }

        private void danhSáchPhiếuXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cobPhieu.Text = "Phiếu xuất";
            cobXemPhieu.Text = "Phiếu xuất";
            tabKho.SelectedTab = tabPageDahSach;
            var query = from s in db.PhieuXuats
                        select
                        new { maPhieu = s.MaPhieu, maHienThi = s.MaHienThi, ngayLap = s.NgayXuat, DoiTac = s.DoiTac.TenDoiTac, nhanVien = s.NhanVien.TenNv, tongTien = s.TongTien };
            dgvDanhSach.DataSource = query.ToList();
            DanhSoTtDgv(dgvDanhSach);
            SetColumnDgvDanhSach();
        }

        private void ThemPhieu()
        {
            txtMaHienThi.Text = null;
            txtMaHienThi.ReadOnly = false;
            txtCk.Text = "0";
            txtCk.ReadOnly = false;
            txtVat.Text = "0";
            txtVat.ReadOnly = false;
            txtGhiChu.Text = null;
            txtGhiChu.ReadOnly = false;
            txtMaHienThiCt.Text = "0";
            txtTienHangPhieu.Text = "0";
            txtTienHangChit.Text = "0";
            txtTongTien.Text = "0";
            cobDoiTac.Enabled = true;
            cobNhanVien.Enabled = true;
            dateNgayLap.Enabled = true;
            cobPhieu.Enabled = false;
            dgvXemCt.DataSource = null;
            groupThemMatHang.Visible = true;
            groupMatHang.Visible = true;
            groupThem.Visible = true;
            groupSua.Visible = false;
        }
        private void thêmPhiếuNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabKho.SelectedTab = tabPageThongTin;
            cobPhieu.Text = "Phiếu nhập";
            ThemPhieu();
        }

        private void thêmPhiếuXuấtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabKho.SelectedTab = tabPageThongTin;
            cobPhieu.Text = "Phiếu xuất";
            ThemPhieu();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            labBaoCao.Text = "Báo cáo tháng " + dateBaoCao.Value.Month + " năm " + dateBaoCao.Value.Year;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            txtMaBaoCao.Text = null;
        }

        private string TimBaoCaoThangTruoc(DateTime ngayLap)
        {
            var query = db.BaoCaoThangs.ToList();
            string thang=null;
            string nam = null;
            foreach (var item in query)
            {

                if (ngayLap.Month == 1)
                {
                    thang = "12";
                    nam = (ngayLap.Year - 1).ToString();
                }
                else
                {
                    thang = (ngayLap.Month - 1).ToString();
                }
            }
            string chuoi=nam+thang;
            return chuoi;
        }
        private int TimTongNhap(DateTime thang, int maHang)
        {
            int soLuong = 0;
            var hang =(from s in db.ChiTietNhaps
                where
                    (s.MaHang == maHang && s.PhieuNhap.NgayNhap.Value.Month == thang.Month &&
                     s.PhieuNhap.NgayNhap.Value.Year == thang.Year)
                select new { so=s.SoLuong}).ToList();
            foreach (var item in hang)
            {
                soLuong = soLuong + int.Parse(item.so.ToString());
            }
            return soLuong;
        }
        private int TimTongXuat(DateTime thang, int maHang)
        {
            int soLuong = 0;
            var hang = (from s in db.ChiTietXuats
                        where
                            (s.MaHang == maHang && s.PhieuXuat.NgayXuat.Value.Month == thang.Month &&
                             s.PhieuXuat.NgayXuat.Value.Year == thang.Year)
                        select new { so = s.SoLuong }).ToList();
            foreach (var item in hang)
            {
                soLuong = soLuong + int.Parse(item.so.ToString());
            }
            return soLuong;
        }
        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            BaoCaoThang bc = new BaoCaoThang();
            bc.ThoiGian = "Tháng " +dateThemBc.Value.Month + " năm " + dateThemBc.Value.Year;
            bc.NgayLap = dateThemBc.Value;
            bc.MoTa = txtGhiChuBc.Text;
            bc.MaBaoCao = int.Parse(txtMaBaoCao.Text);
            db.BaoCaoThangs.Add(bc);
            //string thangTruoc=TimBaoCaoThangTruoc(dateThemBc.Value);
            //if(thangTruoc==null)
            //{
                var hang = from s in db.HangHoas select s;
                foreach (var item in hang.ToList())
                {
                    ChiTietBaoCao detail = new ChiTietBaoCao();
                    detail.MaBaoCao = int.Parse(txtMaBaoCao.Text);
                    detail.MaHang = item.MaHang;
                    detail.TonCuoi = item.SoLuong;
                    detail.SlNhap = TimTongNhap(dateThemBc.Value, item.MaHang);
                    detail.SlXuat= TimTongXuat(dateThemBc.Value, item.MaHang);
                    detail.TonCuoi = item.SoLuong-TimTongNhap(dateThemBc.Value, item.MaHang) -
                                     TimTongXuat(dateThemBc.Value, item.MaHang);
                    db.ChiTietBaoCaos.Add(detail);
                }
           // }
            try
            {
                db.SaveChanges();
                var baoCao = from a in db.ChiTietBaoCaos
                    where (a.MaBaoCao == int.Parse(txtMaBaoCao.Text))
                    select
                        new
                        {
                            maHang = a.MaHang,
                            tenHang = a.HangHoa.TenHang,
                            tonDau = a.TonDau,
                            sln = a.SlNhap,
                            slx = a.SlXuat,
                            tonCuoi = a.TonCuoi
                        };
                dgvBaoCao.DataSource = baoCao.ToList();

            }
            catch (Exception)
            {
                MessageBox.Show("KhÔng thể tạo báo cáo này!");
            }
               



        }

        private void txtMaBaoCao_TextChanged(object sender, EventArgs e)
        {
            txtMaBaoCao.KeyPress += new KeyPressEventHandler(txtMaBaoCao_KeyPress);
        }

        private void txtMaBaoCao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dateThemBc_ValueChanged(object sender, EventArgs e)
        {
            txtMaBaoCao.Text = dateThemBc.Value.Year.ToString() + dateThemBc.Value.Month.ToString();
        }

        private void dateNgayLap_ValueChanged(object sender, EventArgs e)
        {
            txtMaHienThi.Text = dateNgayLap.Value.Year.ToString() + dateNgayLap.Value.Month.ToString() + dateNgayLap.Value.Day.ToString();
        }

        private void báoCáoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabKho.SelectedTab = tabPageBaoCao;
        }
    }
}
