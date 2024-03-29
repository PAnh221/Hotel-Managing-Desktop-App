﻿using System;
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
    public partial class ClientForm : Form
    {
        Entity.HotelDBMF db = null;
        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            pbSave.Visible = false;
            pbCancel.Visible = false;
            mySetKhachHang();

            setProvince();
            cbProv.SelectedIndex = 0;

            setDistrict();
            cbDist.SelectedIndex = 0;

            setComm();
            cbCommune.SelectedIndex = 0;
        }

        private void mySetKhachHang()
        {
            db = new Entity.HotelDBMF();
            var ClientQ = from khList in db.KhachHangEntities
                          select khList;
            DataTable dt = new DataTable();
            dt.Columns.Add("CMND");
            dt.Columns.Add("Ten_KH");
            dt.Columns.Add("Dia_Chi");
            dt.Columns.Add("So_Dien_Thoai");
            dt.Columns.Add("Nu");
            dt.Columns.Add("commune_id");

            foreach (var p in ClientQ)
            {
                dt.Rows.Add(p.CMND, p.TenKH, p.DiaChi, p.SoDienThoai, p.Nu, p.commune_id);
            }

            dgvClient.DataSource = dt;
        }

        private void setProvince()
        {
            db = new Entity.HotelDBMF();
            var ProvQ = from ProvList in db.provinceEntities
                        select
                        ProvList.province_name;
            foreach (string ProvName in ProvQ)
            {
                cbProv.Items.Add(ProvName);
            }
        }

        private void setDistrict()
        {
            var DistQ = from DistList in db.districtEntities
                        join ProvList in db.provinceEntities on

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
            var CommQ = from CommList in db.communeEntities
                        join DistList in db.districtEntities on

                        CommList.district_id equals DistList.district_id
                        where (DistList.district_name == cbDist.Text)

                        select CommList.commune_name;
            foreach (string CommName in CommQ)
            {
                cbCommune.Items.Add(CommName);
            }
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

        private void ButtonColorChanged(string picture, PictureBox pb)
        {
            pb.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Images\\" + picture);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvClient.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtID.Text = dgvClient.Rows[r].Cells[0].Value.ToString();
            txtName.Text = dgvClient.Rows[r].Cells[1].Value.ToString();
            txtAddress.Text = dgvClient.Rows[r].Cells[2].Value.ToString();
            txtPhoneNumber.Text = dgvClient.Rows[r].Cells[3].Value.ToString();

            if (Convert.ToBoolean(dgvClient.Rows[r].Cells[4].Value) == true)
            {
                ckbFemale.Checked = true;
            }
            else
            {
                ckbFemale.Checked = false;

            }


        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            var Query = (from KH in db.KhachHangEntities
                         where KH.CMND == txtID.Text
                         select KH).SingleOrDefault();
            if (Query != null)
            {
                MessageBox.Show("Client ID is already existed", "Lỗi!");
            }
            else
            {
                try
                {

                    var Query1 = (from C in db.communeEntities
                                  where C.commune_name == cbCommune.Text
                                  select C);

                    var cid = Query1.FirstOrDefault<Entity.communeEntity>();

                    Entity.KhachHangEntity KH = new Entity.KhachHangEntity();
                    KH.CMND = txtID.Text.Trim();
                    KH.TenKH = txtName.Text.Trim();
                    KH.DiaChi = txtAddress.Text.Trim() + "," + cbCommune.Text.Trim() + "," + cbDist.Text.Trim();
                    KH.SoDienThoai = txtPhoneNumber.Text.Trim();
                    KH.Nu = ckbFemale.Checked;
                    KH.commune_id = cid.commune_id;
                    db.KhachHangEntities.Add(KH);
                    db.SaveChanges();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                mySetKhachHang();
            }
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

        private void pbDelete_Click(object sender, EventArgs e)
        {

            if (dgvClient.CurrentCell != null) {
                try
                {
                    int r = dgvClient.CurrentCell.RowIndex;
                    string tempDID = dgvClient.Rows[r].Cells[0].Value.ToString();
                    Entity.KhachHangEntity Q = db.KhachHangEntities.Single(x => x.CMND == tempDID);

                    //db.districts.DeleteOnSubmit(DistQ);
                    //db.SubmitChanges();
                    db.KhachHangEntities.Remove(Q);
                    db.SaveChanges();
                    mySetKhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void pbEdit_Click(object sender, EventArgs e)
        {
//            //db = new SalesDBMF();
//            int r = dtGridView.CurrentCell.RowIndex;
//            string tempDID = dtGridView.Rows[r].Cells[0].Value.ToString();
//            district DTQuery = db.districts.Single(x => x.district_id ==

//            tempDID);
//            if (DTQuery != null)
//            {
//                province PRQuery2 = db.provinces.Single(x => x.province_id

//                == txtPID.Text);

//                var DTQuery2 = (from DT in db.districts
//                                where
//                                DT.district_id == txtDID.Text

//                                select DT).SingleOrDefault();
//                if (PRQuery2 == null)
//                {
//                    MessageBox.Show("Province_id chưa tồn tại trong BảngProvince, Vui lòng cập nhật Province_id trong bảngProvince trước!", "Lỗi khóa ngoại!");
                
//return;
//                }
//                if (DTQuery.district_id == txtDID.Text)
//                {
//                    //DTQuery.district_id = txtDID.Text;
//                    DTQuery.district_name = txtDName.Text;
//                    DTQuery.province_id = txtPID.Text;
//                    db.SaveChanges();

//                }
//                else
//                {
//                    if (DTQuery2 != null)
//                    {
//                        MessageBox.Show("District_ID đã tồn tại trong BảngDistrict không sửa được!", "Lỗi khóa!");
//                    return;
//                    }
//                    try
//                    {

//                        db.districts.Remove(DTQuery);

//                        db.SaveChanges();

//                        district DT = new district();
//                        DT.district_id = txtDID.Text;
//                        DT.district_name = txtDName.Text;
//                        DT.province_id = txtPID.Text;
//                        db.districts.Add(DT);
//                        db.SaveChanges();

//                    }
//                    catch
//                    {

//                        MessageBox.Show("District_ID đã tồn tại khóa ngoại
//                        trong bảng Commune, Vui lòng cập nhật District_ID
//                        trong bảng Commune trước!", "Lỗi khóa ngoại!");
                   
//}
//                }
//            }
//            MySetDistrict();
        }
    }
}
