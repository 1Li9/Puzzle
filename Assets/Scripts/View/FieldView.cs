using UnityEngine;

public class FieldView : MonoBehaviour
{
    private Field _field;

    public void SetField(Field field)
    {
        _field = field;
    }

    private void OnDestroy()
    {
        _field.Dispose();
    }
}