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
using QL_NHANSU.GUI;
namespace QL_NHANSU
{
    public partial class NV : UserControl
    {
       // NhanVien nv = new NhanVien();
        QL_NS context = new QL_NS();
        bool ok = true;
        public NV()
        {

            InitializeComponent();

        }
        #region Load NV
       
        private void LoadControl()
        {
            cbbPhong.DataSource = context.PhongBans.ToList();
            cbbPhong.ValueMember = "MaPB";
            cbbPhong.DisplayMember = "TenPB";
        }
        private void LoaddgvNV()
        {

            var nv = from p in context.NhanViens
                     select new
                     {
                         MaNV = p.MaNV,
                         TenNV = p.TenNV,
                         NgaySinh = p.NgaySinh,
                         DChi = p.DChi,
                         GioiTinh = p.GTinh,
                         Luong = p.Luong,
                         SoNV = p.SoNVDuoiQuyen,
                         Email = p.Email,
                         SDT = p.SDT,
                         ChucVu = p.Chucvu,
                         TenPB = context.PhongBans.Where(z => z.MaPB == p.MaPB).FirstOrDefault().TenPB,
                         NguoiGS = p.NgGS
                     };
            dgvNV.DataSource = nv.ToList();
        }
        private void LoadTN()
        {
            string manv = dgvNV.SelectedRows[0].Cells["MaNV"].Value.ToString();
            int i = 0;
            var ListTN = context.ThanNhans.Where(p => p.MaNV == manv).ToList()
                                 .Select(p => new
                                 {
                                     STT = ++i,
                                     HoTenTN = p.TenTN,
                                     QuanHE = p.QuanHe
                                 })
                                 .ToList();
            dgvTN.DataSource = ListTN;
        }
        private void NV_Load(object sender, EventArgs e)
        {
            LoaddgvNV();
            LoadControl();
        }
        #endregion
        #region Lấy and ktr dữ liệu
        private void settingNV(NhanVien nv)
        {
            nv.MaNV = txtMaNV.Text;
            nv.Luong = txtluong.Text;
         //   nv.GTinh = comboBox1.Text;
            nv.NgaySinh = dtNS.Value;
            nv.NgGS = txtNgGS.Text;
            nv.SDT = txtSoDT.Text;
            nv.SoNVDuoiQuyen = txtSonv.Text;
            nv.TenNV = txtTen.Text;
            nv.Email = txtEmail.Text;
            nv.MaPB = cbbPhong.SelectedValue.ToString();
            nv.DChi = txtdiachi.Text;
            nv.Chucvu = txtchucvu.Text;
        }
        private bool check()
        {
           
            if (txtMaNV.Text == "") { MessageBox.Show("Chưa điền mã của nhân viên"); return false; }
            
            return true;

        }
        #endregion
        #region Sự kiện với nhân viên
        private void dgvNV_SelectionChanged(object sender, EventArgs e)
        {
            try {
                if (dgvNV.SelectedRows.Count > 0)
                {
                   // comboBox1.SelectedIndex = -1;
                  //  cbbPhong.SelectedIndex = -1;
                    txtMaNV.Text = dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();
                    txtchucvu.Text = dgvNV.CurrentRow.Cells["ChucVu"].Value.ToString();
                    txtdiachi.Text = dgvNV.CurrentRow.Cells["DChi"].Value.ToString();
                    txtEmail.Text = dgvNV.CurrentRow.Cells["Email"].Value.ToString();
                    txtluong.Text = dgvNV.CurrentRow.Cells["Luong"].Value.ToString();
                    txtNgGS.Text = dgvNV.CurrentRow.Cells["NguoiGS"].Value.ToString();
                    txtSoDT.Text = dgvNV.CurrentRow.Cells["SDT"].Value.ToString();
                    txtSonv.Text = dgvNV.CurrentRow.Cells["SoNV"].Value.ToString();
                    txtTen.Text = dgvNV.CurrentRow.Cells["TenNV"].Value.ToString();
                    cbbPhong.Text = dgvNV.CurrentRow.Cells["TenPB"].Value.ToString();
                    comboBox1.Text = dgvNV.CurrentRow.Cells["GioiTinh"].Value.ToString();
                    dtNS.Text = dgvNV.CurrentRow.Cells["NgaySinh"].Value.ToString();
                    string manv = dgvNV.SelectedRows[0].Cells["MaNV"].Value.ToString();
                  //  int i = 0;
                    LoadTN();
                }
            }
            catch(Exception ex)
            {

            }           
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbbTK.Text == "Mã nhân viên")
            {
                var nv = from p in context.NhanViens.Where(p=>p.MaNV==txtKey.Text)
                         select new
                         {
                             MaNV = p.MaNV,
                             TenNV = p.TenNV,
                             NgaySinh = p.NgaySinh,
                             DChi = p.DChi,
                             GioiTinh = p.GTinh,
                             Luong = p.Luong,
                             SoNV = p.SoNVDuoiQuyen,
                             Email = p.Email,
                             SDT = p.SDT,
                             ChucVu = p.Chucvu,
                             TenPB = context.PhongBans.Where(z => z.MaPB == p.MaPB).FirstOrDefault().TenPB,
                             NguoiGS = p.NgGS
                         };
                if(nv==null) { MessageBox.Show("Không tìm thấy nhân viên"); LoaddgvNV(); }
                dgvNV.DataSource = nv.ToList();

            }
            else if (cbbTK.Text == "Tên nhân viên")
            {
                var nv = from p in context.NhanViens.Where(p=>p.TenNV==txtKey.Text)
                         select new
                         {
                             MaNV = p.MaNV,
                             TenNV = p.TenNV,
                             NgaySinh = p.NgaySinh,
                             DChi = p.DChi,
                             GioiTinh = p.GTinh,
                             Luong = p.Luong,
                             SoNV = p.SoNVDuoiQuyen,
                             Email = p.Email,
                             SDT = p.SDT,
                             ChucVu = p.Chucvu,
                             TenPB = context.PhongBans.Where(z => z.MaPB == p.MaPB).FirstOrDefault().TenPB,
                             NguoiGS = p.NgGS
                         };
                if (nv == null) { MessageBox.Show("Không tìm thấy nhân viên"); LoaddgvNV(); }
                else
                dgvNV.DataSource = nv.ToList();
            }
            else if (cbbTK.Text == "PB")
            {
                var nv = from p in context.NhanViens.Where(p => p.MaPB == txtKey.Text)
                         select new
                         {
                             MaNV = p.MaNV,
                             TenNV = p.TenNV,
                             NgaySinh = p.NgaySinh,
                             DChi = p.DChi,
                             GioiTinh = p.GTinh,
                             Luong = p.Luong,
                             SoNV = p.SoNVDuoiQuyen,
                             Email = p.Email,
                             SDT = p.SDT,
                             ChucVu = p.Chucvu,
                             TenPB = context.PhongBans.Where(z => z.MaPB == p.MaPB).FirstOrDefault().TenPB,
                             NguoiGS = p.NgGS
                         };
                if (nv == null) { MessageBox.Show("Không tìm thấy nhân viên"); LoaddgvNV(); }
                else
                    dgvNV.DataSource = nv.ToList();
            }
        }
        #endregion
        #region Sự kiện với thân nhân of nhân viên
        private void btnthemTN_Click(object sender, EventArgs e)
        {
            String a = dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();
            AddTN fr = new AddTN(a);
            fr.Show();
            LoadTN();
        }

