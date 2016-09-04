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
        Dictionary<short, IEquip> EquipInventory { get; }
        Dictionary<short, IOther> UseInventory { get; }
        Dictionary<short, IOther> SetupInventory { get; }
        Dictionary<short, IOther> EtcInventory { get; }
        Dictionary<short, IOther> CashInventory { get; }
    }
}
