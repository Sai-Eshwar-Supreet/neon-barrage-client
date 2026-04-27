using DG.Tweening;
using System;
using UnityEngine;

public class PlayerTraverser : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerTraversalInput traversalInput;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private TriggerArea area;
    [SerializeField] private Transform vaultPoint;
    [SerializeField] private LayerMask vaultableSurfaces;
 
    private PlayerTraversalContext traversalContext;
    private ClimbModifier climbModifier;

    private void Awake()
    {
        traversalContext = new PlayerTraversalContext(characterController, traversalInput, stats);
        climbModifier = new ClimbModifier(traversalContext);
    }
    public bool IsClimbPressed => traversalInput.IsClimbPressed;
    public bool IsWallAvailable => area.CheckOverlap();

    public void Climb()
    {
        climbModifier.Update();

        characterController.Move(traversalContext.Velocity * Time.deltaTime);
    }

    public void Vault(Action onVaultComplete, Action onVaultFailed)
    {
        if (!Physics.Raycast(vaultPoint.position, Vector3.down, out RaycastHit hit, 2f, vaultableSurfaces, QueryTriggerInteraction.Ignore)) 
        {
            onVaultFailed?.Invoke();
            return; 
        }

        Vector3 point = hit.point + Vector3.up * 0.25f;

        traversalContext.Transform.DOMove(point, traversalContext.Stats.VaultDuration).onComplete += () => onVaultComplete?.Invoke();
    }
}
