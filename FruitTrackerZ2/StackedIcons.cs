using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    public partial class StackedIcons : UserControl {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Image> Icons { get; set; } = new();

        public event Action<MouseButtons>? OnIconClicked;

        public StackedIcons() {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.None;

            var rect = ClientRectangle;
            rect.Inflate(-(Padding.Left + Padding.Right) / 2, -(Padding.Top + Padding.Bottom) / 2);

            Console.Write(rect.ToString());

            foreach (Image img in Icons) {
                e.Graphics.DrawImage(img, rect);
            }
        }

        private void StackedIcons_MouseClick(object sender, MouseEventArgs e) {
            OnIconClicked?.Invoke(e.Button);
        }
    }
}
