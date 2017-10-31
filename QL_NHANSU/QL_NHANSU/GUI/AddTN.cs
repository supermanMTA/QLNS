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
    public partial class AddTN : Form
    {
        QL_NS context = new QL_NS();
        ThanNhan tn=new ThanNhan();
        public AddTN( string a)
        {
            InitializeComponent();
            tn.MaNV = a;
        }

        private void THANNHAN_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = tn.MaNV;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tn.TenTN = txtTenTN.Text;
            tn.NgaySinh = dateTimePicker1.Value;
            tn.QuanHe = txtQH.Text;

            if (txtTenTN.Text == ""|| txtQH.Text=="" )
            {
                MessageBox.Show("Nhập đủ thông tin ");
            }
            else
            {
                
                 DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm thân nhân này không?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == dr)
                    {
                        try
                        {
                            context.ThanNhans.Add(tn);
                            context.SaveChanges();
                            MessageBox.Show("Thêm thân nhân thành công");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thêm Thân nhân thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
