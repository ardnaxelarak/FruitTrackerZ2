using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FruitTrackerZ2 {
    public class RetroArchReader {
        private static readonly Regex REGEX = new(@"READ_CORE_MEMORY ([0-9A-Fa-f]+)(?: ([0-9A-Fa-f]{2}))+", RegexOptions.Compiled | RegexOptions.Multiline);
        private string Hostname { get; }
        private int Port { get; }
        private MemoryCacher MemoryCacher { get; }

        public event Action? OnReceiveUpdate;

        public RetroArchReader(string hostname, int port, MemoryCacher memoryCacher) {
            this.Hostname = hostname;
            this.Port = port;
            this.MemoryCacher = memoryCacher;
        }

        public async Task StartPolling(List<MemorySegment> segments, CancellationToken cancellationToken) {
            UdpClient client = new();
            client.Connect(this.Hostname, this.Port);

            List<ReadOnlyMemory<byte>> commands = segments
                .Select(segment => string.Format("READ_CORE_MEMORY 0x{0:X} {1}", segment.Address, segment.Length))
                .Select(str => new ReadOnlyMemory<byte>(Encoding.ASCII.GetBytes(str)))
                .ToList();

            try {
                while (!cancellationToken.IsCancellationRequested) {
                    foreach (ReadOnlyMemory<byte> command in commands) {
                        Console.WriteLine("Sending command");
                        await client.SendAsync(command, cancellationToken);
                        var result = await client.ReceiveAsync(cancellationToken);
                        this.ProcessResponse(result);
                        await Task.Delay(TimeSpan.FromSeconds(0.1), cancellationToken);
                    }
                }
            } catch (TaskCanceledException) {
            } catch (OperationCanceledException) {
            }
        }

        private void ProcessResponse(UdpReceiveResult result) {
            string text = Encoding.ASCII.GetString(result.Buffer);
            foreach (Match match in REGEX.Matches(text)) {
                int addr = int.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
                List<byte> data = match.Groups[2].Captures.Select(cap => byte.Parse(cap.Value, System.Globalization.NumberStyles.HexNumber)).ToList();
                this.MemoryCacher.Update(addr, data);
            }

            this.OnReceiveUpdate?.Invoke();
        }
    }
}
