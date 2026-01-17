using UnityEngine;

public class TrascendInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] string interactionName;
    [SerializeField] BaseStateMachine fsm;
    public void Interact(GameObject interactor)
    {
        Debug.Log(interactor.name);
        if(interactor.TryGetComponent<AnimationController>(out AnimationController controller))
        {
            controller.ChangeAnim("Purify_Bean");
        }
            
        fsm.Trascend();

        interactor.GetComponentInChildren<InteractorDetector>().Clear(this);
    }

    public string InteractionName()=>interactionName;
}