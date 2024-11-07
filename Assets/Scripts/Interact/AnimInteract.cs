using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInteract : MonoBehaviour
{
    [HideInInspector]
    public bool AnimEnd;

    [HideInInspector]
    public bool LateAnim;

    private void Start()
    {
        AnimEnd = false;
        LateAnim = false;
    }

    /// <summary>
    /// Se déclanche lors de la fin de l'animation
    /// </summary>
    public void AnimationFinished()
    {
        AnimEnd = true;
        Debug.Log("Anim Finish");
    }

    /// <summary>
    /// Se déclanche quand au moment dit "trop tard" et que l'objet rate
    /// </summary>
    public void TooLateAnim()
    {
        LateAnim = true;
        Debug.Log("Too Late to go");
    }
}
