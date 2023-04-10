using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject box;
    public GameObject tint;
    public GameObject portraitPuffy;
    public DialogueTrigger[] portrait;
    public bool dialogueOn;
    public bool cameraMovement;

    private Queue<string> sentences;

    [SerializeField]
    private KeyCode continueDialogue;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        cameraMovement = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        box.SetActive(true);
        //tint.SetActive(true);
        //portraitPuffy.SetActive(true);
        dialogueOn = true;
        for (int i = 0; i < portrait.Length; i++)
        {
            if (portrait[i].portraitCheck == true)
            {
                portrait[i].portrait.SetActive(true);
            }
        }
        Debug.Log("Starting Conversation with " + dialogue.name);

        nameText.text = dialogue.name;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
            DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {

            if (sentences.Count == 0)
            {
                EndDialogue();
                box.SetActive(false);
                tint.SetActive(false);
                return;
            }

            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        for (int i = 0; i < portrait.Length; i++)
        {
                portrait[i].portrait.SetActive(false);
        }
        portraitPuffy.SetActive(false);
        dialogueOn = false;
        cameraMovement = true;

        Debug.Log("End of conversation");
    }
}
