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
using System.IO;

namespace QuanLySieuThi.View
{

    public partial class Sua_NV : Form
    {
        BANHANGSIEUTHIEntities db = new BANHANGSIEUTHIEntities();
        private string path;
        public Sua_NV(int id)
        {
            InitializeComponent();

            NhanVien nv = db.NhanViens.Single(s => s.MaNv == id);
            try
            {

                string path = nv.anh.ToString();
                if (!string.IsNullOrWhiteSpace(path))
                {
                    MemoryStream ms = new MemoryStream((byte[])nv.anh);
                    ptb_anh.Image = Image.FromStream(ms);

                }
            }
            catch
            {
                ptb_anh.Image = null;
            }

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
            var chucvu = from s in db.ChucVus where s.MaChucVu == nv.MaChucVu select s.ChucVu1;

            cmb_chucvu.Text = chucvu.FirstOrDefault();
        }
        public void load()
        {
            cmb_gioitinh.Items.Clear();
            cmb_gioitinh.Items.Add("Nam");
            cmb_gioitinh.Items.Add("Nữ");
            cmb_chucvu.Items.Clear();

            var list = (from s in db.ChucVus select s.ChucVu1).ToList();
            cmb_chucvu.DisplayMember = "ChucVu1";
            cmb_chucvu.DataSource = list;
          
        }
        private void Sua_NV_Load(object sender, EventArgs e)
        {
            load();
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            
            int ma = Int32.Parse(txt_manv.Text);
            var nv = db.NhanViens.FirstOrDefault(x=>x.MaNv == ma);
            var cv = db.ChucVus.FirstOrDefault(s => s.MaChucVu == nv.MaChucVu);
            nv.MaNv = int.Parse(txt_manv.Text);
            nv.TenNv = txt_hoten.Text;
   
            Boolean gioiTinh = false;
            if (cmb_gioitinh.Text == "Nam")
            {
                gioiTinh = true;
            }
            nv.GioiTinh = gioiTinh;
            nv.DiaChi = txt_diachi.Text;
            nv.NgaySinh = DateTime.Parse(dtk_ngaysinh.Text);
            cv.ChucVu1 = cmb_chucvu.Text;
            try {
                MemoryStream str1 = new MemoryStream();
                ptb_anh.Image.Save(str1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = str1.ToArray();
                nv.anh = pic;
            }
            catch
            {
                nv.anh = null;

            }
            
            db.SaveChanges();

            frmNhanVien fr = new frmNhanVien();
            fr.Show(this);
            Hide();
            fr.load();
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
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            frmNhanVien fr = new frmNhanVien();
            fr.Show();
            Hide();
        }

        private void btn_brown_Click(object sender, EventArgs e)
        {

            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = openfile.Filter = "JPG file(*.jpg)|*.jpg|All files (*.*)|*.*";
            openfile.FilterIndex = 1;
            openfile.RestoreDirectory = true;
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                ptb_anh.ImageLocation = openfile.FileName;

            }
        
    }
    }
}
