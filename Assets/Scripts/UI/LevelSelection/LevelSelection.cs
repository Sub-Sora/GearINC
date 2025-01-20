using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private string _levelSceneName;

    public void LoadNextLevel()
    {
        ManagerMain.Instance.Objective.Object = ManagerMain.Instance.Objective.Object.NextObjective;
        SceneManager.LoadScene(_levelSceneName);
    }

    public void LoadLevel(ObjectiveObject levelObject)
    {
        ManagerMain.Instance.Objective.Object = levelObject;
        SceneManager.LoadScene(_levelSceneName);
    }

    public void ReloadLevel()
    {
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