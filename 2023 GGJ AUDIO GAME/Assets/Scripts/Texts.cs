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
        philosopherTexts.Add("No", 0);
        philosopherTexts.Add("Yes", 0);
        philosopherTexts.Add("Eye", 0);
        philosopherTexts.Add("God", 0);
        philosopherTexts.Add("Sky", 0);
        philosopherTexts.Add("Mad", 0);
        philosopherTexts.Add("See", 0);
        philosopherTexts.Add("Age", 0);
        philosopherTexts.Add("Atom", 0);
        philosopherTexts.Add("Punch", 0);
        philosopherTexts.Add("Life", 0);
        philosopherTexts.Add("Case", 0);
        philosopherTexts.Add("Veto", 0);
        philosopherTexts.Add("Birth", 0);
        philosopherTexts.Add("Global", 0);
        philosopherTexts.Add("Death", 0);
        philosopherTexts.Add("Logic", 0);
        philosopherTexts.Add("World", 0);
        philosopherTexts.Add("Truth", 0);
        philosopherTexts.Add("Cosmos", 0);
        philosopherTexts.Add("Brave", 0);
        philosopherTexts.Add("Zoom", 0);
        philosopherTexts.Add("Burden", 0);
        philosopherTexts.Add("Duty", 0);


        //
        philosopherTexts.Add("Wealth", 1);
        philosopherTexts.Add("Universe", 1);
        philosopherTexts.Add("Hello World", 1);
        philosopherTexts.Add("Belief", 1);
        philosopherTexts.Add("Ethics", 1);
        philosopherTexts.Add("Stigma", 1);
        philosopherTexts.Add("Qualia", 1);
        philosopherTexts.Add("Beauty", 1);
        philosopherTexts.Add("Science", 1);
        philosopherTexts.Add("Believe", 1);
        philosopherTexts.Add("Nemesis", 1);
        philosopherTexts.Add("Genesis", 1);
        philosopherTexts.Add("Reality", 1);
        philosopherTexts.Add("Skeptic", 1);
        philosopherTexts.Add("Progress", 1);
        philosopherTexts.Add("Morality", 1);
        philosopherTexts.Add("Evidence", 1);
        philosopherTexts.Add("Argument", 1);
        philosopherTexts.Add("Nucleus", 1);
        philosopherTexts.Add("Stoicism", 1);
        philosopherTexts.Add("Humanism", 1);
        philosopherTexts.Add("Humanity", 1);

        //
        philosopherTexts.Add("Ita vero", 2);
        philosopherTexts.Add("Pro bono", 2);
        philosopherTexts.Add("Education", 2);
        philosopherTexts.Add("Evolution", 2);
        philosopherTexts.Add("Rhetorics", 2);
        philosopherTexts.Add("Dimension", 2);
        philosopherTexts.Add("Free will", 2);
        philosopherTexts.Add("Intellect", 2);
        philosopherTexts.Add("Reasoning", 2);
        philosopherTexts.Add("Solopsism", 2);
        philosopherTexts.Add("Experience", 2);
        philosopherTexts.Add("Motivation", 2);
        philosopherTexts.Add("Philosophy", 2);
        philosopherTexts.Add("Perception", 2);
        philosopherTexts.Add("Ad Hominem", 2);
        philosopherTexts.Add("Ipso Facto", 2);

        //
        philosopherTexts.Add("Magum Opus", 3);
        philosopherTexts.Add("Vox Populis", 3);
        philosopherTexts.Add("Cogito ergo sum", 3);
        philosopherTexts.Add("Curriculum vitae", 3);
        philosopherTexts.Add("Going back to my roots", 3);

        for (int i = 0; i < philosopherTexts.Count; i++)
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
        string text = "difficulty = " + difficulty;
        Debug.Log(text);
        int maxRoll = 2;
        int minRoll = 0;
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
                minRoll = length1;
                break;
            case 3:
                maxRoll = length3;
                minRoll = length1;
                break;
        }
        int randomRoll = UnityEngine.Random.Range(minRoll, maxRoll);
        text = philosopherTexts.Keys.ElementAt(randomRoll);
        return text;
        
    }
    
}
