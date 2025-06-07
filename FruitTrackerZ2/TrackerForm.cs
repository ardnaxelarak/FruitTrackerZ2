using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace FruitTrackerZ2
{
    public partial class TrackerForm : Form {
        private static readonly int PORT = 5777;

        private bool autoTracking = false;
        private Z2Equipment tracking = new();
        private CancellationTokenSource trackingToken = new CancellationTokenSource();

        private Settings settings = new();
        private LocationIcon? locationIconSelected;

        private readonly IconSelector itemSelector;
        private readonly List<IconSelector> selectors = new();

        public TrackerForm() {
            InitializeComponent();

            itemSelector = new() {
                Visible = false,
            };
            itemSelector.OnIconClicked += ItemSelectorIconClicked;
            selectors.Add(itemSelector);
            Controls.Add(itemSelector);

            TrackerManager.Instance.Tracking = tracking;
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
            inventoryTable.OnBackgroundClick += BackgroundClick;

            locationTable.SetAutoTracker(tracking);
            locationTable.OnBackgroundClick += BackgroundClick;
            locationTable.OnLocationCapture += LocationCapture;

            palaceTable.OnBackgroundClick += BackgroundClick;
            palaceTable.OnLocationCapture += LocationCapture;

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            try {
                using (StreamReader reader = new("Resources/full_shuffle.yml")) {
                    this.settings = deserializer.Deserialize<Settings>(reader);
                }
            } catch (Exception) { }

            this.RunWebserver();
        }

        private void ItemSelectorIconClicked(string icon) {
            if (this.locationIconSelected != null) {
                this.locationIconSelected.ItemId = $"{icon}_small";
                this.locationIconSelected = null;
                this.itemSelector.Visible = false;
            }
        }

        private void LocationCapture(LocationIcon icon, Point screenPoint) {
            this.locationIconSelected = icon;
            Point clientPoint = PointToClient(screenPoint);
            this.selectors.ForEach(selector => { selector.Visible = false; });

            IconSelector? selector = null;

            selector = this.itemSelector;
            selector.ShowIcons(settings.Items.Select(item => $"items/{item}").ToList());

            if (selector != null) {
                var popupPosition = Position.FromContainer(clientPoint, this, false);
                popupPosition.SetLocation(selector);
                selector.Visible = true;
            }
        }

        private void BackgroundClick(object? sender, MouseEventArgs e) {
            this.selectors.ForEach(selector => { selector.Visible = false; });
        }

        private void RunWebserver() {
            WebApplicationBuilder builder = WebApplication.CreateBuilder();
            builder.Services.AddSignalR();

            WebApplication app = builder.Build();

            app.UseStaticFiles();
            app.MapHub<TrackingHub>("/webview");

            string baseUrl = $"http://localhost:{PORT}/";
            Task _ = app.RunAsync(baseUrl);

            IHubContext<TrackingHub, ITrackingClient>? hub = app.Services.GetService<IHubContext<TrackingHub, ITrackingClient>>();

            if (hub != null) {
                TrackerManager.Instance.Tracker = hub.Clients.All;
            }
        }
    }
}
