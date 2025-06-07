using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    internal class IconSelector : FlowLayoutPanel {
        private readonly List<IconPanel> boxes = new();

        public event Action<string>? OnIconClicked;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool SingleRow { get; set; } = false;

        public IconSelector() : base() {
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.Gray;
            Padding = new(3);
        }

        public void ShowIcons(List<string> icons) {
            Controls.Clear();

            while (boxes.Count < icons.Count) {
                IconPanel newPanel = new() {
                    Width = 36,
                    Height = 36,
                    Margin = new Padding(2),
                };
                newPanel.OnSelected += IconClicked;
                boxes.Add(newPanel);
            }

            for (int i = 0; i < icons.Count; i++) {
                boxes[i].Icon = icons[i];
                Controls.Add(boxes[i]);
            }

            int columns = (int) Math.Ceiling(Math.Sqrt(icons.Count));
            int rows = (int) Math.Ceiling(icons.Count / (double) columns);

            if (SingleRow) {
                rows = 1;
                columns = icons.Count;
            }

            Width = 40 * columns + 8;
            Height = 40 * rows + 8;
            BringToFront();
        }

        private void IconClicked(string icon) {
            this.OnIconClicked?.Invoke(icon);
        }
    }
}
