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
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void tácVụToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmHangHoa f=new frmHangHoa();
            f.Show();
            this.Hide();
        }

        private void linkKho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cobTk f=new cobTk();
            f.Show();
            this.Hide();
        }

        private void linkBanHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmBanHang f= new frmBanHang();
            f.Show();
            this.Hide();
        }

        private void linkNhanVien_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmNhanVien f=new frmNhanVien();
            f.Show();
            this.Hide();
        }

        private void linkKhachHang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmKhachHang f=new frmKhachHang();
            f.Show();
            this.Hide();
        }

        private void linkDoiTac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDoiTac f=new frmDoiTac();
            f.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
