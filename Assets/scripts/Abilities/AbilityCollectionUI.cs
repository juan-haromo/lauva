using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityCollectionUI : MonoBehaviour
{
    public static AbilityCollectionUI Instace;

    void Awake()
    {
        if(Instace == null)
        {
            Instace = this;
        }
        else
        {
            Debug.Log("More than one ability collection UI, destroying the one in " + name);
            Destroy(this);
        }
    }

    [SerializeField] GameObject interactionPanel;
    [SerializeField] Button btnCancel;
    [SerializeField] Button btnAbility1;
    [SerializeField] Button btnAbility2;

    public bool IsActive{get; private set;}
    
    GameObject Collectable; 
    AbilityHolder AbilityHolder;
    IAbility AbilityToUnlock;
    InteractorDetector interactorDetector;
    AbilityCollectable AbilityCollectable;

    void Start()
    {
        btnCancel.onClick.RemoveAllListeners();
        btnCancel.onClick.AddListener(()=>{
            TurnOff();
        });

        btnAbility1.onClick.RemoveAllListeners();
        btnAbility1.onClick.AddListener(() =>
        {
           if(AbilityHolder != null && AbilityToUnlock != null)
            {
                AbilityHolder.ability1 = AbilityToUnlock;
                AbilityToUnlock = null;
                Collectable.SetActive(false);
                interactorDetector.interactables.Remove(AbilityCollectable);
            }
            TurnOff();
        });

        btnAbility2.onClick.RemoveAllListeners();
        btnAbility2.onClick.AddListener(() =>
        {
           if(AbilityHolder != null && AbilityToUnlock != null)
            {
                AbilityHolder.ability2 = AbilityToUnlock;
                AbilityToUnlock = null;
                Collectable.SetActive(false);
                interactorDetector.interactables.Remove(AbilityCollectable);
            }
            TurnOff();
        });

        TurnOff();
    }

    public void TurnOn(GameObject collectable, AbilityHolder abilityHolder, IAbility abilityToUnlock, InteractorDetector detector, AbilityCollectable abilityCollectable)
    {
        IsActive = true;
        EventSystem.current.SetSelectedGameObject(interactionPanel);
        Collectable = collectable;
        PlayerInputManager.Instance.Input.Overworld.Disable();

        AbilityHolder = abilityHolder;

        AbilityToUnlock = abilityToUnlock;
        interactorDetector = detector;
        AbilityCollectable = abilityCollectable;

        interactionPanel.SetActive(true);
    }

    void TurnOff()
    {
        interactionPanel.SetActive(false);
         
        PlayerInputManager.Instance.Input.Overworld.Enable();

        IsActive = false;
    }
}