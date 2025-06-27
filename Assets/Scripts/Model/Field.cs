using System;
using System.Collections.Generic;
using UnityEngine;

public class Field : IDisposable
{
    private readonly Dictionary<Position2, Cell> Cells;
    private readonly IWinCondition WinCondition;

    private Position2 _freePosition;

    public Field(Dictionary<Position2, Cell> cells, Position2 freePosition, IWinCondition winCondition)
    {
        _freePosition = freePosition;
        Cells = cells;
        WinCondition = winCondition;

        foreach (Cell cell in Cells.Values)
            cell.Interacted += MoveCell;
    }

    public event Action CellMoved;

    public void Dispose()
    {
        foreach (Cell cell in Cells.Values)
            cell.Interacted -= MoveCell;
    }

    private void MoveCell(Cell cell)
    {
        if (cell == null)
            throw new ArgumentNullException(nameof(cell));

        if (IsNeighboringCellFree(cell) == false)
            return;

        Position2 tempPosition = cell.Position;
        cell.SetPosition(_freePosition);
        _freePosition = tempPosition;

        Cells.Remove(tempPosition);
        Cells.Add(cell.Position, cell);

        CellMoved?.Invoke();

        if (WinCondition.IsWin())
            Debug.Log("Win");
    }

    private bool IsNeighboringCellFree(Cell cell)
    {
        return
            new Position2(cell.Position.X, cell.Position.Y + 1) == _freePosition ||
            new Position2(cell.Position.X + 1, cell.Position.Y) == _freePosition ||
            new Position2(cell.Position.X - 1, cell.Position.Y) == _freePosition ||
            new Position2(cell.Position.X, cell.Position.Y - 1) == _freePosition;
    }
}