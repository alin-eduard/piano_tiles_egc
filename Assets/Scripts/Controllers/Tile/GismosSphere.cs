using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GismosSphere : MonoBehaviour
{
    [SerializeField] [Range(0.05f, 0.2f)] private float radius = 0.2f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
