using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public PlayerInput Input{get; private set;}
    CharacterController controller;
    [SerializeField] float speed;
    Vector2 movement;

    void Awake()
    {
        Input = new PlayerInput(); 
        controller = GetComponent<CharacterController>();   
    }

    void OnEnable()
    {
        Input.Enable();
    }

    void OnDisable()
    {
        Input.Disable();
    }

    void Update()
    {
        movement = Time.deltaTime * speed *  Input.Overworld.Movement.ReadValue<Vector2>().normalized;
        controller.Move(movement);
    }
}
