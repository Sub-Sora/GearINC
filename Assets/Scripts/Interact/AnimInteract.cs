using UnityEngine;

public class AnimInteract : MonoBehaviour
{
    [HideInInspector]
    public bool AnimEnd;

    [HideInInspector]
    public bool LateAnim;

    private AreaEngine _engine;

    private void Start()
    {
        AnimEnd = false;
        LateAnim = false;
        _engine = GetComponent<AreaEngine>();
    }

    /// <summary>
    /// Se d�clanche lors de la fin de l'animation
    /// </summary>
    public void AnimationFinished()
    {
        AnimEnd = true;
        _engine.Complete();
        Debug.Log("Anim Finish");
    }

    /// <summary>
    /// Se d�clanche quand au moment dit "trop tard" et que l'objet rate
    /// </summary>
    public void TooLateAnim()
    {
        LateAnim = true;
    }
}
