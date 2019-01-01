using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {

    //Also include the NPC sprite here at a later date.

    public Sprite icon;
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
}
