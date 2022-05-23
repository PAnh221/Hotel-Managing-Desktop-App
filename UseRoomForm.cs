using Nhom15_FinalProject.Helper;
using Nhom15_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom15_FinalProject
{
    public partial class UseRoomForm : Form
    {
        QuanLyKhachSanDataContext db = null;
        public UseRoomForm()
        {
            InitializeComponent();
            db = new QuanLyKhachSanDataContext();
            BindingGridview();
            LoadDropdownPhong();
            LoadDropdownNhanVien();
            LoadDropdownKhachHang();
        }

        private void UseRoomForm_Load(object sender, EventArgs e)
        {
            pbSave.Visible = false;

        }
        private void BindingGridview()
        {
            List<ThuePhongDTO> userRooms = db.ThuePhongs.Select(s => new ThuePhongDTO()
            {
                MaThuePhong = s.MaThuePhong,
                MaPhong = s.MaPhong,
                MaNV = s.MaNV,
                CMND = s.CMND,
                NgayVao = s.NgayVao,
                DatCoc = s.DatCoc
            }).ToList();
            DataTable table = new DataTable();
            if (userRooms != null && userRooms.Any())
            {
                table = userRooms.ToDataTable<ThuePhongDTO>();
            }
            dgvRoom.DataSource = table;
            dgvRoom.AutoGenerateColumns = false;
            dgvRoom.DataSource = userRooms;
        }

        private void LoadDropdownPhong()
        {
            var dataTable = new DataTable();
            var data = db.Phongs.ToList();

            if (data != null && data.Any())
            {
                dataTable = data.ToDataTable<Phong>();
            }
            cmbRoomID.DisplayMember = "MaPhong";
            cmbRoomID.ValueMember = "MaPhong";
            cmbRoomID.DataSource = dataTable;
        }
        private void LoadDropdownNhanVien()
        {
            var dataTable = new DataTable();
            var data = db.NhanViens.ToList();

            if (data != null && data.Any())
            {
                dataTable = data.ToDataTable<NhanVien>();
            }
            cmNhanVien.DisplayMember = "TenNV";
            cmNhanVien.ValueMember = "MaNV";
            cmNhanVien.DataSource = dataTable;
        }
        private void LoadDropdownKhachHang()
        {
            var dataTable = new DataTable();
            var data = db.KhachHangs.ToList();

            if (data != null && data.Any())
            {
                dataTable = data.ToDataTable<KhachHang>();
            }
            cmbCMND.DisplayMember = "TenKH";
            cmbCMND.ValueMember = "CMND";
            cmbCMND.DataSource = dataTable;
        }

        #region Events Mouse
        private void pbAdd_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("add_blue.png", this.pbAdd);
        }

        private void pbAdd_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("add.png", this.pbAdd);
        }

        private void pbBack_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("back_blue.png", this.pbBack);
        }

        private void pbBack_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("back.png", this.pbBack);
        }

        private void pbEdit_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("edit_blue.png", this.pbEdit);
        }

        private void pbEdit_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("edit.png", this.pbEdit);
        }


        private void pbSave_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("save_blue.png", this.pbSave);
        }

        private void pbSave_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("save.png", this.pbSave);
        }

        private void pbCancel_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("cancel_blue.png", this.pbCancel);
        }

        private void pbCancel_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("cancel.png", this.pbCancel);
        }
        #endregion

        private void ButtonColorChanged(string picture, PictureBox pb)
        {
            pb.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Images\\" + picture);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Mã thuê phòng không được để trống.");
                    txtID.Focus();
                    return;
                }
                db.ThuePhongs.InsertOnSubmit(new ThuePhong
                {
                    MaThuePhong = txtID.Text,
                    MaPhong = cmbRoomID.SelectedValue.ToString(),
                    CMND = cmbCMND.SelectedValue.ToString(),
                    MaNV = cmNhanVien.SelectedValue.ToString(),
                    NgayVao = dtpDateIn.Text.ToString(),
                    DatCoc = txtDeposit.Text
                });
                db.SubmitChanges();
                BindingGridview();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void pbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtID.Text))
                {
                    MessageBox.Show("Mã thuê phòng không được để trống.");
                    txtID.Focus();
                    return;
                }
                var Entity = db.ThuePhongs.FirstOrDefault(f => f.MaThuePhong == txtID.Text);
                Entity.MaThuePhong = txtID.Text;
                Entity.MaPhong = cmbRoomID.SelectedValue.ToString();
                Entity.CMND = cmbCMND.SelectedValue.ToString();
                Entity.MaNV = cmNhanVien.SelectedValue.ToString();
                Entity.NgayVao = dtpDateIn.Text.ToString();
                Entity.DatCoc = txtDeposit.Text;
                db.SubmitChanges();
                BindingGridview();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            var id = txtID.Text;

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Không tìm thấy mã thuê phòng.");
                txtID.Focus();
                return;
            }
            var Entity = db.ThuePhongs.FirstOrDefault(f => f.MaThuePhong == id);
            if (Entity == null)
            {
                MessageBox.Show("Không tìm thấy mã thuê phòng.");
                txtID.Focus();
                return;
            }
            try
            {
                db.ThuePhongs.DeleteOnSubmit(Entity);
                db.SubmitChanges();
                BindingGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvRoom.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtID.Text = dgvRoom.Rows[r].Cells[0].Value.ToString().Trim();
            cmbRoomID.Text = dgvRoom.Rows[r].Cells[1].Value.ToString().Trim();
            cmbCMND.Text = dgvRoom.Rows[r].Cells[2].Value.ToString().Trim();
            cmNhanVien.Text = dgvRoom.Rows[r].Cells[3].Value.ToString().Trim();
            txtDeposit.Text = dgvRoom.Rows[r].Cells[5].Value.ToString().Trim();
        }
    }
}
