using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{

    // EVENTS
    public delegate void SFXEventStep(bool isWalking);
    public SFXEventStep playerStep, robotStep;

    public delegate void SFXEvents();

    // MUSIC
    public AudioSource AudioDrum;

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

    public void ChangeMusic()
    {
        if (SceneManager.GetActiveScene().name == "TutoMenu")
        {
            AudioDrum.DOFade(0, 2f);
        }
        else
        {
            AudioDrum.DOFade(1, 2f);
        }
    }
}
