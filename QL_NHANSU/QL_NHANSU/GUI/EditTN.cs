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
    public partial class EditTN : Form
    {
        QL_NS context = new QL_NS();
        ThanNhan tn = new ThanNhan();
        public EditTN( string a,string b)
        {
            InitializeComponent();
            tn.MaNV = a;
            tn.TenTN = b;
        }

        private void EditTN_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            txtTenTN.Enabled = false;
            txtMaNV.Text = tn.MaNV;
            txtTenTN.Text = tn.TenTN;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa thân nhân này không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dr)
                {
                    try
                    {
                        tn = context.ThanNhans.Find(tn.MaNV, tn.TenTN);
                     
                        tn.NgaySinh = dateTimePicker1.Value;
                        tn.QuanHe = txtQH.Text;
              
                        context.SaveChanges();
                        MessageBox.Show("Đã sửa");
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa Thân nhân thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
