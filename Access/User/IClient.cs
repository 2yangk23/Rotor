using System;
using MaplePacketLib.Tools;
using RotorLib.Access.Inventory;
using RotorLib.Access.Map;

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

        bool WaitRecv(ushort header, out PacketReader reader, int timeout = -1, bool returnPacket = false);

        void MoveMap(int mapId);

        void EnterPortal(string name, short x, short y);

        void EnterPortalSpecial(string name, short x, short y);

        void ChangeChannel(byte channel);
    }
}
