using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private InputActionReference _moveAction;

    [Header("Movement")]

    [SerializeField]
    private GameObject _joyStick;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Quaternion _lastRotation;

    [Header("Canva Raycast")]

    [SerializeField]
    private GraphicRaycaster m_Raycaster;

    [SerializeField]
    private EventSystem m_EventSystem;

    [SerializeField]
    private RectTransform canvasRect;

    private PointerEventData m_PointerEventData;

    void FixedUpdate()
    {
        MovePlayer();
        SpawnJoystick();
    }

    /// <summary>
    /// Permet de faire bouger le personnage
    /// </summary>
    private void MovePlayer()
    {
        Vector2 inputDir = _moveAction.action.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);

        // Le personnage se d�placera
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


    /// <summary>
    /// Permet de faire spawn le joystick
    /// Si jamais notre doigt est sur l'ui on ne pourra pas le faire spawn
    /// </summary>
    private void SpawnJoystick()
    {

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

                Vector2 touchePos = new Vector2(touch.position.x, touch.position.y);
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the game object
                m_PointerEventData.position = touchePos;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);

                if (results.Count == 0)
                {
                    _joyStick.SetActive(true);
                    _joyStick.transform.position = touchePos;
                }
            }
        }
    }
}
