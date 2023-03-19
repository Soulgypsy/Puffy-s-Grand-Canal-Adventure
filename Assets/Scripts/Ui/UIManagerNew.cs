using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerNew : MonoBehaviour
{
    [Header("Cursor")]
    public Texture2D defaultCursor;
    public Texture2D aimCursor;

    public void changeToAimCursor()
    {
        Cursor.SetCursor(aimCursor, new Vector2(16, 16), CursorMode.Auto);
    }
    public void changeToDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, new Vector2(0, 0), CursorMode.Auto);
    }
}
