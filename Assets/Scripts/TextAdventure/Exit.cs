using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Exit
{
    public string keyString;
    public string exitDescription;
    [TextArea] public string exitResponse;
    public Room valueRoom;
}
