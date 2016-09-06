namespace RotorLib.Access.Map {
    public enum ShopType : byte {
        PERMIT = 5,
        MUSHY = 6
    }

    public interface IShop : IMapObject {
        ShopType Type { get; }
        short Foothold { get; }
        string OwnerName { get; }
        int ShopId { get; }
    }
}
