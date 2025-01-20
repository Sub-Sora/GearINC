using UnityEngine;
using System.Collections.Generic;
public class UIChangeLevelSelection : MonoBehaviour
{
    [SerializeField]
    private List<Level> _levels = new List<Level>();

    private int _selectedLevel;

    public void LeftLevel()
    {
        if (_levels[_selectedLevel].CanBeUsed)
        {
            _levels[_selectedLevel].CanBeUsed = false;
            _levels[_selectedLevel].GetComponent<Animator>().SetBool("left", true);

            if (_selectedLevel == 0)
            {
                _levels[_levels.Count - 1].gameObject.SetActive(true);
                _levels[_levels.Count - 1].GetComponent<Animator>().SetBool("otherLeft", true);
                _selectedLevel = _levels.Count - 1;
            }
            else
            {
                _levels[_selectedLevel - 1].gameObject.SetActive(true);
                _levels[_selectedLevel - 1].GetComponent<Animator>().SetBool("otherLeft", true);
                _selectedLevel--;
            }
        }
    }

    public void RightLevel()
    {
        if (_levels[_selectedLevel].CanBeUsed)
        {
            _levels[_selectedLevel].CanBeUsed = false;
            _levels[_selectedLevel].GetComponent<Animator>().SetBool("right", true);

            if (_selectedLevel == _levels.Count - 1)
            {
                _levels[0].gameObject.SetActive(true);
                _levels[0].GetComponent<Animator>().SetBool("otherRight", true);
                _selectedLevel = 0;
            }
            else
            {
                _levels[_selectedLevel + 1].gameObject.SetActive(true);
                _levels[_selectedLevel + 1].GetComponent<Animator>().SetBool("otherRight", true);
                _selectedLevel++;
            }
        }
    }
}