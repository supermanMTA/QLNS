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
    public partial class Dangky : Form
    {
        QL_NS context=new QL_NS();
        NguoiDung nd = new NguoiDung();
        public Dangky()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
                return;
            }
            else {
                var list=context.NguoiDungs.Where(p=>p.ID==txtname.Text&&p.pass==txtpass.Text).ToList().FirstOrDefault();
                if(list!=null){
                    MessageBox.Show("Tài khoản đã tồn tại");
                }
                else{
                    nd.ID=txtname.Text;
                    nd.pass=txtpass.Text;
                    context.NguoiDungs.Add(nd);
                    context.SaveChanges();
                        MessageBox.Show("Đã Thêm");
                        this.Hide();
                        Main fr = new Main(true);
                        fr.ShowDialog();
                }
              }
            }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpass.Clear();
            
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main fr = new Main(false);
            fr.ShowDialog();
        }

            
        }
    
}
