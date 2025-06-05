using System.Collections.Generic;

namespace FruitTrackerZ2 {
    public class ItemData {
        public string Name { get; set; }
        public int Addr { get; set; }
        public byte Mask { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Inverted { get; set; }
    }

    public class ItemList {
        public List<ItemData> Items { get; set; } = new();
    }

    public class LocationList {
        public List<ItemData> Locations { get; set; } = new();
    }
}
