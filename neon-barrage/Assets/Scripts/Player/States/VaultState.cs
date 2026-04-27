using UnityEngine;

public class VaultState : BaseState<PlayerController>
{
    public VaultState(PlayerController context) : base(context) { }

    private bool isVaultCompleted = false;

    public override void EnterState()
    {
        Context.Traverser.Vault(() => isVaultCompleted = true, () => isVaultCompleted = true);
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
    public override void CheckSwitchStates()
    {
        if (isVaultCompleted || !Context.Traverser.IsClimbPressed)
        {
            SwitchState<LocomotionState>();
        }
    }

    public override void ExitState()
    {
        isVaultCompleted = false;
    }

}
