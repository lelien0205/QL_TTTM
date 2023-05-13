using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCH_ThucPham
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((this.textBox1.Text =="") || (this.textBox2.Text ==""))
            {
                MessageBox.Show("Vui lòng nhập thông tin","Thông báo");
            }
            else
            {
                if ((this.textBox1.Text == "nhom7") || (this.textBox2.Text == "12345"))
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo");
                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập thông tin", "Thông báo");
                    this.Close();
                }
            }
        }
    }
}
