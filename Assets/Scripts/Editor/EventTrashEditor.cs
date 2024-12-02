using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EventTrash))]

public class EventTrashEditor : Editor
{
    private void OnSceneGUI()
    {
        EventTrash gizmo = (EventTrash)target;
        for (int i = 0; i < gizmo.Points.Count; i++)
        {
            // Afficher le label pour chaque point
            Handles.Label(gizmo.transform.position + gizmo.Points[i], $"Trash Spawn: {i}", new GUIStyle
            {
                fontStyle = FontStyle.Bold,
                normal = new GUIStyleState { textColor = Color.white }
            });

            // Manipuler la position avec PositionHandle
            Vector3 newPosition = Handles.PositionHandle(gizmo.transform.position + gizmo.Points[i], Quaternion.identity);

            // Vérifier si le point a changé de position
            if (gizmo.Points[i] != newPosition - gizmo.transform.position)
            {
                Undo.RecordObject(gizmo, "Move Point");
                gizmo.Points[i] = newPosition - gizmo.transform.position;
            }
        }
    }
}
