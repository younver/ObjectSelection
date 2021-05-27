using UnityEngine;

public class TagSelector : MonoBehaviour, ISelector
{
    [SerializeField] public string selectableTag = "Selectable";
    private Transform _selection;

    public Transform GetSelection()
    {
        return this._selection;
    }

    public void Check(Ray ray)
    {
        this._selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(this.selectableTag))
            {
                this._selection = selection;
            }
        }
    }
}