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
    public partial class frm_themnv : Form
    {
        BANHANGSIEUTHIEntities db = new BANHANGSIEUTHIEntities();
        public frm_themnv()
        {
            InitializeComponent();
        }

        private void frm_themnv_Load(object sender, EventArgs e)
        {
            cmb_gioitinh.Items.Clear();
            cmb_gioitinh.Items.Add("Nam");
            cmb_gioitinh.Items.Add("Nữ");

            cmb_chucvu.Items.Clear();
            var list1 = (from s in db.ChucVus select s.ChucVu1).ToList();
            cmb_chucvu.DataSource = list1;
            cmb_chucvu.DisplayMember = "ChucVu1";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            BANHANGSIEUTHIEntities db = new BANHANGSIEUTHIEntities();
            NhanVien nv = new NhanVien();
         //    nv.MaNv = int.Parse(txt_manv.Text);
        //  nv = db.NhanViens.Single(s=>s.MaNv==int.Parse(txt_manv.Text));
            nv.TenNv = txt_hoten.Text;
            Boolean gioiTinh = false;
            if (cmb_gioitinh.Text == "Nam")
            {
                gioiTinh = true;
            }
            nv.GioiTinh = gioiTinh;
            nv.DiaChi = txt_diachi.Text;
            nv.NgaySinh = DateTime.Parse(dtk_ngaysinh.Text);
            nv.TenDangNhap = txt_tendn.Text;
            nv.MatKhau = txt_pass.Text;
            MemoryStream str1 = new MemoryStream();
            ptb_anh.Image.Save(str1, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] pic = str1.ToArray();
            nv.anh = pic;
            db.NhanViens.Add(nv);
           try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show("hhh"+ex);
            }
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

        private void grb_thongtinnhanvien_Enter(object sender, EventArgs e)
        {

        }
    }
}

