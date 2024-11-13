using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private string levelSceneName;

    public void LoadLevel(ObjectiveObject levelObjective)
    {
        ManagerMain.Instance.Objective.Object = levelObjective;
        SceneManager.LoadScene(levelSceneName);
    }
}