using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextManager
{
    public string name; //se supone que agarra el nombre de la persona, en este caso el Cliente.
    [TextArea(3, 10)]
    public string[] order_list;


}
