using UnityEngine;

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

    public PlayerActions.TraversalActions Traversal
    {
        get
        {
            if (m_playerActions == null) Initialise();
            return m_playerActions.Traversal;
        }
    }

    private void Awake()
    {
        if (m_playerActions == null) Initialise();
    }

    private void Initialise() => m_playerActions = new PlayerActions();
}
