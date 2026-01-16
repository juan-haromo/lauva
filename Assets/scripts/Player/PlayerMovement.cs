using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float speed;
    Vector2 movement;
    InputAction movementAction;

    void Awake()
    {
        controller = GetComponent<CharacterController>();   
        movementAction = PlayerInputManager.Instance.Input.Overworld.Movement;
    }

    void OnEnable()
    {
       movementAction.Enable();
    }

    void OnDisable()
    {
        movementAction.Disable();
    }

    void Update()
    {
        movement = Time.deltaTime * speed *  movementAction.ReadValue<Vector2>().normalized;
        controller.Move(movement);
    }
}
