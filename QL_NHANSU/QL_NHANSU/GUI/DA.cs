using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_NHANSU.Data;
namespace QL_NHANSU.GUI
{
    public partial class DA : UserControl
    {
        QL_NS context = new QL_NS();
        DuAn da = new DuAn();
        bool ok = true;
        public DA()
        {
            InitializeComponent();
        }
        #region Load
        private void LoadControl()
        {
            cbbMaPB.DataSource = context.PhongBans.ToList();
            cbbMaPB.ValueMember = "MaPB";
            cbbMaPB.DisplayMember = "TenPB";
         } 
        private void LoaddgvDuAn()
        {
           
            var da = from p in context.DuAns
                     select new
                     {
                         //STT = i++,
                         MaDuAn = p.MaDA,
                         TenDuAn = p.TenDA,
                         TenPBPhuTrach = context.PhongBans.Where(z => z.MaPB == p.MaPB).FirstOrDefault().TenPB,
                         TongSoGio=p.tongsogio,
                         DiaDiem=p.DiaDiem
                     };
            dgvDuAn.DataSource = da.ToList();
        }
        private void LoadNV()
        {
            string mada = dgvDuAn.CurrentRow.Cells["MaDuAn"].Value.ToString();
            int i = 0;
            var ListTN = context.PhanCongs.Where(p => p.MaDA == mada).ToList()
                                 .Select(p => new
                                 {
                                     STT = ++i,
                                     MaNV = p.MaNV,
                                     TenNV = context.NhanViens.Where(z => z.MaNV == p.MaNV).FirstOrDefault().TenNV,
                                     SoGio=p.SoGio
                                 })
                                 .ToList();
            dgvDANV.DataSource = ListTN;
        }
        private void DA_Load(object sender, EventArgs e)
         {
            LoadControl();
            LoaddgvDuAn(); 
         }
        #endregion
        #region Lấy and ktr dữ liệu
        private void settingDA()
        {
            da.MaDA = txtMaDA.Text;
            da.TenDA = txtTenDA.Text;
            da.tongsogio = txtsogio.Text;
            da.MaPB = cbbMaPB.SelectedValue.ToString();
            da.DiaDiem = txtDD.Text;
        }
        private bool check()
        {
            if (txtMaDA.Text == "") { MessageBox.Show("Mã dự án còn trống"); return false; }
            if (txtTenDA.Text == "") { MessageBox.Show("Tên dự án còn trống"); return false; }
            
            return true;
        }
        #endregion
        #region sự kiện of dự án
        private void dgvDuAn_SelectionChanged(object sender, EventArgs e)
        {
            txtDD.Text = dgvDuAn.CurrentRow.Cells["DiaDiem"].Value.ToString();
            txtMaDA.Text = dgvDuAn.CurrentRow.Cells["MaDuAn"].Value.ToString();
            cbbMaPB.Text = dgvDuAn.CurrentRow.Cells["TenPBPhuTrach"].Value.ToString();
            txtsogio.Text = dgvDuAn.CurrentRow.Cells["TongSoGio"].Value.ToString();
            txtTenDA.Text = dgvDuAn.CurrentRow.Cells["TenDuAn"].Value.ToString();
            LoadNV();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mã dự án")
            {
                var da = from p in context.DuAns.Where(p=>p.MaDA==txtKey.Text)
                         select new
                         {
                             //STT = i++,
                             MaDuAn = p.MaDA,
                             TenDuAn = p.TenDA,
                             TenPBPhuTrach = context.PhongBans.Where(z => z.MaPB == p.MaPB).FirstOrDefault().TenPB,
                             TongSoGio = p.tongsogio,
                             DiaDiem = p.DiaDiem
                         };
               
                if (da == null) MessageBox.Show("Không tìm thấy");
                else dgvDuAn.DataSource = da.ToList();
            }
            else if (comboBox1.Text == "Tên dự án")
            {
                var da = from p in context.DuAns.Where(p => p.TenDA == txtKey.Text)
                         select new
                         {
                             //STT = i++,
                             MaDuAn = p.MaDA,
                             TenDuAn = p.TenDA,
                             TenPBPhuTrach = context.PhongBans.Where(z => z.MaPB == p.MaPB).FirstOrDefault().TenPB,
                             TongSoGio = p.tongsogio,
                             DiaDiem = p.DiaDiem
                         };

                if (da == null) MessageBox.Show("Không tìm thấy");
                else dgvDuAn.DataSource = da.ToList();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaDA.Clear();
            txtsogio.Clear();
            txtTenDA.Clear();
            txtsogio.Clear();
            txtDD.Clear();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            ok = true;
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {           
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            ok = false;
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (ok)
            {
                if (check())
                {
                    try
                    {
                        settingDA();
                        context.DuAns.Add(da);
                        context.SaveChanges();
                        MessageBox.Show("Thêm dự án thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaddgvDuAn();
                        btnThem.Enabled = true;
                        btnXoa.Enabled = true;
                        btnSua.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm dự án thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (txtMaDA.Text == "") MessageBox.Show("Chưa có dự án nào được chọn");
                else
                {
                    txtMaDA.Enabled = false;
                    if (check())
                    {
                        try
                        {
                            da = context.DuAns.Where(p => p.MaDA == txtMaDA.Text).FirstOrDefault();
                            settingDA();
                            context.SaveChanges();
                            MessageBox.Show("Sửa thông tin dự án thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoaddgvDuAn();
                            btnThem.Enabled = true;
                            btnXoa.Enabled = true;
                            btnSua.Enabled = true;
                            btnLuu.Enabled = false;
                            btnHuy.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Sửa thông tin dự án thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    txtMaDA.Enabled = true;
                }
            }
            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDA.Text == "")
            {
                MessageBox.Show("chọn dựa án muốn xóa");
            }
            else
            {
                if (check())
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa dự án này không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (DialogResult.Yes == dr)
                    {
                        try
                        {
                            da = context.DuAns.Find(txtMaDA.Text);
                            if (da == null) MessageBox.Show("Không tồn tại phòng ban này");
                            var listNV = from ctn in context.PhanCongs.ToList()
                                         from p in context.DuAns.Where(p => p.MaDA == ctn.MaDA).ToList()
                                         select ctn;
                            context.PhanCongs.RemoveRange(listNV);
                            context.SaveChanges();

                            context.DuAns.Remove(da);
                            context.SaveChanges();
                            MessageBox.Show("Xóa dự án thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoaddgvDuAn();
                        }
                        catch
                        {
                            MessageBox.Show("Xóa dự án thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
        #endregion
        #region Sự kiện of nhân viên tham gia dựa án
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            String a = dgvDuAn.CurrentRow.Cells["MaDuAn"].Value.ToString();
            AddNV fr = new AddNV(a);
            fr.Show();
       //     LoadTN();
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (dgvDANV.RowCount > 1)
            {
                String a = dgvDuAn.CurrentRow.Cells["MaDuAn"].Value.ToString();
                string b = dgvDANV.CurrentRow.Cells["MaNV"].Value.ToString();
                EditNV fr = new EditNV(a, b);
                fr.Show();
            }
            else { MessageBox.Show("Chưa có nhân viên nào tham gia dự án"); }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (dgvDANV.RowCount >= 1)
            {
                String a = dgvDuAn.CurrentRow.Cells["MaDuAn"].Value.ToString();
                string b = dgvDANV.CurrentRow.Cells["MaNV"].Value.ToString();
                try
                {
                    PhanCong pc = new PhanCong();
                    pc = context.PhanCongs.Find(b, a);
                    context.PhanCongs.Remove(pc);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa");
                    LoadNV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa nhân viên tham gia dự án thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Chưa có nhân viên nào tham gia dự án"); }
        }
        #endregion

        
    }
}
