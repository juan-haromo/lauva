using UnityEngine;

public class TypewriterInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] Typewriter typewriter;

    public void Interact(GameObject interactor)
    {
        
    }

    public string InteractionName()=> "Talk";
}
