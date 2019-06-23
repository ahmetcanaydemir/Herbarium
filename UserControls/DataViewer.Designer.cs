namespace Herbarium
{
    partial class DataViewer
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgDataView = new Herbarium.DataViewer.OzelGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDataView
            // 
            this.dtgDataView.AllowUserToAddRows = false;
            this.dtgDataView.AllowUserToDeleteRows = false;
            this.dtgDataView.AllowUserToOrderColumns = true;
            this.dtgDataView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dtgDataView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgDataView.BackgroundColor = System.Drawing.Color.White;
            this.dtgDataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgDataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDataView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgDataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgDataView.Location = new System.Drawing.Point(0, 0);
            this.dtgDataView.Margin = new System.Windows.Forms.Padding(0);
            this.dtgDataView.Name = "dtgDataView";
            this.dtgDataView.ReadOnly = true;
            this.dtgDataView.RowHeadersVisible = false;
            this.dtgDataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dtgDataView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDataView.ShowEditingIcon = false;
            this.dtgDataView.Size = new System.Drawing.Size(793, 523);
            this.dtgDataView.TabIndex = 0;
            this.dtgDataView.VirtualMode = true;
            this.dtgDataView.DataSourceChanged += new System.EventHandler(this.dtgDataView_DataSourceChanged);
            this.dtgDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDataView_CellContentClick);
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtgDataView);
            this.Name = "DataViewer";
            this.Size = new System.Drawing.Size(793, 523);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public OzelGridView dtgDataView;
    }
}
