using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInteract : MonoBehaviour
{
    public bool AnimEnd;

    public bool LateAnim;

    private void Start()
    {
        AnimEnd = false;
        LateAnim = false;
    }

    public void AnimationFinished()
    {
        AnimEnd = true;
    }

    public void TooLate()
    {
        LateAnim = true;
    }
}
