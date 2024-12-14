namespace Quan_ly_Ban_Thuoc
{
    partial class frmQuanLyThuoc
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
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtHeader = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvMedicineData = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilter
            // 
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Location = new System.Drawing.Point(334, 61);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(88, 24);
            this.cbFilter.TabIndex = 13;
            // 
            // txtHeader
            // 
            this.txtHeader.AutoSize = true;
            this.txtHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeader.Location = new System.Drawing.Point(26, 18);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(216, 25);
            this.txtHeader.TabIndex = 11;
            this.txtHeader.Text = "Quản lý thông tin thuốc";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(428, 61);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(277, 22);
            this.txtSearch.TabIndex = 8;
            // 
            // dgvMedicineData
            // 
            this.dgvMedicineData.AllowUserToAddRows = false;
            this.dgvMedicineData.AllowUserToDeleteRows = false;
            this.dgvMedicineData.AllowUserToResizeColumns = false;
            this.dgvMedicineData.AllowUserToResizeRows = false;
            this.dgvMedicineData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMedicineData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicineData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvMedicineData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicineData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicineData.Location = new System.Drawing.Point(31, 109);
            this.dgvMedicineData.Name = "dgvMedicineData";
            this.dgvMedicineData.RowHeadersWidth = 51;
            this.dgvMedicineData.RowTemplate.Height = 30;
            this.dgvMedicineData.Size = new System.Drawing.Size(1223, 602);
            this.dgvMedicineData.TabIndex = 14;
            this.dgvMedicineData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicineData_CellClick);
            this.dgvMedicineData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicineData_CellEndEdit);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = global::Quan_ly_Ban_Thuoc.Properties.Resources.analysis_analytics_magnifier_search_locate_magnifyng_glass_icon_153884;
            this.btnRefresh.Location = new System.Drawing.Point(303, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 25);
            this.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Image = global::Quan_ly_Ban_Thuoc.Properties.Resources.spacefm_103907;
            this.btnHome.Location = new System.Drawing.Point(1204, 53);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(50, 50);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 9;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = global::Quan_ly_Ban_Thuoc.Properties.Resources.add_insert_plus_1588;
            this.btnAdd.Location = new System.Drawing.Point(31, 61);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(35, 35);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAdd.TabIndex = 9;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmQuanLyThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 743);
            this.Controls.Add(this.dgvMedicineData);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtHeader);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Name = "frmQuanLyThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLyThuoc";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicineData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbFilter;
        public System.Windows.Forms.PictureBox btnRefresh;
        public System.Windows.Forms.Label txtHeader;
        public System.Windows.Forms.PictureBox btnAdd;
        public System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvMedicineData;
        public System.Windows.Forms.PictureBox btnHome;
    }
}