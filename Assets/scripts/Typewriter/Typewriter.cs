using System;
using System.Collections;
using TMPro;
using UnityEngine;


public class Typewriter : MonoBehaviour
{
    TextMeshProUGUI lblText;
    Transform dialoguePanel;
    public float timeInterval = 0.1f;
    Coroutine writing;
    bool isWritting = false;
    public ConversationEnd OnConversationEnd;
    int dialogueIndex;
    Dialogue currentDialogue;

    void Start()
    {
        dialoguePanel = DialogueUI.Instance.dialogueBox;
        lblText = DialogueUI.Instance.dialogueText;
        lblText.text = string.Empty;
    }

    IEnumerator Type()
    {        
        isWritting = true;   
        lblText.maxVisibleCharacters = 0;
        lblText.text = currentDialogue.dialogues[dialogueIndex];
        while (lblText.maxVisibleCharacters < lblText.text.Length)
        {
            lblText.maxVisibleCharacters++;
            yield return new WaitForSeconds(timeInterval);   
        }
        isWritting = false;
    }

    public void StartWriting(Dialogue dialogue)
    {
        PlayerInputManager.Instance.Input.VisualNovel.PassDialogue.performed += PassDialogue;
        dialoguePanel.gameObject.SetActive(true);
        currentDialogue = dialogue;
        dialogueIndex = 0;
        writing = StartCoroutine(Type());
    }

    private void PassDialogue(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (isWritting)
        {
            StopCoroutine(writing);
            lblText.maxVisibleCharacters = lblText.text.Length;
            isWritting = false;
        }
        else
        {
            dialogueIndex++;
            if(dialogueIndex < currentDialogue.dialogues.Count)
            {
                writing = StartCoroutine(Type());
            }
            else
            {
                lblText.text = string.Empty;
                dialoguePanel.gameObject.SetActive(false);
                OnConversationEnd?.Invoke();
            }
        }
    }
}
