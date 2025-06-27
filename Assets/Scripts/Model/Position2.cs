using System;

public readonly struct Position2
{
    public Position2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public override bool Equals(object obj)
    {
        return obj is Position2 position &&
               X == position.X &&
               Y == position.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }

    public static bool operator ==(Position2 left, Position2 right) =>
        left.X == right.X && left.Y == right.Y;

    public static bool operator !=(Position2 left, Position2 right) =>
     left.X != right.X || left.Y != right.Y;
}