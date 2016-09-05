namespace RotorLib.Access.Map {
    public enum DropType : byte {
        DROPPING = 0,
        VISIBLE = 1,
        SPAWNED = 2,
        DISAPPEARING = 3
    }

    public interface IDrop : IMapObject {
        DropType Type { get; }
        int Crc { get; }
    }
}
