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
    public partial class frmDoiTac : Form
    {
        public frmDoiTac()
        {
            InitializeComponent();
        }

        BANHANGSIEUTHIEntities db = new BANHANGSIEUTHIEntities();

        #region method
        private void LoadData()
        {
            this.dataGridView1.DataSource = db.DoiTacs.ToList();
            this.dataGridView1.Columns[0].HeaderText = "Mã Đối Tác";
            this.dataGridView1.Columns[1].HeaderText = "Tên Đối Tác";
            this.dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            this.dataGridView1.Columns[3].HeaderText = "SĐT";
            this.dataGridView1.Columns[4].HeaderText = "WebSite";
            this.dataGridView1.Columns[5].HeaderText = "Người Đại Diện";
            this.dataGridView1.Columns[6].HeaderText = "SĐT Người Đại Diện ";
            this.dataGridView1.Columns[7].HeaderText = "Status";
        }

        private void Add()
        {
            try
            {
                DoiTac dt =new DoiTac();
                dt.TenDoiTac = this.textBoxTenDT.Text;
                dt.DiaChi = this.textBoxDiaChi.Text;
                dt.SoDienThoai = this.textBoxSDT.Text;
                dt.Website = this.textBoxWeb.Text;
                dt.NguoiDaiDien = this.textBoxNgDaiDien.Text;
                dt.SdtNguoiDaiDien = this.textBoxSDTNgDD.Text;
                dt.Status = Int32.Parse(textBoxStatus.Text);
                db.DoiTacs.Add(dt);             
                MessageBox.Show("Thêm Thành Công!!!");
            }
            catch
            {
                MessageBox.Show("Thêm Thất bại!!");
            }
        }

        private void Edit()
        {
            int ma = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DoiTac dt    = db.DoiTacs.Single(s => s.MaDoiTac.Equals(ma));
            if (this.textBoxMaDT.Text.Length != 0)
                dt.MaDoiTac = Int32.Parse(textBoxMaDT.Text);
            if (this.textBoxTenDT.Text.Length != 0)
                dt.TenDoiTac = this.textBoxTenDT.Text;
            if (this.textBoxDiaChi.Text.Length != 0)
                dt.DiaChi = this.textBoxDiaChi.Text;
            if (this.textBoxSDT.Text.Length != 0)
                dt.TenDoiTac = this.textBoxTenDT.Text;
            if (this.textBoxWeb.Text.Length != 0)
                dt.Website = this.textBoxWeb.Text;
            if (this.textBoxNgDaiDien.Text.Length != 0)
                dt.NguoiDaiDien = this.textBoxNgDaiDien.Text;
            if (this.textBoxSDTNgDD.Text.Length != 0)
                dt.SdtNguoiDaiDien = this.textBoxSDTNgDD.Text;
            if (this.textBoxStatus.Text.Length != 0)
                dt.Status = Int32.Parse(textBoxStatus.Text);

        }

        private void Del()
        {
            int ma = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Confirm", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    DoiTac dt = db.DoiTacs.Single(s => s.MaDoiTac.Equals(ma));
                    db.DoiTacs.Remove(dt);
                    db.SaveChanges();                  
                    MessageBox.Show("Đã xóa!");
                }
                catch
                {
                    MessageBox.Show("Xóa Thất bại!!");
                }
            }
        }

        private void Search()
        {

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

        private void btn_showDT_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_ThemDT_Click(object sender, EventArgs e)
        {
            Add();
            LoadData();
        }

        

        private void btn_XoaDT_Click(object sender, EventArgs e)
        {
            Del();
            LoadData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            LoadData();
        }

        private void btn_SuaDT_Click(object sender, EventArgs e)
        {
            Edit();
            LoadData();
        }

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ma =int.Parse( this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DoiTac dt = db.DoiTacs.Single(s => s.MaDoiTac.Equals(ma));
            textBoxMaDT.Text = dt.MaDoiTac.ToString();
            textBoxTenDT.Text = dt.TenDoiTac.ToString();
            textBoxDiaChi.Text = dt.DiaChi.ToString();
            textBoxSDT.Text = dt.SoDienThoai.ToString();
            textBoxWeb.Text = dt.Website.ToString();
            textBoxNgDaiDien.Text = dt.NguoiDaiDien.ToString();
            textBoxSDTNgDD.Text = dt.SdtNguoiDaiDien.ToString();
            textBoxStatus.Text = dt.Status.ToString();
        }
    }
}
