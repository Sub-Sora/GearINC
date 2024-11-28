using System.Collections;
using System.Collections.Generic;
using CandyCoded.HapticFeedback;
using UnityEngine;
using UnityEngine.Events;

public class HapticButton : MonoBehaviour
{
    public UnityEvent hapticEvent;

    private void Start()
    {
        if (hapticEvent != null) hapticEvent = new UnityEvent();
        hapticEvent.AddListener(PlayHapticButton);
    }

    public void PlayHapticButton()
    {
        HapticFeedback.LightFeedback();
    }
}
