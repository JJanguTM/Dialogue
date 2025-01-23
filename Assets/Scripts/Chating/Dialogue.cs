using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string Name { get; private set; }
    public string[] Contexts { get; private set; }

    public Dialogue(string name, string[] contexts)
    {
        Name = name;
        Contexts = contexts;
    }
}

