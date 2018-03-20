namespace QuanLySieuThi
{
    partial class frmKhachHang
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
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_XoaDT = new System.Windows.Forms.Button();
            this.btn_SuaDT = new System.Windows.Forms.Button();
            this.btn_ThemKh = new System.Windows.Forms.Button();
            this.btn_showKH = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxSDTKH = new System.Windows.Forms.TextBox();
            this.textBoxDiaChiKH = new System.Windows.Forms.TextBox();
            this.textBoxTenKh = new System.Windows.Forms.TextBox();
            this.textBoxMaKh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(741, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 32);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_XoaDT);
            this.groupBox2.Controls.Add(this.btn_SuaDT);
            this.groupBox2.Controls.Add(this.btn_ThemKh);
            this.groupBox2.Controls.Add(this.btn_showKH);
            this.groupBox2.Location = new System.Drawing.Point(712, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(146, 303);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btn_XoaDT
            // 
            this.btn_XoaDT.Location = new System.Drawing.Point(29, 214);
            this.btn_XoaDT.Name = "btn_XoaDT";
            this.btn_XoaDT.Size = new System.Drawing.Size(89, 30);
            this.btn_XoaDT.TabIndex = 3;
            this.btn_XoaDT.Text = "Xóa";
            this.btn_XoaDT.UseVisualStyleBackColor = true;
            this.btn_XoaDT.Click += new System.EventHandler(this.btn_XoaDT_Click);
            // 
            // btn_SuaDT
            // 
            this.btn_SuaDT.Location = new System.Drawing.Point(29, 154);
            this.btn_SuaDT.Name = "btn_SuaDT";
            this.btn_SuaDT.Size = new System.Drawing.Size(89, 30);
            this.btn_SuaDT.TabIndex = 2;
            this.btn_SuaDT.Text = "Sửa";
            this.btn_SuaDT.UseVisualStyleBackColor = true;
            this.btn_SuaDT.Click += new System.EventHandler(this.btn_SuaDT_Click);
            // 
            // btn_ThemKh
            // 
            this.btn_ThemKh.Location = new System.Drawing.Point(29, 90);
            this.btn_ThemKh.Name = "btn_ThemKh";
            this.btn_ThemKh.Size = new System.Drawing.Size(89, 30);
            this.btn_ThemKh.TabIndex = 1;
            this.btn_ThemKh.Text = "Thêm";
            this.btn_ThemKh.UseVisualStyleBackColor = true;
            this.btn_ThemKh.Click += new System.EventHandler(this.btn_ThemKh_Click);
            // 
            // btn_showKH
            // 
            this.btn_showKH.Location = new System.Drawing.Point(29, 35);
            this.btn_showKH.Name = "btn_showKH";
            this.btn_showKH.Size = new System.Drawing.Size(89, 30);
            this.btn_showKH.TabIndex = 0;
            this.btn_showKH.Text = "Hiển thị DS";
            this.btn_showKH.UseVisualStyleBackColor = true;
            this.btn_showKH.Click += new System.EventHandler(this.btn_showKH_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxStatus);
            this.groupBox1.Controls.Add(this.textBoxSDTKH);
            this.groupBox1.Controls.Add(this.textBoxDiaChiKH);
            this.groupBox1.Controls.Add(this.textBoxTenKh);
            this.groupBox1.Controls.Add(this.textBoxMaKh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 303);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(434, 96);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(179, 20);
            this.textBoxStatus.TabIndex = 16;
            // 
            // textBoxSDTKH
            // 
            this.textBoxSDTKH.Location = new System.Drawing.Point(432, 32);
            this.textBoxSDTKH.Name = "textBoxSDTKH";
            this.textBoxSDTKH.Size = new System.Drawing.Size(179, 20);
            this.textBoxSDTKH.TabIndex = 12;
            // 
            // textBoxDiaChiKH
            // 
            this.textBoxDiaChiKH.Location = new System.Drawing.Point(95, 160);
            this.textBoxDiaChiKH.Name = "textBoxDiaChiKH";
            this.textBoxDiaChiKH.Size = new System.Drawing.Size(179, 20);
            this.textBoxDiaChiKH.TabIndex = 11;
            // 
            // textBoxTenKh
            // 
            this.textBoxTenKh.Location = new System.Drawing.Point(95, 96);
            this.textBoxTenKh.Name = "textBoxTenKh";
            this.textBoxTenKh.Size = new System.Drawing.Size(179, 20);
            this.textBoxTenKh.TabIndex = 10;
            // 
            // textBoxMaKh
            // 
            this.textBoxMaKh.Location = new System.Drawing.Point(95, 31);
            this.textBoxMaKh.Name = "textBoxMaKh";
            this.textBoxMaKh.Size = new System.Drawing.Size(179, 20);
            this.textBoxMaKh.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(354, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "SDT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Đối Tác";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Đối Tác";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 309);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(869, 207);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 524);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_XoaDT;
        private System.Windows.Forms.Button btn_SuaDT;
        private System.Windows.Forms.Button btn_ThemKh;
        private System.Windows.Forms.Button btn_showKH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxSDTKH;
        private System.Windows.Forms.TextBox textBoxDiaChiKH;
        private System.Windows.Forms.TextBox textBoxTenKh;
        private System.Windows.Forms.TextBox textBoxMaKh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}