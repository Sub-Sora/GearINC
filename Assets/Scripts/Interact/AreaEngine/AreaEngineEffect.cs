using UnityEngine;

public class AreaEngineEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject _circle;

    [SerializeField]
    private Material _classicMat;

    [SerializeField]
    private Material _badMat;

    [SerializeField]
    private Material _goodMat;

    public void GetARessource()
    {
        ChangeCircle(_classicMat);
        _circle.SetActive(true);
    }

    public void AnimFailed()
    {
        ChangeCircle(_badMat);
    }

    public void AnimClear()
    {
        ChangeCircle(_goodMat);
    }

    public void DesactivateCircle()
    {
        _circle.SetActive(false);
    }

    private void ChangeCircle(Material mat)
    {
        _circle.GetComponent<MeshRenderer>().material = mat;
    }
}