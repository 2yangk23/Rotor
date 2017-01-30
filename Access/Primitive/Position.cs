using MaplePacketLib.Tools;

namespace RotorLib.Access.Primitive {
    public class Position {
        public short X { get; internal set; }
        public short Y { get; internal set; }

        public Position(short x, short y) {
            X = x;
            Y = y;
        }

        public override string ToString() {
            return $"({X}, {Y})";
        }
    }

    public static class PositionPacketExtensions {
        public static void WritePosition(this PacketWriter pw, Position p) {
            pw.WriteShort(p.X);
            pw.WriteShort(p.Y);
        }

        public static Position ReadPosition(this PacketReader pr) {
            return new Position(pr.ReadShort(), pr.ReadShort());
        }
    }
}
