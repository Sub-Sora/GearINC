using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TutoText", menuName = "Tuto Text")]
public class ScirptableText : ScriptableObject
{
    [TextArea(15, 20)]
    public string text = "";
}
