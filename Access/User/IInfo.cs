namespace RotorLib.Access.User {
    public interface IInfo {
        int UserId { get; }
        byte Channel { get; }
        int MapId { get; }

        int PortalCrc { get; }
        int HyperCrc { get; }
        byte PortalCount { get; }
    }
}
