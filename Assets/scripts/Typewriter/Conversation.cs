using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Conversation : MonoBehaviour, IInteractable
{
    public List<Dialogue> dialogues;
    int currentDialogue = 0;
    [SerializeField] Typewriter typewriter;

    public void Interact(GameObject interactor)
    {
        
        PlayerInputManager.Instance.Input.Overworld.Disable();
        PlayerInputManager.Instance.Input.VisualNovel.Enable();
        typewriter.StartWriting(dialogues[currentDialogue]);
        typewriter.OnConversationEnd += EndConversation;
        
    }

    private void EndConversation()
    {
        PlayerInputManager.Instance.Input.VisualNovel.Disable();
        PlayerInputManager.Instance.Input.Overworld.Enable();
        typewriter.OnConversationEnd -= EndConversation;
        currentDialogue++;
        if (currentDialogue >= dialogues.Count)
        {
            currentDialogue--;
        }
    }


    public string InteractionName()=> " ";
}

public delegate void ConversationEnd();