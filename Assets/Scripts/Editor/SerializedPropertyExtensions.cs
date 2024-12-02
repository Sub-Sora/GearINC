using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class SerializedPropertyExtensions
{
    public static Type GetPropertyType(SerializedProperty property)
    {
        if (property == null) return null;

        // Obtenez l'objet sérialisé (SerializedObject)
        object targetObject = property.serializedObject.targetObject;
        if (targetObject == null) return null;

        // Divisez le chemin en parties
        string[] pathParts = property.propertyPath.Split('.');

        Type currentType = targetObject.GetType();
        for (int i = 0; i < pathParts.Length; i++)
        {
            FieldInfo field = currentType.GetField(pathParts[i],
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (field == null)
                return null; // Le champ n'existe pas (peut-être un tableau ou une propriété)

            currentType = field.FieldType;

            // Gérer les tableaux ou les listes
            if (currentType.IsArray)
            {
                currentType = currentType.GetElementType();
            }
            else if (typeof(System.Collections.IEnumerable).IsAssignableFrom(currentType) &&
                     currentType.IsGenericType)
            {
                currentType = currentType.GetGenericArguments()[0];
            }
        }

        return currentType;
    }
}