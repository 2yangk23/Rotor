using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MaplePacketLib.Tools;
using RotorLib.Access.Inventory;
using RotorLib.Access.Map;
using RotorLib.Access.User;
using RotorLib.Tools;

namespace RotorLib {
    public abstract class Rotor {
        private readonly IClient client;
        private readonly List<ushort> headers = new List<ushort>();
        private readonly Blocking<PacketReader> reader = new Blocking<PacketReader>();
        private readonly CancellationTokenSource source = new CancellationTokenSource();

        /* Access Data */
        protected IInventory Inventory => client.GetInventory;
        protected IMap Map => client.GetMap;
        protected IMapler Mapler => client.GetMapler;
        protected IInfo Info => client.GetInfo;

        protected Rotor(IClient client) {
            this.client = client;
        }

        /* Initialize Rotor
         * - Register RECV headers
         * - Runtime initialization
         * - If not needed, don't implement
         */
        protected void Init() { }

        /* Execute Rotor
         * - Main running script
         * - If looping, condition on token
         * - If not needed, don't implement
         */
        protected void Execute(CancellationToken token) { }

        #region Start/Stop Methods
        public void Start() {
            try {
                Console.WriteLine($"Starting {GetType().Name}");
                Init();
                // Only run Execute if overriden
                var methodInfo = typeof(Rotor).GetMethod("Execute");
                if (methodInfo.GetBaseDefinition().DeclaringType != methodInfo.DeclaringType) {
                    Task.Run(() => Execute(source.Token), source.Token);
                }
            } catch (InvalidOperationException ex) {
                Stop();
                Console.WriteLine($"Error running {GetType().Name}.  Terminated.");
                Console.WriteLine(ex.ToString());
            }
        }

        public void Stop() {
            source?.Cancel();
            headers.ForEach(d => client.UnregisterRecv(d));
            headers.Clear();
        }
        #endregion

        #region Basic Functionality
        public void Log(string format, params object[] args) {
            client.WriteLog(format, args);
        }

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
