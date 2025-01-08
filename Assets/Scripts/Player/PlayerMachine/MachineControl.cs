using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static PlayerMain;

public class MachineControl : MonoBehaviour
{
    public MachineInteract _interact;

    private List<AreaEngine> _listEngine = new List<AreaEngine>();

    //Take the current Engine come from
    private int _currentEngine;

    private int _moving;
    private bool _isMoving;

    [Header("Movement")]

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _maxZ;

    private Quaternion _lastRotation;


    [Header("Joystick")]

    [SerializeField]
    private GameObject _joyStick;

    [SerializeField]
    private float _joyStickDeadZone;

    [SerializeField]
    private GameObject _joyStickMovable;

    private Vector2 _initJoyStickPos;

    /// <summary>
    /// Vas initialiser un passage pour l'agent pour éviter des erreurs de démarage
    /// </summary>
    public void InitializedPath(List<AreaEngine> engineList)
    {
        _listEngine = engineList;
        _interact = GetComponent<MachineInteract>();
        _currentEngine = 0;
        _interact.InitializedPath(engineList);
    }

    private void Start()
    {
        _initJoyStickPos = _joyStick.transform.position;
    }

    private void FixedUpdate()
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
                Quaternion targetRotation = Quaternion.LookRotation(moveDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
                _lastRotation = transform.rotation;
            }
            else 
            {
                if (_lastRotation != null) transform.rotation = _lastRotation;
                if (_interact.CurrentEngine != null)
                {
                    _interact.StopMoving();
                }
            }
        }

        if (transform.position.z > _maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _maxZ);
        }
    }
}
