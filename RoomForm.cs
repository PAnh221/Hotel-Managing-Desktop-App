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
    public partial class RoomForm : Form
    {
        public RoomForm()
        {
            InitializeComponent();
        }
        QuanLyKhachSanDataContext db = null;

        private void MySetRoomForm()
        {
            db = new QuanLyKhachSanDataContext();
            var PhongQ = from p in db.Phongs select p;
            dgvRoom.DataSource = PhongQ;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            db = new QuanLyKhachSanDataContext();
            cmbRoomType.DataSource = from p in db.LoaiPhongs select p;
            cmbRoomType.DisplayMember = "MaLoai";
            //cmbRoomType.ValueMember = "MaPhong";
            MySetRoomForm();

            pbCancel.Visible = false;
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

        private void pbDelete_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("delete_blue.png", this.pbDelete);
        }

        private void pbDelete_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("delete.png", this.pbDelete);
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

        private void txtFind_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvRoom.DataSource = db.Phongs.Where(x => x.MaPhong.Equals(txtFind.Text));
        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvRoom.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtRoomID.Text = dgvRoom.Rows[r].Cells[0].Value.ToString();
            cmbRoomType.Text = dgvRoom.Rows[r].Cells[1].Value.ToString();
            txtArea.Text = dgvRoom.Rows[r].Cells[4].Value.ToString();
            txtNote.Text = dgvRoom.Rows[r].Cells[3].Value.ToString();
            txtPrice.Text = dgvRoom.Rows[r].Cells[5].Value.ToString();
            //cbStatus.Checked = dgvRoom.Rows[r].Cells[2].Value.ToString();

        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLyKhachSanDataContext db = new QuanLyKhachSanDataContext();
                db.Phongs.InsertOnSubmit(new Phong
                {
                    MaPhong = txtRoomID.Text,

                    MaLoai = cmbRoomType.Text,

                    TrangThai = cbStatus.Checked,

                    GhiChu = txtNote.Text,

                    DienTich = txtArea.Text,

                    GiaThue = Convert.ToDouble(txtPrice.Text),

                    SoGiuong = Convert.ToInt32(txtBed.Text)

                });
                db.SubmitChanges();
                MySetRoomForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbEdit_Click(object sender, EventArgs e)
        {
            if (dgvRoom.SelectedRows == null)
            {
                return;
            }
            try
            {
                if (dgvRoom.CurrentCell != null)
                {
                    int r = dgvRoom.CurrentCell.RowIndex;
                    string tempPID = dgvRoom.Rows[r].Cells[0].Value.ToString();
                    Phong PhongQ = db.Phongs.Single(x => x.MaPhong == tempPID);
                    PhongQ.MaPhong = txtRoomID.Text;
                    PhongQ.MaLoai = cmbRoomType.Text;
                    PhongQ.TrangThai = cbStatus.Checked;
                    PhongQ.GhiChu = txtNote.Text;
                    PhongQ.DienTich = txtArea.Text;
                    PhongQ.GiaThue = Convert.ToDouble(txtPrice.Text);
                    db.SubmitChanges();
                    MySetRoomForm();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvRoom.CurrentCell.RowIndex;
                string tempPID = dgvRoom.Rows[r].Cells[0].Value.ToString();
                Phong PhongQ = db.Phongs.Single(x => x.MaPhong == tempPID);
                db.Phongs.DeleteOnSubmit(PhongQ);
                db.SubmitChanges();
                MySetRoomForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbSave_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvRoom.CurrentCell.RowIndex;
                string tempPID = dgvRoom.Rows[r].Cells[0].Value.ToString();
                Phong PhongQ = db.Phongs.Single(x => x.MaPhong == tempPID);
                PhongQ.MaPhong = txtRoomID.Text;
                PhongQ.MaLoai = cmbRoomType.Text;
                PhongQ.TrangThai = cbStatus.Checked;
                PhongQ.GhiChu = txtNote.Text;
                PhongQ.DienTich = txtArea.Text;
                PhongQ.GiaThue = Convert.ToDouble(txtPrice.Text);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void pbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvRoom.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtRoomID.Text = dgvRoom.Rows[r].Cells[0].Value.ToString().Trim();
            cmbRoomType.Text = dgvRoom.Rows[r].Cells[1].Value.ToString().Trim();
            cbStatus.Checked = Convert.ToBoolean(dgvRoom.Rows[r].Cells[2].Value);
            txtArea.Text = dgvRoom.Rows[r].Cells[4].Value.ToString().Trim();
            txtNote.Text = dgvRoom.Rows[r].Cells[3].Value.ToString().Trim();
            txtPrice.Text = dgvRoom.Rows[r].Cells[5].Value.ToString().Trim();
            txtBed.Text = dgvRoom.Rows[r].Cells[6].Value.ToString().Trim();

        }
    }
}
