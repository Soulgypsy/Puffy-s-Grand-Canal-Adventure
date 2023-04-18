using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerLevelThree : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject portrait;
    public bool portraitCheck;

    public void TriggerDialogue()
    {
        portraitCheck = true;
        FindObjectOfType<DialogueManagerLevelThree>().StartDialogue(dialogue);
        portraitCheck = false;
    }
}
