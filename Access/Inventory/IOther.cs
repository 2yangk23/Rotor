namespace RotorLib.Access.Inventory {
    public enum Flag : short {
        NONE = 0x0,                 // 0000 0000 0000 0000
        LOCK = 0x1,                 // 0000 0000 0000 0001
        NO_SLIP = 0x2,              // 0000 0000 0000 0010
        COLD_RESIST = 0x4,          // 0000 0000 0000 0100
        UNTRADEABLE = 0x8,          // 0000 0000 0000 1000
        KARMA = 0x10,               // 0000 0000 0001 0000
        CHARM = 0x20,               // 0000 0000 0010 0000
        ANDROID_ACTIVATED = 0x40,   // 0000 0000 0100 0000
        CRAFTED = 0x80,             // 0000 0000 1000 0000
        CURSE_PROTECTION = 0x100,   // 0000 0001 0000 0000
        LUCKY_DAY = 0x200,          // 0000 0010 0000 0000
        KARMA_ACC_USE = 0x400,      // 0000 0100 0000 0000
        KARMA_ACC = 0x1000,         // 0001 0000 0000 0000
        SHIELD = 0x2000,            // 0010 0000 0000 0000
        SCROLL_PROTECTION = 0x4000, // 0100 0000 0000 0000

        KARMA_USE = 0x2
    }

    public interface IOther : IItem {
        short Quantity { get; }
        Flag Flag { get; }

        bool IsAmmo { get; }
        bool IsBowArrow { get; }
        bool IsXbowArrow { get; }
        bool IsThrowingStar { get; }
        bool IsSummonSack { get; }
        bool IsBullet { get; }
        bool IsMonsterCard { get; }
        bool IsFamiliar { get; }
    }
}
