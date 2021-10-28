using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabChanger : MonoBehaviour
{
    //public CursorChanger.CursorStates CursorMode;

    public void OnMouseEnter()
    {
        CursorChanger.instance.ChangeCursor(CursorChanger.CursorStates.grabmode);
        Debug.Log("enter");
    }

    public void OnMouseExit()
    {
        CursorChanger.instance.ChangeCursor(CursorChanger.CursorStates.selection);
        Debug.Log("exit");
    }
}
