using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; //keeps track of which NPC you're having a dialogue with

    [TextArea(3, 10)]
    public string[] sentences;

    public string[] sell_sentences;
    public string[] leave_sentences;
    public string[] converse_sentences;
}
