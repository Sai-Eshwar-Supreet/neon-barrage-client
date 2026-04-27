using UnityEngine;

public class PlayerTraversalContext
{
    public CharacterController Controller { get; private set; }
    public Transform Transform => Controller.transform;
    public PlayerTraversalInput Input { get; private set; }
    public PlayerStats Stats { get; private set; }
    public Vector3 Velocity { get; set; } = Vector3.zero;

    public PlayerTraversalContext(CharacterController controller, PlayerTraversalInput input, PlayerStats stats)
    {
        Controller = controller;
        Input = input;
        Stats = stats;
    }
}
