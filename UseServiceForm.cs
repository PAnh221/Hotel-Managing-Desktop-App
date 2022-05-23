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
    public partial class UseServiceForm : Form
    {
        QuanLyKhachSanDataContext db = null;
        public UseServiceForm()
        {
            InitializeComponent();
            db = new QuanLyKhachSanDataContext();
            BindingGridview();
            LoadDropdownPhong();
            LoadDropdownThuePhong();
        }

        private void BindingGridview()
        {
            List<SuDungDichVuDTO> userService = db.SuDungDichVus.Select(s => new SuDungDichVuDTO()
            {
                MaDV = s.MaDV,
                MaThuePhong = s.MaThuePhong,
                NgaySuDung = s.NgaySuDung,
                SoLuong = s.SoLuong
            }).ToList();
            DataTable table = new DataTable();
            if (userService != null && userService.Any())
            {
                table = userService.ToDataTable<SuDungDichVuDTO>();
            }
            dgvUseService.DataSource = table;
            dgvUseService.AutoGenerateColumns = false;
            dgvUseService.DataSource = userService;
        }
        private void LoadDropdownPhong()
        {
            var dataTable = new DataTable();
            var data = db.DichVus.ToList();

            if (data != null && data.Any())
            {
                dataTable = data.ToDataTable<DichVu>();
            }
            cmbServiceID.DisplayMember = "MaDV";
            cmbServiceID.ValueMember = "MaDV";
            cmbServiceID.DataSource = dataTable;
        }
        private void LoadDropdownThuePhong()
        {
            var dataTable = new DataTable();
            var data = db.ThuePhongs.ToList();

            if (data != null && data.Any())
            {
                dataTable = data.ToDataTable<ThuePhong>();
            }
            cmbUseRoomID.DisplayMember = "MaThuePhong";
            cmbUseRoomID.ValueMember = "MaThuePhong";
            cmbUseRoomID.DataSource = dataTable;
        }
        private void UseServiceForm_Load(object sender, EventArgs e)
        {
            pbSave.Visible = false;
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

        private void pbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbServiceID.Text))
                {
                    MessageBox.Show("Mã dịch vụ không được để trống.");
                    cmbServiceID.Focus();
                    return;
                }
                db.SuDungDichVus.InsertOnSubmit(new SuDungDichVu
                {
                    MaDV = cmbServiceID.Text,
                    MaThuePhong = cmbUseRoomID.SelectedValue.ToString(),
                    NgaySuDung = dtpDateIn.Value,
                    SoLuong = Convert.ToInt32(txtAmount.Text)
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
                if (string.IsNullOrWhiteSpace(cmbServiceID.Text))
                {
                    MessageBox.Show("Mã dịch vụ không được để trống.");
                    cmbServiceID.Focus();
                    return;
                }
                var Entity = db.SuDungDichVus.FirstOrDefault(f => f.MaDV == cmbServiceID.Text);
                Entity.MaDV = cmbServiceID.Text;
                //Entity.MaPhong = cmbServiceID.SelectedValue.ToString();
                Entity.MaThuePhong = cmbUseRoomID.SelectedValue.ToString();
                Entity.NgaySuDung = dtpDateIn.Value;
                Entity.SoLuong = Convert.ToInt32(txtAmount.Text);
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
            var id = cmbServiceID.Text;

            if (string.IsNullOrWhiteSpace(cmbServiceID.Text))
            {
                MessageBox.Show("Không tìm thấy mã dịch vụ.");
                cmbServiceID.Focus();
                return;
            }
            var Entity = db.SuDungDichVus.FirstOrDefault(f => f.MaDV == id);
            if (Entity == null)
            {
                MessageBox.Show("Không tìm thấy mã dịch vụ.");
                cmbServiceID.Focus();
                return;
            }
            try
            {
                db.SuDungDichVus.DeleteOnSubmit(Entity);
                db.SubmitChanges();
                BindingGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUseService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvUseService.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            
            cmbServiceID.Text = dgvUseService.Rows[r].Cells[0].Value.ToString();
            cmbUseRoomID.Text = dgvUseService.Rows[r].Cells[1].Value.ToString();
            dtpDateIn.Value = Convert.ToDateTime(dgvUseService.Rows[r].Cells[2].Value.ToString().Trim());
            txtAmount.Text = dgvUseService.Rows[r].Cells[3].Value.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
