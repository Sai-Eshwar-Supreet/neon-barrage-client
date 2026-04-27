using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] Vector3 center;
    [SerializeField] Vector3 size;

    private readonly Collider[] results = new Collider[8];

    public bool CheckOverlap()
    {
        int count = Physics.OverlapBoxNonAlloc(
            transform.position + center,
            size * 0.5f,
            results,
            transform.rotation,
            mask,
            QueryTriggerInteraction.Ignore
        );

        return count > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        var defaultMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(center, size);

        Gizmos.matrix = defaultMatrix;
    }
}