using System;
using System.Threading;
using System.Windows.Forms;

namespace FruitTrackerZ2
{
    public partial class TrackerForm : Form {
        private bool autoTracking = false;
        private Z2Equipment tracking = new();
        private CancellationTokenSource trackingToken = new CancellationTokenSource();

        public TrackerForm() {
            InitializeComponent();
        }

        private void autoTrackingLabel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Middle) {
                if (!autoTracking || e.Button == MouseButtons.Middle) {
                    autoTracking = true;
                    autoTrackingLabel.Image = Resources.red_snes;
                    trackingToken.Cancel();
                    trackingToken = new();
                    _ = tracking.ConnectToRetroArch("192.168.1.108", 55355, trackingToken.Token);
                }
            } else if (e.Button == MouseButtons.Right) {
                autoTracking = false;
                autoTrackingLabel.Image = Resources.gray_snes;
                trackingToken.Cancel();
                trackingToken = new();
            }
        }

        private void TrackerForm_Load(object sender, System.EventArgs e) {
            tracking.OnConnected += () => Invoke(new Action(() => autoTrackingLabel.Image = autoTracking ? Resources.green_snes : Resources.gray_snes));
            tracking.OnDisconnected += () => Invoke(new Action(() => autoTrackingLabel.Image = autoTracking ? Resources.red_snes : Resources.gray_snes));

            inventoryTable.SetAutoTracker(tracking);
            locationTable.SetAutoTracker(tracking);
        }
    }
}
