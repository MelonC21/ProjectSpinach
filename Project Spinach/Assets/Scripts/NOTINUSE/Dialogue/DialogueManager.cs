using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;
    private Queue<string> sell_sentences;
    private Queue<string> leave_sentences;
    private Queue<string> converse_sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        sell_sentences = new Queue<string>();
        leave_sentences = new Queue<string>();
        converse_sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear(); // clear any sentences from a previous conversation
        sell_sentences.Clear();
        leave_sentences.Clear();
        converse_sentences.Clear();

        // load up the empty queues that were initialized in the Start() function
        // you can find the specific elements in the StartDialogueInteractionButton gameobject under the DialogueTrigger component
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string sentence in dialogue.sell_sentences)
        {
            sell_sentences.Enqueue(sentence);
        }
        foreach (string sentence in dialogue.leave_sentences)
        {
            leave_sentences.Enqueue(sentence);
        }
        foreach (string sentence in dialogue.converse_sentences)
        {
            converse_sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) //we have reached the end of our queue
        {
            //we can end our dialogue
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);

        //dialogueText.text = sentence; //To make the whole sentence come out at once
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNextSell_Sentence() // this function should only be called by pressing the sell button
    {
        if (sell_sentences.Count == 0) //we have reached the end of our queue
        {
            //we can end our dialogue
            EndDialogue();
            return;
        }
        string sentence = sell_sentences.Dequeue();
        Debug.Log(sentence);

        //dialogueText.text = sentence; //To make the whole sentence come out at once
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNextLeave_Sentence() // this function should only be called by pressing the leave button
    {
        if (leave_sentences.Count == 0) //we have reached the end of our queue
        {
            //we can end our dialogue
            EndDialogue();
            return;
        }
        string sentence = leave_sentences.Dequeue();
        Debug.Log(sentence);

        //dialogueText.text = sentence; //To make the whole sentence come out at once
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayNextConverse_Sentence() // this function should only be called by pressing the converse button
    {
        if (converse_sentences.Count == 0) //we have reached the end of our queue
        {
            //we can end our dialogue
            EndDialogue();
            return;
        }
        string sentence = converse_sentences.Dequeue();
        Debug.Log(sentence);

        //dialogueText.text = sentence; //To make the whole sentence come out all at once
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) // this will type out the characters in the dialogue one at a time
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null; // TODO: make the characters come out SLOWER. Right now, one character is typed out each frame
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
