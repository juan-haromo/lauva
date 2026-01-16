using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager Instance{get; private set;}
    void Awake()
    {
        if(PlayerInputManager.Instance == null)
        {
            Instance = this;
            Input = new PlayerInput();  
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("More than one input manager, destroying input manager of " + name);
            Destroy(this);
        }
    }
    public PlayerInput Input{get; private set;}

}