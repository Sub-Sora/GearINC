using UnityEngine;
using UnityEditor;
using static Job;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using Codice.Client.BaseCommands.Merge.Xml;

[CustomEditor(typeof(ObjectiveObject))]

public class ObjectiveObjectEditor : Editor
{

    /* public override void OnInspectorGUI()
     {
         serializedObject.Update();

         SerializedProperty list = serializedObject.FindProperty("properties");
         EditorGUILayout.PropertyField(list, true); //true means includeChildren=true, which allows me to expand and collapse the array.

         EditorGUILayout.HelpBox("The value is measured in µg (micrograms).", MessageType.Info);

         serializedObject.ApplyModifiedProperties();
     }


    private SerializedProperty _typesNeededProperty;
    private SerializedProperty _allJobProperty;
    private int _lastListSize;
    private void OnEnable()
    {
        _typesNeededProperty = serializedObject.FindProperty("TypesNeeded");
        _allJobProperty = serializedObject.FindProperty("AllJob");
        //_lastListSize = _allJobProperty.arraySize;
        //_lastListSize = _allJobProperty.arraySize;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Liste des types de jobs présent", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_allJobProperty, true);

        EditorGUILayout.LabelField("Liste des types de jobs besoins", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_typesNeededProperty, true);
        

        Debug.Log(_allJobProperty.arraySize);

         if (_allJobProperty.arraySize == 0)
         {
             EditorGUILayout.HelpBox("La liste est vide. Ajoutez un élément pour commencer.", MessageType.Info);
         }

         for (int i = 0; i < Enum.GetValues(typeof(JobType)).Length; i++)
         {
             Debug.Log(_allJobProperty.GetArrayElementAtIndex(i));
             SerializedProperty element = _allJobProperty.GetArrayElementAtIndex(i);
             element.enumValueIndex = (int)(JobType)EditorGUILayout.EnumPopup("Element " + i, (JobType)element.enumValueIndex);

             element.enumValueIndex = EditorGUILayout.IntField("Nombre " + i, element.intValue);
             Debug.Log(element.enumValueIndex);

         }

         if (GUILayout.Button("Ajouter un élément"))
         {
             _allJobProperty.arraySize++; // Augmente la taille de la liste
             _allJobProperty.GetArrayElementAtIndex(_allJobProperty.arraySize - 1).enumValueIndex = 0; // Initialise le nouvel élément à la première valeur de l'enum
         }


         if (_allJobProperty.arraySize != _lastListSize)
         {
             SetAnotherValueOnAllJob();
         }



         var options = new[] { JobType.none, JobType.carpenter };

         int index = Mathf.Max(0, Array.IndexOf(options, (JobType)_allJobProperty.enumValueIndex));

         // Affiche uniquement les options limitées
         index = EditorGUILayout.Popup("Options", index, Array.ConvertAll(options, item => item.ToString()));
         _typesNeededProperty.enumValueIndex = (int)options[index];

         //NormalizeSpawnPercentages();

        serializedObject.ApplyModifiedProperties();
    }

    private Array GetAllValueAvailable()
    {
        List<JobType> result = new List<JobType>();

        for(int i = 0; i <= _lastListSize - 1; i++)
        {
            //result.Add(_allJobProperty.GetArrayElementAtIndex(i));
            SerializedProperty element = _allJobProperty.GetArrayElementAtIndex(i);
            element.enumValueIndex = (int)(JobType)EditorGUILayout.EnumPopup("Element " + i, (JobType)element.enumValueIndex);
            element.enumValueIndex = EditorGUILayout.IntField("Nombre " + i, element.intValue);

        }

        return _allJobProperty.arr
    }

    private void SetAnotherValueOnAllJob()
    {
        for (int i = 0; i <= _lastListSize - 1; i++)
        {

        }

        string enumString = "Carpenter";
        JobType parsed_enum = (JobType)System.Enum.Parse(typeof(JobType), enumString);
        Debug.Log(parsed_enum);
    }*/
}
