using UnityEngine;

public class TypewriterInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] Typewriter typewriter;

    public void Interact(GameObject interactor)
    {
        typewriter.ToogleWriting();
    }

    public string InteractionName()=> "Talk";
}
