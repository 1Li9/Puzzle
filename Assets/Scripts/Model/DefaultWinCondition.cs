using System;
using System.Collections.Generic;

public class DefaultWinCondition : IWinCondition
{
    private Dictionary<Position2, Cell> _cells;

    private NextCellCalculator _cellCalculator;
    int _numbersSum;

    public DefaultWinCondition(Dictionary<Position2, Cell> cells)
    {
        _cells = cells;
        _cellCalculator = new NextCellCalculator(cells);

        foreach(Cell cell in _cells.Values)
            _numbersSum += cell.Number;
    }

    public bool IsWin()
    {
        if (_cells.Values.Count == 0)
            throw new ArgumentOutOfRangeException(nameof(_cells));

        if(_cells.TryGetValue(new(0, 0), out Cell firstCell) == false)
            return false;

        int sum = firstCell.Number;

        foreach (Cell cell in _cells.Values)
        {
            if (_cellCalculator.TryGetNextCell(cell, out Cell nextCell))
            {
                sum += nextCell.Number;

                if (nextCell.Number == cell.Number + 1)
                    continue;
                else
                    return false;
            }
        }

        return sum == _numbersSum;
    }
}
