using UnityEngine;

public class InteractionTest : MonoBehaviour, IInteractable
{
    [SerializeField] string interactionName;
    public void Interact(GameObject interactor)
    {
        Debug.Log(interactionName +  " was tested");
    }

    public string InteractionName()=>interactionName;
}
