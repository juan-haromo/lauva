using UnityEngine;

public class AbilityCollectable : MonoBehaviour, IInteractable
{
    public ScriptableObject abilityToUnlock;

    public void Interact(GameObject interactor)
    {
        if(AbilityCollectionUI.Instace.IsActive){return;}
        if(interactor.TryGetComponent<AbilityHolder>(out AbilityHolder abilityHolder))
        {
            InteractorDetector detector = interactor.GetComponentInChildren<InteractorDetector>();
            AbilityCollectionUI.Instace.TurnOn(gameObject, abilityHolder,abilityToUnlock as IAbility, detector, this);
        }
    }

    public string InteractionName()=> "Get ability";
}