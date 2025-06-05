using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    internal class InventoryIcon : StackedIcons {
        private static readonly IconManager IM = IconManager.Instance;

        private int value = 999;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Value {
            get {
                return this.value;
            } 
            set {
                if (value >= images.Length) {
                    value = images.Length - 1;
                }
                if (this.value != value) {
                    this.value = value;
                    UpdateIcon();
                }
            }
        }

        private Image[][] images = Array.Empty<Image[]>();
        private string[][] imageSources = Array.Empty<string[]>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CellId { get; set; } = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[][] ImageSets {
            set {
                images = value.Select(row => row.Select(item => IM.GetImage($"items/{item}")).ToArray()).ToArray();
                imageSources = value.Select(row => row.Select(item => $"icons/items/{item}.png").ToArray()).ToArray();
                UpdateIcon();
            }
        }

        public InventoryIcon() : base() {
            Dock = DockStyle.Fill;
            Margin = new Padding(0);
            MouseDown += InventoryIcon_MouseDown;
        }

        public void UpdateBroadcast() {
            if (CellId.Length > 0) {
                if (Value < imageSources.Length) {
                    // TrackerManager.Instance.Tracker?.UpdateItem(CellId, imageSources[Value]);
                }
            }
        }

        private void UpdateIcon() {
            if (Value < images.Length) {
                Icons.Clear();
                Icons.AddRange(images[Value]);
                Refresh();
            }
            UpdateBroadcast();
        }

        private void InventoryIcon_MouseDown(object? sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (Value < images.Length - 1) {
                    Value++;
                }
            } else if (e.Button == MouseButtons.Right) {
                if (Value > 0) {
                    Value--;
                }
            }
        }
    }
}
