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

    }
}
