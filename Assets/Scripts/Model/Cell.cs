using System;

public class Cell
{
    private Position2 position;

    public Cell(Position2 position, int number)
    {
        Position = position;
        Number = number;
    }

    public Position2 Position
    {
        get => position;
        private set
        {
            position = value;
            PositionChanged?.Invoke();
        }
    }
    public int Number { get; }

    public event Action<Cell> Interacted;
    public event Action PositionChanged;

    public void Interact() =>
        Interacted?.Invoke(this);

    public void SetPosition(Position2 position) =>
        Position = position;
}