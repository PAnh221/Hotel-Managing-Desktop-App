
namespace Nhom15_FinalProject
{
    partial class RoomTypeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomTypeForm));
            this.btnLogout = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNameType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomType = new System.Windows.Forms.TextBox();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            this.gbInfor = new System.Windows.Forms.GroupBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.NameType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.dgvTypeRoom = new System.Windows.Forms.DataGridView();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbEdit = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            this.gbInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(1551, 193);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(145, 49);
            this.btnLogout.TabIndex = 139;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 31);
            this.label3.TabIndex = 61;
            this.label3.Text = "Room Type:";
            // 
            // txtNameType
            // 
            this.txtNameType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNameType.Location = new System.Drawing.Point(199, 139);
            this.txtNameType.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameType.Name = "txtNameType";
            this.txtNameType.Size = new System.Drawing.Size(233, 36);
            this.txtNameType.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 31);
            this.label2.TabIndex = 59;
            this.label2.Text = "Name Type:";
            // 
            // txtRoomType
            // 
            this.txtRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtRoomType.Location = new System.Drawing.Point(199, 75);
            this.txtRoomType.Margin = new System.Windows.Forms.Padding(4);
            this.txtRoomType.Name = "txtRoomType";
            this.txtRoomType.Size = new System.Drawing.Size(233, 36);
            this.txtRoomType.TabIndex = 62;
            // 
            // pbCancel
            // 
            this.pbCancel.Image = ((System.Drawing.Image)(resources.GetObject("pbCancel.Image")));
            this.pbCancel.Location = new System.Drawing.Point(680, 607);
            this.pbCancel.Margin = new System.Windows.Forms.Padding(4);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(80, 71);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCancel.TabIndex = 136;
            this.pbCancel.TabStop = false;
            this.pbCancel.MouseEnter += new System.EventHandler(this.pbCancel_MouseEnter);
            this.pbCancel.MouseLeave += new System.EventHandler(this.pbCancel_MouseLeave);
            // 
            // gbInfor
            // 
            this.gbInfor.Controls.Add(this.label3);
            this.gbInfor.Controls.Add(this.txtNameType);
            this.gbInfor.Controls.Add(this.label2);
            this.gbInfor.Controls.Add(this.txtRoomType);
            this.gbInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbInfor.Location = new System.Drawing.Point(156, 300);
            this.gbInfor.Margin = new System.Windows.Forms.Padding(4);
            this.gbInfor.Name = "gbInfor";
            this.gbInfor.Padding = new System.Windows.Forms.Padding(4);
            this.gbInfor.Size = new System.Drawing.Size(617, 192);
            this.gbInfor.TabIndex = 138;
            this.gbInfor.TabStop = false;
            this.gbInfor.Text = "Information";
            // 
            // pbSave
            // 
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Location = new System.Drawing.Point(577, 607);
            this.pbSave.Margin = new System.Windows.Forms.Padding(4);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(80, 71);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 135;
            this.pbSave.TabStop = false;
            this.pbSave.MouseEnter += new System.EventHandler(this.pbSave_MouseEnter);
            this.pbSave.MouseLeave += new System.EventHandler(this.pbSave_MouseLeave);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(1203, 249);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(47, 38);
            this.btnSearch.TabIndex = 137;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // pbAdd
            // 
            this.pbAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbAdd.Image")));
            this.pbAdd.Location = new System.Drawing.Point(156, 607);
            this.pbAdd.Margin = new System.Windows.Forms.Padding(4);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(80, 71);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 134;
            this.pbAdd.TabStop = false;
            this.pbAdd.MouseEnter += new System.EventHandler(this.pbAdd_MouseEnter);
            this.pbAdd.MouseLeave += new System.EventHandler(this.pbAdd_MouseLeave);
            // 
            // pbDelete
            // 
            this.pbDelete.Image = ((System.Drawing.Image)(resources.GetObject("pbDelete.Image")));
            this.pbDelete.Location = new System.Drawing.Point(375, 607);
            this.pbDelete.Margin = new System.Windows.Forms.Padding(4);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(80, 71);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 133;
            this.pbDelete.TabStop = false;
            this.pbDelete.MouseEnter += new System.EventHandler(this.pbDelete_MouseEnter);
            this.pbDelete.MouseLeave += new System.EventHandler(this.pbDelete_MouseLeave);
            // 
            // NameType
            // 
            this.NameType.DataPropertyName = "TenLoai";
            this.NameType.HeaderText = "Name Type";
            this.NameType.MinimumWidth = 6;
            this.NameType.Name = "NameType";
            this.NameType.ReadOnly = true;
            this.NameType.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MaLoai";
            this.dataGridViewTextBoxColumn1.HeaderText = "Room Type";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtFind.Location = new System.Drawing.Point(905, 249);
            this.txtFind.Margin = new System.Windows.Forms.Padding(4);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(288, 37);
            this.txtFind.TabIndex = 131;
            // 
            // dgvTypeRoom
            // 
            this.dgvTypeRoom.AllowUserToAddRows = false;
            this.dgvTypeRoom.AllowUserToDeleteRows = false;
            this.dgvTypeRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypeRoom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.NameType});
            this.dgvTypeRoom.Location = new System.Drawing.Point(905, 314);
            this.dgvTypeRoom.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTypeRoom.Name = "dgvTypeRoom";
            this.dgvTypeRoom.ReadOnly = true;
            this.dgvTypeRoom.RowHeadersWidth = 51;
            this.dgvTypeRoom.Size = new System.Drawing.Size(791, 420);
            this.dgvTypeRoom.TabIndex = 130;
            // 
            // pbBack
            // 
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(16, 193);
            this.pbBack.Margin = new System.Windows.Forms.Padding(4);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(73, 64);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 129;
            this.pbBack.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(687, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type Room";
            // 
            // pbEdit
            // 
            this.pbEdit.Image = ((System.Drawing.Image)(resources.GetObject("pbEdit.Image")));
            this.pbEdit.Location = new System.Drawing.Point(265, 607);
            this.pbEdit.Margin = new System.Windows.Forms.Padding(4);
            this.pbEdit.Name = "pbEdit";
            this.pbEdit.Size = new System.Drawing.Size(80, 71);
            this.pbEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEdit.TabIndex = 132;
            this.pbEdit.TabStop = false;
            this.pbEdit.MouseEnter += new System.EventHandler(this.pbEdit_MouseEnter);
            this.pbEdit.MouseLeave += new System.EventHandler(this.pbEdit_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1713, 177);
            this.panel1.TabIndex = 128;
            // 
            // RoomTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 743);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.gbInfor);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pbAdd);
            this.Controls.Add(this.pbDelete);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.dgvTypeRoom);
            this.Controls.Add(this.pbBack);
            this.Controls.Add(this.pbEdit);
            this.Controls.Add(this.panel1);
            this.Name = "RoomTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomType";
            this.Load += new System.EventHandler(this.RoomType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            this.gbInfor.ResumeLayout(false);
            this.gbInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEdit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.PictureBox pbCancel;
        private System.Windows.Forms.GroupBox gbInfor;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.DataGridView dgvTypeRoom;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbEdit;
        private System.Windows.Forms.Panel panel1;
    }
}