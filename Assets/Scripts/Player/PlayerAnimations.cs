using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerMain _main;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _main = GetComponent<PlayerMain>();
        _main.ControlPost += ControlPostAnim;
    }

    private void ControlPostAnim(bool isDoing)
    {
        _animator.SetBool("isControl", isDoing);
    }
}
