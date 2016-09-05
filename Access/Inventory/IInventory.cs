using System.Collections.Generic;

namespace RotorLib.Access.Inventory {
    public enum InventoryTab : byte {
        EQUIP = 1,
        USE = 2,
        SETUP = 3,
        ETC = 4,
        CASH = 5
    }

    public interface IInventory {
        long Mesos { get; }
        IReadOnlyDictionary<short, IEquip> EquipInventory { get; }
        IReadOnlyDictionary<short, IOther> UseInventory { get; }
        IReadOnlyDictionary<short, IOther> SetupInventory { get; }
        IReadOnlyDictionary<short, IOther> EtcInventory { get; }
        IReadOnlyDictionary<short, IOther> CashInventory { get; }
    }
}
