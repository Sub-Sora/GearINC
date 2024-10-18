using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            Interact();
        }    
    }

    public virtual void Interact()
    {
        Debug.Log("interact");
    }
}
