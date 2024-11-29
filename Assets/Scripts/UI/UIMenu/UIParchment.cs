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

    private HapticButton _haptic;

    private void Start()
    {
        _scrollAnim = GetComponent<Animator>();
        _haptic = GameObject.Find("Canvas").GetComponent<HapticButton>();

    }

    public void OpenScroll()
    {
        if (!_isOpen && !_isAnim)
        {
            if (_haptic != null) _haptic.hapticEvent.Invoke();
            _scrollAnim.SetBool("isScrolled", true);
            _isOpen = true;
            _isAnim = true;
        }
        if (_isOpen && !_isAnim)
        {
            if (_haptic != null) _haptic.hapticEvent.Invoke();
            _scrollAnim.SetBool("isScrolled", false);
            _isOpen = false;
            _isAnim = true;
            Handheld.Vibrate();
        }
    }

    public void EndAnim()
    {
        _isAnim = false;
    }

    public void ResetAnim()
    {
        _scrollAnim.SetBool("isScrolled", false);
        _isOpen = false;
        _isAnim = false;
    }
}
