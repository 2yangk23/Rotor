namespace RotorLib.Access.User {
    public interface IInfo {
        byte Channel { get; }
        int MapId { get; }

        int PortalCrc { get; }
        byte PortalCount { get; }
    }
}
