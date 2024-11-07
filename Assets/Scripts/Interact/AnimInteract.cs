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

    public void AnimationFinished()
    {
        AnimEnd = true;
        Debug.Log("Anim Finish");
    }

    public void TooLateAnim()
    {
        LateAnim = true;
        Debug.Log("Too Late to go");
    }
}
