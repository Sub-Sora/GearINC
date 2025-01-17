using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // CAMERA //
    [SerializeField]
    private CinemachineVirtualCamera _robotCam;
    [SerializeField]
    private CinemachineVirtualCamera _playerCam;

    [SerializeField]
    private float _fovAnimGameOver = 35;

    [SerializeField]
    private int _zoomSpeed = 5;

    // PLAYER //
    private GameObject _player;

    private Animator _anim;

    [SerializeField]
    private float _rotationSpeed = 1;

    void Start()
    {
        ScoreManager.Instance.GameOverEvnt += StartGameOver;
        _player = GameObject.FindGameObjectWithTag("Player");
        _anim = _player.GetComponentInChildren<Animator>();
    }

    public void TestGameOver()
    {
        ScoreManager.Instance.GameOverEvnt.Invoke();
    }

    private void StartGameOver()
    {
        _robotCam.Priority = 0;
        _playerCam.Priority = 10;
        StartCoroutine("WaitUntilAnimation");
        _player.transform.DORotate(new Vector3(0, 180, 0), _rotationSpeed);
    }

    private IEnumerator WaitUntilAnimation()
    {
        while (_playerCam.m_Lens.FieldOfView > _fovAnimGameOver)
        {
            _playerCam.m_Lens.FieldOfView = Mathf.Lerp(_playerCam.m_Lens.FieldOfView, _fovAnimGameOver -1, Time.deltaTime * _zoomSpeed);

        yield return null;
        }
        _playerCam.m_Lens.FieldOfView = _fovAnimGameOver;

        _anim.SetBool("isWinning", ScoreManager.Instance.IsWin);
        _anim.SetBool("winState", true);
        AnimatorStateInfo animationState = _anim.GetCurrentAnimatorStateInfo(0);
        float animationDuration = animationState.length;

        yield return new WaitForSeconds(animationDuration);
        ShowGameOver();
    }

    private void ShowGameOver()
    {
        ScoreManager.Instance.StarsScore();
    }
}
