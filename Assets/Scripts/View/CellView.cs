using UnityEngine;
using UnityEngine.EventSystems;

public class CellView : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PositionCalculator _positionCalculator;

    private Cell _cell;

    public Vector3 Scale => transform.localScale;
    public int Number => _cell.Number;

    public void OnPointerDown(PointerEventData eventData)
    {
        _cell.Interact();
    }

    public void SetCell(Cell cell)
    {
        _cell = cell;
        _cell.PositionChanged += ChangePosition;
    }

    private void ChangePosition()
    {
        Position2 localPosition = _cell.Position;
        transform.localPosition = _positionCalculator.Calculate(Scale.x, Scale.z, localPosition);
    }

    private void OnDisable()
    {
        _cell.PositionChanged -= ChangePosition;
    }
}