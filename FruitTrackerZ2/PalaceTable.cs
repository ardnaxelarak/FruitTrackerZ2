using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FruitTrackerZ2 {
    public partial class PalaceTable : UserControl {
        private readonly List<PalaceIcon> palaceIcons = new();
        private readonly List<LocationIcon> contentsIcons = new();

        private readonly string[] bosses = new string[] {
            "horsehead",
            "helmethead",
            "rebonack",
            "carock",
            "gooma",
            "barba",
            "thunderbird",
        };

        private Z2Equipment? tracking;

        public PalaceTable() {
            InitializeComponent();
        }

        public void SetAutoTracker(Z2Equipment tracking) {
            this.tracking = tracking;
            tracking.OnReceiveUpdate += AutoTrackerUpdate;
        }

        private void AutoTrackerUpdate() {
            if (tracking == null) {
                return;
            }

            foreach (var icon in contentsIcons) {
                if (tracking.Locations.ContainsKey(icon.CellId)) {
                    icon.Value = tracking.Locations[icon.CellId].Value;
                }
            }
        }

        public void UpdateBroadcastView() {
            foreach (var icon in palaceIcons) {
                icon.UpdateBroadcast();
            }
        }

        public void ResetInventory() {
            foreach (var icon in palaceIcons) {
                icon.Value = 0;
                icon.UpdateBroadcast();
            }
            foreach (var icon in contentsIcons) {
                icon.Value = false;
                icon.ItemId = null;
                icon.UpdateBroadcast();
            }
        }

        private void PalaceTable_Load(object sender, EventArgs e) {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            for (var i = 0; i < 6; i++) {
                var pillarStr = $"palaces/pillar{i + 1}";
                var itemStr = $"palaces/palace{i + 1}item";
                var bossStr = $"palaces/{bosses[i]}";

                var palace = new PalaceIcon(pillarStr) {
                    BackColor = palaceLayoutPanel.BackColor,
                    CellId = pillarStr,
                    Padding = new(3),
                };
                palaceLayoutPanel.Controls.Add(palace, 3 * (i / 3), i % 3);
                palaceIcons.Add(palace);

                var item = new LocationIcon(itemStr) {
                    BackColor = palaceLayoutPanel.BackColor,
                    CellId = itemStr,
                    Padding = new(3),
                };
                palaceLayoutPanel.Controls.Add(item, 3 * (i / 3) + 1, i % 3);
                contentsIcons.Add(item);

                var boss = new LocationIcon(bossStr) {
                    BackColor = palaceLayoutPanel.BackColor,
                    CellId = bossStr,
                    Padding = new(3),
                };
                palaceLayoutPanel.Controls.Add(boss, 3 * (i / 3) + 2, i % 3);
                contentsIcons.Add(boss);
            }

            var greatPalace = new PalaceIcon("palaces/pillar7") {
                BackColor = palaceLayoutPanel.BackColor,
                CellId = "pillar7",
                Padding = new(3),
            };
            palaceLayoutPanel.Controls.Add(greatPalace, 3, 3);
            palaceIcons.Add(greatPalace);

            var thunderbird = new LocationIcon("palaces/thunderbird") {
                BackColor = palaceLayoutPanel.BackColor,
                CellId = "thunderbird",
                Padding = new(3),
            };
            palaceLayoutPanel.Controls.Add(thunderbird, 4, 3);
            contentsIcons.Add(thunderbird);
        }
    }
}
