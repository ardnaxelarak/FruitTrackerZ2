namespace FruitTrackerZ2
{
    partial class TrackerForm
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrackerForm));
            inventoryTable = new InventoryTable();
            statusStrip = new System.Windows.Forms.StatusStrip();
            spacerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            autoTrackingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            locationTable = new LocationTable();
            palaceTable1 = new PalaceTable();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // inventoryTable
            // 
            inventoryTable.Location = new System.Drawing.Point(13, 12);
            inventoryTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            inventoryTable.Name = "inventoryTable";
            inventoryTable.Size = new System.Drawing.Size(252, 168);
            inventoryTable.TabIndex = 0;
            // 
            // statusStrip
            // 
            statusStrip.AutoSize = false;
            statusStrip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { spacerLabel, autoTrackingLabel });
            statusStrip.Location = new System.Drawing.Point(0, 370);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new System.Drawing.Size(532, 36);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 1;
            // 
            // spacerLabel
            // 
            spacerLabel.Name = "spacerLabel";
            spacerLabel.Size = new System.Drawing.Size(483, 31);
            spacerLabel.Spring = true;
            // 
            // autoTrackingLabel
            // 
            autoTrackingLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            autoTrackingLabel.Image = Resources.gray_snes;
            autoTrackingLabel.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
            autoTrackingLabel.Name = "autoTrackingLabel";
            autoTrackingLabel.Size = new System.Drawing.Size(24, 34);
            autoTrackingLabel.MouseDown += autoTrackingLabel_MouseDown;
            // 
            // locationTable
            // 
            locationTable.Location = new System.Drawing.Point(64, 186);
            locationTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            locationTable.Name = "locationTable";
            locationTable.Size = new System.Drawing.Size(398, 168);
            locationTable.TabIndex = 2;
            // 
            // palaceTable1
            // 
            palaceTable1.Location = new System.Drawing.Point(269, 12);
            palaceTable1.Margin = new System.Windows.Forms.Padding(0);
            palaceTable1.Name = "palaceTable1";
            palaceTable1.Size = new System.Drawing.Size(252, 168);
            palaceTable1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(532, 406);
            Controls.Add(palaceTable1);
            Controls.Add(locationTable);
            Controls.Add(statusStrip);
            Controls.Add(inventoryTable);
            Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "FruitTracker";
            Load += TrackerForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private InventoryTable inventoryTable;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel spacerLabel;
        private System.Windows.Forms.ToolStripStatusLabel autoTrackingLabel;
        private LocationTable locationTable;
        private PalaceTable palaceTable1;
    }
}
