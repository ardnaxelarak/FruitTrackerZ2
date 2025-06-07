using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    internal class PalaceIcon : StackedIcons {
        private const string COMPLETED_SOURCE = "palaces/completepalace_dark";

        private static readonly IconManager IM = IconManager.Instance;
        private static readonly Image COMPLETED = IM.GetImage(COMPLETED_SOURCE);
        private static readonly string[] LOCATIONS_SOURCE = new string[] {
            "overlays/w",
            "overlays/e",
            "overlays/mi",
            "overlays/dv",
        };
        private static readonly Image[] LOCATIONS = LOCATIONS_SOURCE.Select(source => IM.GetImage(source)).ToArray();

        private int value = 0;
        private bool completed = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Value {
            get {
                return this.value;
            } 
            set {
                if (value > LOCATIONS.Length) {
                    value = LOCATIONS.Length;
                }
                if (this.value != value) {
                    this.value = value;
                    this.UpdateIcon();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Completed {
            get {
                return this.completed;
            } 
            set {
                if (this.completed != value) {
                    this.completed = value;
                    this.UpdateIcon();
                }
            }
        }

        private readonly Image pillarImg;
        private readonly string pillarSrc;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CellId { get; set; } = "";

        public PalaceIcon(string image) : base() {
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.MouseDown += InventoryIcon_MouseDown;

            this.pillarSrc = image;
            this.pillarImg = IM.GetImage(image);
            this.UpdateIcon();
        }

        public void UpdateBroadcast() {
            if (CellId.Length > 0) {
                var list = new List<string>();
                if (this.Completed) {
                    list.Add($"icons/{COMPLETED_SOURCE}.png");
                } else {
                    list.Add($"icons/{this.pillarSrc}.png");
                }

                if (this.Value > 0 && this.Value <= LOCATIONS_SOURCE.Length) {
                    list.Add($"icons/{LOCATIONS_SOURCE[this.Value - 1]}.png");
                }

                TrackerManager.Instance.Tracker?.UpdateItem(CellId, list.ToArray());
            }
        }

        private void UpdateIcon() {
            this.Icons.Clear();
            if (this.Completed) {
                this.Icons.Add(COMPLETED);
            } else {
                this.Icons.Add(this.pillarImg);
            }

            if (this.Value > 0 && this.Value <= LOCATIONS.Length) {
                this.Icons.Add(LOCATIONS[this.Value - 1]);
            }

            this.Refresh();
            this.UpdateBroadcast();
        }

        private void InventoryIcon_MouseDown(object? sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (this.Value < LOCATIONS.Length) {
                    this.Value++;
                }
            } else if (e.Button == MouseButtons.Right) {
                if (this.Value > 0) {
                    this.Value--;
                }
            } else if (e.Button == MouseButtons.Middle) {
                this.Completed = !this.Completed;
            }
        }
    }
}
