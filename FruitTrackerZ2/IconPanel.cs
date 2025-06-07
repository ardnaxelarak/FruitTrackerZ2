using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    public partial class IconPanel : StackedIcons {
        private static readonly IconManager IM = IconManager.Instance;

        private string? icon;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string? Icon {
            get => icon;
            set {
                this.icon = value;
                this.Icons.Clear();

                if (this.Icon != null) {
                    this.Icons.Add(IM.GetImage(this.Icon));
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public event Action<string>? OnSelected;

        public IconPanel(string? icon = null) {
            base.OnIconClicked += IconPanel_Click;
            this.Icon = icon;
        }

        private void IconPanel_Click(MouseButtons buttons) {
            if (this.Icon != null) {
                this.OnSelected?.Invoke(this.Icon);
            }
        }
    }
}
