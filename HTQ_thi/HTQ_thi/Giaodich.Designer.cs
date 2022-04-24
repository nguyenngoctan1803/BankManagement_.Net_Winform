
namespace HTQ_thi
{
    partial class Giaodich
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.branch_text = new System.Windows.Forms.Label();
            this.naptien_btn = new System.Windows.Forms.Button();
            this.loaitk_cbb = new System.Windows.Forms.ComboBox();
            this.dgvgiaodich = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sotien_text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ruttien_btn = new System.Windows.Forms.Button();
            this.sotk_text = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gioitinh_text = new System.Windows.Forms.TextBox();
            this.sdt_text = new System.Windows.Forms.TextBox();
            this.chinhanhTK_text = new System.Windows.Forms.TextBox();
            this.sodu_text = new System.Windows.Forms.TextBox();
            this.ngaycap_text = new System.Windows.Forms.TextBox();
            this.cmnd_text = new System.Windows.Forms.TextBox();
            this.ngaysinh_text = new System.Windows.Forms.TextBox();
            this.diachi_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.chinhanhGD_cbb = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ma_nv_lb = new System.Windows.Forms.Label();
            this.logout_btn = new System.Windows.Forms.Button();
            this.login_pnl = new System.Windows.Forms.Panel();
            this.error_lb = new System.Windows.Forms.Label();
            this.login_nv_btn = new System.Windows.Forms.Button();
            this.pass_nv_text = new System.Windows.Forms.TextBox();
            this.user_nv_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvgiaodich)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.login_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // branch_text
            // 
            this.branch_text.AutoSize = true;
            this.branch_text.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.branch_text.Location = new System.Drawing.Point(13, 9);
            this.branch_text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.branch_text.Name = "branch_text";
            this.branch_text.Size = new System.Drawing.Size(82, 21);
            this.branch_text.TabIndex = 1;
            this.branch_text.Tag = "Thủ Đức";
            this.branch_text.Text = "Chi Nhánh";
            // 
            // naptien_btn
            // 
            this.naptien_btn.BackColor = System.Drawing.Color.Green;
            this.naptien_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.naptien_btn.ForeColor = System.Drawing.Color.Transparent;
            this.naptien_btn.Location = new System.Drawing.Point(72, 218);
            this.naptien_btn.Margin = new System.Windows.Forms.Padding(4);
            this.naptien_btn.Name = "naptien_btn";
            this.naptien_btn.Size = new System.Drawing.Size(134, 35);
            this.naptien_btn.TabIndex = 2;
            this.naptien_btn.Text = "Nạp tiền";
            this.naptien_btn.UseVisualStyleBackColor = false;
            this.naptien_btn.Click += new System.EventHandler(this.naptien_btn_Click);
            // 
            // loaitk_cbb
            // 
            this.loaitk_cbb.FormattingEnabled = true;
            this.loaitk_cbb.Location = new System.Drawing.Point(166, 110);
            this.loaitk_cbb.Margin = new System.Windows.Forms.Padding(4);
            this.loaitk_cbb.Name = "loaitk_cbb";
            this.loaitk_cbb.Size = new System.Drawing.Size(248, 29);
            this.loaitk_cbb.TabIndex = 5;
            this.loaitk_cbb.SelectedIndexChanged += new System.EventHandler(this.cbloaigd_SelectedIndexChanged);
            // 
            // dgvgiaodich
            // 
            this.dgvgiaodich.AllowUserToAddRows = false;
            this.dgvgiaodich.AllowUserToDeleteRows = false;
            this.dgvgiaodich.AllowUserToResizeColumns = false;
            this.dgvgiaodich.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Format = "g";
            dataGridViewCellStyle1.NullValue = null;
            this.dgvgiaodich.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvgiaodich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvgiaodich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvgiaodich.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvgiaodich.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvgiaodich.ColumnHeadersHeight = 29;
            this.dgvgiaodich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvgiaodich.EnableHeadersVisualStyles = false;
            this.dgvgiaodich.Location = new System.Drawing.Point(16, 362);
            this.dgvgiaodich.Margin = new System.Windows.Forms.Padding(4);
            this.dgvgiaodich.MultiSelect = false;
            this.dgvgiaodich.Name = "dgvgiaodich";
            this.dgvgiaodich.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvgiaodich.RowHeadersVisible = false;
            this.dgvgiaodich.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvgiaodich.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvgiaodich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvgiaodich.Size = new System.Drawing.Size(1270, 271);
            this.dgvgiaodich.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Loại tài khoản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(574, 337);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lịch Sủ Giao Dịch";
            // 
            // sotien_text
            // 
            this.sotien_text.Location = new System.Drawing.Point(166, 171);
            this.sotien_text.Margin = new System.Windows.Forms.Padding(4);
            this.sotien_text.Name = "sotien_text";
            this.sotien_text.Size = new System.Drawing.Size(248, 28);
            this.sotien_text.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 174);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 21);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số tiền";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ruttien_btn);
            this.groupBox1.Controls.Add(this.naptien_btn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.sotk_text);
            this.groupBox1.Controls.Add(this.sotien_text);
            this.groupBox1.Controls.Add(this.loaitk_cbb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(28, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(460, 273);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giao dịch nạp / rút";
            // 
            // ruttien_btn
            // 
            this.ruttien_btn.BackColor = System.Drawing.Color.Red;
            this.ruttien_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ruttien_btn.ForeColor = System.Drawing.Color.Transparent;
            this.ruttien_btn.Location = new System.Drawing.Point(256, 218);
            this.ruttien_btn.Margin = new System.Windows.Forms.Padding(4);
            this.ruttien_btn.Name = "ruttien_btn";
            this.ruttien_btn.Size = new System.Drawing.Size(131, 35);
            this.ruttien_btn.TabIndex = 13;
            this.ruttien_btn.Text = "Rút tiền";
            this.ruttien_btn.UseVisualStyleBackColor = false;
            this.ruttien_btn.Click += new System.EventHandler(this.ruttien_btn_Click);
            // 
            // sotk_text
            // 
            this.sotk_text.Location = new System.Drawing.Point(166, 51);
            this.sotk_text.Margin = new System.Windows.Forms.Padding(4);
            this.sotk_text.Name = "sotk_text";
            this.sotk_text.Size = new System.Drawing.Size(248, 28);
            this.sotk_text.TabIndex = 11;
            this.sotk_text.Leave += new System.EventHandler(this.sotk_text_MouseLeave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.gioitinh_text);
            this.groupBox2.Controls.Add(this.sdt_text);
            this.groupBox2.Controls.Add(this.chinhanhTK_text);
            this.groupBox2.Controls.Add(this.sodu_text);
            this.groupBox2.Controls.Add(this.ngaycap_text);
            this.groupBox2.Controls.Add(this.cmnd_text);
            this.groupBox2.Controls.Add(this.ngaysinh_text);
            this.groupBox2.Controls.Add(this.diachi_text);
            this.groupBox2.Controls.Add(this.name_text);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(533, 42);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(729, 273);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin tài khoản";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(242, 240);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 21);
            this.label15.TabIndex = 17;
            this.label15.Text = "Số Dư";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(387, 198);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 21);
            this.label14.TabIndex = 7;
            this.label14.Text = "Ngày Cấp";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 21);
            this.label12.TabIndex = 7;
            this.label12.Text = "Giới tính";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(25, 198);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 21);
            this.label13.TabIndex = 7;
            this.label13.Text = "Chi Nhánh";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(388, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Số ĐT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(387, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "CMND";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(387, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "Địa Chỉ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ngày Sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Họ Tên";
            // 
            // gioitinh_text
            // 
            this.gioitinh_text.Location = new System.Drawing.Point(120, 142);
            this.gioitinh_text.Margin = new System.Windows.Forms.Padding(4);
            this.gioitinh_text.Name = "gioitinh_text";
            this.gioitinh_text.ReadOnly = true;
            this.gioitinh_text.Size = new System.Drawing.Size(216, 28);
            this.gioitinh_text.TabIndex = 6;
            // 
            // sdt_text
            // 
            this.sdt_text.Location = new System.Drawing.Point(483, 32);
            this.sdt_text.Margin = new System.Windows.Forms.Padding(4);
            this.sdt_text.Name = "sdt_text";
            this.sdt_text.ReadOnly = true;
            this.sdt_text.Size = new System.Drawing.Size(216, 28);
            this.sdt_text.TabIndex = 6;
            // 
            // chinhanhTK_text
            // 
            this.chinhanhTK_text.Location = new System.Drawing.Point(120, 195);
            this.chinhanhTK_text.Margin = new System.Windows.Forms.Padding(4);
            this.chinhanhTK_text.Name = "chinhanhTK_text";
            this.chinhanhTK_text.ReadOnly = true;
            this.chinhanhTK_text.Size = new System.Drawing.Size(216, 28);
            this.chinhanhTK_text.TabIndex = 6;
            // 
            // sodu_text
            // 
            this.sodu_text.Location = new System.Drawing.Point(302, 237);
            this.sodu_text.Margin = new System.Windows.Forms.Padding(4);
            this.sodu_text.Name = "sodu_text";
            this.sodu_text.ReadOnly = true;
            this.sodu_text.Size = new System.Drawing.Size(216, 28);
            this.sodu_text.TabIndex = 6;
            // 
            // ngaycap_text
            // 
            this.ngaycap_text.Location = new System.Drawing.Point(483, 195);
            this.ngaycap_text.Margin = new System.Windows.Forms.Padding(4);
            this.ngaycap_text.Name = "ngaycap_text";
            this.ngaycap_text.ReadOnly = true;
            this.ngaycap_text.Size = new System.Drawing.Size(216, 28);
            this.ngaycap_text.TabIndex = 6;
            // 
            // cmnd_text
            // 
            this.cmnd_text.Location = new System.Drawing.Point(483, 141);
            this.cmnd_text.Margin = new System.Windows.Forms.Padding(4);
            this.cmnd_text.Name = "cmnd_text";
            this.cmnd_text.ReadOnly = true;
            this.cmnd_text.Size = new System.Drawing.Size(216, 28);
            this.cmnd_text.TabIndex = 5;
            // 
            // ngaysinh_text
            // 
            this.ngaysinh_text.Location = new System.Drawing.Point(120, 86);
            this.ngaysinh_text.Margin = new System.Windows.Forms.Padding(4);
            this.ngaysinh_text.Name = "ngaysinh_text";
            this.ngaysinh_text.ReadOnly = true;
            this.ngaysinh_text.Size = new System.Drawing.Size(216, 28);
            this.ngaysinh_text.TabIndex = 5;
            // 
            // diachi_text
            // 
            this.diachi_text.Location = new System.Drawing.Point(483, 86);
            this.diachi_text.Margin = new System.Windows.Forms.Padding(4);
            this.diachi_text.Name = "diachi_text";
            this.diachi_text.ReadOnly = true;
            this.diachi_text.Size = new System.Drawing.Size(216, 28);
            this.diachi_text.TabIndex = 0;
            // 
            // name_text
            // 
            this.name_text.Location = new System.Drawing.Point(120, 35);
            this.name_text.Margin = new System.Windows.Forms.Padding(4);
            this.name_text.Name = "name_text";
            this.name_text.ReadOnly = true;
            this.name_text.Size = new System.Drawing.Size(216, 28);
            this.name_text.TabIndex = 0;
            // 
            // chinhanhGD_cbb
            // 
            this.chinhanhGD_cbb.BackColor = System.Drawing.Color.CadetBlue;
            this.chinhanhGD_cbb.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chinhanhGD_cbb.FormattingEnabled = true;
            this.chinhanhGD_cbb.Location = new System.Drawing.Point(105, 6);
            this.chinhanhGD_cbb.Name = "chinhanhGD_cbb";
            this.chinhanhGD_cbb.Size = new System.Drawing.Size(167, 29);
            this.chinhanhGD_cbb.TabIndex = 15;
            this.chinhanhGD_cbb.SelectedIndexChanged += new System.EventHandler(this.chinhanhGD_cbb_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label16.Location = new System.Drawing.Point(278, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 21);
            this.label16.TabIndex = 17;
            this.label16.Text = "Mã NV";
            // 
            // ma_nv_lb
            // 
            this.ma_nv_lb.AutoSize = true;
            this.ma_nv_lb.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ma_nv_lb.Location = new System.Drawing.Point(342, 9);
            this.ma_nv_lb.Name = "ma_nv_lb";
            this.ma_nv_lb.Size = new System.Drawing.Size(205, 21);
            this.ma_nv_lb.TabIndex = 18;
            this.ma_nv_lb.Text = "mã nhân viên đã đăng nhập";
            // 
            // logout_btn
            // 
            this.logout_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.logout_btn.ForeColor = System.Drawing.Color.Transparent;
            this.logout_btn.Location = new System.Drawing.Point(1169, 6);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(117, 29);
            this.logout_btn.TabIndex = 19;
            this.logout_btn.Text = "Đăng Xuất";
            this.logout_btn.UseVisualStyleBackColor = true;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // login_pnl
            // 
            this.login_pnl.Controls.Add(this.error_lb);
            this.login_pnl.Controls.Add(this.login_nv_btn);
            this.login_pnl.Controls.Add(this.pass_nv_text);
            this.login_pnl.Controls.Add(this.user_nv_text);
            this.login_pnl.Controls.Add(this.label1);
            this.login_pnl.Controls.Add(this.label11);
            this.login_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_pnl.Location = new System.Drawing.Point(0, 0);
            this.login_pnl.Name = "login_pnl";
            this.login_pnl.Size = new System.Drawing.Size(1299, 633);
            this.login_pnl.TabIndex = 20;
            // 
            // error_lb
            // 
            this.error_lb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.error_lb.AutoSize = true;
            this.error_lb.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.error_lb.ForeColor = System.Drawing.Color.Red;
            this.error_lb.Location = new System.Drawing.Point(529, 274);
            this.error_lb.Name = "error_lb";
            this.error_lb.Size = new System.Drawing.Size(243, 21);
            this.error_lb.TabIndex = 22;
            this.error_lb.Text = "Tên đăng nhập hoặc mật khẩu sai";
            this.error_lb.Visible = false;
            // 
            // login_nv_btn
            // 
            this.login_nv_btn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.login_nv_btn.BackColor = System.Drawing.Color.DarkTurquoise;
            this.login_nv_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login_nv_btn.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.login_nv_btn.Location = new System.Drawing.Point(578, 302);
            this.login_nv_btn.Name = "login_nv_btn";
            this.login_nv_btn.Size = new System.Drawing.Size(149, 32);
            this.login_nv_btn.TabIndex = 2;
            this.login_nv_btn.Text = "Đăng Nhập";
            this.login_nv_btn.UseVisualStyleBackColor = false;
            this.login_nv_btn.Click += new System.EventHandler(this.login_nv_btn_Click);
            // 
            // pass_nv_text
            // 
            this.pass_nv_text.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pass_nv_text.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.pass_nv_text.Location = new System.Drawing.Point(579, 216);
            this.pass_nv_text.Name = "pass_nv_text";
            this.pass_nv_text.Size = new System.Drawing.Size(236, 28);
            this.pass_nv_text.TabIndex = 1;
            // 
            // user_nv_text
            // 
            this.user_nv_text.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.user_nv_text.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.user_nv_text.Location = new System.Drawing.Point(579, 170);
            this.user_nv_text.Name = "user_nv_text";
            this.user_nv_text.Size = new System.Drawing.Size(236, 28);
            this.user_nv_text.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(449, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mật Khẩu";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(449, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 21);
            this.label11.TabIndex = 18;
            this.label11.Text = "Tên Đăng Nhập";
            // 
            // Giaodich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1299, 633);
            this.Controls.Add(this.login_pnl);
            this.Controls.Add(this.logout_btn);
            this.Controls.Add(this.ma_nv_lb);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chinhanhGD_cbb);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvgiaodich);
            this.Controls.Add(this.branch_text);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Giaodich";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giaodich";
            this.Load += new System.EventHandler(this.Giaodich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvgiaodich)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.login_pnl.ResumeLayout(false);
            this.login_pnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label branch_text;
        private System.Windows.Forms.Button naptien_btn;
        private System.Windows.Forms.ComboBox loaitk_cbb;
        private System.Windows.Forms.DataGridView dgvgiaodich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox sotien_text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox sdt_text;
        private System.Windows.Forms.TextBox ngaysinh_text;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Button ruttien_btn;
        private System.Windows.Forms.TextBox sotk_text;
        private System.Windows.Forms.TextBox cmnd_text;
        private System.Windows.Forms.TextBox diachi_text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gioitinh_text;
        private System.Windows.Forms.ComboBox chinhanhGD_cbb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox chinhanhTK_text;
        private System.Windows.Forms.TextBox ngaycap_text;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox sodu_text;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label ma_nv_lb;
        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Panel login_pnl;
        private System.Windows.Forms.Label error_lb;
        private System.Windows.Forms.Button login_nv_btn;
        private System.Windows.Forms.TextBox pass_nv_text;
        private System.Windows.Forms.TextBox user_nv_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
    }
}