using UnityEngine;
using UnityEngine.VFX;

public class PlayerVFX : MonoBehaviour
{
    public bool IsWalking;

    public VisualEffect WalkEffect;

    private void Init(PlayerMain main)
    {
        main.VFX = this;
    }

    public void StartWalkingVFX()
    {
        if (!IsWalking)
        {
            IsWalking = true;
            WalkEffect.Play();
        }
    }

    public void StopWalkingVFX()
    {
        if (IsWalking)
        {
            IsWalking = false;
            WalkEffect.Stop();
        }
    }

    private void FixedUpdate()
    {
        if (IsWalking)
        {
            //Debug.Log("move");
        }
    }
}