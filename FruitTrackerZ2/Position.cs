using System.Drawing;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    public struct Position {
        public int X { get; set; }
        public int Y { get; set; }
        public AnchorStyles Anchor { get; set; }

        public static Position FromContainer(Point point, Control parent, bool closeVertical) {
            int offset = 20;
            Position pos = new();
            if (point.X > parent.Width / 2) {
                pos.X = point.X - offset;
                pos.Anchor = AnchorStyles.Right;
            } else {
                pos.X = point.X + offset;
                pos.Anchor = AnchorStyles.Left;
            }
            if ((point.Y > parent.Height / 2) ^ closeVertical) {
                pos.Y = point.Y - offset;
                pos.Anchor |= AnchorStyles.Bottom;
            } else {
                pos.Y = point.Y + offset;
                pos.Anchor |= AnchorStyles.Top;
            }
            return pos;
        }

        public void SetLocation(Control control) {
            control.Left = X;
            control.Top = Y;

            if (Anchor.HasFlag(AnchorStyles.Right)) {
                control.Left -= control.Width;
            }
            if (Anchor.HasFlag(AnchorStyles.Bottom)) {
                control.Top -= control.Height;
            }
        }
    }
}
