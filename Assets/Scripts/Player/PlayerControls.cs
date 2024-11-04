using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _moveAction;

    [SerializeField]
    private float _speed;

    private Vector3 _dir;

    private CharacterController controller;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 inputDir = _moveAction.action.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);

        controller.Move(moveDir * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
