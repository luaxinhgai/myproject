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
    public partial class frmNhanVien : Form
    {
        BANHANGSIEUTHIEntities db=new BANHANGSIEUTHIEntities();
        public frmNhanVien()
        {
            InitializeComponent();
        }

        DataGridView dt;
        public frmNhanVien(DataGridView dgv_nhanvien)
        {
            InitializeComponent();
            dgv_nhanvien = dt;
        }

        //load dữ liệu lên form

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            load();
            
        }
        public void load() {
            cmb_gioitinh.Items.Clear();
            cmb_gioitinh.Items.Add("Nam");
            cmb_gioitinh.Items.Add("Nữ");

       //     cmb_chucvu.Items.Clear();
            var list1 = (from s in db.ChucVus select s.ChucVu1).ToList();
            cmb_chucvu.DataSource = list1;
            cmb_chucvu.DisplayMember = "ChucVu1";
            //var list = (from s in db.NhanViens select s).ToList();
            //dgv_nhanvien.DataSource = list;

            this.dgv_nhanvien.DataSource = db.NhanViens.Where(s=>s.Status==null).Select(db => new
            {
                ID = db.MaNv,
                Name = db.TenNv,
                Birthday = db.NgaySinh,
                Gender = db.GioiTinh == true ? "Nam" : "Nữ",
                Add = db.DiaChi,
                Anh = db.anh,
                Chucvu = db.MaChucVu,
                Tendn = db.TenDangNhap,
                Pass = db.MatKhau
            }).ToList();
            dgv_nhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgv_nhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgv_nhanvien.Columns[2].HeaderText = "Ngày sinh";
            dgv_nhanvien.Columns[3].HeaderText = "Giới Tính";
            dgv_nhanvien.Columns[4].HeaderText = "Địa chỉ";
            dgv_nhanvien.Columns[5].HeaderText = "Ảnh";
            dgv_nhanvien.Columns[6].HeaderText = "Chức vụ";
        }
       

        private void dgv_nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgv_nhanvien.CurrentRow.Cells[0].Value.ToString());
            NhanVien nv = db.NhanViens.SingleOrDefault(s=>s.MaNv==id);
            txt_manv.Text = nv.MaNv.ToString();
            txt_hoten.Text = nv.TenNv;
            txt_diachi.Text = nv.DiaChi;
            if (nv.GioiTinh.Value == false)
            {
                cmb_gioitinh.Text = "Nữ";
            }
            else
            {
                cmb_gioitinh.Text = "Nam";
            }
            dtk_ngaysinh.Text = nv.NgaySinh.ToString();
         
try
            {
                string path = nv.anh.ToString();

                if (!string.IsNullOrWhiteSpace(path))
                {
                    MemoryStream ms = new MemoryStream((byte[])dgv_nhanvien.CurrentRow.Cells[5].Value);
                    ptb_anh.Image = Image.FromStream(ms);

                }
            }
            catch(Exception)
            {
                ptb_anh.Image = null;
            }
            var chucvu = from s in db.ChucVus where s.MaChucVu == nv.MaChucVu select s.ChucVu1;
            cmb_chucvu.Text = chucvu.FirstOrDefault();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv_nhanvien.CurrentRow.Cells[0].Value.ToString());
            Sua_NV fr = new Sua_NV(id);
            fr.Show(this);
            Hide();

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            
            frm_themnv fr = new frm_themnv();
            fr.Show();
            Hide();
        }

        private void txt_timkiem_KeyUp(object sender, KeyEventArgs e)
        {
           
            var Lst = (from s in db.NhanViens where s.TenNv.Contains(txt_timkiem.Text) select s).ToList();
            dgv_nhanvien.DataSource = Lst;
            txt_manv.DataBindings.Clear();
            txt_hoten.DataBindings.Clear();
           
            txt_manv.DataBindings.Add("text", Lst, "MaNv");
            txt_hoten.DataBindings.Add("text", Lst, "TenNv");
          
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            frmTrangChu fr = new frmTrangChu();
            fr.Show();
            Hide();
        }
      
 private byte[] convertFilToBytes(string spath)
        {

            byte[] data = null;
            FileInfo finfo = new FileInfo(spath);
            long numBytes = finfo.Length;
            FileStream fs = new FileStream(spath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            data = br.ReadBytes((int)numBytes);
            return data;

            //{
            //    FileStream fs;
            //    fs = new FileStream(txt_anh.Text, FileMode.Open, FileAccess.Read);

            //    byte[] picbyte = new byte[fs.Length];
            //    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            //    fs.Close();
            //    return picbyte;

        }

    

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_nhanvien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cần chọn dữ liệu để xóa!", "Thông báo");
                return;
            }
            DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.OK)
            {
                //     int ma = int.Parse(txt_manv.Text);
                //    var nv = db.NhanViens.FirstOrDefault(x => x.MaNv == ma);
            
               int id = int.Parse(dgv_nhanvien.CurrentRow.Cells[0].Value.ToString());
            //    QLNhanSuEntities1 nv2 = new QLNhanSuEntities1();
                // phongban pb = new phongban();
               NhanVien  nv = db.NhanViens.Single(s => s.MaNv == id);
                nv.Status = 0;
                db.SaveChanges();
                load();
            }
            
        }

    }
}
