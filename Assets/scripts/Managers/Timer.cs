using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("More than one timer in scene, destroying the one in " + name);
            Destroy(this);
        }
    }


    public Image imgTimer;
    public float maxTime;
    float currentTime;

    [SerializeField] GameObject endMenu;
    public event LevelEnd OnTimeEnd;

    void Start()
    {
        Time.timeScale = 1;
        currentTime = maxTime;
        endMenu.SetActive(false);
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        imgTimer.fillAmount = currentTime/maxTime;

        if(currentTime <= 0)
        {
            OnTimeEnd?.Invoke(this);
            Time.timeScale = 0;
            endMenu.SetActive(true);
        }
    }

    public void AddTime(float time)
    {
        currentTime = Mathf.Clamp(currentTime + MathF.Abs(time),0, maxTime);
    }
}

public delegate void LevelEnd(Timer timer);
