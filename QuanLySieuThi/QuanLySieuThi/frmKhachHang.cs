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

namespace QuanLySieuThi
{
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        BANHANGSIEUTHIEntities1 db = new BANHANGSIEUTHIEntities1();
        #region method
        void LoadKh()
        {
            this.dataGridView1.DataSource = db.KhachHangs.ToList();
        }
        void AddKh()
        {
            try
            {
                KhachHang dt = new KhachHang();
                dt.MaKh = Int32.Parse(textBoxMaKh.Text);
                dt.TenKh = this.textBoxTenKh.Text;
                dt.SoDienThoai = this.textBoxSDTKH.Text;
                dt.DiaChi = this.textBoxDiaChiKH.Text;
                dt.Status = Int32.Parse(textBoxStatus.Text);
                db.KhachHangs.Add(dt);
                MessageBox.Show("Thêm Thành Công!!!");
            }
            catch
            {
                MessageBox.Show("Thêm Thất bại!!");
            }
        }
        void Save()
        {
            DialogResult dlr = MessageBox.Show("Lưu tất cả thay đổi?",
                            "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                db.SaveChanges();
            }

        }
        void EditKH()
        {
            int ma = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            KhachHang dt = db.KhachHangs.Single(s => s.MaKh.Equals(ma));
            if (this.textBoxMaKh.Text.Length != 0)
                dt.MaKh = Int32.Parse(textBoxMaKh.Text);
            if (this.textBoxTenKh.Text.Length != 0)
                dt.TenKh = this.textBoxTenKh.Text;
            if (this.textBoxDiaChiKH.Text.Length != 0)
                dt.DiaChi = this.textBoxDiaChiKH.Text;
            if (this.textBoxSDTKH.Text.Length != 0)
                dt.SoDienThoai = this.textBoxSDTKH.Text;
            if (this.textBoxStatus.Text.Length != 0)
                dt.Status = Int32.Parse(textBoxStatus.Text);
            db.SaveChanges();
            LoadKh();
        }

        void DelKH()
        {
            int ma = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    KhachHang dt = db.KhachHangs.Single(s => s.MaKh.Equals(ma));
                    db.KhachHangs.Remove(dt);
                    db.SaveChanges();
                    MessageBox.Show("Đã xóa!");
                }
                catch
                {
                    MessageBox.Show("Xóa Thất bại!!");
                }
            }
        }

        #endregion

        private void btn_showKH_Click(object sender, EventArgs e)
        {
            LoadKh();
        }

        private void btn_ThemKh_Click(object sender, EventArgs e)
        {
            AddKh();
            LoadKh();
        }

        private void btn_SuaDT_Click(object sender, EventArgs e)
        {
            EditKH();
        }

        private void btn_XoaDT_Click(object sender, EventArgs e)
        {
            DelKH();
            LoadKh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaKh.Text = dataGridView1.CurrentRow.Cells["MaKh"].Value.ToString() + " ";
            textBoxTenKh.Text = dataGridView1.CurrentRow.Cells["TenKh"].Value.ToString() + " ";
            textBoxDiaChiKH.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString() + " ";
            textBoxSDTKH.Text = dataGridView1.CurrentRow.Cells["SoDienThoai"].Value.ToString() + " ";
            textBoxStatus.Text = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
        }
    }
}