        private void btnSuatn_Click(object sender, EventArgs e)
        {
            if (dgvTN.RowCount > 1) {
                String a = dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();
                string b = dgvTN.CurrentRow.Cells["HoTenTN"].Value.ToString();
                EditTN fr = new EditTN(a, b);
                fr.Show();
            }
            else { MessageBox.Show("Nhân viên chưa có thân nhân nào"); }
        }

        private void btnXoaTn_Click(object sender, EventArgs e)
        {
            if (dgvTN.RowCount > 1)
            {
                String a = dgvNV.CurrentRow.Cells["MaNV"].Value.ToString();
                string b = dgvTN.CurrentRow.Cells["HoTenTN"].Value.ToString();
                try
                {
                    ThanNhan tn = new ThanNhan();
                    tn = context.ThanNhans.Find(a, b);
                    context.ThanNhans.Remove(tn);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa");
                    LoadTN();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa thân nhân thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else { MessageBox.Show("Nhân viên chưa có thân nhân nào"); }

        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtchucvu.Clear();
            txtdiachi.Clear();
            txtEmail.Clear();
            txtluong.Clear();
            txtMaNV.Clear();
            txtNgGS.Clear();
            txtSoDT.Clear();
            txtSonv.Clear();
            txtTen.Clear();
            comboBox1.Focus();
            ok = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ok = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            BtnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == dr)
            {

               NhanVien nv = context.NhanViens.Find(txtMaNV.Text);
                if (nv == null) MessageBox.Show("Không tồn tại nhân viên");
                try
                {
                    context.NhanViens.Remove(nv);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa");
                    LoaddgvNV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa nhân viên thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                if(check())
                try
                {
                    NhanVien nv = context.NhanViens.Find(txtMaNV.Text);
                        if (nv!= null) { MessageBox.Show("Đã tồn tại nhân viên này"); }
                    NhanVien tg = new NhanVien();
                    settingNV(tg);
                    context.NhanViens.Add(tg);
                    context.SaveChanges();
                    MessageBox.Show("Thêm nhân viên thành công");
                    LoaddgvNV();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    var id = txtMaNV.Text;
                    NhanVien tg = context.NhanViens.Where(p => p.MaNV == id).FirstOrDefault();
                    settingNV(tg);
                    context.SaveChanges();
                    MessageBox.Show("Sửa nhân viên thành công");
                    LoaddgvNV();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            BtnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoaddgvNV();
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            BtnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
    }
}
//textbox1.text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
//textbox2.text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
//textbox3.text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
