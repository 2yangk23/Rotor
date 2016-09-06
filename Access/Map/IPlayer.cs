namespace RotorLib.Access.Map {
    public interface IPlayer : IMapObject {
        string Name { get; }
        short Foothold { get; }
        bool HasPermit { get; }
    }
}
