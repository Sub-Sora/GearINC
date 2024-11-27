using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private string levelSceneName;

    [SerializeField]
    private string levelSceneNameNewGameplay;

    public void LoadLevel(ObjectiveObject levelObjective)
    {
        ManagerMain.Instance.Objective.Object = levelObjective;
        SceneManager.LoadScene(levelSceneName);
    }

    public void LoadLevelNewGameplay(ObjectiveObject levelObjective)
    {
        ManagerMain.Instance.Objective.Object = levelObjective;
        SceneManager.LoadScene(levelSceneNameNewGameplay);
    }
}