namespace GoogleDrive
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnKetNoiTaiKhoanGoogle = new Button();
            label2 = new Label();
            txtDuongDanTep = new TextBox();
            btnChonTep = new Button();
            txtNhatKy = new TextBox();
            btnTaiLen = new Button();
            SignOut_btn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(136, 29);
            label1.Name = "label1";
            label1.Size = new Size(490, 69);
            label1.TabIndex = 0;
            label1.Text = "Upload File to GoogleDrive";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnKetNoiTaiKhoanGoogle
            // 
            btnKetNoiTaiKhoanGoogle.BackColor = Color.FromArgb(128, 255, 128);
            btnKetNoiTaiKhoanGoogle.Location = new Point(21, 69);
            btnKetNoiTaiKhoanGoogle.Name = "btnKetNoiTaiKhoanGoogle";
            btnKetNoiTaiKhoanGoogle.Size = new Size(169, 29);
            btnKetNoiTaiKhoanGoogle.TabIndex = 1;
            btnKetNoiTaiKhoanGoogle.Text = "Kết nối Google Drive";
            btnKetNoiTaiKhoanGoogle.UseVisualStyleBackColor = false;
            btnKetNoiTaiKhoanGoogle.Click += btnKetNoiTaiKhoanGoogle_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(21, 109);
            label2.Name = "label2";
            label2.Size = new Size(152, 23);
            label2.TabIndex = 2;
            label2.Text = "Đường dẫn tải lên:";
            // 
            // txtDuongDanTep
            // 
            txtDuongDanTep.Location = new Point(218, 108);
            txtDuongDanTep.Multiline = true;
            txtDuongDanTep.Name = "txtDuongDanTep";
            txtDuongDanTep.Size = new Size(382, 34);
            txtDuongDanTep.TabIndex = 3;
            // 
            // btnChonTep
            // 
            btnChonTep.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnChonTep.Location = new Point(648, 110);
            btnChonTep.Name = "btnChonTep";
            btnChonTep.Size = new Size(89, 37);
            btnChonTep.TabIndex = 4;
            btnChonTep.Text = "Chọn tệp";
            btnChonTep.UseVisualStyleBackColor = true;
            btnChonTep.Click += btnChonTep_Click_1;
            // 
            // txtNhatKy
            // 
            txtNhatKy.Location = new Point(12, 206);
            txtNhatKy.Multiline = true;
            txtNhatKy.Name = "txtNhatKy";
            txtNhatKy.Size = new Size(776, 232);
            txtNhatKy.TabIndex = 5;
            // 
            // btnTaiLen
            // 
            btnTaiLen.BackColor = Color.FromArgb(255, 255, 128);
            btnTaiLen.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            btnTaiLen.Location = new Point(218, 148);
            btnTaiLen.Name = "btnTaiLen";
            btnTaiLen.Size = new Size(89, 43);
            btnTaiLen.TabIndex = 6;
            btnTaiLen.Text = "Tải lên";
            btnTaiLen.UseVisualStyleBackColor = false;
            btnTaiLen.Click += btnTaiLen_Click_1;
            // 
            // SignOut_btn
            // 
            SignOut_btn.BackColor = Color.FromArgb(255, 224, 192);
            SignOut_btn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SignOut_btn.Location = new Point(580, 153);
            SignOut_btn.Name = "SignOut_btn";
            SignOut_btn.Size = new Size(208, 32);
            SignOut_btn.TabIndex = 7;
            SignOut_btn.Text = "Đăng xuất Google Drive";
            SignOut_btn.UseVisualStyleBackColor = false;
            SignOut_btn.Click += SignOut_btn_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(324, 148);
            button1.Name = "button1";
            button1.Size = new Size(119, 43);
            button1.TabIndex = 8;
            button1.Text = "Dừng tải lên";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(SignOut_btn);
            Controls.Add(btnTaiLen);
            Controls.Add(txtNhatKy);
            Controls.Add(btnChonTep);
            Controls.Add(txtDuongDanTep);
            Controls.Add(label2);
            Controls.Add(btnKetNoiTaiKhoanGoogle);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnKetNoiTaiKhoanGoogle;
        private Label label2;
        private TextBox txtDuongDanTep;
        private Button btnChonTep;
        private TextBox txtNhatKy;
        private Button btnTaiLen;
        private Button SignOut_btn;
        private Button button1;

        // txtGhiChu

        //this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
        //this.txtGhiChu.Location = new System.Drawing.Point(10, 230);
        //this.txtGhiChu.Multiline = true;
        //this.txtGhiChu.Name = "txtGhiChu";
        //this.txtGhiChu.ReadOnly = true;
        //this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        //this.txtGhiChu.Size = new System.Drawing.Size(702, 160);
        //this.txtGhiChu.TabIndex = 5;

    }
}