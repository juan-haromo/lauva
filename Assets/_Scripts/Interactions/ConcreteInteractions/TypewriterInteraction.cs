using UnityEngine;

public class TypewriterInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] Typewriter typewriter;

    public void Interact()
    {
        typewriter.ToogleWriting();
    }

    public string InteractionName()=> "Talk";
}
