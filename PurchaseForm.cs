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
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }
        QuanLyKhachSanDataContext db = null;

        private void MySetPurchaseForm()
        {
            db = new QuanLyKhachSanDataContext();
            var ThanhToanQ = from t in db.ThanhToans select t;
            dgvPurchase.DataSource = ThanhToanQ;
        }
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            db = new QuanLyKhachSanDataContext();

            cmbRoomUseID.DataSource = from t in db.ThuePhongs select t;
            cmbRoomUseID.DisplayMember = "MaThuePhong";
            //cmbRoomUseID.ValueMember = "MaThanhToan";

            cmbStaffID.DataSource = from t in db.NhanViens select t;
            cmbStaffID.DisplayMember = "MaNV";
            //cmbStaffID.ValueMember = "MaThanhToan";

            MySetPurchaseForm();

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

        private void pbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLyKhachSanDataContext db = new QuanLyKhachSanDataContext();
                db.ThanhToans.InsertOnSubmit(new ThanhToan
                {
                    MaThanhToan = txtPurchaseID.Text,

                    ThanhTien = Convert.ToDecimal(txtTotal.Text),

                    MaThuePhong = cmbRoomUseID.Text,

                    MaNV = cmbStaffID.Text,

                    NgayVao = Convert.ToDateTime(dtpDateIn.Value),

                    NgayThanhToan = Convert.ToDateTime(dtpPurchaseDate.Text)


                });
                db.SubmitChanges();
                MySetPurchaseForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbEdit_Click(object sender, EventArgs e)
        {
            if (dgvPurchase.SelectedRows == null)
            {
                return;
            }
            try
            {
                int r = dgvPurchase.CurrentCell.RowIndex;
                string tempPID = dgvPurchase.Rows[r].Cells[0].Value.ToString();
                ThanhToan ThanhToanQ = db.ThanhToans.Single(x => x.MaThanhToan == tempPID);
                ThanhToanQ.MaThanhToan = txtPurchaseID.Text;
                ThanhToanQ.ThanhTien = Convert.ToDecimal(txtTotal.Text);
                ThanhToanQ.MaThuePhong = cmbRoomUseID.Text;
                ThanhToanQ.MaNV = cmbStaffID.Text;
                ThanhToanQ.NgayVao = Convert.ToDateTime(dtpDateIn.Text);
                ThanhToanQ.NgayThanhToan = Convert.ToDateTime(dtpPurchaseDate.Text);
                db.SubmitChanges();
                MySetPurchaseForm();
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
                int r = dgvPurchase.CurrentCell.RowIndex;
                string tempPID = dgvPurchase.Rows[r].Cells[0].Value.ToString();
                ThanhToan ThanhToanQ = db.ThanhToans.Single(x => x.MaThanhToan == tempPID);
                db.ThanhToans.DeleteOnSubmit(ThanhToanQ);
                db.SubmitChanges();
                MySetPurchaseForm();
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
                int r = dgvPurchase.CurrentCell.RowIndex;
                string tempPID = dgvPurchase.Rows[r].Cells[0].Value.ToString();
                ThanhToan ThanhToanQ = db.ThanhToans.Single(x => x.MaThanhToan == tempPID);
                ThanhToanQ.MaThanhToan = txtPurchaseID.Text;
                ThanhToanQ.ThanhTien = Convert.ToDecimal(txtTotal.Text);
                ThanhToanQ.MaThuePhong = cmbRoomUseID.Text;
                ThanhToanQ.MaNV = cmbStaffID.Text;
                ThanhToanQ.NgayVao = Convert.ToDateTime(dtpDateIn.Text);
                ThanhToanQ.NgayThanhToan = Convert.ToDateTime(dtpPurchaseDate.Text);
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

        private void dgvPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvPurchase.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtPurchaseID.Text = dgvPurchase.Rows[r].Cells[0].Value.ToString();
            txtTotal.Text = dgvPurchase.Rows[r].Cells[1].Value.ToString();
            cmbRoomUseID.Text = dgvPurchase.Rows[r].Cells[2].Value.ToString();
            cmbStaffID.Text = dgvPurchase.Rows[r].Cells[3].Value.ToString();
            dtpDateIn.Text = dgvPurchase.Rows[r].Cells[4].Value.ToString();
            dtpPurchaseDate.Text = dgvPurchase.Rows[r].Cells[5].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvPurchase.DataSource = db.ThanhToans.Where(x => x.MaThanhToan.Equals(txtFind.Text));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            cbStatus.Checked = true;
        }
    }
}
