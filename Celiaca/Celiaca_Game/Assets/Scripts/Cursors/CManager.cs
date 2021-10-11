using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CManager : MonoBehaviour
{
    public static CManager instance;
    public enum CursorStates
    {
        C_default,
        C_select,
    }
    public CursorStates StateCursor = CursorStates.C_default;
    public Texture2D[] Cursors;
    public static bool C_active;

    private void Awake()
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
        Cursor.visible = C_active;
        Cursor.SetCursor(Cursors[(int)StateCursor], Vector2.zero, CursorMode.Auto);
    }

    public void ChangeCursor(CursorStates estate)
    {
        Cursor.SetCursor(Cursors[(int)StateCursor], Vector2.zero, CursorMode.Auto);
    }
}
