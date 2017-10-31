using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_NHANSU.Data;
namespace QL_NHANSU.GUI
{
    public partial class AddNV : Form
    {
        PhanCong pc = new PhanCong();
        QL_NS context = new QL_NS();
        public AddNV(string a)
        {
            InitializeComponent();
            pc.MaDA = a;
        }
        private void LoadControl()
        {
            cbbTenNV.DataSource = context.NhanViens.ToList();
            cbbTenNV.ValueMember = "MaNV";
            cbbTenNV.DisplayMember = "TenNV";
        }
        private void AddNV_Load(object sender, EventArgs e)
        {
            txtMaDA.Text = pc.MaDA;
            LoadControl();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pc.MaNV = cbbTenNV.SelectedValue.ToString();
            pc.SoGio = txtSogio.Text;
            if (txtSogio.Text == "")
            {
                MessageBox.Show("Nhập so gio cua nhan vien");
            }
            else
            {

                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm nhân viên này vào dự án không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    try
                    {
                        context.PhanCongs.Add(pc);
                        context.SaveChanges();
                        MessageBox.Show("Thêm nhân viên vào dự án thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm nhân viên vào dự án thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
