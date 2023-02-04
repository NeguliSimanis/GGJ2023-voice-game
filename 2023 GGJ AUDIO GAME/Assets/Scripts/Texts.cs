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
        philosopherTexts.Add("Yes", 0);
        philosopherTexts.Add("", 0);
        philosopherTexts.Add("e", 0);

        philosopherTexts.Add("Yes", 1);
        philosopherTexts.Add("", 1);
        philosopherTexts.Add("e", 1);

        philosopherTexts.Add("Yes", 2);
        philosopherTexts.Add("", 2);
        philosopherTexts.Add("e", 2);

        philosopherTexts.Add("Yes", 3);
        philosopherTexts.Add("", 3);
        philosopherTexts.Add("e", 3);
    }

    public string GetRandomText(int difficulty = 0)
    {
        string text = "a";
        int randomRoll = UnityEngine.Random.Range(0, philosopherTexts.Count);
        text = philosopherTexts.Keys.ElementAt(randomRoll);
        return text;
        
    }
    
}
