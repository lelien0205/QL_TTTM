using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLCH_ThucPham.Class;

namespace QLCH_ThucPham
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Functions.Disconnect();
            Application.Exit();
        }

        private void mnuPhanLoai_Click(object sender, EventArgs e)
        {
            frmDMPhanloai frm = new frmDMPhanloai();
            frm.ShowDialog();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            frmDMHang frm = new frmDMHang();
            //frm.MdiParent = this; // mo duoc nhieu tab do
            frm.ShowDialog();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            frmDMNhanvien frm = new frmDMNhanvien();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            frmDMKhachHang frm = new frmDMKhachHang();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            //frmHoaDonban frm = new frmHoaDonban();
            ////frm.MdiParent = this;
            //frm.ShowDialog();
        }

        private void mnuDanhMuc_Click(object sender, EventArgs e)
        {
           
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDangNhap frm = new frmDangNhap();
            //frm.ShowDialog();
        }

        private void theoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmTiemKiemHD frm = new frmTiemKiemHD();
            //frm.ShowDialog();
        }

        private void lậpĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmDMKhachHang frm = new frmDMKhachHang(); 
            //frm.ShowDialog();
        }

        private void quảnLýNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMHang frm = new frmDMHang();
            //frm.MdiParent = this; // mo duoc nhieu tab do
            frm.ShowDialog();
        }

        private void quảnLýBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDonban frm = new frmHoaDonban();
            //frm.MdiParent = this;
            frm.ShowDialog();
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiemKiemHD frm = new frmTiemKiemHD();
            frm.ShowDialog();
        }
    }
}
