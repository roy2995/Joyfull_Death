using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawModeOff : MonoBehaviour
{
    public static bool CanDraw;

    private void Awake()
    {
        CanDraw = false;       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DrawMode();
        }
        else
        {
            return;
        }
    }

    public void DrawMode()
    {
        CanDraw = !CanDraw;
        if (CanDraw)
        {
            CursorChanger.instance.ChangeCursor(CursorChanger.CursorStates.drawmode);
        }
    }
}
