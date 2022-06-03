using UnityEngine;

public class GizmosSphere : MonoBehaviour
{
    [SerializeField] [Range(0.05f, 0.2f)] private float radius = 0.2f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
