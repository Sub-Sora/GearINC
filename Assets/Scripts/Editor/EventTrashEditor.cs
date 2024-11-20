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
            // Afficher le label pour chaque point
            Handles.Label(gizmo.transform.position + gizmo.points[i], $"Trash Spawn: {i}", new GUIStyle
            {
                fontStyle = FontStyle.Bold,
                normal = new GUIStyleState { textColor = Color.white }
            });

            // Manipuler la position avec PositionHandle
            Vector3 newPosition = Handles.PositionHandle(gizmo.transform.position + gizmo.points[i], Quaternion.identity);

            // Vérifier si le point a changé de position
            if (gizmo.points[i] != newPosition - gizmo.transform.position)
            {
                Undo.RecordObject(gizmo, "Move Point");
                gizmo.points[i] = newPosition - gizmo.transform.position;
            }
        }
    }
}
