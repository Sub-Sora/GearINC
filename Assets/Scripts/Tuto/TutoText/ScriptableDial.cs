using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New_Dial_Tuto", menuName = "Tuto/New Dial Tuto")]
public class ScriptableDial : ScriptableObject
{
    [SerializeField]
    private Dial[] _allLines;

    public Dial GetLineByIndex(int index)
    {
        return _allLines[index];
    }

    public int GetLenght()
    {
        return _allLines.Length -1;
    }
}
