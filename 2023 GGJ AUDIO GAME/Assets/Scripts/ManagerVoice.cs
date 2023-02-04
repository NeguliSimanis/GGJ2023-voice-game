using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Linq;
//using UnityEngine.Windows.Speech;

public enum SpeechTypes
{
    Join
}

public class ManagerVoice : MonoBehaviour
{

    //private KeywordRecognizer keywordRecognizer;
    //private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {

        //actions.Add("join", Join);
        //actions.Add("Believe me", Join);
        //actions.Add("Left", Left);
        //actions.Add("Trust", Join);

        //keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        //keywordRecognizer.OnPhraseRecognized += ProcessSpeech;
        //keywordRecognizer.Start();
    }

    //private void ProcessSpeech(PhraseRecognizedEventArgs speech)
    //{
    //    Debug.Log(speech.text);
    //    actions[speech.text].Invoke();
    //}

    private void Join()
    {
        //Debug.Log("join ");
        //    if (GameManager.instance.speechToBeDetected[0] == SpeechTypes.Join)
        //    {
        //        Debug.Log("join success");
        //        GameManager.instance.voiceEnemy.ProcessDeath(ObstacleDeath.RecruitedByPlayer);
        //     }
        
        //Debug.Log("join success not succ");
        
    }

    private void Left()
    {
        //Debug.Log("lef");
    }
    
}
