using QuanLySieuThi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySieuThi.View
{
    public partial class frmHangHoa : Form
    {
        BANHANGSIEUTHIEntities db = new BANHANGSIEUTHIEntities();

        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            FillData();
        }

        public void FillData()
        {
            cmbMaloai.DataSource = db.LoaiHangs.ToList();
            cmbMaloai.ValueMember = "MaLoai";
            cmbMaloai.DisplayMember = "DienGiai";

            cmbDonvitinh.Items.Clear();
            cmbDonvitinh.Items.Add("Bao");
            cmbDonvitinh.Items.Add("Hộp");
            cmbDonvitinh.Items.Add("Gói");
            cmbDonvitinh.Items.Add("Túi");
            cmbDonvitinh.Items.Add("Vỉ");
            cmbDonvitinh.Items.Add("Cái");

            dgvHanghoa.DataSource = db.HangHoas.Select(d => new {
                Maloai = d.MaLoai,
                Mahang = d.MaHang,
                Tenhang = d.TenHang,
                Donvitinh = d.DonViTinh,
                TenNSX = d.TenNhaSanXuat,
                Giasi = d.GiaSi,
                Giaban = d.Gia,
                Trangthai = d.Status,
                Ngaysanxuat = d.NgaySx,
                Hansudung = d.HanSd,
                Soluong = d.SoLuong
            }).ToList();
            this.dgvHanghoa.Columns[0].HeaderText = "Mã Hàng";
            this.dgvHanghoa.Columns[1].HeaderText = "Mã loại";
            this.dgvHanghoa.Columns[2].HeaderText = "Tên Hàng";
            this.dgvHanghoa.Columns[3].HeaderText = "Đơn Vị Tính";
            this.dgvHanghoa.Columns[4].HeaderText = "Tên Nhà Xuất Bản";
            this.dgvHanghoa.Columns[5].HeaderText = "Giá Sỉ";
            this.dgvHanghoa.Columns[6].HeaderText = "Giá bán";
            this.dgvHanghoa.Columns[7].HeaderText = "Trạng Thái";
            this.dgvHanghoa.Columns[8].HeaderText = "Ngày Sản Xuất";
            this.dgvHanghoa.Columns[9].HeaderText = "Hạn Sử Dụng";
            this.dgvHanghoa.Columns[10].HeaderText = "Số Lượng";
        }

        private void dgvHanghoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int maHang = int.Parse(this.dgvHanghoa.CurrentRow.Cells[1].Value.ToString());
                var h = db.HangHoas.Where(s => s.MaHang == maHang).FirstOrDefault();
                cmbMaloai.SelectedItem = h.MaLoai;
                txtMahang.Text = h.MaHang.ToString();
                txtTenhang.Text = h.TenHang;
                cmbDonvitinh.Text = h.DonViTinh;
                txtTennhasanxuat.Text = h.TenNhaSanXuat;
               txtGiasi.Text = h.GiaSi.ToString();
                txtGiaban.Text = h.Gia.ToString();
                txtTrangthai.Text = h.Status.ToString();
                dtpNgaysanxuat.Text = h.NgaySx.ToString();
                dtpHansudung.Text = h.HanSd.ToString();
                txtSoluong.Text = h.SoLuong.ToString();
            }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                HangHoa h = new HangHoa();
                // h.MaHang = Int32.Parse(txtMahang.Text);
                h.MaLoai = Int32.Parse(cmbMaloai.SelectedValue.ToString());
                h.TenHang = this.txtTenhang.Text;
                h.DonViTinh = this.cmbDonvitinh.Text;
                h.TenNhaSanXuat = this.txtTennhasanxuat.Text;
                h.GiaSi = decimal.Parse(txtGiasi.Text);
                h.Gia = decimal.Parse(txtGiaban.Text);
                h.Status = 1;
                h.NgaySx = DateTime.Parse(dtpNgaysanxuat.Text);
                h.HanSd = DateTime.Parse(dtpHansudung.Text);
                h.SoLuong = Int32.Parse(txtSoluong.Text);
                db.HangHoas.Add(h);
                db.SaveChanges();
                FillData();

            }
            catch
            {
                MessageBox.Show("Insert fail!!");
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int ma = int.Parse(this.dgvHanghoa.CurrentRow.Cells[1].Value.ToString());
                HangHoa h = db.HangHoas.Where(s => s.MaHang == ma).FirstOrDefault();
                //if (this.txtMahang.Text.Length != 0)
                //    h.MaHang = Int32.Parse(txtMahang.Text);
                cmbMaloai.SelectedItem = h.MaLoai;
                if (this.txtTenhang.Text.Length != 0)
                    h.TenHang = this.txtTenhang.Text;
                h.DonViTinh = this.cmbDonvitinh.Text;
                if (this.txtTennhasanxuat.Text.Length != 0)
                    h.TenNhaSanXuat = this.txtTennhasanxuat.Text;
                if (this.txtGiasi.Text.Length != 0)
                    h.GiaSi = decimal.Parse(txtGiasi.Text);
                if (this.txtGiaban.Text.Length != 0)
                    h.Gia = decimal.Parse(txtGiaban.Text);
                if (this.txtTrangthai.Text.Length != 0)
                    h.Status = Int32.Parse(txtTrangthai.Text);
                if (this.dtpNgaysanxuat.Text.Length != 0)
                    h.NgaySx = DateTime.Parse(dtpNgaysanxuat.Text);
                if (this.dtpHansudung.Text.Length != 0)
                    h.HanSd = DateTime.Parse(dtpHansudung.Text);
                if (this.txtSoluong.Text.Length != 0)
                    h.SoLuong = Int32.Parse(txtSoluong.Text);
                db.SaveChanges();
                FillData();
            }
            catch
            {
                MessageBox.Show("Fix fail!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            DialogResult dr = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int ma = int.Parse(this.dgvHanghoa.CurrentRow.Cells[1].Value.ToString());
                    HangHoa h = db.HangHoas.Single(s => s.MaHang.Equals(ma));
                    db.HangHoas.Remove(h);
                    db.SaveChanges();
                    FillData();
                }
                catch
                {
                    MessageBox.Show("Delete fail!!");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmTrangChu f = new frmTrangChu();
            f.Show();
            this.Hide();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            BANHANGSIEUTHIEntities db = new BANHANGSIEUTHIEntities();
            var Lst = (from s in db.HangHoas where s.TenHang.Contains(txtTimkiem.Text) select s).ToList();
            dgvHanghoa.DataSource = Lst;
            txtMahang.DataBindings.Clear();
            cmbMaloai.DataBindings.Clear();
            txtTenhang.DataBindings.Clear();
            txtTennhasanxuat.DataBindings.Clear();
            txtTrangthai.DataBindings.Clear();
            txtMahang.DataBindings.Add("text", Lst, "MaHang");
            cmbMaloai.DataBindings.Add("text", Lst, "MaLoai");
            txtTenhang.DataBindings.Add("text", Lst, "TenHang");
            txtTennhasanxuat.DataBindings.Add("text", Lst, "TenNhaSanXuat");
            txtTrangthai.DataBindings.Add("text", Lst, "Status");

        }


    }
}
