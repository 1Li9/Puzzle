using System.Collections.Generic;

public class NextCellCalculator
{
    private Dictionary<Position2, Cell> _cells;

    public NextCellCalculator(Dictionary<Position2, Cell> cells)
    {
        _cells = cells;
    }

    public bool TryGetNextCell(Cell currentCell, out Cell cell)
    {
        Position2 nextPosition = new(currentCell.Position.X + 1, currentCell.Position.Y);

        if (_cells.TryGetValue(nextPosition, out cell))
        {
            return true;
        }
        else
        {
            nextPosition = new(0, currentCell.Position.Y + 1);

            return _cells.TryGetValue(nextPosition, out cell);
        }
    }
}