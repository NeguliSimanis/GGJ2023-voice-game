using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Texts : MonoBehaviour
{
    public Dictionary<string, int> philosopherTexts = new Dictionary<string, int>();
   
    // Start is called before the first frame update

    void Awake()
    {
        philosopherTexts.Add("q", 0);
        philosopherTexts.Add("w", 0);
        philosopherTexts.Add("e", 0);
        philosopherTexts.Add("r", 0);
        philosopherTexts.Add("t", 0);
        philosopherTexts.Add("y", 0);
        philosopherTexts.Add("u", 0);
        philosopherTexts.Add("i", 0);
        philosopherTexts.Add("o", 0);
        philosopherTexts.Add("p", 0);
        philosopherTexts.Add("a", 0);
        philosopherTexts.Add("s", 0);
        philosopherTexts.Add("d", 0);
        philosopherTexts.Add("f", 0);
        philosopherTexts.Add("g", 0);
        philosopherTexts.Add("h", 0);
        philosopherTexts.Add("j", 0);
        philosopherTexts.Add("k", 0);
        philosopherTexts.Add("l", 0);
        philosopherTexts.Add("z", 0);
        philosopherTexts.Add("x", 0);
        philosopherTexts.Add("c", 0);
        philosopherTexts.Add("v", 0);
        philosopherTexts.Add("b", 0);
        philosopherTexts.Add("n", 0);
        philosopherTexts.Add("m", 0);
    }

    public string GetRandomText(int difficulty = 0)
    {
        string text = "a";
        int randomRoll = UnityEngine.Random.Range(0, philosopherTexts.Count);
        text = philosopherTexts.Keys.ElementAt(randomRoll);
        return text;
        
    }
    
}
