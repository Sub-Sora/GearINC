using UnityEngine;

public class AnimInteract : MonoBehaviour
{

    [HideInInspector]
    public bool LateAnim;

    private AreaEngine _engine;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();  
        LateAnim = false;
        _engine = GetComponent<AreaEngine>();
    }

    /// <summary>
    /// Se d�clanche lors de la fin de l'animation
    /// </summary>
    public void AnimationFinished()
    {
        _animator.SetBool("isPlay", false);
        _engine.Complete();
    }

    /// <summary>
    /// Se d�clanche quand au moment dit "trop tard" et que l'objet rate
    /// </summary>
    public void TooLateAnim()
    {
        LateAnim = true;
    }
}
