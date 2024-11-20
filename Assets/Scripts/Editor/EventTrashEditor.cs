using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventTrashTooling))]

public class EventTrashEditor : Editor
{
    private void OnSceneGUI()
    {
        EventTrashTooling gizmo = (EventTrashTooling)target;
        Debug.Log("gui");
        for (int i = 0; i < gizmo.points.Count; i++)
        {
            // Utiliser Handles pour cr�er un handle de position ajustable pour chaque point
            Vector3 newPosition = Handles.PositionHandle(gizmo.transform.position + gizmo.points[i], Quaternion.identity);
            if (gizmo.points[i] != newPosition - gizmo.transform.position)
            {
                // Enregistrer la modification dans l'historique pour permettre les annulations
                Undo.RecordObject(gizmo, "Move Point");
                gizmo.points[i] = newPosition - gizmo.transform.position;
            }
        }
    }
}
