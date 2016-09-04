using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MaplePacketLib.Tools;
using Rotor.Access;
using Rotor.Tools;

namespace Rotor {
    public abstract class Rotor {
        private readonly IClient client;
        private readonly List<ushort> headers = new List<ushort>();
        private readonly Blocking<PacketReader> reader = new Blocking<PacketReader>();
        private readonly CancellationTokenSource source = new CancellationTokenSource();

        protected Rotor(IClient client) {
            this.client = client;
        }

        protected void Start() {
            try {
                Init();
                Task.Run(() => Execute(source.Token), source.Token);
            } catch (InvalidOperationException ex) {
                Stop();
                Console.WriteLine($"Error running {GetType().Name}.  Terminated.");
                Console.WriteLine(ex.ToString());
            }
        }

        protected void Stop() {
            source?.Cancel();
            headers.ForEach(d => client.UnregisterRecv(d));
            headers.Clear();
        }

        protected abstract void Init();

        protected abstract void Execute(CancellationToken token);

        #region Basic Functionality
        protected void SendPacket(byte[] packet) {
            client.SendPacket(packet);
        }

        protected void SendPacket(PacketWriter packet) {
            client.SendPacket(packet);
        }

        protected void RegisterRecv(ushort header, Action<PacketReader> handler) {
            client.RegisterRecv(header, handler);
            headers.Add(header);
        }

        protected void UnregisterRecv(ushort header) {
            headers.Remove(header);
            client.UnregisterRecv(header);
        }

        protected PacketReader WaitRecv(ushort header, bool returnPacket = false) {
            return client.WaitRecv(header, reader, returnPacket);
        }
        #endregion
    }
}
