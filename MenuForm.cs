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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        #region Events Click
        private void Client_Click(object sender, EventArgs e)
        {
            ClientForm frmclient = new ClientForm();
            this.Hide();
            frmclient.ShowDialog();
            this.Show();
        }
        private void Staff_Click(object sender, EventArgs e)
        {
            StaffForm frmstaff = new StaffForm();
            this.Hide();
            frmstaff.ShowDialog();
            this.Show();
        }
        private void ServiceUsing_Click(object sender, EventArgs e)
        {
            UseServiceForm frmuseService = new UseServiceForm();
            this.Hide();
            frmuseService.ShowDialog();
            this.Show();
        }
        private void RoomUsing_Click(object sender, EventArgs e)
        {
            UseRoomForm frmuseRoom = new UseRoomForm();
            this.Hide();
            frmuseRoom.ShowDialog();
            this.Show();
        }
        private void Purchase_Click(object sender, EventArgs e)
        {
            PurchaseForm frmPurchase = new PurchaseForm();
            this.Hide();
            frmPurchase.ShowDialog();
            this.Show();
        }
        private void Room_Click(object sender, EventArgs e)
        {
            RoomForm frmroom = new RoomForm();
            this.Hide();
            frmroom.ShowDialog();
            this.Show();
        }

        private void Service_Click(object sender, EventArgs e)
        {
            ServiceForm frmservice = new ServiceForm();
            this.Hide();
            frmservice.ShowDialog();
            this.Show();
        }

        private void TypeRoom_Click(object sender, EventArgs e)
        {
            RoomTypeForm frmTypeRoom = new RoomTypeForm();
            this.Hide();
            frmTypeRoom.ShowDialog();
            this.Show();
        }
        #endregion

        #region Events Mouse

        private void Client_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("client_yellow.png", this.lblClient, this.pbClient);
        }

        private void Client_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("client.png", this.lblClient, this.pbClient);
        }

        private void Purchase_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("purchase_yellow.png", this.lblPurchase, this.pbPurchase);
        }

        private void Purchase_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("purchase.png", this.lblPurchase, this.pbPurchase);
        }

        private void Room_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("room_yellow.png", this.lblRoom, this.pbRoom);
        }

        private void Room_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("room.png", this.lblRoom, this.pbRoom);
        }

        private void Service_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("service_yellow.png", this.lblService, this.pbService);
        }

        private void Service_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("service.png", this.lblService, this.pbService);
        }
        private void TypeRoom_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("typeroom_yellow.png", this.lblTypeRoom, this.pbTypeRoom);
        }

        private void TypeRoom_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("typeroom.png", this.lblTypeRoom, this.pbTypeRoom);
        }
        private void ServiceUsing_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("serviceUsing_yellow.png", this.lblServiceUsing, this.pbServiceUsing);
        }

        private void ServiceUsing_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("serviceUsing.png", this.lblServiceUsing, this.pbServiceUsing);
        }
        private void RoomUsing_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("roomUsing_yellow.png", this.lblRoomUsing, this.pbRoomUsing);
        }

        private void RoomUsing_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("roomUsing.png", this.lblRoomUsing, this.pbRoomUsing);
        }
        private void Staff_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanged_Enter("staff_yellow.png", this.lblStaff, this.pbStaff);
        }

        private void Staff_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanged_Leave("staff.png", this.lblStaff, this.pbStaff);
        }
        #endregion

        private void ButtonColorChanged_Enter(string picture, Label lbl, PictureBox pb)
        {
            lbl.ForeColor = Color.Yellow;
            pb.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Images\\" + picture);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void ButtonColorChanged_Leave(string picture, Label lbl, PictureBox pb)
        {
            lbl.ForeColor = Color.Black;
            pb.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Images\\" + picture);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
