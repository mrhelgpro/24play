using UnityEngine;

public interface IHolder
{
    public void AddHoldable(IHoldable holdable);
    public void RemoveHoldable(IHoldable holdable);
    public Transform GetParent();
    public int GetIndex();
}

public interface IHoldable
{
    public bool IsHolder();
    public void AddToHolder(IHolder holder);
    public void RemoveFromHolder(Transform parent);
}