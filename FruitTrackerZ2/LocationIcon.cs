using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    public class LocationIcon : StackedIcons {
        private static readonly IconManager IM = IconManager.Instance;
        private static readonly Image CROSS = IM.GetImage("overlays/cross");

        public event Action<Point>? OnCaptureClick;

        private bool value = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Value {
            get {
                return this.value;
            } 
            set {
                if (this.value != value) {
                    this.value = value;
                    this.UpdateIcon();
                }
            }
        }

        private Image UncheckedImg;
        private Image CheckedImg;
        private List<Image> ItemImgs = new();

        // private string[][] imageSources = Array.Empty<string[]>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CellId { get; set; } = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string? ItemId {
            set {
                this.ItemImgs.Clear();
                if (value != null) {
                    this.ItemImgs.Add(IM.GetImage($"{value}#outline"));
                    this.ItemImgs.Add(IM.GetImage(value));
                }
                this.UpdateIcon();
            }
        }

        public LocationIcon(string image) : base() {
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.MouseDown += InventoryIcon_MouseDown;

            this.UncheckedImg = IM.GetImage(image);
            this.CheckedImg = IM.GetImage($"{image}#inactive");
            this.UpdateIcon();
        }

        public void UpdateBroadcast() {
            if (CellId.Length > 0) {
                // if (Value < imageSources.Length) {
                //    // TrackerManager.Instance.Tracker?.UpdateItem(CellId, imageSources[Value]);
                // }
            }
        }

        private void UpdateIcon() {
            this.Icons.Clear();
            this.Icons.Add(this.Value ? this.CheckedImg : this.UncheckedImg);
            if (!this.Value) {
                this.Icons.AddRange(this.ItemImgs);
            } else if (this.Value) {
                this.Icons.Add(CROSS);
            }

            this.Refresh();
            this.UpdateBroadcast();
        }

        private void InventoryIcon_MouseDown(object? sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                this.Value = !this.Value;
            } else if (e.Button == MouseButtons.Right) {
                if (this.ItemImgs.Count > 0) {
                    this.ItemId = null;
                } else {
                    this.OnCaptureClick?.Invoke(PointToScreen(e.Location));
                }
            }
        }
    }
}
