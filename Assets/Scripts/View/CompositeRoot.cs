using System.Collections.Generic;
using UnityEngine;

public class CompositeRoot : MonoBehaviour
{
    [SerializeField] private PositionCalculator _positionCalculator;
    [SerializeField] private FieldFabric _fieldFabric;

    [SerializeField] private Transform _fieldPosition;
    [SerializeField] private CellView _cellViewPrefab;
    [SerializeField] private FieldView _fieldViewPrefab;

    private void Start()
    {
        _fieldFabric.Create(out Field field, out Dictionary<Position2, Cell> cells);
        CreateFieldView(field);
        CreateCellsView(cells);
    }

    private void CreateFieldView(Field field)
    {
        FieldView fieldView = Instantiate(_fieldViewPrefab, _fieldPosition.position, Quaternion.identity);
        fieldView.SetField(field);
    }

    private void CreateCellsView(Dictionary<Position2, Cell> cells)
    {
        foreach (Cell cell in cells.Values)
        {
            Position2 position = cell.Position;
            Vector3 globalPosition = _positionCalculator.ConvertToGlobal(_cellViewPrefab.Scale.x, _cellViewPrefab.Scale.z, position);
            CellView cellView = Instantiate(_cellViewPrefab, globalPosition, Quaternion.identity);
            cellView.SetCell(cell);
        }
    }
}