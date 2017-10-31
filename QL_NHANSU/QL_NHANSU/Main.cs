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
using QL_NHANSU.GUI;
namespace QL_NHANSU
{
    public partial class Main : Form
    {
        bool b = false;
        public Main(bool a)
        {
            InitializeComponent();
            b = a;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            
            if (b == true)
            {
                FormQl.Enabled = true;
                btnDangxuat.Enabled = true;
                btnLogin.Enabled = false;
            }
        }
        private void NhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            NV nv = new NV();
            panelMain.Controls.Clear();
   
            nv.Dock = DockStyle.Fill;
            panelMain.Controls.Add(nv);
            nv.Show();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
            PB pb = new PB();
            panelMain.Controls.Clear();
            
            pb.Dock = DockStyle.Fill;
            panelMain.Controls.Add(pb);
            pb.Show();
        } 
        private void dựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            DA da = new DA();
            panelMain.Controls.Clear();
        
            da.Dock = DockStyle.Fill;
            panelMain.Controls.Add(da);
            da.Show();
        }       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
          
            lg.ShowDialog();
            this.Hide();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            Dangky Dk = new Dangky();
            Dk.ShowDialog();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn đăng xuất", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {
                this.Hide();
               
            }
            else { return; }
        }

        
       
    }
}
