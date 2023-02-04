using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
   
    public Player player;
    private bool hasInteractedWithPlayer = false;
    private bool isDead = false;
    
    /// <summary>
    /// leftmost position obstacle moves before it is destroyed
    /// </summary>
    [Header("movement")]
    public float speed;
    [SerializeField]
    private float minPosX;
    [SerializeField]
    private float colliderLeftOffset;
    [SerializeField]
    private float colliderRightOffset;
    [SerializeField]
    private float colliderTopOffset;
    [SerializeField]
    private float colliderPlayerHandicap;
    private bool isInPlayerRange = false;
    private bool canHurtPlayer = true;

    [Header("VISUAL")]
    [SerializeField] private TextMeshProUGUI myText;
    [SerializeField] private SpriteRenderer mySprite;

    [Header("voic recog")]
    public bool isDifficultEnemy;
    [SerializeField] private TextMeshProUGUI audioText;
    public SpeechTypes mySpeechType = SpeechTypes.Join;

    [Header("PHILOSOPHERS")]
    [SerializeField] Sprite aristotle;
    [SerializeField] Sprite thomasSprite;
    [SerializeField] Sprite decartes;
    [SerializeField] Sprite nietszsche;
    public Dictionary<int, Philosopher> philosopherRequirements;

    private void Start()
    {
        player = GameManager.instance.currPlayer;
        myText.text = GameManager.instance.texts.GetRandomText(difficulty: 0).ToUpper();
        InitializeEnemy();
    }

    private void SetMySprite()
    {
         int year = GameManager.instance.currentYear;
        if (year < GameManager.instance.aristotleEndYear)
        {
            mySprite.sprite = aristotle;
        }
        else if (year < GameManager.instance.thomasEndYear)
        {
            mySprite.sprite = thomasSprite;
        }
        else if (year < GameManager.instance.decartesEndYear)
        {
            mySprite.sprite = decartes;
        }
        else
        {
            mySprite.sprite = nietszsche;
        }
    }

    public void InitializeEnemy()
    {
        audioText.gameObject.SetActive(false);
        SetMySprite();
        //if (!isAudioEnemy)
        //{
        //    audioText.gameObject.SetActive(false);
        //}
        //else
        //{
        //    audioText.text = "Say: trust!";
        //    GameManager.instance.speechToBeDetected.Add(mySpeechType);
        //    //  actions.Add("Join", Join);
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
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
            player.transform.position.y < colliderTopOffset + transform.position.y + colliderPlayerHandicap)
        {
            if (!isInPlayerRange)
            {
                //Debug.LogError("ya");
                isInPlayerRange = true;
                myText.color = Color.yellow;
                myText.fontStyle = FontStyles.Bold;

            }
            if (isInPlayerRange)
            {
                ListenToPlayerInput();
            }
        }
        if (player.transform.position.x > transform.position.x + 0.2f &&
            player.transform.position.x < colliderRightOffset * 0.4f + transform.position.x && 
            player.transform.position.y < colliderTopOffset * 0.4f + transform.position.y)
        {
            if (canHurtPlayer && 
                !hasInteractedWithPlayer && GameManager.instance.ProcessCollisionWithPhilosopher())
            {
                hasInteractedWithPlayer = true;
                ProcessDeath(ObstacleDeath.MissedByPlayer);
            }
            
        }
    }

    private void ListenToPlayerInput()
    {
       if (Input.inputString.ToUpper() == myText.text)
        {
            canHurtPlayer = false;
            ProcessDeath(ObstacleDeath.PunchedByPlayer);
        }
    }

    public void ProcessDeath(ObstacleDeath death)
    {
        if (isDead)
            return;
        isDead = true;
        IEnumerator die = DieAfterSeconds();
        if (death == ObstacleDeath.PunchedByPlayer ||
            death == ObstacleDeath.RecruitedByPlayer)
            canHurtPlayer = false;
        else
        {
            StartCoroutine(die);
            GameManager.instance.currPlayer.RemovePhilosopher();
            return;
        }
        if (death == ObstacleDeath.PunchedByPlayer)
        {
            mySprite.enabled = false;
            myText.color = Color.green;
            GameManager.instance.currPlayer.AddPhilosopher(mySprite.sprite);
            GameManager.instance.AddPhilosopher(1);
            die = DieAfterSeconds(0.9f);
            StartCoroutine(die);
        }
        else if (death == ObstacleDeath.RecruitedByPlayer)
        {
            audioText.color = Color.green;
            myText.enabled = false;
            mySprite.enabled = false;
            GameManager.instance.AddPhilosopher(1);
            GameManager.instance.currPlayer.AddPhilosopher(mySprite.sprite);
            die = DieAfterSeconds(0.9f);
            StartCoroutine(die);
        }
    }

    IEnumerator DieAfterSeconds(float seconds = 0)
    {
        for (int i = 0; i < GameManager.instance.speechToBeDetected.Count; i++)
        {
            if (GameManager.instance.speechToBeDetected[i] == mySpeechType)
                GameManager.instance.speechToBeDetected.RemoveAt(i);
        }
        yield return new WaitForSeconds(seconds);
        GameManager.instance.isDifficultEnemyAlive = false;
        Destroy(gameObject);
    }
}
