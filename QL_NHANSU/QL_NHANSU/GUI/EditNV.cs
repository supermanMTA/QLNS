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
    public partial class EditNV : Form
    {
        PhanCong pc = new PhanCong();
        QL_NS context = new QL_NS();
        public EditNV(string a,string b)
        {
            InitializeComponent();
            pc.MaDA = a;
            pc.MaNV = b;
        }
        private void EditNV_Load(object sender, EventArgs e)
        {
            txtMaDA.Enabled = false;
            cbbTenNV.Enabled = false;
            txtMaDA.Text = pc.MaDA;
            cbbTenNV.Text = pc.MaNV;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa nhân viên tham gia dựa án này không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                try
                {
                    pc = context.PhanCongs.Find( pc.MaNV,pc.MaDA);
                    pc.SoGio = txtSogio.Text;
                    context.SaveChanges();
                    MessageBox.Show("Đã sửa");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa thông tin nhân viên tham gia dự án thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }


}
