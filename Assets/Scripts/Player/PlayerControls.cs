using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    private GameObject _stick;

    Button a;

    [SerializeField]
    private InputActionReference _moveAction;

    [SerializeField]
    private GameObject _canva;

    [SerializeField]
    private GameObject _interactButton;

    [SerializeField]
    private float _speed;

    private Vector3 _dir;

    private CharacterController controller;

    [SerializeField] GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;

    /// <summary>
    /// Permet de faire bouger le personnage
    /// </summary>
    void FixedUpdate()
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

        SpawnJoystick();
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
