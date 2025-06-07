using System;

namespace FruitTrackerZ2 {
    internal class TrackerManager {
        private static TrackerManager? instance;

        public static TrackerManager Instance {
            get {
                instance ??= new();
                return instance;
            }
        }

        public ITrackingClient Tracker { get; set; } = new DummyTrackingClient();

        public Z2Equipment? Tracking { get; set; }

        public void RequestUpdate() {
            OnRequestUpdate?.Invoke();
        }

        public event Action? OnRequestUpdate;
    }
}
