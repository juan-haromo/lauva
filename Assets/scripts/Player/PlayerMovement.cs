using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float baseSpeed;
    float currentSpeed;
    Vector2 movement;
    public InputAction MovementAction{get;private set;}

    void Awake()
    {
        controller = GetComponent<CharacterController>();   
        MovementAction = PlayerInputManager.Instance.Input.Overworld.Movement;
        currentSpeed = baseSpeed;
    }

    void OnEnable()
    {
       MovementAction.Enable();
    }

    void OnDisable()
    {
        MovementAction.Disable();
    }

    void Update()
    {
        movement = Time.deltaTime * currentSpeed *  MovementAction.ReadValue<Vector2>().normalized;
        controller.Move(movement);
    }

    Coroutine speedBoostRoutine;
    public void SpeedBoost(float time, float speed)
    {
        StopCoroutine(speedBoostRoutine);
        speedBoostRoutine = StartCoroutine(Speedboost(time,speed));    
    }

    IEnumerator Speedboost(float time, float speed)
    {
        currentSpeed = speed;
        yield return new WaitForSeconds(time);
        currentSpeed = baseSpeed;
    }
}
