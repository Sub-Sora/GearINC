using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoZoneEntrance : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TutoManager.Instance.allDials.TutoStart();
        PlayerControls player = other.GetComponent<PlayerControls>();
        player.DesactivatePlayer();
        Destroy(this);
    }
}
