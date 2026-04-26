using UnityEngine;
using static UnityEngine.InputSystem.DefaultInputActions;

[DisallowMultipleComponent]
public class PlayerInputManager : MonoBehaviour
{
    private PlayerActions m_playerActions;

    public PlayerActions.MovementActions Movement
    {
        get
        {
            if (m_playerActions == null) Initialise();
            return m_playerActions.Movement;
        }
    }

    private void Awake()
    {
        if (m_playerActions == null) Initialise();
    }

    private void Initialise() => m_playerActions = new PlayerActions();
}
