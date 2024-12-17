namespace Quan_ly_Ban_Thuoc
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbXinChao = new System.Windows.Forms.Label();
            this.dgvProductCart = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.listViewMedicines = new System.Windows.Forms.ListView();
            this.lstId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtKhachTra = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenustripMedicine = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddMedicine = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQLThuoc = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thuốcHếtHạnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCart)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(483, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ THUỐC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(945, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giỏ Hàng";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(261, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(288, 22);
            this.textBox2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(555, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(161, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Danh sách thuốc";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(134, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lbXinChao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 609);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 61);
            this.panel1.TabIndex = 9;
            // 
            // lbXinChao
            // 
            this.lbXinChao.AutoSize = true;
            this.lbXinChao.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbXinChao.Location = new System.Drawing.Point(932, 11);
            this.lbXinChao.Name = "lbXinChao";
            this.lbXinChao.Size = new System.Drawing.Size(135, 19);
            this.lbXinChao.TabIndex = 0;
            this.lbXinChao.Text = "Hello {username}";
            // 
            // dgvProductCart
            // 
            this.dgvProductCart.AllowUserToAddRows = false;
            this.dgvProductCart.AllowUserToDeleteRows = false;
            this.dgvProductCart.AllowUserToOrderColumns = true;
            this.dgvProductCart.AllowUserToResizeColumns = false;
            this.dgvProductCart.AllowUserToResizeRows = false;
            this.dgvProductCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProductCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.dgvCode,
            this.dgvName,
            this.dgvDonVi,
            this.dgvQuantity,
            this.dgvPrice,
            this.dgvAmount,
            this.dgvDelete});
            this.dgvProductCart.Location = new System.Drawing.Point(639, 129);
            this.dgvProductCart.Name = "dgvProductCart";
            this.dgvProductCart.RowHeadersWidth = 51;
            this.dgvProductCart.RowTemplate.Height = 30;
            this.dgvProductCart.Size = new System.Drawing.Size(631, 310);
            this.dgvProductCart.TabIndex = 10;
            this.dgvProductCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductCart_CellClick);
            this.dgvProductCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductCart_CellValueChanged);
            // 
            // Index
            // 
            this.Index.FillWeight = 30.41129F;
            this.Index.HeaderText = "#";
            this.Index.MinimumWidth = 6;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // dgvCode
            // 
            this.dgvCode.FillWeight = 29.69769F;
            this.dgvCode.HeaderText = "id";
            this.dgvCode.MinimumWidth = 6;
            this.dgvCode.Name = "dgvCode";
            this.dgvCode.ReadOnly = true;
            // 
            // dgvName
            // 
            this.dgvName.FillWeight = 86.29176F;
            this.dgvName.HeaderText = "Tên";
            this.dgvName.MinimumWidth = 6;
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvDonVi
            // 
            this.dgvDonVi.FillWeight = 32.61308F;
            this.dgvDonVi.HeaderText = "DVT";
            this.dgvDonVi.MinimumWidth = 6;
            this.dgvDonVi.Name = "dgvDonVi";
            this.dgvDonVi.ReadOnly = true;
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.FillWeight = 17.81734F;
            this.dgvQuantity.HeaderText = "SL";
            this.dgvQuantity.MinimumWidth = 6;
            this.dgvQuantity.Name = "dgvQuantity";
            // 
            // dgvPrice
            // 
            this.dgvPrice.FillWeight = 48.33517F;
            this.dgvPrice.HeaderText = "Giá";
            this.dgvPrice.MinimumWidth = 6;
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.FillWeight = 44.26442F;
            this.dgvAmount.HeaderText = "T.Tiền";
            this.dgvAmount.MinimumWidth = 6;
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            // 
            // dgvDelete
            // 
            this.dgvDelete.FillWeight = 15.5015F;
            this.dgvDelete.HeaderText = "";
            this.dgvDelete.Image = global::Quan_ly_Ban_Thuoc.Properties.Resources.remove;
            this.dgvDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvDelete.MinimumWidth = 10;
            this.dgvDelete.Name = "dgvDelete";
            this.dgvDelete.ReadOnly = true;
            this.dgvDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // listViewMedicines
            // 
            this.listViewMedicines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewMedicines.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listViewMedicines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstId,
            this.lstName,
            this.lstUnit,
            this.lstQuantity,
            this.lstPrice});
            this.listViewMedicines.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewMedicines.FullRowSelect = true;
            this.listViewMedicines.GridLines = true;
            this.listViewMedicines.HideSelection = false;
            this.listViewMedicines.Location = new System.Drawing.Point(12, 129);
            this.listViewMedicines.Name = "listViewMedicines";
            this.listViewMedicines.Size = new System.Drawing.Size(621, 475);
            this.listViewMedicines.TabIndex = 11;
            this.listViewMedicines.UseCompatibleStateImageBehavior = false;
            this.listViewMedicines.View = System.Windows.Forms.View.Details;
            this.listViewMedicines.SelectedIndexChanged += new System.EventHandler(this.listViewMedicines_SelectedIndexChanged);
            // 
            // lstId
            // 
            this.lstId.Text = "ID";
            // 
            // lstName
            // 
            this.lstName.Text = "Tên thuốc";
            this.lstName.Width = 110;
            // 
            // lstUnit
            // 
            this.lstUnit.Text = "DVT";
            this.lstUnit.Width = 84;
            // 
            // lstQuantity
            // 
            this.lstQuantity.Text = "SL";
            this.lstQuantity.Width = 52;
            // 
            // lstPrice
            // 
            this.lstPrice.Text = "Giá tiền";
            this.lstPrice.Width = 89;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtKhachTra);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnPayment);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(639, 445);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 158);
            this.panel2.TabIndex = 12;
            // 
            // txtKhachTra
            // 
            this.txtKhachTra.Location = new System.Drawing.Point(449, 53);
            this.txtKhachTra.Name = "txtKhachTra";
            this.txtKhachTra.Size = new System.Drawing.Size(100, 22);
            this.txtKhachTra.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.GhostWhite;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(106, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 38);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.BackColor = System.Drawing.Color.Blue;
            this.btnPayment.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(405, 89);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(127, 38);
            this.btnPayment.TabIndex = 2;
            this.btnPayment.Text = "Thanh toán";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(524, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(25, 16);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0 đ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(15, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Khách trả";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(15, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tổng hóa đơn:";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 15.5015F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Quan_ly_Ban_Thuoc.Properties.Resources.remove;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 10;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 29;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::Quan_ly_Ban_Thuoc.Properties.Resources.icons8_refresh_40;
            this.btnRefresh.Location = new System.Drawing.Point(12, 94);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(30, 30);
            this.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.TabStop = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLogout,
            this.btnExit});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(101, 27);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 28);
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 28);
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MenustripMedicine
            // 
            this.MenustripMedicine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddMedicine,
            this.btnQLThuoc});
            this.MenustripMedicine.Name = "MenustripMedicine";
            this.MenustripMedicine.Size = new System.Drawing.Size(76, 27);
            this.MenustripMedicine.Text = "Thuốc";
            // 
            // btnAddMedicine
            // 
            this.btnAddMedicine.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddMedicine.Name = "btnAddMedicine";
            this.btnAddMedicine.Size = new System.Drawing.Size(211, 28);
            this.btnAddMedicine.Text = "Thêm thuốc";
            this.btnAddMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);
            // 
            // btnQLThuoc
            // 
            this.btnQLThuoc.Name = "btnQLThuoc";
            this.btnQLThuoc.Size = new System.Drawing.Size(211, 28);
            this.btnQLThuoc.Text = "Quản lý thuốc";
            this.btnQLThuoc.Click += new System.EventHandler(this.btnQLThuoc_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thuốcHếtHạnToolStripMenuItem,
            this.doanhThuToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(91, 27);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // thuốcHếtHạnToolStripMenuItem
            // 
            this.thuốcHếtHạnToolStripMenuItem.Name = "thuốcHếtHạnToolStripMenuItem";
            this.thuốcHếtHạnToolStripMenuItem.Size = new System.Drawing.Size(213, 28);
            this.thuốcHếtHạnToolStripMenuItem.Text = "Thuốc hết hạn";
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(213, 28);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.MenustripMedicine,
            this.báoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1282, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 670);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.listViewMedicines);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvProductCart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1300, 790);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý thuốc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductCart)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProductCart;
        private System.Windows.Forms.ListView listViewMedicines;
        private System.Windows.Forms.ColumnHeader lstId;
        private System.Windows.Forms.ColumnHeader lstName;
        private System.Windows.Forms.ColumnHeader lstUnit;
        private System.Windows.Forms.ColumnHeader lstQuantity;
        private System.Windows.Forms.ColumnHeader lstPrice;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbXinChao;
        public System.Windows.Forms.PictureBox btnRefresh;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnLogout;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem MenustripMedicine;
        private System.Windows.Forms.ToolStripMenuItem btnAddMedicine;
        private System.Windows.Forms.ToolStripMenuItem btnQLThuoc;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thuốcHếtHạnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewImageColumn dgvDelete;
        private System.Windows.Forms.TextBox txtKhachTra;
    }
}