using RotorLib.Access.Primitive;

namespace RotorLib.Access.Map {
    public interface IMapObject {
        int Id { get; }
        Position Position { get; }
    }
}
