using System.Collections.Generic;
using UnityEngine;

public class PositionCalculator : MonoBehaviour
{
    [SerializeField] private float _gap;

    public Vector3 ConvertToGlobal(float xScale, float zScale, Position2 localPosition)
    {
        return new(localPosition.X * (xScale + _gap), 0, -localPosition.Y * (zScale + _gap));
    }

    public bool TryGetRandomNeighbour(Dictionary<Position2, Cell> cells, Position2 position, out Cell cell)
    {
        cell = null;
        Cell[] neighbours = GetValidNeighbour(cells, position);

        if(neighbours == null)
            return false;

        int index = Random.Range(0, neighbours.Length);
        cell = neighbours[index];

        return true;
    }

    private Cell[] GetValidNeighbour(Dictionary<Position2, Cell> cells, Position2 position)
    {
        List<Cell> result = new();

        if (cells.TryGetValue(new Position2(position.X + 1, position.Y), out Cell cell))
            result.Add(cell);
        if (cells.TryGetValue(new Position2(position.X - 1, position.Y), out cell))
            result.Add(cell);
        if (cells.TryGetValue(new Position2(position.X, position.Y + 1), out cell))
            result.Add(cell);
        if (cells.TryGetValue(new Position2(position.X, position.Y - 1), out cell))
            result.Add(cell);

        return result.ToArray();
    }
}