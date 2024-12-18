using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    public void ShowScoreMenu()
    {
        ScoreManager.Instance.StarsScore();
    }
}
