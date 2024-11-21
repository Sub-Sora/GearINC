using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerControls : MonoBehaviour
{
    public bool IsGameInit;

    [SerializeField]
    private InputActionReference _moveAction;

    [Header("Joystick")]

    [SerializeField]
    private GameObject _joyStick;

    [SerializeField] 
    private float _joyStickDeadZone;

    [SerializeField]
    private GameObject _joyStickMovable;

    [Header("Movement")]

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

    private Vector2 _initJoyStickPos;

    private PlayerMain _main;

    void FixedUpdate()
    {
        if (IsGameInit)
        {
            MovePlayer();
            SpawnJoystick();
        }
    }

    private void Init(PlayerMain main)
    {
        _main = main;
        main.Controls = this;
    }

    public void InitThePlayer()
    {
        IsGameInit = true;
    }

    /// <summary>
    /// Permet de faire bouger le personnage
    /// </summary>
    private void MovePlayer()
    {
        if (_joyStick.activeSelf)
        {
            float distanceJoystick = Vector3.Distance(_joyStickMovable.transform.position, _initJoyStickPos);
            if ((Vector2)_joyStickMovable.transform.position != _initJoyStickPos)
            {
                Vector2 inputDir = new Vector2(_joyStickMovable.transform.position.x - _initJoyStickPos.x, _joyStickMovable.transform.position.y - _initJoyStickPos.y).normalized;

                if (distanceJoystick < _joyStickDeadZone)
                {
                    inputDir = Vector2.zero;
                }

                Vector3 moveDir = new Vector3(inputDir.x, 0, inputDir.y);
                transform.Translate(moveDir * _speed * Time.deltaTime, Space.World);

                if (inputDir != Vector2.zero)
                {
                    _main.VFX.StartWalkingVFX();
                    Quaternion targetRotation = Quaternion.LookRotation(moveDir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
                    _lastRotation = transform.rotation;
                }
                else if (_lastRotation != null)
                {
                    transform.rotation = _lastRotation;
                    _main.VFX.StopWalkingVFX();
                }
            }
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
                _main.VFX.StopWalkingVFX();
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
                    _initJoyStickPos = touchePos;
                }
            }
        }
    }
}
