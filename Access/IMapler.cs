namespace Rotor.Access {
     public interface IMapler {
        int Id { get; }
        string Name { get; }
        byte Level { get; }
        short Job { get; }

        short Str { get; }
        short Dex { get; }
        short Int { get; }
        short Luk { get; }
        int Hp { get; }
        int MaxHp { get; }
        int Mp { get; }
        int MaxMp { get; }

        int Ap { get; }
        long Exp { get; }
        int Fame { get; }
        int Map { get; }
    }
}
