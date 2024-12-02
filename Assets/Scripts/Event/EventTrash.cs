using System.Collections.Generic;
using UnityEngine;

public class EventTrash : EventMap
{
    public List<GameObject> Rubbishs = new List<GameObject>();
    public List<Vector3> Points = new List<Vector3>();

    [SerializeField]
    private int _numberOfRubbish;

    public override void EventBegin()
    {
        for (int i = 0; i < _numberOfRubbish; ++i)
        {
            int randomPoint = Random.Range(0, Points.Count);
            Instantiate(Rubbishs[Random.Range(0, Rubbishs.Count)], Points[randomPoint], Quaternion.identity);
            Points.RemoveAt(randomPoint);
        }
    }

}