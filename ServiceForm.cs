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
    public partial class ServiceForm : Form
    {
        HotelDBMF db = null;
        public ServiceForm()
        {
            InitializeComponent();
        }

        private void ServiceForm_Load(object sender, EventArgs e)
        {
            mySetService();
        }

        private void mySetService()
        {
            db = new HotelDBMF();
            var SQ = from SList in db.DichVus
                      select SList;
            DataTable dt = new DataTable();
            dt.Columns.Add("Ma_DV");
            dt.Columns.Add("Ten_DV");
            dt.Columns.Add("Gia_Tien");
            dt.Columns.Add("Don_Vi");
            foreach (var p in SQ)
            {
                dt.Rows.Add(p.MaDV, p.TenDV, p.GiaTien, p.DonViTinh);
            }
            dgvService.DataSource = dt;
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

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvService.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtServiceID.Text = dgvService.Rows[r].Cells[0].Value.ToString();
            txtServiceName.Text = dgvService.Rows[r].Cells[1].Value.ToString();
            txtPrice.Text = dgvService.Rows[r].Cells[2].Value.ToString();
            txtUnit.Text = dgvService.Rows[r].Cells[3].Value.ToString();
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            db = new HotelDBMF();
            int r = dgvService.CurrentCell.RowIndex;
            string tempID = dgvService.Rows[r].Cells[0].Value.ToString();

            var Query = (from SV in db.DichVus
                         where SV.MaDV == txtServiceID.Text.Trim()
                         select SV).SingleOrDefault();
            if (Query != null)
            {
                MessageBox.Show("Ma Dich Vu already exists", "Error");
                return;
            }
            else
            {
                try
                {
                    DichVu SV = new DichVu();
                    SV.MaDV = txtServiceID.Text.Trim();
                    SV.TenDV = txtServiceName.Text.Trim();
                    SV.GiaTien = Convert.ToDouble(txtPrice.Text.Trim());
                    SV.DonViTinh = txtUnit.Text.Trim();

                    db.DichVus.Add(SV);
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Error", "Lỗi !");

                }
                mySetService();
            }
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            int r = dgvService.CurrentCell.RowIndex;
            string tempDID = dgvService.Rows[r].Cells[0].Value.ToString();
            DichVu Q = db.DichVus.Single(x => x.MaDV == tempDID);

            db.DichVus.Remove(Q);
            db.SaveChanges();
            mySetService();
        }
    }
}
