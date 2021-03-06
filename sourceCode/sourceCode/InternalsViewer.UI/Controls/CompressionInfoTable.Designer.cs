namespace InternalsViewer.UI.Controls
{
    partial class CompressionInfoTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.compressionInfoPanel = new System.Windows.Forms.Panel();
            this.offsetDataGridView = new System.Windows.Forms.DataGridView();
            this.StructureColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compressionInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // compressionInfoPanel
            // 
            this.compressionInfoPanel.Controls.Add(this.offsetDataGridView);
            this.compressionInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.compressionInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.compressionInfoPanel.Name = "compressionInfoPanel";
            this.compressionInfoPanel.Size = new System.Drawing.Size(150, 150);
            this.compressionInfoPanel.TabIndex = 2;
            // 
            // offsetDataGridView
            // 
            this.offsetDataGridView.AllowUserToAddRows = false;
            this.offsetDataGridView.AllowUserToDeleteRows = false;
            this.offsetDataGridView.AllowUserToResizeRows = false;
            this.offsetDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.offsetDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.offsetDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.offsetDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.offsetDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.offsetDataGridView.ColumnHeadersHeight = 22;
            this.offsetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.offsetDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StructureColumn,
            this.ValueColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.offsetDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.offsetDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.offsetDataGridView.GridColor = System.Drawing.Color.Gainsboro;
            this.offsetDataGridView.Location = new System.Drawing.Point(0, 0);
            this.offsetDataGridView.MultiSelect = false;
            this.offsetDataGridView.Name = "offsetDataGridView";
            this.offsetDataGridView.ReadOnly = true;
            this.offsetDataGridView.RowHeadersVisible = false;
            this.offsetDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.offsetDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.offsetDataGridView.Size = new System.Drawing.Size(150, 150);
            this.offsetDataGridView.TabIndex = 4;
            this.offsetDataGridView.SelectionChanged += new System.EventHandler(this.OffsetDataGridView_SelectionChanged);
            // 
            // StructureColumn
            // 
            this.StructureColumn.DataPropertyName = "Structure";
            this.StructureColumn.HeaderText = "";
            this.StructureColumn.Name = "StructureColumn";
            this.StructureColumn.ReadOnly = true;
            this.StructureColumn.Visible = false;
            // 
            // ValueColumn
            // 
            this.ValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueColumn.DataPropertyName = "Description";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.ValueColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.ValueColumn.HeaderText = "Compression Info";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            // 
            // CompressionInfoTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.compressionInfoPanel);
            this.Name = "CompressionInfoTable";
            this.compressionInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.offsetDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel compressionInfoPanel;
        private System.Windows.Forms.DataGridView offsetDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn StructureColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}
