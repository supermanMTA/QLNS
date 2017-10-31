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
    public partial class PB : UserControl
    {
        // PhongBan pb = new PhongBan(); 
        QL_NS context = new QL_NS();
        bool ok = true;
        public PB()
        {
            InitializeComponent();
        }
        #region Load
        private void LoadControl()
        {
            cbbTP.DataSource = context.NhanViens.ToList();
            cbbTP.ValueMember = "MaNV";
            cbbTP.DisplayMember = "TenNV";
        }
        private void LoaddgvPB()
        {
            var pb = from p in context.PhongBans
                     select new
                     {
                         MaPB = p.MaPB,
                         TenPB = p.TenPB,
                         SoNV = p.SoNV,
                         TruongPhong = context.NhanViens.Where(z => z.MaNV == p.MaTP).FirstOrDefault().TenNV,
                         NgayNC = p.Ng_NC
                     };
            dgvPB.DataSource = pb.ToList();
        }
        private void PB_Load(object sender, EventArgs e)
        {
            LoaddgvPB();
            LoadControl();
        }
        #endregion
        #region Lấy and ktr dữ liệu
        private void settingPB(PhongBan pb)
        {
            pb.MaPB = txtMaPhong.Text;
            pb.TenPB = txtTenPhong.Text;
            pb.SoNV = txtSoNV.Text;
            pb.Ng_NC = DateNC.Value;
            pb.MaTP = cbbTP.SelectedValue.ToString();
        }
        private bool check()
        {
            if (txtMaPhong.Text == "") { MessageBox.Show("Mã phòng ban còn trống"); return false; }
            if (txtTenPhong.Text == "") { MessageBox.Show("Tên phòng ban còn trống"); return false; }
            if (txtSoNV.Text == "") { MessageBox.Show("Số nhân viên của phòng còn trống"); return false; }
            return true;
        }
        #endregion
        #region Sự kiện của phòng ban
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mã PB")
            {
                var pb = from p in context.PhongBans.Where(p => p.MaPB == txtKey.Text)
                         select new
                         {
                             MaPB = p.MaPB,
                             TenPB = p.TenPB,
                             SoNV = p.SoNV,
                             TruongPhong = context.NhanViens.Where(z => z.MaNV == p.MaTP).FirstOrDefault().TenNV,
                             NgayNC = p.Ng_NC
                         };
                if (pb == null) MessageBox.Show("Không tìm thấy");
                else dgvPB.DataSource = pb.ToList();
            }
            else if (comboBox1.Text == "Tên PB")
            {
                var pb = from p in context.PhongBans.Where(p => p.TenPB == txtKey.Text)
                         select new
                         {
                             MaPB = p.MaPB,
                             TenPB = p.TenPB,
                             SoNV = p.SoNV,
                             TruongPhong = context.NhanViens.Where(z => z.MaNV == p.MaTP).FirstOrDefault().TenNV,
                             NgayNC = p.Ng_NC
                         };
                if (pb == null) MessageBox.Show("Không tìm thấy");
                else dgvPB.DataSource = pb.ToList();

            }
        }

        private void dgvPB_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaPhong.Text = dgvPB.CurrentRow.Cells["MaPB"].Value.ToString();
                txtTenPhong.Text = dgvPB.CurrentRow.Cells["TenPB"].Value.ToString();
                txtSoNV.Text = dgvPB.CurrentRow.Cells["SoNV"].Value.ToString();
                cbbTP.Text = dgvPB.CurrentRow.Cells["TruongPhong"].Value.ToString();
                DateNC.Text = dgvPB.CurrentRow.Cells["NgayNC"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMaPhong.Clear();
            txtSoNV.Clear();
            txtTenPhong.Clear();
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
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa phòng ban này không", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == dr)
            {
                try
                {
                    PhongBan pb = context.PhongBans.Find(txtMaPhong.Text);
                    if (pb == null) MessageBox.Show("Không tồn tại phòng ban này");
                    context.PhongBans.Remove(pb);
                    context.SaveChanges();
                    MessageBox.Show("Xóa phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoaddgvPB();
                }
                catch
                {
                    MessageBox.Show("Xóa phòng ban thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                if (check())
                {
                    try
                    {
                        PhongBan tg = new PhongBan();
                        settingPB(tg);
                        context.PhongBans.Add(tg);
                        context.SaveChanges();
                        MessageBox.Show("Thêm phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaddgvPB();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm phòng ban thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return;
            }
            else
            {
                txtMaPhong.Enabled = false;
                if (check())
                {
                    try
                    {
                        PhongBan tg = context.PhongBans.Where(p => p.MaPB == txtMaPhong.Text).FirstOrDefault();
                        settingPB(tg);
                        context.SaveChanges();
                        MessageBox.Show("Sửa thông tin phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaddgvPB();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa thông tin nhân viên thất bại\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                txtMaPhong.Enabled = true;
            }
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            BtnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoaddgvPB();
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            BtnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        #endregion
    }
}
