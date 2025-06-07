using Microsoft.AspNetCore.SignalR;

namespace FruitTrackerZ2 {
    public class TrackingHub : Hub<ITrackingClient> { }
}
