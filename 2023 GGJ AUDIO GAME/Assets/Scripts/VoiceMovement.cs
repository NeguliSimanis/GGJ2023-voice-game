//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Linq;
//using UnityEngine.Windows.Speech;
//using TMPro;
//using UnityEngine.UI;

//public class VoiceMovement : MonoBehaviour
//{
//    [SerializeField]
//    private TextMeshProUGUI debugText;
//    private KeywordRecognizer keywordRecognizer;
//    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

//    private void Start()
//    {
//        foreach (var device in Microphone.devices)
//        {
//            Debug.Log("Name: " + device);
//        }

//        actions.Add("forward", Forward);
//        actions.Add("up", Up);
//        actions.Add("down", Down);
//        actions.Add("back", Back);
//        actions.Add("right", Right);
//        actions.Add("left", Left);
//        actions.Add("play", Play);
//        actions.Add("fuck", Fuck);

//        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
//        keywordRecognizer.OnPhraseRecognized += ProcessSpeech;
//        keywordRecognizer.Start();
//    }

//    private void ProcessSpeech(PhraseRecognizedEventArgs speech)
//    {
//        Debug.Log(speech.text);
//        actions[speech.text].Invoke();
//    }

//    private void Forward()
//    {
//        transform.Translate(1, 0, 0);
//        debugText.text = "FORWARD";
//    }

//    private void Back()
//    {
//        transform.Translate(-1, 0, 0);
//        debugText.text = "BACK";
//    }

//    private void Up()
//    {
//        transform.Translate(0, 1, 0);
//        debugText.text = "UP";
//    }

//    private void Down()
//    {
//        transform.Translate(0, -1, 0);
//        debugText.text = "DOWN";
//    }

//    private void Right()
//    {
//        transform.Translate(1, 0, 0);
//        debugText.text = "RIGHT";
//    }

//    private void Left()
//    {
//        transform.Translate(-1, 0, 0);
//        debugText.text = "LEFT";
//    }

//    private void Play()
//    {
//        Debug.Log("plaay");
//        debugText.text = "PLAY";
//    }

//    private void Fuck()
//    {
//        Debug.Log("fuck");
//        debugText.text = "FUCK";
//    }

    
//}
