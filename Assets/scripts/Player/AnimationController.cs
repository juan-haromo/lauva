using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    string currentAnim;
    public void ChangeAnim(string newAnim, float crossfade = 0f)
    {
        if (currentAnim != newAnim)
        {
            currentAnim = newAnim;
            anim.CrossFade(newAnim,crossfade,0);
        }
    }

    string[] idles = {"idle_Bean"};
    public string GetIdle()
    {
        return idles[Random.Range(0,idles.Length)];
    }
}