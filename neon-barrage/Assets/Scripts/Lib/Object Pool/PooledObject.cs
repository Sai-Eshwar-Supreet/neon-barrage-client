using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PooledObject : MonoBehaviour, ITransformCacher
{
    public event System.Action<PooledObject> OnDeactivateObject;

    public Transform ContextTransform
    {
        get
        {
            if (m_AmmoTransform == null) m_AmmoTransform = transform;
            return m_AmmoTransform;
        }
        private set { m_AmmoTransform = value; }
    }
    private Transform m_AmmoTransform;

    protected void DeactivateObject()
    {
        OnDeactivateObject?.Invoke(this);
    }
}
