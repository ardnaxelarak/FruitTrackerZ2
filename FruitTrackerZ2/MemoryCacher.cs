using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitTrackerZ2 {
    public class MemoryCacher {
        private readonly Dictionary<int, byte> memoryCache = new();

        public MemoryCacher() { }

        public void Clear() {
            memoryCache.Clear();
        }

        public void Update(int addr, List<byte> data) {
            for (int i = 0; i < data.Count; i++) {
                memoryCache[addr + i] = data[i];
            }
        }

        public List<byte> ReadBytes(int addr, int length) {
            return Enumerable.Range(addr, length).Select(address => this.memoryCache.GetValueOrDefault(address, (byte) 0)).ToList();
        }

        public byte ReadByte(int addr) {
            List<byte> result = this.ReadBytes(addr, 1);
            return result[0];
        }

        public int ReadInt(int addr) {
            List<byte> result = this.ReadBytes(addr, 4);

            int value = 0;
            for (int i = 0; i < Math.Min(result.Count, 4); i++) {
                value |= ((int) result[i]) << (8 * i);
            }
            return value;
        }

        public long ReadLong(int addr) {
            List<byte> result = this.ReadBytes(addr, 8);

            long value = 0;
            for (int i = 0; i < Math.Min(result.Count, 8); i++) {
                value |= ((long) result[i]) << (8 * i);
            }
            return value;
        }
    }
}
