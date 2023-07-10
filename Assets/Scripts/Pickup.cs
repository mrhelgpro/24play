using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Pickup : MonoBehaviour, IHoldable
{
    private IHolder _holder = null;
    private Rigidbody _rigidbody = null;
    private Transform _transform = null;

    private void Start()
    {
        _transform = transform;

        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = false;

        _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        _holder = GetComponentInParent<IHolder>();

        if (IsHolder() == true) AddToHolder(_holder);
    }

    public bool IsHolder() => _holder != null;

    public void AddToHolder(IHolder holder)
    {
        _holder = holder;
        _holder.AddHoldable(this);

        _transform.parent = _holder.GetParent();
        _transform.localPosition = new Vector3(0, _holder.GetIndex() - 1, 0);

        _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    public void RemoveFromHolder(Transform parent)
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotation;
        _transform.parent = parent; // FIXED IT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        _holder.RemoveHoldable(this);
        _holder = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsHolder() == true)
        {
            if (collision.gameObject.tag == "Wall")
            {
                float boxVertical = collision.transform.position.y;
                float myVertical = _transform.position.y;

                if (Mathf.Abs(boxVertical - myVertical) <= 0.1f)
                {
                    RemoveFromHolder(collision.transform.parent);

                    return;
                }
            }

            if (collision.gameObject.tag == "Pickup")
            {
                IHoldable holdable = collision.gameObject.GetComponentInParent<IHoldable>();

                if (holdable != null)
                {
                    if (holdable.IsHolder() == false)
                    {
                        holdable.AddToHolder(_holder);
                    }
                }
            }
        }
    }
}
