using UnityEngine;

public class Level : MonoBehaviour
{
    public bool CanBeUsed;

    public void HideLevel()
    {
        gameObject.SetActive(false);
    }

    public void ShowLevel()
    {
        CanBeUsed = true;
    }
}