using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    [SerializeField] ScriptableObject initialAbility1;
    [SerializeField] ScriptableObject initialAbility2;
    public IAbility ability1;
    public IAbility ability2;
    InputAction abilityInput1;
    InputAction abilityInput2;


    void Awake()
    {
        abilityInput1 = PlayerInputManager.Instance.Input.Overworld.Ability1;
        abilityInput2 = PlayerInputManager.Instance.Input.Overworld.Ability2;
        
        ability1 = initialAbility1 as IAbility;
        ability2 = initialAbility2 as IAbility;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        abilityInput1.performed += ActivateAbility1;        
        abilityInput2.performed += ActivateAbility2;        
    }

    void OnEnable()
    {
        abilityInput1.Enable();
        abilityInput2.Enable();
    }

    void OnDisable()
    {
        abilityInput1.Disable();
        abilityInput2.Disable();
    }  

    bool isOneReady = true;
    private void ActivateAbility1(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(!isOneReady){return;}
        ability1.Activate(gameObject);
        StartCoroutine(AbilityCooldown1());
    }

    IEnumerator AbilityCooldown1()
    {
        isOneReady = false;
        yield return new WaitForSeconds(ability1.Cooldown());
        isOneReady = true;
    }

    bool isTwoReady = true;
    private void ActivateAbility2(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(!isTwoReady){return;}
        ability2.Activate(gameObject);
        StartCoroutine(AbilityCooldown2());
    }


    IEnumerator AbilityCooldown2()
    {
        isTwoReady = false;
        yield return new WaitForSeconds(ability2.Cooldown());
        isTwoReady = true;
    }


  
}
