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
        //0
        philosopherTexts.Add("No", 0);
        philosopherTexts.Add("Yes", 0);
        philosopherTexts.Add("Eye", 0);
        philosopherTexts.Add("Art", 0);
        philosopherTexts.Add("God", 0);
        philosopherTexts.Add("Sky", 0);
        philosopherTexts.Add("Mad", 0);
        philosopherTexts.Add("See", 0);
        philosopherTexts.Add("Age", 0);
        philosopherTexts.Add("Gold", 0);
        philosopherTexts.Add("Atom", 0);
        philosopherTexts.Add("Punch", 0);
        philosopherTexts.Add("Based", 0);
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
        philosopherTexts.Add("Roots", 0);
        philosopherTexts.Add("Fate", 0);
        philosopherTexts.Add("Word", 0);
        philosopherTexts.Add("Arm", 0);
        philosopherTexts.Add("Zen", 0);
        philosopherTexts.Add("Time", 0);
        philosopherTexts.Add("Love", 0);
        philosopherTexts.Add("Why", 0);
        philosopherTexts.Add("Rule", 0);
        philosopherTexts.Add("Law", 0);
        philosopherTexts.Add("Logos", 0);
        philosopherTexts.Add("Spirit", 0);
        philosopherTexts.Add("Cringe", 0);
        philosopherTexts.Add("Right", 0);
        philosopherTexts.Add("Wrong", 0);
        philosopherTexts.Add("Alibi", 0);
        philosopherTexts.Add("Music", 0);
        philosopherTexts.Add("Soul", 0);
        philosopherTexts.Add("Body", 0);
        philosopherTexts.Add("Mind", 0);
        philosopherTexts.Add("Study", 0);
        philosopherTexts.Add("Sin", 0);
        philosopherTexts.Add("Fable", 0);
        philosopherTexts.Add("Dream", 0);
        philosopherTexts.Add("rhyme", 0);
        philosopherTexts.Add("Sparta", 0);
        philosopherTexts.Add("Dogma", 0);
        philosopherTexts.Add("Fact", 0);
        philosopherTexts.Add("Myth", 0);
        philosopherTexts.Add("Idea", 0);
        philosopherTexts.Add("Self", 0);

        //1
        philosopherTexts.Add("Wealth", 1);
        philosopherTexts.Add("doctrine", 1);
        philosopherTexts.Add("Absolute", 1);
        philosopherTexts.Add("supersede", 1);
        philosopherTexts.Add("threshold", 1);
        philosopherTexts.Add("Vision", 1);
        philosopherTexts.Add("Academic", 1);
        philosopherTexts.Add("Justice", 1);
        philosopherTexts.Add("Ethics", 1);
        philosopherTexts.Add("Gamers", 1);
        philosopherTexts.Add("Wisdom", 1);
        philosopherTexts.Add("phobia", 1);
        philosopherTexts.Add("De jure", 1);
        philosopherTexts.Add("Pathos", 1);
        philosopherTexts.Add("Pub fight", 1);
        philosopherTexts.Add("Universe", 1);
        philosopherTexts.Add("Hello World", 1);
        philosopherTexts.Add("Belief", 1);
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
        philosopherTexts.Add("Religion", 1);
        philosopherTexts.Add("Theory", 1);
        philosopherTexts.Add("Joy plants", 1);
        philosopherTexts.Add("Essence", 1);
        philosopherTexts.Add("Indict", 1);
        philosopherTexts.Add("Wednesday", 1);
        philosopherTexts.Add("Ingenious", 1);
        philosopherTexts.Add("Society", 1);
        philosopherTexts.Add("Democracy", 1);
        philosopherTexts.Add("Elegance", 1);
        philosopherTexts.Add("Emotion", 1);
        philosopherTexts.Add("question", 1);
        philosopherTexts.Add("antiquity", 1);
        philosopherTexts.Add("Spinoza", 1);
        philosopherTexts.Add("column", 1);
        philosopherTexts.Add("maneuver", 1);
        philosopherTexts.Add("Mediation", 1);
        philosopherTexts.Add("Meditation", 1);
        philosopherTexts.Add("Ideology", 1);
        philosopherTexts.Add("Principle", 1);
        philosopherTexts.Add("Syntax", 1);
        philosopherTexts.Add("eschew", 1);
        philosopherTexts.Add("anathema", 1);

        //2
        philosopherTexts.Add("Ita vero", 2);
        philosopherTexts.Add("Categorization", 2);
        philosopherTexts.Add("Conjecture", 2);
        philosopherTexts.Add("perseverance", 2);
        philosopherTexts.Add("millennium", 2);
        philosopherTexts.Add("Descartes", 2);
        philosopherTexts.Add("pronunciation", 2);
        philosopherTexts.Add("Nietzsche", 2);
        philosopherTexts.Add("mathematics", 2);
        philosopherTexts.Add("Revolution", 2);
        philosopherTexts.Add("Punishment", 2);
        philosopherTexts.Add("Vernacular", 2);
        philosopherTexts.Add("Sycophant", 2);
        philosopherTexts.Add("Cynicism", 2);
        philosopherTexts.Add("Non sequitur", 2);
        philosopherTexts.Add("Easter egg", 2);
        philosopherTexts.Add("Determinism", 2);
        philosopherTexts.Add("Panacea", 2);
        philosopherTexts.Add("Pantheon", 2);
        philosopherTexts.Add("Perception", 2);
        philosopherTexts.Add("Pro bono", 2);
        philosopherTexts.Add("Education", 2);
        philosopherTexts.Add("Evolution", 2);
        philosopherTexts.Add("Rhetorics", 2);
        philosopherTexts.Add("Dimension", 2);
        philosopherTexts.Add("Free will", 2);
        philosopherTexts.Add("Intellect", 2);
        philosopherTexts.Add("Reasoning", 2);
        philosopherTexts.Add("Solipsism", 2);
        philosopherTexts.Add("Experience", 2);
        philosopherTexts.Add("Motivation", 2);
        philosopherTexts.Add("Philosophy", 2);
        philosopherTexts.Add("Ad Hominem", 2);
        philosopherTexts.Add("Ipso Facto", 2);
        philosopherTexts.Add("Nauseous", 2);
        philosopherTexts.Add("Minuscule", 2);
        philosopherTexts.Add("Hypothesis", 2);
        philosopherTexts.Add("Sacrilegious", 2);
        philosopherTexts.Add("Mischievous", 2);
        philosopherTexts.Add("metaphysics", 2);
        philosopherTexts.Add("accommodate", 2);
        philosopherTexts.Add("conscientious", 2);
        philosopherTexts.Add("drunkenness", 2);
        philosopherTexts.Add("Simulacrum", 2);
        philosopherTexts.Add("Consciousness", 2);
        philosopherTexts.Add("Transcendental", 2);
        philosopherTexts.Add("Epistemology", 2);
        philosopherTexts.Add("succedaneum", 2);
        philosopherTexts.Add("transmogrify", 2);

        // 3
        philosopherTexts.Add("Magum Opus", 3);
        philosopherTexts.Add("Aestheticism", 3);
        philosopherTexts.Add("Presupposition", 3);
        philosopherTexts.Add("Thomas Aquinas", 3);
        philosopherTexts.Add("Verisimilitude", 3);
        philosopherTexts.Add("Archeology", 3);
        philosopherTexts.Add("Schizophrenia", 3);
        philosopherTexts.Add("Vox Populis", 3);
        philosopherTexts.Add("encyclopedia", 3);
        philosopherTexts.Add("Cogito ergo sum", 3);
        philosopherTexts.Add("Curriculum vitae", 3);
        philosopherTexts.Add("Argumentum ad verecundiam", 3);
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
        int maxRoll = 2;
        int minRoll = 0;
        switch (difficulty)
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
                minRoll = length2;
                break;
        }
        int randomRoll = UnityEngine.Random.Range(minRoll, maxRoll);
        text = philosopherTexts.Keys.ElementAt(randomRoll);
        return text.ToUpper();

    }

}
