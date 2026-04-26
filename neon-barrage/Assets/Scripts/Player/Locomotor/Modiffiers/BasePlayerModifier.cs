using UnityEngine;

[System.Serializable]
public abstract class BasePlayerModifier
{
    protected PlayerMovementContext ctx;
    public BasePlayerModifier(PlayerMovementContext ctx)
    {
        this.ctx = ctx;
    }
    public abstract void Update();
}
