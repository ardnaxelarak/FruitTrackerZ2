namespace FruitTrackerZ2 {
    public interface ITrackable {
        public bool Value { get; }
    }

    internal abstract class Trackable : ITrackable  {
        protected readonly MemoryCacher cache;

        protected Trackable(MemoryCacher cache) {
            this.cache = cache;
        }

        public abstract bool Value { get; }
    }

    internal class BitmaskTrackable : Trackable {
        protected readonly int addr;
        protected readonly int bitmask;
        protected readonly bool inverted;

        internal BitmaskTrackable(MemoryCacher cache, int addr, int bitmask, bool inverted) : base(cache) {
            this.addr = addr;
            this.bitmask = bitmask;
            this.inverted = inverted;
        }

        public override bool Value {
            get {
                if (inverted) {
                    return (cache.ReadByte(addr) & bitmask) == 0;
                } else {
                    return (cache.ReadByte(addr) & bitmask) > 0;
                }
            }
        }
    }

    internal class ValueTrackable : Trackable {
        protected readonly int addr;

        internal ValueTrackable(MemoryCacher cache, int addr) : base(cache) {
            this.addr = addr;
        }

        public override bool Value {
            get => cache.ReadByte(addr) > 0;
        }
    }
}
