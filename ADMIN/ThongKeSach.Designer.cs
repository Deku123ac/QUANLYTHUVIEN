namespace ADMIN
{
    partial class ThongKeSach
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
            this.gbTuyChonThongKe = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btThoat = new System.Windows.Forms.Button();
            this.btThongKe = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gbTuyChonThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo cáo thống kê sách trong thư viện";
            // 
            // gbTuyChonThongKe
            // 
            this.gbTuyChonThongKe.Controls.Add(this.dataGridView1);
            this.gbTuyChonThongKe.Controls.Add(this.btThoat);
            this.gbTuyChonThongKe.Controls.Add(this.btThongKe);
            this.gbTuyChonThongKe.Controls.Add(this.comboBox1);
            this.gbTuyChonThongKe.Location = new System.Drawing.Point(12, 104);
            this.gbTuyChonThongKe.Name = "gbTuyChonThongKe";
            this.gbTuyChonThongKe.Size = new System.Drawing.Size(928, 492);
            this.gbTuyChonThongKe.TabIndex = 1;
            this.gbTuyChonThongKe.TabStop = false;
            this.gbTuyChonThongKe.Text = "Tùy chọn thống kê";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(56, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(815, 398);
            this.dataGridView1.TabIndex = 3;
            // 
            // btThoat
            // 
            this.btThoat.Location = new System.Drawing.Point(730, 30);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(105, 36);
            this.btThoat.TabIndex = 2;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btThongKe
            // 
            this.btThongKe.Location = new System.Drawing.Point(532, 30);
            this.btThongKe.Name = "btThongKe";
            this.btThongKe.Size = new System.Drawing.Size(105, 36);
            this.btThongKe.TabIndex = 1;
            this.btThongKe.Text = "Thống Kê";
            this.btThongKe.UseVisualStyleBackColor = true;
            this.btThongKe.Click += new System.EventHandler(this.btThongKe_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tất cả sách",
            "Sách đang mượn",
            "Sách đã trả"});
            this.comboBox1.Location = new System.Drawing.Point(171, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(221, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // ThongKeSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 608);
            this.Controls.Add(this.gbTuyChonThongKe);
            this.Controls.Add(this.label1);
            this.Name = "ThongKeSach";
            this.Text = "ThongKeSach";
            this.Load += new System.EventHandler(this.ThongKeSach_Load);
            this.gbTuyChonThongKe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTuyChonThongKe;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btThongKe;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}