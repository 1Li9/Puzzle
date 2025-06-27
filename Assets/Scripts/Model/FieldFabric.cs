using System.Collections.Generic;
using UnityEngine;

public class FieldFabric : MonoBehaviour
{
    [SerializeField] private PositionCalculator _positionCalculator;
    [SerializeField] private int _height = 4;
    [SerializeField] private int _width = 4;
    [SerializeField] private int _scrambleSteps = 20;

    private Position2 _freeCellPosition;

    public void Create(out Field field, out Dictionary<Position2, Cell> cells)
    {
        _freeCellPosition = new Position2(_height - 1, _width - 1);

        cells = CreateCells();
        SetRandomPositions(cells);

        DefaultWinCondition defaultWinCondition = new(cells);
        field = new(cells, _freeCellPosition, defaultWinCondition);
    }

    private Dictionary<Position2, Cell> CreateCells()
    {
        Dictionary<Position2, Cell> cells = new();

        int count = 1;

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if ((i + 1) * (j + 1) == _height * _width)
                    return cells;

                Position2 position = new(j, i);
                Cell cell = new(position, count);

                cells.Add(position, cell);

                count++;
            }
        }

        return cells;
    }

    private void SetRandomPositions(Dictionary<Position2, Cell> cells)
    {
        for (int i = 0; i < _scrambleSteps; i++)
        {
            if (_positionCalculator.TryGetRandomNeighbour(cells, _freeCellPosition, out Cell neighbourCell) == false)
                throw new System.ArgumentNullException(nameof(cells));

            Position2 tempPosition = neighbourCell.Position;
            neighbourCell.SetPosition(_freeCellPosition);
            _freeCellPosition = tempPosition;

            cells.Remove(tempPosition);
            cells.Add(neighbourCell.Position, neighbourCell);
        }
    }
}