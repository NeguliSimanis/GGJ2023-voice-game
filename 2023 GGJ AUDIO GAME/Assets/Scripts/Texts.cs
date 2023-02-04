using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Texts : MonoBehaviour
{
    public Dictionary<string, int> philosopherTexts = new Dictionary<string, int>();
    int length0;
    int length1;
    int length2;
    int length3;
   
    void Awake()
    {
        philosopherTexts.Add("Yes", 0);
        philosopherTexts.Add("No", 0);
        philosopherTexts.Add("Ok", 0);
        philosopherTexts.Add("Logic", 0);
        philosopherTexts.Add("Morality", 1);
        philosopherTexts.Add("Evidence", 1);
        philosopherTexts.Add("Argument", 1);
        philosopherTexts.Add("Rhetorics", 2);
        philosopherTexts.Add("Free will", 2);
        philosopherTexts.Add("Intellect", 3);
        philosopherTexts.Add("Reasoning", 3);
        philosopherTexts.Add("Philosophy", 3);

        for(int i = 0; i < philosopherTexts.Count; i++)
        {
            length3++;
            if (philosopherTexts.Values.ElementAt(i) < 1)
                length0++;
            if (philosopherTexts.Values.ElementAt(i) < 2)
                length1++;
            if (philosopherTexts.Values.ElementAt(i) < 3)
                length2++;
        }
        Debug.Log("LENGTHS " + length0 + " "
            + length1 + " "
            + length2 + " "
            + length3 + " ");
    }

    public string GetRandomText(int difficulty = 0)
    {
        string text = "a";
        int maxRoll = 2;
        switch(difficulty)
        {
            case 0:
                maxRoll = length0;
                break;
            case 1:
                maxRoll = length1;
                break;
            case 2:
                maxRoll = length2;
                break;
            case 3:
                maxRoll = length3;
                break;
        }
        int randomRoll = UnityEngine.Random.Range(0, maxRoll);
        text = philosopherTexts.Keys.ElementAt(randomRoll);
        return text;
        
    }
    
}
