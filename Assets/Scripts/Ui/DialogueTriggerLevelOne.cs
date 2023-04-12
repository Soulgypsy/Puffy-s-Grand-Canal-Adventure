using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerLevelOne : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject portrait;
    public bool portraitCheck;

    public void TriggerDialogue()
    {
        portraitCheck = true;
        FindObjectOfType<DialogueManagerLevelOne>().StartDialogue(dialogue);
        portraitCheck = false;
    }
}
