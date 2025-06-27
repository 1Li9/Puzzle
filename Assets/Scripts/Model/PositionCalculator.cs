using UnityEngine;

public class PositionCalculator : MonoBehaviour
{
    [SerializeField] private float _gap;
    
    public Vector3 Calculate(float xScale, float zScale, Position2 localPosition)
    {
        return new(localPosition.X * (xScale + _gap), 0, -localPosition.Y * (zScale + _gap));
    }
}