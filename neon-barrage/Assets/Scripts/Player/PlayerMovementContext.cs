using UnityEngine;

public class PlayerMovementContext
{
    private readonly CharacterController controller;
    private readonly PlayerMovementInput input;

    public CharacterController Controller => controller;
    public Transform Transform => controller.transform;
    public PlayerMovementInput Input => input;
    public Vector3 Velocity = Vector3.zero;

    public PlayerMovementContext(CharacterController controller, PlayerMovementInput input)
    {
        this.controller = controller;
        this.input = input;
    }
}