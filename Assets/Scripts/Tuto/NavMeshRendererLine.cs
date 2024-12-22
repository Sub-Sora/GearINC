using UnityEngine;
using UnityEngine.AI;

public class NavMeshRendererLine : MonoBehaviour
{
    public Transform target;
    public LineRenderer lineRenderer;
    public NavMeshAgent navMeshAgent;

    void Update()
    {
        NavMeshPath path = new NavMeshPath();

        if (NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path))
        {
            DisplayPath(path);
        }
    }

    void DisplayPath(NavMeshPath path)
    {
        if (path.corners.Length == 0)
            return;

        lineRenderer.positionCount = path.corners.Length;

        for (int i = 0; i < path.corners.Length; i++)
        {
            lineRenderer.SetPosition(i, path.corners[i]);
        }
    }
}
