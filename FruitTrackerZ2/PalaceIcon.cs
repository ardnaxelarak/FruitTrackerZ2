using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    internal class PalaceIcon : StackedIcons {
        private static readonly IconManager IM = IconManager.Instance;
        private static readonly Image[] LOCATIONS = new Image[] {
            IM.GetImage("overlays/w"),
            IM.GetImage("overlays/e"),
            IM.GetImage("overlays/mi"),
            IM.GetImage("overlays/dv"),
        };

        private int value = 0;

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

        private Image PillarImg;

        // private string[][] imageSources = Array.Empty<string[]>();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CellId { get; set; } = "";

        public PalaceIcon(string image) : base() {
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.MouseDown += InventoryIcon_MouseDown;

            this.PillarImg = IM.GetImage(image);
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
            this.Icons.Add(this.PillarImg);
            if (this.Value > 0) {
                this.Icons.Add(LOCATIONS[this.Value - 1]);
            }

            this.Refresh();
            this.UpdateBroadcast();
        }

        private void InventoryIcon_MouseDown(object? sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (Value < LOCATIONS.Length) {
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
