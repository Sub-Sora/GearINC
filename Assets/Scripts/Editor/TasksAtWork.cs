using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
//using static SerializedPropertyExtensions;

[CustomEditor(typeof(AllTasks))]

public class TasksAtWork : Editor
{
    
    private SerializedProperty _tasksInProgressProperty;
    string stringToEdit = "";
    private int leftPosition = Screen.width / 2;
    private int topPosition = Screen.height / 2;
    private int boxHeight = 20;
    private float newBoxWidth;
    private GUIStyle myStyle = new GUIStyle();
    Vector2 sizeOfLabel;

    void Start()
    {
        myStyle.alignment = TextAnchor.MiddleCenter;
        //any other styles
    }
    private void OnEnable()
    {
        //_tasksInProgressProperty = serializedObject.FindProperty("TasksInProgress");
    }
    public override void OnInspectorGUI()
    {
        //serializedObject.Update();

        
        /*EditorGUILayout.LabelField("Tache en cours", EditorStyles.boldLabel);
        for (int i = 0;  i < _tasksInProgressProperty.arraySize; i++)
        {
            SerializedProperty elementProperty = _tasksInProgressProperty.GetArrayElementAtIndex(i);
            AllTasks convertedMCL = elementProperty.objectReferenceValue as System.Object as AllTasks;
            if (convertedMCL == null)
            {
                convertedMCL = new AllTasks();
            }
            Debug.Log(convertedMCL);
            if (elementProperty.objectReferenceValue != null)
            {
                if (elementProperty.objectReferenceValue is AllTasks scriptInstance)
                {
                    EditorGUILayout.LabelField(scriptInstance.TasksInProgress[i].TasksName, EditorStyles.boldLabel);
                }
                else
                {
                    Debug.Log("Mauvais");
                }
            }
            else
            {
                Debug.Log("pire");
            }

            GUILayout.BeginHorizontal();
            EditorGUILayout.Toggle(false);
            //EditorGUILayout.LabelField(_tasksInProgressProperty.GetArrayElementAtIndex(i).GetType(), EditorStyles.boldLabel);
            GUILayout.Button("Info");
            GUILayout.EndHorizontal();
            /*
            //Calculates the size of your label text with myStyle
            sizeOfLabel = myStyle.CalcSize(new GUIContent(_tasksInProgressProperty.GetArrayElementAtIndex(i).stringValue));

            //sizeOfLabel.x will get the length. +6 can be adjusted for padding	
            newBoxWidth = sizeOfLabel.x + 6;

            //The background box behind the label, just for the example.
            GUI.Box(new Rect(leftPosition - newBoxWidth / 2, topPosition + 15 * i, newBoxWidth, boxHeight), "");

            //The label text, this example is centered
            GUI.Label(new Rect(leftPosition - newBoxWidth / 2, topPosition + 15 * i, newBoxWidth, boxHeight), _tasksInProgressProperty.GetArrayElementAtIndex(i).stringValue, myStyle);

            //The button, drawn to the right of wherever the label ends.
            GUI.Button(new Rect(leftPosition + newBoxWidth / 2, topPosition + 15 * i, 25, boxHeight), "");
            
        }

       stringToEdit = GUILayout.TextField(stringToEdit, 25);

        if (GUILayout.Button("Ajouter un élément"))
        {
            _tasksInProgressProperty.arraySize++; // Augmente la taille de la liste
            SerializedProperty elementProperty = _tasksInProgressProperty.GetArrayElementAtIndex(_tasksInProgressProperty.arraySize-1);
            Tasks convertedMCL = elementProperty.objectReferenceValue as System.Object as Tasks;
            if (_tasksInProgressProperty.GetArrayElementAtIndex(_tasksInProgressProperty.arraySize - 1).objectReferenceValue is Tasks scriptInstance)
            {
                scriptInstance.TasksName = stringToEdit;
            }
        }

        
    }*/

       /* if (GUILayout.Button("Ajouter une tâche"))
        {
            // Ajouter une tâche fictive (à personnaliser selon vos besoins)
            Tasks newTask = CreateTaskExample();
            taskManager.AddTask(newTask);
            EditorUtility.SetDirty(taskManager); // Marque le script comme modifié pour sauvegarde
        }
       */
        serializedObject.ApplyModifiedProperties();
    }

    /*private Tasks CreateTaskExample()
    {
        // Crée un nouveau GameObject avec le script Tasks (exemple)
        GameObject newTaskObject = new GameObject("NewTask");
        Tasks newTask = newTaskObject.AddComponent<Tasks>();
        newTask.TasksName = "Nouvelle Tâche";
        return newTask;
    }*/

}
