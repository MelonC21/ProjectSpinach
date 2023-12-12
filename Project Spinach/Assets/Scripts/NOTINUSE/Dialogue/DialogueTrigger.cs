using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        
        //locate our DialogueManager
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        //which function argument we pass into StartDialogue tells it what conversation to start
    
    }
}
