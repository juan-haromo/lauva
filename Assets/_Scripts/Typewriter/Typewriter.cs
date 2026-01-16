using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Typewriter : MonoBehaviour
{
    public TextMeshPro lblText;
    public float timeInterval = 0.1f;
    Coroutine writing;
    string[] messages = {"Hola","Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent tincidunt nec ante at malesuada. Sed ac arcu tempor leo tincidunt iaculis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Integer elementum facilisis orci ut blandit. Donec semper, metus vel volutpat porttitor, erat sapien maximus sapien, a dictum libero sapien quis eros. Mauris tellus quam, cursus et rutrum non, lacinia at dolor. Aenean placerat blandit condimentum. Ut suscipit, ligula commodo tincidunt ullamcorper, quam tellus finibus quam, non feugiat nisi enim ut sem. Aliquam ante libero, pellentesque lobortis est vel, maximus lobortis diam. Quisque eu augue augue.", "Texto texto texto a lo wey pero tampoco tanto como un lorem xD"};
    bool isWritting = false;

    void Start()
    {
        lblText.text = string.Empty;
    }

    IEnumerator Type(string text)
    {
        isWritting = true;
        lblText.maxVisibleCharacters = 0;
        lblText.text = text;
        while (lblText.maxVisibleCharacters < lblText.text.Length)
        {
            lblText.maxVisibleCharacters++;
            yield return new WaitForSeconds(timeInterval);
        }
        isWritting = false;
    }

    public void ToogleWriting()
    {
        if(isWritting)
        {
           StopText(); 
        }
        else
        {
            if(writing != null){StopCoroutine(writing);}
            writing = StartCoroutine(Type(messages[Random.Range(0,messages.Length)]));     
        }
    }

    public void StopText()
    {
        isWritting = false;
        StopCoroutine(writing);
        lblText.maxVisibleCharacters = lblText.text.Length;
    }
}
