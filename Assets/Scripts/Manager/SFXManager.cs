using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour
{

    // EVENTS
    public delegate void SFXEventStep(bool isWalking);
    public SFXEventStep playerStep, robotStep;

    public delegate void SFXEvents();

    // MUSIC
    public AudioSource AudioSource { get; private set; }
    public AudioClip MenuMusic, LevelMusic;

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
            AudioSource.clip = LevelMusic;
        }
        else
        {
            AudioSource.clip = MenuMusic;
        }
    }
}
