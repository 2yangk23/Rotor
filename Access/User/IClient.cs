using System;
using MaplePacketLib.Tools;
using RotorLib.Access.Inventory;
using RotorLib.Access.Map;
using RotorLib.Access.Primitive;
using RotorLib.Tools;

namespace RotorLib.Access.User {
    public enum ClientState : byte {
        DISCONNECTED,
        LOGIN,
        CASHSHOP,
        GAME
    }

    public interface IClient {
        IInventory GetInventory { get; }

        IMap GetMap { get; }

        IMapler GetMapler { get; }

        IInfo GetInfo { get; }

        void WriteLog(string format, params object[] args);

        void SendPacket(byte[] packet);

        void SendPacket(PacketWriter packet);

        void RegisterRecv(ushort header, Action<PacketReader> handler);

        void UnregisterRecv(ushort header);

        PacketReader WaitRecv(ushort header, Blocking<PacketReader> reader, bool returnPacket = false);

        void MoveMap(int mapId);

        void EnterPortal(string name, short x, short y);

        void EnterPortalSpecial(string name, short x, short y);

        void ChangeChannel(byte channel);
    }
}
