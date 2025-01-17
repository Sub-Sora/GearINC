using UnityEngine;

public class AnimInteract : MonoBehaviour
{

    [HideInInspector]
    public bool LateAnim;

    public AreaEngine Engine;

    public Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
        LateAnim = false;
    }

    /// <summary>
    /// Se déclanche lors de la fin de l'animation
    /// </summary>
    public void AnimationFinished()
    {
        Animator.SetBool("isPlay", false);
        Engine.Complete();
    }

    /// <summary>
    /// Se déclanche quand au moment dit "trop tard" et que l'objet rate
    /// </summary>
    public void TooLateAnim()
    {
        LateAnim = true;
    }
}
