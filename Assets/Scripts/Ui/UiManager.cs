using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    public GameObject questMenu;
    [SerializeField] bool menuUp;
    [SerializeField] Animator QuestMenuAnimator;
    [SerializeField] Collectables[] questScore;
    [SerializeField] Sprite[] questIconsArray;
    [SerializeField] Image[] questIconsImage;
    [SerializeField] public Text countdownRace;
    public GameObject[] crates;

    [Header("Cursor")]
    public Texture2D defaultCursor;
    public Texture2D aimCursor;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < crates.Length; i++)
        {
            questScore[i] = crates[i].GetComponent<Collectables>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) & menuUp == false)
        {
            menuUp = true;
            QuestMenuAnimator.SetBool("MenuUp", true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) & menuUp == true)
        {
            menuUp = false;
            QuestMenuAnimator.SetBool("MenuUp", false);
        }

        for  (int i = 0; i < crates.Length; i++)
        {
            if (questScore[i].questScore == true)
            {
                questIconsImage[i].sprite = questIconsArray[1];
            }
        }
    }


    public void changeToAimCursor()
    {
        Cursor.SetCursor(aimCursor, new Vector2(16, 16), CursorMode.Auto);
    }
    public void changeToDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(0, 0), CursorMode.Auto);
    }
}

