using System.Collections.Generic;
using System.Windows.Forms;

namespace FruitTrackerZ2 {
    public partial class InventoryTable : UserControl {
        private readonly InventoryIcon shieldIcon;
        private readonly InventoryIcon jumpIcon;
        private readonly InventoryIcon lifeIcon;
        private readonly InventoryIcon fairyIcon;
        private readonly InventoryIcon fireIcon;
        private readonly InventoryIcon reflectIcon;
        private readonly InventoryIcon spellIcon;
        private readonly InventoryIcon thunderIcon;

        private readonly InventoryIcon candleIcon;
        private readonly InventoryIcon gloveIcon;
        private readonly InventoryIcon raftIcon;
        private readonly InventoryIcon bootsIcon;
        private readonly InventoryIcon fluteIcon;
        private readonly InventoryIcon crossIcon;
        private readonly InventoryIcon hammerIcon;
        private readonly InventoryIcon magickeyIcon;

        private readonly InventoryIcon trophyIcon;
        private readonly InventoryIcon mirrorIcon;
        private readonly InventoryIcon bagunoteIcon;
        private readonly InventoryIcon medicineIcon;
        private readonly InventoryIcon waterIcon;
        private readonly InventoryIcon kidIcon;
        private readonly InventoryIcon downstabIcon;
        private readonly InventoryIcon upstabIcon;

        private readonly List<InventoryIcon> inventoryIcons = new();

        private Z2Equipment? tracking;

        public InventoryTable() {
            InitializeComponent();

            shieldIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "shield",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_shield" },
                    new [] { "shield" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(shieldIcon, 0, 0);
            inventoryIcons.Add(shieldIcon);

            jumpIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "jump",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_jump" },
                    new [] { "jump" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(jumpIcon, 0, 1);
            inventoryIcons.Add(jumpIcon);

            lifeIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "life",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_life" },
                    new [] { "life" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(lifeIcon, 0, 2);
            inventoryIcons.Add(lifeIcon);

            fairyIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "fairy",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_fairy" },
                    new [] { "fairy" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(fairyIcon, 0, 3);
            inventoryIcons.Add(fairyIcon);

            fireIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "fire",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_fire" },
                    new [] { "fire" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(fireIcon, 1, 0);
            inventoryIcons.Add(fireIcon);

            reflectIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "reflect",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_reflect" },
                    new [] { "reflect" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(reflectIcon, 1, 1);
            inventoryIcons.Add(reflectIcon);

            spellIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "spell",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_spell" },
                    new [] { "spell" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(spellIcon, 1, 2);
            inventoryIcons.Add(spellIcon);

            thunderIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "thunder",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_thunder" },
                    new [] { "thunder" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(thunderIcon, 1, 3);
            inventoryIcons.Add(thunderIcon);

            candleIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "candle",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_candle" },
                    new [] { "candle" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(candleIcon, 2, 0);
            inventoryIcons.Add(candleIcon);

            gloveIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "glove",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_glove" },
                    new [] { "glove" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(gloveIcon, 3, 0);
            inventoryIcons.Add(gloveIcon);

            raftIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "raft",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_raft" },
                    new [] { "raft" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(raftIcon, 4, 0);
            inventoryIcons.Add(raftIcon);

            hammerIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "hammer",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_hammer" },
                    new [] { "hammer" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(hammerIcon, 5, 0);
            inventoryIcons.Add(hammerIcon);

            bootsIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "boots",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_boots" },
                    new [] { "boots" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(bootsIcon, 2, 1);
            inventoryIcons.Add(bootsIcon);

            fluteIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "flute",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_flute" },
                    new [] { "flute" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(fluteIcon, 3, 1);
            inventoryIcons.Add(fluteIcon);

            crossIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "cross",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_cross" },
                    new [] { "cross" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(crossIcon, 4, 1);
            inventoryIcons.Add(crossIcon);

            magickeyIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "magickey",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_magickey" },
                    new [] { "magickey" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(magickeyIcon, 5, 1);
            inventoryIcons.Add(magickeyIcon);

            trophyIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "trophy",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_trophy" },
                    new [] { "trophy" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(trophyIcon, 2, 2);
            inventoryIcons.Add(trophyIcon);

            mirrorIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "mirror",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_mirror" },
                    new [] { "mirror" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(mirrorIcon, 3, 2);
            inventoryIcons.Add(mirrorIcon);

            bagunoteIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "bagunote",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_bagunote" },
                    new [] { "bagunote" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(bagunoteIcon, 4, 2);
            inventoryIcons.Add(bagunoteIcon);

            medicineIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "medicine",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_medicine" },
                    new [] { "medicine" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(medicineIcon, 5, 2);
            inventoryIcons.Add(medicineIcon);

            waterIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "water",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_water" },
                    new [] { "water" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(waterIcon, 2, 3);
            inventoryIcons.Add(waterIcon);

            kidIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "kid",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_kid" },
                    new [] { "kid" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(kidIcon, 3, 3);
            inventoryIcons.Add(kidIcon);

            downstabIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "downstab",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_downstab" },
                    new [] { "downstab" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(downstabIcon, 4, 3);
            inventoryIcons.Add(downstabIcon);

            upstabIcon = new() {
                BackColor = itemLayoutPanel.BackColor,
                CellId = "upstab",
                Padding = new(3),
                ImageSets = new string[][] {
                    new [] { "no_upstab" },
                    new [] { "upstab" },
                },
                Value = 0,
            };
            itemLayoutPanel.Controls.Add(upstabIcon, 5, 3);
            inventoryIcons.Add(upstabIcon);
        }

        public void SetAutoTracker(Z2Equipment tracking) {
            this.tracking = tracking;
            tracking.OnReceiveUpdate += AutoTrackerUpdate;
        }

        private void AutoTrackerUpdate() {
            if (tracking == null) {
                return;
            }

            foreach (var icon in inventoryIcons) {
                if (tracking.Items.ContainsKey(icon.CellId)) {
                    icon.Value = tracking.Items[icon.CellId].Value ? 1 : 0;
                }
            }
        }

        public void UpdateBroadcastView() {
            foreach (InventoryIcon icon in inventoryIcons) {
                icon.UpdateBroadcast();
            }
        }

        public void ResetInventory() {
            foreach (InventoryIcon icon in inventoryIcons) {
                icon.Value = 0;
                icon.UpdateBroadcast();
            }
        }
    }
}
