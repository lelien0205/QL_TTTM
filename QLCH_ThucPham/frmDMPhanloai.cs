using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLCH_ThucPham.Class;

namespace QLCH_ThucPham
{
    public partial class frmDMPhanloai : Form
    {
        DataTable tblPL;
        public frmDMPhanloai()
        {
            InitializeComponent();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaPhanloai, TenPhanloai FROM tblPhanLoai";
            tblPL = Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvPhanLoai.DataSource = tblPL; //Nguồn dữ liệu            
            dgvPhanLoai.Columns[0].HeaderText = "Mã phân loại";
            dgvPhanLoai.Columns[1].HeaderText = "Tên phân loại";
            dgvPhanLoai.Columns[0].Width = 100;
            dgvPhanLoai.Columns[1].Width = 300;
            dgvPhanLoai.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvPhanLoai.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
        private void dgvPhanLoai_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Focus();
                return;
            }
            if (tblPL.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLoai.Text = dgvPhanLoai.CurrentRow.Cells["MaPhanloai"].Value.ToString();
            txtTenPhanLoai.Text = dgvPhanLoai.CurrentRow.Cells["TenPhanloai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaLoai.Enabled = true; //cho phép nhập mới
            txtMaLoai.Focus();
        }

        private void ResetValue()
        {
            txtMaLoai.Text = "";
            txtTenPhanLoai.Text = "";
        }

        private void frmDMPhanloai_Load(object sender, EventArgs e)
        {
            txtMaLoai.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            LoadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaLoai.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã phân loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoai.Focus();
                return;
            }
            if (txtTenPhanLoai.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên phân loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPhanLoai.Focus();
                return;
            }
            sql = "Select MaPhanloai From tblPhanLoai where MaPhanloai=N'" + txtMaLoai.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã phân loại này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoai.Focus();
                return;
            }

            sql = "INSERT INTO tblPhanLoai VALUES(N'" +
                txtMaLoai.Text + "',N'" + txtTenPhanLoai.Text + "')";
            Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLoai.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblPL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoai.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenPhanLoai.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên phân loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblPhanLoai SET TenPhanloai=N'" +
                txtTenPhanLoai.Text.ToString() +
                "' WHERE MaPhanloai=N'" + txtMaLoai.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblPL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoai.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblPhanLoai WHERE MaPhanloai=N'" + txtMaLoai.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView(); // nap lai du lieu 
                ResetValue();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaLoai.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaLoai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtTenPhanLoai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtMaLoai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
