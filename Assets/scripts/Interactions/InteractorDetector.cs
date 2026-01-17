using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractorDetector : MonoBehaviour
{
    public HashSet<IInteractable> interactables;
    [SerializeField] TextMeshPro lblInteractionName;
    InputAction interactAction;
    [SerializeField] GameObject player;
    void Start()
    {
        interactables = new HashSet<IInteractable>();
        lblInteractionName.text = string.Empty;

        interactAction = PlayerInputManager.Instance.Input.Overworld.Interact;
        interactAction.performed += Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if(interactables.Count <= 0){return;}
        interactables.First().Interact(player);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactables.Add(interactable);
            lblInteractionName.text = interactable.InteractionName();
            interactAction.Enable();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            if (!interactables.Contains(interactable))
            {
                return;
            }
            interactables.Remove(interactable);
            if(0 < interactables.Count)
            {
                lblInteractionName.text = interactables.First().InteractionName();
            }
            else
            {
                lblInteractionName.text = string.Empty;
                interactAction.Disable();   
            }                
        }
    }

    public void Clear(IInteractable toRemove)
    {
        interactables.Remove(toRemove);
        lblInteractionName.text = string.Empty;
    }
}
