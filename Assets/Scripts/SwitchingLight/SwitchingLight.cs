using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingLight : MonoBehaviour
{
    [SerializeField]
    private string _lightLvlToLoad;

    public void LoadLightLevel()
    {
        SceneManager.LoadScene(_lightLvlToLoad, LoadSceneMode.Additive);
    }

    public void UnloadLightLevel()
    {
        SceneManager.UnloadSceneAsync(_lightLvlToLoad);
    }
}
