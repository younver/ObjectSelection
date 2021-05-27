using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private ISelectionResponse _selectionResponse;
    private IRayProvider _rayProvider;
    private ISelector _selector;

    private Transform _currentSelection;

    private void Awake()
    {
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
        _selectionResponse = GetComponent<ISelectionResponse>();
    }
    private void Update()
    {
        // Selection/Deselection
        if (_currentSelection != null) _selectionResponse.OnDeselect(_currentSelection);

        // Creating a Ray
        var ray = _rayProvider.CreateRay();

        // Selection Determination
        _selector.Check(ray);
        _currentSelection = _selector.GetSelection();

        // Selection/Deselection
        if (_currentSelection != null) _selectionResponse.OnSelect(_currentSelection);
    }
}
