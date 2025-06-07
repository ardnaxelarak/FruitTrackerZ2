using System.Threading.Tasks;

namespace FruitTrackerZ2 {
    public interface ITrackingClient {
        Task StartClock();
        Task StopClock();
        Task ResetClock(int millis = 0);
        Task UpdateItem(string cellId, string[] images);
    }

    internal class DummyTrackingClient : ITrackingClient {
        public Task StartClock() => Task.CompletedTask;
        public Task StopClock() => Task.CompletedTask;
        public Task ResetClock(int millis = 0) => Task.CompletedTask;
        public Task UpdateItem(string cellId, string[] images) => Task.CompletedTask;
    }
}
