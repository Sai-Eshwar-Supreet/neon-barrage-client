using UnityEngine;

[System.Serializable]
public abstract class BasePlayerModifier<T>
{
    protected T ctx;
    public BasePlayerModifier(T ctx)
    {
        this.ctx = ctx;
    }
    public abstract void Update();

    public abstract void OnExit();
}
