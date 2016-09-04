namespace RotorLib.Access.Inventory {
    public enum Potential : byte {
        NONE = 0,
        HIDDEN_RARE = 1,
        HIDDEN_EPIC = 2,
        HIDDEN_UNIQUE = 3,
        HIDDEN_LEGEND = 4,
        RARE = 17,
        EPIC = 18,
        UNIQUE = 19,
        LEGEND = 20
    }

    public interface IEquip : IItem {
        Potential Potential { get; }
        byte Enhancements { get; }
    }
}
