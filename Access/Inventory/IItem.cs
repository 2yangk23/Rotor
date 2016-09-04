namespace RotorLib.Access.Inventory {
    public enum ItemType : byte {
        UNKNOWN = 0,
        EQUIP = 1,
        OTHER = 2,
        PET = 3
    }

    public interface IItem {
        ItemType ItemType { get; }
        int Id { get; }
        short Slot { get; }
    }
}
