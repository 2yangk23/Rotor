using RotorLib.Access.Primitive;

namespace RotorLib.Access.Map {
    public interface IMob : IMapObject {
        int Crc { get; }
        int MobId { get; }

        void Move(Position position);
    }
}
