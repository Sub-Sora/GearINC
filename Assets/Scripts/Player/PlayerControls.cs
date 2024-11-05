using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _moveAction;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private CharacterController controller;

    private Quaternion _lastRotation;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 inputDir = _moveAction.action.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);
        controller.Move(moveDir * _speed * Time.deltaTime);

        if (inputDir != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            _lastRotation = transform.rotation;
        }
        else if (_lastRotation != null)
        {
            transform.rotation = _lastRotation;
        }

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
