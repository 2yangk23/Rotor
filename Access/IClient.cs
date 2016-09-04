using System;
using MaplePacketLib.Tools;
using RotorLib.Tools;

namespace RotorLib.Access {
    public interface IClient {
        void WriteLog(string format, params object[] args);

        void SendPacket(byte[] packet);

        void SendPacket(PacketWriter packet);

        void RegisterRecv(ushort header, Action<PacketReader> handler);

        void UnregisterRecv(ushort header);

        PacketReader WaitRecv(ushort header, Blocking<PacketReader> reader, bool returnPacket = false);
    }
}
