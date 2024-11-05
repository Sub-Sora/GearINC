using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _moveAction;

    [SerializeField]
    private GameObject _joyStick;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Quaternion _lastRotation;

    /// <summary>
    /// Permet de faire bouger le personnage
    /// </summary>
    void FixedUpdate()
    {
        Vector2 inputDir = _moveAction.action.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);

        // Le personnage se déplacera
        transform.Translate(moveDir * _speed * Time.deltaTime, Space.World);

        // Va changer la rotation du personnage
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

        if (_joyStick.activeSelf)
        {
            if (Input.touchCount == 0)
            {
                _joyStick.SetActive(false);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                _joyStick.SetActive(true);
                _joyStick.transform.position = new Vector2(touch.position.x, touch.position.y);
            }
        }
        
    }
}
