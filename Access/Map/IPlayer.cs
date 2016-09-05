namespace RotorLib.Access.Map {
    public interface IPlayer : IMapObject {
        string Ign { get; }
        short Fh { get; }
        bool HasPermit { get; }
    }
}
