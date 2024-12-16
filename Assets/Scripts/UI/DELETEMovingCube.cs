using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DELETEMovingCube : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 5;

    private void FixedUpdate()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime, _rotationSpeed * Time.deltaTime, 0);
    }
}
