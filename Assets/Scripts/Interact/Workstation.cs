using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static Job;

public class Workstation : Interactable
{
    public JobType Type;

    public ManagerOnce Main;

    [SerializeField]
    private GameObject _engineToPut;

    [SerializeField]
    private Material _skinJob;

    [SerializeField]
    private GameObject _UIPos;

    private JobSheet _jobSheet;
    
    private PlayerMain _player;

    public override void Interact(PlayerMain player)
    {
        if (player.IsTuto)
        {
            if (gameObject == TutoManager.Instance.TutoPhases[TutoManager.Instance.TutoActualPeriod])
            {
                TutoManager.Instance.IngrementPeriod();
            }
            else
            {
                return;
            }
        }

        _player = player;
        _jobSheet.JobSheetObject.SetActive(true);
    }

    public void GiveJobInformationToPlayer()
    {
        _player.Job.Job = Type;
        _player.Job.EnginePut = _engineToPut;
        _jobSheet.JobSheetObject.SetActive(false);
        _player.Job.LastJob.SetActive(false);
        foreach (PlayerJobParent skin in _player.Job.Skins)
        {
            if (skin.Job == Type)
            {
                skin.gameObject.SetActive(true);
                _player.Job.LastJob = skin.gameObject;
            }
        }

        _player.PlayerAnimator.SetBool("switchJob", true);
        _player.VFX.SwitchJobEffect.Play();
    }

    public void SetWorkstationJobName(GameObject uiJob)
    {
        _UIPos = uiJob;
    }

    public void SetWorkstationJobSheets(JobSheet uiJobSheet)
    {
        _jobSheet = uiJobSheet;
        _jobSheet.AcceptJobButton.onClick.AddListener(GiveJobInformationToPlayer);
    }

    /// <summary>
    /// Sera appel� lorsque le joueur s'approche de la workstation
    /// </summary>
    private void ShowJobView()
    {
        _UIPos.SetActive(true);
    }

    public void HideJobView()
    {
        _UIPos.SetActive(false);
    }
}