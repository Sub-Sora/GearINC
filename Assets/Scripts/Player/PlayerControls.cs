using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private GameObject _stick;

    [SerializeField]
    private InputActionReference _moveAction;

    [SerializeField]
    private GameObject _canva;

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

    // WIP Joystick 

    //private void OnTouch(InputValue value)
    //{

    //    //Debug.Log(value.Get<Vector2>());
    //    Debug.Log(Touchscreen.current.position);
    //    bool stickShow = false;
    //    if (stickShow == false)
    //    {
    //        var joyStick = Instantiate(_stick, Touchscreen.current.position.ReadValue(), Quaternion.identity);
    //        joyStick.transform.parent = _canva.transform;
    //    }
    //}
}
