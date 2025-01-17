using UnityEngine;
using UnityEngine.Events;

public class SFXManager : MonoBehaviour
{

    // EVENTS
    public delegate void SFXEventStep(bool isWalking);
    public SFXEventStep playerStep, robotStep;

    public delegate void SFXEvents();

    //SINGLETON
    private static SFXManager instance = null;
    public static SFXManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
