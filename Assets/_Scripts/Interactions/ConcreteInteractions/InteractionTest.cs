using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    [SerializeField] string interactionName;
    public void Interact()
    {
        Debug.Log(interactionName +  " was tested");
    }

    public string InteractionName()=>interactionName;
}
