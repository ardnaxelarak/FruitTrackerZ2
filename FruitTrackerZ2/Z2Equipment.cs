using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FruitTrackerZ2 {
    public class Z2Equipment {
        public static readonly List<MemorySegment> Segments = new List<MemorySegment>() {
            new MemorySegment(0x077A, 0x24),
            new MemorySegment(0x0600, 0x100),
        };

        public Dictionary<string, ITrackable> Items { get; } = new();
        public Dictionary<string, ITrackable> Locations { get; } = new();

        public event Action? OnReceiveUpdate;
        public event Action? OnConnected;
        public event Action? OnDisconnected;

        private MemoryCacher Memory { get; }
        private bool connected = false;
        private readonly object syncLock = new();
        private CancellationTokenSource pollingToken = new();

        public Z2Equipment() {
            this.Memory = new MemoryCacher();

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            ItemList items = new();
            try {
                using (StreamReader reader = new("Resources/items.yml")) {
                    items = deserializer.Deserialize<ItemList>(reader);
                }
            } catch (FileNotFoundException) { }

            LocationList locations = new();
            try {
                using (StreamReader reader = new("Resources/locations.yml")) {
                    locations = deserializer.Deserialize<LocationList>(reader);
                }
            } catch (FileNotFoundException) { }

            this.Items = items.Items.ToDictionary(item => item.Name, item => (ITrackable) new BitmaskTrackable(this.Memory, item.Addr, item.Mask, item.Inverted));
            this.Locations = locations.Locations.ToDictionary(item => item.Name, location => (ITrackable) new BitmaskTrackable(this.Memory, location.Addr, location.Mask, location.Inverted));
        }

        public bool Connected {
            get => connected;
            private set {
                if (connected != value) {
                    if (value) {
                        try {
                            OnConnected?.Invoke();
                        } catch (Exception) { }
                    } else {
                        try {
                            OnDisconnected?.Invoke();
                        } catch (Exception) { }
                    }
                }
                connected = value;
            }
        }

        public async Task ConnectToRetroArch(string hostname, int port, CancellationToken cancellationToken) {
            await this.EnsureDisconnected(cancellationToken);

            if (cancellationToken.IsCancellationRequested) {
                return;
            }

            var reader = new RetroArchReader(hostname, port, this.Memory);

            reader.OnReceiveUpdate += UpdateReceived;
            Connected = true;

            var newToken = CancellationTokenSource.CreateLinkedTokenSource(this.pollingToken.Token, cancellationToken);
            await reader.StartPolling(Z2Equipment.Segments, newToken.Token);

            reader.OnReceiveUpdate -= UpdateReceived;
            Connected = false;
        }

        private async Task EnsureDisconnected(CancellationToken cancellationToken) {
            if (this.Connected) {
                pollingToken.Cancel();
                pollingToken = new();

                CancellationTokenSource timeout = new(TimeSpan.FromSeconds(1));
                CancellationTokenSource linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeout.Token);

                await Task.Yield();

                while (this.Connected && !linked.IsCancellationRequested) {
                    try {
                        await Task.Delay(TimeSpan.FromSeconds(0.1), linked.Token);
                    } catch (TaskCanceledException) { }
                }
            }
        }

        private void UpdateReceived() {
            this.OnReceiveUpdate?.Invoke();
        }
    }
}
