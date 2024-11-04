using UnityEngine;

public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Update de test sans le personnage
    /// </summary>
    private void Update()
    {
        if (Input.anyKey)
        {
            Interact();
        }    
    }

    /// <summary>
    /// Ce lancera lorsque le joueur interragira avec
    /// </summary>
    public virtual void Interact()
    {
        Debug.Log("interact");
    }
}
