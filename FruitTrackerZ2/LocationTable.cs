using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FruitTrackerZ2 {
    public partial class LocationTable : UserControl {
        private readonly List<LocationIcon> locationIcons = new();

        private Z2Equipment? tracking;

        public event Action<LocationIcon, Point>? OnLocationCapture;
        public event Action<object?, MouseEventArgs>? OnBackgroundClick;

        public LocationTable() {
            InitializeComponent();

            this.MouseDown += (sender, e) => this.OnBackgroundClick?.Invoke(sender, e);
            this.locationLayoutPanel.MouseDown += (sender, e) => this.OnBackgroundClick?.Invoke(sender, e);
        }

        public void SetAutoTracker(Z2Equipment tracking) {
            this.tracking = tracking;
            tracking.OnReceiveUpdate += AutoTrackerUpdate;
        }

        private void AutoTrackerUpdate() {
            if (tracking == null) {
                return;
            }

            foreach (var icon in locationIcons) {
                if (tracking.Locations.ContainsKey(icon.CellId)) {
                    icon.Value = tracking.Locations[icon.CellId].Value;
                }
            }
        }

        public void UpdateBroadcastView() {
            foreach (var icon in locationIcons) {
                icon.UpdateBroadcast();
            }
        }

        public void ResetInventory() {
            foreach (var icon in locationIcons) {
                icon.Value = false;
                icon.ItemId = null;
                icon.UpdateBroadcast();
            }
        }

        private void LocationTable_Load(object sender, EventArgs e) {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            LocationList locations = new();
            try {
                using (StreamReader reader = new("Resources/locations.yml")) {
                    locations = deserializer.Deserialize<LocationList>(reader);
                }
            } catch (Exception) { }

            foreach (var location in locations.Locations) {
                var icon = new LocationIcon($"locations/{location.Name}") {
                    BackColor = locationLayoutPanel.BackColor,
                    CellId = location.Name,
                    Padding = new(3),
                };
                icon.OnCaptureClick += point => this.OnLocationCapture?.Invoke(icon, point);
                locationLayoutPanel.Controls.Add(icon, location.Column, location.Row);
                locationIcons.Add(icon);
            }
        }
    }
}
