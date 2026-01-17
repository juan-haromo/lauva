using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName ="Dialogue",menuName = "Dialogues/Dialogue")]
public class Dialogue : ScriptableObject
{
    public List<string> dialogues;
}