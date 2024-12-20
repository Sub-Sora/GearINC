using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private string _levelSceneName;

    public void LoadLevel(ObjectiveObject levelObjective)
    {
        ManagerMain.Instance.Objective.Object = levelObjective;
        SceneManager.LoadScene(_levelSceneName);
    }

    public void ReloadLevel(ObjectiveObject levelObjective)
    {
        levelObjective = ManagerMain.Instance.Objective.Object;
        _levelSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_levelSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadTutoMenu()
    {
        SceneManager.LoadScene("MenuTuto");
    }
}