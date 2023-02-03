using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerUI : MonoBehaviour
{
    Player player;
    [SerializeField]
    TextMeshProUGUI philosopherCountText;

    void Start()
    {
        player = GameManager.instance.currPlayer;
    }

    public void UpdatePhilosopherCount()
    {
        philosopherCountText.text = "Philosophers: " + GameManager.instance.currPhilosphers.ToString();
    }
}
