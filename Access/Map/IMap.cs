using System.Collections.Generic;

namespace RotorLib.Access.Map {
    public interface IMap {
        IReadOnlyDictionary<int, IPlayer> Players { get; }
        IReadOnlyDictionary<int, IDrop> Drops { get; }
        IReadOnlyDictionary<int, IShop> Shops { get; }
    }
}
