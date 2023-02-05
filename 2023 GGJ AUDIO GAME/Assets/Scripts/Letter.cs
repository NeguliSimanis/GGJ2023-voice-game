using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Letter : MonoBehaviour
{
    public TextMeshProUGUI letterText;
    public Image letterBackgroundImage;

    public void SetLetter(string letter)
    {
        this.letterText.text = letter;
    }

    public void CompleteLetter()
    {
        Debug.Log("Letter Complete");
        this.letterBackgroundImage.color = new Color(0f, 1f, 0f);
    }

    public void SetEmpty()
    {
        letterBackgroundImage.enabled = false;
    }
}