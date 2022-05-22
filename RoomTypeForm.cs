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
    public partial class RoomTypeForm : Form
    {
        Entity.HotelDBMF db = null;
        public RoomTypeForm()
        {
            InitializeComponent();
        }

        private void RoomType_Load(object sender, EventArgs e)
        {
            pbSave.Visible = false;
            pbCancel.Visible = false;
            mySetRoomType();
        }

        private void mySetRoomType()
        {
            db = new Entity.HotelDBMF();
            var RTQ = from RTypeList in db.LoaiPhongEntities
                      select RTypeList;
            DataTable dt = new DataTable();
            dt.Columns.Add("Ma_Loai");
            dt.Columns.Add("Ten_Loai");
            foreach (var p in RTQ)
            {
                dt.Rows.Add(p.MaLoai, p.TenLoai);
            }
            dgvTypeRoom.DataSource = dt;
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

        private void dgvTypeRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvTypeRoom.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtRoomType.Text = dgvTypeRoom.Rows[r].Cells[0].Value.ToString();
            txtNameType.Text = dgvTypeRoom.Rows[r].Cells[1].Value.ToString();
        }

        private void pbEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            if(dgvTypeRoom.CurrentCell != null)
            {
                int r = dgvTypeRoom.CurrentCell.RowIndex;
                string tempDID = dgvTypeRoom.Rows[r].Cells[0].Value.ToString();
                Entity.LoaiPhongEntity Q = db.LoaiPhongEntities.Single(x => x.MaLoai == tempDID);

                db.LoaiPhongEntities.Remove(Q);
                db.SaveChanges();
                mySetRoomType();
            }

        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            db = new Entity.HotelDBMF();
            //int r = dgvTypeRoom.CurrentCell.RowIndex;
            //string tempID = dgvTypeRoom.Rows[r].Cells[0].Value.ToString();

            string tempID = txtRoomType.Text;

            var Query = (from RT in db.LoaiPhongEntities
                         where RT.MaLoai == txtRoomType.Text.Trim()
                         select RT).SingleOrDefault();
            if (Query != null)
            {
                MessageBox.Show("Ma Loai already exists", "Error");
                return;
            }
            else
            {
                try
                {
                    Entity.LoaiPhongEntity RT = new Entity.LoaiPhongEntity();
                    RT.MaLoai = txtRoomType.Text.Trim();
                    RT.TenLoai = txtNameType.Text.Trim();

                    db.LoaiPhongEntities.Add(RT);
                    db.SaveChanges();

                }
                catch
                {
                    MessageBox.Show("Error", "Lỗi !");

                }
                mySetRoomType();
            }
        }
    }
}
