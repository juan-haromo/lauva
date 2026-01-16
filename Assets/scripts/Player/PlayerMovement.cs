using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed;
    Vector2 movement;
    public InputAction MovementAction{get;private set;}

    void Awake()
    {
        controller = GetComponent<CharacterController>();   
        MovementAction = PlayerInputManager.Instance.Input.Overworld.Movement;
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
        movement = Time.deltaTime * speed *  MovementAction.ReadValue<Vector2>().normalized;
        controller.Move(movement);
    }
}
