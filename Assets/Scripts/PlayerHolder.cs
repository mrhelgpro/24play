using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour, IHolder
{
    [SerializeField] private List<IHoldable> _holdableList = new List<IHoldable>();
    [SerializeField] private Transform _skinTransform;
    [SerializeField] private Transform _cubeHolderTransform;

    public void AddHoldable(IHoldable holdable)
    {
        _holdableList.Add(holdable);
        int index = _holdableList.Count;

        _skinTransform.localPosition = new Vector3(0, index, 0);
    }

    public void RemoveHoldable(IHoldable holdable)
    {
        _holdableList.Remove(holdable);
    }

    public Transform GetParent() => _cubeHolderTransform != null ? _cubeHolderTransform : transform;
    public int GetIndex() => _holdableList.Count;
}
