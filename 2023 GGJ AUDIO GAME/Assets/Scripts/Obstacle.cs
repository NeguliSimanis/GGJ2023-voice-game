using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using TMPro;
using UnityEngine.UI;


public class Obstacle : MonoBehaviour
{
    public float speed;
    public Player player;
    private bool hasInteractedWithPlayer = false;
    
    /// <summary>
    /// leftmost position obstacle moves before it is destroyed
    /// </summary>
    [Header("movement")]
    [SerializeField]
    private float minPosX;
    [SerializeField]
    private float colliderLeftOffset;
    [SerializeField]
    private float colliderRightOffset;
    [SerializeField]
    private float colliderTopOffset;
    [SerializeField]
    private float colliderPlayerHandicap = 1;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI myText;


    private void Start()
    {
        player = GameManager.instance.currPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * GameManager.instance.currSpeedMultiplier);
        CheckForCollisionWithPlayer();
        if (transform.position.x < minPosX)
            Destroy(gameObject);
    }

    private void CheckForCollisionWithPlayer()
    {
        if (player.transform.position.x > colliderLeftOffset + transform.position.x - colliderPlayerHandicap &&
            player.transform.position.x < colliderRightOffset + transform.position.x + colliderPlayerHandicap &&
            player.transform.position.y < colliderTopOffset + transform.position.y + -colliderPlayerHandicap)
        {

        }
        if (player.transform.position.x > colliderLeftOffset + transform.position.x &&
            player.transform.position.x < colliderRightOffset + transform.position.x && 
            player.transform.position.y < colliderTopOffset + transform.position.y)
        {
            if (!hasInteractedWithPlayer && GameManager.instance.ProcessCollisionWithPhilosopher())
            {
                hasInteractedWithPlayer = true;
                ProcessDeath();
            }
            
        }
    }

    private void ProcessDeath()
    {
        Destroy(gameObject);
    }
}
