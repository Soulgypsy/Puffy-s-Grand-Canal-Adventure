using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UiManager : MonoBehaviour
{
    

    [Header("Cursor")]
    public Texture2D defaultCursor;
    public Texture2D aimCursor;

    [Header("Lv 2 - Cargo")]
    public GameObject counter;
    public TextMeshProUGUI cargoText;




    public void changeToAimCursor()
    {
        Cursor.SetCursor(aimCursor, new Vector2(16, 16), CursorMode.Auto);
    }
    public void changeToDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(0, 0), CursorMode.Auto);
    }

    public void cargoCounterChange(int count)
    {
        cargoText.text = count + "/3";
    }
}

