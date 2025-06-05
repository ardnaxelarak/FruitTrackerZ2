namespace FruitTrackerZ2 {
    public struct MemorySegment {
        public int Address;
        public int Length;

        public MemorySegment(int address, int length) {
            this.Address = address;
            this.Length = length;
        }
    }
}
