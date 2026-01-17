using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller{get; private set;}
    [SerializeField] float baseSpeed;
    float currentSpeed;
    Vector2 movement;
    public Vector2 LastMovement {get; private set;}
    public InputAction MovementAction{get;private set;}
    [SerializeField] AnimationController animationController;
    [SerializeField] Transform playerSprite;
    Vector3 originalScale;
    float xScale;

    void Awake()
    {
        Controller = GetComponent<CharacterController>();   
        MovementAction = PlayerInputManager.Instance.Input.Overworld.Movement;
        currentSpeed = baseSpeed;
        ascendedLigth.gameObject.SetActive(false);
        originalScale = playerSprite.localScale;
        xScale = playerSprite.localScale.x;
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
        if(movement != Vector2.zero)
        {
            LastMovement = movement;
            animationController.ChangeAnim("Walk_Bean");
            originalScale.x = 0 < movement.x? -xScale : xScale;
            playerSprite.localScale = originalScale;
        }
        else
        {
            animationController.ChangeAnim(animationController.GetIdle());
        }
        Controller.Move(movement);
    }

    Coroutine speedBoostRoutine;
    public void SpeedBoost(float time, float speed)
    {
        if(speedBoostRoutine != null){StopCoroutine(speedBoostRoutine);}
        speedBoostRoutine = StartCoroutine(Speedboost(time,speed));    
    }

    IEnumerator Speedboost(float time, float speed)
    {
        currentSpeed = speed;
        yield return new WaitForSeconds(time);
        currentSpeed = baseSpeed;
    }

    
    public void Transcend(float duration)
    {
        StartCoroutine(Trascended(duration));
    }

    [SerializeField] Transform ascendedLigth;
    IEnumerator Trascended(float duration)
    {
        TrascendedLightManger.Instance.UnifyLights(duration);
        MovementAction.Disable();
        ascendedLigth.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        ascendedLigth.gameObject.SetActive(false);
        MovementAction.Enable();
    }
}
