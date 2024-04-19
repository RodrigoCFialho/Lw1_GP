using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private IInteractable interactable;

    public void InteractEvent()
    {
        if (interactable != null)
        {
            interactable.Interact();
        }
    }

    public void SetInteractible(IInteractable interactableObject)
    {
        interactable = interactableObject;

    }


}
