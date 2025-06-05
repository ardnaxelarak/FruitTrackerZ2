namespace FruitTrackerZ2 {
    partial class InventoryTable {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            itemLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            SuspendLayout();
            // 
            // itemLayoutPanel
            // 
            itemLayoutPanel.ColumnCount = 6;
            itemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            itemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            itemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            itemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            itemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            itemLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.666666F));
            itemLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            itemLayoutPanel.Location = new System.Drawing.Point(0, 0);
            itemLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            itemLayoutPanel.Name = "itemLayoutPanel";
            itemLayoutPanel.RowCount = 4;
            itemLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            itemLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            itemLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            itemLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            itemLayoutPanel.Size = new System.Drawing.Size(252, 168);
            itemLayoutPanel.TabIndex = 0;
            // 
            // InventoryTable
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(itemLayoutPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "InventoryTable";
            Size = new System.Drawing.Size(252, 168);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel itemLayoutPanel;
    }
}
