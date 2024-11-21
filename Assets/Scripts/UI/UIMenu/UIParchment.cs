using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParchment : MonoBehaviour
{
    [SerializeField]
    private Animator _scrollAnim;

    private bool _isOpen;

    [HideInInspector]
    public bool _isAnim;

    private void Start()
    {
        _scrollAnim = this.GetComponent<Animator>();
    }

    public void OpenScroll()
    {
        if (!_isOpen && !_isAnim)
        {
            _scrollAnim.SetBool("isScrolled", true);
            _isOpen = true;
            _isAnim = true;
        }
        if (_isOpen && !_isAnim)
        {
            _scrollAnim.SetBool("isScrolled", false);
            _isOpen = false;
            _isAnim = true;
        }
    }

    public void EndAnim()
    {
        _isAnim = false;
    }
}
