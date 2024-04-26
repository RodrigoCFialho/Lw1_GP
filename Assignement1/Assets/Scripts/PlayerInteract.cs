using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private List<IInteractable> interactableList = new List<IInteractable>();

    public void InteractEvent()
    {
        if (interactableList != null)
        {
            for (int i = 0; i < interactableList.Count; ++i)
            {
                interactableList[i].Interact();
            }
        }
    }

    public void SetInteractible(IInteractable interactableObject)
    {
        interactableList.Add(interactableObject);
    }

    public void RemoveInteractible(IInteractable interactableObject)
    {
        interactableList.Remove(interactableObject);
    }
}
