using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            dialogueText.text = string.Empty;
            dialogueBox.gameObject.SetActive(false);
        }
        else
        {
            Destroy(this);
        }
    }

    public TextMeshProUGUI dialogueText;
    public Transform dialogueBox;
}
