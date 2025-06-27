using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class CellUI : MonoBehaviour
{
    [SerializeField] CellView _cellView;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();   
    }

    private void Start()
    {
        _text.text = _cellView.Number.ToString();
    }
}
