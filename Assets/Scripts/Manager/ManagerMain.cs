using UnityEngine;

public class ManagerMain : MonoBehaviour
{
    private static ManagerMain _instance = null;
    public static ManagerMain Instance => _instance;

    public Objective Objective;

    public void Awake()
    {
        if (_instance != null && _instance != this)
        {
            _instance.Awake();
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}