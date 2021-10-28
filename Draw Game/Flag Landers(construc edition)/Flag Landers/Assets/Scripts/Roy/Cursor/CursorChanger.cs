using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public static CursorChanger instance;

    public enum CursorStates
    {
        selection,
        drawmode,
        grabmode
    }

    [Header("Cursor Settings")]
    public CursorStates StatesCursor = CursorStates.selection;
    public Texture2D[] cursores;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Cursor.visible = true;
        Cursor.SetCursor(cursores[(int)StatesCursor], Vector2.zero, CursorMode.Auto);
    }

    public void ChangeCursor(CursorStates states)
    {
        Cursor.SetCursor(cursores[(int)states], Vector2.zero, CursorMode.Auto);
    }
}
