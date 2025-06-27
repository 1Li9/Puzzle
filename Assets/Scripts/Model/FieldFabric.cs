using System.Collections.Generic;
using UnityEngine;

public class FieldFabric : MonoBehaviour
{
    [SerializeField] private int _height = 4;
    [SerializeField] private int _width = 4;

    public void Create(out Field field, out Dictionary<Position2, Cell> cells)
    {
        cells = CreateCells();
        DefaultWinCondition defaultWinCondition = new(cells);
        field = new(cells, new Position2(_height - 1, _width - 1), defaultWinCondition);
    }

    private Dictionary<Position2, Cell> CreateCells()
    {
        Dictionary<Position2, Cell> cells = new();
        List<int> numbers = new List<int>();

        for (int i = 1; i < _height * _width; i++)
            numbers.Add(i);

        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _height; j++)
            {
                if ((i + 1) * (j + 1) == _height * _width)
                    return cells;

                int index = Random.Range(0, numbers.Count);
                int number = numbers[index];
                numbers.RemoveAt(index);

                Position2 position = new(j, i);
                Cell cell = new(position, number);

                cells.Add(position, cell);
            }
        }

        return cells;
    }
}