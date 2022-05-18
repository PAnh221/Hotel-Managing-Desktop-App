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
    public partial class StaffForm : Form
    {

        HotelDBMF db = null;
        public StaffForm()
        {
            InitializeComponent();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {

            mySetNhanVien();
            setProvince();
            cbProv.SelectedIndex = 0;

            setDistrict();
            cbDist.SelectedIndex = 0;

            setComm();
            cbCommune.SelectedIndex = 0;
        }

        #region Events Mouse
        private void pbAdd_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("add_Client_blue.png", this.pbAdd);
        }

        private void pbAdd_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("add_Client.png", this.pbAdd);
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
            ButtonColorChanged("edit_Client_blue.png", this.pbEdit);
        }

        private void pbEdit_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("edit_Client.png", this.pbEdit);
        }

        private void pbDelete_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged("delete_Client_blue.png", this.pbDelete);
        }

        private void pbDelete_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged("delete_Client.png", this.pbDelete);
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

        private void setProvince()
        {
            db = new HotelDBMF();
            var ProvQ = from ProvList in db.provinces
                        select
                        ProvList.province_name;
            foreach (string ProvName in ProvQ)
            {
                cbProv.Items.Add(ProvName);
            }
        }

        private void setDistrict()
        {
            var DistQ = from DistList in db.districts
                        join ProvList in db.provinces on

                        DistList.province_id equals ProvList.province_id
                        where (ProvList.province_name == cbProv.Text.Trim())

                        select DistList.district_name;
            foreach (string DistName in DistQ)
            {
                cbDist.Items.Add(DistName);
            }
        }

        private void setComm()
        {
            var CommQ = from CommList in db.communes
                        join DistList in db.districts on

                        CommList.district_id equals DistList.district_id
                        where (DistList.district_name == cbDist.Text)

                        select CommList.commune_name;
            foreach (string CommName in CommQ)
            {
                cbCommune.Items.Add(CommName);
            }
        }

        private void ButtonColorChanged(string picture, PictureBox pb)
        {
            pb.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Images\\" + picture);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void mySetNhanVien()
        {
            db = new HotelDBMF();
            var StaffQ = from nvList in db.NhanViens
                         select nvList; 
            DataTable dt = new DataTable();
            dt.Columns.Add("Ma NV");
            dt.Columns.Add("Ten NV");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("NamSinh");
            dt.Columns.Add("Nu");
            dt.Columns.Add("commune_id");

            foreach (var p in StaffQ)
            {
                dt.Rows.Add(p.MaNV, p.TenNV, p.DiaChi, p.Nu, p.commune_id);
            }

            dgvStaff.DataSource = dt;
        }
        private void pbEdit_Click(object sender, EventArgs e)
        {
            //int r = dgvStaff.CurrentCell.RowIndex;
            //string tempDID = dgvStaff.Rows[r].Cells[0].Value.ToString();
            //NhanVien DTQuery = db.NhanViens.Single(x => x.MaNV == tempDID);
            //if (DTQuery != null)
            //{
            //    if (DTQuery.MaNV == txtID.Text)
            //    {
            //        DTQuery.Nu = ckbFemale.Checked;
            //        DTQuery.DiaChi = txtAddress.Text.Trim();
            //        DTQuery.TenNV = txtName.Text.Trim();
            //        db.SaveChanges();
            //    }
            //    else
            //    {
            //        //if (DTQuery2 != null)
            //        //{
            //        //    MessageBox.Show("District_ID đã tồn tại trong Bảng District không sửa được!", "Lỗi khóa!");
                    
            //        //return;
            //        }
            //        try
            //        {

            //            db.NhanViens.Remove(DTQuery);

            //            db.SaveChanges();

            //            NhanVien nhanVien = new NhanVien();
            //            nhanVien.MaNV = txtID.Text;
            //            nhanVien.TenNV = txtName.Text;
            //            //nhanVien.province_id = txtPID.Text;
            //            db.NhanViens.Add(nhanVien);
            //            db.SaveChanges();

            //        }
            //        catch
            //        {

            //            MessageBox.Show("District_ID đã tồn tại khóa ngoại trong bảng Commune, Vui lòng cập nhật District_ID trong bảng Commune trước!", "Lỗi khóa ngoại!");
                   
            //        }
            //    }
            }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int r = dgvStaff.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtID.Text = dgvStaff.Rows[r].Cells[0].Value.ToString();
            txtName.Text = dgvStaff.Rows[r].Cells[1].Value.ToString();
            txtAddress.Text = dgvStaff.Rows[r].Cells[2].Value.ToString();
            if (Convert.ToBoolean(dgvStaff.Rows[r].Cells[3].Value) == true)
            {
                ckbFemale.Checked = true;
            }
            else
            {
                ckbFemale.Checked = false;

            }
            //dtpBirthday = dgvStaff.Rows[r].Cells[3];
            //txtPID.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            //dtpBirthDate = dgvStaff.Rows[r].Cells[3].Value.ToString();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbCommune_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDist.Items.Clear();
            setDistrict();
            cbDist.SelectedIndex = 0;
        }

        private void cbDist_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCommune.Items.Clear();
            setComm();
            cbCommune.SelectedIndex = 0;
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            var Query = (from NV in db.NhanViens
                           where NV.MaNV == txtID.Text
                           select NV).SingleOrDefault();
            if (Query != null)
            {
                MessageBox.Show("Staff ID is already existed", "Lỗi!");
            }
            else
            {
                try
                {
                    NhanVien NV = new NhanVien();
                    NV.MaNV = txtID.Text.Trim();
                    NV.TenNV = txtName.Text.Trim();
                    NV.DiaChi = txtAddress.Text.Trim() + "," + cbCommune.Text.Trim() + "," + cbDist.Text.Trim();

                    NV.Nu = ckbFemale.Checked;
                    NV.commune_id = "10";
                    db.NhanViens.Add(NV);
                    db.SaveChanges();
                }

                catch
                {
                    MessageBox.Show("Error", "Lỗi!");

                }
                mySetNhanVien();
            }
        }

        private void pbDelete_Click(object sender, EventArgs e)
        {
            int r = dgvStaff.CurrentCell.RowIndex;
            string tempDID = dgvStaff.Rows[r].Cells[0].Value.ToString();
            NhanVien Q = db.NhanViens.Single(x => x.MaNV ==tempDID);

            //db.districts.DeleteOnSubmit(DistQ);
            //db.SubmitChanges();
            db.NhanViens.Remove(Q);
            db.SaveChanges();
            mySetNhanVien();
        }
    }
    }

